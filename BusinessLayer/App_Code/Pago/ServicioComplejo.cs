using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.IO;
using DataAccessLayer;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;



/// <summary>
/// Summary description for ServicioComplejo
/// </summary> 
public class ServicioComplejo
{
        private DateTime fecha;
        private int frecuencia;
        private DataHandler handler;
        private string directorioTemporal;//para descargar los ficheros en el cliente
        private string directorioRemoto;//donde se buscaran los ficheros en el servidor
        private string ruta_copyBD; // Raul: donde voy a copiar el fichero en el servidor de BD 
        private string codServicio;//lista con los servicios que estan activos durante y al final del proceso    
        private ManipuladorFTP manipuladorFTP;

   
    private string fichero;//ficheros que se esta procesando  

    private static string dirFicheroReporte;
    private int idNotificacion;
    

    private bool existeFichero;

    private int cantEsperaFTP;

    public ServicioComplejo(DataHandler handler, string codServicio, string directorioTemporal, string directorioRemoto, string rutaCopyBD)
        {
            this.handler = handler;
            this.codServicio = codServicio;
            this.directorioTemporal = directorioTemporal;
            this.directorioRemoto = directorioRemoto;
            this.ruta_copyBD = rutaCopyBD;    
            idNotificacion = 0;
            frecuencia = 0;
            existeFichero = false;

          cantEsperaFTP=0;
        }

    public ServicioComplejo(DateTime fecha, DataHandler handler, string codServicio, string directorioTemporal, string directorioRemoto)
    {
        this.fecha = fecha;
        this.handler = handler;
        this.codServicio = codServicio;
        this.directorioTemporal = directorioTemporal;
        this.directorioRemoto = directorioRemoto;
        
        idNotificacion = -1;
        frecuencia = 0;
        existeFichero = false;
        
        cantEsperaFTP = 0;
    }

    public static string DirFicheroReporte
    {
        get { return dirFicheroReporte; }
        set { dirFicheroReporte = value; }
    }
    public DataHandler Handler
       {
          get { return handler; }
          set { handler = value; }
       }
    public ManipuladorFTP ManipuladorFTP
        {
            get{return manipuladorFTP;}
            set{manipuladorFTP = value;}
        }
    public DateTime Fecha
        {
            get{return fecha;}
            set{fecha = value;}
        }
    public string DirectorioTemporal
        {
            get{ return directorioTemporal;}
            set{directorioTemporal = value;}
        }
    public string DirectorioRemoto
     {
        get { return directorioRemoto; }
        set{directorioRemoto = value;}
     }
    public string CodServicio
    {
        get { return codServicio; }
        set { codServicio = value; }
    }
    public int Frecuencia
    {
        get { return frecuencia; }
        set { frecuencia = value; }
    }
//************************************************************	  
    public bool Proceso(DateTime fech)
    {
        bool result_ok = false;
        try
        {
            fecha = fech;
            //fecha=handler.BuscarFechaDescargaFTP(codServicio);
        }
        catch (Exception)
        {
            handler.GuardarNotificacion("El Sistema no puede conectarse con la base de datos,buscando fecha descarga servicio "+codServicio, "Administrador");
            return false;
        }
       
         DateTime now=DateTime.Now;
         if (fecha.CompareTo(now) == -1 //esta atrasado 
             || (fecha.Year == now.Year && fecha.Month == now.Month && fecha.Day == now.Day))
        {
                try
                {
                    //ObtenerFichero(manipuladorFTP.DireccionServidor, directorioTemporal);
                    if (ObtenerFichero()) // aki lo trae del FTP 192.168.22.13
                    { 
                    // DescompactarFichero();
                    
                    //Raul: este metodo dentro ejecuta un .bat que esta en oc local que se va a encargar 
                    // de copiarlo del serv de aplicacion al serv de BD(en una ruta identica: C:\Empresas\#serv) usando la Unidad de Red creada hacia el servidor BD
                     MoverFichero_a_ServBD(); // aki lo copia en el servidor BD 192.168.22.10

                     // Este es el que busca el fichero en la ubicacion que esta y ejecuta el SP que carga el fichero txt en la tabla de la BD
                         if (ProcesarFichero2()) // aki ejecuta el sp que ejecuta el dtsx para cargarlo en la tabla de la BD
                         {
                             //handler.GuardarNotificacion("Fichero "+codServicio+" copiado satisfactoriamente en la tabla TLB_SERV_"+codServicio, "Administrador");
                             result_ok = true;
                         }
                    }
                    else
                    {
                        result_ok = false;
                    }
                         
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    frecuencia = handler.BuscarFrecuenciaDescargaFTP(codServicio);
                }
                catch (Exception)
                {
                        handler.GuardarNotificacion("No se pudo actualizar la fecha de la próxima descarga porque no hay conexión con la base de datos, servicio "+codServicio, "Administrador");
                        return false;
                }
                fecha = fecha.AddDays(frecuencia);
                try
                {
                    handler.GuardarFechaDescargaFTP(codServicio, fecha);
                }
                catch (Exception)
                {
                    handler.GuardarNotificacion("No se pudo actualizar la fecha de la próxima descarga porque no hay conexión con la base de datos, servicio "+codServicio, "Administrador");
                    return false;
                }

        }

         return result_ok;

    }

    private void MoverFichero_a_ServBD()
    {

        // fichero .bat para conectar la unidad de red creada al servidor de BD.
        string conectarUnidad = @"C:\Ficheros_Batch\conectarUnidadRed_BD.bat";
        Process conexion_unidad_red = new Process();
        conexion_unidad_red.StartInfo.FileName = conectarUnidad;
        conexion_unidad_red.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        conexion_unidad_red.Start();
        conexion_unidad_red.WaitForExit();
        conexion_unidad_red.Dispose();
        conexion_unidad_red.Close();

        Process p = new Process();

        //ruta en donde se copia el fichero que traemos del FTP
        string ruta_file_copiado=@"C:\Empresas\" + codServicio + @"\E"+codServicio + ".txt";       

        // primero preg si el fichero esta o no en la ubicacion antes de pasarlo al servidor de BD
        if (!File.Exists(ruta_file_copiado))
        {
            handler.GuardarNotificacion(new Notificacion("El fichero del servicio "+codServicio+" no se descargó del FTP", "Administrador"));
            
            // aqui buscar la manera de mostrar un cartel con la alerta de que el fichero q se trajo del FTP no se copio en 102
        }
        else
        { 
        // fichero .bat que copia el fichero txt del servidor local a ubicacion de servidor de BD
            string bat_copy = @"C:\Ficheros_Batch\copy" + codServicio + ".bat";

            if (File.Exists(bat_copy)) // si el .bat existe en la ubicacion local para poder ejecutarlo
            {
                try
                {
                    // esta seria la 2da variante para copiar los ficheros, la primera esta estudiandose (tema de los Sockets) 

                    if (codServicio == "03") // si es ONAT darle mas tiempo de ejecucion del .bat porque es muy grande
                    {
                        p = new Process();
                        p.StartInfo.FileName = bat_copy;
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.StartInfo.ErrorDialog = true;
                        p.Start();
                        p.WaitForExit(180000); //180000 milisegundos, que serian 3 min para finalizar                        
                        p.Dispose();
                        p.Refresh();
                        p.Close();
                    }
                    else
                    {
                        p = new Process();
                        p.StartInfo.FileName = bat_copy;
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.Start();
                        p.WaitForExit();
                        p.Dispose();
                        p.Close();
                    }
                        

                        // descomentarear la linea para cuando se quiera probar la copia del servidor local al de BD
                        //handler.GuardarNotificacion(new Notificacion("El fichero del servicio " + codServicio + " se copió hacia la BD satisfactoriamente", "Administrador"));

                    //EjecutarFuncionFTP("Conectarse_BD", new object[] { }, "El sistema no puede conectarse con el Servidor BD", 15);

                    string path_source = @"\"+ManipuladorFTP.DireccionServBD.ToString()+@"\Empresas\"+codServicio+@"\E"+codServicio+".txt";

                    if (File.Exists(path_source))
                    {
                        double cant_lineas = 0;
                        StreamReader fichero = new StreamReader(path_source);
                        string linea = fichero.ReadLine();                        

                        while (linea != null)
                        {
                            linea = fichero.ReadLine();
                            cant_lineas += 1;
                        }                        
                    }
                }
                catch (Exception m)
                {
                    handler.GuardarNotificacion(new Notificacion("El sistema no puede conectarse con el Servidor BD. Mensaje de Error: " + m.Message, "Administrador"));
                    //throw new Exception("El sistema no puede conectarse con el Servidor BD. Mensaje de Error: "+m.Message);
                }


            }
        }  
            // sino usar la primera variante para poder copiar el fichero del serv local al de BD (usando la clase Socket)
            //else
            //{ 
                
            //}
 
    }
//************************************************************    
    private void DescompactarFichero()
    { 
    //string directorio, string zipFic, bool eliminar, bool renombrar)
	
		    ZipInputStream z = new ZipInputStream(File.OpenRead(directorioTemporal+fichero));
			ZipEntry theEntry;
			//se obtiene el primero y unico fichero que debe estar compactado
				theEntry = z.GetNextEntry();
				if( !(theEntry == null) )
				{
                    string fileName = directorioTemporal + Path.GetFileName(theEntry.Name);

					FileStream streamWriter;
					try
					{
						streamWriter = File.Create(fileName);
					}
					catch (DirectoryNotFoundException)
					{
						Directory.CreateDirectory(Path.GetDirectoryName(fileName));
						streamWriter = File.Create(fileName);
					}
					int size = 2048;
					byte[] data = new byte[2048];
					do
					{
						size = z.Read(data, 0, data.Length);
						if( (size > 0) )
						{
							streamWriter.Write(data, 0, size);
						}
						else
						{
							break;
						}
					}while(true);
					streamWriter.Close();
				}
			z.Close();
    }
//************************************************************
    public bool ObtenerFichero()
    {
        #region Nuevo Codigo para probar la copia del fichero del FTP al servidor local

        //Stream responseStream = null;
        //FileStream fileStream = null;
        //StreamReader reader = null;

        //try
        //{
        //    string ruta_ftp = downloadUrl + directorioRemoto;
        //    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(downloadUrl + directorioRemoto);
        //    downloadRequest.Credentials = new NetworkCredential(manipuladorFTP.UsuarioFTP, manipuladorFTP.ClaveUsuarioFTP);
        //    downloadRequest.UsePassive = true;
        //    downloadRequest.UseBinary = true;
        //    downloadRequest.KeepAlive = true;
        //    FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse();
        //    responseStream = downloadResponse.GetResponseStream();

        //    string fileName = Path.GetFileName(downloadRequest.RequestUri.AbsolutePath);

        //    if (fileName.Length == 0)
        //    {
        //        reader = new StreamReader(responseStream);
        //        SqlContext.Pipe.Send(reader.ReadToEnd());
        //    }
        //    else
        //    {
        //        fileStream = File.Create(SaveToDirectory + "\\" + fileName);
        //        byte[] buffer = new byte[1024];
        //        int bytesRead;
        //        while (true)
        //        {
        //            bytesRead = responseStream.Read(buffer, 0, buffer.Length);
        //            if (bytesRead == 0)
        //                break;
        //            fileStream.Write(buffer, 0, bytesRead);
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    //Console.WriteLine(ex.Message);
        //}

        //finally
        //{
        //    if (reader != null)
        //        reader.Close();
        //    else if (responseStream != null)
        //        responseStream.Close();
        //    if (fileStream != null)
        //        fileStream.Close();
        //}

        #endregion

        bool obtener = false;

        #region Codigo original
        EjecutarFuncionFTP("Conectarse", new object[] { }, "El sistema no puede conectarse con el Servidor FTP", 15);
        EjecutarFuncionFTP("CambiarDeDirectorioRemoto", new object[] { directorioRemoto }, "El sistema no puede conectarse con el Servidor FTP", 15);
        List<string> TempList = new List<string>((string[])EjecutarFuncionFTP("DarListadoFicheros", new object[] { "*.txt" }, "El sistema no puede conectarse con el Servidor FTP", 15));
        TempList.AddRange((string[])EjecutarFuncionFTP("DarListadoFicheros", new object[] { "*.TXT" }, "El sistema no puede conectarse con el Servidor FTP", 15));
        string[] ficherosProceso = TempList.ToArray();

        fichero = ValidarLista(ficherosProceso);

        if (fichero == null)
        {
            handler.GuardarNotificacion("No hay información a descargar para el servicio " + codServicio + ".", "Administrador");
            obtener = false;
        }
        else
        {
            // manipuladorFTP.Descargar3(fichero, directorioTemporal + fichero);
            EjecutarFuncionFTP("Descargar3", new object[] { fichero, directorioTemporal + "E" + codServicio + ".txt" }, "El sistema no puede conectarse con el Servidor FTP, para actualizar el servivio " + codServicio + ".", 15);
            obtener = true;
        }
        try
        {
            manipuladorFTP.CerrarConeccion();
        }
        catch (Exception)
        {

        }
        #endregion

        return obtener;
        // EjecutarFuncionFTP("CerrarConeccion", new object[] { }, "El sistema no puede conectarse con el Servidor FTP, para actualizar el servivio " + codServicio + ".", 15);
           
        }
//************************************************************
    private string ValidarLista(string[] lista)
        {
          foreach (string nom in lista)
            {
                if (NombreValido(nom))
                {
                    existeFichero = true;
                  return nom;
                }
            }
                 return null;  
        
        }
//************************************************************
    private bool NombreValido(string nombre)
        {
            //comprobar que el nombre represente la fecha correcta
            //ESSAAMMDD.TXT 
         if (nombre.Length==13 && nombre.Substring(1, 2).Equals(codServicio) && FechaValida(nombre))
                        return true;
         return false;
        }
//************************************************************
    private bool FechaValida(string nombre)
    {
        //comprobar que el nombre represente la fecha correcta
        //ESSAAMMDD.TXT 
        string aa = Convert.ToString(fecha.Year).Substring(2, 2);
        int mm = fecha.Month;
        int dd = fecha.Day;

        if (int.Parse(nombre.Substring(7, 2)) == dd &&
           int.Parse(nombre.Substring(5, 2))== mm &&
           nombre.Substring(3, 2).Equals(aa) )
            return true;
        else
            return false;
    }
//************************************************************  
    public void ProcesarFichero()
    { //leer los ficheros descargados del FTP para pasarlos para la BD

         
         
       // if("as"=="as")
         if (existeFichero)    
        {
            //TextWriter tw1 = new StreamWriter("C:\\WINDOWS\\Temp\\Telebanca1.txt");
            //tw1.WriteLine("entro al if");
            

               // MetroHandler mh = new MetroHandler(fichero,codServicio);
                string line;
                StreamReader st = new StreamReader(directorioTemporal + "E" + codServicio + ".txt", Encoding.Default);
                PagoComplejo aux = new PagoComplejo();

                //tw1.WriteLine("Lleno el sream reader con el fichero en el directotio temp");
                //tw1.Close();
                try
                {
                    line = st.ReadLine();
                    if (line == null)
                    {
                        handler.GuardarNotificacion("Descarga desde el ftp del fichero " + fichero + " pero este está en Blanco.", "Administrador");
                        line = "fin";
                    }
                    //    throw new Exception("fichero en blanco");     Ahora el fichero puede estar en blanco
                    //handler.LimpiarServiciosComplejosTemp();
                    //while (line.Length >= 99 && line.Length <= 175)
                    {
                        //aux = new PagoComplejo();
                        //// Tipo de Servicio – 2 posiciones (información llave)
                        //aux.Tipo = line.Substring(0, 2);
                        ////Identificador del cliente – 13 posiciones (información llave)
                        //aux.Identificador = line.Substring(2, 13);
                        ////Nombre – 22 posiciones (se muestra en la pantalla))
                        //aux.Nombre = line.Substring(15, 22);
                        ////Importe – 16 posiciones (13 para enteros, 1 para punto y 2 para decimales)
                       
                        
                        ////string a = "";
                        //string b = line.Substring(37, 16);
                        //aux.Importe = Convert.ToSingle(Convert.ToDouble(b));

                        ////Descriptivo – 22 posiciones (se muestra en la pantalla)
                        //aux.Descriptivo = line.Substring(53, 22);
                        ////Informativo – 25 a 100 posiciones (no se muestra en la pantalla pero si se envía al banco en el mensaje 0200 en el bit  121)
                        //aux.Informativo = line.Substring(75);

                        //aqui lo guardo en la base de Datos con el DataHandler
                        try
                        {
                            //Handler.GuardarServicioComplejo(aux);//Sin SP
                            Handler.GuardarServicioComplejoNew(codServicio, fichero);//Con SP Modificacion 21/10/08
                        }
                        catch (Exception)
                        {
                           
                                handler.GuardarNotificacion("No se descargo la información de los ficheros por error de conexión con la base de datos", "Administrador");
                                return; 
                        }
                        try
                        {
                            //mh.NuevaLinea(aux);
                        }
                        catch (Exception ex)
                        {
                            handler.GuardarNotificacion(ex.Message,"Administrador");
                        }

                        line = st.ReadLine();
                        if (line == null || st.EndOfStream)
                            line = "fin";
                    }
                    
                    //if ((!(line.Length >= 99) || !(line.Length <= 175))&&(!line.Equals("fin"))) // ANTERIOR (SIEMPRE ENTRABA A ESTE IF Y NO DEJABA CARGAR. VER BIEN ESTO)
                    if (((line.Length >= 99) || (line.Length <= 175)) && (line.Equals("fin"))) // Raul. Probando de esta forma ahora
                    {
                        handler.GuardarNotificacion("Se descargó el Fichero " + fichero + " pero no esta en el formato requerido", "Administrador");
                        st.Close();                    
                    }
                    else
                    {
                      // Handler.LimpiarServiciosComplejos(codServicio); //Sin SP
                       
                       //TextWriter tw2 = new StreamWriter("C:\\WINDOWS\\Temp\\Telebanca2.txt");
                       //tw2.WriteLine("Va a limpiar");
                        //Handler.LimpiarServiciosComplejosNew(codServicio);//Con SP Modificacion 21/10/08
                       //tw2.WriteLine("limpio todo y paso a real");
                       //tw2.Close();
                       
                       Handler.GuardarNotificacion("Descarga del Fichero " + fichero + " completada satisfactoriamente", "Administrador");
                       st.Close();
                       //if (codServicio == "02")//Solo para Electrica
                       //{
                       //    try
                       //    {
                       //        //llamo a copiar a ftp(metro)
                       //        //si true llamo al metodo del web service asincronico
                       //        if (handler.CopiarFicheroaFTPMetro(directorioTemporal + fichero, "ftp://192.168.157.211" + "/E02.txt"))
                       //        {
                       //            //ws.ProcesaFicheroFTP(id_serv,nom_fich); + "/E02090128BIG.txt"
                       //            // handler.ConfirmaFicheroFTPMetro("E02.txt");
                       //            Handler.GuardarNotificacion("Fichero enviado a Metro satisfactoriamente", "Administrador");
                       //        }
                       //    }
                       //    catch (Exception ex)
                       //    {
                       //        Handler.GuardarNotificacion("MFichEx: " + ex.Message, "Administrador");
                       //    }
                       //}
                    }
                    try
                    {
                        handler.CambierEstadoServicio(codServicio, "AC");
                    }
                    catch (Exception)
                    {
                        handler.GuardarNotificacion("No se pudo poner el servicio activo despues de ser descargado, servicio " + codServicio, "Administrador");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("fichero en blanco"))
	                      handler.GuardarNotificacion(" El fichero del Servicio "+codServicio+" esta en blanco", "Administrador");
	                  else
                          handler.GuardarNotificacion("El fichero del servicio "+codServicio+" "+ex.Message+" no esta en el formato requerido", "Administrador");
                      handler.GuardarNotificacion(ex.Message, "Administrador");

                  try
                  {
                      handler.CambierEstadoServicio(codServicio, "NA");
                  }
                  catch (Exception)
                  {
                      handler.GuardarNotificacion("Error al conectarse con la base de datos al deshabilitar el servicio " + codServicio + "\n" + "La información del fichero: " + directorioTemporal + "/" + fichero + " tiene problemas.", "Administrador");
                  }
                }
                //st.Close();
            }
            else
            {
                handler.GuardarNotificacion("No se encuentra en el FTP el fichero " + fichero, "Administrador");
                
                try
                {
                    handler.CambierEstadoServicio(codServicio,"NA");
                }
                catch (Exception)
                {
                    handler.GuardarNotificacion("Error al conectarse con la base de datos al deshabilitar el servicio " + codServicio, "Administrador");
                }
                 
            }
          // tw1.Close(); 
    }

    public bool ProcesarFichero2()
    {
        bool result_sucess = false;

        //leer los ficheros descargados del FTP para pasarlos para la BD

        // if("as"=="as")
        if (existeFichero)
        {
            string line;
            StreamReader st = new StreamReader(directorioTemporal + "E" + codServicio + ".txt", Encoding.Default);
            line = st.ReadLine();
            if (line == null)
            {
                handler.GuardarNotificacion("Descarga desde el ftp del fichero " + fichero + " pero este está en Blanco.", "Administrador");
                line = "fin";
            }
           
            PagoComplejo aux = new PagoComplejo();
                                      
                    try
                    {
                        //Handler.GuardarServicioComplejo(aux);//Sin SP
                        if (Handler.GuardarServicioComplejoNew(codServicio, fichero))//Con SP Modificacion 21/10/08
                        { 
                            result_sucess = true;
                        }
                    }
                    catch (Exception)
                    {

                        handler.GuardarNotificacion("No se descargo la información de los ficheros por error de conexión con la base de datos", "Administrador");
                        return false;
                    }
                    try
                    {
                        line = st.ReadLine();
                        if (line == null || st.EndOfStream)
                            line = "fin";

                        if (((line.Length >= 99) || (line.Length <= 175)) && (line.Equals("fin"))) // Raul. Probando de esta forma ahora
                        {
                            handler.GuardarNotificacion("Se descargó el Fichero " + fichero + " pero no esta en el formato requerido", "Administrador");
                            st.Close();
                            result_sucess = false;
                        }
                        else
                        {
                            //Handler.GuardarNotificacion("Descarga del Fichero " + fichero + " completada satisfactoriamente", "Administrador");
                            st.Close();
                            result_sucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("fichero en blanco"))
                        {
                            handler.GuardarNotificacion(" El fichero del Servicio " + codServicio + " esta en blanco", "Administrador");
                            result_sucess = false;
                        }
                        else
                        { 
                            handler.GuardarNotificacion("El fichero del servicio " + codServicio + " " + ex.Message + " no esta en el formato requerido", "Administrador");
                            handler.GuardarNotificacion(ex.Message, "Administrador");
                            result_sucess = false;
                        }
                        try
                        {
                            handler.CambierEstadoServicio(codServicio, "NA");
                        }
                        catch (Exception)
                        {
                            handler.GuardarNotificacion("Error al conectarse con la base de datos al deshabilitar el servicio " + codServicio + "\n" + "La información del fichero: " + directorioTemporal + "/" + fichero + " tiene problemas.", "Administrador");
                        }

                        handler.GuardarNotificacion(ex.Message, "Administrador");
                    }

                    //Handler.GuardarNotificacion("Descarga del Fichero " + fichero + " completada satisfactoriamente", "Administrador");
                
                try
                {
                    handler.CambierEstadoServicio(codServicio, "AC");
                }
                catch (Exception)
                {
                    handler.GuardarNotificacion("No se pudo poner el servicio activo despues de ser descargado, servicio " + codServicio, "Administrador");
                }
                       
        }
        else
        {
            handler.GuardarNotificacion("No se encuentra en el FTP el fichero " + fichero, "Administrador");
            result_sucess = false;
            try
            {
                handler.CambierEstadoServicio(codServicio, "NA");
            }
            catch (Exception)
            {
                handler.GuardarNotificacion("Error al conectarse con la base de datos al deshabilitar el servicio " + codServicio, "Administrador");
            }

        }
        // tw1.Close(); 

        return result_sucess;
    }

    
//************************************************************
    private object EjecutarFuncionFTP(string metodo, object[] parametros, string mensajeError, int tiempoEspera)
    { 
    //
        object result = null; 
        bool fin = false;
        do
        {
            try
            {
                result = manipuladorFTP.GetType().GetMethod(metodo).Invoke(manipuladorFTP,parametros);
                //result = manipuladorFTP.GetType().GetMethod(metodo).Invoke(manipuladorFTP, parametros);
              fin = true;
              cantEsperaFTP = 0;
              EscribirFichero( "");
              if (idNotificacion != 0)
              {
                  try
                  {
                      handler.BorrarNotificacion(idNotificacion);
                  }
                  catch (Exception)
                  {
                      EscribirFichero( "Error al conectarse con la base de datos al borrar la notificacion con id:" + idNotificacion.ToString());
                  }
                  idNotificacion = 0;
              }
            }
            catch (Exception)
            {
                cantEsperaFTP++;
                if (idNotificacion == 0)
                {
                    try
                    {
                        idNotificacion = handler.GuardarNotificacion(new Notificacion(mensajeError, "Administrador"));
                        EscribirFichero( "");
                    }
                    catch (Exception)
                    {
                        EscribirFichero( mensajeError);
                    }
                }
                if (cantEsperaFTP == 3)
                {
                    throw;
                }else
                    Thread.Sleep(tiempoEspera * 60 * 1000);
             }  
        } while (!fin);
        return result;
    }
//************************************************************
    private void EscribirFichero(string mensage)
    {
        string dir = dirFicheroReporte + codServicio + ".txt";
        try
        {
            StreamWriter report = new StreamWriter(dir);
            report.WriteLine(mensage);
            report.Close();
        }
        catch (Exception)
        {
        }
       
    }

    //***************************
           
}

class MetroHandler
{
    string local = "C:\\Inetpub\\wwwroot\\Telebanca\\Ficheros\\";
    string dest = "C:\\Temp\\";
    string fichnom;

    public MetroHandler(string fichnom,string codserv)
    {
        //local = ConfigurationSettings.AppSettings["Local"];
        dest = System.Configuration.ConfigurationManager.AppSettings["DirDestFichMetro"];
        this.fichnom = fichnom;
        StreamWriter sw = new StreamWriter(local + fichnom);
        sw.Close();
    }

    public void NuevaLinea(PagoComplejo aux)
    {
        // Tipo de Servicio – 2 posiciones (información llave)
        string tipo = "  " + aux.Tipo;
        tipo = tipo.Substring(tipo.Length - 2, 2);

        //Identificador del cliente – 13 posiciones (información llave)
        string id = "             " + aux.Identificador;
        id = id.Substring(id.Length - 13, 13);

        //Nombre – 22 posiciones (se muestra en la pantalla))
        string nom = "                      " + aux.Nombre;
        nom = nom.Substring(nom.Length - 22, 22);

        //Importe – 16 posiciones (13 para enteros, 1 para punto y 2 para decimales)
        string imp = "                " + aux.Importe;
        imp = imp.Substring(imp.Length - 16, 16);

        //Descriptivo – 22 posiciones (se muestra en la pantalla)
        string desc = "                      " + aux.Descriptivo;
        desc = desc.Substring(desc.Length - 22, 22);

        //Informativo – 25 a 100 posiciones (no se muestra en la pantalla pero si se envía al banco en el mensaje 0200 en el bit  121)
        string inf = "                                                                                                    " + aux.Informativo;
        inf = inf.Substring(inf.Length - 100, 100);

        StreamWriter sw = new StreamWriter(local + fichnom, true);
        sw.WriteLine(tipo + id + nom + imp + desc + inf);
        sw.Close();
    }

    public void Copia()
    {
        System.IO.File.Copy(local + fichnom, dest + fichnom, true);
    }
}
