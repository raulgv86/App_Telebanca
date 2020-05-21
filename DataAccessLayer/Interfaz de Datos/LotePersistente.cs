using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace DataAccessLayer
{
    [Serializable]
    public class LotePersistente
    {
        private int idLote;
        private string idUsuarioTarjeta;     // Operadora de Impresion de Tarjetas
        private DateTime fechaHoraImpTarjeta;
        private DateTime fechaHoraImpPin;
        private string idUsuarioPin;        // Operadora de Impresion de Pines
        private string estadoT;
        private string estadoP;        
        private List<TarjetaPersistente> tarjetas;

        public LotePersistente() { }

        public LotePersistente(int idLote, string UsuarioTarjeta, DateTime FechaHoraTarjeta,
                                  DateTime FechaHoraPin, string UsuarioPin, string EstadoT, string EstadoP)
        {
            this.idLote = idLote;
            this.idUsuarioTarjeta = UsuarioTarjeta;
            this.fechaHoraImpTarjeta = FechaHoraTarjeta;
            this.fechaHoraImpPin = FechaHoraPin;
            this.idUsuarioPin = UsuarioPin;
            this.estadoT = EstadoT;
            this.estadoP = EstadoP;            
            this.tarjetas = new List<TarjetaPersistente>();


        }

        //Constructor para CU_Crear_Lote
        public LotePersistente(string estadoT, string estadoP)
        {
            this.estadoT = estadoT;
            this.estadoP = estadoP;
        }

        public List<TarjetaPersistente> Tarjetas
        {
            get
            {
                return this.tarjetas;
            }
            set
            {
                this.tarjetas = value;
            }
        }

        public int Id_Lote
        {
            get
            {
                return this.idLote;
            }
            set
            {
                this.idLote = value;
            }
        }

        public string IdUsuarioTarjeta
        {
            get
            {
                return this.idUsuarioTarjeta;
            }
            set
            {
                this.idUsuarioTarjeta = value;
            }
        }

        public DateTime FechaHoraImpTarjetas
        {
            get
            {
                return this.fechaHoraImpTarjeta;
            }

            set
            {
                this.fechaHoraImpTarjeta = value;
            }

        }

        public DateTime FechaHoraImpPin
        {
            get
            {
                return this.fechaHoraImpPin;
            }
            set
            {
                this.fechaHoraImpPin = value;
            }
        }

        public string IdUsuarioPin
        {
            get
            {
                return this.idUsuarioPin;
            }
            set
            {
                this.idUsuarioPin = value;
            }
        }

        public string EstadoT
        {
            get 
            {
                return estadoT; 
            }
            set 
            {
                estadoT = value; 
            }
        }


        public string EstadoP
        {
            get 
            {
                return estadoP; 
            }
            set
            { 
                estadoP = value; 
            }
        }
    }
}
