using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Class1
/// </summary>
public partial class Usuario : UsuarioPersistente
{

    //********** INICIO ************ CU_CONCILIACIONES AUXILIARES **********************************************
    //PROGRAMADOR: Edisbel
    public string EnviarConciliacionTarjetasCreadas(DateTime f, string IDBanco)// OK Rev 14/9/2006
    {
        try
        {            
            string[] DEVCREADAS;
            BancoPersistente BNK = Handler.GetBancoDadoID(IDBanco);
            List<string> IDSTarjetasActivas = Handler.TarjetasDeBancoCreadasEnDia(f, BNK.NumBanco);            
            if (IDSTarjetasActivas.Count == 0)
            {
                return "No existen tarjetas Activas en el dia: " + f.ToString("dd/MM/yyyy") + " para el banco: " + BNK.Nombre;
            }
            else
            {
                DEVCREADAS = Handler.EnviarConciliacionCreadas(IDSTarjetasActivas.ToArray(), BNK.WebServices);
                if (DEVCREADAS.Length == 0)
                {
                    return "Conciliacion de tarjetas Activas Enviada Satisfactoriamente al banco: " + BNK.Nombre;
                }
                else
                {
                    try
                    {
                        foreach (string j in DEVCREADAS)
                        {
                            Handler.UpdateEstadoTarjeta(j, "N");
                        }
                    }
                    catch (Exception e)
                    {
                        return "Conciliacion de Tarjetas Activas Cancelada " + e.Message;
                    }
                    return "Existen " + DEVCREADAS.Length.ToString() + " tarjetas no validas del banco: " + BNK.Nombre;
                }               
            }        
        }
        catch (Exception eX)
        {
            return eX.Message;
        }
    }
    //*********************************************************************************************************
    public string EnviarConciliacionTarjetasCanceladas(DateTime f, string IDBanco)//Ok rev 14/9/2006
    {
        try
        {
            string[] DEVCANCELADAS;
            BancoPersistente BNK = Handler.GetBancoDadoID(IDBanco);
            List<string> IDST = Handler.TarjetasCanceladasEnDiaDeBanco(f, BNK.NumBanco);
            if (IDST.Count == 0)
            {
                return "No existen tarjetas canceladas en el dia: " + f.ToString("dd/MM/yyyy") + " para el banco: " + BNK.Nombre;
            }
            else
            {
                DEVCANCELADAS = Handler.EnviarConciliacionCanceladas(IDST.ToArray(), BNK.WebServices);
                if (DEVCANCELADAS.Length == 0)
                {
                    return "Conciliacion de tarjetas Canceladas Enviada Satisfactoriamente al banco: " + BNK.Nombre;
                }
                else
                {
                    try
                    {
                        foreach (string j in DEVCANCELADAS)
                        {
                            Handler.UpdateEstadoTarjetaHistorico(j, "N");
                        }
                    }
                    catch (Exception e)
                    {
                        return "Conciliacion de Tarjetas Canceladas Cancelada " + e.Message;
                    }
                    return "Existen " + DEVCANCELADAS.Length.ToString() + " tarjetas no validas del banco: " + BNK.Nombre;
                }
            }
        }
        catch (Exception eX)
        {
            return eX.Message;
        }  
    }
    //*************************************************************************************************************
    public string EnviarConciliacionImpresas(DateTime f, string IDBanco)
    {
        try
        {
            string[] DEVIMPRESAS;
            BancoPersistente BNK = Handler.GetBancoDadoID(IDBanco);            
            List<string> IDST = Handler.TarjetasDeBancoActivasEnFecha(f, BNK.NumBanco);

            if (IDST.Count == 0)
            {
                return "No existen tarjetas Impresas(Creadas) en el dia: " + f.ToString("dd/MM/yyyy") + " para el banco: " + BNK.Nombre;
            }
            else
            {
                DEVIMPRESAS = Handler.EnviarConciliacionActivas(IDST.ToArray(), BNK.WebServices);
                if (DEVIMPRESAS.Length == 0)
                {
                    return "Conciliacion de tarjetas Impresas(Creadas) Enviada Satisfactoriamente al banco: " + BNK.Nombre;
                }
                else
                {
                    try
                    {
                        foreach (string j in DEVIMPRESAS)
                        {
                            Handler.UpdateEstadoTarjeta(j, "N");
                        }
                    }
                    catch (Exception e)
                    {
                        return "Conciliacion de Tarjetas Impresas(Creadas) Cancelada " + e.Message;
                    }
                    return "Existen " + DEVIMPRESAS.Length.ToString() + " tarjetas no validas del banco: " + BNK.Nombre;
                }
            }
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }   
    }
    //*******************************************************************************************************
    public bool ExistenTarjetasCanceladasDeBancoEnDia(DateTime f, string IDB)
    {
        try
        {
            return Handler.TarjetasCanceladasEnDiaDeBanco(f, IDB).Count > 0;
        }
        catch (Exception)
        {
            throw new Exception("No se pudieron obtener las tarjetas deshabilitadas o pedidas pues la conexión con la Base de Datos esta deshabilitada, reintente mas tarde");
        }        
    }
    //******************************************************************************************************
    public bool ExistenTarjetasActivasDeBancoEnDia(DateTime f, string IDB)
    {
        try
        {
            return Handler.TarjetasDeBancoActivasEnFecha(f, IDB).Count > 0;
        }
        catch (Exception)
        {
            throw new Exception("No se pudieron obtener las tarjetas procesadas pues la conexión con la Base de Datos esta deshabilitada, reintente más tarde");
        }
    }
    //*******************************************************************************************************
    public bool ExistenTarjetasImpresasDeBancoEnDia(DateTime f, string IDB)
    {
        try
        {
            return Handler.TarjetasDeBancoCreadasEnDia(f, IDB).Count > 0;
        }
        catch (Exception)
        {
            throw new Exception("No se pudieron obtener las tarjetas creadas pues la conexión con la Base de Datos esta deshabilitada, reintente mas tarde");
        }
    }
    //******************************************************************************************************


    //********** FIN ************ CU_CONCILIACIONES AUXILIARES **********************************************

    //********** INICIO ********** CU_REALIZAR REPORTE********************************************************
   //PROG:YOAN ANTONIO LOPEZ RGUEZ  
    public List<LotePersistente> ObtenerLotesPinfinalizadoORTarjetaFinalizado(string funcionalidadOperadora)
    {
        try
        {            
            if (funcionalidadOperadora == "Imprimir Pines")
                return Handler.ObtenerLotesEstadoPinFinDadoFecha("I",DateTime.Now);
            else
                return Handler.ObtenerLotesEstadoTFinDadoFecha("I", DateTime.Now);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }       
    }
    //OBTENER LOTES POR IMPRIMIR
    public List<LotePersistente> ObtenerLotesPinORTarjetaPorImprimir(string funcionalidadOperadora)
    {
        try
        {
            if (funcionalidadOperadora == "Imprimir Pines")
                return Handler.ObtenerLotesDadoEstadoPin("C");
            else               
                return Handler.ObtenerLotesDadoEstadoT("C");
        }
        catch (Exception )
        {
            throw new Exception("Error de conexión con la base de datos"); 
        }
    }

    //OBTENER TARJETAS DADO EL NUMERO DE LOTE
    public List<TarjetaPersistente> ObtenerTarjetasDeLote(int id_lote)
    {
        try
        {
            return Handler.ObtenerTarjetasdeLote(id_lote);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos"); 
        }     
    }
 //OBTENER DATOS DEL REPORTE DE LOTES IMPRESOS
   public List<DatosTarjetas> ReporteTarjetasImpresasOPorImprimir(int idlote)
    {

        try
        {
            List<DatosTarjetas> result = new List<DatosTarjetas>();
            string nombreSucursal, nombreBanco, idBanco, operadora;
            DatosTarjetas tarjetaReporte = new DatosTarjetas();

            List<TarjetaPersistente> tarjetas = new List<TarjetaPersistente>();
            operadora = this.Nombre;
            tarjetas = Handler.TarjetasDadoLote(idlote);
            if (tarjetas.Count == 0) throw new Exception("1");
            nombreSucursal = tarjetas[0].NoSucursal;     //Handler.BuscarNombreSucursalDadoNumero(tarjetas[0].NoSucursal);
            idBanco = tarjetas[0].IdNumeroTarjeta.Substring(0, 2);
            nombreBanco = Handler.GetBancoDadoID(idBanco).Nombre;
            foreach (TarjetaPersistente i in tarjetas)
            {
                tarjetaReporte = new DatosTarjetas(i, nombreSucursal, nombreBanco, operadora);
                result.Add(tarjetaReporte);
            }
            return result;
        }
        catch (SqlException)
        {
            throw new Exception("Error de conexión con la base de datos"); 
        
        }
    }  
    //OBTENER NOMBRE DE LA SUCURSAL   
    public string BuscarNombreSucursalDadoNumero(string NoSucursal)//obtener nombre de la sucursal              
    {
        try
        {
            return Handler.BuscarNombreSucursalDadoNumero(NoSucursal);
        }
        catch(Exception) 
        {
            throw new Exception("Error de conexión con la base de datos"); 
        }
     }

    //OBTENER NOMBRE DEL BANCO
    public string GetBancoDadoID(string idBanco)
    {
        try
        {
            return Handler.GetBancoDadoID(idBanco).Nombre;
        }
        catch(Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }
 //********CU_REALIZAR REPORTE** FIN *******************************************************************


    /* -----INICIO------------ CU_Crear_Lote-------INICIO----------*/

    //Programador: Jose

    //Listar los datos de las sucursales que tienen tarjetas sin identificador de lote y en estado creada.
        public ArrayList ListarNoSucursalTarjetasNoIdLote()
    {
        try
        {
            List<string> NoSucursales = new List<string>();
            NoSucursales = Handler.BuscarTarjetasNoIdLoteEstadoC();

            ArrayList numeroSucursal = new ArrayList();

            for (int i = 0; i < NoSucursales.Count; i++)
                if (!numeroSucursal.Contains((object)NoSucursales[i]))
                {
                    numeroSucursal.Add(NoSucursales[i]);
                }
            return numeroSucursal;
        }
        catch (Exception)
        {
            throw new Exception("No se puede llevar a cabo el proceso de creación de lotes debido a que la conexión con la base de datos está deshabilitada. Reintente más tarde.");
        }
       }
       

    //Mostrar la cantidad de tarjetas con su sucursal correspondiente que estan sin imprimir y sin
    //identificador de lote
    public ArrayList DatosTarjetasPorSucursal(string noSucursal)
    {
        try
        {
            List<TarjetaPersistente> aux = new List<TarjetaPersistente>();
            int count = 0;            
            ArrayList informe = new ArrayList();
            aux = Handler.TarjetasAImprimirPorSucursalNoIdLote(noSucursal); 

            foreach (TarjetaPersistente TP in aux)
            {
                count++;
            }

            string nombreSucursal =Handler.BuscarNombreSucursalDadoNumero(noSucursal);  
            informe.Add(nombreSucursal);
            informe.Add(count);

            return informe;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión a la Base de Datos.");
        }
    }

    
    //Mostrar las fechas que pertenecen a la sucursal seleccionada con su cantidad al lado
    public ArrayList MostrarFechaPorSucursalYCantidad(string noSucursal)
    {
        try
        {
            List<TarjetaPersistente> aux = new List<TarjetaPersistente>();
            ArrayList fechaTarjetas = new ArrayList();
            ArrayList cantidadTarjetas = new ArrayList();
            ArrayList informe = new ArrayList();

            aux = Handler.TarjetasAImprimirPorSucursalNoIdLote(noSucursal);   /* me devuelve la misma tarjeta */           

            for (int i = 0; i < aux.Count; i++)
            {
                if (!fechaTarjetas.Contains((object)aux[i].FechaOrdenImp.ToShortDateString() ))
                {
                    fechaTarjetas.Add(aux[i].FechaOrdenImp.ToShortDateString());
                    int can = Handler.ObtenerCantPorFechaYNoSucursal(aux[i].FechaOrdenImp, noSucursal);    
                    cantidadTarjetas.Add(can);  
                }            
            }

            informe.Add(fechaTarjetas);
            informe.Add(cantidadTarjetas);

            return informe;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión a la Base de Datos.");
        }
    }
       

    

    //Crear el lote con las tarjetas a imprimir y actualizar dichos registros
    //en la tabla Tarjeta
    public bool CrearLote(string noSucursal,ArrayList fechasSeleccionadas)
    {
        try 
        {
            int idLote = Handler.InsertarLote(new LotePersistente("C", "C"));          

            List<TarjetaPersistente> tarjetasLote = new List<TarjetaPersistente>();

            for (int i = 0; i < fechasSeleccionadas.Count; i++)
            {
                tarjetasLote = Handler.TarjetasAImprimirPorSucursalNoIdLoteFecha(noSucursal,Convert.ToDateTime(fechasSeleccionadas[i]));   //error
                     foreach (TarjetaPersistente TP in tarjetasLote)
                    Handler.ActualizarTarjetasAImprimir(TP.IdNumeroTarjeta, idLote);
            }
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión a la Base de Datos.");           
        }
    }


    /* -----FIN------------ CU_Crear_Lote-------FIN----------*/


    /* -----INICIO------------ CU_Imprimir_Tarjetas-------INICIO----------*/

    //Programador: Jose
    //Flujo Normal de eventos: Seleccionar el/los lote(s) para ser impresos

    //Obtener identificadores de lotes existentes con la cantidad de tarjetas de cada uno
    public string[][] DatosLotesEstadoTCreado()
    {
        try
        {
            List<LotePersistente> lotes = new List<LotePersistente>();

            lotes = Handler.BuscarLoteEstadoTC();

            string[][] informe = new string[2][];

            if (lotes.Count > 0)
            {
                List<string> idLotes = new List<string>();
                List<string> cantTarjetasLote = new List<string>();
                

                foreach (LotePersistente LP in lotes)
                {
                    idLotes.Add(LP.Id_Lote.ToString());
                    //Buscar en Tarjeta cuantas existen dado un Id_Lote
                    cantTarjetasLote.Add(LP.Tarjetas.Count.ToString());
                }

                informe[0] = idLotes.ToArray();
                informe[1] = cantTarjetasLote.ToArray();                
            }
            /*else
                Handler.GuardarNotificacion("No hay lotes pendientes de impresion", "Operadora de Tarjetas");*/
            
            return informe;

        }
        catch (Exception)
        {
            //Handler.GuardarNotificacion(error.Message, "Operadora de Tarjetas");
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }


    //Tarjetas dado Id_Lote
    public List<TarjetaPersistente> TarjetasAImprimirDadoIdLote(int idLote)
    {
        List<TarjetaPersistente> tarjetasLote = new List<TarjetaPersistente>();

        tarjetasLote = Handler.ObtenerTarjetasdeLote(idLote);

        return tarjetasLote;
    }

    //Obtener los datos de las tarjetas que se van a imprimir dado el o los lotes seleccionados
    public string[][] TarjetasAImprimir(ArrayList idLote)
    {
        try
        {
            List<TarjetaPersistente> aux = new List<TarjetaPersistente>();

            string[][] tarjetasFinales = new string[11][];

            List<string> numTarjetas = new List<string>();
            List<string> filas1 = new List<string>();
            List<string> filas2 = new List<string>();
            List<string> filas3 = new List<string>();
            List<string> filas4 = new List<string>();
            List<string> filas5 = new List<string>();
            List<string> filas6 = new List<string>();
            List<string> filas7 = new List<string>();
            List<string> filas8 = new List<string>();
            List<string> filas9 = new List<string>();
            List<string> filas10 = new List<string>();
                      

            for (int i = 0; i < idLote.Count; i++)
            {
                aux = TarjetasAImprimirDadoIdLote(Convert.ToInt32(idLote[i].ToString()));

                foreach (TarjetaPersistente TP in aux)
                {
                    numTarjetas.Add(TP.IdNumeroTarjeta);

                    Matriz matrizDesencriptada = new Tarjeta(TP).DarMatriz();             

                    filas1.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[0]));
                    filas2.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[1]));
                    filas3.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[2]));
                    filas4.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[3]));
                    filas5.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[4]));
                    filas6.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[5]));
                    filas7.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[6]));
                    filas8.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[7]));
                    filas9.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[8]));
                    filas10.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[9]));
                }
            }

            tarjetasFinales[0] = numTarjetas.ToArray();
            tarjetasFinales[1] = filas1.ToArray();
            tarjetasFinales[2] = filas2.ToArray();
            tarjetasFinales[3] = filas3.ToArray();
            tarjetasFinales[4] = filas4.ToArray();
            tarjetasFinales[5] = filas5.ToArray();
            tarjetasFinales[6] = filas6.ToArray();
            tarjetasFinales[7] = filas7.ToArray();
            tarjetasFinales[8] = filas8.ToArray();
            tarjetasFinales[9] = filas9.ToArray();
            tarjetasFinales[10] = filas10.ToArray();

            return tarjetasFinales;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Obtiene las filas con el formato que se deben mostrar por la tarjeta
    public string ObtenerFilasEspaciadas(string filaOrig)
    {
        string Result = filaOrig;
        for (int z = 2; z < Result.Length; z += 6) //Se incrementa en 4 de espacios + 2 de posición
            Result = Result.Insert(z, "    ");
        return Result;
    }

    public bool ActualizarDatosLoteT(ArrayList idLotes)
    {
        try
        {
            string idUsuarioOperadora = Usuario;
            DateTime dtValor = System.DateTime.Now;

            for (int i = 0; i < idLotes.Count; i++)
            {
                //Actualizar datos en el registro de el/los lotes que se seleccionaron para imprimir.
                //Poner en estadoT Impreso (I)
                Handler.ActualizarCamposLoteOrdenImp(Convert.ToInt32(idLotes[i].ToString()), idUsuarioOperadora, dtValor);
            }

            return true;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    

    //Flujo Normal de eventos: Reimprimir

    //Listar los numeros de tarjetas a reimprimir dado un Id_Lote con un indice al lado para usar
    //a la hora de escoger que rango quiero volver a imprimir
    
    public ArrayList ListarDatosTarjetasAReimprimir(int idLote)
    
      {
        try
        {
            LotePersistente lote = new LotePersistente();
            lote = Handler.ObtenerLoteDadoIdLote(idLote);

            ArrayList informe = new ArrayList();

            if (lote.Id_Lote == 0)
            {
                informe.Add("El lote especificado no existe");
                return informe;
            }
            else if (lote.EstadoT.CompareTo("I") != 0)
            {
                informe.Add("El lote especificado no se puede reimprimir");
                return informe;
            }
            else
            {
                List<string> numeroTarjeta = new List<string>();
                List<string> indice = new List<string>();
                List<string> nombre = new List<string>();
                List<string> apellidos = new List<string>();
                List<string> cliente = new List<string>();

                List<TarjetaPersistente> tarjetasReimp = new List<TarjetaPersistente>();

                tarjetasReimp = TarjetasAImprimirDadoIdLote(idLote);

                for (int i = 0; i < tarjetasReimp.Count; i++)
                {
                    int aux = i + 1;
                    indice.Add(aux.ToString());
                    numeroTarjeta.Add(tarjetasReimp[i].IdNumeroTarjeta);
                    nombre.Add(tarjetasReimp[i].NombrePropietario);
                    apellidos.Add(tarjetasReimp[i].Apellidos);
                    cliente.Add(tarjetasReimp[i].IdCliente);
              
                
                }

                informe.Add(indice.ToArray());
                informe.Add(numeroTarjeta.ToArray());
                informe.Add(nombre.ToArray());
                informe.Add(apellidos.ToArray());
                informe.Add(cliente.ToArray());
                return informe;
            }

        }
        catch (Exception )
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Reimprimir el rango de tarjetas seleccionados
    public string[][] TarjetasAReimprimir(int indiceInicio, int indiceFin, int IdLote)
    {
        try
        {
            ArrayList listaOriginal = new ArrayList();
            string[][] listaDeseada = new string[11][];
            TarjetaPersistente aux = new TarjetaPersistente();
            listaOriginal = ListarDatosTarjetasAReimprimir(IdLote);

            List<string> numTarjetas = new List<string>();
            List<string> filas1 = new List<string>();
            List<string> filas2 = new List<string>();
            List<string> filas3 = new List<string>();
            List<string> filas4 = new List<string>();
            List<string> filas5 = new List<string>();
            List<string> filas6 = new List<string>();
            List<string> filas7 = new List<string>();
            List<string> filas8 = new List<string>();
            List<string> filas9 = new List<string>();
            List<string> filas10 = new List<string>();

            string[] arrOK = new string[indiceFin - indiceInicio + 1];
            int index = 0;
            for (int j = indiceInicio - 1; j < indiceFin; j++)
                arrOK[index++] = ((string[])listaOriginal[1])[j];
            listaDeseada[1] = arrOK;

            string[] ids = listaDeseada[1] as string[];
            for (int i = 0; i < ids.Length; i++)
            {
                aux = Handler.BuscarTarjeta(ids[i]);
                numTarjetas.Add(aux.IdNumeroTarjeta);
                Matriz matrizDesencriptada = new Tarjeta(aux).DarMatriz();

                filas1.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[0]));
                filas2.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[1]));
                filas3.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[2]));
                filas4.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[3]));
                filas5.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[4]));
                filas6.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[5]));
                filas7.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[6]));
                filas8.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[7]));
                filas9.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[8]));
                filas10.Add(ObtenerFilasEspaciadas(matrizDesencriptada.Filas[9]));
            }

            listaDeseada[0] = numTarjetas.ToArray();
            listaDeseada[1] = filas1.ToArray();
            listaDeseada[2] = filas2.ToArray();
            listaDeseada[3] = filas3.ToArray();
            listaDeseada[4] = filas4.ToArray();
            listaDeseada[5] = filas5.ToArray();
            listaDeseada[6] = filas6.ToArray();
            listaDeseada[7] = filas7.ToArray();
            listaDeseada[8] = filas8.ToArray();
            listaDeseada[9] = filas9.ToArray();
            listaDeseada[10] = filas10.ToArray();

            return listaDeseada;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Salvar operacion de reimprimir a la Tabla AccionUsuario
    public bool SalvarOperacionReimpresionT(int indiceInicio, int indiceFin, int IdLote)
    {
        try
        {
            string idUsuarioOperadora = Usuario;
            string funcionalidad = "Reimprimir";
            DateTime dtValor = System.DateTime.Now;
            List<string> descripcion = new List<string>();

            string[][] tarjetasReimpresas = TarjetasAReimprimir(indiceInicio, indiceFin, IdLote);

            string[] ids = tarjetasReimpresas[0] as string[];

            for (int i = 0; i < ids.Length; i++)
            {
                descripcion.Add(ids[i]);
            }

            return Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(idUsuarioOperadora,
                                                                        funcionalidad, dtValor, descripcion));
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Flujo Normal de eventos: Finalizar

    //Actualizar estadoT dado el  id del Lote: poner en estado finalizado "F"
    public void FinalizarImpresionDeTarjetas(int ID_Lote)
    {
        try
        {   
            LotePersistente L;
            List<TarjetaPersistente> aux = new List<TarjetaPersistente>();
            DateTime dt = System.DateTime.Now;
            
                Handler.ActualizarEstadoTLote(ID_Lote,dt);
                L = Handler.ObtenerLoteDadoIdLote(ID_Lote);
                if (L.EstadoP.CompareTo("F") == 0)
                {
                   aux = Handler.ObtenerTarjetasdeLote(ID_Lote);
                    foreach (TarjetaPersistente TP in aux)
	                    {
		                     Handler.ModificarEstadoDeLaTarjeta(TP.IdNumeroTarjeta , "A");
	                    }
                }
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Devuelve verdadero si hay lotes con estado de tarjetas en impreso"I"
    public bool TarjetasPorReimprimir()
    {
        try
        {
            List<LotePersistente> aux = new List<LotePersistente>();
            aux = Handler.ObtenerLotesDadoEstadoT("I");
            return aux.Count != 0;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    public string[][] ListarLotesDeTarjetasImpresas() 
    {
        List<LotePersistente> lote = new List<LotePersistente>();
        lote = Handler.ObtenerLotesDadoEstadoT("I");
        string[][] listaDeseada = new string[1][];
        List<string> ID = new List<string>();

        foreach (LotePersistente LP in lote)
        {
            ID.Add(LP.Id_Lote.ToString());
        }
        listaDeseada[0] = ID.ToArray();

        return listaDeseada;
    }


    /* -----FINAL------------- CU_Imprimir_Tarjetas ------FINAL-----------*/




    /* -----INICIO------------- CU_Realizar_Reporte ----------------INICIO------*/


    public ArrayList TarjetasDadoBancoEstado(string nombrebanco, string estado)//ok
    {
        List<TarjetaPersistente> tarjeta = Handler.TarjetasDadoBancoEstado(nombrebanco, estado);

        ArrayList tarjetasFinales = new ArrayList();
        ArrayList aux = new ArrayList();
        for (int i = 0; i < tarjeta.Count; i++)
        {
            aux.Add(tarjeta[i].IdNumeroTarjeta);
            aux.Add(tarjeta[i].TipoIdentificacion);
            aux.Add(tarjeta[i].NombrePropietario);
            aux.Add(tarjeta[i].Apellidos);  
           // aux.Add(tarjeta[i].SegundoApellido);
            aux.Add(tarjeta[i].NoSucursal);
            tarjetasFinales.Add(aux);
            aux.Clear();
        }
        return tarjetasFinales;

    }

    public ArrayList TrajetasDadoSucursalEstado(string nombresucursal, string estado)
    {
        List<TarjetaPersistente> tarjeta = Handler.TarjetasDadoSucursalEstado(nombresucursal, estado);

        ArrayList tarjetasFinales = new ArrayList();
        ArrayList aux = new ArrayList();
        for (int i = 0; i < tarjeta.Count; i++)
        {
            aux.Add(tarjeta[i].IdNumeroTarjeta);
            aux.Add(tarjeta[i].TipoIdentificacion);
            aux.Add(tarjeta[i].NombrePropietario);
            aux.Add(tarjeta[i].Apellidos);
            aux.Add(tarjeta[i].NoSucursal);
            tarjetasFinales.Add(aux);
            aux.Clear();
        }
        return tarjetasFinales;
    }

    public ArrayList TarjetasImpresasDadoFecha(DateTime fecha)
    {
        List<TarjetaPersistente> tarjetaFech = Handler.TarjetasImpresasDadoFecha(fecha);

        ArrayList tarjetaFinalesFech = new ArrayList();
        ArrayList auxFech = new ArrayList();
        for (int i = 0; i < tarjetaFech.Count; i++)
        {
            auxFech.Add(tarjetaFech[i].IdNumeroTarjeta);
            auxFech.Add(tarjetaFech[i].TipoIdentificacion);
            auxFech.Add(tarjetaFech[i].IdNumeroTarjeta);
            auxFech.Add(tarjetaFech[i].NombrePropietario);
            auxFech.Add(tarjetaFech[i].Apellidos);
           // auxFech.Add(tarjetaFech[i].SegundoApellido);
            tarjetaFinalesFech.Add(auxFech);
            auxFech.Clear();
        }
        return tarjetaFinalesFech;

    }

    public ArrayList ListaTarjeta()
    {
        List<TarjetaPersistente> Tarjetas = Handler.ObtenerListaTarjeta();
        ArrayList nombrestarjetas = new ArrayList();

        for (int i = 0; i < Tarjetas.Count; i++)
        {
            nombrestarjetas.Add(Tarjetas[i].IdLote);

        }

        return nombrestarjetas;
    }

    public ReporteContenido[] LoteContenido(int idLote)
    {
        // Se debe modificar...

        ReporteContenido[] reporte = new ReporteContenido[1];
        reporte[0] = Handler.ReporteContenido(idLote);
        return reporte;
    }

    public LotePersistente[] LotesDadoOperadora(string operadora)
    {

        LotePersistente[] lote = Handler.LotesDadoOperadora(operadora).ToArray();
        return lote;
    }

    public LotePersistente[] LotesDadoIntervalo(DateTime fechI, DateTime fechF)
    {
        LotePersistente[] intervalo = Handler.LotesDadoIntervalo(fechI, fechF).ToArray();

        return intervalo;

    }
    public int LoteCantidadTarjeta(int idlote)
    {
        int cantidad = Handler.LoteCantidadTarjeta(idlote);
        return cantidad;

    }



    /* -----FINAL------------- CU_Realizar_Reporte ----------------FINAL------*/

    /* -----INICIO---------CU_Solicitudes de Baja de la Tarjeta----INICIO----------*/
     
        //El code inherente a este bloque debe estar solamente dentro de las operaciones automaticas...
        //no tiene contraparte desde lo visual....

    /* -----FIN---------CU_Solicitudes de Baja de la Tarjeta----FIN----------*/

    /* -----INICIO--------------CU_CaptarMatrices------------INICIO---------*/

    public List<Matriz> CargarMatricesFichero(string dir)
    {
        List<Matriz> listaMatrices = new List<Matriz>();
        Matriz matrizFichero = new Matriz(); 
        string linea = "";
        try
        {
            using (StreamReader sr = File.OpenText(dir))
            {
                int i = -1;
                while ((linea = sr.ReadLine()) != null)
                {                   
                    if (i == -1)
                    {
                        if (linea.Length < 10)
                        {
                            matrizFichero.ID = Convert.ToInt32(linea);
                            i++;
                        }
                        else
                        {
                            throw new Exception("No se pueden encriptar las matrices del fichero especificado debido a que el formato no es correcto");
                        }
                    }
                    else
                    {
                        if (linea.Length == 20 )
                        {
                            matrizFichero.Filas[i++] = linea;
                        }
                        else
                            throw new Exception("No se pueden encriptar las matrices del fichero especificado debido a que el formato no es correcto");
                    }

                    if (i > 9)
                    {
                        listaMatrices.Add(matrizFichero);
                        i = -1;
                        matrizFichero = new Matriz();
                    }
                }
            }
            if (listaMatrices.Count > 0)
            {
                return listaMatrices;
            }
            else throw new Exception("El fichero especificado esta vacio");            
        }
        catch (Exception error)
        {
            throw error;
        }
    }

    public List<Matriz> EncriptarMatrices(List<Matriz> matrices)
    {
        List<Matriz> matri = new List<Matriz>();

        try
        {
            for (int i = 0; i < matrices.Count; i++)
            {
                Matriz m = new Matriz();
                m.Filas = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarMatriz(matrices[i].Filas);
                m.Estado = "Desocupada";
                m.Encriptada = true;
                m.ID = matrices[i].ID;
                matri.Add(m);
            }
            return matri;
        }
        catch (Exception error)
        {
            throw error;
        }
    }

    public int GuardarMatrices(List<Matriz> matrices)
    {
        try
        {            
            Handler.IncertarMatricesEncriptadasBD(matrices);            
                return matrices.Count;            
        
        }
        catch (SqlException er)
        {
            if (er.Message.Substring(0,24) == "Violation of PRIMARY KEY")               
               throw new Exception("El fichero contienen matrices que ya existen");            
            else
                throw new Exception("No se pudo captar las nuevas  matrices. La conexión con la base de datos está deshabilitada. Reintente más tarde");        
        }
        catch (Exception error)
        {
            throw error;
        }
    }

    public string[][] GetTorresActivas()
    {
        DriveInfo []d= DriveInfo.GetDrives();
      
        string [][]li = new string[d.Length][];
        
        for (int i = 0; i < d.Length; i++)
        {
            string[] a = new string[3]; 
            a[0] = d[i].Name;
            a[1] = d[i].DriveType.ToString();
            a[2] = d[i].IsReady.ToString();
            li[i] = a;           
        }
      return li;
    }

    public string[] BuscarSubcarpetas(string path)
    {
        DirectoryInfo a = new DirectoryInfo(path);
        if (a.Exists)
        {
            try
            {
                DirectoryInfo[] arr = a.GetDirectories();
                string[] arre = new string[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arre[i] = arr[i].Name;
                }
                return arre;
            }
            catch (Exception) 
            {
                return new string[0];
            }

        }
        else
            return new string[0];    
    }

    public string[] BuscarTxt(string path)
    {
        DirectoryInfo a = new DirectoryInfo(path);
        if (a.Exists)
        {
            try
            {
                FileInfo[] arr = a.GetFiles();
                string[] arre = new string[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    if(arr[i].Extension == ".txt")
                    arre[i] = arr[i].Name;
                }
                return arre;
            }
            catch (Exception)
            {
                return new string[0];
            }

        }
        else
            throw new Exception("La direccion : " + path + " no existe.");
    }





    /* -----FIN----------------CU_CaptarMatrices---------------FIN----------*/


    //----- INICIO -------- CU_IMPRIMIR_PINES------------------------------
    //Programador: Dennis.

    // Me da los lotes con la cantidad de pines correspondiente a cada uno de ellos.

    public string[][] CantidadPinesPorLotes()//ok
    {

        try
        {
            string creado = "C";
            string[][] Result = new string[2][];
            List<LotePersistente> lotes = new List<LotePersistente>();
           
           
                lotes = Handler.ObtenerLotesDadoEstadoPin(creado);
          
            
            if (lotes.Count > 0)
            {
                List<string> TempId = new List<string>();
                List<string> TempCant = new List<string>();
                foreach (LotePersistente LP in lotes)
                {
                    TempId.Add(LP.Id_Lote.ToString());
                    TempCant.Add(LP.Tarjetas.Count.ToString());
                }
                Result[0] = TempId.ToArray();
                Result[1] = TempCant.ToArray();
                
            }
                      
            return Result;
        }
        catch (Exception)
        {
            
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }



    // Me da el nombre del banco segun el numero de tarjeta
    public string DarNombreABanco(string numTarjeta) //ok
    {
        List<BancoPersistente> banco = new List<BancoPersistente>();

        try
        {

            banco = Handler.ObtenerListaBanco();
        }
        catch (Exception )
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }

            for (int i = 0; i < banco.Count; i++)
           {
            if (banco[i].NumBanco == (numTarjeta.Substring(0, 2)))
            {
                return banco[i].Nombre;
            }
        }
        return null;
    }

    // Datos del lote o lotes a imprimir.

    public string[][] DatosDeLotes(ArrayList idLotes)// ok
    {
        try
        {

            List<TarjetaPersistente> tarj = new List<TarjetaPersistente>();
            string [][]listaDeseada = new string[8][];

            List<string> Nombre = new List<string>();
            List<string>  Apellidos = new List<string>();
            List<string> Cliente = new List<string>();
            List<string> NumeroTarjeta = new List<string>();
            List<string> Sucursal = new List<string>();
            List<string> NumeroPin = new List<string>();
            List<string> NombreBanco = new List<string>();
            List<string> NoSucursal = new List<string>();
            
            
            for (int i = 0; i < idLotes.Count; i++)
			{
                tarj = Handler.ObtenerTarjetasdeLote(Convert.ToInt32(idLotes[i].ToString()));
			 
                           
            for (int j = 0; j < tarj.Count; j++)
                {
                    Nombre.Add(tarj[j].NombrePropietario);
                    Apellidos.Add(tarj[j].Apellidos);
                    Cliente.Add(tarj[j].IdCliente);
                    NumeroTarjeta.Add(tarj[j].IdNumeroTarjeta);
                    NumeroPin.Add(tarj[j].NoPin);
                    Sucursal.Add(Handler.BuscarNombreSucursalDadoNumero(tarj[j].NoSucursal));
                    NombreBanco.Add(DarNombreABanco(tarj[j].IdNumeroTarjeta));
                    NoSucursal.Add(tarj[j].NoSucursal);

                }
                listaDeseada[0]=Nombre.ToArray();
                listaDeseada[1]=Apellidos.ToArray();
                listaDeseada[2]=Cliente.ToArray();
                listaDeseada[3]=NumeroTarjeta.ToArray();
                listaDeseada[4]=NumeroPin.ToArray();
                listaDeseada[5]=Sucursal.ToArray();
                listaDeseada[6]=NombreBanco.ToArray();
                listaDeseada[7]=NoSucursal.ToArray();

            }
            return listaDeseada;
        }

        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Actualizar datos en la tabla Lote
    public bool ActualizarDatosLoteP(ArrayList idLotes)
    {
        try
        {
            string idUsuarioOperadora = Usuario;
            DateTime dtValor = System.DateTime.Now;

            for (int i = 0; i < idLotes.Count; i++)
            {
                
                Handler.ActualizarPinEnLote(Convert.ToInt32(idLotes[i].ToString()), idUsuarioOperadora, dtValor);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }



    // me muestra los datos de los pines que quiero reimprimir
    public ArrayList ListarDatosPinesAReimprimir(int idLote)//ok
    {
        try
        {
            LotePersistente lote = new LotePersistente();
            
           
                lote = Handler.ObtenerLoteDadoIdLote(idLote);
            
            ArrayList informe = new ArrayList();

             if (lote.Id_Lote == 0)
                {
                    informe.Add("El lote especificado no existe");                
                    return informe;
                }

                if (lote.EstadoP.CompareTo("I") != 0)
                {
                    informe.Add("El lote especificado no se puede reimprimir");
                    return informe;
                }
                else
                {

                    List<string> numeroTarjeta = new List<string>();
                    List<string> indice = new List<string>();
                    List<string> nombre = new List<string>();
                    List<string> apellidos = new List<string>();
                    List<string> cliente = new List<string>();


                    List<TarjetaPersistente> tarjetas = new List<TarjetaPersistente>();

                  
                  
                        tarjetas = Handler.ObtenerTarjetasdeLote(idLote);
                   

                    for (int i = 0; i < tarjetas.Count; i++)
                    {
                        int aux = i + 1;
                        indice.Add(aux.ToString());
                        numeroTarjeta.Add(tarjetas[i].IdNumeroTarjeta);
                        nombre.Add(tarjetas[i].NombrePropietario);
                        apellidos.Add(tarjetas[i].Apellidos);
                        cliente.Add(tarjetas[i].IdCliente);


                    }

                    informe.Add(indice.ToArray());
                    informe.Add(numeroTarjeta.ToArray());
                    informe.Add(nombre.ToArray());
                    informe.Add(apellidos.ToArray());
                    informe.Add(cliente.ToArray());

                    return informe;
                }

        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }  
    }

    // es donde se escoje el intervalo de los pines que el tipo quiere reimprimir
    // ya mandando los datos a imprimir 
    public string[][] PinesAReimprimir(int indiceInicio, int indiceFin, int IdLote)//ok
    {
        try
        {
            ArrayList listaOriginal = new ArrayList();
            string[][] listaDeseada = new string[9][];

            TarjetaPersistente aux = new TarjetaPersistente();

            listaOriginal = ListarDatosPinesAReimprimir(IdLote);

            
            List<string> sucursal = new List<string>();
            List<string> numeroPin = new List<string>();
            List<string> nombreBanco = new List<string>();
            List<string> noSucursal = new List<string>();
   

            for (int i = 0; i < listaOriginal.Count; i++)
            {
                string[] arr = listaOriginal[i] as string[];
                string[] arrOK = new string[indiceFin - indiceInicio + 1];
                int index = 0;
                for (int j = indiceInicio - 1; j < indiceFin; j++)
                    arrOK[index++] = arr[j];
                listaDeseada[i] = (arrOK);
            }

            string[] ids = listaDeseada[1] as string[];
            for (int i = 0; i < ids.Length; i++)
            {


                aux = Handler.BuscarTarjeta(ids[i]);

                sucursal.Add(Handler.BuscarNombreSucursalDadoNumero(aux.NoSucursal));
                numeroPin.Add(aux.NoPin);
                nombreBanco.Add(DarNombreABanco(aux.IdNumeroTarjeta));
                noSucursal.Add(aux.NoSucursal);


            }


            listaDeseada[listaOriginal.Count] = sucursal.ToArray();
            listaDeseada[listaOriginal.Count + 1] = numeroPin.ToArray();
            listaDeseada[listaOriginal.Count + 2] = nombreBanco.ToArray();
            listaDeseada[listaOriginal.Count + 3] = noSucursal.ToArray();

            return listaDeseada;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    
    }
    // Guarda en la tabla AccionUsuario que la operadora reimprimio pines

    public bool SalvarOperacionReimpresionP(int indiceInicio, int indiceFin, int IdLote)//ok
    {
        try
        {
            string idUsuarioOperadora = Usuario;
            string funcionalidad = "Reimprimir";
            DateTime dtValor = System.DateTime.Now;
            List<string> descripcion = new List<string>();

            string[][] PinesReimpresoss = PinesAReimprimir(indiceInicio, indiceFin, IdLote);
                        
            string[] ids = PinesReimpresoss[1] as string[];
            
            for (int i = 0; i < ids.Length; i++)
            {
                descripcion.Add(ids[i]);
            }

            return Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(idUsuarioOperadora,
                                                                        funcionalidad, dtValor, descripcion));
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //Finaliza la impresion, no dando la posibilidad a que se vuelva a imprimir cualquiera de estos Pines 

    public void FinalizarImpresionDePines(int ID_Lote)
    {   
        LotePersistente L;
        List<TarjetaPersistente> tar = new List<TarjetaPersistente>();
        DateTime dt = System.DateTime.Now;
        
        try
        {
            //lotesImpresos = Handler.ObtenerLotesDadoEstadoPin(impreso);
            //for (int i = 0; i < lotesImpresos.Count; i++)
            Handler.ActualizarEstadoPinLote(ID_Lote, dt);
            L = Handler.ObtenerLoteDadoIdLote(ID_Lote);
            if (L.EstadoT.CompareTo("F") == 0)
            {
                tar = Handler.ObtenerTarjetasdeLote(ID_Lote);
                foreach (TarjetaPersistente T in tar)
                {
                    Handler.ModificarEstadoDeLaTarjeta(T.IdNumeroTarjeta, "A");
                }

            }
                               
            
        }
        catch (Exception )
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }

    //devuelbe verdadero si hay lotes con estado de pines impreso "I"
    public bool PinesPorReimprimir()
    {
        try
        {
            List<LotePersistente> aux = new List<LotePersistente>();
            aux = Handler.ObtenerLotesDadoEstadoPin("I");
            return aux.Count != 0;
        }
        catch (Exception )
        {   
            throw new Exception("Error en la conexión con la base de datos.");
        }    
    }

    //devuelbe los lotes que estan en estado impreso "I"
    public string[][] ListarLotesDePinesImpresos()
    {
        try
        {
            List<LotePersistente> lote = new List<LotePersistente>();
            string[][] listadeseada=new string[1][];
            List<string> ID = new List<string>();

            lote = Handler.ObtenerLotesDadoEstadoPin("I");
            foreach (LotePersistente LP in lote)
            {
                ID.Add(LP.Id_Lote.ToString());
            }
            listadeseada[0] = ID.ToArray();

            return listadeseada;
        }
        catch (Exception)
        {
            throw new Exception("Error en la conexión con la base de datos.");
        }
    }


    //----- FIN -------- CU_IMPRIMIR_PINES------------------------------


    /* -----INICIO------------- CU_Realizar Busqueda -----------INICIO------*/

    public ArrayList TarjetasImpresasPorOperadora(string operadora)//ok_elwhite
    {
        string nombreOP;
        List<TarjetaPersistente> tarjetaIO = Handler.TarjetasImpresasPorOperadora(operadora);
        ArrayList tarjetaIMOP = new ArrayList();
        ArrayList aux = new ArrayList();
        UsuarioPersistente up = BuscarUsuario(operadora);
        nombreOP = up.Nombre;

        for (int i = 0; i < tarjetaIO.Count; i++)
        {
            aux.Add(tarjetaIO[i].IdNumeroTarjeta);
            aux.Add(tarjetaIO[i].NombrePropietario);
           // aux.Add(tarjetaIO[i].PrimerApellido);
            aux.Add(tarjetaIO[i].Apellidos);
            aux.Add(tarjetaIO[i].NoSucursal);
            aux.Add(nombreOP);
            tarjetaIMOP.Add(aux);
            aux.Clear();
        }
        return tarjetaIMOP;

    }
    public ArrayList PinesImpresasPorOperadora(string operadora)//ok_elwhite
    {
        string nombreOP;
        List<TarjetaPersistente> tarjetaIO = Handler.TarjetasImpresasPorOperadora(operadora);
        ArrayList aux = new ArrayList();
        ArrayList pinIO = new ArrayList();
        UsuarioPersistente up = BuscarUsuario(operadora);
        nombreOP = up.Nombre;

        for (int i = 0; i < tarjetaIO.Count; i++)
        {
            aux.Add(tarjetaIO[i].IdNumeroTarjeta);
            aux.Add(tarjetaIO[i].NombrePropietario);
          //  aux.Add(tarjetaIO[i].PrimerApellido);
            aux.Add(tarjetaIO[i].Apellidos);
            aux.Add(tarjetaIO[i].NoSucursal);
            aux.Add(nombreOP);
            pinIO.Add(aux);
            aux.Clear();
        }
        return pinIO;
    }

    public ArrayList TarjetasEnEstadoCreadaActivasDadoFecha(DateTime fecha, string estado)
    {
        List<TarjetaPersistente> tarjetaFE = Handler.TarjetasEnEstadoCreadaActivasDadoFecha(fecha, estado);
        ArrayList tarjetaFEES = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaFE.Count; i++)
        {
            aux.Add(tarjetaFE[i].IdNumeroTarjeta);
            aux.Add(tarjetaFE[i].NombrePropietario);
            //aux.Add(tarjetaFE[i].PrimerApellido);
            aux.Add(tarjetaFE[i].Apellidos);
            aux.Add(tarjetaFE[i].NoSucursal);
            tarjetaFEES.Add(aux);
            aux.Clear();
        }
        return tarjetaFEES;
    }


    public ArrayList PinesEnEstadoCreadosActivosDadoFecha(DateTime fecha, string estado)
    {
        List<TarjetaPersistente> tarjetaFE = Handler.TarjetasEnEstadoCreadaActivasDadoFecha(fecha, estado);
        ArrayList PinesFEES = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaFE.Count; i++)
        {
            aux.Add(tarjetaFE[i].IdNumeroTarjeta);
            aux.Add(tarjetaFE[i].NombrePropietario);
            //aux.Add(tarjetaFE[i].PrimerApellido);
            aux.Add(tarjetaFE[i].Apellidos);
            aux.Add(tarjetaFE[i].NoSucursal);
            aux.Add(tarjetaFE[i].EstadoPin);
            PinesFEES.Add(aux);
            aux.Clear();
        }
        return PinesFEES;
    }


    public ArrayList TarjetasDeshabilitadasPedidasDadoFecha(DateTime fecha, string estado)
    {
        List<TarjetaPersistente> tarjetaFE = Handler.TarjetasDeshabilitadasPedidasDadoFecha(fecha, estado);
        ArrayList tarjetaFEES = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaFE.Count; i++)
        {
            aux.Add(tarjetaFE[i].IdNumeroTarjeta);
            aux.Add(tarjetaFE[i].NombrePropietario);
           // aux.Add(tarjetaFE[i].PrimerApellido);
            aux.Add(tarjetaFE[i].Apellidos);
            aux.Add(tarjetaFE[i].NoSucursal);
            tarjetaFEES.Add(aux);
            aux.Clear();
        }
        return tarjetaFEES;
    }


    public ArrayList TarjetasDadoNombreCliente(string nombreCliente)//ok_elwhite
    {
        List<TarjetaPersistente> tarjetaNC = Handler.TarjetaDadoNombreCliente(nombreCliente);
        ArrayList tarjetaNOCL = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaNC.Count; i++)
        {
            aux.Add(tarjetaNC[i].IdNumeroTarjeta);
            aux.Add(tarjetaNC[i].NombrePropietario);
           // aux.Add(tarjetaNC[i].PrimerApellido);
            aux.Add(tarjetaNC[i].Apellidos);
            aux.Add(tarjetaNC[i].NoSucursal);
            aux.Add(tarjetaNC[i].Estado);
            tarjetaNOCL.Add(aux);
            aux.Clear();
        }
        return tarjetaNOCL;

    }

    public ArrayList PinesDadoNombreCliente(string nombreCliente)//ok_elwhite
    {
        List<TarjetaPersistente> tarjetaNC = Handler.TarjetaDadoNombreCliente(nombreCliente);
        ArrayList aux = new ArrayList();
        ArrayList pinNC = new ArrayList();

        for (int i = 0; i < tarjetaNC.Count; i++)
        {
            aux.Add(tarjetaNC[i].IdNumeroTarjeta);
            aux.Add(tarjetaNC[i].NombrePropietario);
          //  aux.Add(tarjetaNC[i].PrimerApellido);
            aux.Add(tarjetaNC[i].Apellidos);
            aux.Add(tarjetaNC[i].NoSucursal);
            aux.Add(tarjetaNC[i].EstadoPin);
            pinNC.Add(aux);
            aux.Clear();
        }
        return pinNC;
    }

    public ArrayList TarjetasDadoApellidoCliente(string apellidoCliente)
    {
        List<TarjetaPersistente> tarjetaAC = Handler.TarjetasDadoApellidoCliente(apellidoCliente);
        ArrayList tarjetaAPCL = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaAC.Count; i++)
        {
            aux.Add(tarjetaAC[i].IdNumeroTarjeta);
            aux.Add(tarjetaAC[i].NombrePropietario);
            //aux.Add(tarjetaAC[i].PrimerApellido);
            aux.Add(tarjetaAC[i].Apellidos);

            aux.Add(tarjetaAC[i].NoSucursal);
            aux.Add(tarjetaAC[i].Estado);
            tarjetaAPCL.Add(aux);
            aux.Clear();
        }
        return tarjetaAPCL;

    }

    public ArrayList PinesDadoApellidoCliente(string apellidoCliente)
    {
        List<TarjetaPersistente> tarjetaAC = Handler.TarjetasDadoApellidoCliente(apellidoCliente);
        ArrayList PinAPCL = new ArrayList();
        ArrayList aux = new ArrayList();

        for (int i = 0; i < tarjetaAC.Count; i++)
        {
            aux.Add(tarjetaAC[i].IdNumeroTarjeta);
            aux.Add(tarjetaAC[i].NombrePropietario);
            //aux.Add(tarjetaAC[i].PrimerApellido);
            aux.Add(tarjetaAC[i].Apellidos);
            aux.Add(tarjetaAC[i].NoSucursal);
            aux.Add(tarjetaAC[i].EstadoPin);
            PinAPCL.Add(aux);
            aux.Clear();
        }
        return PinAPCL;

    }

    public TarjetaPersistente TarjetasDadoIdCliente(string idCliente)
    {
        TarjetaPersistente tarjetaIC = Handler.TarjetasDadoIdCliente(idCliente);
        TarjetaPersistente aux = new TarjetaPersistente();

        aux.IdNumeroTarjeta = tarjetaIC.IdNumeroTarjeta;
        aux.NombrePropietario = tarjetaIC.NombrePropietario;
       // aux.PrimerApellido = tarjetaIC.PrimerApellido;
        aux.Apellidos = tarjetaIC.Apellidos;
        aux.NoSucursal = tarjetaIC.NoSucursal;
        aux.Estado = tarjetaIC.Estado;

        return aux;
    }

    public TarjetaPersistente PinesDadoIdCliente(string idCliente)
    {
        TarjetaPersistente tarjetaIC = Handler.TarjetasDadoIdCliente(idCliente);
        TarjetaPersistente aux = new TarjetaPersistente();

        aux.IdNumeroTarjeta = tarjetaIC.IdNumeroTarjeta;
        aux.NombrePropietario = tarjetaIC.NombrePropietario;
        //aux.PrimerApellido = tarjetaIC.PrimerApellido;
        aux.Apellidos = tarjetaIC.Apellidos;
        aux.NoSucursal = tarjetaIC.NoSucursal;
        aux.EstadoPin = tarjetaIC.EstadoPin;

        return aux;
    }
    /* -----FIN---------------- CU_Realizar Busqueda --------------FIN------*/


}

