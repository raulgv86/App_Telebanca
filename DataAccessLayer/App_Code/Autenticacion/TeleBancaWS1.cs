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
using System.Web.Services;
using System.Web.Services.Protocols;
using DataAccessLayer;

/// <summary>
/// Summary description for TeleBancaWS1
/// </summary>
public partial class TeleBancaWS : System.Web.Services.WebService
{
    #region CU_Realizar_Busqueda


    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasEnEstadoCreadaActivasDadoFecha(DateTime fecha, string estado)
    {
        return GetUsuarioActual.TarjetasEnEstadoCreadaActivasDadoFecha(fecha, estado);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList PinesEnEstadoCreadosActivosDadoFecha(DateTime fecha, string estado)
    {
        return GetUsuarioActual.PinesEnEstadoCreadosActivosDadoFecha(fecha, estado);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDeshabilitadasPedidasDadoFecha(DateTime fecha, string estado)
    {
        return GetUsuarioActual.TarjetasDeshabilitadasPedidasDadoFecha(fecha, estado);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasImpresasPorOperadora(string operadora)//ok
    {
        return GetUsuarioActual.TarjetasImpresasPorOperadora(operadora);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList PinesImpresasPorOperadora(string operadora)
    {
        return GetUsuarioActual.PinesImpresasPorOperadora(operadora);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDadoNombreCliente(string nombreCliente)
    {
        return GetUsuarioActual.TarjetasDadoNombreCliente(nombreCliente);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList PinesDadoNombreCliente(string nombreCliente)
    {
        return GetUsuarioActual.PinesDadoNombreCliente(nombreCliente);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDadoApellidoCliente(string apellidoCliente)
    {
        return GetUsuarioActual.TarjetasDadoApellidoCliente(apellidoCliente);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList PinesDadoApellidoCliente(string apellidoCliente)
    {
        return GetUsuarioActual.PinesDadoApellidoCliente(apellidoCliente);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public TarjetaPersistente TarjetasDadoIdCliente(string idCliente)
    {
        return GetUsuarioActual.TarjetasDadoIdCliente(idCliente);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public TarjetaPersistente PinesDadoIdCliente(string idCliente)
    {
        return GetUsuarioActual.PinesDadoIdCliente(idCliente);
    }
    #endregion
    //******************************************************************************************************
    #region CU_Realizar_Reporte

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public LotePersistente[] LotesDadoIntervalo(DateTime fechI, DateTime fechF)
    {
        return GetUsuarioActual.LotesDadoIntervalo(fechI, fechF);
    }
    //************CU REALIZAR REPORTE INICIO******************************************************************************************
    //MOSTRAR REPORTES IMPRESOS PROGRAMADOR:YOAN ANTONIO LOPEZ RODRIGUEZ

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList ObtenerLotesFinalizados()
    {
        string funcionalidadOperadora = "";
        if (GetUsuarioActual.Rol.Funcionalidades.Contains("Imprimir Pines"))
            funcionalidadOperadora = "Imprimir Pines";
        else
            if (GetUsuarioActual.Rol.Funcionalidades.Contains("Imprimir Tarjetas"))
                funcionalidadOperadora = "Imprimir Tarjetas";

        ArrayList idlotes = new ArrayList();
        List<LotePersistente> lotes = GetUsuarioActual.ObtenerLotesPinfinalizadoORTarjetaFinalizado(funcionalidadOperadora);
        foreach (LotePersistente lote in lotes)
            idlotes.Add(lote.Id_Lote.ToString());
        return idlotes;
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]

    //REPORTE DE LOTES POR IMPRIMIR
    public Datoslote[] ObtenerLotesPorImprimir()
    {
        string funcionalidadOperadora = "";
        string idBanco, nombreSucursal, nombreBanco, operadora;
        if (GetUsuarioActual.Rol.Funcionalidades.Contains("Imprimir Pines"))
            funcionalidadOperadora = "Imprimir Pines";
        else
            if (GetUsuarioActual.Rol.Funcionalidades.Contains("Imprimir Tarjetas"))
                funcionalidadOperadora = "Imprimir Tarjetas";
        List<LotePersistente> lotes = GetUsuarioActual.ObtenerLotesPinORTarjetaPorImprimir(funcionalidadOperadora);
        if (lotes.Count == 0) throw new Exception("1");
        List<Datoslote> datosLotesPorimprimir = new List<Datoslote>();
        Datoslote dlote = new Datoslote();
        TarjetaPersistente auxiliar = new TarjetaPersistente();
        foreach (LotePersistente lote in lotes)
        {
            if (lote.Tarjetas.Count == 0) continue;
            auxiliar = lote.Tarjetas[0];//primera tarjeta de cada lote
            nombreSucursal = GetUsuarioActual.BuscarNombreSucursalDadoNumero(auxiliar.NoSucursal);//obtener nombre de la sucursal              
            idBanco = auxiliar.IdNumeroTarjeta.Substring(0, 2);
            nombreBanco = GetUsuarioActual.GetBancoDadoID(idBanco);
            operadora = GetUsuarioActual.Nombre;
            dlote = new Datoslote(lote, nombreSucursal, nombreBanco, operadora);
            datosLotesPorimprimir.Add(dlote);
        }
        return datosLotesPorimprimir.ToArray();
    }
    //REPORTE DE TARJETAS POR LOTE IMPRESO
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public DatosTarjetas[] ReporteTarjetasPorLote(string[] idlotes)
    {
        List<DatosTarjetas> reporteTarjetas = new List<DatosTarjetas>();
        foreach (string i in idlotes)
            reporteTarjetas.AddRange(GetUsuarioActual.ReporteTarjetasImpresasOPorImprimir(Convert.ToInt32(i)));
        return reporteTarjetas.ToArray();
    }

    //**********CU REALIZAR REPORTE FIN****************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDadoFecha(DateTime fecha)
    {
        return GetUsuarioActual.TarjetasImpresasDadoFecha(fecha);
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDadoSucursalEstado(string sucursal, string estado)
    {
        return GetUsuarioActual.TrajetasDadoSucursalEstado(sucursal, estado);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList TarjetasDadoBancoEstado(string banco, string estado)
    {
        return GetUsuarioActual.TarjetasDadoBancoEstado(banco, estado);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList LotesContenido(int idLote)
    {
        ArrayList Result = new ArrayList();
        Result.AddRange(GetUsuarioActual.LoteContenido(idLote));
        return Result;
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList LotesDadoOperadora(string operadora)
    {
        ArrayList Result = new ArrayList();
        Result.Add(GetUsuarioActual.LotesDadoOperadora(operadora));
        return Result;
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList ReporteContenido(int idlote)
    {
        GetUsuarioActual.LoteContenido(idlote);
        return new ArrayList();
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public int LoteCantidadTarjeta(int idlote)
    {
        return GetUsuarioActual.LoteCantidadTarjeta(idlote);
    }
    #endregion

    #region CU_Crear_Lote

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList ListarNoSucursalTarjetasNoIdLote()
    {
        return GetUsuarioActual.ListarNoSucursalTarjetasNoIdLote();
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList DatosTarjetasPorSucursal(string noSucursal)
    {
        return GetUsuarioActual.DatosTarjetasPorSucursal(noSucursal);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList MostrarFechaPorSucursalYCantidad(string noSucursal)
    {
        return GetUsuarioActual.MostrarFechaPorSucursalYCantidad(noSucursal);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool CrearLote(string noSucursal, ArrayList fechasSeleccionadas)
    {
        return GetUsuarioActual.CrearLote(noSucursal, fechasSeleccionadas);
    }



    //-------------------------- FIN --------------------------------



    #endregion

    #region CU_Imprimir_Tarjetas

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] DatosLotesEstadoTCreado()
    {
        //Autenticar("administrador", "123");
        return GetUsuarioActual.DatosLotesEstadoTCreado();
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool ActualizarDatosLoteT(ArrayList idLotes)
    {
        return GetUsuarioActual.ActualizarDatosLoteT(idLotes);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] TarjetasAImprimir(ArrayList idLotes)
    {
        return GetUsuarioActual.TarjetasAImprimir(idLotes);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList ListarDatosTarjetasAReimprimir(int idLote)
    {

        return GetUsuarioActual.ListarDatosTarjetasAReimprimir(idLote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] TarjetasAReimprimir(int indiceInicio, int indiceFin, int IdLote)
    {
        return GetUsuarioActual.TarjetasAReimprimir(indiceInicio, indiceFin, IdLote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool SalvarOperacionReimpresionT(int indiceInicio, int indiceFin, int IdLote)
    {
        return GetUsuarioActual.SalvarOperacionReimpresionT(indiceInicio, indiceFin, IdLote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public void FinalizarImpresionDeTarjetas(int ID_Lote)
    {
        GetUsuarioActual.FinalizarImpresionDeTarjetas(ID_Lote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool TarjetasPorReimprimir()
    {
        return GetUsuarioActual.TarjetasPorReimprimir();
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] ListarLotesDeTarjetasImpresas() 
    {
        return GetUsuarioActual.ListarLotesDeTarjetasImpresas();
    }

    //-------------------------- FIN --------------------------------



    #endregion

    #region CU_CaptarMatrices

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public int CargarEncriptarGuardarMatrices(string dir)
    {
        List<Matriz> m = new List<Matriz>();
        List<Matriz> ma = new List<Matriz>();
        m = GetUsuarioActual.CargarMatricesFichero(dir);
        if (m.Count != 0)
        {
            ma = GetUsuarioActual.EncriptarMatrices(m);
        }
        else
            throw new Exception("No hay matrices a encriptar");

        return (int)GetUsuarioActual.GuardarMatrices(ma);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[] BuscarTxt(string path)
    {
        return GetUsuarioActual.BuscarTxt(path);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] GetTorresA()
    {
        return GetUsuarioActual.GetTorresActivas();
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[] GetSubCarpetas(string p)
    {
        return GetUsuarioActual.BuscarSubcarpetas(p);
    }

    #endregion

    #region CU_CONCILIACIONES AUXILIARES
    //*****************************************************************************
    //Edisbel
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[] GetListaBancos()
    {
        List<BancoPersistente> lb = GetUsuarioActual.Handler.ObtenerListaBanco();
        List<string> listnom = new List<string>();
        foreach (BancoPersistente i in lb)
        {
            listnom.Add(i.Nombre);
        }
        return listnom.ToArray();
    }
    //**************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[] GetIDBancos()
    {
        List<BancoPersistente> lb = GetUsuarioActual.Handler.ObtenerListaBanco();
        List<string> lids = new List<string>();
        foreach (BancoPersistente i in lb)
        {
            lids.Add(i.NumBanco);
        }
        return lids.ToArray();
    }
    //***********************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string EnviarConciliacionTarjetasCreadas(DateTime fecha, string NombreBanco)
    {
        return GetUsuarioActual.EnviarConciliacionTarjetasCreadas(fecha, NombreBanco);
    }
    //************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string EnviarConciliacionTarjetasCanceladas(DateTime fecha, string NombreBanco)
    {
        return GetUsuarioActual.EnviarConciliacionTarjetasCanceladas(fecha, NombreBanco);
    }
    //*************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string EnviarConciliacionImpresas(DateTime fecha, string NombreBanco)
    {
        return GetUsuarioActual.EnviarConciliacionImpresas(fecha, NombreBanco);
    }
    //*************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool ExistenTarjetasCanceladasDeBancoEnDia(DateTime f, string IDB)
    {
        return GetUsuarioActual.ExistenTarjetasCanceladasDeBancoEnDia(f, IDB);
    }
    //*************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool ExistenTarjetasActivasDeBancoEnDia(DateTime f, string IDB)
    {
        return GetUsuarioActual.ExistenTarjetasActivasDeBancoEnDia(f, IDB);
    }
    //*************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool ExistenTarjetasImpresasDeBancoEnDia(DateTime f, string IDB)
    {
        return GetUsuarioActual.ExistenTarjetasImpresasDeBancoEnDia(f, IDB);
    }

    #endregion

    #region CU_Imprimir_Pines


    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] CantidadPinesPorLotes()
    {
        //Autenticar("administrador", "123");
        return GetUsuarioActual.CantidadPinesPorLotes();
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] DatosDeLotes(ArrayList idLotes)
    {
        return GetUsuarioActual.DatosDeLotes(idLotes);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public ArrayList ListarDatosPinesAReimprimir(int idLote)
    {
        //Autenticar("administrador", "123"); 
        return GetUsuarioActual.ListarDatosPinesAReimprimir(idLote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] PinesAReimprimir(int indiceInicio, int indiceFin, int IdLote)
    {
        //Autenticar("administrador", "123");
        return GetUsuarioActual.PinesAReimprimir(indiceInicio, indiceFin, IdLote);
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public void FinalizarImpresionDePines(int ID_Lote)
    {
        //Autenticar("administrador", "123");
        GetUsuarioActual.FinalizarImpresionDePines(ID_Lote);
    }


    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]

    public void SalvarOperacionReimpresionP(int indiceInicio, int indiceFin, int IdLote)
    {
        //Autenticar("administrador", "123");
        GetUsuarioActual.SalvarOperacionReimpresionP(indiceInicio, indiceFin, IdLote);

    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool ActualizarDatosLoteP(ArrayList idLotes)
    {
        return GetUsuarioActual.ActualizarDatosLoteP(idLotes);
    }
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public bool PinesPorReimprimir()
    {
        return GetUsuarioActual.PinesPorReimprimir();
    }

    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[][] ListarLotesDePinesImpresos()
    {
        return GetUsuarioActual.ListarLotesDePinesImpresos();
    }


    #endregion

    #region CU_REALIZAR REPORTE

    //*******************************************************************************************
    [WebMethod(EnableSession = true, Description = "MOD_AUTENTICACION")]
    public string[] ObtenerTarjetasDeLote(int id_lote)
    {
        List<string> ls = new List<string>();
        List<TarjetaPersistente> list = new List<TarjetaPersistente>();
        list = GetUsuarioActual.ObtenerTarjetasDeLote(id_lote);
        foreach (TarjetaPersistente i in list)
        {
            ls.Add(i.IdNumeroTarjeta);
        }
        return ls.ToArray();
    }
    #endregion







    //Metodos de Prueba de CU Conciliaciones Automaticas
    [WebMethod(Description = "No borrar este metodo es para probrar el CU conciliaciones automaticas..............................OK!!!!!!!!!!!!!!!!!!!!!!?????")]
    public void ConciliacionesAutoimatiocasA()
    {
        Usuario.Operaciones.EnviarConciliaciones();
    }

    [WebMethod(Description = "No borrar este metodo es para probrar el CU Crear autenticaciones..............................OK!!!!!!!!!!!!!!!!!!!!!!?????")]
    public void ConciliacionesAutoimatiocasB()
    {
        Usuario.Operaciones.GestionarAutenticaciones();
    }
    [WebMethod(Description = "Probando CU Descargar del FTP")]
    public void DescargarFtp()
    {
        Usuario.Operaciones.EjecutarTransacciones(null);
    }

    [WebMethod(Description = "Método para descargar los ficheros FTP de los servicios")]
    public bool DescargarFicheroFtp(string IdServicio, DateTime fecha)
    {
        if (Usuario.Operaciones.ProcesoFTPPagoComplejo(IdServicio, fecha))
            return true;
        else
            return false;

    }





}
