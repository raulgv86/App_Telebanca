using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public Class1()
    {
        //
        // TODO: Add constructor logic here
        //
        
    }

    public class TMatriz
    {
    
    }

    public MyDataSet ContratodeServicios(DateTime Desde, DateTime Hasta, string subcadena)
    {
        
        
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();

        //Hasta = Hasta.Date.Add(new TimeSpan(0, 11, 59, 59, 59));
        Hasta = Hasta.Date.Add(new TimeSpan(11, 59, 59)); // especificada la hora hasta donde se hace el corte de las 12pm

        string date_format = "SET DATEFORMAT YMD ";
        string sSQL = date_format+"SELECT Usuario, Funcionalidad, Fecha, Descripcion FROM TLB_AccionesUsuario WHERE(Funcionalidad = 'Contratar Servicios') AND (Fecha >='" + Desde.Date + "' AND Fecha <= '" + Hasta + "')"+subcadena+" ORDER BY Fecha";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "TLB_AccionesUsuario");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;
       
    }

    public MyDataSet Reclamaciones(DateTime Desde, DateTime Hasta)
    {
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();

        string date_format = "SET DATEFORMAT YMD ";
        string sSQL = date_format + "SELECT Fecha, Id_Transaccion, Usuario, Descripcion FROM TLB_Reclamacion WHERE (Fecha >= '"+Desde+"' AND Fecha <= '"+Hasta+"')  ORDER BY Fecha";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "TLB_Reclamacion");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;

    }

    public MyDataSet IContratodeServicios(DateTime Desde, DateTime Hasta, string por,string operador, string servicio)
    {
        string oper;
        if (operador == "") oper = "<>''";
        else oper = "='" + operador + "'";
        string subcadena = "AND (Usuario" + oper + ")";
        if (por != "Todos") subcadena = subcadena + "AND (Descripcion LIKE '%" + por + "%')";
        if (servicio != "Todos") subcadena = subcadena + "AND (Descripcion LIKE '%" + servicio + "%')";

        return ContratodeServicios(Desde, Hasta, subcadena);
    }

    public MyDataSet IReclamaciones(DateTime Desde, DateTime Hasta)
    {
        return Reclamaciones(Desde,Hasta);
    }

    public string NombreCliente(string idasociado, string servicio)
    {
        //servicio sera utilizado mas adelante en caso que otros servicios quieran eso..
        string resp = "";
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        string sSQL = "SELECT nombre_completo FROM TLB_Usuarios"+ servicio +" WHERE id_cliente='"+idasociado+"'";
        SqlConnection myconexion = new SqlConnection(sCadenaConexion);
        SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
        SqlDataReader myreader;

        try
        {
            myconexion.Open();
            myreader = mycomand.ExecuteReader();

            if (myreader.Read())
            {
                resp = myreader.GetString(0);
            }
            myreader.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error de conexion con la Base de Datos");
        }
        finally
        {

            myconexion.Close();
        }

        return resp;
        
        //return null;
    }

    public MyDataSet TarjetasCalientes(DateTime Desde, DateTime Hasta, string Descripcion, string operador)
    {
        string oper;
        string Descr;
        if (Descripcion == "Todos") Descr = "<>''";
        else Descr = "='" + Descripcion + "'";
        if (operador == "") oper = "<>''";
        else oper = "='" + operador + "'";




        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        string date_format = "SET DATEFORMAT YMD ";
        string sSQL = date_format + "SELECT dbo.TLB_Tarjeta.Id_NoTarjeta AS Tarjeta, dbo.TLB_Tarjeta.IdentificacionCliente AS CI, dbo.TLB_Tarjeta.Nombre, dbo.TLB_Tarjeta.PrimerApellido AS Apellidos, dbo.TLB_AccionesUsuario.Fecha, dbo.TLB_AccionesUsuario.Usuario AS Operador, SUBSTRING(dbo.TLB_AccionesUsuario.Descripcion, 13, 1) AS Descripcion FROM dbo.TLB_AccionesUsuario INNER JOIN dbo.TLB_Tarjeta ON SUBSTRING(dbo.TLB_AccionesUsuario.Descripcion, 2, 10) = dbo.TLB_Tarjeta.Id_NoTarjeta  WHERE (dbo.TLB_AccionesUsuario.Funcionalidad = 'Tarjeta Caliente') AND (dbo.TLB_AccionesUsuario.Fecha >= '" + Desde + "' AND dbo.TLB_AccionesUsuario.Fecha <= '" + Hasta + "') AND (dbo.TLB_AccionesUsuario.Usuario " + oper + ") AND (SUBSTRING(dbo.TLB_AccionesUsuario.Descripcion, 13, 1) " + Descr + ") ORDER BY dbo.TLB_AccionesUsuario.Fecha";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "TarjetasCalientes");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;
    }

    public MyDataSet DatosTarjeta(string IdTarjeta)
    {
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        string sSQL = "SELECT Id_NoTarjeta,No_Pin,Nombre,PrimerApellido,SegundoApellido,NoSucursal,FechaOrdenImp,EstadoPin,Estado,Id_Matriz,Id_Lote,IdentificacionCliente,TipoIdentificacion,Id_Pais,Coord_Contrato FROM dbo.TLB_Tarjeta WHERE (dbo.TLB_Tarjeta.Id_NoTarjeta = '" + IdTarjeta + "')";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "DatosTarjetas");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;
    }

    // datos de banca movil
    public MyDataSet DatosClienteBmovil(string IdTarjeta)
    {
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        string sSQL = "select ID_TARJETA,NUM_IDEPER,COD_TIPID,COD_PAEXID FROM sfn_GetClienteBMovil('" + IdTarjeta.Trim() + "')";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "DatosClienteBMovil");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;
    }



    public MyDataSet ParteDiarioIni(DateTime Dia)
    {
        MyDataSet ParteDiario = this.ParteDiarioSP(Dia);
        foreach (DataRow row in ParteDiario.ParteDiario.Rows)
        {
            row[4] = Dia;
            if (row[0].ToString().Trim() == "01") row[0] = "01 ETECSA";
            if (row[0].ToString().Trim() == "02") row[0] = "02 ELECTRICIDAD";
            if (row[0].ToString().Trim() == "03") row[0] = "03 ONAT";
            if (row[0].ToString().Trim() == "04") row[0] = "04 MULTAS";
            if (row[0].ToString().Trim() == "05") row[0] = "05 AGUAS";
            if (row[0].ToString().Trim() == "06") row[0] = "06 CONTRAVENCIÓN";
            if (row[0].ToString().Trim() == "07") row[0] = "07 TRANSFERENCIAS";
            if (row[0].ToString().Trim() == "08") row[0] = "08 AEROCARIBBEAN";
            if (row[0].ToString().Trim() == "09") row[0] = "09 AMORTIZACION";
            if (row[0].ToString().Trim() == "11") row[0] = "11 GAS";
        }
        return ParteDiario;
    }

    public MyDataSet ParteDiarioSP(DateTime Dia)
    {
       //'2008-03-25' 
        string fecha = Dia.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ParteDiario", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fecha", fecha);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet ParteDiario = new MyDataSet();
        try
        {
            adapter.Fill(ParteDiario, "ParteDiario");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return ParteDiario;
    }

    public DataSet GetOperacionReversar(string Traza, DateTime Fecha)
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_GetTransaccionAReversar", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Fecha", Fecha);
        mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet Oper = new DataSet();
        try
        {
            adapter.Fill(Oper, "Operacion");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return Oper;
    }

    public MyDataSet OperacionesReversadas(DateTime Desde, DateTime Hasta)
    {
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();

        string date_format = "SET DATEFORMAT YMD ";
        string sSQL = date_format + "SELECT * from dbo.TLB_OperacionesReversadas WHERE (FechaHora >= '" + Desde + "' and FechaHora <= '" + Hasta + "')";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "TLB_OperacionesReversadas");
        }
        catch (Exception excp)
        {
            throw excp; 
        }
        
        return DTS;
    }

    //Tabla resumen anual
    public MyDataSet TablaResumenAnual()
    {
        MyDataSet DTS = new MyDataSet();
        DataSet Asociados = this.AsociadosAnual();
        DataSet Consultas = this.ConsultaSaldoAnual();
        DataSet Servicios = this.ServiciosAnual();
        string Anno = "";
        int CantAsociados = 0;
        string  ServCOntratados = "";
        string  ServTelef = "";
        string  ServAguas = "";
        string  ServElect = "";
        int Operaciones = 0;
        int Telef = 0;
        int Elect = 0;
        int Aguas = 0;
        int Multa = 0;
        int Onat  = 0;
        int Transf = 0;
        int ContraV = 0;
        int Aero = 0;
        int Amort = 0;
        int Gas = 0;
       // decimal MOperaciones = 0;
        decimal MTelef = 0;
        decimal MElect = 0;
        decimal MAguas = 0;
        decimal MMulta = 0;
        decimal MOnat = 0;
        decimal MTransf = 0;
        decimal MContraV = 0;
        decimal MAero = 0;
        decimal MAmort = 0;
        decimal MGas = 0;
        int CSald = 0;
        string OtrasLL = "";
        //string[] Annos = new string[Asociados.Tables[0].Rows.Count];
        ArrayList Annos = new ArrayList();
        foreach (DataRow row in Asociados.Tables[0].Rows)
        {
            Annos.Add(row[0].ToString());     
        }

        for (int i = 0; i <= Annos.Count - 1; i++)
        {
            foreach(DataRow row in Asociados.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    Anno = row[0].ToString();
                    CantAsociados = Convert.ToInt32(row[1].ToString());
                }
            }
            foreach (DataRow row in Consultas.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    CSald = Convert.ToInt32(row[1].ToString());
                }
            }
            foreach (DataRow row in Servicios.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    if (row[1].ToString() == "Etecsa")
                    {
                        Telef = Convert.ToInt32(row[2].ToString());
                        MTelef = Convert.ToDecimal(row[3].ToString());
                        Operaciones = Operaciones + Telef;
                    }
                    else
                    {
                        if (row[1].ToString() == "Electrica")
                        {
                            Elect = Convert.ToInt32(row[2].ToString());
                            MElect = Convert.ToDecimal(row[3].ToString());
                            Operaciones = Operaciones + Elect;
                        }
                        else
                        {
                            if (row[1].ToString() == "Aguas")
                            {
                                Aguas = Convert.ToInt32(row[2].ToString());
                                MAguas = Convert.ToDecimal(row[3].ToString());
                                Operaciones = Operaciones + Aguas;
                            }
                            else
                            {
                                if (row[1].ToString() == "Multas")
                                {
                                    Multa = Convert.ToInt32(row[2].ToString());
                                    MMulta = Convert.ToDecimal(row[3].ToString());
                                    Operaciones = Operaciones + Multa;
                                }
                                else
                                {
                                    if (row[1].ToString() == "Onat")
                                    {
                                        Onat = Convert.ToInt32(row[2].ToString());
                                        MOnat = Convert.ToDecimal(row[3].ToString());
                                        Operaciones = Operaciones + Onat;
                                    }
                                    else
                                    {
                                        if (row[1].ToString() == "Transferencias")
                                        {
                                            Transf = Convert.ToInt32(row[2].ToString());
                                            MTransf = Convert.ToDecimal(row[3].ToString());
                                            Operaciones = Operaciones + Transf;
                                        }
                                        else
                                        {
                                            if (row[1].ToString() == "Contravencion")
                                            {
                                                ContraV = Convert.ToInt32(row[2].ToString());
                                                MContraV = Convert.ToDecimal(row[3].ToString());
                                                Operaciones = Operaciones + ContraV;
                                            }
                                            else
                                            {
                                                if (row[1].ToString() == "AeroCaibbean")
                                                {
                                                    Aero = Convert.ToInt32(row[2].ToString());
                                                    MAero = Convert.ToDecimal(row[3].ToString());
                                                    Operaciones = Operaciones + Aero;
                                                }
                                                else
                                                {
                                                    if (row[1].ToString() == "Amortizacion")
                                                    {
                                                        Amort = Convert.ToInt32(row[2].ToString());
                                                        MAmort = Convert.ToDecimal(row[3].ToString());
                                                        Operaciones = Operaciones + Amort;
                                                    }
                                                    else
                                                    {
                                                        if (row[1].ToString() == "Gas")
                                                        {
                                                            Gas = Convert.ToInt32(row[2].ToString());
                                                            MGas = Convert.ToDecimal(row[3].ToString());
                                                            Operaciones = Operaciones + Gas;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DTS.TablaResumen.Rows.Add(Anno, CantAsociados, ServCOntratados, ServTelef, ServElect, ServAguas,Operaciones, Telef, Elect, Aguas, Multa, Onat, CSald, OtrasLL, MTelef, MElect, MAguas, MMulta, MOnat, Transf, MTransf, ContraV, MContraV, Aero, MAero, Amort, MAmort, Gas, MGas);
            Operaciones = 0;
            Telef = 0;
            Elect = 0;
            Aguas = 0;
            Multa = 0;
            Onat = 0;
            Transf = 0;
            ContraV = 0;
            Aero = 0;
            Amort = 0;
            Gas = 0;
            // decimal MOperaciones = 0;
            MTelef = 0;
            MElect = 0;
            MAguas = 0;
            MMulta = 0;
            MOnat = 0;
            MTransf = 0;
            MContraV = 0;
            MAero = 0;
            MAmort = 0;
            MGas = 0;
        }

            return DTS;
    }

    public DataSet AsociadosAnual()
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoAscociados", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        //mycommand.Parameters.AddWithValue("@Fecha", Fecha);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public DataSet ConsultaSaldoAnual()
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoConsultaSaldo", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.CommandTimeout = 180;
        //mycommand.Parameters.AddWithValue("@Fecha", Fecha);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public DataSet ServiciosAnual()
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoServicios", myconection);        
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.CommandTimeout = 180;
        //mycommand.Parameters.AddWithValue("@Fecha", Fecha);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }
    
    //Tabla Resumen Mensual
    public MyDataSet TablaResumenMensual(string Ano)
    {
        MyDataSet DTS = new MyDataSet();
        DataSet Asociados = this.AsociadosMensual(Ano);
        DataSet Consultas = this.ConsultaSaldoMensual(Ano);
        DataSet Servicios = this.ServiciosMensual(Ano);
        string Anno = "";
        int CantAsociados = 0;
        string ServCOntratados = "";
        string ServTelef = "";
        string ServAguas = "";
        string ServElect = "";
        int Operaciones = 0;
        int Telef = 0;
        int Elect = 0;
        int Aguas = 0;
        int Multa = 0;
        int Onat = 0;
        int Transf = 0;
        int ContraV = 0;
        int Aero = 0;
        int Amort = 0;
        int Gas = 0;
        // decimal MOperaciones = 0;
        decimal MTelef = 0;
        decimal MElect = 0;
        decimal MAguas = 0;
        decimal MMulta = 0;
        decimal MOnat = 0;
        decimal MTransf = 0;
        decimal MContraV = 0;
        decimal MAero = 0;
        decimal MAmort = 0;
        decimal MGas = 0;
        int CSald = 0;
        string OtrasLL = "";
        //string[] Annos = new string[Asociados.Tables[0].Rows.Count];
        ArrayList Annos = new ArrayList();
        foreach (DataRow row in Asociados.Tables[0].Rows)
        {
            Annos.Add(row[0].ToString());
        }

        for (int i = 0; i <= Annos.Count - 1; i++)
        {
            foreach (DataRow row in Asociados.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    Anno = row[0].ToString();
                    CantAsociados = Convert.ToInt32(row[1].ToString());
                }
            }
            foreach (DataRow row in Consultas.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    CSald = Convert.ToInt32(row[1].ToString());
                }
            }
            foreach (DataRow row in Servicios.Tables[0].Rows)
            {
                if (row[0].ToString() == Annos[i].ToString())
                {
                    if (row[1].ToString() == "Etecsa")
                    {
                        Telef = Convert.ToInt32(row[2].ToString());
                        MTelef = Convert.ToDecimal(row[3].ToString());
                        Operaciones = Operaciones + Telef;
                    }
                    else
                    {
                        if (row[1].ToString() == "Electrica")
                        {
                            Elect = Convert.ToInt32(row[2].ToString());
                            MElect = Convert.ToDecimal(row[3].ToString());
                            Operaciones = Operaciones + Elect;
                        }
                        else
                        {
                            if (row[1].ToString() == "Aguas")
                            {
                                Aguas = Convert.ToInt32(row[2].ToString());
                                MAguas = Convert.ToDecimal(row[3].ToString());
                                Operaciones = Operaciones + Aguas;
                            }
                            else
                            {
                                if (row[1].ToString() == "Multas")
                                {
                                    Multa = Convert.ToInt32(row[2].ToString());
                                    MMulta = Convert.ToDecimal(row[3].ToString());
                                    Operaciones = Operaciones + Multa;
                                }
                                else
                                {
                                    if (row[1].ToString() == "Onat")
                                    {
                                        Onat = Convert.ToInt32(row[2].ToString());
                                        MOnat = Convert.ToDecimal(row[3].ToString());
                                        Operaciones = Operaciones + Onat;
                                    }
                                    else
                                    {
                                        if (row[1].ToString() == "Transferencias")
                                        {
                                            Transf = Convert.ToInt32(row[2].ToString());
                                            MTransf = Convert.ToDecimal(row[3].ToString());
                                            Operaciones = Operaciones + Transf;
                                        }

                                        else
                                        {
                                            if (row[1].ToString() == "Contravencion")
                                            {
                                                ContraV = Convert.ToInt32(row[2].ToString());
                                                MContraV = Convert.ToDecimal(row[3].ToString());
                                                Operaciones = Operaciones + ContraV;
                                            }

                                            else
                                            {
                                                if (row[1].ToString() == "AeroCaribbean")
                                                {
                                                    Aero = Convert.ToInt32(row[2].ToString());
                                                    MAero = Convert.ToDecimal(row[3].ToString());
                                                    Operaciones = Operaciones + Aero;
                                                }
                                                else
                                                {
                                                    if (row[1].ToString() == "Amortizacion")
                                                    {
                                                        Amort = Convert.ToInt32(row[2].ToString());
                                                        MAmort = Convert.ToDecimal(row[3].ToString());
                                                        Operaciones = Operaciones + Amort;
                                                    }
                                                    else
                                                    {
                                                        if (row[1].ToString() == "Gas")
                                                        {
                                                            Gas = Convert.ToInt32(row[2].ToString());
                                                            MGas = Convert.ToDecimal(row[3].ToString());
                                                            Operaciones = Operaciones + Gas;
                                                        }
                                                    }
                                                }
                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }





            DTS.TablaResumen.Rows.Add(Anno, CantAsociados, ServCOntratados, ServTelef, ServElect, ServAguas, Operaciones, Telef, Elect, Aguas, Multa, Onat, CSald, OtrasLL, MTelef, MElect, MAguas, MMulta, MOnat, Transf, MTransf, ContraV, MContraV, Aero, MAero, Amort, MAmort, Gas, MGas);
            Operaciones = 0;
            Telef = 0;
            Elect = 0;
            Aguas = 0;
            Multa = 0;
            Onat = 0;
            Transf = 0;
            ContraV = 0;
            Aero = 0;
            Amort = 0;
            Gas = 0;
            // decimal MOperaciones = 0;
            MTelef = 0;
            MElect = 0;
            MAguas = 0;
            MMulta = 0;
            MOnat = 0;
            MTransf = 0;
            MContraV = 0;
            MAero = 0;
            MAmort = 0;
            MGas = 0;
        }

        return DTS;
    }

    public DataSet AsociadosMensual(string Anno)
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoAsociadosMes", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Anno", Anno);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public DataSet ConsultaSaldoMensual(string Anno)
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoConsultaSaldoMes", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Anno", Anno);
        mycommand.CommandTimeout = 180;
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public DataSet ServiciosMensual(string Anno)
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_InfoServiciosMes", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Anno", Anno);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Table");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public MyDataSet ReporteConsultaSaldos(DateTime fechaI, DateTime fechaF, string oper)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReporteConsultaSaldo", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet DS = new MyDataSet();
        try
        {
            adapter.Fill(DS, "ConsultaSaldos");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public MyDataSet ReporteConsultaUltimosMov(DateTime fechaI, DateTime fechaF, string oper)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReporteConsultaUltimosMov", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet DS = new MyDataSet();
        try
        {
            adapter.Fill(DS, "ConsultaUltMov");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public MyDataSet ReporteCancelarBMovil(DateTime fechaI, DateTime fechaF, string oper)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReporteCancelarBancaMovil", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet DS = new MyDataSet();
        try
        {
            adapter.Fill(DS, "CancelarBMovil");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public MyDataSet ReporteSolicitudPinDigitalTM(DateTime fechaI, DateTime fechaF, string oper)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReporteSolicitudPinDigitalTM", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet DS = new MyDataSet();
        try
        {
            adapter.Fill(DS, "PinDigitalTM");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public MyDataSet ReporteLocalizaTransfExterior(DateTime fechaI, DateTime fechaF, string oper)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReporteLocalizacionTransfExterior", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        //mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        MyDataSet DS = new MyDataSet();
        try
        {
            adapter.Fill(DS, "ReportLocalizaTransf");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

    public DataSet GetOperacionReclamar(string Traza, string dia, string mes, string anno, string Tarjeta, string Servicio, string Monto)
    {
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_GetOperacionesAReclamar", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Traza", Traza);
        mycommand.Parameters.AddWithValue("@dia", dia);
        mycommand.Parameters.AddWithValue("@mes", mes);
        mycommand.Parameters.AddWithValue("@anno", anno);
        mycommand.Parameters.AddWithValue("@Tarjeta", Tarjeta);
        mycommand.Parameters.AddWithValue("@Servicio", Servicio);
        mycommand.Parameters.AddWithValue("@Monto", Monto);
       // mycommand.Parameters.AddWithValue("@Traza", Traza);
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet Oper = new DataSet();
        try
        {
            adapter.Fill(Oper, "Operacion");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return Oper;
    }

    /*public void ReversarOperacion(string Id_Transaccion, string Operador)
    {
        int result;
        string stringConection = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_ReversarOperacion", myconection);
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@Id_TRansaccion", Id_Transaccion);
        mycommand.Parameters.AddWithValue("@Operador", Operador);
        mycommand.Parameters.AddWithValue("@FechaReverso", DateTime.Now);
        try
        {
            myconection.Open();
            mycommand.ExecuteNonQuery();
            //result = Convert.ToInt32(mycommand.Parameters["@idSupplier"].Value);
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            myconection.Close();
        }
        //return result;
    }/*

    /*public MyDataSet ParteDiario(DateTime Dia)
    {
        string sCadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"].ToString();
        string sSQL = "SELECT dbo.TLB_Transaccion.*, dbo.TLB_DatosTransaccion.Valor AS Monto FROM dbo.TLB_Transaccion INNER JOIN dbo.TLB_DatosTransaccion ON dbo.TLB_Transaccion.Id_Transaccion = dbo.TLB_DatosTransaccion.Id_Transaccion WHERE (dbo.TLB_DatosTransaccion.ID_DATOS = 02) AND (day(dbo.TLB_Transaccion.FechaHora) = " + Dia.Day + ") AND (month(dbo.TLB_Transaccion.FechaHora) = " + Dia.Month + ") AND (year(dbo.TLB_Transaccion.FechaHora) = " + Dia.Year + ") ORDER BY dbo.TLB_Transaccion.ID_SERV";
        MyDataSet DTS = new MyDataSet();

        try
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCadenaConexion);
            Adapter.Fill(DTS, "ReporteDiario");
        }
        catch (Exception excp)
        {
            throw excp;
        }
        return DTS;
    }*/

    /*public MyDataSet ParteDiarioF(DateTime Dia)
    {
        string Servicio;
        DateTime Hora;
        string Horario;
        decimal Monto = 0;
        int CantPagos01A = 0;
        int CantPagos02A = 0;
        int CantPagos03A = 0;
        int CantPagos04A = 0;
        int CantPagos05A = 0;
        int CantPagos01P = 0;
        int CantPagos02P = 0;
        int CantPagos03P = 0;
        int CantPagos04P = 0;
        int CantPagos05P = 0;
        decimal MontoTotal01A = 0;
        decimal MontoTotal02A = 0;
        decimal MontoTotal03A = 0;
        decimal MontoTotal04A = 0;
        decimal MontoTotal05A = 0;
        decimal MontoTotal01P = 0;
        decimal MontoTotal02P = 0;
        decimal MontoTotal03P = 0;
        decimal MontoTotal04P = 0;
        decimal MontoTotal05P = 0;
        MyDataSet DTS = this.ParteDiario(Dia);
        

        foreach (DataRow row in DTS.ReporteDiario.Rows)
        {
            Hora = Convert.ToDateTime(row["FechaHora"]);
            Monto = Convert.ToDecimal(row["Monto"]);
            //Servicio
            if (row["ID_SERV"].ToString() == "01")
            { 
                //Servicio = "ETECSA"; 
                if (Hora.Hour < 17)
                { 
                    //Horario = "8:30AM-5:00PM";
                    CantPagos01A = CantPagos01A + 1;
                    MontoTotal01A = MontoTotal01A + Monto;
                }
                else
                { 
                    //Horario = "5:00PM - 8:30PM"; 
                    CantPagos01P = CantPagos01P + 1;
                    MontoTotal01P = MontoTotal01P + Monto;
                }
            }
            if (row["ID_SERV"].ToString() == "02")
            {
                //Servicio = "ELECTRICIDAD";
                if (Hora.Hour < 17)
                {
                    //Horario = "8:30AM-5:00PM";
                    CantPagos02A = CantPagos02A + 1;
                    MontoTotal02A = MontoTotal02A + Monto;
                }
                else
                {
                    //Horario = "5:00PM - 8:30PM"; 
                    CantPagos02P = CantPagos02P + 1;
                    MontoTotal02P = MontoTotal02P + Monto;
                }
            }
            if (row["ID_SERV"].ToString() == "03")
            {
                //Servicio = "ONAT";
                if (Hora.Hour < 17)
                {
                    //Horario = "8:30AM-5:00PM";
                    CantPagos03A = CantPagos03A + 1;
                    MontoTotal03A = MontoTotal03A + Monto;
                }
                else
                {
                    //Horario = "5:00PM - 8:30PM"; 
                    CantPagos03P = CantPagos03P + 1;
                    MontoTotal03P = MontoTotal03P + Monto;
                }
            }
            if (row["ID_SERV"].ToString() == "04")
            {
                //Servicio = "MULTAS";
                if (Hora.Hour < 17)
                {
                    //Horario = "8:30AM-5:00PM";
                    CantPagos04A = CantPagos04A + 1;
                    MontoTotal04A = MontoTotal04A + Monto;
                }
                else
                {
                    //Horario = "5:00PM - 8:30PM"; 
                    CantPagos04P = CantPagos04P + 1;
                    MontoTotal04P = MontoTotal04P + Monto;
                }
            }
            if (row["ID_SERV"].ToString() == "05")
            {
                //Servicio = "AGUAS";
                if (Hora.Hour < 17)
                {
                    //Horario = "8:30AM-5:00PM";
                    CantPagos05A = CantPagos05A + 1;
                    MontoTotal05A = MontoTotal05A + Monto;
                }
                else
                {
                    //Horario = "5:00PM - 8:30PM"; 
                    CantPagos05P = CantPagos05P + 1;
                    MontoTotal05P = MontoTotal05P + Monto;
                }
            }
        }

            DTS.ParteDiario.Rows.Add("ETECSA", "8:30AM-5:00PM", CantPagos01A, MontoTotal01A, Dia);
            DTS.ParteDiario.Rows.Add("ETECSA", "5:00PM - 8:30PM", CantPagos01P, MontoTotal01P, Dia);
            DTS.ParteDiario.Rows.Add("ELECTRICIDAD", "8:30AM-5:00PM", CantPagos02A, MontoTotal02A, Dia);
            DTS.ParteDiario.Rows.Add("ELECTRICIDAD", "5:00PM - 8:30PM", CantPagos02P, MontoTotal02P, Dia);
            DTS.ParteDiario.Rows.Add("ONAT", "8:30AM-5:00PM", CantPagos03A, MontoTotal03A, Dia);
            DTS.ParteDiario.Rows.Add("ONAT", "5:00PM - 8:30PM", CantPagos03P, MontoTotal03P, Dia);
            DTS.ParteDiario.Rows.Add("MULTAS", "8:30AM-5:00PM", CantPagos04A, MontoTotal04A, Dia);
            DTS.ParteDiario.Rows.Add("MULTAS", "5:00PM - 8:30PM", CantPagos04P, MontoTotal04P, Dia);
            DTS.ParteDiario.Rows.Add("AGUAS", "8:30AM-5:00PM", CantPagos05A, MontoTotal05A, Dia);
            DTS.ParteDiario.Rows.Add("AGUAS", "5:00PM - 8:30PM", CantPagos05P, MontoTotal05P, Dia);

            return DTS;

    }*/


}
