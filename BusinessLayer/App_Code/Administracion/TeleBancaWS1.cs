using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DataAccessLayer;
using System.Data;

/// <summary>
/// Summary description for TeleBancaWS1
/// </summary>
public partial class TeleBancaWS : System.Web.Services.WebService
{
    /*------------INICIO---------------- CASO DE USO GESTION DE USUARIO ---------------INICIO----------------------*/

    [WebMethod(EnableSession = true)]
    public bool ModificarUsuario(string nombre, string clave, string rol, string usuario, bool activo, string carnetIdentidad)
    {
        return GetUsuarioActual.ModificarUsuario(nombre, clave, rol, usuario, activo, carnetIdentidad);
    }

    [WebMethod(EnableSession = true)]
    public string[] getUsuariActivo()
    {
        return GetUsuarioActual.GetUsuario();
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarUsuario(string usuario)
    {
        if (UsuariosActivos.ContainsKey(usuario))
            return false;
        return GetUsuarioActual.EliminarUsuario(usuario);
    }

    [WebMethod(EnableSession = true)]
    public string[] BuscarUsuario(string usuario)
    {
        string[] datosUsuario = new string[6];
        UsuarioPersistente user = GetUsuarioActual.BuscarUsuario(usuario);
        if (user != null)
        {
            datosUsuario[0] = user.Nombre;
            datosUsuario[1] = user.Usuario;
            datosUsuario[2] = user.Contrasena;
            datosUsuario[3] = user.Rol.Nombre;
            datosUsuario[4] = user.Activo.ToString();
            datosUsuario[5] = user.CarnetIdentidad;
            return datosUsuario;
        }
        else {return null;}
    }

    [WebMethod(EnableSession = true)]
    public void AdicionarNomenclador()
    {
        throw new System.NotImplementedException();
    }
    
    [WebMethod(EnableSession = true)]
    public bool AdicionarUsuario(string nombre, string clave,string rol,string usuario,bool activo, string carnetIdentidad)
    {
        return GetUsuarioActual.AgregarUsuario(nombre, clave, rol, usuario,activo,carnetIdentidad);
    }

    [WebMethod(EnableSession = true)]
    public string[] GetUsuario(string usuario,string clave) 
    {
        string[] datosUsuario = new string[5];
        for (int i = 0; i < GetUsuarioActual.GetUsuario(usuario,clave).Length; i++)
        {
            datosUsuario[i] = GetUsuarioActual.GetUsuario(usuario, clave).GetValue(i).ToString();
        }
        return datosUsuario;
    }

    [WebMethod(EnableSession = true)]
    public string[] GetListaUsuarios()
    {
        return GetUsuarioActual.GetListaUsuarios();
    }
    /*------------FIN---------------- CASO DE USO GESTION DE USUARIO ---------------FIN----------------------*/

    /*------------INICIO---------------- CASO DE USO GESTION DE ROL ---------------INICIO----------------------*/

    [WebMethod(EnableSession = true)]
    public bool ExisteRolConNombre(string nonmbre) 
    {
        return GetUsuarioActual.ExisteRolConNombre(nonmbre);
    }

    [WebMethod(EnableSession = true)]
    public bool ExisteRolConFuncionalidades(string[] funcionalidades)
    {
        return GetUsuarioActual.ExisteRolConFuncionalidades(funcionalidades);
    }

    [WebMethod(EnableSession = true)]
    public bool ExisteRol(string nombre,string descripcion,string[] funcionalidades) 
    {
        return GetUsuarioActual.ExisteRol(nombre, descripcion, funcionalidades);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList GetRoles()
    {
        return GetUsuarioActual.GetRoles();
    }    
    
    [WebMethod(EnableSession = true)]
    public bool AdicionarRol(string nombre, string descripcion, string[] funcionalidades)
    {
        return GetUsuarioActual.AgregarRol(nombre, descripcion, funcionalidades);
    }    
    
    [WebMethod(EnableSession = true)]
    public bool EliminarRol(string idRol)
    {
        Usuario[] listaUsuario = new Usuario[UsuariosActivos.Count];
        UsuariosActivos.Values.CopyTo(listaUsuario, 0);
        foreach (Usuario i in listaUsuario)
        {
            if (i.Rol.Nombre == idRol)
            {
                return false;
            }
        }
         return GetUsuarioActual.EliminarRol(idRol);
    }

    [WebMethod(EnableSession = true)]
    public bool ModificarRol(string nombre, string descripcion, string[] funcionalidades)
    {
        return GetUsuarioActual.ModificarRol(nombre, descripcion, funcionalidades);
    }

    [WebMethod(EnableSession = true)]
    public string[] BuscarRol(string idRol)
    {
        return GetUsuarioActual.BuscarRol(idRol);
    }

    [WebMethod(EnableSession = true)]
    public string[] ObtenerListaRoles()
    {
        return GetUsuarioActual.ObtenerListaRoles();
    }

    [WebMethod(EnableSession = true)]
    public string[] ObtenerListaFuncionalidades()
    {
        return GetUsuarioActual.ObtenerListaFuncionalidades();
    }
    
    [WebMethod(EnableSession = true)]
    public bool ExisteUsuarioConRol(string idRol) 
    {
        RolPersistente rolP = new RolPersistente();
        rolP.Nombre = idRol;
        return GetUsuarioActual.ExisteUsuarioConRol(idRol);
    }

    /*------------FIN---------------- CASO DE USO GESTION DE ROL ---------------FIN----------------------*/
   

    /*------------INICIO---------------- CASO DE USO GESTION INFOMOCION DE TELE BANCA ---------------INICIO----------------------*/

    [WebMethod(EnableSession = true)]
    public bool ExisteInfCreada() 
    {
        return GetUsuarioActual.ExisteInfCreada();
    }

    [WebMethod(EnableSession = true)]
    public bool ModificarInformacionTb(string nombreTb, string direccionTb, string telefonoTb, string faxTb, string urlSitioWeb, string logoTipo, string nombreDirector, string correoElectronico, string organismoTb, string descripcionServicios)
    {
        bool Result = false;

        Result = GetUsuarioActual.ModificarInformacionTb(nombreTb, direccionTb, telefonoTb, faxTb, urlSitioWeb, logoTipo, nombreDirector, correoElectronico, organismoTb, descripcionServicios);
        return Result;       
    }

    [WebMethod(EnableSession = true)]
    public string[] GetInformacionTb() 
    {
        string[] arrInforTB = GetUsuarioActual.GetInformacionTb();

        return arrInforTB;
    }

    /*------------FIN---------------- CASO DE USO GESTION INFOMOCION DE TELE BANCA  ---------------FIN----------------------*/


    /*------------INICIO---------------- CASO DE USO GESTION CONFIGURACION ---------------INICIO----------------------*/
    [WebMethod(EnableSession = true)]
    public bool ExisteConfCreada()
    {
        return GetUsuarioActual.ExisteConfCreada();
    }

    [WebMethod(EnableSession = true)]
    public bool ModificarConfiguracion(string direccionServidorBd, string usuarioBD, string ContrasenaBD, DateTime horaConciliaciones, string direccionServidorFtp, string UsuarioFtp, string ContraseñaFtp, DateTime TiempoInactividad, string direccionSalvaBd, DateTime horaInicioPeticiones, DateTime horaSalva, string imprPin, string imprTarj)
    {
        //anterior
        return GetUsuarioActual.ModificarConfiguracion(direccionServidorBd, horaConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, TiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj);
        
        // ultimo cambio (Raul). esto era para probar la copiar de los ficheros usando ip del serv de BD con user y pass
        //return GetUsuarioActual.ModificarConfiguracion(direccionServidorBd,usuarioBD,ContrasenaBD, horaConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, TiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj); // Raul
    }
    [WebMethod(EnableSession = true)]
    public string[] ObtenerConfiguracion()
    {
        return GetUsuarioActual.ObtenerConfiguracion();

    }

    [WebMethod(EnableSession = true)]
    public string[] ObtDirecionesCadena(string aCadena)
    {
        string[] cadenas=aCadena.Split(';'); 

        List<string> listaCadenas=new List<string>();

        for (int i = 0; i < cadenas.Length; i++)
		{
            string palabra=cadenas[i].Trim(' ');

            if(palabra!="")
            {
                listaCadenas.Add(palabra);
            
            }
			 
		}

        return listaCadenas.ToArray();
    }


    [WebMethod(EnableSession = true)]
    public string[] ObtenerDirecionesCadena(string cadena) 
    {

        int cant = 0;

        for (int i = 0; i < cadena.Length; i++)
        {
            if(cadena[i].Equals(';'))
            {
                cant++;             
            }            
        }

        int pos = 0;

        string[] direcciones = new string[cant];

        string direcc = "";
        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i].Equals(';'))
            {
                direcciones[pos] = direcc;
                pos++;
                direcc = "";
            }
            else
            {
                direcc = direcc + cadena[i];
            }
        }


        return direcciones;
     
    }

    [WebMethod(EnableSession = true)]
    public bool Modificar_Fecha_Contable_BD(DateTime nueva_fecha)
    {
        try
        {
            return GetUsuarioActual.Fecha_Contable(nueva_fecha);
        }
        catch (Exception)
        {

            throw;
        }
        
    } 

    /*------------FIN---------------- CASO DE USO GESTION CONFIGURACION  ---------------FIN----------------------*/


    
    /*------------INICIO---------------- CASO DE USO MODIFICAR CONTRASEÑA ---------------INICIO----------------------*/
    [WebMethod(EnableSession = true)]
    public bool ModificarClave(string usuario, string nuevacontrasenna)
    {
        return GetUsuarioActual.ModificarClave(usuario, nuevacontrasenna);
    }

    [WebMethod(EnableSession = true)]
    public string DevolverClave(string usuario) {

        return GetUsuarioActual.DevolverClave(usuario); 
    }
    /*------------FIN---------------- CASO DE USO MODIFICAR CONTRASEÑA ---------------FIN----------------------*/
       
    /*------------INICIO---------------- CASO DE USO SALVAR Y RESTAURAR DATOS    ---------------INICIO----------------------*/
    [WebMethod(EnableSession = true)]
    public bool SalvarDatos() 
    {
        return GetUsuarioActual.SalvarDatos();    
    }

    [WebMethod(EnableSession = true)]
    public bool RestaurarDatos(string dir) 
    {
        return GetUsuarioActual.RestaurarDatos(dir); 
    }

    [WebMethod(EnableSession = true)]
    public string[] SalvasRestaurar()
    {
        return GetUsuarioActual.SalvasRestaurar();
    }
    [WebMethod(EnableSession = true)]
    public string InformacionMantenimiento(string tipo) 
    {
        return GetUsuarioActual.InformacionMantenimiento(tipo);
    }
    
    /*------------FIN---------------- CASO DE USO SALVAR Y RESTAURAR DATOS    ---------------FIN----------------------*/
    
    /*------------INICIO---------------- CASO DE USO GESTIONAR NOTIFICACION---------------INICIO----------------------*/
    [WebMethod(EnableSession = true)]
    public string[][]  ObtenerListaNotificaciones()
    {
        string[][] ArrNotif = GetUsuarioActual.ObtenerListaNotificaciones();

      return ArrNotif;
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarNotificacion( int id_Notificacion) 
    {

        return GetUsuarioActual.EliminarNotificacion(id_Notificacion);
    }


    [WebMethod(EnableSession = true)]
    public bool CargarNotificacionesBD() 
    {

        return GetUsuarioActual.CargarNotificacionesBD();
     
    }

    

    /*------------FIN---------------- CASO DE USO GESTIONAR NOTIFICACION--------------FIN-----------------------*/
    [WebMethod(EnableSession = true)]
    public  DataSet ReporteTarjetas(int type)
    {
        return GetUsuarioActual.ReporteTarjetas(type);
                
    }


}
