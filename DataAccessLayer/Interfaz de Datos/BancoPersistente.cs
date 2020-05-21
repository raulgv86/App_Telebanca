using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccessLayer
{
    public class BancoPersistente
    {
      //  private string id_Banco;
        private string nombre;
        private string webServices;
        private string password;
        private string numBanco; 
        private string abreviatura;
        private string centrollamad;
        private string identificationserver;

        public BancoPersistente() {}
        public BancoPersistente(string Nombre, string WebServices, string PassWord, string NumBanco, string Abreviatura, string Centrollamad, string Identificationserver)
        {
            this.nombre = Nombre;
            this.webServices = WebServices;
            this.password = PassWord;
            this.numBanco = NumBanco;
            //this.id_Banco = IdBanco;
            this.abreviatura = Abreviatura;
            this.centrollamad = Centrollamad;
            this.identificationserver = Identificationserver;
        }

      /*  public string Id_Banco
        {
            get { return id_Banco; }
            set { id_Banco = value; }
        }*/

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

        public string WebServices
        {
            get
            {
                return webServices;
            }
            set
            {
                webServices = value;
            }
        }

        public string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string NumBanco
        {
            get
            {
                return numBanco;
            }
            set
            {
                numBanco = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return abreviatura;
            }
            set
            {
                abreviatura = value;
            }
        }

        public string Centrollamad
        {
            get
            {
                return centrollamad;
            }
            set
            {
                centrollamad = value;
            }
        }

        public string Identificationserver
        {
            get
            {
                return identificationserver;
            }
            set
            {
                identificationserver = value;
            }
        }


    }
}
