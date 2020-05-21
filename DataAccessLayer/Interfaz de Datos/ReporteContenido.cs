using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
  public  class ReporteContenido
    {
         string nroTarjeta;
         string identificacion;
         string nombrePropietario;
         string primerApellido;
         string banco;
         string nroSucursal;
            int idLote;
           
      
      
      public ReporteContenido(string nrotarjeta, string identificacion, string nombrePropietario, string primerApellido, string banco, string nroSucursal,int idlote)
        {
            this.nroTarjeta =nrotarjeta;
            this.identificacion = identificacion;
            this.nombrePropietario = nombrePropietario;
            this.primerApellido = primerApellido;
            this.banco = banco;
            this.nroSucursal = nroSucursal;
            this.idLote = idlote;
           
                    
        }
      public ReporteContenido()
      {

      }
      
      
      public string NroTarjeta
        {
            get
            {
               return nroTarjeta;

            }
            set
            {
                this.nroTarjeta = value;
            }
        }

        public string TipoIdentificacion
        {
            get
            {
                return  identificacion ;
            }
            set
            {
                this.identificacion = value ;
            }
        }

      public string NombrePropietario
        {
            get
            {
                return nombrePropietario;
            }
            set
            {
                this.nombrePropietario = value;
            }
        }

      public string PrimerApellido
        {
            get
            {
                return primerApellido;
            }
            set
            {
                this.primerApellido = value;
            }
        }

      public string Banco
        {
            get
            {
                return banco;
            }
            set
            {
                this.banco = value;
            }
        }

      public string NumeroSucursal
        {
            get
            {
                return nroSucursal;
            }
            set
            {
                this.nroSucursal = value;

            }
        }

      public int IDLote
        {
            get
            {
                return idLote;
            }
            set
            {
                this.idLote = value;

            }
        }

     

            }
        }
             


   

