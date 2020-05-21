using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace DataAccessLayer
{ 
    public class ServicioPersistente
    {
        private string idServicio;
        private  string nombre;
       
        private bool autenticaPorTarjeta;
        private bool autenticaPorCI;
        private bool autenticaPorPin;
        private string estado; 

        private string tipoServicio;
        private int cantCoord;
        private List<DatoPersistente> datosPersistentes;
        private DateTime fechaDescargaFTP;
        private int frecuencia;

        private bool asociados;

        public bool Asociados
        {
            get { return asociados; }
            set { asociados = value; }
        }


        public ServicioPersistente() 
        {
            this.datosPersistentes = new List<DatoPersistente>();
        }
        public ServicioPersistente(string idServicio, string pnombre, bool pautenticaPorTarjeta, bool pautenticaPorCI, bool pautenticaPorPin, string pestado, string ptipoServicio, int pcantCoord, DateTime fechaDescargaFTP, int frecuencia,bool asociad)
        {
            this.idServicio = idServicio;
            this.nombre = pnombre;
            this.autenticaPorCI = pautenticaPorCI; 
            this.autenticaPorPin = pautenticaPorPin;
            this.autenticaPorTarjeta = pautenticaPorTarjeta;
            this.estado = pestado;
            this.tipoServicio = ptipoServicio;
            this.cantCoord = pcantCoord;
            this.frecuencia = frecuencia;
            this.fechaDescargaFTP = fechaDescargaFTP;
            this.datosPersistentes = new List<DatoPersistente>();
            asociados = asociad;
        }

        public string IdServicio
        {
            get { return idServicio; }
            set { idServicio = value; }
        }
        public DateTime FechaDescargaFTP
        {
            get { return fechaDescargaFTP; }
            set { fechaDescargaFTP = value; }
        }
	
        public int Frecuencia
        {
            get { return frecuencia; }
            set { frecuencia = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    

        public bool AutenticaPorTarjeta
        {
            get { return autenticaPorTarjeta; }
            set { autenticaPorTarjeta = value; }
        }
        public bool AutenticaPorCI
        {
            get { return autenticaPorCI; }
            set { autenticaPorCI = value; }
        }
      

        public bool AutenticaPorPin
        {
            get { return autenticaPorPin; }
            set { autenticaPorPin = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
      
        public string TipoServicio
        {
            get { return tipoServicio; }
            set { tipoServicio = value; }
        }
     

        public int CantCoord
        {
            get { return cantCoord; }
            set { cantCoord = value; }
        }
    

        public List<DatoPersistente> DatosPersistentes
        {
            get { return datosPersistentes; }
            set { datosPersistentes = value; }
        }      

    }
    public class DatoPersistente
    {
        private string nombreDato;
        private string tipoDato;    //dataCar
        private string tipo;    //String , int o bool
        private int tamañoDato;

        public DatoPersistente() { }
        public DatoPersistente(string pnombreDato, string ptipoDato, string ptipo, int ptamañoDato)
        {
            this.nombreDato = pnombreDato;
            this.tipoDato = ptipoDato;
            this.tipo = ptipo;
            this.tamañoDato = ptamañoDato;

        }

        public int TamañoDato
        {
            get { return tamañoDato; }
            set { tamañoDato = value; }
        }


        public string NombreDato
        {
            get { return nombreDato; }
            set { nombreDato = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        public string TipoDato
        {
            get { return tipoDato; }
            set { tipoDato = value; }
        }


    }
}
