using System;
using System.Web;
using System.Collections.Generic;
using DataAccessLayer;

namespace DataAccessLayer
{
    [Serializable]
    public class TarjetaPersistente
    {
        private string idNumeroTarjeta;
        private string noPin;
        private string nombrePropietario;	
        private string apellidos;
        private string noSucursal;
        private DateTime fechaOrdenImp;
        private string estadoPin;
        private string estado;
        private Matriz matriz;
        private int idLote;
        private string idCliente;             //CI o Pasaporte
        private string tipoIdentificacion;    //Tipo documento (CI o Pasaporte)    
        private string idPais;
        

        public TarjetaPersistente() {
            matriz = new Matriz();
        }
        public TarjetaPersistente(string numeroTarjeta, string NoPin, string NombrePropietario,
                                   string apellidos, string NoSucursal,
                                   DateTime FechaOrdenImp, string EstadoPin, string Estado,
                                   Matriz Matriz, int IdLoteTarjeta, string IdCliente,
                                   string tipoIdentificacion, string aPais)
        {
            this.idNumeroTarjeta = numeroTarjeta;
            this.noPin = NoPin;
            this.nombrePropietario = NombrePropietario;
            this.apellidos = apellidos;
            this.noSucursal = NoSucursal;
            this.fechaOrdenImp = FechaOrdenImp;
            this.estadoPin = EstadoPin;
            this.estado = Estado;
            this.matriz = Matriz;
            this.idLote = IdLoteTarjeta;
            this.idCliente = IdCliente;
            this.tipoIdentificacion = tipoIdentificacion;
            this.idPais = aPais;
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
       
        public DateTime FechaOrdenImp
        {
            get
            {
                return fechaOrdenImp;
            }
            set
            {
                fechaOrdenImp = value;
            }
        }

        public string EstadoPin
        {
            get
            {
                return estadoPin;
            }
            set
            {
                estadoPin = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public Matriz Matriz 
        {
            get
            {
                return matriz;
            }
            set
            {
                matriz = value;
            }
        }

        public int IdLote
        {
            get
            {
                return idLote;
            }
            set
            {
                idLote = value;
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

        public string TipoIdentificacion
        {
            get 
            {
                return tipoIdentificacion;
            }
            set
            {
                tipoIdentificacion = value;
            }
        }

        public string Pais
        {
            get
            {
                return idPais;
            }
            set
            {
                idPais = value;
            }
        }

       
    }


}