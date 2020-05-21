using System;
using System.Collections.Generic;
using System.Text;



    public class PagoComplejo 
    {
        private int id;
        private string tipo;
        private string identificador;
        private string nombre;
        private float importe;
        private string descriptivo;
        private string informativo;

        public PagoComplejo()
        { 
        
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
        public string Identificador
        {
            get
            {
                return identificador;
            }
            set
            {
                identificador = value;
            }
        }
        public string Nombre
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
        public float Importe
        {
            get
            {
                return importe;
            }
            set
            {
                importe = value;
            }
        }
        public string Descriptivo
        {
            get
            {
                return descriptivo;
            }
            set
            {
                descriptivo = value;
            }
        }
        public string Informativo
        {
            get
            {
                return informativo;
            }
            set
            {
                informativo = value;
            }
        }
        

    }

