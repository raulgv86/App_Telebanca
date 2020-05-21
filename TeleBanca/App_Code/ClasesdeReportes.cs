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


/// <summary>
/// Summary description for InformeConsulta
/// </summary>

public class DatosAgenda
{
    private string reportero;
    private DateTime fecha;
    private string id_Usuario;
    private string cod_Entidad;
    private int codi_Entidad;
    private int codAntSucursal;
    private int nombre;
    private int direccion;
    private int fax;
    private int telefono;
    private int correoElectronico;
    private int sitioWeb;

    //public DatosAgenda(TeleBancaWS.DatosAgenda pDatosAgenda)
    //{
    //    this.reportero = pInformeConsulta.Reportero;
    //    this.fecha = pInformeConsulta.Fecha;
    //    this.empresa = pInformeConsulta.Empresa;
    //    this.informacion_demandada = pInformeConsulta.Informacion_demandada;
    //    this.frecuencia = pInformeConsulta.Frecuencia;
    //}

    public DatosAgenda() { }
    public DatosAgenda(string Reportero, DateTime Fecha, string Id_Usuario, string Cod_Entidad, int Codi_Entidad, int CodAntSucursal, int Nombre, int Direccion, int Fax, int Telefono, int CorreoElectronico, int SitioWeb)
    {
        this.reportero = Reportero;
        this.fecha = Fecha;
        this.id_Usuario = Id_Usuario;
        this.cod_Entidad = Cod_Entidad;
        this.codi_Entidad = Codi_Entidad;
        this.codAntSucursal = CodAntSucursal;
        this.nombre = Nombre;
        this.direccion = Direccion;
        this.fax = Fax;
        this.telefono = Telefono;
        this.correoElectronico = CorreoElectronico;
        this.sitioWeb = SitioWeb;

    }
    public string Reportero
    {
        get
        {
            return reportero;
        }
        set
        {
            reportero = value;
        }
    }

    public DateTime Fecha
    {
        get
        {
            return fecha;
        }
        set
        {
            fecha = value;
        }
    }    
    public string Id_Usuario
    {
        get
        {
            return id_Usuario;
        }
        set
        {
            id_Usuario = value;
        }
    }

    public string Cod_Entidad
    {
        get
        {
            return cod_Entidad;
        }
        set
        {
            cod_Entidad = value;
        }

    }
    public int Codi_Entidad
    {
        get
        {
            return codi_Entidad;
        }
        set
        {
            codi_Entidad = value;
        }
    }
    public int CodAntSucursal
    {
        get
        {
            return codAntSucursal;
        }
        set
        {
            codAntSucursal = value;
        }
    }
    public int Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
    public int Direccion
    {
        get
        {
            return direccion;
        }
        set
        {
            direccion = value;
        }
    }
    public int Fax
    {
        get
        {
            return fax;
        }
        set
        {
            fax = value;
        }
    }
    public int Telefono
    {
        get
        {
            return telefono;
        }
        set
        {
            telefono = value;
        }
    }
    public int CorreoElectronico
    {
        get
        {
            return correoElectronico;
        }
        set
        {
            correoElectronico = value;
        }

    }
    public int SitioWeb
    {
        get
        {
            return sitioWeb;
        }
        set
        {
            sitioWeb = value;
        }
    }


}
//----------------------------------------------------------------
public class DatosProcesos
{
    private string reportero;
    private DateTime fechap;
    private string id_Usuariop;
    private string tema;
    private int solicitudes;

    public DatosProcesos() { }
    public DatosProcesos(string Reportero, DateTime Fechap, string Id_Usuariop, string Tema, int Solicitudes)
    {
        this.reportero = Reportero;
        this.fechap = Fechap;
        this.id_Usuariop = Id_Usuariop;
        this.tema = Tema;
        this.solicitudes = Solicitudes;
    }
    public string Reportero
    {
        get
        {
            return reportero;
        }
        set
        {
            reportero = value;
        }
    }
    public int Solicitudes
    {
        get
        {
            return solicitudes;
        }
        set
        {
            solicitudes = value;
        }
    }
    public DateTime Fechap
    {
        get
        {
            return fechap;
        }
        set
        {
            fechap = value;
        }
    }
    public string Id_Usuariop
    {
        get
        {
            return id_Usuariop;
        }
        set
        {
            id_Usuariop = value;
        }
    }
    public string Tema
    {
        get
        {
            return tema;
        }
        set
        {
            tema = value;
        }
    }
}
//-------------------------------------------------
public class DatosResumen
{

    private string reportero;
    private string nombre_operadora;
    private int inf_procesos;
    private int inf_agenda;
    private DateTime fecha;

    public DatosResumen() { }
    public DatosResumen(string Reportero, string Nombre_operadora, int Inf_procesos, int Inf_agenda, DateTime Fecha)
    {
        this.reportero = Reportero;
        this.nombre_operadora = Nombre_operadora;
        this.inf_procesos = Inf_procesos;
        this.inf_agenda = Inf_agenda;
        this.fecha = Fecha;
    }
    public string Reportero
    {
        get
        {
            return reportero;
        }
        set
        {
            reportero = value;
        }
    }
    public string Nombre_operadora
    {
        get
        {
            return nombre_operadora;
        }
        set
        {
            nombre_operadora = value;
        }
    }
    public int Inf_procesos
    {
        get
        {
            return inf_procesos;
        }
    }
    public int Inf_agenda
    {
        get
        {
            return inf_agenda;
        }
        set
        {
            inf_agenda = value;
        }
    }
    public DateTime Fecha
    {
        get
        {
            return fecha;
        }
        set
        {
            fecha = value;
        }
    }

}
//------------------------------------------------------------------
public class InformeConsultas
{
    private string reportero;
    private DateTime fecha;
    private string empresa;
    private string informacion_demandada;
    private int frecuencia;

    public InformeConsultas(TeleBancaWS.InformeConsultas pInformeConsulta)
    {
        this.reportero = pInformeConsulta.Reportero;
        this.fecha = pInformeConsulta.Fecha;
        this.empresa = pInformeConsulta.Empresa;
        this.informacion_demandada = pInformeConsulta.Informacion_demandada;
        this.frecuencia = pInformeConsulta.Frecuencia;
    }

    public InformeConsultas() { }

    public InformeConsultas(string Reportero, DateTime Fecha, string Empresa, string Informacion_demandada, int Frecuencia)
    {
        this.reportero = Reportero;
        this.fecha = Fecha;
        this.empresa = Empresa;
        this.informacion_demandada = Informacion_demandada;
        this.frecuencia = Frecuencia;
    }
    public string Reportero
    {
        get
        {
            return reportero;
        }
        set
        {
            reportero = value;
        }
    }
    public DateTime Fecha
    {
        get
        {
            return fecha;
        }
        set
        {
            fecha = value;
        }
    }
    public string Empresa
    {
        get
        {
            return empresa;
        }
        set
        {
            empresa = value;
        }
    }
    public string Informacion_demandada
    {
        get
        {
            return informacion_demandada;
        }
        set
        {
            informacion_demandada = value;
        }
    }
    public int Frecuencia
    {
        get
        {
            return frecuencia;
        }
        set
        {
            frecuencia = value;
        }
    }
}

//--------------------------------------------------------
public class DatosTarjetas
{
    //DataHandler handler = new DataHandler();
    private string numeroLote;
    private string nombreSucursal;
    private string banco;
    private string numeroTarjeta;
    private string nombre;
    private string apellidos;
    private string identificacion;
    private string operadora;

    public DatosTarjetas() { }
   // public DatosTarjetas(TarjetaPersistente tarjeta, string nombreSucursal, string nombreBanco, string nombreOperadora)
    //{
      //  this.numeroLote = tarjeta.IdLote.ToString();
     //   this.nombreSucursal = nombreSucursal;
     //   this.banco = nombreBanco;
      //  this.numeroTarjeta = tarjeta.IdNumeroTarjeta;
     //   this.nombre = tarjeta.NombrePropietario;
     //   this.apellidos = tarjeta.Apellidos;
     //   this.identificacion = tarjeta.TipoIdentificacion;
      //  this.operadora = nombreOperadora;

   // }

    public string NumeroLote
    {
        get { return numeroLote; }
        set { numeroLote = value; }
    }

    public string NombreSucursal
    {
        get { return nombreSucursal; }
        set { nombreSucursal = value; }
    }

    public string Banco
    {
        get { return banco; }
        set { banco = value; }
    }

    public string NumeroTarjeta
    {
        get { return numeroTarjeta; }
        set { numeroTarjeta = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellidos
    {
        get { return apellidos; }
        set { apellidos = value; }
    }

    public string Identificacion
    {
        get { return identificacion; }
        set { identificacion = value; }
    }


    public string Operadora
    {
        get { return operadora; }
        set { operadora = value; }
    }


}
public class Datoslote
{
    private string numeroLote;
    private string nombreSucursal;
    private string nombreBanco;
    private int cantidadTotalTarjetas;
    private string operadora;
    public Datoslote() { }
 
    public string Numerolote
    {
        get { return numeroLote; }
        set { numeroLote = value; }
    }

    public string NombreSucursal
    {
        get { return nombreSucursal; }
        set { nombreSucursal = value; }
    }

    public string NombreBanco
    {
        get { return nombreBanco; }
        set { nombreBanco = value; }
    }


    public int CantidadTotalTarjetas
    {
        get { return cantidadTotalTarjetas; }
        set { cantidadTotalTarjetas = value; }
    }

    public string Operadora
    {
        get { return operadora; }
        set { operadora = value; }
    }

}

//----Módulo Autenticación-----------------------------------------
public class TarjetaPersistenteReport
{
    private string idNumeroTarjeta;
    private string noPin;
    private string nombrePropietario;
    private string apellidos;
    private string noSucursal;
    private string idCliente;             //CI o Pasaporte
    private string nombreSucursal;
    private string tipoBanco;

    public TarjetaPersistenteReport()
    {
        
    }
    public TarjetaPersistenteReport(string numeroTarjeta, string NoPin, string NombrePropietario,
                               string apellidos, string NoSucursal,
                               string IdCliente,string NombreSucursal,string TipoBanco)
    {
        this.idNumeroTarjeta = numeroTarjeta;
        this.noPin = NoPin;
        this.nombrePropietario = NombrePropietario;
        this.apellidos = apellidos;
        this.noSucursal = NoSucursal;       
        this.idCliente = IdCliente;
        this.nombreSucursal = NombreSucursal;
        this.tipoBanco = TipoBanco;
       
    }


    public string Apellidos
    {
        get { return apellidos; }
        set { apellidos = value; }
    }

    public string IdNumeroTarjeta
    {
        get
        {
            return idNumeroTarjeta;
        }
        set
        {
            idNumeroTarjeta = value;
        }
    }

    public string NoPin
    {
        get
        {
            return noPin;
        }
        set
        {
            noPin = value;
        }
    }

    public string NombrePropietario
    {
        get
        {
            return nombrePropietario;
        }
        set
        {
            nombrePropietario = value;
        }
    }

    public string NoSucursal
    {
        get
        {
            return noSucursal;
        }

        set
        {
            noSucursal = value;
        }
    }  

    public string IdCliente
    {
        get
        {
            return idCliente;
        }
        set
        {
            idCliente = value;
        }
    }
    public string NombreSucursal 
    {
        get 
        {
            return nombreSucursal;
        }
        set 
        {
            this.nombreSucursal = value;
        }
    }
    public string TipoBanco 
    {
        get 
        {
            return tipoBanco;
        }
        set 
        {
            this.tipoBanco = value;
        }
    }

    

}

public class TarjetasAImprimir
{
    private string tarjeta;
    private string fila1;
    private string fila2;
    private string fila3;
    private string fila4;
    private string fila5;
    private string fila6;
    private string fila7;
    private string fila8;
    private string fila9;
    private string fila10;
    public TarjetasAImprimir() { }
    public TarjetasAImprimir(string Tarjeta, string Fila1, string Fila2, string Fila3, string Fila4, string Fila5,
        string Fila6, string Fila7, string Fila8, string Fila9, string Fila10)
    {
        this.tarjeta = Tarjeta;
        this.fila1 = Fila1;
        this.fila2 = Fila2;
        this.fila3 = Fila3;
        this.fila4 = Fila4;
        this.fila5 = Fila5;
        this.fila6 = Fila6;
        this.fila7 = Fila7;
        this.fila8 = Fila8;
        this.fila9 = Fila9;
        this.fila10 = Fila10;
    }

    public string NoTarjeta
    { 
        get
        {
            return tarjeta;
        }

        set
        {
            this.tarjeta = value;
        }
    }

    public string Fila1
    {
        get
        {
            return fila1;
        }

        set
        {
            this.fila1 = value;
        }
    }

    public string Fila2
    {
        get
        {
            return fila2;
        }

        set
        {
            this.fila2 = value;
        }
    }

    public string Fila3
    {
        get
        {
            return fila3;
        }

        set
        {
            this.fila3 = value;
        }
    }

    public string Fila4
    {
        get
        {
            return fila4;
        }

        set
        {
            this.fila4 = value;
        }
    }

    public string Fila5
    {
        get
        {
            return fila5;
        }

        set
        {
            this.fila5 = value;
        }
    }

    public string Fila6
    {
        get
        {
            return fila6;
        }

        set
        {
            this.fila6 = value;
        }
    }

    public string Fila7
    {
        get
        {
            return fila7;
        }

        set
        {
            this.fila7 = value;
        }
    }

    public string Fila8
    {
        get
        {
            return fila8;
        }

        set
        {
            this.fila8 = value;
        }
    }

    public string Fila9
    {
        get
        {
            return fila9;
        }

        set
        {
            this.fila9 = value;
        }
    }

    public string Fila10
    {
        get
        {
            return fila10;
        }

        set
        {
            this.fila10 = value;
        }
    }
    
}
public class ReporteTransacciones
{
    private string nombre;
    private string noTarjeta;
    private string servicio;
    private string operador;
    private DateTime fecha;
    private float importe;
    private int traza;
    private string moneda;
    private string reportero;
    

    public string Reportero
    {
        set { reportero = value; }
        get { return reportero; }
    }

    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }
    public string NoTarjeta
    {
        set { noTarjeta = value; }
        get { return noTarjeta; }
    }
    public string Servicio
    {
        set { servicio = value; }
        get { return servicio; }
    }
    public string Operador
    {
        set { operador = value; }
        get { return operador; }
    }
    public DateTime Fecha
    {
        set { fecha = value; }
        get { return fecha; }
    }
    public float Importe
    {
        set { importe = value; }
        get { return importe; }
    }
    public int Traza
    {
        set { traza = value; }
        get { return traza; }
    }
    public string Moneda
    {
        set { moneda = value; }
        get { return moneda; }
    } 
    

}

