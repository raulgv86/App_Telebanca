using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

 
    public class Servicio
    {
        private string codigoServicio;
        private List<Asociado> asociados;

        public Servicio() {
            asociados = new List<Asociado>();
        }

        public Servicio(string codigoServicio, List<Asociado> asociados)
        {
            this.codigoServicio = codigoServicio;
            this.asociados = asociados;
        }

        public string CodigoServicio
        {
            get
            {
                return codigoServicio;
            }
            set
            {
                codigoServicio = value;
            }
        }

        public List<Asociado> Asociados
        {
            get
            {
                return asociados;
            }
            set
            {
                asociados = value;
            }
        }


    }

