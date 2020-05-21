using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DataAccessLayer;

public partial class Usuario: UsuarioPersistente
{
    public DataAccessLayer.DataHandler Handler;   
	


    public static COperacionAutomatica operaciones;

    public static COperacionAutomatica Operaciones
    {
        get { return operaciones; }
        set { operaciones = value; }
    }	
    

    public Usuario(UsuarioPersistente pusuario) : base(pusuario.Usuario, pusuario.Contrasena, pusuario.Nombre, pusuario.Rol,true,pusuario.CarnetIdentidad)
    {
        if (operaciones == null)
        {
            operaciones = new COperacionAutomatica();
        }       
    }
}
     
       



