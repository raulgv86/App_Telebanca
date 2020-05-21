using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DataAccessLayer;



/// <summary>
/// Summary description for Tarjeta
/// </summary>
public partial class Tarjeta: TarjetaPersistente
{
   
    public Tarjeta(TarjetaPersistente tarjeta)
        :base(
          tarjeta.IdNumeroTarjeta,
          tarjeta.NoPin,
          tarjeta.NombrePropietario,
          tarjeta.Apellidos,
          tarjeta.NoSucursal,
          tarjeta.FechaOrdenImp,
          tarjeta.EstadoPin,
          tarjeta.Estado,
          tarjeta.Matriz,
          tarjeta.IdLote,
          tarjeta.IdCliente,
          tarjeta.TipoIdentificacion,
          tarjeta.Pais)
    {
      
    }
}
