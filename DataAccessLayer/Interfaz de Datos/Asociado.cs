using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer    
{

    public class Asociado
    {
        private List<Dato> datos;

        public Asociado() {
            datos = new List<Dato>();
        }

        public Asociado(List<Dato> datos)
        {
            this.datos = datos;
        }
       

       public List<Dato> Datos
        {
            get
            {
                return datos;
            }
            set
            {
                datos = value;
            }
        }


    }

    public class Dato
    {
        private string id;
        private string valor;

        public Dato() { }

        public Dato(string id, string valor)
        {
            this.id = id;
            this.valor = valor;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }


    }
}
