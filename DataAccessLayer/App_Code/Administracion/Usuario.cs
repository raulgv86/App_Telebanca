using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;
using DataAccessLayer;

/// <summary>
/// Summary description for Class1
/// </summary>
public partial class Usuario: UsuarioPersistente
{

    public bool Login(string usuario, string pass) { return false; }

    /*------------INIICIO---------------- CASO DE USO GESTION DE USUARIO -------------------------INICIO------------*/

    public bool EliminarUsuario(string usuario)
    {        
       return Handler.EliminarUsuario(usuario);
    }

    public bool ModificarUsuario(string nombre, string clave, string rol, string usuario, bool activo, string carnetIdentidad)
    {
        UsuarioPersistente TempUsuario = Handler.BuscarUsuario(usuario);
        RolPersistente TempRol = Handler.BuscarRol(rol);       
        
        TempUsuario.Nombre = nombre;
        TempUsuario.Contrasena = clave;
        TempUsuario.Activo = activo;
        TempUsuario.Rol = TempRol;
        TempUsuario.CarnetIdentidad = carnetIdentidad;

        bool Result = Handler.ModificarUsuario(TempUsuario);
        
        if (usuario == this.Usuario)
        {
            this.Nombre = TempUsuario.Nombre;
            this.Contrasena = TempUsuario.Contrasena;
            this.Rol = TempUsuario.Rol;
            this.Activo = TempUsuario.Activo;
            this.CarnetIdentidad = TempUsuario.CarnetIdentidad;
        }
        return Result;
    }

    public string[] GetListaUsuarios() 
    {        
        int cant = Handler.GetListaUsuarios().Count;
        string[] listaUsuarios = new string[cant];
        for (int i = 0; i < cant; i++)
        {
            listaUsuarios[i] = Handler.GetListaUsuarios()[i].ToString();
        }
        return listaUsuarios;
    }
    public UsuarioPersistente BuscarUsuario(string pUsuario) 
    {        
        UsuarioPersistente usuarioP = new UsuarioPersistente();
        UsuarioPersistente usuarioN = Handler.BuscarUsuario(pUsuario);
        if (usuarioN != null)
        {
            usuarioP.Usuario = usuarioN.Usuario;
            usuarioP.Rol = usuarioN.Rol;
            usuarioP.Nombre = usuarioN.Nombre;
            usuarioP.Contrasena = usuarioN.Contrasena;
            usuarioP.Activo = usuarioN.Activo;
            usuarioP.CarnetIdentidad = usuarioN.CarnetIdentidad;
            return usuarioP;
        } 
        else { return null; }

        
    }
    public bool AgregarUsuario(string nombre, string clave, string rol, string usuario,bool activo, string carnetIdentidad)
    {
        UsuarioPersistente usuarioP = new UsuarioPersistente();
        usuarioP.Nombre = nombre;
        usuarioP.Contrasena = clave;
        usuarioP.Usuario = usuario;
        usuarioP.Activo = activo;
        usuarioP.CarnetIdentidad = carnetIdentidad;
        RolPersistente rolP = new RolPersistente();
        RolPersistente rolN = Handler.BuscarRol(rol);
        rolP.Nombre = rol;
        rolP.Descripcion = rolN.Descripcion;
        rolP.Funcionalidades = rolN.Funcionalidades;
        usuarioP.Rol = rolN;
        return Handler.AgregarUsuario(usuarioP);
    }

    public string[] GetUsuario(string usuario, string clave)
    {
        UsuarioPersistente TempUser = Handler.GetUsuario(usuario, clave);
        string[] Result = new string[6];
        Result[0] = TempUser.Contrasena.ToString();
        Result[1] = TempUser.Nombre.ToString();
        Result[2] = TempUser.Rol.Nombre.ToString();
        Result[3] = TempUser.Usuario.ToString();
        Result[4] = TempUser.Activo.ToString();
        Result[5] = TempUser.CarnetIdentidad.ToString();
        return Result;
    }

    public string[] GetUsuario()
    {
        string[] Result = new string[3];
        Result[0] = this.Usuario.ToString();
        Result[1] = this.Contrasena;
        Result[2] = this.Nombre;
        return Result;
    }

    public string[][] GetDataMenu(int pModulo)
    {
        string[][] Result = new string[2][];

        List<string> TempList = new List<string>();
        List<string> TempList1 = new List<string>();
        for(int i=0; i < Rol.Modulo.Count; i++)
            if (Rol.Modulo[i] == pModulo)
            {
                TempList.Add(Rol.NombreMenu[i]);
                TempList1.Add(Rol.ValorMenu[i].ToString());
            }

        Result[0] = TempList.ToArray();
        Result[1] = TempList1.ToArray();
        return Result;
    }

    /*------------FIN---------------- CASO DE USO GESTION DE USUARIO --------------FIN-----------------------*/


    /*------------INICIO---------------- CASO DE USO GESTION DE ROL ---------------INICIO----------------------*/

    public bool ExisteRol(string nombre,string descripcion, string[] funcionalidades) 
    {
        return Handler.ExisteRol(nombre);
    }

    public bool EliminarRol(string idRol)
    {
        return Handler.EliminarRol(idRol);
    }
    
    public bool ModificarRol(string nombre, string descripcion, string[] funcionaliades)
    {
        RolPersistente rolp = new RolPersistente();
        rolp.Descripcion = descripcion;
        rolp.Nombre = nombre;
        RolPersistente rolN = Handler.BuscarRol(nombre);
        bool cambiaron = true;
        for (int i = 0; i < funcionaliades.Length; i++)
        {
            rolp.Funcionalidades.Add(funcionaliades[i].ToString());
        }
        if (rolN.Funcionalidades.Count == rolp.Funcionalidades.Count)
        {
            foreach (string i in rolp.Funcionalidades)
            {
                if (rolN.Funcionalidades.Contains(i))
                {
                    cambiaron = false;
                }
            }
        }
        if (cambiaron == true) 
        {
            if (!ExisteRolConFuncionalidades(funcionaliades))
            {
                return Handler.ModificarRol(rolp); 
            }
            else
            {
                return false;
            }
        }
        return Handler.ModificarRol(rolp);
    }

    public string[] BuscarRol(string idRol)
    {
        RolPersistente rol = Handler.BuscarRol(idRol);
        int cant = rol.Funcionalidades.Count + 2;
        string[] datosRol = new string[cant];
        datosRol[0] = rol.Nombre.ToString();
        datosRol[1] = rol.Descripcion.ToString();
        int aux = 2;
        for (int a = 0; a < rol.Funcionalidades.Count; a++)
        {
            datosRol[aux] = rol.Funcionalidades[a].ToString();
            aux++;
        }
        return datosRol;
    }

    public bool AgregarRol(string nombre, string descripcion, string[] funcionaliades)
    {
        RolPersistente rolp = new RolPersistente();
        rolp.Descripcion = descripcion;
        rolp.Nombre = nombre;
        for (int i = 0; i < funcionaliades.Length; i++)
        {
            rolp.Funcionalidades.Add(funcionaliades[i].ToString());
        }
        return Handler.AgregarRol(rolp);
    }

    public bool ExisteRolConNombre(string nombre) 
    {
        bool Result = false;
        List<RolPersistente> listaRoles = Handler.ObtenerListaRoles();
        for (int i = 0; i < listaRoles.Count; i++)
            if(listaRoles[i].Nombre==nombre)
            {
                Result = true;
                break;
            }
        return Result;
    }
    public bool ExisteRolConFuncionalidades(string[] funcionalidades) 
    {
        bool Result = false;
        List<RolPersistente> listaRoles = Handler.ObtenerListaRoles();
        List<string> listaFAux = new List<string>();
        for (int i = 0; i < funcionalidades.Length; i++)
        {
            listaFAux.Add(funcionalidades[i]);
        }
        int cont = 0;
        for (int i = 0; i < listaRoles.Count; i++)
        {
            if(listaRoles[i].Funcionalidades.Count == listaFAux.Count)
            {
               listaRoles[i].Funcionalidades.Sort();
               listaFAux.Sort();
                for (int a = 0; a < funcionalidades.Length; a++)
                {
                    if (listaFAux[a] == listaRoles[i].Funcionalidades[a]) 
                    {
                        cont++;                        
                    }
                }
                if (cont == funcionalidades.Length) { Result = true; break; }
            }
        }        
        return Result;
    }
    public string[] ObtenerListaRoles()
    {
        List<RolPersistente> listaRoles = Handler.ObtenerListaRoles();
        int cant = listaRoles.Count;
        string[] listaNombresRoles = new string[cant];
        for (int i = 0; i < cant; i++)
        {
            listaNombresRoles[i] = listaRoles[i].Nombre.ToString();
        }
        return listaNombresRoles;
    }

    public string[] ObtenerListaFuncionalidades()
    {
        List<string> funcionalidades = Handler.ObtenerListaFuncionalidades();
        int cant = funcionalidades.Count;
        string[] listaFuncionalidades = new string[cant];
        for (int i = 0; i < cant; i++)
            listaFuncionalidades[i] = funcionalidades[i].ToString();
        return listaFuncionalidades;
    }
    
    // Ver este metodo***********************************
    public bool ExisteUsuarioConRol(string nombre) 
    {
       /* 
        RolPersistente TempRol = new RolPersistente();
        TempRol.Nombre = nombre;
        return Handler.ExisteUsuarioConRol(TempRol);   */
        return false;
    }

    // Ver este metodo***********************************
    public ArrayList GetRoles()
    {
        if (!Rol.Funcionalidades.Contains("Gestionar Roles"))
            throw new Exception("Error de funcionalidad");

        //RolPersistente[] TempRoles = Handler.GetRoles().ToArray();
        ArrayList Result = new ArrayList();
        //foreach (RolPersistente i in TempRoles)
        //    Result.Add(i.Nombre);
        return Result;
    }

    
    /*-----------FIN---------------- CASO DE USO GESTION DE ROL --------------------------FIN----------------------*/


    /*-----------INICO---------------- CASO DE USO GESTION CONFIGURACION --------------------------INICIO----------------------*/

    public bool ExisteConfCreada() 
    {
        return Handler.ExisteConfCreada();
    }

    public bool ModificarConfiguracion(string direccionServidorBd, DateTime horaConciliaciones, string direccionServidorFtp, string UsuarioFtp, string ContraseñaFtp, DateTime tiempoInactividad, string direccionSalvaBd, DateTime horaInicioPeticiones, DateTime horaSalva, string imprPin, string imprTarj)    {
        Configuracion configuracion = new Configuracion(direccionServidorBd, horaConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, tiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj);
        
        // linea puesta por Raul. La de arriba era la que estaba(en esta ultima es para probar la copia de los ficheros hacia la BD usando usuario y contraseña pero al final se queda la original de arriba)
        //Configuracion configuracion = new Configuracion(direccionServidorBd,usuarioBD,ContrasenaBD, horaConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, tiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj); // Raul
        configuracion.HoraSalva = horaSalva;
       
        bool aux = Handler.ModificarConfiguracion(configuracion);
        try
        {
            operaciones.Actualizar();
        }
        catch (Exception)
        {

        }
        return aux;
    }

    public string[] ObtenerConfiguracion()
    {
        string[] aux = new string[11]; 
        Configuracion config = Handler.GetConfiguracion();
        aux[0]= config.DireccServBD ;
        aux[1]= config.HoraConciliaciones.ToString();
        aux[2]= config.DireccionServidorFtp;
        aux[3]= config.UsuarioFTP; 
        aux[4]= config.ContraseñaFTP;
        aux[5]= config.DireccSalvaBD;
        aux[6]= config.HoraInicioPetic.ToString();
        aux[7] = config.TiempoInactividad.ToString();
        aux[8] = config.HoraSalva.ToString();
        aux[9] = config.ImpresoraPin;
        aux[10] = config.ImpresoraTarjeta;
        return aux;
    }
    /*-----------FIN---------------- CASO DE USO GESTION CONFIGURACION --------------------------FIN----------------------*/

    /*--------INICIO----------------- CASO DE USO ACTUALIZAR INFORMACION DE TELE BANCA -----------------INICIO----------------*/

    public bool ExisteInfCreada() 
    {
        return Handler.ExisteInfCreada();
    }

    public string[] GetInformacionTb()
    {
        string[] arrInfTB = new string[10];
        InformacionTb infomTb = Handler.GetInformacionTb();

        arrInfTB[0] = infomTb.GetSetNombreTb;
        arrInfTB[1] = infomTb.GetSetDireccionTb;
        arrInfTB[2] = infomTb.GetSetTelefonoTb;
        arrInfTB[3] = infomTb.GetSetFaxTb;
        arrInfTB[4] = infomTb.GetSetUrlSitioWeb;
        arrInfTB[5] = infomTb.GetSetLogoTipo;
        arrInfTB[6] = infomTb.GetSetNombreDirector;
        arrInfTB[7] = infomTb.GetSetCorreoElectronico;
        arrInfTB[8] = infomTb.GetSetDescripcionServicios;
        arrInfTB[9] = infomTb.GetSetOrganismoTb;

        return arrInfTB;
    }

  
    public bool ModificarInformacionTb(string nombreTb, string direccionTb, string telefonoTb, string faxTb, string urlSitioWeb, string logoTipo, string nombreDirector, string correoElectronico, string organismoTb, string descripcionServicios)
    {
        InformacionTb informacionTb = new InformacionTb();
        informacionTb.GetSetNombreTb = nombreTb;
        informacionTb.GetSetDireccionTb = direccionTb;
        informacionTb.GetSetTelefonoTb = telefonoTb;
        informacionTb.GetSetFaxTb = faxTb;
        informacionTb.GetSetUrlSitioWeb = urlSitioWeb;
        informacionTb.GetSetLogoTipo = logoTipo;
        informacionTb.GetSetNombreDirector = nombreDirector;
        informacionTb.GetSetCorreoElectronico = correoElectronico;
        informacionTb.GetSetOrganismoTb = organismoTb;
        informacionTb.GetSetDescripcionServicios = descripcionServicios;

        return Handler.ModificarInformacionTb(informacionTb);
    }


    /*--------FIN----------------- CASO DE USO ACTUALIZAR INFORMACION DE TELE BANCA -----------------FIN----------------*/
    
   


    /*------------INICIO---------------- CASO DE USO MODIFICAR CONTRASEÑA ---------------INICIO----------------------*/
    public bool ModificarClave(string usuario, string nuevacontrasenna)
    {
        bool Result = Handler.ModificarClave(usuario, nuevacontrasenna);
        this.Contrasena = (Result)? nuevacontrasenna : this.Contrasena;
        return Result;
    }

    public string DevolverClave(string usuario)
    {
        UsuarioPersistente user = Handler.BuscarUsuario(usuario);
        return user.Contrasena; 
    } 

    /*------------FIN---------------- CASO DE USO MODIFICAR CONTRASEÑA --------------FIN-----------------------*/
  
    
   /*------------INICIO---------------- CASO DE USO SALVAR Y RESTAURAR DATOS    ---------------INICIO----------------------*/
    public bool SalvarDatos()
    {
        string dir = Handler.GetConfiguracion().DireccSalvaBD;        
        return Handler.HacerBackUp(dir);  
    }
    public bool RestaurarDatos(string dir) 
    {
        //string dir = Handler.GetConfiguracion().DireccSalvaBD;
        return Handler.RestaurarBaseDato(dir); 
    }
    public string[] SalvasRestaurar() 
    {
        string DireccServBD = ObtenerConfiguracion()[0];
        string tempDireccSalvaBD = ObtenerConfiguracion()[5];       
        string aux="\\Backup";
        string[] ArregloTemp = tempDireccSalvaBD.Split(new string[] { aux }, StringSplitOptions.None);
        string DireccSalvaBD = ArregloTemp[1].Insert(0, aux);        

        List<string> ls = new List<string>();
        System.IO.FileInfo[] backup = new System.IO.DirectoryInfo("\\\\"+DireccServBD+DireccSalvaBD).GetFiles("*.bak");
        for (int i = 0; i < backup.Length; i++)
        {
            ls.Add(backup[i].ToString());
		}
        return ls.ToArray();
    }

    public string InformacionMantenimiento(string tipo)
    {
        return Handler.InformacionMantenimiento(tipo);    
    }

  /*------------FIN---------------- CASO DE USO SALVAR Y RESTAURAR DATOS    ---------------FIN----------------------*/
    
    
   /*------------INICIO---------------- CASO DE USO GESTIONAR NOTIFICACION---------------INICIO----------------------*/
        public string[][] ObtenerListaNotificaciones()
        {
            string[][] notificaciones = new string[4][];
            
            List<Notificacion> lista = Handler.ObtenerListaNotificaciones();

            List<string> TempListIdNotificaciones = new List<string>();
            List<string> TempListDescripNotificaciones = new List<string>();
            List<string> TempListIdRolNotificaciones = new List<string>();
            List<string> TempListFechaNotificaciones = new List<string>();

            int cant = lista.Count;                      
            for (int i = 0; i < cant; i++) 
            {
                Notificacion notif = lista[i];
                TempListIdNotificaciones.Add(notif.Id_Notificacion.ToString());
                TempListDescripNotificaciones.Add(notif.Descripcion.ToString());
                TempListIdRolNotificaciones.Add(notif.Id_Rol.ToString());
                TempListFechaNotificaciones.Add(notif.Fecha.ToString());
            }

            notificaciones[0] = TempListIdNotificaciones.ToArray();
            notificaciones[1] = TempListDescripNotificaciones.ToArray();
            notificaciones[2] = TempListIdRolNotificaciones.ToArray();
            notificaciones[3] = TempListFechaNotificaciones.ToArray();

            return notificaciones;

        }

        public bool EliminarNotificacion(int  id_Notificacion)
        {
            return Handler.EliminarNotificacion(id_Notificacion);
        }

    public bool CargarNotificacionesBD() 
    {

        return Handler.CargarNotificacionesBD();

    }

   

        /*------------FIN---------------- CASO DE USO GESTIONAR NOTIFICACION --------------FIN-----------------------*/
    public DataSet ReporteTarjetas(int type)
    {
        DataAccessLayer.DataHandler H = new DataHandler();
         return H.Tarjetas(type);
       
    }
    //Limpiar los registros de las transacciones en TLB_Transaccion y TLB_DatosTransacciones
    public bool LimpiarTransacciones(int anno)
    {
        return Handler.LimpiarTLB_Transaccion(anno);
    }

    public DataSet N_Titular(string no_tarjeta, int tipo_cuenta, string cuenta)
    {
        DataSet result = new DataSet();

        result = Handler.Nombre_Titular(no_tarjeta, tipo_cuenta, cuenta);
        return result;
    }

    public string N_Factura(string ID, string cod)
    {
        return Handler.N_F(ID,cod);
    }

    public DataSet Cred(string no_tarjeta, string ci)
    {
        DataSet result = new DataSet();

        result = Handler.Credit(no_tarjeta, ci);
        return result;
    }

    public DataSet DCred(string notarjeta, string idserv, string no_ce, int meses)
    {
        DataSet result = new DataSet();

        result = Handler.DaCredit(notarjeta, idserv, no_ce, meses);
        return result;
    }

    public string CLlamad()
    {
        string result = Handler.N_CLlamadas();
        return result;
    }

    public string WSIS()
    {
        string result = Handler.WSIS();
        return result;
    }

    public Boolean PINWSIS(string tarjeta, int[] pos, char[] dig)
    {
        return Handler.PINWSISS(tarjeta, pos, dig);  
    }

    public Boolean COORWSIS(string tarjeta, int f, int c, string v)
    {
        return Handler.COORWSISS(tarjeta, f, c, v);
    }


    public bool Fecha_Contable(DateTime nueva_fecha)
    {
        return Handler.ModificarFechaContable_TLB_Configuracion(nueva_fecha);
    }
}
