using System;
using System.Web;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class UsuarioPersistente
    {
        private string usuario;
        private string nombre;
        private string contrasena;
        private bool activo;
        private string carnetIdentidad;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
	
        private RolPersistente rol;

        public UsuarioPersistente(string Usuario, string Contrasena, string Nombre, RolPersistente Rol,bool Activo, string CarnetIdentidad)
        {
            this.nombre = Nombre;
            this.usuario = Usuario;
            this.contrasena = Contrasena;
            this.rol = Rol;
            this.activo = Activo;
            this.carnetIdentidad = CarnetIdentidad;
        }
        public UsuarioPersistente() { this.activo = true;}

        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public string CarnetIdentidad
        {
            get
            {
                return carnetIdentidad; 
            }
            set
            {
                carnetIdentidad = value; 
            }
        }
	
        public string Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                contrasena = value;
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
        public RolPersistente Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
            }
        }

    }
}