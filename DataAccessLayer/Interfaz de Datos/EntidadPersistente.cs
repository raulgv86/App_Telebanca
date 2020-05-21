using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{

    /*------INICIO ------ Modulo Servicio Información ------INICIO ------*/
    
    public class EntidadPersistente
    {
        string nombre;
        string direccion;
        string telefono;
        string fax;
        string codigo;
        string codigoAnterior;
        private string CorreosElectronicos;
        private string SitiosWEB;

        

       
        List<string> sitiosWeb;
        List<string> correosElectronicos;

        public EntidadPersistente() 
        {
            nombre = "";
            direccion = "";
            nombre = "";
            telefono = "";
            fax = "";
            codigo = "";
            codigoAnterior = "";
            sitiosWeb = new List<string>();
            correosElectronicos = new List<string>();
        }

        public EntidadPersistente(string nombre, string direccion, string telefono, string fax, string codigo, string codigo_anterior, List<string> sitiosWeb, List<string> correosElectronicos)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.fax = fax;
            this.codigo = codigo;
            this.codigoAnterior = codigo_anterior;
            this.sitiosWeb = sitiosWeb;
            this.correosElectronicos = correosElectronicos; 
        }

        public EntidadPersistente(string nombre, string direccion, string telefono, string fax, string codigo, string codigo_anterior, string Sitios_Web, string Correos_Electronicos)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.fax = fax;
            this.codigo = codigo;
            this.codigoAnterior = codigo_anterior;
            this.SitiosWEB = SitiosWEB;
            this.CorreosElectronicos = Correos_Electronicos;
        }

        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public string CodigoAnterior
        {
            get
            {
                return codigoAnterior;
            }
            set
            {
                codigoAnterior = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
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

        public List<string> SitiosWeb
        {
            get
            {
                return sitiosWeb;
            }
            set
            {
                sitiosWeb = value;
                SitiosWEB = "";
                foreach (string var in sitiosWeb)
                {
                    if (var != "")
                        SitiosWEB += var;
                }
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        public List<string> CorreoElectronico
        {
            get
            {
                return correosElectronicos;
            }
            set
            {
                correosElectronicos = value;
                CorreosElectronicos = "";
                foreach (string var in correosElectronicos)
                {
                    if (var != "")
                        CorreosElectronicos += var;
                }
            }
        }

        public string F_CorreosElectronicos
        {
            get { return CorreosElectronicos; }
            set { CorreosElectronicos = value; }
        }

        public string F_SitiosWeb
        {
            get { return SitiosWEB; }
            set { SitiosWEB = value; }
        }
	
	

    }


    /*---------------- FIN ---------------- Modulo Servicio Información ------------------ FIN -----------------*/

}
