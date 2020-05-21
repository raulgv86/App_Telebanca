using System;
using System.Collections.Generic;
using System.Text;

   public class Notificacion
    {
        private int id_Notificacion;
        private string descripcion;
        private string id_rol;
        private DateTime fecha;

       public Notificacion()
       { 
       
       }
       public Notificacion(string descripcion, string id_rol) 
       {
           this.descripcion = descripcion;
           this.id_rol = id_rol;
       }

        public string Id_Rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }
	

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
	

        public int Id_Notificacion
        {
            get { return id_Notificacion; }
            set { id_Notificacion = value; }
        }

       public DateTime Fecha 
       {
           get {  return fecha; }
           set { fecha = value; }
       }
	
    }

