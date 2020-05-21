using System;
using System.Collections.Generic;
using System.Text;




    [Serializable]
    public class Matriz 
    {
        private int id_matriz;
        private string estado;
        private Boolean encriptada;
        private string[] filas = { "", "", "", "", "", "", "", "", "", "" };



        #region Constructores
        public Matriz(int id,string fil1, string fil2, string fil3, string fil4, string fil5,
                        string fil6, string fil7, string fil8, string fil9, string fil10,Boolean encript)
        {
            filas[0] = fil1;
            filas[1] = fil2;
            filas[2] = fil3;
            filas[3] = fil4;
            filas[4] = fil5;
            filas[5] = fil6;
            filas[6] = fil7;
            filas[7] = fil8;
            filas[8] = fil9;
            filas[9] = fil10;
            encriptada = encript;
            id_matriz = id;

        }

        //Esto es solo para probar otras cosas 
        public Matriz(int id,int cantFila, int cantCol)
        {
            id_matriz = id;
            Random rand = new Random();
            char[] digitos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int pos;
            for (int j = 0; j < cantFila; j++)
            {
                char[] cadenaFila = { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0',
                                      '0', '0', '0', '0', '0', '0', '0', '0', '0' };

                for (int i = 0; i < cantCol; i++)
                {
                    pos = rand.Next(9);
                    cadenaFila[i] = digitos[pos];

                }
                Filas[j] = new String(cadenaFila);
            }
        }

        public Matriz()
        {
            encriptada = true;
        }
        public Matriz(bool aEncriptada)
        {
            this.encriptada = aEncriptada;
        }


    #endregion 
        

        #region property
        public int ID
        {
            get
            {
                return id_matriz;
            }
            set
            {
                id_matriz = value;
            }
        }

        public string[] Filas
        {
            get
            {
                return filas;
            }
            set
            {
                filas = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public bool Encriptada
        {
            get
            {
                return encriptada;
            }
            set
            {
                encriptada = value;
            }
        }

         #endregion

      }

        

