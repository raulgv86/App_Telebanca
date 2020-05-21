using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DataAccessLayer;

namespace DataAccessLayer
{
   

    /*------INICIO ------ CASO DE USO Servicio Información ------INICIO ------*/


  /*  public class ReportePeristente
    {
        UsuarioPersistente usuario;

        public ReportePeristente() { }

        public ReportePeristente(UsuarioPersistente usuario)
        {
            this.usuario = usuario;
        }

        public UsuarioPersistente Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
    }
    public class ReportePersistenteResumen : ReportePeristente
    {
        int cantInformacion;
        int cantTemas;

        public ReportePersistenteResumen() { }
        public ReportePersistenteResumen(UsuarioPersistente usuario, int cantInformacion, int cantTemas):base(usuario)
        {
            this.cantInformacion = cantInformacion;
            this.cantTemas = cantTemas;
        }

        public int CantInformacion
        {
            get
            {
                return cantInformacion;
            }
            set
            {
                cantInformacion = value;
            }
        }

        public int CantTemas
        {
            get
            {
                return cantTemas;
            }
            set
            {
                cantTemas = value;
            }
        } 
    }
    public class ReportePersistenteDetallado : ReportePeristente
    {
        DateTime fecha;
        DateTime hora;

        public ReportePersistenteDetallado() { }
        public ReportePersistenteDetallado(UsuarioPersistente usuario, DateTime fecha, DateTime hora):base(usuario)
        {
            this.fecha = fecha;
            this.hora = hora;
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

        public DateTime Hora
        {
            get
            {
                return hora;
            }
            set
            {
                hora = value;
            }
        }
    }
    public class ReporteInformacion : ReportePersistenteDetallado
    {
        string informacion;
        EntidadPersistente entidad;

        public ReporteInformacion() { }
        public ReporteInformacion(UsuarioPersistente usuario, DateTime fecha, DateTime hora, string informacion, EntidadPersistente entidad):base(usuario, fecha, hora)
        {
            this.informacion = informacion;
            this.entidad = entidad;
        }

        public EntidadPersistente Entidad
        {
            get
            {
                return entidad;
            }
            set
            {
                entidad = value;
            }
        }

        public string Informacoin
        {
            get
            {
                return informacion;
            }
            set
            {
                informacion = value;
            }
        }
    }
    public class ReporteTemas : ReportePersistenteDetallado
    {
        string tema;
        InformacionPersistente informacion;

        public ReporteTemas() { }
        public ReporteTemas(UsuarioPersistente usuario, DateTime fecha, DateTime hora, string tema, InformacionPersistente informacion):base(usuario, fecha, hora)
        {
            this.tema = tema;
            this.informacion = informacion;
        }

        public InformacionPersistente Informacion
        {
            get
            {
                return informacion;
            }
            set
            {
                informacion = value;
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
       
    }*/
    //-----------------------------------------------------
    //NUEVO
    //-----------------------------------------------------------
    
    //-----------------------------------
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
            set
            {
                inf_procesos = value;
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
    [Serializable]
    public class InformeConsultas
    {
        private string reportero;
        private DateTime fecha;
        private string empresa;
        private string informacion_demandada;
        private int frecuencia;

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

    /*------  FIN  ------ CASO DE USO Servicio Información ------  FIN  ------*/
//----------INICIO----CASO DE USO SERVICIO DE AUTENTICACION------------------------
    //PROGRAMADOR:YOAN ANTONIO LOPEZ RODRIGUEZ
    [Serializable]
    public class DatosTarjetas
    {
        DataHandler handler = new DataHandler();
        private string numeroLote;
        private string nombreSucursal;
        private string banco;
        private string numeroTarjeta;
        private string nombre;
        private string apellidos;
        private string identificacion;
        private string operadora;

        public DatosTarjetas() { }
        public DatosTarjetas(TarjetaPersistente tarjeta,string nombreSucursal,string nombreBanco,string nombreOperadora)
                   
        {
            this.numeroLote = tarjeta.IdLote.ToString();
            this.nombreSucursal = nombreSucursal;
            this.banco = nombreBanco;
            this.numeroTarjeta = tarjeta.IdNumeroTarjeta;
            this.nombre = tarjeta.NombrePropietario;
            this.apellidos = tarjeta.Apellidos;
            this.identificacion = tarjeta.IdCliente;
            this.operadora = nombreOperadora;

        }

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
    [Serializable]
    public class Datoslote
    {
        private string numeroLote;
        private string nombreSucursal;
        private string nombreBanco;
        private int cantidadTotalTarjetas;       
        private string operadora;
        public Datoslote() { }
        public Datoslote(LotePersistente lote,string nombreSucursal,string nombreBanco,string nombreOperadora) 
        {
            this.numeroLote = lote.Id_Lote.ToString();
            this.nombreSucursal = nombreSucursal;
            this.nombreBanco = nombreBanco;
            this.cantidadTotalTarjetas = lote.Tarjetas.Count;
            this.operadora = nombreOperadora;
        }
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
}
//----------FIN----CASO DE USO SERVICIO DE AUTENTICACION------------------------