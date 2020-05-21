using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class InformacionPersistente
    {
        List<string> palabrasClaves;
        int  temaPadre;
        string texto,tema,superTema;
        int idTema;
        List<string> SubTemas = new List<string>();

        public InformacionPersistente()
        {
            palabrasClaves = new List<string>();
            SubTemas = new List<string>();
            temaPadre = 0;
            texto =  tema = superTema ="";
            idTema = 0;
        }

        public InformacionPersistente(string tema, List<string> palabrasClaves, int temaPadre, string texto)
        {
            this.tema = tema;
            this.palabrasClaves = palabrasClaves;
            this.temaPadre = temaPadre;
            this.texto = texto;
            this.idTema = 0;
        }
        public List<string> PalabrasClaves
        {
            get
            {
                return palabrasClaves;
            }
            set
            {
                palabrasClaves = value;
            }
        }
        public List<string> FSubtemas 
        {
            set 
            {
                SubTemas = value;
            }
            get 
            {
                return SubTemas;
            }
        }

        public string SuperTema 
        {
            set 
            {
               superTema = value;
            }
            get 
            {
                return superTema;
            }
        }

        public int TemaPadre
        {
            get
            {
                return temaPadre;
            }
            set
            {
                temaPadre = value;
            }
        }

        public string Tema
        {
            get
            {
                return tema;
            }
            set
            {
                tema = value;
            }
        }

        public string Texto
        {
            get
            {
                return texto;
            }
            set
            {
                texto = value;
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
                idTema = value;
            }
        }
    }
}
