using System;
using System.Collections.Generic;
using System.Text;


    public class ReclamacionTransaccion
    {
        private string idTransaccion;
        private string idUsuario;
        private DateTime fecha;
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
	

        public ReclamacionTransaccion( string idTransaccion,string idUsuario, DateTime fecha, string descripcion)
        { 
        this.idTransaccion = idTransaccion;
        this.idUsuario = idUsuario;
        this.fecha = fecha;
        this.descripcion = descripcion;
        }
        public ReclamacionTransaccion()
        {
            this.idTransaccion = "";
            this.idUsuario = "";
            this.fecha = DateTime.Now;
            this.descripcion = "";
        }

        public string IdTransaccion
        {
            get { return idTransaccion; }
            set { idTransaccion = value; }
        }
        public string IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }

