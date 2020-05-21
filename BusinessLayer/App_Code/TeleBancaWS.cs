using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;


/// <summary>
/// Summary description for TeleBancaWS
/// </summary>
[WebService(Namespace = "http://localhost/Business/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public partial class TeleBancaWS : System.Web.Services.WebService
{
    /// <summary>
    /// Usuarios Autenticados en el Sistema
    /// </summary>
    private  static Dictionary<string, Usuario> UsuariosActivos;

    /// <summary>
    /// Nombre del usuario que está trabajando con esta sesión
    /// </summary>
    private string UsuarioActivo;

    /// <summary>
    /// Campo para el manipulador de datos
    /// </summary>
    ///     
    public TeleBancaWS()
    {
        DataAccessLayer.DataHandler.MyCurrent = HttpContext.Current;
        if (UsuariosActivos == null)
            UsuariosActivos = new System.Collections.Generic.Dictionary<string, Usuario>();
    }


    [WebMethod(EnableSession = true)]
    public bool Autenticar(string pusuario, string pcontrasena)
    {
        DataAccessLayer.DataHandler datahandler = new DataAccessLayer.DataHandler();
        bool Result = datahandler.Login(pusuario,pcontrasena);
        if (Result)
        {

            if (!UsuariosActivos.ContainsKey(pusuario.ToLower()))
            {
                Usuario TempUser = new Usuario(datahandler.GetUsuario(pusuario, pcontrasena));
                TempUser.Handler = datahandler;
                UsuariosActivos.Add(TempUser.Usuario.ToLower(), TempUser);
                Session["UsuarioAut"] = TempUser.Usuario.ToString();

            }
            //else
            //{

            //    throw new Exception("!!! Usuario conectado al Sistema desde otra Estación de Trabajo !!!");
            //}

        }

        
        Session["UserName"] = UsuarioActivo = (Result) ? pusuario.ToLower() : string.Empty;
        Usuario.Operaciones = Usuario.Operaciones == null? new COperacionAutomatica():Usuario.operaciones;
        return Result;
    }


    [WebMethod(EnableSession = true)]
    public void Salir()
    {      
        UsuariosActivos.Remove(Session["UserName"].ToString());
        
        //StaticDispose(Session["UserName"].ToString());
        Session["UserName"] = null;
    }
   
 
    
    /// <summary>
    /// Extrae de la lista de usuarios el usuario con el que se está trabajando
    /// </summary>    
    private Usuario GetUsuarioActual
    {
        get
        {            
            if (Session["UserName"] == null)
                throw new Exception("Sessión nula... Usuario no autenticado");
            if (UsuarioActivo == null)
                UsuarioActivo = Session["UserName"].ToString();
            Usuario a = UsuariosActivos[UsuarioActivo];
            return a ;
        }
    }

    private void InitializeComponent()
    {
    }


    public static void StaticDispose(string pUserName)
    {
        if (UsuariosActivos.ContainsKey(pUserName))
            UsuariosActivos.Remove(pUserName);       
    }

    [WebMethod(EnableSession = true)]
    public void BuscarSaldo(int numTarjeta)
    {
        throw new System.NotImplementedException();
    }

    [WebMethod(EnableSession = true)]
    public string[][] GetDataMenu(int pModulo)
    {
        return GetUsuarioActual.GetDataMenu(pModulo);
    }

    [WebMethod(EnableSession = true)]
    public bool SalvarTransacciones(int anno)
    {
        return GetUsuarioActual.LimpiarTransacciones(anno);
    }

    [WebMethod(EnableSession = true)]
    public DataSet Titular(string no_tarjeta, int tipo_cuenta, string cuenta)
    {
        DataSet tit = new DataSet();        
        tit = GetUsuarioActual.N_Titular(no_tarjeta,tipo_cuenta, cuenta);
        return tit;
    }

    [WebMethod(EnableSession = true)]
    public DataSet Credito(string no_tarjeta, string ci)
    {
        DataSet cre = new DataSet();
        cre = GetUsuarioActual.Cred(no_tarjeta, ci);
        return cre;
    }

    [WebMethod(EnableSession = true)]
    public DataSet DatosCredito(string no_tarjeta, string idserv, string ce, int meses)
    {
        DataSet dcre = new DataSet();
        dcre = GetUsuarioActual.DCred(no_tarjeta, idserv, ce, meses);
        return dcre;
    }

    [WebMethod(EnableSession = true)]
    public string CLlamadas()
    {
        string cll = GetUsuarioActual.CLlamad();
        return cll;
    }

    [WebMethod(EnableSession = true)]
    public string WSIS()
    {
        string ws = GetUsuarioActual.WSIS();
        return ws;
    }

    [WebMethod(EnableSession = true)]
    public void PINWSIS(string tarjeta, int[] pos, char[] dig)
    {
       GetUsuarioActual.PINWSIS(tarjeta, pos, dig);
        
    }

    

}



 