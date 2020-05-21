using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class HistorialUsuarioTemaPersitente
    {
        string usuario;
        int idTema;
        DateTime fecha;

        public HistorialUsuarioTemaPersitente() { }
        public HistorialUsuarioTemaPersitente(string usuario, int idTema, DateTime fecha)
        {
            this.usuario = usuario;
            this.idTema = idTema;
            this.fecha = fecha;
        }

        public string Usuario
        {
            get 
            {
                return usuario;
            }
            set
            {
                this.usuario = value;
            }
        }
        public int IdTema
        {
            get 
            {
                return idTema;
            }
            set 
            {
                this.idTema = value;
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
                this.fecha = value;
            }
        }
    }
}
