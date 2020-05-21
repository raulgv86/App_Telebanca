using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using CriptoTeleBanca;

/// <summary>
/// Summary description for CTarjeta
/// </summary>
public partial class Tarjeta : TarjetaPersistente   
{
       

   public Matriz DarMatriz()
    {
        if (Matriz.Encriptada)
        {
            Matriz.Filas = CriptografiaTeleBanca.DesencriptarMatriz(Matriz.Filas);
            Matriz.Encriptada = false;
        }
            return Matriz;
    }
    
  
   
}
