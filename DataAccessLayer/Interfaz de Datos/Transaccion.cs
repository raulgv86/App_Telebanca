using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
 
    public class Transaccion
    {
        private string traza;//traza 
        private string idServicio;
        private string idUsuario;
        private DateTime fecha;
        private string numeroTarjeta;
        private string consecutivoTransac;

        public string  ConsecutivoTransac 
        {
            get { return consecutivoTransac; }
            set { consecutivoTransac = value; }
        }
	
       
        private string[] datos;//datos relevantes y de pago

        public Transaccion()
        { 
        
        }

        public Transaccion(string traza ,string idServicio, string numeroTarjeta,
                           string idUsuario, DateTime fecha, string[] datos)
        {
            this.traza = traza;
            this.idServicio = idServicio;
            this.numeroTarjeta = numeroTarjeta;
            this.idUsuario = idUsuario;
            this.fecha = fecha;
            this.datos = datos;
        }
        public string[] Datos
        {
            get { return datos; }
            set { datos = value; }
        }
        public string Traza
        {
            get { return traza; }
            set { traza = value; }
        }
        public string IdServicio
        {
            get
            {
                return idServicio;
            }
            set
            {
                idServicio = value;
            }
        }
        public string NumeroTarjeta
        {
            get
            {
                return numeroTarjeta;
            }
            set
            {
                numeroTarjeta = value;
            }
        }
        public string IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
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


}
