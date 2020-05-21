using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


    /// <summary>
    /// Summary description for EstadoNavegacionPago
    /// </summary>
    public class EstadoNavegacionPago
    {
        private int ultimaPagina;
        private int ultimaPagConfServ;
        private int ultimaPagConfServ2;
        private bool autenticadoTarjeta;
        private bool autenticadoPin;
        private bool autenticadoCoordM;

        private int cantCoordIntroducidas;

        private int cantCoordAIntroducir;

       private int cantIntentos;

        private bool esPrimeraCoord; 

//**************introducidas mal
        private int cantTrazasIN;

        public int CantTrazasIN
        {
            get { return cantTrazasIN; }
            set { cantTrazasIN = value;}
        }

        private int cantCoordIM;

        public int CantCoordIM
        {
            get { return cantCoordIM; }
            set { cantCoordIM = value; }
        }

        private int cantPinIM;

        public int CantPinIM
        {
            get { return cantPinIM; }
            set { cantPinIM = value; }
        }

        private int cantNumTarjIM;

        public int CantNumTarjIM
        {
            get { return cantNumTarjIM; }
            set { cantNumTarjIM = value; }
        }

        private int cantCIIM;

        public int CantCIIM
        {
            get { return cantCIIM; }
            set { cantCIIM = value; }
        }
//********************
      

        public int UltimaPagConfServ
        {
            get { return ultimaPagConfServ; }
            set { ultimaPagConfServ = value; }
        }
        public int UltimaPagConfServ2
        {
            get { return ultimaPagConfServ2; }
            set { ultimaPagConfServ2 = value; }
        }
	

        public int CantCoordAIntroducir
        {
            get { return cantCoordAIntroducir; }
            set { cantCoordAIntroducir = value; }
        }
        public int CantIntentos
        {
            get { return cantIntentos; }
            set { cantIntentos = value; }
        }
        public bool EsPrimeraCoord
        {
            get { return esPrimeraCoord; }
            set { esPrimeraCoord = value; }
        }

        public int UltimaPagina
        {
            get { return ultimaPagina; }
            set { ultimaPagina = value; }
        }
        public bool AutenticadoTarjeta
        {
            get { return autenticadoTarjeta; }
            set { autenticadoTarjeta = value; }
        }
        public bool AutenticadoPin
        {
            get { return autenticadoPin; }
            set { autenticadoPin = value; }
        }
        public bool AutenticadoCoordM
        {
            get { return autenticadoCoordM; }
            set { autenticadoCoordM = value; }
        }
        
        
        public int CantCoordIntroducidas
        {
            get { return cantCoordIntroducidas; }
            set { cantCoordIntroducidas = value; }
        }
        //********
        //introduccion id cliente en pago complejo a cualquiera 
        private int cantIDCualquieraIntrod;

        public int CantIDCualquieraIntrod
        {
            get { return cantIDCualquieraIntrod; }
            set { cantIDCualquieraIntrod = value; }
        }



        public EstadoNavegacionPago()
        {
            ultimaPagina = 0;

            autenticadoTarjeta = false;
            autenticadoPin = false;
            autenticadoCoordM = false;

            esPrimeraCoord = true;

           
            cantCoordIntroducidas = 0;

            cantCoordAIntroducir = 0;

            cantIntentos = 3;

            cantCoordIM = 0; ;
             cantPinIM = 0;
             cantNumTarjIM = 0;
             cantCIIM = 0;
             cantTrazasIN = 0;
             cantIDCualquieraIntrod = 0;


        }
        public void Inicializar()
        {
            ultimaPagina = 0;

            autenticadoTarjeta = false;
            autenticadoPin = false;
            autenticadoCoordM = false;

            esPrimeraCoord = true;

           
            cantCoordIntroducidas = 0;

            cantCoordAIntroducir = 0;

            cantIntentos = 3;

            cantCoordIM = 0; ;
            cantPinIM = 0;
            cantNumTarjIM = 0;
            cantCIIM = 0;

            cantIDCualquieraIntrod = 0;
            
        }

    }
