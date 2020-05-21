using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaz_de_Datos
{
    public class ContratoPersistente
    {
        TarjetaPersistente aTarjeta;

        List<Servicio> aSevicios;

        public ContratoPersistente(string IdTarjeta)
        {
            DataHandler TempHandler = new DataHandler();
            aTarjeta = TempHandler.BuscarTarjeta(IdTarjeta);
            aSevicios = TempHandler.ObtenerServiciosContratados(IdTarjeta);            
        }

        public List<Servicio> Sevicios
        {
            get { return aSevicios; }
            set { aSevicios = value; }
        }
        public TarjetaPersistente Tarjeta
        {
            get { return aTarjeta; }
            set { aTarjeta = value; }
        }
    }
}
