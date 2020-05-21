using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class AccionUsuarioPersistente
    {
        private string usuario;
        private string funcionalidad;
        private DateTime fecha;
        private List<string> descripcion;

        public AccionUsuarioPersistente()
        {
            descripcion = new List<string>();
        }

        public AccionUsuarioPersistente(string aUsuario, string aFuncionalidad,
                                        DateTime aFecha, List<string> aDescripcion)
        {
            this.usuario = aUsuario;
            this.funcionalidad = aFuncionalidad;
            this.fecha = aFecha;
            this.descripcion = aDescripcion;


        }

        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }

        }

        public string Funcionalidad
        {
            get
            {
                return this.funcionalidad;
            }
            set
            {
                this.funcionalidad = value;
            }

        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }

        }

        public List<string> Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }

        }
    }
}
