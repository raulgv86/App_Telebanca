using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Collections;
using DataAccessLayer;

 

/// <summary>
/// Summary description for TeleBancaWS1 
/// </summary>
public partial class TeleBancaWS : System.Web.Services.WebService
{
   #region Pago

    [WebMethod(EnableSession = true)]
    public void ActualizarSucursales()
    {
        GetUsuarioActual.ActualizarSucursales();
    }
    [WebMethod(EnableSession = true)]
    public string BuscarTarjeta(string numTarjeta)
    {
        
        return GetUsuarioActual.ObtenerTarjeta(numTarjeta);
    }

    [WebMethod(EnableSession = true)]
    public TarjetaPersistente BuscarDatosTarjeta(string numTarjeta)
    {

        return GetUsuarioActual.ObtenerDatosTarjeta(numTarjeta);
    }

    [WebMethod(EnableSession = true)]
    public string[] BuscarTarjetaPorCI(string CI)
    {
        return GetUsuarioActual.BuscarTarjetaPorCI(CI);
    }

    [WebMethod(EnableSession = true)]
    public DataSet ConsultarSaldo(string Tarjeta)
    {
        DataSet saldoss = new DataSet();
        saldoss = GetUsuarioActual.ConsultarSaldo(Tarjeta);
        return saldoss;
        
    }
    [WebMethod(EnableSession = true)]
    public DataSet Monedas(string Tarjeta)
    {
        DataSet moneda = new DataSet();
        moneda = GetUsuarioActual.ObtenerMonedas(Tarjeta);
        return moneda;

    }
    [WebMethod(EnableSession = true)]
    public DataSet ConsultarSaldoIntegrada(string tarjeta)
    {
       DataSet saldos = new DataSet();
       saldos = GetUsuarioActual.ConsultaSaldosIntegrada(tarjeta);
       return saldos;
    }
    [WebMethod(EnableSession = true)]
    public string DarNombrePro()
    {   
        
        return GetUsuarioActual.Tarjeta.NombrePropietario+" "+GetUsuarioActual.Tarjeta.Apellidos;
    }

    [WebMethod(EnableSession = true)]
    public bool CambiarEstadoTarjeta(string numeroTarjeta, string estado)
    {
        return GetUsuarioActual.CambiarEstadoTarjeta(numeroTarjeta,estado);
    }


    //**********

   

    [WebMethod(EnableSession = true)]
    public int[] PreguntarPin()
    {//se debuelven las pociciones de los dos diogitos del ping que se van a preguntar
        return GetUsuarioActual.PreguntarPin();
    }

    [WebMethod(EnableSession = true)]
    public string PreguntarCoordenada()
    {//se debuelven la coordenada de la matris que se van a preguntar
        //ejemplo {"a1"}
        return GetUsuarioActual.PreguntarCoordenada();
    }

    [WebMethod(EnableSession = true)]
    public Boolean ChequearPin(int[] ping)
    {//se le pasa un arreglo de 4, que representa digito y valor seguidamente
        //ejemplo {"1","2","2","3"}
        return GetUsuarioActual.ChequearPin(ping);
    }

    [WebMethod(EnableSession = true)]
    public Boolean ChequearCoordenada(string[] coordenadas)
    {//se le pasa un arreglo de 2, que reprecenta coordenada y segidamente el valor 
        //ejemplo {"a1","12"}
        return GetUsuarioActual.ChequearCoordenada(coordenadas);
    }

       
    

      
   
     
 //*******

    [WebMethod(EnableSession = true)]
    public int BuscarNivelAutenticacionPorCoord(string codigoServicio)
    {//devuelve la cantidad de coordenadas mas que hay que pedir
        return GetUsuarioActual.BuscarNivelAutenticacionPorCoord(codigoServicio);
    }

    [WebMethod(EnableSession = true)]
    public bool BuscarNivelAutenticacionPorCI(string codigoServicio)
    {//devuelve si hay que pedir el carnet de identidad
        return GetUsuarioActual.BuscarNivelAutenticacionPorCI(codigoServicio);
    }

    [WebMethod(EnableSession = true)]
    public string VerificarMetodoPago(string codigoServicio)
    {//devuelve el metodo (simple o complejo) de un servicio, para ser pagado
        return GetUsuarioActual.VerificarMetodoPago(codigoServicio);
    }


//**********


    [WebMethod(EnableSession = true)]
    public string EnviarTransaccion(string codigoServicio, int posAsociado, bool moneda)
    {
        return GetUsuarioActual.EnviarTransaccion(codigoServicio, posAsociado,moneda);
    }

    [WebMethod(EnableSession = true)]
    public string EnviarTransaccionPagoComplejo(string codigoServicio,string[] datos, bool moneda)
    {//datos tiene : idcliente, importe, informativo
       return GetUsuarioActual.EnviarTransaccionPagoComplejo(codigoServicio,datos, moneda);
    }


   /* [WebMethod(EnableSession = true)]
    public string BuscarCodigoError(string traza)
    {
       return GetUsuarioActual.BuscarCodigoError(traza);
    }*/
    


 
    //*******

    [WebMethod(EnableSession = true)]
    public string[] MostrarTransaccionAReclamar(string traza, int[] fechaTrans)
    {//muestra estos datos en este orden
        //Asociado, FechaHora, Importe, Usuario, No. Tarjeta,	Servicio, Nombre y Apellidos del cliente
        //if el arreglo que devuelve tiene "count=1" es que no existe la transaccion 

        return GetUsuarioActual.MostrarTransaccionAReclamar(traza, fechaTrans);
    }

    [WebMethod(EnableSession = true)]
    public string MostrarCI_Transf(string Tarjeta)
    {

        return GetUsuarioActual.ObtenerCarnet(Tarjeta);
    }

    [WebMethod(EnableSession = true)]
    public bool ReclamarTransaccion(string  idTransaccion, string descripcion)
    {

        return GetUsuarioActual.ReclamarTransaccion(idTransaccion, UsuarioActivo, descripcion); 
    } 
    

     
 
    //**//****nuevo***/
    [WebMethod(EnableSession = true)]
    public ArrayList MostrarServiciosContratados()
    {//tiene dos arraglos (string[]) con codServ y nombre de serv
        return GetUsuarioActual.MostrarServiciosContratados();
    }

   /* [WebMethod(EnableSession = true)]
    public ArrayList MostrarAsociados(string idServ)
    {
        return GetUsuarioActual.MostrarAsociados(idServ);
    }*/
    [WebMethod(EnableSession = true)]
    public string[] MostrarIdAsociados(string codigoServicio)
    {//tiene arreglo (string[]) con los id de los datos de los asociados
        return GetUsuarioActual.MostrarIdAsociados(codigoServicio);
    }


    [WebMethod(EnableSession = true)]
    public ArrayList MostrarDatosAsociadosServicio(string codigoServicio)
    {
        return GetUsuarioActual.MostrarDatosAsociadosServicio(codigoServicio);
    }


    [WebMethod(EnableSession = true)]
    public string[] BuscarNombresDatos(string[] idDato) 
    {
        return GetUsuarioActual.BuscarNombresDatos(idDato);
    }
   

    //***********

    //en la lista de datos del usuario

    [WebMethod(EnableSession = true)]
    public bool ModificarDatoPago(string idDato,string valor) 
    {
      return GetUsuarioActual.ModificarDatoPago(idDato, valor);
    }

    [WebMethod(EnableSession = true)]
    public string MostrarDatoPago(string idDato)
    {
        return GetUsuarioActual.MostrarDatoPago(idDato);
    }
    
    [WebMethod(EnableSession = true)]
    public bool EstanTodosModificados()
    {
       return GetUsuarioActual.EstanTodosModificados();
    }


    [WebMethod(EnableSession = true)]
    public void ObtenerListDatosPago(string codServ)
    {
        GetUsuarioActual.ObtenerListDatosPago(codServ);
    }
    
    [WebMethod(EnableSession = true)]
    public string[] BuscarIdDatosPago(string codServ)
    {
        return GetUsuarioActual.BuscarIdDatosPago(codServ);
    }



    /*[WebMethod(EnableSession = true)]
    public string[] BuscarDatosMuestraPagComplejo(string codServicio, string idAsociado)
    {
        return GetUsuarioActual.BuscarPagoComplejo(codServicio, idAsociado);
    }*/
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarDatosMuestraPagComplejo(string codServicio, string idAsociado)
    {
        return GetUsuarioActual.BuscarPagoComplejo(codServicio, idAsociado);
    }
   

    #endregion Pago



    #region  Banco

    /*-------Inicio--------Caso de Uso Gestionar Banco----------------------------------*/

    [WebMethod(EnableSession = true)]
    public bool AdicionarBanco(string nombre, string webServices, string password, string numBanco, string abreviatura, string centrollamad, string identificationserver)
    {
        return GetUsuarioActual.AdicionarBanco(nombre, webServices, password, numBanco, abreviatura, centrollamad, identificationserver);
    }

    [WebMethod(EnableSession = true)]
    public string[] BuscarDatosBanco(string numBanco)
    {
        return GetUsuarioActual.BuscarDatosBanco(numBanco);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList ObtenerListaBanco()
    {
        return GetUsuarioActual.ObtenerListaBanco();

    }

    [WebMethod(EnableSession = true)]
    public bool ModificarBanco(string nombre, string webServices, string password, string numBanco, string abreviatura, string centrollamad, string identificationserver)
    {
        return GetUsuarioActual.ModificarBanco(nombre, webServices, password, numBanco, abreviatura, centrollamad, identificationserver);
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarBanco(string numBanco)
    {
        return GetUsuarioActual.EliminarBanco(numBanco);
    }

    /*---------Fin---------Caso de Uso Gestionar Banco----------------------------------*/

    #endregion  Banco

    #region reporteTransaccion
    [WebMethod(EnableSession = true)]
    public ReporteTransacciones[] getLitadoTransacciones(DateTime ini, DateTime fin, string operador, string value)  //lista de datos de transaccines dado rango de fecha
    {
        return GetUsuarioActual.getLitadoTransacciones(ini, fin,operador, value);
    }
    #endregion reporteTransaccion


    #region Configurar Servicios

    [WebMethod(EnableSession = true)]
    public bool InsertarServicio(string idser, string nombre, bool autenticaPorTarjeta, bool autenticaPorCI, bool autenticaPorPin, string estado, string tipoServicio, int cantCoord, DateTime fechaDescargaFTP, int frecuncia,bool asociados)
    {
        return GetUsuarioActual.InsertarServicio(idser,nombre, autenticaPorTarjeta, autenticaPorCI, autenticaPorPin, estado, tipoServicio, cantCoord, fechaDescargaFTP, frecuncia,asociados);
    }
    [WebMethod(EnableSession = true)]
    public bool InsertarDatosAServicio(string nombServ, object[] datos)
    {
        return GetUsuarioActual.InsertarDatosAServicio(nombServ, datos);
    }
    [WebMethod(EnableSession = true)]
    public bool ModificarServicio(string idser, string nombre, bool autenticaPorTarjeta, bool autenticaPorCI, bool autenticaPorPin, string estado, string tipoServicio, int cantCoord, DateTime fechaDescargaFTP, int frecuncia, bool asociados)
    {
        return GetUsuarioActual.ModificarServicio(idser,nombre, autenticaPorTarjeta, autenticaPorCI, autenticaPorPin, estado, tipoServicio, cantCoord, fechaDescargaFTP, frecuncia,asociados);
    }
    [WebMethod(EnableSession = true)]
    public bool EliminarServicio(string nombServ)
    {
        return GetUsuarioActual.EliminarServicio(nombServ);
    }
    [WebMethod(EnableSession = true)]
    public string[] ListaServiciosExistentes()
    {
        return GetUsuarioActual.ListaServiciosExistentes();
    }

    [WebMethod(EnableSession = true)]
    public bool ContratarServicio(string aServNombre, string[] Asociados)
    {
        return GetUsuarioActual.ContratarServicio(aServNombre, Asociados, UsuarioActivo);
    }

    [WebMethod(EnableSession = true)]
    public bool ModificarContratoServicio(string aServNombre, string[] Asociados){
        return GetUsuarioActual.ModificarContratoServicio(aServNombre, Asociados, UsuarioActivo);
    }

    [WebMethod(EnableSession = true)]
    public bool DescontratarServicio(string aServNombre)
    {
        return GetUsuarioActual.DescontratarServicio(aServNombre,UsuarioActivo);
    }


    [WebMethod(EnableSession = true)]
    public ArrayList GetListaAtributosDeServicios(string nombre) //los atrivutos sencillos de un servicio
    {
        return GetUsuarioActual.GetListaAtributosDeServicios(nombre);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList GetListaDatosDeServicios(string nombSer) // los datos de un servicio
    {
        return GetUsuarioActual.GetListaDatosDeServicios(nombSer);
    }
    #endregion Configurar Servicios

    #region Configurar Datos

    [WebMethod(EnableSession = true)]
    public bool AdicionarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato)
    {
        return GetUsuarioActual.AdicionarDato(nombreDato, tipoDato, tipo, tamañoDato);
    }
    [WebMethod(EnableSession = true)]
    public bool ModificarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato, string nombreAnt)
    {
        return GetUsuarioActual.ModificarDato(nombreDato, tipoDato, tipo, tamañoDato, nombreAnt);
    }
    [WebMethod(EnableSession = true)]
    public bool EliminarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato)
    {
        return GetUsuarioActual.EliminarDato(nombreDato, tipoDato, tipo, tamañoDato);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList GetListadoTodosDatos()
    {
        return GetUsuarioActual.GetListadoTodosDatos();
    }
    [WebMethod(EnableSession = true)]
    public ArrayList GetListaDatosNoAsociados()
    {
        return GetUsuarioActual.GetListaDatosNoAsociados();
    }
    #endregion Configurar Datos


    #region Actualizar Servicio y Datos

    [WebMethod(EnableSession = true)]
    public ArrayList ActualizarServiciosDatos(object[] listBancos) 
    {
        return GetUsuarioActual.ActualizarServiciosDatos(listBancos);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList ListadoDeBancosId() 
    {
        return GetUsuarioActual.ListadoDeBancosId();

    }
    #endregion Actualizar Servicio y Datos
  
        
    /*-------Inicio--------Caso de Uso Conciliaciones Automaticas----------------------------------*/
    
    /*[WebMethod(EnableSession = true)]
    public void ConciliacionesTarjetasCalientes()
    {
        GetUsuarioActual.ConciliacionesAutomaticasTarjetasCalientes();
    }*/


    
    /*-------Fin--------Caso de Uso Conciliaciones Automaticas----------------------------------*/


    /*-------Inicio--------Caso de Uso Conciliaciones Auxiliares----------------------------------*/

    [WebMethod(EnableSession = true)]
    public bool ConciliacionesAuxTransaccion(DateTime fecha,string NumBanco)
    {
      
        return GetUsuarioActual.ConciliacionesAuxiliaresTransaccion(fecha, NumBanco);
    }

    [WebMethod(EnableSession = true)]
    public bool ConciliacionesAuxReclamacion(DateTime fecha, string NumBanco)
    {

        return GetUsuarioActual.ConciliacionesAuxiliaresReclamaciones(fecha, NumBanco);
    }


    /*-------Fin--------Caso de Uso Conciliaciones Auxiliares----------------------------------*/


    //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08***********************
    [WebMethod(EnableSession = true)]
    public string[] ObtenerMontoMulta(string art, string inciso, string peligrosidad)
    {
        return GetUsuarioActual.ObtenerMontoMulta(art, inciso, peligrosidad);
    }
    //*****************************************************************************************

    //Modificacion para obtener monto a pagar en etecsa---22/04/08*****************************
    [WebMethod(EnableSession = true)]
    public string ProcesarFicheroEtecsa(string idTelefono)
    {
        return GetUsuarioActual.ProcesarFicheroEtecsa(idTelefono);
    }
    //******************************************************************************************
    [WebMethod(EnableSession = true)]
    public void ReversarOperacion(string Id_Transaccion)
    {
         GetUsuarioActual.ReversarOperacion(Id_Transaccion);
    }
    [WebMethod(EnableSession = true)]
    public DataSet TransferenciasProv()
    {
        DataSet prov = new DataSet();
        prov = GetUsuarioActual.TransferenciasP();
        return prov;
        
    }
    [WebMethod(EnableSession = true)]
    public DataSet TransferenciasMunicipio(string codigo)
    {
        DataSet muni = new DataSet();
        muni = GetUsuarioActual.TransferenciasM(codigo);
        return muni;

    }
    [WebMethod(EnableSession = true)]
    public DataSet TransferenciasBanco(string codigo)
    {
        DataSet banco = new DataSet();
        banco = GetUsuarioActual.TransferenciasB(codigo);
        return banco;

    }
    [WebMethod(EnableSession = true)]
    public bool DesactivarUser(string pusuario)
    {
        DataAccessLayer.DataHandler datahandler = new DataAccessLayer.DataHandler();
        bool Result = datahandler.DesactivarUsuario(pusuario);
        if (!Result)
        {
            //throw new Exception("Su usuario ha sido desactivado... Contacte con el administrador del sistema.");
        }
        return Result;
    }
    [WebMethod(EnableSession = true)]
    public bool Quien_Bloquea_Usuario(string pusuario, string descripcion)
    {
        DataAccessLayer.DataHandler datahand = new DataAccessLayer.DataHandler();
        bool Result = datahand.BloqueaUsuario(pusuario, descripcion);
        if (!Result)
        {
            //throw new Exception("Su usuario ha sido desactivado... Contacte con el administrador del sistema.");
        }
        return Result;
    }

    [WebMethod(EnableSession = true)]
    public DateTime Fecha_Expira(string usuario)
    {
        try
        {
        DataAccessLayer.DataHandler datahandler = new DataAccessLayer.DataHandler();
        DataSet DS = new DataSet();
        DateTime fecha1;
        string fecha;
        DS = datahandler.Fecha_Expira(usuario);
        foreach (DataRow Row in DS.Tables[0].Rows)
        {
            fecha = Row[0].ToString();
            fecha1 = Convert.ToDateTime(fecha);
            return fecha1;
        }
        }
        catch (Exception )
            {
                throw new Exception("Fecha expiración de clave no encontrada");
            }
            return new DateTime();
    }
    [WebMethod(EnableSession = true)]
    public bool Desbloqueo_User(string usuario)
    {
        bool resultado;
        resultado = GetUsuarioActual.Desbloqueo_Usuario(usuario);
        return resultado;

    }

    [WebMethod(EnableSession = true)]
    public string Desencrypt(string pin)
    {
        DataAccessLayer.DataHandler datahand = new DataAccessLayer.DataHandler();
        string Result = datahand.Desencriptar(pin);
       
        return Result;
    }

    [WebMethod(EnableSession = true)]
    public string NombreFactura(string ID, string cod)
    {
        return GetUsuarioActual.N_Factura(ID,cod);
    }
        
           
           
            
            
        
    
}
