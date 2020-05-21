using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReporteTransacciones
    {
        private string reportero;
        private string nombre;
        private string noTarjeta;
        private string servicio; 
        private string operador;
        private DateTime fecha;
        private float importe;
        private string traza;
        private string informativo;
        private string moneda;
        //private string idcliente;

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
        public string Traza
        {
            set { traza = value; }
            get { return traza; }
        }

        public string Informativo
        {
            set { informativo = value; }
            get { return informativo; }
        }
        //public string Idcliente
        //{
        //    set { idcliente = value; }
        //    get { return idcliente; }
        //}
        public string Moneda
        {
            set { moneda = value; }
            get { return moneda; }
        }   
    }
}
