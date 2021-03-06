using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using DevExpress.Web.ASPxGridView;





public partial class WebUserControl2 : System.Web.UI.UserControl
{
    public TeleBancaWS.TeleBancaWS Servicio;
    public String enviar_error;

    
    // private bool HayConfirmacion;
    //****************
    private object[] datosnew
    {
        get { return (object[])Session["datosnew"]; }
        set { Session["datosnew"] = value; }
    }
    //***********
    private object[] TodosDatos; // datos en base dato
    private string passWord
    {
        get { return (string)Session["passWord"]; }
        set { Session["passWord"] = value; }
    }

    private string nombreAnt
    {
        get { return (string)Session["nombreAnt"]; }
        set { Session["nombreAnt"] = value; }
    }
    private object[] DatosTemp    //  datos de uso temporal para el servicio que se inserta o modifica
    {
        get { return (object[])Session["DatosTemp"]; }
        set { Session["DatosTemp"] = value; }
    }
    private ArrayList DatosTemp1
    {
        get { return (ArrayList)Session["DatosTemp1"]; }
        set { Session["DatosTemp1"] = value; }
    }
    private string NoTarjeta
    {
        get { return (string)Session["NoTarjeta"]; }
        set { Session["NoTarjeta"] = value; }
    }
    //private string Pin
    //{
    //    get { return (string)Session["Pin"]; }
    //    set { Session["Pin"] = value; }
    //}

    

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox51.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox52.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox53.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox5.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox75.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox78.Attributes.Add("onkeypress", "javascript:return Money(event);");
        TextBox64.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox65.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox66.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox67.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox69.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox71.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox72.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox73.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox76.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox74.Attributes.Add("onkeypress", "javascript:return LP_data(event);");
        TextBox77.Attributes.Add("onkeypress", "javascript:return LP_data(event);");

        

        if (Servicio == null)
            if (Session["Servicio"] != null)
                Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];

        if (Session["EstadoNavegacionPago"] == null)
        {
            EstadoNavegacionPago temp = new EstadoNavegacionPago();
            Session["EstadoNavegacionPago"] = temp;
        }
        if (DatosTemp1 == null)
            DatosTemp1 = new ArrayList();


        if (!this.IsPostBack)
        {
            try
            {
                string[][] datosMenu = Servicio.GetDataMenu(2);
                Menu1.Items.Clear();

                MenuItem subMenu1 = new MenuItem();
                subMenu1.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu1.Selected = false;
                Menu1.Items.Add(subMenu1);

                MenuItem subMenu2 = new MenuItem();
                subMenu2.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu2.Selected = false;
                subMenu2.Text = "Servicio de Pago";
                subMenu2.Value = "0";
                Menu1.Items.Add(subMenu2);

                for (int i = 0; i < datosMenu[0].Length; i++)
                {
                    MenuItem subMenu = new MenuItem();
                    subMenu.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";

                    subMenu.Text = datosMenu[0][i];
                    subMenu.Value = datosMenu[1][i];
                    Menu1.Items.Add(subMenu);

                }
                Page.DataBind();

                //Nuevo flujo 020508*************
                int CountMenu = Menu1.Items.Count;

                for (int i = 0; i < CountMenu; i++)
                {
                    if (Menu1.Items[i].Value == "38" || Menu1.Items[i].Value == "8"
                        || Menu1.Items[i].Value == "50" || Menu1.Items[i].Value == "25" || Menu1.Items[i].Value == "40")
                    {

                        Menu1.Items[i].Enabled = false;
                    }
                }
            }
            catch
            {

                Response.Redirect("Default.aspx");
                //Response.Redirect("Default06.aspx");
            }


            Session["NuevoCI"] = ""; //Raul: esta variable la uso para en el Amortizar verificar en el boton Buscar que no trabaje con el mismo CI            
                       
        }

    }



    public EstadoNavegacionPago EstadoNavegPago
    {
        get { return (EstadoNavegacionPago)Session["EstadoNavegacionPago"]; }
        set { Session["EstadoNavegacionPago"] = value; }
    }




    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        
        if (e.Item.Value == 40.ToString() || e.Item.Value == 0.ToString())//pago
        {

            if (e.Item.Value == 0.ToString())
            {
                TextBox8.Focus();
                TextBox9.Value = "";
                TextBox8.Value = "";
                TextBox10.Value = "";
                

                EstadoNavegPago = new EstadoNavegacionPago();

                MVWPago.ActiveViewIndex = int.Parse(e.Item.Value);
                return;
                /* if (EstadoNavegPago.UltimaPagina!=0)
                 { 
                     MVWPago.ActiveViewIndex = EstadoNavegPago.UltimaPagina;
                 return;
                  }*/
            }
            else
            {//esto es para las tarjetas que tengan solo asociada cuenta en CUC

               
                    if (EstadoNavegPago.AutenticadoTarjeta)
                    {
                        Label2.Text = Servicio.PreguntarCoordenada();
                        TextBox4.Focus();
                        MVWPago.ActiveViewIndex = 3;
                    }
                    else
                    {
                        MVWPago.ActiveViewIndex = 1;
                        TextBox8.Value = "";
                        TextBox10.Value = "";

                        Errores.Alert(this, "El cliente no ha sido autenticado");

                    }
                
            }


        }
        if (e.Item.Value == 10.ToString())//caliente
        {
            TextBox7.Text = "";
            EstadoNavegPago = new EstadoNavegacionPago();


        }
        if (e.Item.Value == 8.ToString())//saldo
        {
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                LlenarConsultarSaldo();
                TextBox2.Focus();
                return;
            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }

        }
        if (e.Item.Value == 12.ToString())//configurar servicios: cargar primera vista
        {
            BtnDescFTP.Enabled = false;
            if (!this.CargarServicios())
                return;

        }

        if (e.Item.Value == 19.ToString())//configurar datos
        {
            try
            {
                this.CargarDatosnoAsociados();
                if (ListBox4.Items.Count == 0)
                {
                    Button16_Click3(null, null);
                    return;
                }
                Button32.Enabled = false;
                Button54.Enabled = false;

            }
            catch (Exception ex)
            {
                e.Item.Value = "0";
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }

        }
        //-------Inicio Gestionar Banco---------------
        if (e.Item.Value == 22.ToString())//gestionar banco
        {
            Button58.Enabled = false;
            Button59.Enabled = false;

            try
            {
                ActualizarLisbox9();
                if (ListBox9.Items.Count == 0)
                    e.Item.Value = 23.ToString();
            }
            catch (Exception ex)
            {
                e.Item.Value = "0";
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

            }




        }
        //-------Fin Gestionar Banco---------------

        if (e.Item.Value == 25.ToString())//iniciar reclamacion
        {
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                Label2.Text = Servicio.PreguntarCoordenada();
                TextBox4.Focus();
                MVWPago.ActiveViewIndex = 3;
                //return;
            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }

        }
        if (e.Item.Value == 32.ToString())//iniciar Actualizar informacion
        {
            if (!this.CargaVistaActualizarB())
                return;
        }
        //******Consulta de saldos integrada
        if (e.Item.Value == 38.ToString())
        {
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                MVWPago.ActiveViewIndex = 38;
                TextBox50.Text = Session["NoTarjeta"].ToString();
                this.ConsultaIntegrada();

            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }
            //if (!this.CargaVistaActualizarB())
            //return;
        }
        else
        //if (e.Item.Value == 41.ToString())//Cerrar Sesion
        //{
        //    if (EstadoNavegPago.AutenticadoTarjeta == false)
        //    {
        //        Label42.Text = "";
        //    }
        //    EstadoNavegPago.AutenticadoTarjeta = false;
        //    EstadoNavegPago.AutenticadoPin = false;
        //    TextBox9.Value = "";
        //    TextBox8.Value = "";
        //    TextBox10.Value = "";
        //    int CountMenu = Menu1.Items.Count;
        //    for (int i = 0; i < CountMenu; i++)
        //    {
        //        if (Menu1.Items[i].Value == "38" || Menu1.Items[i].Value == "8"
        //            || Menu1.Items[i].Value == "50" || Menu1.Items[i].Value == "25" || Menu1.Items[i].Value == "40")
        //        {

        //            Menu1.Items[i].Enabled = false;
        //        }
        //    }

        //    }
        //******************************

        //******Ultimos Movimientos*******************************************
        //Raul: 15-03-2019 Nueva Funcionalidad: Ultimos Movimientos
        if (e.Item.Value == 51.ToString()) // Ultimos Movimientos
        {
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                DropDownList19.Enabled = false;
                DropDownList19.Items.Clear();
                ASPxButton1.Enabled = false;
                ASPxGridView1.DataSource = null;
                ASPxGridView1.DataBind();
                this.MVWPago.ActiveViewIndex = 59;
            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }
        }
        else
            //******Final de Ultimos Movimientos*******************************************

            //******Cancelar Registro Banca Movil*******************************************
            //Raul: 27-03-2019 Nueva Funcionalidad: Cancelar Registro Banca Movil
            if (e.Item.Value == 52.ToString()) // Cancelar Registro Banca Movil
            {
                if (EstadoNavegPago.AutenticadoTarjeta)
                {
                    this.MVWPago.ActiveViewIndex = 60;
                }
                else
                {
                    MVWPago.ActiveViewIndex = 1;
                    TextBox2.Value = "";
                    TextBox3.Value = "";
                    TextBox43.Value = "";

                    Errores.Alert(this, "El cliente no ha sido autenticado");

                }
            }
            else
        //******Final de Cancelar Registro Banca Movil*******************************************
        //******Localizacion de Transferencia Exterior*******************************************
        //Raul: 03-04-2019 Nueva Funcionalidad: Localiza Transf Exterior
        if (e.Item.Value == 64.ToString()) // Localiza Transf Exterior
        {
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                //View localizacion = View64;
                //MVWPago.Views.Add(localizacion);
                //int x = MVWPago.Views.Count;
                //MVWPago.ActiveViewIndex = MVWPago.Views.IndexOf(localizacion);        
                this.MVWPago.ActiveViewIndex = 63;
            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }
        }
        //******Final de Localizacion de Transferencia Exterior*******************************************
        else
            //******Reporte Localizacion Transferencias Exterior*******************************************
            //Raul: 02-07-2019 Nueva Funcionalidad: Reporte Localizacion Transferencias Exterior
            if (e.Item.Value == 65.ToString()) // Reporte Localizacion Transferencias Exterior
            {
                Control c = View65.FindControl("View65");
                
                int posi = Convert.ToInt16(MVWPago.Views.IndexOf(c));                
                this.MVWPago.ActiveViewIndex = posi;                
            }
                //******Fin de Reporte Localizacion Transferencias Exterior*******************************************
            else
                if (e.Item.Value == 66.ToString()) // Actualizar Informacion del Cliente
                {
                    if (EstadoNavegPago.AutenticadoTarjeta)
                    {
                        DropDownList19.Enabled = false;
                        DropDownList19.Items.Clear();
                        ASPxButton1.Enabled = false;
                        ASPxGridView1.DataSource = null;
                        ASPxGridView1.DataBind();
                        this.MVWPago.ActiveViewIndex = 65;
                    }
                    else
                    {
                        MVWPago.ActiveViewIndex = 1;
                        TextBox2.Value = "";
                        TextBox3.Value = "";
                        TextBox43.Value = "";

                        Errores.Alert(this, "El cliente no ha sido autenticado");

                    }
                }
                else
                    if (e.Item.Value == 67.ToString()) // Pin Digital de Tarjeta Magnetica (PAN)
                    {
                        if (EstadoNavegPago.AutenticadoTarjeta)
                        {                            

                            this.MVWPago.ActiveViewIndex = 66;
                        }
                        else
                        {
                            MVWPago.ActiveViewIndex = 1;                            

                            Errores.Alert(this, "El cliente no ha sido autenticado");

                        }
                    }
                    else
                        //****** Reporte Solicitud Pin Digital TM *******************************************
                        //Raul: 20-02-2020 Nueva Funcionalidad: Reporte Solicitud Pin Digital TM
                        if (e.Item.Value == 68.ToString()) // Reporte Solicitud Pin Digital TM
                        {
                            Control c = View68.FindControl("View68");

                            int posi = Convert.ToInt16(MVWPago.Views.IndexOf(c));
                            this.MVWPago.ActiveViewIndex = posi;
                        }
                        //******Fin de Reporte Solicitud Pin Digital TM *******************************************
            else
            //******Informacion Banca Movil*******************************************
            //Raul: 05-05-2020 Nueva Funcionalidad: Informacion de Banca Movil
            if (e.Item.Value == 69.ToString()) // Banca Movil
            {
                Control c = View68.FindControl("View70");

                int posi = Convert.ToInt16(MVWPago.Views.IndexOf(c));
                this.MVWPago.ActiveViewIndex = posi;                
            }
            else

        //Modificar Contratar Servicios (19/06/07) ************************************
        if (e.Item.Value == "50")//new
        { //new
            //MVWPago.ActiveViewIndex = 1;//new
            if (EstadoNavegPago.AutenticadoTarjeta)
            {
                Label2.Text = Servicio.PreguntarCoordenada();
                TextBox4.Focus();
                MVWPago.ActiveViewIndex = 3;
            }
            else
            {
                MVWPago.ActiveViewIndex = 1;
                TextBox2.Value = "";
                TextBox3.Value = "";
                TextBox43.Value = "";

                Errores.Alert(this, "El cliente no ha sido autenticado");

            }

        }//new
        else
            if (e.Item.Value == 63.ToString()) // Reporte Cancelar Banca Movil
            {                
                    this.MVWPago.ActiveViewIndex = 62;                
            }
        else //new
        {//new
            if (e.Item.Value == "8" || e.Item.Value == "40" || e.Item.Value == "25" || e.Item.Value == "50" || e.Item.Value == "38")//new            
            {
                
            }
            else
            {
                //View vista = (View)MVWPago.FindControl("View"+e.Item.Value.ToString());
                //MVWPago.ActiveViewIndex = MVWPago.Views.IndexOf(vista);
                MVWPago.ActiveViewIndex = Convert.ToInt32(e.Item.Value);//new
            }
        }//new
        //MVWPago.ActiveViewIndex = Convert.ToInt32(e.Item.Value);//estaba antes
    }//****************************************************************************
    public bool CargaVistaActualizarB()
    {
        try
        {
            object[] aux = Servicio.ListadoDeBancosId();


            int len = aux.Length;
            if (len == 0)
            {
                Errores.Alert(this, " No existen bancos para actualizar la configuración de los servicios y datos ");
                return false;
            }
            else
            {
                Button49.Enabled = false;
                ListBox16.Items.Clear();
                string[] aux2 = null;
                for (int i = 0; i < len; i++)
                {
                    aux2 = (string[])aux[i];
                    ListBox16.Items.Add(aux2[0]);
                    ListBox16.Items[i].Value = aux2[1];
                }

                CheckBox1.Checked = false;
                return true;
            }
        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            return false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region validacion
        RegularExpressionValidator2.Visible = true;
        RegularExpressionValidator3.Visible = true;
        RegularExpressionValidator4.Visible = true;
        RequiredFieldValidator20.Visible = true;
        RequiredFieldValidator21.Visible = true;
        RequiredFieldValidator22.Visible = true;

        RequiredFieldValidator20.Validate();
        RequiredFieldValidator21.Validate();
        RequiredFieldValidator22.Validate();
        RegularExpressionValidator2.Validate();
        RegularExpressionValidator3.Validate();
        RegularExpressionValidator4.Validate();
        #endregion

        bool valido = RequiredFieldValidator20.IsValid && RequiredFieldValidator21.IsValid && RequiredFieldValidator22.IsValid && RegularExpressionValidator2.IsValid && RegularExpressionValidator3.IsValid && RegularExpressionValidator4.IsValid;
        if (!valido)
            Errores.Alert(this, " Entrada de datos no válida ");
        else
            try
            {                                
                string aux = TextBox9.Value + TextBox8.Value + TextBox10.Value;
   
                    string estado = Servicio.BuscarTarjeta(aux);
                    string estado_pin = Servicio.BuscarEstadoPin_Tarjeta(aux);

                    // Raul: Alertar en caso de que el cliente tenga aun el pin inicial. Debe cambiarlo. NO dejar que haga operaciones contables
                    if (estado_pin != "creado" && !estado_pin.StartsWith("operadora|"))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('EL PIN INICIAL DE LA TARJETA " + aux + " DEBE SER CAMBIADO ANTES DE REALIZAR CUALQUIER OPERACION CONTABLE. TELEFONOS: (7-866-0606 || 7-835-3535) OPCION #2');", true);// este muestra el mensaje como un modal
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "showalert", "<script>ShowToast()</script>", true);// este muestra el mensaje como un modal

                        return;
                    }

                    if (estado.StartsWith("operadora|"))
                    {
                        Button2_Click(null, null);
                        Errores.Alert(this, "..::Usted no puede pagarse a sí mismo::..");  // Es un mensaje
                    }
                    if (estado == "1" || estado == "A") 
                    {
                        Label31.Text = Servicio.DarNombrePro();
                        Label41.Text = Label31.Text;
                        Label42.Text = Label31.Text;
                        int[] ping = Servicio.PreguntarPin();
                        string[] alf ={ "1ro", "2do", "3ro", "4to" };
                        Label32.Text = alf[ping[0]];
                        Label33.Text = alf[ping[1]];
                        TextBox41.Focus();
                        EstadoNavegPago.UltimaPagina = 2;
                        NoTarjeta = aux;
                        MVWPago.ActiveViewIndex = 2;
                    }
                    if (estado == "2" || estado == "D")
                    {
                        Button2_Click(null, null);
                        Errores.Alert(this, " La Tarjeta está Deshabilitada ");  // Es un mensaje
                    }
                    //  
                    if (estado == "P")
                    {
                        Button2_Click(null, null);
                        Errores.Alert(this, " La Tarjeta está Pedida ");  // Es un mensaje
                    }
                    if (estado == "0" || estado == "C")
                    {
                        Button2_Click(null, null);
                        Errores.Alert(this, " La Tarjeta está en proceso de Impresión");  // Es un mensaje
                    }
                    if (estado == "")
                    {//cuando no devuelve el estado
                        EstadoNavegPago.CantNumTarjIM++;
                        if (EstadoNavegPago.CantNumTarjIM >= EstadoNavegPago.CantIntentos)
                        {
                            Button2_Click(null, null);
                            Errores.Alert(this, " Ha realizado el máximo de intentos ");
                        }
                        else
                        {
                            Errores.Alert(this, " Este No de Tarjeta no está registrada en la Banca Telefónica ");
                        }

                        TextBox8.Value = "";
                        TextBox10.Value = "";
                    }
                
            }
            catch (Exception ex)
            {
                Button2_Click(null, null);
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }

        
    }
    private void FinalizarCasoUso()
    {
        EstadoNavegPago = new EstadoNavegacionPago();
        MVWPago.ActiveViewIndex = 0;
    }

    private void LlenarPreguntarPin()
    {
        try
        {
            Label31.Text = Servicio.DarNombrePro();
            int[] ping = Servicio.PreguntarPin();
            string[] alf ={ "1ro", "2do", "3ro", "4to" };
            Label32.Text = alf[ping[0]];
            Label32.Text = alf[ping[1]];
            MVWPago.ActiveViewIndex = 3;
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, ex.Message);
        }
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        #region validacion
        RegularExpressionValidator8.Visible = false;
        RequiredFieldValidator25.Visible = false;

        RequiredFieldValidator25.Validate();
        RegularExpressionValidator8.Validate();

        #endregion
        bool valido = RequiredFieldValidator25.IsValid && RegularExpressionValidator8.IsValid;

        string estado_pin = Servicio.BuscarEstadoPin_Tarjeta(NoTarjeta);

        // Raul: Alertar en caso de que el cliente tenga aun el pin inicial. Debe cambiarlo. NO dejar que haga operaciones contables
        if (estado_pin == "inicial")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('DEBE CAMBIAR EL PIN MEDIANTE EL OPERADOR AUTOMATICO: (7-866-0606 || 7-835-3535) - Opcion #2');", true);// este muestra el mensaje como un modal
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Cambia el PIN');", true);// este muestra una ventana con el mensaje sin visualizar nada detras
            //Response.Write("<script>alert('ESTA TARJETA DEBE CAMBIAR EL PIN POR EL IVR ANTES DE REALIZAR CUALQUIER PAGO')</script>");// este muestra una ventana con el mensaje pero luego de cerrarla cambia la resolucion de la pagina y letras
            return;
        }

        if (!valido)
        {
            Errores.Alert(this, " Entrada de datos no válida ");
        }
        else
        {
            string[] coordV = new string[2];
            coordV[0] = Label2.Text;
            coordV[1] = TextBox4.Value;
            try
            {
                ////Para trabajar mas comodo
                bool a = true;
                //**************************
                if (Servicio.ChequearCoordenada(coordV))
                //if (a)
                {

                    if (!EstadoNavegPago.EsPrimeraCoord)
                    {
                        EstadoNavegPago.CantCoordIntroducidas++;
                        if (EstadoNavegPago.CantCoordAIntroducir > EstadoNavegPago.CantCoordIntroducidas)
                        {
                            Label2.Text = Servicio.PreguntarCoordenada();
                            TextBox4.Focus();
                        }
                        else
                        {
                           
                           
                                EstadoNavegPago.AutenticadoCoordM = true;
                                //MostrarAsociados(DropDownList1.SelectedItem.Value);
                                LlenarAsociados1();
                                EstadoNavegPago.UltimaPagina = 5;
                                MVWPago.ActiveViewIndex = 5;
                            
                        }

                        TextBox4.Value = "";
                    }
                    else//la primera vez para la tarjeta
                    {
                        object[] servicios = new object[1];
                        servicios = Servicio.MostrarServiciosContratados();

                        string[] nombres = (string[])servicios[1];

                        //string[] nombres = new string[20];
                        //string[] codServ = new string[20];
                        string[] codServ = (string[])servicios[0];
                        //Modificacion Servicios Contratados(Modificado 19/06/07)***************
                        //**********************************************************************
                        //**********************************************************************
                        if (Menu1.SelectedItem.Text == "Contratar Servicios")
                        {
                            DropDownList5.DataSource = nombres;
                            DropDownList5.DataBind();

                            for (int i = 0; i < codServ.Length; i++)
                            {
                                DropDownList5.Items[i].Value = codServ[i];
                            }
                            TextBox4.Value = "";
                            EstadoNavegPago.UltimaPagina = 4;
                            MVWPago.ActiveViewIndex = 33;

                            ListBox5.Items.Clear();
                            string[] aux = Servicio.ListaServiciosExistentes();

                            if (aux.Length == 0)
                            {
                                this.InicializaVistadeServicios();
                                TextBox4.Value = "";
                                //ListBox5.DataSource = aux;
                                //ListBox5.DataBind();

                            }
                            else
                            {
                                ListBox5.DataSource = aux;
                                ListBox5.DataBind();
                                //this.InicializaVistadeServicios();
                            }
                            ////////// //******************
                        }
                        if (Menu1.SelectedItem.Text == "Iniciar Reclamación")
                        {
                            ////for (int i = 2005; i < DateTime.Now.Year; i++)
                            ////{
                            ////    int aux = i + 1;
                            ////    DropDownList7.Items.Add(aux.ToString());
                            ////}
                            for (int i = DateTime.Now.Year; i > 2005; i--)
                            {
                                //int aux = i + 1;
                                DropDownList7.Items.Add(i.ToString());
                            }


                            string[] serv = Servicio.ListaServiciosExistentes();

                            if (serv.Length != 0)
                            {
                                DropDownList11.DataSource = serv;
                                DropDownList11.DataBind();
                                // this.InicializaVistadeServicios(); 
                            }
                            TextBox26.Focus();
                            MVWPago.ActiveViewIndex = 28;
                            //Inicializando----
                            EstadoNavegPago.CantCoordIM = 0;
                            TextBox19.Value = "";
                            TextBox4.Value = "";
                        }
                        //*******************************************************
                        //*******************************************************
                        //*******************************************************
                        //*******************************************************
                        if (Menu1.SelectedItem.Text == "Pago")
                        {
                            DropDownList1.DataSource = nombres;
                            DropDownList1.DataBind();

                            for (int i = 0; i < codServ.Length; i++)
                            {
                                DropDownList1.Items[i].Value = codServ[i];
                            }

                            TextBox4.Value = "";
                            EstadoNavegPago.UltimaPagina = 4;
                            MVWPago.ActiveViewIndex = 4;
                        }

                    }
                }
                else
                {
                    EstadoNavegPago.CantCoordIM++;
                    if (EstadoNavegPago.CantCoordIM >= EstadoNavegPago.CantIntentos)
                    {
                        FinalizarCasoUso();
                        Errores.Alert(this, " Ha realizado el numero máximo de intentos ");
                    }
                    else
                    {
                        Errores.Alert(this, " La coordenada es errónea ");
                    }
                }
            }
            catch (Exception ex)
            {
                Button5_Click(null, null);
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }

        }
    }

    private void MostrarAsociados(string codServicio)
    {
        /* string[] idsA = Servicio.MostrarIdAsociados(codServicio);
         ListBox1.DataSource = idsA;
         ListBox1.DataBind();
         ListBox1.SelectedIndex = 0; */


    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    ArrayList datosPComp = new ArrayList();

    protected void Button10_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];

        try
        {
            if (Convert.ToInt32((string)Session["codServicio"]) > 50)
            {
                Session["codServicio"] = codServ = "0" + Convert.ToString(Convert.ToInt32(Session["codServicio"]) - 50);

                if (codServ.Length >= 3) { Session["codServicio"] = codServ = codServ.Substring(1, 2); }
            }
            else
                Session["codServicio"] = Session["codServicio"];
                codServ = (string)Session["codServicio"];
            Label7.Text = "0.0";
            TextBox54.Visible = false;
            //Modificacion captar monto etecsa-22/04/08********************
            if (codServ == "01")
            {
                GridView8.DataBind();
                string Asoc = "";
                int PosAsoc = this.PosicionAsociadoPagoSimple();
                Asoc = Label156.Text = asociadosSevPago.Items[PosAsoc].Cells[1].Text;
                Session["asociado_etecsa"] = Asoc;
                
                if (Asoc.Substring(2, 1) == "1")
                {
                    Label164.Text = "CUP";
                }
                if (Asoc.Substring(2, 1) == "2")
                {
                    Label164.Text = "CUC";
                }
                if (Asoc.Substring(6, 1) == "7")
                {
                    Label106.Text = Label157.Text = Asoc.Substring(7, 3) + "-" + Asoc.Substring(10, 4);
                }
                else
                {
                    Label106.Text = Label157.Text = "( " + Asoc.Substring(6, 2) + " ) " + Asoc.Substring(8, 2) + "-" + Asoc.Substring(10, 4);
                }


            }

            //************************************************************
            string metodoP = Servicio.VerificarMetodoPago(codServ);
            string nombreServ = (string)Session["nombreServ"];
            if (metodoP.Equals("01"))
            {
                //servicioa pagar
                Label1.Text = nombreServ;

                //limpiar el textbox que identifica el telefono.
                Label121.Text = "???";
                Label135.Text = "Provincia?";

                //obtengo la lista de datos de pago
                Servicio.ObtenerListDatosPago(codServ);//guarda una lista de datos en el usuario

                //lleno el listBox con los datos de Pago
                string[] idDatoP = Servicio.BuscarIdDatosPago(codServ);
                string[] nombresDP = Servicio.BuscarNombresDatos(idDatoP);
                ListBox2.DataSource = nombresDP;
                ListBox2.DataBind();
                for (int i = 0; i < idDatoP.Length; i++)
                {
                    ListBox2.Items[i].Value = idDatoP[i];
                }
                //ListBox2.SelectedIndex = 0;
                TextBox5.Focus();

                try
                {
                    object[] datos = Servicio.BuscarDatosMuestraPagComplejo(codServ, Label156.Text);
                    string[] variable = (string[])datos[0];
                    Session["datosPComp1"] = variable;
                    EstadoNavegPago.UltimaPagina = 57;
                    MVWPago.ActiveViewIndex = 57;

                }
                catch (Exception ex)
                {

                    if (Label156.Text.Substring(6, 1) != "7")
                    {
                        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message) + " pues es una factura de " + Label158.Text + " y ETECSA aún no envía a nuestro sistema las facturas de todo el país, por favor capte el importe brindado por el Cliente");
                        EstadoNavegPago.UltimaPagina = 57;
                        MVWPago.ActiveViewIndex = 57;
                    }
                    else
                    {
                        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                        EstadoNavegPago.UltimaPagina = 57;
                        MVWPago.ActiveViewIndex = 57;
                    }
                }


            }
            else
            {
                //retorno : nombre, importe, informativo
                object[] datos = Servicio.BuscarDatosMuestraPagComplejo(codServ, PrimerDatoRelevanteSeleccionado());
                string[] dpc = (string[])datos[0];
                Session["datosPComp"] = datos;
                Session["pagoComplejo"] = dpc;

                //lleno el combo box de pagos que pueden existir
                LlenarVistaPagoComp(0);
                /*
                PagosComp.DataSource = CrearStringsMostPagoComp();
                PagosComp.DataBind();
                Label4.Text = nombreServ;
                Label6.Text = dpc[0].Substring(2);
                Label7.Text = dpc[1].Substring(2);*/

                //string idCliente = ListBox1.SelectedItem.Value;
                //identificador del servicio que se esta pagando
                int PosAsoc = this.PosicionAsociadoPagoSimple();

                Button13.Enabled = true; // Raul: nuevo. Habilitar el boton del SI del pago porque se le deshabilitaba despues de haber hecho una ONAT
                Button13.Focus();
                EstadoNavegPago.UltimaPagina = 7;
                MVWPago.ActiveViewIndex = 7;
                if (codServ == "03")
                {
                    Label38.Text = dpc[0].ToString();
                }
                else
                {
                    Label38.Text = asociadosSevPago.Items[PosAsoc].Cells[1].Text;

                }

            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }


    }
    //************
    void LlenarVistaPagoComp(int posSelect)
    {
        string codServ = (string)Session["codServicio"];
        object[] datos = (object[])Session["datosPComp"];
        string nombreServ = (string)Session["nombreServ"];
        string[] dpc = (string[])datos[posSelect];
        Session["pagoComplejo"] = dpc;

        //lleno el list box de pagos que pueden existir
        
        PagosComp.DataSource = CrearStringsMostPagoComp(datos);
        PagosComp.DataBind();
        
        for (int i = 0; i < datos.Length; i++)
        {
            string[] dat = (string[])datos[i];
            PagosComp.Items[i].Value = dat[0];//id en PagoComplejo
        }


        Label4.Text = nombreServ;
        Label6.Text = dpc[2].Substring(2);
        if (codServ != "03")
        {
            Label7.Text = dpc[3].Substring(2);

            // probar el nuevo cambio para agua (acreditar)
            if (codServ == "05")
            {
                int bim_restantes = PagosComp.Items.Count;

                if (bim_restantes == 2)
                {
                    string info = PagosComp.Items[bim_restantes - 1].Value;
                }
                //for (int i = 0; i < bim_restantes; i++)
                //{
                    
                //}
                
            }
        }
        Label38.Text = CI_Pago.Value;
        
        

    }
    string[] CrearStringsMostPagoComp(object[] datos)
    {   
        string codServ = (string)Session["codServicio"];
        //creo los strings que se mostraran
        if (codServ == "03")
        {
            string[] res = new string[datos.Length + 1];
            res[0] = "";
            for (int i = 0; i < datos.Length; i++)
            {
                string[] dat = (string[])datos[i];
                res[i + 1] = dat[1];//descriptivo
            }
            return res;
        }

        else
        {
            string[] res = new string[datos.Length];
            for (int i = 0; i < datos.Length; i++)
            {
                string[] dat = (string[])datos[i];
                res[i] = dat[1];//descriptivo
            }
            return res;
        }
    }
    //********
    protected void SelectPagoAsociadComp(object sender, EventArgs e)
    {
        try
        {
            if (PagosComp.SelectedIndex == 0)
            {
                RadioButtonList9.ClearSelection();
                Label7.Text = "";
                TextBox54.Text = "";
                //Button13.Enabled = false;
                return;
            }
            else
            {
                TextBox54.Text = "";
                Button13.Enabled = true;
            }
            object[] datos = (object[])Session["datosPComp"];
            string nombreServ = (string)Session["nombreServ"];
            string[] dpc = (string[])datos[PagosComp.SelectedIndex - 1];
            Session["pagoComplejo"] = dpc;

            Label4.Text = nombreServ;
            Label6.Text = dpc[2].Substring(2);
            if (PagosComp.SelectedIndex != 0)
            {
                Label7.Text = dpc[3].Substring(2);
            }




            if (nombreServ.ToUpper() == "ONAT")
            {
                RadioButtonList9.Visible = true;
                string codServ = (string)Session["codServicio"];
                string Tarjeta = Session["NoTarjeta"].ToString();


                RadioButtonList9.Visible = true;
                DataSet DT = new DataSet();
                DT = Servicio.Monedas(Tarjeta);
                int cantidad = DT.Tables[0].Rows.Count;
                if (RadioButtonList9.Items.Count == 0)
                {
                    foreach (DataRow Row in DT.Tables[0].Rows)
                    {
                        RadioButtonList9.Items.Add(Row[1].ToString());
                    }
                }



                if (dpc[4].Substring(2, 1) == "1")
                {
                    if (cantidad == 2)
                    {
                        if (RadioButtonList9.Items.FindByText("CUC") != null)
                        {
                            RadioButtonList9.Items.FindByText("CUC").Selected = true;

                            if (RadioButtonList9.Items.FindByText("CUP") != null)
                            {
                                RadioButtonList9.Items.FindByText("CUP").Enabled = false;
                                RadioButtonList9.Items.FindByText("CUP").Selected = false;
                            }
                            if (RadioButtonList9.Items.FindByText("USD") != null)
                            {
                                RadioButtonList9.Items.FindByText("USD").Enabled = false;
                                RadioButtonList9.Items.FindByText("USD").Selected = false;
                            }
                            Button13.Enabled = true;
                        }
                        else
                        {
                            Errores.Alert(this, " ..::Error con este Pago::.. ");
                        }
                    }
                    else if (cantidad == 3) // Raul: si tiene asociada CUP, CUC, USD
                    {
                        RadioButtonList9.Items.FindByText("CUC").Selected = true;

                        if (RadioButtonList9.Items.FindByText("CUP") != null)
                        {
                            RadioButtonList9.Items.FindByText("CUP").Enabled = false;
                            RadioButtonList9.Items.FindByText("CUP").Selected = false;
                        }
                        if (RadioButtonList9.Items.FindByText("USD") != null)
                        {
                            RadioButtonList9.Items.FindByText("USD").Enabled = false;
                            RadioButtonList9.Items.FindByText("USD").Selected = false;
                        }
                        Button13.Enabled = true;
                    }
                    else if (cantidad == 1)
                    {
                        RadioButtonList9.Visible = false;
                        Label162.Visible = true;
                        Label162.Text = "CUC";
                    }

                }
                if (dpc[4].Substring(2, 1) == "2")
                {
                    if (cantidad == 2)
                    {
                        if (RadioButtonList9.Items.FindByText("CUP") != null)
                        {
                            RadioButtonList9.Items.FindByText("CUP").Selected = true;
                            if (RadioButtonList9.Items.FindByText("CUC") != null)
                            {
                                RadioButtonList9.Items.FindByText("CUC").Enabled = false;
                                RadioButtonList9.Items.FindByText("CUC").Selected = false;
                            }
                            if (RadioButtonList9.Items.FindByText("USD") != null)
                            {
                                RadioButtonList9.Items.FindByText("USD").Enabled = false;
                                RadioButtonList9.Items.FindByText("USD").Selected = false;
                            }

                            Button13.Enabled = true;
                        }
                        else
                        {
                            Errores.Alert(this, " ..::Error con este Pago::.. ");
                        }
                    }
                    else if (cantidad == 3) // Raul: si tiene asociada CUP, CUC, USD
                    {
                        RadioButtonList9.Items.FindByText("CUP").Selected = true;
                        if (RadioButtonList9.Items.FindByText("CUC") != null)
                        {
                            RadioButtonList9.Items.FindByText("CUC").Enabled = false;
                            RadioButtonList9.Items.FindByText("CUC").Selected = false;
                        }
                        if (RadioButtonList9.Items.FindByText("USD") != null)
                        {
                            RadioButtonList9.Items.FindByText("USD").Enabled = false;
                            RadioButtonList9.Items.FindByText("USD").Selected = false;
                        }

                        Button13.Enabled = true;
                    }
                    else if (cantidad == 1)
                    {
                        RadioButtonList9.Visible = false;
                        Label162.Visible = true;
                        Label162.Text = "CUP";
                    }
                }
                if (dpc[4].Substring(2, 1) != "1" && dpc[4].Substring(2, 1) != "2")
                {
                    Errores.Alert(this, " ..::No se ha identificado el tipo de moneda para este Pago::.. ");
                }

                if (Label7.Text == "0")
                {
                    TextBox54.Visible = true;
                }
                else
                {
                    TextBox54.Visible = false;

                }

            }
            else
            {
                RadioButtonList9.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

            /*nuevo*/
                SqlConnection conx = new SqlConnection();

                try
                {
                    string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                    conx.ConnectionString = cadena_conexion;
                    conx.Open();

                    SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','PAGO SERVICIO',GETDATE(),'Seleccionando la factura de ONAT que va a pagar','ERROR PAGO SERVICIO: SelectPagoAsociadComp'" + ex.Message.Trim() + ")", conx);
                    int i = cm.ExecuteNonQuery();


                }
                catch (Exception ex1)
                {
                    enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. "+ex1.Message.ToString().Trim();
                    Session["Texto_Error"] = enviar_error;
                    Response.Redirect("~/Error500.aspx");
                    //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
                }

                //conx.Close();
                //enviar_error = ex.Message.ToString().Trim();
                //Session["Texto_Error"] = enviar_error;
                //Response.Redirect("~/Error500.aspx");
                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

            /*/nuevo*/            
        }
    }


    //*******************************************
    private string PrimerDatoRelevanteSeleccionado()
    {
        foreach (DataGridItem row in asociadosSevPago.Items)
        {
            CheckBox item = (CheckBox)row.Cells[0].Controls[1];
            if (item.Checked)
            {
                return row.Cells[1].Text;
            }
        }
        return "";
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        /*int posTemp = RadioButtonList1.SelectedIndex;
        if (posTemp == -1)
        {
            Label1.Visible = true;
        }
        else
        {
            if (posTemp == 0)
            {
                MultiView1.ActiveViewIndex = 8;

            }
        }  */
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 7;
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 3;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string codServicio = DropDownList1.SelectedItem.Value;
        Session["codServicio"] = codServicio;
        Session["nombreServ"] = DropDownList1.SelectedItem.Text;

         //string Tarjeta = Session["NoTarjeta"].ToString();

         //       DataSet DT = new DataSet();
         //       DT = Servicio.ConsultarSaldo(Tarjeta);

         //       if ((EstadoNavegPago.AutenticadoTarjeta && DT.Tables[0].Rows.Count == 1 && DT.Tables[0].Rows[0][1].ToString().ToUpper() == "CUC") && (codServicio != "01" || codServicio != "03"))
         //       {
         //           MVWPago.ActiveViewIndex = 1;
         //           Errores.Alert(this, "Este Cliente tiene asociado a la tarjeta TeleBanca solo 1 cuenta y es en CUC, de momento no puede hacer pagos en esta moneda para el servicio seleccionado");
         //           TextBox8.Value = "";
         //           //TextBox9.Value = "";
         //           TextBox10.Value = "";
         //       }
         //       else
                
                    try
                    {
                        EstadoNavegPago.CantCoordAIntroducir = Servicio.BuscarNivelAutenticacionPorCoord(codServicio);
                        if (EstadoNavegPago.CantCoordAIntroducir > 0 && !EstadoNavegPago.AutenticadoCoordM)
                        {
                            Label2.Text = Servicio.PreguntarCoordenada();
                            EstadoNavegPago.EsPrimeraCoord = false;
                            EstadoNavegPago.UltimaPagina = 3;
                            MVWPago.ActiveViewIndex = 3;
                        }
                        else
                        {
                            LlenarAsociados1();
                            EstadoNavegPago.UltimaPagina = 5;
                            MVWPago.ActiveViewIndex = 5;

                            string codServ = (string)Session["codServicio"];
                            string nombreServ = DropDownList1.SelectedItem.Text;

                            if (codServ == "01")
                            {
                                Image23.Visible = true;
                                Image24.Visible = true;
                                Label121.Visible = true;
                                Label135.Visible = true;
                                Label121.Text = "???";
                                Image23.ImageUrl = "~/Images/Imagenes/ETECSA_logo.jpg";

                                int contador = asociadosSevPago.Items.Count;

                                for (int i = 0; i <= contador; i++)
                                {

                                   
                                    if (asociadosSevPago.Items[i].Cells[1].Text.Substring(6, 1) == "7")
                                    {
                                        asociadosSevPago.Items[i].Cells[0].ToolTip = asociadosSevPago.Items[i].Cells[1].Text.Substring(7, 3) + "-" + asociadosSevPago.Items[i].Cells[1].Text.Substring(10, 4);
                                       
                                    }
                                    else
                                    {
                                        asociadosSevPago.Items[i].Cells[0].ToolTip = "( " + asociadosSevPago.Items[i].Cells[1].Text.Substring(6, 2) + " ) " + asociadosSevPago.Items[i].Cells[1].Text.Substring(8, 2) + "-" + asociadosSevPago.Items[i].Cells[1].Text.Substring(10, 4);
                                    }

                                }

                            }

                            if (codServ == "02")
                            {
                                Image23.Visible = true;
                                Image23.ImageUrl = "~/Images/Imagenes/electrica.png";
                                Image24.Visible = false;
                                Label121.Visible = false;
                                Label135.Visible = false;

                            }

                            if (codServ == "03")
                            {
                                Image23.Visible = true;
                                Image23.ImageUrl = "~/Images/Imagenes/Logo_onat.JPG";
                                Image24.Visible = false;
                                Label121.Visible = false;
                                Label135.Visible = false;

                            }
                            if (codServ == "04")
                            {
                                Image23.Visible = true;
                                Image23.ImageUrl = "~/Images/Imagenes/logo_multas.png";
                                Image24.Visible = false;
                                Label121.Visible = false;
                                Label135.Visible = false;
                            }

                            if (codServ == "05")
                            {
                                Image23.Visible = true;
                                Image23.ImageUrl = "~/Images/Imagenes/aguas.PNG";
                                Image24.Visible = false;
                                Label121.Visible = false;
                                Label135.Visible = false;
                            }

                            if (codServ == "06")
                            {
                                Image23.Visible = false;
                                Image23.ImageUrl = "";
                                Image24.Visible = false;
                                Label121.Visible = false;
                                Label135.Visible = false;
                            }

                            if (codServ == "07")
                            {
                                MVWPago.ActiveViewIndex = 55;
                            }

                            if (codServ == "08")
                            {
                                MVWPago.ActiveViewIndex = 52;
                            }

                             if (codServ == "09")
                            {                                
                                DetailsView2.DataSource = null;
                                DetailsView2.DataBind();

                                //GridView11.DataSource = null;
                                //GridView11.DataBind();

                                //GridView11.Visible = false;

                                ASPxGridView3.DataSource = null;
                                ASPxGridView3.DataBind();

                                ASPxGridView3.Visible = false;

                                //Button141.Enabled = false;
                                //ASPxButton1.Enabled = false;
                                DetailsView2.Visible = false;

                                TextBox74.Text = "";

                                Button141.Visible = false;
                                Button142.Visible = false;
                                TextBox77.Visible = false; 
                                Label172.Visible = false;
                                Label173.Visible = false;
                                Button143.Visible = false;

                                MVWPago.ActiveViewIndex = 58;
                            }

                             if (codServ == "11")
                             {
                                 Image23.Visible = true;
                                 Image23.ImageUrl = "~/Images/Imagenes/gas.PNG";
                                 Image24.Visible = false;
                                 Label121.Visible = false;
                                 Label135.Visible = false;
                             }
                                

                            else


                                //Image23.Visible = false;
                                Image24.Visible = false;
                            Label121.Visible = false;
                            Label135.Visible = false;
                            asociadosSevPago.Items.Equals(0);


                        }

                    }
                    catch (Exception ex)
                    {
                        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                    }


                
    }

    protected void LlenarAsociados(string[] nombresDat, object[] datos, int pos)
    {
        DataTable tabla = new DataTable();
        tabla.Columns.Add("marcar", typeof(CheckBox));
        foreach (string var in nombresDat)
        {
            tabla.Columns.Add(var, "".GetType());
        }
        tabla.Columns.Add("A nombre de");

        for (int i = pos; i < datos.Length; i++)
        {
            string[] var = (string[])datos[i];


            CheckBox aux = new CheckBox();
            aux.Checked = false;

            DataRow row = tabla.NewRow();
            row[0] = aux;
            for (int j = 0; j < var.Length; j++)
            {
                row[j + 1] = var[j];
            }
            string codS = (string)Session["codServicio"];
            row[2] = Servicio.NombreFactura(var[0],codS);
            
            tabla.Rows.Add(row);
        }
        asociadosSevPago.DataSource = tabla;
        asociadosSevPago.DataBind();

    }
    protected void LlenarAsociados1()
    {

        string codServ = DropDownList1.SelectedItem.Value;
        Label11.Text = (string)Session["nombreServ"];
        object[] datos = Servicio.MostrarDatosAsociadosServicio(codServ);
        bool tieneAsicdos = (bool)datos[0];
        string[] nombresDat = null;
        if (tieneAsicdos && datos.Length > 1)//cambio para  resolver problema de multas "&& datos.Length > 1"
            nombresDat = (string[])datos[1];
        else tieneAsicdos = false;//cambio para resolver problema de multas
        Session["tieneAsicdos"] = tieneAsicdos;
        if (!tieneAsicdos)
        {
            Panel1.Visible = true;
            Panel_ListAsociados.Visible = false;
            CI_Pago.Value="";
            Button10.Visible = false;
            //Button9.Visible = false;
        }
        else
        {
            Panel1.Visible = false;
            Panel_ListAsociados.Visible = true;
            Button10.Visible = true;
            Button9.Visible = true;
            LlenarAsociados(nombresDat, datos, 2);
        }


        /*
      Label11.Text=DropDownList1.SelectedItem.Text;
      string[] IdAsociados = Servicio.MostrarIdAsociados(DropDownList1.SelectedItem.Value);

      ListBox1.DataSource = IdAsociados;
      ListBox1.DataBind();
      ListBox1.SelectedIndex = 0;
        */
    }
    protected void BuscarAsociados_Pago(object sender, EventArgs e)
    {
        try
        {
            string codServ = (string)Session["codServicio"];
           
            RegularExpressionValidator32.Visible = false;
            RequiredFieldValidator36.Visible = false;

            RequiredFieldValidator36.Validate();
            RegularExpressionValidator32.Validate();


            bool valido = RequiredFieldValidator36.IsValid && RegularExpressionValidator32.IsValid;

           
            if (CI_Pago.Value.Length.ToString() != "11" && codServ != "03")
            {
                valido = false;
            }

            if (!valido)
            {
                Errores.Alert(this, " ..::Entrada de Datos no Válida::.. ");
            }
            else
            {
                if (codServ == "04")
                {
                    MVWPago.ActiveViewIndex = 39;
                }
                else
                {
                    object[] datos = Servicio.BuscarDatosMuestraPagComplejo(codServ, CI_Pago.Value);

                    string[] dpc = (string[])datos[0];
                    Session["datosPComp"] = datos;
                    Session["pagoComplejo"] = dpc;
                    //lleno el combo box de pagos que pueden existir
                    LlenarVistaPagoComp(0);
                    EstadoNavegPago.UltimaPagina = 7;
                    MVWPago.ActiveViewIndex = 7;
                    Button13.Enabled = true;

                    if (codServ == "03")
                    {
                        Label7.Text = "0.0";
                        RadioButtonList9.ClearSelection();
                        RadioButtonList9.Visible = false;
                        TextBox54.Visible = false;
                        //Button13.Enabled = false;
                        Button13.Enabled = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08*****************
            if ((string)Session["codServicio"] == "04")
            {
                //if (CI_Pago.Value.Length.ToString() == "11")
                //{
                Errores.Alert(this, "No hay pago relacionado al cliente, se va a realizar el pago a través de la captación de datos");
                //string codServ = (string)Session["codServicio"];
                //object[] datos = Servicio.BuscarDatosMuestraPagComplejo(codServ, CI_Pago.Value);
                //string[] dpc = (string[])datos[0];
                //Session["datosPComp"] = datos;
                //Session["pagoComplejo"] = dpc;
                //Mostrar nueva View para realizar este pago
                MVWPago.ActiveViewIndex = 39;
                //}
                //else
                //{
                //    Errores.Alert(this, "Por favor, introduzca el carnet de identidad correctamente");
                //}
            }
            //Modificación para el Servicio de Multas por Contravención, captación de datos...
            if ((string)Session["codServicio"] == "06")
            {
                Errores.Alert(this, "No hay Pago relacionado al Cliente, se va a realizar el pago a través de la captación de datos");
                
                
                //Mostrar nueva View para realizar este pago
                MVWPago.ActiveViewIndex = 50;

            }
            else
            {
                //*************************************************************************************
                EstadoNavegPago.CantIDCualquieraIntrod++;
                if (EstadoNavegPago.CantIDCualquieraIntrod >= EstadoNavegPago.CantIntentos)
                {
                    FinalizarCasoUso();
                    Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                    Errores.Alert(this, " Ha realizado el número máximo de intentos ");
                }
                else
                {
                    
                    Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;
                }
            }//Este esta cerrando al else de la modificacion
            


        }

    }


    protected void Button21_Click(object sender, EventArgs e)
    {
        string[] Result;
        List<string> aux1 = new List<string>();
        RegularExpressionValidator1.Visible = true;
        RegularExpressionValidator1.Validate();

        if ((TextBox7.Text == "") || (!RegularExpressionValidator1.IsValid))
        {
            RegularExpressionValidator1.IsValid = false;
            RegularExpressionValidator1.Visible = true;
            Errores.Alert(this, " Entrada de Datos no Válida ");
            return;
        }
        RegularExpressionValidator1.Visible = true;

        try
        {
            Result = Servicio.BuscarTarjetaPorCI(TextBox7.Text);
            aux1.AddRange(Result);
            if (Result.Length < 2)   //En este arreglo viene primero el nombre y después las tarjetas
            {
                EstadoNavegPago.CantCIIM++;
                TextBox7.Text = "";
                if (EstadoNavegPago.CantCIIM < EstadoNavegPago.CantIntentos)
                {
                    Errores.Alert(this.Page, " El número de CI no se encuentra en la Banca ");
                }
                else
                {
                    Errores.Alert(this.Page, " Ha realizado el número máximo de intentos ");
                    FinalizarCasoUso();
                }
            }
            else
            {
                Label19.Text = Result[0];   //El primer elemento es el nombre del individuo...
                aux1.RemoveAt(0);           //Luego se elimina el nombre y quedan sus tarjetas...                     
                ListBox1.DataSource = aux1;
                ListBox1.DataBind();
                RadioButtonList6.Enabled = ListBox1.SelectedIndex != -1;
                RadioButtonList6.SelectedIndex = -1;
                Button23.Enabled = (RadioButtonList6.Enabled && RadioButtonList6.SelectedIndex == -1);
                MVWPago.ActiveViewIndex = 11;
            }
        }

        catch (Exception ex)
        {
            Button22_Click(null, null);
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 10;
    }
    protected void Button25_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = MVWPago.ActiveViewIndex = 40;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {

    }
    protected void Button8_Click(object sender, EventArgs e)
    {

        EstadoNavegPago = new EstadoNavegacionPago();
        MVWPago.ActiveViewIndex = 1;
    }

    protected void Button15_Click1(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 14;
    }
    protected void Button28_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 13;
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 15;
    }
    protected void Button30_Click(object sender, EventArgs e)
    {

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Button30_Click1(object sender, EventArgs e)
    {
        RegularExpressionValidator29.Visible = RequiredFieldValidator34.Visible = true;
        RegularExpressionValidator11.Visible = true;
        RequiredFieldValidator1.Visible = RequiredFieldValidator6.Visible = true;
        RegularExpressionValidator11.Validate();
        RequiredFieldValidator1.Validate();
        RequiredFieldValidator6.Validate();
        RegularExpressionValidator29.Validate();
        RequiredFieldValidator34.Validate();

        if ((!RequiredFieldValidator1.IsValid) || (!RegularExpressionValidator11.IsValid) || (!RequiredFieldValidator6.IsValid) || (!RequiredFieldValidator34.IsValid) || (!RegularExpressionValidator29.IsValid))
        {
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }
        new Errores(this).Confirmar("¿Confirma que desea guardar la información?", "InsertarServSimple");

    }
    public void InsertarServSimple()
    {
        try
        {
            string est = "";

            int coord = Convert.ToInt16(TextBox013.Text);
            if (RadioButtonList2.Items[0].Selected)
                est = "AC";
            else
                est = "NA";

            if (Servicio.InsertarServicio(TextBox31.Text, TextBox6.Text, CheckBoxList3.Items[2].Selected,
                 CheckBoxList3.Items[0].Selected, CheckBoxList3.Items[1].Selected,
                                        est, "01", coord, (DateTime)System.Data.SqlTypes.SqlDateTime.Null, 0, true))
            {

                if (DatosTemp != null)
                {
                    Servicio.InsertarDatosAServicio(TextBox6.Text, DatosTemp);


                }
                EstadoNavegPago.UltimaPagConfServ2 = 0; //para cuando cancela Conf Datos
                ListBox7.Items.Clear();
                Errores.Alert(this, "La información ha sido guardada satisfactoriamente");
                this.CargarServicios();
                this.Button20_Click1(null, null);
            }
            else
                Errores.Alert(this, " El servicio  a insertar ya existe.");

        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button36_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 20;
    }
    protected void Button37_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 21;
    }
    protected void Button43_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 16;
    }
    protected void Button44_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 18;
    }
    //protected void Button48_Click(object sender, EventArgs e)
    //{
    //    MVWPago.ActiveViewIndex = 23;
    //}
    protected void TextBox39_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button51_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 25;
    }
    protected void Button53_Click(object sender, EventArgs e)
    {
        //iniciar reclamacion pin

        RegularExpressionValidator19.Visible = true;
        RegularExpressionValidator20.Visible = true;
        RequiredFieldValidator16.Visible = true;
        RequiredFieldValidator17.Visible = true;

        RegularExpressionValidator19.Validate();
        RegularExpressionValidator20.Validate();
        RequiredFieldValidator16.Validate();
        RequiredFieldValidator17.Validate();

        bool valid = RegularExpressionValidator19.IsValid && RegularExpressionValidator20.IsValid && RequiredFieldValidator16.IsValid && RequiredFieldValidator17.IsValid;

        if (!valid)
            Errores.Alert(this, " Entrada de datos no válida ");
else
        {

            int[] pin = new int[4];
            pin[0] = TextToInt(Label15.Text);
            pin[1] = Convert.ToInt32(TextBox16.Text);
            pin[2] = TextToInt(Label16.Text);
            pin[3] = Convert.ToInt32(TextBox17.Value);
            if (Servicio.ChequearPin(pin))
            {
                EstadoNavegPago.AutenticadoPin = true;
                TextBox16.Text = "";
                TextBox17.Value = "";

                Label17.Text = Servicio.PreguntarCoordenada();
                //Inicializando----
                EstadoNavegPago.CantPinIM = 0;
                TextBox19.Focus();
                MVWPago.ActiveViewIndex = 27;
                TextBox16.Text = "";
                TextBox17.Value = "";

            }
            else
            {
                EstadoNavegPago.CantPinIM++;
                if (EstadoNavegPago.CantPinIM >= EstadoNavegPago.CantIntentos)
                {
                    Errores.Alert(this, " Ha realizado el numero máximo de intentos ");
                    EstadoNavegPago.CantPinIM = 0;
                    FinalizarCasoUso();

                }
                else
                {
                    Errores.Alert(this, " Los dígitos del pin son erróneos ");
                }
                TextBox16.Text = "";
                TextBox17.Value = "";
            }
        }
    }
    protected void Button55_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator21.Visible = true;
        RequiredFieldValidator18.Visible = true;

        RequiredFieldValidator18.Validate();
        RegularExpressionValidator21.Validate();

        bool valid = RegularExpressionValidator21.IsValid && RequiredFieldValidator18.IsValid;


        if (!valid)
            Errores.Alert(this, " Entrada de datos no válida ");
        else
        {
            try
            {
                string[] coordV = new string[2];
                coordV[0] = Label17.Text;
                coordV[1] = TextBox19.Value;

                if (Servicio.ChequearCoordenada(coordV))
                {
                    for (int i = 2005; i < DateTime.Now.Year; i++)
                    {
                        int aux = i + 1;
                        DropDownList7.Items.Add(aux.ToString());
                    }
                    TextBox26.Focus();
                    MVWPago.ActiveViewIndex = 28;
                    //Inicializando----
                    EstadoNavegPago.CantCoordIM = 0;
                    TextBox19.Value = "";
                }
                else
                {
                    EstadoNavegPago.CantCoordIM++;
                    if (EstadoNavegPago.CantCoordIM >= EstadoNavegPago.CantIntentos)
                    {
                        FinalizarCasoUso();
                        EstadoNavegPago.CantCoordIM = 0;
                        Errores.Alert(this, " Ha realizado el número máximo de intentos ");
                    }
                    else
                    {
                        Errores.Alert(this, " La coordenada es errónea ");
                    }
                    TextBox19.Value = "";
                }
            }
            catch (Exception ex)
            {
                MVWPago.ActiveViewIndex = 0;
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }
    }
    protected void Button57_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 28;
    }
    protected void TextBox42_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList6.SelectedIndex == 0)
            {

                Servicio.CambiarEstadoTarjeta(ListBox1.SelectedItem.Value, "D");
                Errores.Alert(this, "La tarjeta ha sido deshabilitada satisfactoriamente");
            }
            else
            {
                Servicio.CambiarEstadoTarjeta(ListBox1.SelectedItem.Value, "P");
                Errores.Alert(this, " La tarjeta ha sido deshabilitada y solicitada satisfactoriamente ");
            }
        }
        catch (Exception ex)
        {
            Button24_Click(null, null);
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
        try
        {
            string[] Result = Servicio.BuscarTarjetaPorCI(TextBox7.Text);
            List<string> aux1 = new List<string>();
            aux1.AddRange(Result);
            if (Result.Length < 2)
                MVWPago.ActiveViewIndex = 10;
            else
            {
                Label19.Text = Result[0];   //El primer elemento es el nombre del individuo...
                aux1.RemoveAt(0);           //Luego se elimina el nombre y quedan sus tarjetas...                     
                ListBox1.DataSource = aux1;
                ListBox1.DataBind();
                RadioButtonList6.Enabled = ListBox1.SelectedIndex != -1;
                RadioButtonList6.SelectedIndex = -1;
                Button23.Enabled = (RadioButtonList6.Enabled && RadioButtonList6.SelectedIndex == -1);
            }
        }
        catch (Exception ex)
        {
            Button24_Click(null, null);
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    protected void Button22_Click(object sender, EventArgs e)
    {
        TextBox7.Text = "";
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        RadioButtonList6.SelectedIndex = -1;
        TextBox7.Text = "";
        MVWPago.ActiveViewIndex = 10;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox9.Value = "";
        TextBox8.Value = "";
        TextBox10.Value = "";
        FinalizarCasoUso();

    }
    protected void Button65_Click(object sender, EventArgs e)
    {
        TextBox9.Value = "";
        TextBox8.Value = "";
        TextBox10.Value = "";
        TextBox42.Value = "";
        TextBox41.Value = "";
        FinalizarCasoUso();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TextBox4.Value = "";
        //FinalizarCasoUso();
        MVWPago.ActiveViewIndex = 40;
    }
    protected void Button9_Click1(object sender, EventArgs e)
    {
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
        Label121.Text = "???";
        Label135.Text = "Provincia?";
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        TextBox54.Text = "";
        EstadoNavegPago.UltimaPagina = 5;
        MVWPago.ActiveViewIndex = 5;
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        string IdServicio = (string)Session["codServicio"];
        if (IdServicio == "03")
        {
            if (RadioButtonList9.Items.Count >= 2)
            {
                if (RadioButtonList9.Items.FindByText("CUC") != null)
                {
                    RadioButtonList9.Items.FindByText("CUC").Selected = false;
                    RadioButtonList9.Items.FindByText("CUC").Enabled = true;
                }
                if (RadioButtonList9.Items.FindByText("CUP") != null)
                {
                    RadioButtonList9.Items.FindByText("CUP").Selected = false;
                    RadioButtonList9.Items.FindByText("CUP").Enabled = true;
                }
                if (RadioButtonList9.Items.FindByText("USD") != null)
                {
                    RadioButtonList9.Items.FindByText("USD").Selected = false;
                    RadioButtonList9.Items.FindByText("USD").Enabled = true;
                }                
            }
        }
        Label38.Text = "";
        EstadoNavegPago.UltimaPagina = 5;
        MVWPago.ActiveViewIndex = 5;
    }

    #region <Raul: (anterior a lo del USD) Boton SI de efectuar el Pago>
    //Servicio de Pago. Boton SI de efectuar el Pago
    //protected void Button13_Click1(object sender, EventArgs e)
    //{

    //    //retorno : nombre, importe, informativo
    //    string[] dat = (string[])Session["pagoComplejo"];

    //    if ((bool)Session["tieneAsicdos"])
    //    {
    //        dat[2] = PrimerDatoRelevanteSeleccionado(); //retorno :idRow, descripcion, idcliente, importe, informativo
    //    }

    //    else
    //    {
    //        dat[2] = CI_Pago.Value;
    //    }

    //    try
    //    {

    //        //Para saber en que moneda se efectuó el pago.
    //        bool moneda = false;


    //        //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08*****************
    //        string IdServicio = (string)Session["codServicio"];
    //        string Informativo = "";
    //        string importe = "";
    //        if (IdServicio == "03" && Label7.Text == "0")
    //        {
    //            importe = "02" + TextBox54.Text;
    //            dat[3] = importe;
    //        }
    //        if (IdServicio == "03") // onat
    //        {
    //            if (dat[4].ToString().Substring(2, 1) == "1")
    //            {
    //                moneda = true;
    //            }
    //            if (dat[4].ToString().Substring(2, 1) == "2")
    //            {
    //                moneda = false;
    //            }
    //        }
    //        if (IdServicio == "04") // multa
    //        {
    //            Informativo = dat[4].ToString() + " T:1";
    //            dat[4] = Informativo;
    //        }

    //        if (IdServicio == "06") // contravencion
    //        {
    //            dat[2] = CI_Pago.Value;
    //            Informativo = dat[4].ToString() + " TC:1";
    //            dat[4] = Informativo;

    //        }


    //        //**************************************************************************************

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count; // cantidad de monedas asociadas

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString(); // moneda principal asociada

    //        string tipo_mon = "";
    //        if (moneda == false)
    //        {
    //            tipo_mon = "CUP";
    //        }

    //        if (moneda == true)
    //        {
    //            tipo_mon = "CUC";
    //        }

    //        if (cantidad == 1)
    //        {

    //            if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53; // vista para aplicar tipo cambio
    //            }
    //            else
    //            {

    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

    //                Informativo = dat[4].ToString();
    //                EstadoNavegPago.UltimaPagina = 5;
    //                MVWPago.ActiveViewIndex = 5;
    //                Button13.Enabled = true;
    //            }
    //        }
    //        else if (cantidad == 2) // aqui poner >1 porque puede que sean CUP, CUC, USD
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);

    //            Session["contiene"] = contiene;

    //            MVWPago.ActiveViewIndex = 54;
    //            Button13.Enabled = true;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Button13.Enabled = true;
    //    }
    //}
    #endregion

    //Servicio de Pago. Boton SI de efectuar el Pago
    protected void Button13_Click1(object sender, EventArgs e)  
    {        
       
        //retorno : nombre, importe, informativo
        string[] dat = (string[])Session["pagoComplejo"];
        
        string tipo_mon = ""; // moneda con la que paga
        
        if ((bool)Session["tieneAsicdos"])
        {
            dat[2] = PrimerDatoRelevanteSeleccionado(); //retorno :idRow, descripcion, idcliente, importe, informativo
        }

        else
        {
            dat[2] = CI_Pago.Value;
        }

        try
        {
            
            //Para saber en que moneda se efectuó el pago.
            int moneda = 0; //0=cup, 1=cuc, 2=usd

            
            //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08*****************
            string IdServicio = (string)Session["codServicio"];
            string Informativo = "";
            string importe = "";
            if (IdServicio == "03" && Label7.Text == "0")
            {
                importe = "02"+ TextBox54.Text;
                dat[3] = importe;
            }
            if (IdServicio == "03" ) // onat
            {
                if (dat[4].ToString().Substring(2, 1) == "1")
                {
                    //moneda = true;
                    moneda = 1;
                }
                if (dat[4].ToString().Substring(2, 1) == "2")
                {
                    moneda = 0;
                }
            }
            if (IdServicio == "04") // multa
            {
                Informativo = dat[4].ToString() + " T:1";
                dat[4] = Informativo;
            }

            if (IdServicio == "06") // contravencion
            {
                dat[2] = CI_Pago.Value;
                Informativo = dat[4].ToString() + " TC:1";
                dat[4] = Informativo;
            
            }
            

            //**************************************************************************************

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count; // cantidad de monedas asociadas

            string mon_cue = DT.Tables[0].Rows[0][1].ToString(); // moneda principal asociada

            if (moneda == 0)
            {
                tipo_mon = "CUP";
            }

            if (moneda == 1)
            {
                tipo_mon = "CUC";
            }

            if (moneda == 2)
            {
                tipo_mon = "USD";
            }

            if (cantidad == 1)
            {

                if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")) || ((tipo_mon == "CUP") && (mon_cue == "USD")) || ((tipo_mon == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53; // vista para aplicar tipo cambio
                }
                else
                {

                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);

                    Informativo = dat[4].ToString();
                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;
                    Button13.Enabled = true;
                }
            }
            else if (cantidad == 2) // aqui poner >1 porque puede que sean CUP, CUC, USD
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);

                Session["contiene"] = contiene;
                
                MVWPago.ActiveViewIndex = 54;
                Button13.Enabled = true;
            }
            else if (cantidad == 3)
            {                
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);

                Session["contiene"] = contiene;
                
                MVWPago.ActiveViewIndex = 54;
                Button13.Enabled = true;            
            }
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

            /*nuevo*/
                //SqlConnection conx = new SqlConnection();

                //try
                //{
                //    string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                //    conx.ConnectionString = cadena_conexion;
                //    conx.Open();

                //    SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','PAGO SERVICIO',GETDATE(),'Intenta pagar el id_asociado: " + dat[2].ToString().Trim() + " con moneda: " + tipo_mon + " con el importe: " + dat[3].Substring(2).ToString().Trim() + "','ERROR PAGO SERVICIO: " + ex.Message.Trim() + "')", conx);                    
                //    int i = cm.ExecuteNonQuery();

                //}
                //catch (Exception ex1)
                //{
                //    enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
                //    Session["Texto_Error"] = enviar_error;
                //    Response.Redirect("~/Error500.aspx");
                //    //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
                //}

                //conx.Close();
                //enviar_error = ex.Message.ToString().Trim();
                //Session["Texto_Error"] = enviar_error;
                //Response.Redirect("~/Error500.aspx");
                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

                /*/nuevo*/

            //Button13.Enabled = false;
        }
    }

    #region<Raul: (anterior a lo del USD) Boton Efectuar Pago del View7>
    //protected void Button11_Click(object sender, EventArgs e)
    //{
    //    string codServ = (string)Session["codServicio"];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false;
    //    Button11.Enabled = false;
    //    if (Servicio.EstanTodosModificados())
    //    {//se paga
    //        string mensaje = "";
    //        try
    //        {
    //            string Asoci = "";
    //            int PosAsoci = this.PosicionAsociadoPagoSimple();
    //            Asoci = asociadosSevPago.Items[PosAsoci].Cells[1].Text;
    //            if ((Asoci.Substring(2, 1)) == "2")
    //            {
    //                moneda = true;
    //            }
    //            else
    //            {
    //                moneda = false;
    //            }
    //            Button11.Enabled = false;

    //            mensaje = Servicio.EnviarTransaccion(codServ, PosicionAsociadoPagoSimple(), moneda);
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Errores.Alert(this, mensaje);
    //            Button11.Enabled = true;
    //            Label40.Text = "";
    //        }
    //        catch (Exception ex)
    //        {
    //            Button11.Enabled = true;
    //            Label40.Text = "";
    //            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        }
    //        TextBox5.Text = "";
    //    }
    //    else
    //    {
    //        Errores.Alert(this, " Faltan datos por introducir ");
    //    }
    //}
    #endregion
    protected void Button11_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0;
        Button11.Enabled = false;
        if (Servicio.EstanTodosModificados())
        {//se paga
            string mensaje = "";
            try
            {
                string Asoci = "";
                int PosAsoci = this.PosicionAsociadoPagoSimple();
                Asoci = asociadosSevPago.Items[PosAsoci].Cells[1].Text;
                if ((Asoci.Substring(2, 1)) == "2")
                {
                    moneda = 1;
                }
                else
                {
                    moneda = 0;
                }
                Button11.Enabled = false;

                mensaje = Servicio.EnviarTransaccion(codServ, PosicionAsociadoPagoSimple(),moneda);
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                Errores.Alert(this, mensaje);
                Button11.Enabled = true;
                Label40.Text = "";
            }
            catch (Exception ex)
            {
                Button11.Enabled = true;
                Label40.Text = "";
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
            TextBox5.Text = "";
        }
        else
        {
            Errores.Alert(this, " Faltan datos por introducir ");
        }
    }

    private int PosicionAsociadoPagoSimple()
    {
        int i = 0;
        foreach (DataGridItem row in asociadosSevPago.Items)
        {
            CheckBox item = (CheckBox)row.Cells[0].Controls[1];
            if (item.Checked)
            {
                return i;
            }
            i++;
        }
        return -1;
    }


    protected void PagarAsociado(object sender, EventArgs e)
    {

    }
    private void InicializaVistadeServicios()
    {
        //Label5.Visible = false;

        Button56.Enabled = false;
        Button57.Enabled = false;
        ListBox3.SelectedIndex = -1;
        RadioButtonList1.Items[0].Selected = false;
        RadioButtonList1.Items[1].Selected = false;
        if (ListBox3.Items.Count == 0)
        {
            Button55.Enabled = false;
            Button55_Click(null, null);
        }
        else
        {
            RadioButtonList1.Visible = false;
            Label5.Visible = false;
        }
    }

    private bool CargarServicios()
    {
        try
        {
            ListBox3.Items.Clear();
            string[] aux = Servicio.ListaServiciosExistentes();

            if (aux.Length == 0)
            {
                this.InicializaVistadeServicios();


            }
            else
            {
                ListBox3.DataSource = aux;
                ListBox3.DataBind();
                this.InicializaVistadeServicios();
            }
            return true;
        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            return false;
        }

    }



    protected void Button57_Click1(object sender, EventArgs e)
    {

        Label5.Visible = false;               // no habilito el tipo de servicio
        RadioButtonList1.Visible = false;
        new Errores(this).Confirmar(" ¿Confirma que desea eliminar el servicio? ", "EliminarServicio");

    }
    protected void RadioButtonList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button56_Click(object sender, EventArgs e)
    {

        Label5.Visible = false;
        RadioButtonList1.Visible = false;
        object[] atriv = Servicio.GetListaAtributosDeServicios(ListBox3.SelectedItem.Text);
        string[] datos = (string[])atriv[1];  //segundo arreglo de string: el tipo de servicio
        if (datos[0] == "01") // si simple : en tiposervicio
        {
            this.InicializaVistaModificarSS();
            Label12.Text = ListBox3.SelectedItem.Text;

            datos = (string[])atriv[0];    // primer arreglo: los niveles de autenticacion
            if (datos[0] == "CI")
                CheckBoxList1.Items[0].Selected = true;
            if (datos[1] == "Pin")
                CheckBoxList1.Items[1].Selected = true;
            if (datos[2] == "Tarjeta")
                CheckBoxList1.Items[2].Selected = true;
            TextBox20.Text = datos[3];  // numero de coordenadas

            datos = (string[])atriv[2];  // tercer arreglo : estado del servicio

            if (datos[0] == "AC")
                RadioButtonList4.Items[0].Selected = true;
            else
                RadioButtonList4.Items[1].Selected = true;
            datos = (string[])atriv[3];
            Label28.Text = datos[0];
            //aqui pondra los datos que contendra de la vista de asociacion
            ActualizarDatosAsociados();
            DatosTemp = Servicio.GetListaDatosDeServicios(Label12.Text);
            int length = DatosTemp.Length;
            string[] ar = new string[2];
            for (int i = 0; i < length; i++)
            {
                ar = (string[])DatosTemp[i];
                /*  if ((ar[0] != "IdAsociado") && (ar[0] != "Importe"))
                  {*/
                ListBox7.Items.Add(ar[0]);
                DatosTemp1.Add(ar);
                // }
            }
            this.CargaTodosLosDatos();
            MVWPago.ActiveViewIndex = 15;
        }
        else  // si es modificar complejo
        {

            this.InicializaVistaModificarSC();
            datos = (string[])atriv[0];  // niveles de autenticacion
            if (datos[0] == "CI")
                CheckBoxList4.Items[0].Selected = true;
            if (datos[1] == "Pin")
                CheckBoxList4.Items[1].Selected = true;
            if (datos[2] == "Tarjeta")
                CheckBoxList4.Items[2].Selected = true;
            if (datos[3] != null)
                TextBox27.Text = datos[3];
            if (datos[5] == "tiene asociados")
            {
                CheckBox3.Checked = true;
            }
            else
            {
                CheckBox3.Checked = false;
            }

            Label13.Text = ListBox3.SelectedItem.Text; // el nombre
            datos = (string[])atriv[1];   // primer arreglo: la frecuencia
            TextBox21.Text = datos[0];
            DateTime d = (DateTime)atriv[3];
            Calendar2.SelectedDate = d;   // segundo arreglo: el datatime
            datos = (string[])atriv[4];   // tercer arreglo: el estado
            if (datos[0] == "AC")  //si esta activo el servicio
                RadioButtonList5.Items[0].Selected = true;
            else
                RadioButtonList5.Items[1].Selected = true;
            datos = (string[])atriv[5];
            Label29.Text = datos[0];
            MVWPago.ActiveViewIndex = 16;
        }
    }


    public void EliminarServicio()
    {
        try
        {
            if (Servicio.EliminarServicio(ListBox3.SelectedItem.Text))
            {
                this.CargarServicios();
                Errores.Alert(this, " El servicio fue eliminado satisfactoriamente ");

            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button14_Click1(object sender, EventArgs e)
    {
        RadioButtonList1.Items[0].Selected = false;
        RadioButtonList1.Items[1].Selected = false;

        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        CheckBoxList3.Items[0].Selected = true;
        CheckBoxList3.Items[1].Selected = true;
        CheckBoxList3.Items[2].Selected = true;
        TextBox013.Text = "";
        RadioButtonList2.Items[0].Selected = true;
        RadioButtonList2.Items[1].Selected = true;
        MVWPago.ActiveViewIndex = 13;

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator22.Visible = RegularExpressionValidator30.Visible = RegularExpressionValidator24.Visible =
            RequiredFieldValidator2.Visible = RequiredFieldValidator12.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator35.Visible = true;
        RegularExpressionValidator22.Validate();
        RegularExpressionValidator24.Validate();
        RequiredFieldValidator2.Validate();
        RequiredFieldValidator3.Validate();
        RequiredFieldValidator12.Validate();
        RequiredFieldValidator35.Validate();
        RegularExpressionValidator30.Validate();
        if ((!RegularExpressionValidator22.IsValid) || (!RegularExpressionValidator30.IsValid) || (!RegularExpressionValidator24.IsValid) || (!RequiredFieldValidator35.IsValid) || (!RequiredFieldValidator2.IsValid) || (!RequiredFieldValidator3.IsValid) || (!RequiredFieldValidator12.IsValid))
        {
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }
        try
        {
            new Errores(this).Confirmar("¿Confirma que desea guardar la información?", "InsertarServicioComplejo");
        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    public void InsertarServicioComplejo()
    {


        int coord = Convert.ToInt16(TextBox28.Text);
        string est = "";
        if (RadioButtonList3.Items[0].Selected)
            est = "AC";
        else
            est = "NA";
        bool asociados = false;
        if (CheckBox2.Checked)
        {
            asociados = true;
        }
        if (Servicio.InsertarServicio(TextBox32.Text, TextBox11.Text, CheckBoxList2.Items[2].Selected,
                CheckBoxList2.Items[0].Selected, CheckBoxList2.Items[1].Selected, est,
                "02", coord, Calendar1.SelectedDate,
                Convert.ToInt16(TextBox12.Text), asociados))
        {
            this.LLenarDatosAServicioC();
            if (DatosTemp != null)
            {
                if (Servicio.InsertarDatosAServicio(TextBox11.Text, DatosTemp))
                    Errores.Alert(this, " La información ha sido guardada satisfactoriamente ");

            }
            this.CargarServicios();
            this.Button27_Click(null, null);
        }
        else
            Errores.Alert(this, " El servicio a insertar ya existe. ");
    }
    public void LLenarDatosAServicioC()
    {
        //---------LLenar los datos al servicio complejo--------
        DatosTemp = new object[4];
        string[] aux = new string[2];
        aux[0] = "IdAsociado";
        aux[1] = "1";
        DatosTemp[0] = aux.Clone();

        aux[0] = "Importe";
        aux[1] = "2";
        DatosTemp[2] = aux.Clone();

        aux[0] = "Descriptor";
        aux[1] = "2";
        DatosTemp[1] = aux.Clone();

        aux[0] = "Imformativo";
        aux[1] = "2";
        DatosTemp[3] = aux.Clone();

        //---------Fin LLenar los datos al servicio--------
    }
    protected void Button27_Click(object sender, EventArgs e)
    {
        this.InicializaVistaNSComplejo();
        this.InicializaVistadeServicios();
        // CargarServicios();
        MVWPago.ActiveViewIndex = 12;
    }
    protected void Button30_Click2(object sender, EventArgs e)
    {
        this.InicializaVistaModificarSS();
        this.InicializaVistadeServicios();
        //CargarServicios();
        MVWPago.ActiveViewIndex = 12;
    }
    protected void Button29_Click(object sender, EventArgs e)
    {

        RegularExpressionValidator12.Visible = RequiredFieldValidator10.Visible = true;
        RegularExpressionValidator12.Validate();
        RequiredFieldValidator10.Validate();

        if ((!RegularExpressionValidator12.IsValid) || (!RequiredFieldValidator10.IsValid))
        {
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }
        new Errores(this).Confirmar("¿Confirma que desea guardar la informacion?", "ModificarServicioSimple");

    }
    public void ModificarServicioSimple()
    {
        string est = "";
        int coord = Convert.ToInt16(TextBox20.Text);
        if (RadioButtonList4.Items[0].Selected)
            est = "AC";
        else
            est = "NA";
        try
        {
            if (Servicio.ModificarServicio(Label28.Text, Label12.Text, CheckBoxList1.Items[2].Selected, CheckBoxList1.Items[0].Selected, CheckBoxList1.Items[1].Selected,
                                  est, "01", coord, (DateTime)System.Data.SqlTypes.SqlDateTime.Null, 0, true))
            {

                if (DatosTemp != null)
                {
                    Servicio.InsertarDatosAServicio(Label12.Text, DatosTemp);

                }
                Errores.Alert(this, " La información ha sido guardada satisfactoriamente ");
            }
            EstadoNavegPago.UltimaPagConfServ2 = 0; //para cuando cancela Conf Datos            
            this.CargarServicios();
            this.Button30_Click2(null, null);
        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button33_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator10.Visible = RegularExpressionValidator23.Visible = RequiredFieldValidator4.Visible = RequiredFieldValidator33.Visible = true;
        RegularExpressionValidator10.Validate(); RegularExpressionValidator23.Validate(); RequiredFieldValidator4.Validate();
        RequiredFieldValidator33.Validate();

        if ((!RegularExpressionValidator10.IsValid) || (!RegularExpressionValidator23.IsValid) || (!RequiredFieldValidator4.IsValid) || (!RequiredFieldValidator33.IsValid))
        {
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }        

        EstadoNavegPago.UltimaPagina = 17;
        MVWPago.ActiveViewIndex = 0;
       
        //new Errores(this).Confirmar("¿Confirma que desea guardar la informacion?", "ModificarServicioComplejo");
        ModificarServicioComplejo();

    }
    public void ModificarServicioComplejo()
    {
        try
        {
            string est = "";
            if (RadioButtonList5.Items[0].Selected)
                est = "AC";
            else
                est = "NA";

            int coord = Convert.ToInt16(TextBox27.Text);
            bool asociados = false;
            if (CheckBox3.Checked)
            {
                asociados = true;
            }
            Servicio.ModificarServicio(Label29.Text, Label13.Text, CheckBoxList4.Items[2].Selected
                , CheckBoxList4.Items[0].Selected, CheckBoxList4.Items[1].Selected,
                est, "02", coord, Calendar2.SelectedDate, Convert.ToInt16(TextBox21.Text), asociados);
            this.LLenarDatosAServicioC();

            if (DatosTemp != null)
            {
                if (Servicio.InsertarDatosAServicio(Label13.Text, DatosTemp))
                    Errores.Alert(this, " La información ha sido guardada satisfactoriamente ");

            }
            this.CargarServicios();

            this.Button35_Click(null, null);
        }
        catch (Exception ex)
        {

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button35_Click(object sender, EventArgs e)
    {
        this.InicializaVistaModificarSC();
        InicializaVistadeServicios();
        //CargarServicios();
        MVWPago.ActiveViewIndex = 12;

    }

    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //

        if (Label1.Text == "ETECSA" || Label1.Text == "Etecsa")
        {
            if (ListBox2.SelectedItem.Text == "Importe")
            {
                TextBox5.Text = Label40.Text.Trim();
            }
            else
            {
                string mes = Convert.ToString(DateTime.Today.Month);
                string anno = Convert.ToString(DateTime.Today.Year);
                TextBox5.Text = mes + "/" + anno;
            }

        }
        if (ListBox2.SelectedIndex == -1)
            Errores.Alert(this, " Debe seleccionar un dato ");

        //TextBox5.Text = Servicio.MostrarDatoPago(ListBox2.SelectedItem.Value);


    }
    public void CargaTodosLosDatos()
    {
        try
        {
            ListBox8.Items.Clear();
            TodosDatos = Servicio.GetListadoTodosDatos();
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
        int lenght = TodosDatos.Length;
        string[] elem = new string[4];

        for (int i = 0; i < lenght; i++)
        {
            elem = (string[])TodosDatos[i];
            ListBox8.Items.Add(elem[0]);
        }
    }
    protected void Button26_Click(object sender, EventArgs e)
    {

        EstadoNavegPago.UltimaPagConfServ = 13;
        Button71.Enabled = false;
        MVWPago.ActiveViewIndex = 18;
    }
    protected void Button70_Click(object sender, EventArgs e)
    {
        if (RadioButtonList8.SelectedIndex == -1)
        {
            Errores.Alert(this, " Debe especificar el tipo de dato  ");
        }
        else
            if (ListBox8.SelectedIndex == -1)
                Errores.Alert(this, " Debe seleccionar un dato existente ");
            else
            {
                bool esta = false;

                string nomd = ListBox8.SelectedItem.Text.ToString();
                int lenght = ListBox7.Items.Count;

                for (int i = 0; i < lenght; i++)
                {
                    if (ListBox7.Items[i].Text == nomd)
                        esta = true;
                }
                if (!esta)
                {
                    string[] aux = new string[2];
                    if (RadioButtonList8.Items[0].Selected == true) // para el relevante
                    {
                        aux[0] = nomd;
                        aux[1] = "1";
                        DatosTemp1.Add(aux.Clone());
                    }
                    else
                        if (RadioButtonList8.Items[1].Selected == true)  // para el importe
                        {
                            lenght = DatosTemp1.Count;
                            string[] element = null;
                            for (int i = 0; i < lenght; i++)
                            {
                                element = (string[])DatosTemp1[i];
                                if (element[1].Equals("4"))
                                {
                                    Errores.Alert(this, "  El servicio ya contiene un dato de tipo Importe ");
                                    return;
                                }
                            }
                            aux[0] = nomd;
                            aux[1] = "4";
                            DatosTemp1.Add(aux.Clone());
                        }
                        else
                            if (RadioButtonList8.Items[2].Selected == true)  // para el de pago
                            {
                                aux[0] = nomd;
                                aux[1] = "2";
                                DatosTemp1.Add(aux.Clone());
                            }

                    ListBox7.Items.Add(nomd);
                    ListBox7.SelectedIndex = ListBox7.Items.Count - 1;
                    Button71.Enabled = true;

                }
                else
                    Errores.Alert(this, " El servicio ya contiene ese dato ");
            }
    }
    protected void Button71_Click(object sender, EventArgs e)
    {

        DatosTemp1.RemoveAt(ListBox7.SelectedIndex);
        ListBox7.Items.RemoveAt(ListBox7.SelectedIndex);
        ListBox7.SelectedIndex = -1;
        RadioButtonList8.Items[0].Selected = false;
        RadioButtonList8.Items[1].Selected = false;
        Button71.Enabled = false;

    }

    protected void ListBox8_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    //-----------------------------Configurar servicio---------------------

    //Se eliminó el periodo de pago para etecsa en la tabla C_RELSD, para agregarlo nuevamente completar ID_SERV=01 ID_DATOS=4 ORDEN = 1 DAT_CAR=2
    protected void ListBox7_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] aux = (string[])DatosTemp1[ListBox7.SelectedIndex];
        if (aux[1].Equals("1"))
        {
            RadioButtonList8.Items[0].Selected = true;
            RadioButtonList8.Items[1].Selected = false;
            RadioButtonList8.Items[2].Selected = false;
        }
        else
            if (aux[1].Equals("4"))
            {
                RadioButtonList8.Items[0].Selected = false;
                RadioButtonList8.Items[1].Selected = true;
                RadioButtonList8.Items[2].Selected = false;
            }
            else
                if (aux[1].Equals("2"))
                {
                    RadioButtonList8.Items[0].Selected = false;
                    RadioButtonList8.Items[1].Selected = false;
                    RadioButtonList8.Items[2].Selected = true;
                }

        Button71.Enabled = true;
        ListBox8.SelectedIndex = -1;
    }

    private void ActualizarDatosAsociados()
    {

        ListBox7.Items.Clear();
        DatosTemp1.Clear();
        /* string[] aux = new string[2];
         ListBox7.Items.Add("IdAsociado");
         aux[0]="IdAsociado";
         aux[1]="1";       
         DatosTemp1.Add(aux.Clone());
        
         ListBox7.Items.Add("Importe");
         aux[0] = "Importe";
         aux[1] = "2";       
         DatosTemp1.Add(aux.Clone());*/

    }

    //-------------------------Configurar servicio------------------------
    protected void Button72_Click(object sender, EventArgs e)
    {
        if (DatosTemp1.Count == 0)
            this.DatosTemp = null;
        else
            this.DatosTemp = DatosTemp1.ToArray();

        ListBox7.SelectedIndex = -1;
        ListBox8.SelectedIndex = -1;
        RadioButtonList8.Items[0].Selected = false;
        RadioButtonList8.Items[1].Selected = false;

        MVWPago.ActiveViewIndex = EstadoNavegPago.UltimaPagConfServ;


    }
    protected void Button20_Click1(object sender, EventArgs e)
    {
        this.InicializaVistaNSSimple();
        this.InicializaVistadeServicios();  //inicializar la vista 13 con nada seleccionado..
        // CargarServicios();
        MVWPago.ActiveViewIndex = 12;
    }
    private int TextToInt(string text)
    {
        if (text == "1ro")
            return 0;
        if (text == "2do")
            return 1;
        if (text == "3ro")
            return 2;
        if (text == "4to")
            return 3;
        return -1;
    }


    protected void Button64_Click(object sender, EventArgs e)
    {
        #region validacion
        RegularExpressionValidator6.Visible = false;
        RegularExpressionValidator7.Visible = false;
        RequiredFieldValidator23.Visible = false;
        RequiredFieldValidator24.Visible = false;

        RequiredFieldValidator23.Validate();
        RequiredFieldValidator24.Validate();
        RegularExpressionValidator6.Validate();
        RegularExpressionValidator7.Validate();


        bool valido = RequiredFieldValidator23.IsValid && RequiredFieldValidator24.IsValid && RegularExpressionValidator6.IsValid && RegularExpressionValidator7.IsValid;

        if (!valido)
        {
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }
        #endregion

        int[] pin = new int[4];
        pin[0] = TextToInt(Label32.Text);
        pin[1] = Convert.ToInt32(TextBox41.Value);
        pin[2] = TextToInt(Label33.Text);
        pin[3] = Convert.ToInt32(TextBox42.Value);
        try
        {
            
            if (Servicio.ChequearPin(pin))            
            {
                EstadoNavegPago.AutenticadoPin = true;
                EstadoNavegPago.AutenticadoTarjeta = true;
                TextBox42.Value = "";
                TextBox41.Value = "";
                Label2.Text = Servicio.PreguntarCoordenada();
                TextBox4.Focus();
                EstadoNavegPago.UltimaPagina = 3;
                MVWPago.ActiveViewIndex = 40;

                object[] servicios = new object[1];
                servicios = Servicio.MostrarServiciosContratados();

                string[] nombres = (string[])servicios[1];
                Session["Serv_Contratados"] = nombres;

                GridView5.DataSource = nombres;
                GridView5.DataBind();

                int CountMenu = Menu1.Items.Count;

                for (int i = 0; i < CountMenu; i++)
                {
                    if (Menu1.Items[i].Value == "1")
                    {

                        //Menu1.Items[i].Enabled = false;
                    }
                    else
                    {
                        Menu1.Items[i].Enabled = true;
                    }
                }

                //nuevo Raul: mostrar el label de la tarjeta bt autenticada despues que confirma el pin
                

            }
            else
            {
                EstadoNavegPago.CantPinIM++;
                if (EstadoNavegPago.CantPinIM >= EstadoNavegPago.CantIntentos)
                {
                    FinalizarCasoUso();
                    Errores.Alert(this, " Ha realizado el máximo de intentos ");
                }
                else
                {
                    Errores.Alert(this, " Los dígitos del PIN son erróneos ");
                }
                TextBox41.Value = "";
                TextBox42.Value = "";

            }
        }
        catch (Exception ex)
        {
            Button65_Click(null, null);
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }


    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        EstadoNavegPago.EsPrimeraCoord = true;

        #region validacion
        RegularExpressionValidator5.Visible = true;
        RegularExpressionValidator14.Visible = true;
        RegularExpressionValidator15.Visible = true;
        RequiredFieldValidator26.Visible = true;
        RequiredFieldValidator27.Visible = true;
        RequiredFieldValidator28.Visible = true;

        RequiredFieldValidator26.Validate();
        RequiredFieldValidator27.Validate();
        RequiredFieldValidator28.Validate();
        RegularExpressionValidator5.Validate();
        RegularExpressionValidator14.Validate();
        RegularExpressionValidator15.Validate();
        #endregion

        bool valido = RequiredFieldValidator26.IsValid && RequiredFieldValidator27.IsValid && RequiredFieldValidator28.IsValid && RegularExpressionValidator5.IsValid && RegularExpressionValidator14.IsValid && RegularExpressionValidator15.IsValid;
        if (!valido)
            Errores.Alert(this, " Entrada de datos no válida ");
        else
        {

            try
            {
                string aux = TextBox2.Value + TextBox3.Value + TextBox43.Value;
                string estado = Servicio.BuscarTarjeta(aux);
                if (estado.StartsWith("operadora|"))
                    estado = estado.Replace("operadora|", "");

                if (estado == "A")
                {
                    LlenarConsultarSaldo();
                }
                if (estado == "D")
                {
                    Errores.Alert(this, " La tarjeta esta desabilitada ");  // Es un mensaje
                    return;
                }
                //
                if (estado == "P")
                {
                    Errores.Alert(this, " La tarjeta esta pedida ");  // Es un mensaje
                    return;
                }
                if (estado == "C")
                {
                    Errores.Alert(this, " La tarjeta esta creada ");  // Es un mensaje
                    return;
                }
                if (estado == "")
                {
                    EstadoNavegPago.CantNumTarjIM++;
                    if (EstadoNavegPago.CantNumTarjIM >= EstadoNavegPago.CantIntentos)
                    {
                        Button4_Click(null, null);
                        Errores.Alert(this, " Ha realizado el numero máximo de intentos ");
                    }
                    else
                    {
                        Errores.Alert(this, " El número de la tarjeta no se encuentra registrada en la Banca Telefónica ");
                    }
                    TextBox8.Value = "";
                    TextBox10.Value = "";
                }
            }
            catch (Exception ex)
            {
                Button4_Click(null, null);
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }
    }
    private void LlenarConsultarSaldo()
    {
        try
        {
            
            Label9.Text = Servicio.DarNombrePro();
            //Label10.Text = Servicio.ConsultarSaldo().ToString();
            Button25.Focus();
            MVWPago.ActiveViewIndex = 9;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        TextBox2.Value = "";
        TextBox3.Value = "";
        TextBox43.Value = "";

        MVWPago.ActiveViewIndex = EstadoNavegPago.UltimaPagina;

    }
    private void inicializaVistaReporteTransaccion()
    {

        Calendar4.SelectedDate = DateTime.Today;
        Calendar5.SelectedDate = DateTime.Today;
    }

    protected void Button68_Click(object sender, EventArgs e)
    {
        object[] aux = new object[2];
        string operador = TextBox62.Text;
        string value = RadioButtonList17.SelectedValue.ToString();
        string siglas = RadioButtonList17.SelectedItem.Text;
        Session["siglasmon"] = siglas;
        aux[0] = "ReporteTransacciones";
        if (Calendar4.SelectedDate.CompareTo(Calendar5.SelectedDate) <= 0)
        {

            object[] aux3 = Servicio.getLitadoTransacciones(Calendar4.SelectedDate.Date, Calendar5.SelectedDate.Date, operador, value);

            if (aux3.Length == 0)
            {
                Errores.Alert(this, "..::No existen Transacciones en el Rango de Fechas Seleccionadas::..");
                return;
            }
            aux[1] = aux3;
            Application["Datos"] = aux;
            //Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteOperaciones.aspx?Desde=" + Calendar4.SelectedDate.Date + "&Hasta=" + Calendar5.SelectedDate.Date + "&operador=" + operador + "");

            Navegador.RedirectToPopUp(this, "Reportes.aspx");
        }
        else
            Errores.Alert(this, " Fecha de inicio mayor que fecha de fin ");

    }
    protected void Button73_Click(object sender, EventArgs e)
    {

        RadioButtonList8.Items[0].Selected = false;
        RadioButtonList8.Items[1].Selected = false;

        ListBox8.SelectedIndex = -1;
        DatosTemp1.Clear();
        this.ActualizarDatosAsociados();
        string[] aux = null;
        int lenght = 0;
        if (DatosTemp != null)
            lenght = DatosTemp.Length;
        for (int i = 0; i < lenght; i++)
        {
            aux = (string[])DatosTemp[i];


            DatosTemp1.Add(aux);
            ListBox7.Items.Add(aux[0]);

        }


        MVWPago.ActiveViewIndex = EstadoNavegPago.UltimaPagConfServ;
    }
    protected void Button28_Click1(object sender, EventArgs e)
    {

        EstadoNavegPago.UltimaPagConfServ = 15;
        Button71.Enabled = false;
        MVWPago.ActiveViewIndex = 18;


    }
    private void CargarDatosnoAsociados()
    {

        TodosDatos = Servicio.GetListaDatosNoAsociados();
        string[] dato = new string[4];
        int len = TodosDatos.Length;
        ListBox4.Items.Clear();
        for (int i = 0; i < len; i++)
        {
            dato = (string[])TodosDatos[i];
            ListBox4.Items.Add(dato[0]);
        }


    }


    protected void Button34_Click(object sender, EventArgs e)
    {


        if (EstadoNavegPago.UltimaPagConfServ2 == 18)
        {
            this.CargaTodosLosDatos();
            MVWPago.ActiveViewIndex = 18;
        }
        else
            MVWPago.ActiveViewIndex = 0;
    }
    /*  protected void Button31_Click(object sender, EventArgs e)
      {
          if (RadioButtonList9.SelectedIndex==-1)
              Errores.Alert(this, " Debe especificar alguna opción ");
          else
          {
              if (RadioButtonList9.Items[0].Selected)
              {
                  MVWPago.ActiveViewIndex = 20;
              }
              else
                  if (RadioButtonList9.Items[1].Selected) // si es modificar
                  {
                      if (ListBox4.SelectedIndex == -1)
                          Errores.Alert(this, "Debe escoger algún dato");
                      else
                      {
                          string[] elem = new string[4];
                          TodosDatos = Servicio.GetListadoTodosDatos();
                          int len = TodosDatos.Length;
                          nombreAnt = ListBox4.SelectedItem.Text;
                          for (int i = 0; i < len; i++)
                          {
                              elem = (string[])TodosDatos[i];
                              if (ListBox4.SelectedItem.Text == elem[0])
                              {
                                  TextBox29.Text = elem[0];
                                  TextBox24.Text = elem[3];
                                  MVWPago.ActiveViewIndex = 21;
                                  break;
                              }
                          }
                          DropDownList4.Items.Clear();
                          DropDownList4.Items.Add("int");
                          DropDownList4.Items.Add("int32");
                          DropDownList4.Items.Add("float");
                          DropDownList4.Items.Add("double");
                          DropDownList4.Items.Add("string");
                          DropDownList4.Items.Add("Datatime");
                          DropDownList4.Items.Add("bool");
                          for (int i = 0; i < DropDownList4.Items.Count; i++)
                          {
                              if (elem[2].ToString() == DropDownList4.Items[i].Text)
                              {
                                  DropDownList4.Items[i].Selected = true;
                                  break;
                              }
                          }
                                

                      }
                  }
                  else
                  {
                      try
                      { // ¿Confirma que desea eliminar el dato seleccionado?
                          Servicio.EliminarDato(ListBox4.Text, " ", " ", 0);
                          this.CargarDatosnoAsociados();
                          ListBox4.SelectedIndex = 0;
                      }
                      catch (Exception ex)
                      {
                          Errores.Alert(this, ex.Message);
                      }
                  }
          }
      }*/

    protected void Button74_Click(object sender, EventArgs e)
    {
        TextBox18.Text = "";
        TextBox22.Text = "";
        Button32.Enabled = false;
        Button54.Enabled = false;
        ListBox4.SelectedIndex = -1;
        if (ListBox4.Items.Count != 0)
            MVWPago.ActiveViewIndex = 19;
        else
            MVWPago.ActiveViewIndex = 0;

    }

    public void InsertarDato()
    {
        try
        {
            if (!Servicio.AdicionarDato(TextBox18.Text, " ", DropDownList2.SelectedItem.Value, Convert.ToInt16(TextBox22.Text)))
            {
                //aqui no se especifica el tipo de dato

                Errores.Alert(this, " Existe otro Dato con las mismas características ");
            }
            else
            {
                Errores.Alert(this, "La información ha sido guardada satisfactoriamente");
                this.CargarDatosnoAsociados();  // volver a generar el lisbox de datos
                Button74_Click(null, null);

            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button63_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator9.Visible = true;
        RequiredFieldValidator29.Visible = true;
        RequiredFieldValidator30.Visible = true;


        RequiredFieldValidator29.Validate();
        RegularExpressionValidator9.Validate();
        RequiredFieldValidator30.Validate();

        bool valid = RequiredFieldValidator29.IsValid && RegularExpressionValidator9.IsValid && RequiredFieldValidator30.IsValid;


        if (!valid)
            Errores.Alert(this, "Entrada de datos no válida");
        else
        {

            new Errores(this).Confirmar("¿Confirma que desea guardar la información?", "InsertarDato");
        }

    }
    protected void Button76_Click(object sender, EventArgs e)
    {
        TextBox29.Text = "";
        TextBox24.Text = "";
        Button32.Enabled = false;
        Button54.Enabled = false;
        ListBox4.SelectedIndex = -1;
        MVWPago.ActiveViewIndex = 19;
    }
    protected void ListBox4_Load(object sender, EventArgs e)
    {
        /* if(ListBox4.Items.Count!=0)
         ListBox4.SelectedIndex = 0;*/
    }

    public void ModificarDato()
    {
        try
        {
            if (Servicio.ModificarDato(TextBox29.Text, " ", DropDownList4.SelectedItem.Text, Convert.ToInt16(TextBox24.Text), nombreAnt))
            {
                Errores.Alert(this, "La información ha sido guardada satisfactoriamente");
                this.CargarDatosnoAsociados();
                Button76_Click(null, null);
            }
            else
                Errores.Alert(this, "Existe otro Dato con las mismas características");
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button75_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator13.Visible = true;
        RequiredFieldValidator31.Visible = true;
        RequiredFieldValidator32.Visible = true;

        RegularExpressionValidator13.Validate();
        RequiredFieldValidator31.Validate();
        RequiredFieldValidator32.Validate();

        bool valid = RegularExpressionValidator13.IsValid && RequiredFieldValidator31.IsValid && RequiredFieldValidator32.IsValid;


        if (!valid)
            Errores.Alert(this, " Entrada de datos no válida ");
        else
            new Errores(this).Confirmar("¿Confirma que desea guardar la información?", "ModificarDato");
    }
    protected void TextBox18_Load(object sender, EventArgs e)
    {
        TextBox18.Focus();
    }
    //--------------gestionar banco-----------------
    /*  protected void Button77_Click(object sender, EventArgs e)
      {
          if (RadioButtonList10.SelectedIndex == 0)
              MVWPago.ActiveViewIndex = 23;
          else
          {
              try
              {
                  string banco;
                  string[] NumBanco;
                  if (RadioButtonList10.SelectedIndex == 1)//modificar banco
                  {
                      banco = ListBox9.SelectedValue;
                      NumBanco = banco.Split(' ');
                      string[] DatosBanco = Servicio.BuscarDatosBanco(NumBanco[0]);
                      Label8.Text = DatosBanco[0];  //NOmbre del banco
                      TextBox15.Text = DatosBanco[4];  //abreviatura
                      TextBox25.Text = DatosBanco[3];  //Numero banco
                      TextBox037.Text = DatosBanco[1]; //Web service
                      passWord = DatosBanco[2];  //password
                      MVWPago.ActiveViewIndex = 24;
                  }
                  else
                  {
                      //----falta el mensaje de confirmacion de eliminar banco
                      banco = ListBox9.SelectedValue;
                      NumBanco = banco.Split(' ');
                      Servicio.EliminarBanco(NumBanco[0]);
                      ActualizarLisbox9();
                      ListBox9.SelectedIndex = 0;
                  }

              }
              catch (Exception ex)
              {
                  Errores.Alert(this, ex.Message);
              }            
          }
      }*/

    public void InsertarBanco()
    {
        try
        {
            if (Servicio.AdicionarBanco(TextBox45.Text, TextBox46.Text, passWord, TextBox36.Text, TextBox35.Text, "", ""))
            {
                Errores.Alert(this, "La información ha sido guardada satisfactoriamente");
                TextBox45.Text = "";
                TextBox35.Text = "";
                TextBox36.Text = "";
                TextBox46.Text = "";
                TextBox47.Text = "";
                ActualizarLisbox9();
                ListBox9.SelectedIndex = 0;
                MVWPago.ActiveViewIndex = 22;
            }
            else
                Errores.Alert(this, "Existe otro Banco con los mismos datos del que desea insertar");
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }

    protected void Button79_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator25.Visible = true;
        RegularExpressionValidator27.Visible = true;
        RequiredFieldValidator5.Visible = true;
        RequiredFieldValidator7.Visible = true;
        RequiredFieldValidator8.Visible = true;
        RequiredFieldValidator9.Visible = true;

        RegularExpressionValidator25.Validate();
        RegularExpressionValidator27.Validate();
        RequiredFieldValidator5.Validate();
        RequiredFieldValidator7.Validate();
        RequiredFieldValidator8.Validate();
        RequiredFieldValidator9.Validate();

        bool valid = RegularExpressionValidator27.IsValid && RegularExpressionValidator25.IsValid && RequiredFieldValidator5.IsValid && RequiredFieldValidator7.IsValid && RequiredFieldValidator8.IsValid && RequiredFieldValidator9.IsValid;

        if (!valid)
            Errores.Alert(this, "Entrada de datos no válida");
        else
        {
            passWord = TextBox47.Text;
            new Errores(this).Confirmar("“¿Desea guardar el nuevo banco?", "InsertarBanco");
        }
    }


    protected void Button78_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }

    protected void ListBox9_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox9.SelectedIndex != -1)
        {
            Button58.Enabled = true;
            Button59.Enabled = true;
        }
    }

    protected void Button80_Click1(object sender, EventArgs e)
    {
        ActualizarLisbox9();
        ListBox9.SelectedIndex = -1;
        TextBox45.Text = "";
        TextBox35.Text = "";
        TextBox36.Text = "";
        TextBox46.Text = "";
        TextBox47.Text = "";
        Button58.Enabled = false;
        Button59.Enabled = false;
        MVWPago.ActiveViewIndex = 22;
    }
    protected void Button41_Click1(object sender, EventArgs e)
    {
        Button58.Enabled = false;
        Button59.Enabled = false;
        ListBox9.SelectedIndex = -1;
        MVWPago.ActiveViewIndex = 22;
    }
    private void ActualizarLisbox9()
    {
        ListBox9.Items.Clear();
        object[] obj = Servicio.ObtenerListaBanco();
        string[] ListNumeros = (string[])obj[0];
        string[] ListNombres = (string[])obj[1];
        int cantElementos = ListNumeros.Length;
        for (int i = 0; i < cantElementos; i++)
            ListBox9.Items.Add(ListNumeros[i] + " " + ListNombres[i]);
    }

    public void ModificarBanco()
    {
        try
        {

            if (Servicio.ModificarBanco(Label8.Text, TextBox037.Text, passWord, TextBox25.Text, TextBox15.Text, "", ""))
            {
                Errores.Alert(this, "La información ha sido guardada satisfactoriamente");
                MVWPago.ActiveViewIndex = 22;
            }

            else
                Errores.Alert(this, "Existe otro Banco con los mismos datos del que desea guardar");
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button40_Click1(object sender, EventArgs e)
    {

        RequiredFieldValidator11.Visible = true;
        RegularExpressionValidator28.Visible = true;

        RequiredFieldValidator11.Validate();
        RegularExpressionValidator28.Validate();


        bool valid = RequiredFieldValidator11.IsValid && RegularExpressionValidator28.IsValid;

        if (!valid)
            Errores.Alert(this, "Entrada de datos no válida");
        else
        {

            if (TextBox038.Text != "")
                passWord = TextBox038.Text;
            new Errores(this).Confirmar("“¿Desea guardar los datos?”", "ModificarBanco");
        }

    }
    //--------------fin gestionar banco-----------------


    protected void Button50_Click(object sender, EventArgs e)
    {
        //aceptar numero tarjeta iniciar reclamacion
        RegularExpressionValidator16.Visible = true;
        RegularExpressionValidator17.Visible = true;
        RegularExpressionValidator18.Visible = true;
        RequiredFieldValidator13.Visible = true;
        RequiredFieldValidator14.Visible = true;
        RequiredFieldValidator15.Visible = true;

        RegularExpressionValidator16.Validate();
        RegularExpressionValidator17.Validate();
        RegularExpressionValidator18.Validate();
        RequiredFieldValidator13.Validate();
        RequiredFieldValidator14.Validate();
        RequiredFieldValidator15.Validate();

        bool valid = RegularExpressionValidator16.IsValid && RegularExpressionValidator17.IsValid && RegularExpressionValidator18.IsValid && RequiredFieldValidator13.IsValid && RequiredFieldValidator14.IsValid && RequiredFieldValidator15.IsValid;



        if (!valid)
            Errores.Alert(this, " Entrada de datos no válida ");
        else
        {
            try
            {
                string aux = TextBox1.Value + TextBox14.Value + TextBox23.Value;
                string estado = Servicio.BuscarTarjeta(aux);
                if (estado.StartsWith("operadora|"))
                    estado = estado.Replace("operadora|", "");
                if (estado == "A")
                {
                    Label3.Text = Servicio.DarNombrePro();
                    int[] ping = Servicio.PreguntarPin();
                    string[] alf ={ "1er", "2do", "3er", "4to" };
                    Label15.Text = alf[ping[0]];
                    Label16.Text = alf[ping[1]];
                    TextBox16.Focus();
                    MVWPago.ActiveViewIndex = 26;
                    //Inicializando---------
                    EstadoNavegPago.CantNumTarjIM = 0;
                    TextBox1.Value = "";
                    TextBox14.Value = "";
                    TextBox23.Value = "";
                }
                if (estado == "D")
                {
                    Button51_Click1(null, null);
                    Errores.Alert(this, " ..::Tarjeta Deshabilitada::.. ");  // Es un mensaje
                }
                //
                if (estado == "P")
                {
                    Button51_Click1(null, null);
                    Errores.Alert(this, "..::Tarjeta Pedida::.. ");  // Es un mensaje
                }
                if (estado == "C")
                {
                    Button51_Click1(null, null);
                    Errores.Alert(this, "..::Tarjeta Creada::..");  // Es un mensaje
                }

                if (estado == "")
                {//cuando el numero no esta
                    EstadoNavegPago.CantNumTarjIM++;
                    if (EstadoNavegPago.CantNumTarjIM >= EstadoNavegPago.CantIntentos)
                    {
                        Button51_Click1(null, null);
                        EstadoNavegPago.CantNumTarjIM = 0;
                        Errores.Alert(this, " Ha realizado el número máximo de intentos ");
                    }
                    else
                    {
                        Errores.Alert(this, " El No de Tarjeta que busca, no se encuentra registrada en la Banca Telefónica ");

                    }
                    TextBox1.Value = "";
                    TextBox14.Value = "";
                    TextBox23.Value = "";
                }
            }
            catch (Exception ex)
            {
                Button51_Click1(null, null);
                MVWPago.ActiveViewIndex = 0;
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }
    }
    protected void Button51_Click1(object sender, EventArgs e)
    {
        //cancelar accion numero tarjeta iniciar reclamacion
        TextBox1.Value = "";
        TextBox14.Value = "";
        TextBox23.Value = "";
        EstadoNavegPago.CantNumTarjIM = 0;
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button39_Click(object sender, EventArgs e)
    {
        //cancelar accion coordenada iniciar reclamacion
        TextBox19.Value = "";
        EstadoNavegPago.CantCoordIM = 0;
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button37_Click1(object sender, EventArgs e)
    {
        //cancelar accion pin iniciar reclamacion
        EstadoNavegPago.CantPinIM = 0;
        MVWPago.ActiveViewIndex = 0;
    }
    private void LLenarReclamacion(string[] t, string asociado)
    {
        DataTable a = new DataTable();
        a.Columns.Add("nombre", "".GetType());
        a.Columns.Add("valor", "".GetType());
        DataRow r = a.NewRow();
        r[0] = "Fecha:";
        r[1] = t[0];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "Importe:";
        r[1] = t[1];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "Usuario:";
        r[1] = t[2];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "Número de tarjeta:";
        r[1] = t[3];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "Servicio:";
        r[1] = t[4];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "Nombre cliente:";
        r[1] = t[5];
        a.Rows.Add(r);
        r = a.NewRow();
        r[0] = "IDAsociado:";
        r[1] = asociado;
        a.Rows.Add(r);

        GridView1.DataSource = a;
        GridView1.DataBind();
    }
    protected void Button118_Click(object sender, EventArgs e)
    {
        Label45.Visible = false;
        string Traza = TextBox26.Text;
        string dia = DropDownList3.SelectedValue.ToString();
        string mes = DropDownList6.SelectedValue.ToString();
        string anno = DropDownList7.SelectedValue.ToString();
        //int[] fechaTrans = new int[3];
        //fechaTrans[0] = Convert.ToInt32(DropDownList3.SelectedValue);
        //fechaTrans[1] = Convert.ToInt32(DropDownList6.SelectedValue);
        //fechaTrans[2] = Convert.ToInt32(DropDownList7.SelectedValue);
        //DateTime fecha = new DateTime(fechaTrans[2], fechaTrans[1], fechaTrans[0]);
        string Servicio = DropDownList11.SelectedValue.ToString();
        string Tarjeta = Session["NoTarjeta"].ToString();
        string Monto = TextBox63.Text;
        Class1 Myclass = new Class1();
        DataSet Reclamar = Myclass.GetOperacionReclamar(Traza, dia, mes, anno, Tarjeta, Servicio, Monto);
        DataGrid2.DataSource = Reclamar;
        DataGrid2.DataBind();
        DataGrid2.Visible = true;
        if (Reclamar.Tables[0].Rows.Count == 0) Label45.Visible = true;

    }
    protected void DataGrid2_PreRender(object sender, EventArgs e)
    {
        int count = 0;
        foreach (DataGridItem i in DataGrid2.Items)
        {
            CheckBox item = (CheckBox)i.Cells[0].Controls[1];
            if (item.Checked)
            {
                count++;
            }
        }
        if (count == 1) Button42.Visible = true;
        else Button42.Visible = false;
    }
    protected void Button42_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator26.Visible = true;
        // RequiredFieldValidator19.Visible = true;

        RegularExpressionValidator26.Validate();
        //RequiredFieldValidator19.Validate();

        bool valid = RegularExpressionValidator26.IsValid;//&& RequiredFieldValidator19.IsValid;

        //pasar traza de iniciar reclamacion
        if (!valid)
            Errores.Alert(this, " Entrada de datos no válida  ");
        else
        {
            try
            {
                DateTime fecha = DateTime.Now;
                string Traza = "";
                string asociado = "";
                foreach (DataGridItem i in DataGrid2.Items)
                {
                    CheckBox item = (CheckBox)i.Cells[0].Controls[1];
                    if (item.Checked)
                    {
                        Traza = i.Cells[1].Text.ToString();
                        fecha = Convert.ToDateTime(i.Cells[2].Text.ToString());
                        asociado = i.Cells[5].Text.ToString();
                    }
                }
                int[] fechaTrans = new int[3];
                //fechaTrans[0] = Convert.ToInt32(DropDownList3.SelectedValue);
                fechaTrans[0] = Convert.ToInt32(fecha.Day);
                //fechaTrans[1] = Convert.ToInt32(DropDownList6.SelectedValue);
                fechaTrans[1] = Convert.ToInt32(fecha.Month);
                //fechaTrans[2] = Convert.ToInt32(DropDownList7.SelectedValue);
                fechaTrans[2] = Convert.ToInt32(fecha.Year);
                string[] transaccion = Servicio.MostrarTransaccionAReclamar(Traza, fechaTrans);
                // 0 - Asociado,1 - FechaHora,2 - Importe,3 - Usuario,4 - No. Tarjeta,	
                //5 - Servicio,6 - Nombre y Apellidos del cliente,7 - idTransaccion 
                //if el arreglo que devuelve tiene "count=1" es que no existe la transaccion 
                if (transaccion.Length > 1)
                {

                    Session["idTransaccion"] = transaccion[6];
                    //Label18.Text = transaccion[0];
                    //Label19.Text = transaccion[0];
                    //Label20.Text = transaccion[1];
                    //Label21.Text = transaccion[2];
                    //Label22.Text = transaccion[3];
                    //Label23.Text = transaccion[4];
                    //Label24.Text = transaccion[5];

                    LLenarReclamacion(transaccion, asociado);
                    MVWPago.ActiveViewIndex = 29;
                    //Inicializando------
                    EstadoNavegPago.CantTrazasIN = 0;
                    TextBox26.Text = "";
                    TextBox63.Text = "";
                    DropDownList7.Items.Clear();
                }
                else
                {
                    EstadoNavegPago.CantTrazasIN++;
                    if (EstadoNavegPago.CantTrazasIN >= EstadoNavegPago.CantIntentos)
                    {
                        EstadoNavegPago.CantTrazasIN = 0;
                        Errores.Alert(this, " Ha realizado el número máximo de intentos ");
                        MVWPago.ActiveViewIndex = 0;
                    }
                    else
                    {
                        Errores.Alert(this, "La transacción no existe");
                        TextBox26.Text = "";
                    }
                }
                DataGrid2.Visible = false;

            }
            catch (Exception ex)
            {
                MVWPago.ActiveViewIndex = 0;
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }
    }
    protected void Button52_Click(object sender, EventArgs e)
    {

    }
    protected void Button52_Click1(object sender, EventArgs e)
    {
        //actualizar dato pago

        if (ListBox2.SelectedIndex == -1)
            Errores.Alert(this, " Debe seleccionar un dato ");

        RegularExpressionValidator31.Visible = false;
        RegularExpressionValidator31.Validate();
        if (!RegularExpressionValidator31.IsValid)
        {
            Errores.Alert(this, " Entrada de datos no válida ");
        }
        else
        {
            try
            {
                string idDato = ListBox2.SelectedItem.Value;
                if (!Servicio.ModificarDatoPago(idDato, TextBox5.Text)) //en la lista de datos del usuario
                    Errores.Alert(this, " Entrada de datos no válida ");

            }
            catch (Exception ex)
            {

                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }


    }
    protected void Button43_Click1(object sender, EventArgs e)
    {
        //
        DropDownList7.Items.Clear();
        Label45.Visible = false;
        TextBox26.Text = "";
        TextBox63.Text = "";
        EstadoNavegPago.CantTrazasIN = 0;
        MVWPago.ActiveViewIndex = 0;

    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
        TextBox30.Text = "";
    }

    public void GuardarReclamacion()
    {
        try
        {
            string reclamacion = "";
            foreach (GridViewRow row in GridView1.Rows)
            {
                reclamacion = reclamacion + ' ' + row.Cells[0].Text.ToString() + ' ' + row.Cells[1].Text.ToString();
            }
            reclamacion = reclamacion + ' ' + TextBox30.Text;
            Servicio.ReclamarTransaccion((string)Session["idTransaccion"], reclamacion);
            Errores.Alert(this, " La reclamación se inicio satisfactoriamente");
            MVWPago.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            MVWPago.ActiveViewIndex = 0;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }


    protected void Button44_Click1(object sender, EventArgs e)
    {
        //
        //new Errores(this).Confirmar("¿Desea guardar la reclamación?", "GuardarReclamacion");
        GuardarReclamacion();

    }


    protected void Button53_Click1(object sender, EventArgs e)
    {
        ListBox16.Items.Clear();
        CheckBox1.Checked = false;
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button49_Click(object sender, EventArgs e)
    {
        object[] array = new object[1];
        object[] array2 = null;
        ArrayList descripcion = new ArrayList();
        string aux = "";
        int len = ListBox16.Items.Count;
        try
        {
            if (CheckBox1.Checked)
            {
                array = new object[len];
                for (int i = 0; i < len; i++)
                {
                    array[i] = ListBox16.Items[i].Value;
                }
                array2 = Servicio.ActualizarServiciosDatos(array); // respuesta del sistema en array2
                if (array2.Length == 0)
                {
                    Button53_Click1(null, null);
                    Errores.Alert(this, " Se actualizó la configuración de los servicios y datos satisfactoriamente ");
                }
                else
                {
                    int len2 = array2.Length;
                    for (int i = 0; i < len2; i++)//se precesa el mensaje con los webservice de los bancos no actualizados
                    {
                        if (i != len - 1)
                            aux += (string)array2[i] + ", ";
                        else
                            aux += (string)array2[i] + ". ";

                    }
                    Errores.Alert(this, " Error de conexión con el Web Service del:  " + aux);
                }

            }
            else
            {
                array[0] = ListBox16.SelectedItem.Value;
                array2 = Servicio.ActualizarServiciosDatos(array);// la respuesta del systema esta array2
                if (array2.Length == 0)
                {
                    Button53_Click1(null, null);
                    Errores.Alert(this, " Se actualizo la configuración de los servicios y datos satisfactoriamente ");
                }
                else
                {

                    Errores.Alert(this, " Error de conexión con el Web Service del " + array2[0]);
                }
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button16_Click3(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("int");
        DropDownList2.Items.Add("short");
        DropDownList2.Items.Add("float");
        DropDownList2.Items.Add("double");
        DropDownList2.Items.Add("string");
        DropDownList2.Items.Add("DateTime");
        DropDownList2.Items.Add("bool");
        DropDownList2.Items.Add("long");

        //....
        MVWPago.ActiveViewIndex = 20;
    }
    protected void Button32_Click1(object sender, EventArgs e)
    {
        if (ListBox4.SelectedIndex == -1)
            Errores.Alert(this, "Debe escoger algún dato");
        else
        {
            string[] elem = new string[4];
            try
            {
                TodosDatos = Servicio.GetListadoTodosDatos();
            }
            catch (Exception ex)
            {
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
            int len = TodosDatos.Length;
            nombreAnt = ListBox4.SelectedItem.Text;
            for (int i = 0; i < len; i++)
            {
                elem = (string[])TodosDatos[i];
                if (ListBox4.SelectedItem.Text == elem[0])
                {
                    TextBox29.Text = elem[0];
                    TextBox24.Text = elem[3];
                    MVWPago.ActiveViewIndex = 21;
                    break;
                }
            }
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("int");
            DropDownList4.Items.Add("short");
            DropDownList4.Items.Add("float");
            DropDownList4.Items.Add("double");
            DropDownList4.Items.Add("string");
            DropDownList4.Items.Add("DateTime");
            DropDownList4.Items.Add("bool");
            DropDownList4.Items.Add("long");

            for (int i = 0; i < DropDownList4.Items.Count; i++)
            {
                if (elem[2].ToString() == DropDownList4.Items[i].Text)
                {
                    DropDownList4.Items[i].Selected = true;
                    break;
                }
            }


        }

    }
    public void EliminarDato()
    {
        try
        {
            // ¿Confirma que desea eliminar el dato seleccionado?
            Servicio.EliminarDato(ListBox4.Text, " ", " ", 0);
            Errores.Alert(this, "..::La información ha sido eliminada satisfactoriamente::..");
            this.CargarDatosnoAsociados();
            ListBox4.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button54_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿Confirma que desea eliminar el Dato seleccionado?", "EliminarDato");

    }
    protected void ListBox4_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ListBox4.SelectedIndex != -1)
        {
            Button16.Enabled = true;
            Button32.Enabled = true;
            Button54.Enabled = true;
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 0)  // si es  insertar simple
        {
            this.InicializaVistaNSSimple();
            this.ActualizarDatosAsociados();

            this.CargaTodosLosDatos();  // carga todos los datos
            MVWPago.ActiveViewIndex = 13;
        }
        else
        {
            this.InicializaVistaNSComplejo();
            MVWPago.ActiveViewIndex = 14;
        }

    }
    public void InicializaVistaNSSimple()
    {

        TextBox6.Text = "";
        TextBox013.Text = "";
        TextBox31.Text = "";
        CheckBoxList3.Items[0].Selected = false;
        CheckBoxList3.Items[1].Selected = false;
        CheckBoxList3.Items[2].Selected = false;
        RadioButtonList2.Items[0].Selected = false;
        RadioButtonList2.Items[1].Selected = false;

    }
    public void InicializaVistaModificarSS()
    {
        CheckBoxList1.Items[0].Selected = false;
        CheckBoxList1.Items[1].Selected = false;
        CheckBoxList1.Items[2].Selected = false;
        RadioButtonList4.Items[0].Selected = false;
        RadioButtonList4.Items[1].Selected = false;
        Label12.Text = "";
        Label28.Text = "";
        TextBox20.Text = "";

    }
    public void InicializaVistaNSComplejo()
    {
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox32.Text = "";
        Calendar1.SelectedDate = new DateTime();

        RadioButtonList3.Items[0].Selected = false;
        RadioButtonList3.Items[1].Selected = false;

    }
    public void InicializaVistaModificarSC()
    {
        Label13.Text = "";
        TextBox21.Text = "";
        Label29.Text = "";
        Calendar1.SelectedDate = new DateTime();
        RadioButtonList5.Items[0].Selected = false;
        RadioButtonList5.Items[1].Selected = false;

    }
    protected void Button55_Click1(object sender, EventArgs e)
    {
        Label5.Visible = true;
        RadioButtonList1.Visible = true;
    }
    protected void RadioButtonList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox14.Visible = true;
        Label14.Visible = true;
        Button48.Visible = false;
        Calendar3.Visible = false;
        Label25.Visible = false;
        Button46.Visible = false;
        Button47.Visible = true;
        Calendar3.SelectedDate = new DateTime();
        ListBox14.Items.Clear();
        object[] listB = new object[1];

        try
        {

            listB = Servicio.ObtenerListaBanco();

            if (((string[])listB[0]).Length > 0)
            {
                string[] ListNumeros = (string[])listB[0];
                string[] ListNombres = (string[])listB[1];
                int cantElementos = ListNumeros.Length;
                for (int i = 0; i < cantElementos; i++)
                    ListBox14.Items.Add(ListNumeros[i] + " " + ListNombres[i]);

            }
            else
            {
                Errores.Alert(this, "..::No hay Bancos Asociados::..");
                ListBox14.Visible = false;
                Label14.Visible = false;
            }

        }
        catch (Exception ex)
        {
            ListBox14.Visible = false;
            Label14.Visible = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void View30_Activate(object sender, EventArgs e)
    {
        RadioButtonList11.ClearSelection();
        ListBox14.Visible = false;
        Label14.Visible = false;
        Label25.Visible = false;
        Button46.Visible = false;
        Button47.Visible = false;
        Calendar3.Visible = false;
        Button48.Visible = false;


    }
    protected void Button46_Click(object sender, EventArgs e)
    {

        try
        {
            if (Calendar3.SelectedDate.ToString() == "01/01/0001 0:00:00")
            {
                Errores.Alert(this, "..::Seleccione una Fecha::..");
            }
            else
            {
                Button48.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void Button19_Click1(object sender, EventArgs e)
    {
        EstadoNavegPago.UltimaPagConfServ2 = 18;
        this.CargarDatosnoAsociados();
        Button32.Enabled = false;
        Button54.Enabled = false;
        MVWPago.ActiveViewIndex = 19;
    }
    protected void View14_Activate(object sender, EventArgs e)
    {
        if ((RadioButtonList2.Items[0].Selected == false) && (RadioButtonList2.Items[1].Selected == false))
            RadioButtonList2.Items[0].Selected = true;
    }
    protected void View15_Activate(object sender, EventArgs e)
    {
        if ((RadioButtonList3.Items[0].Selected == false) && (RadioButtonList3.Items[1].Selected == false))
            RadioButtonList3.Items[0].Selected = true;
        Calendar1.SelectedDate = DateTime.Today;
    }
    protected void ListBox16_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox1.Checked = false;
        if (!Button49.Enabled)
            Button49.Enabled = true;
    }
    protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
    {
        ListBox16.SelectedIndex = -1;
        if (!Button49.Enabled)
            Button49.Enabled = true;
        if (!CheckBox1.Checked)
            Button49.Enabled = false;
    }
    protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Button56.Enabled)
        {
            Button56.Enabled = true;
            Button57.Enabled = true;
        }
    }
    protected void Button31_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 23;
    }
    protected void Button58_Click(object sender, EventArgs e)
    {
        try
        {
            string banco;
            string[] NumBanco;
            banco = ListBox9.SelectedValue;
            NumBanco = banco.Split(' ');
            string[] DatosBanco = Servicio.BuscarDatosBanco(NumBanco[0]);
            Label8.Text = DatosBanco[0];  //NOmbre del banco
            TextBox15.Text = DatosBanco[4];  //abreviatura
            TextBox25.Text = DatosBanco[3];  //Numero banco
            TextBox037.Text = DatosBanco[1]; //Web service
            passWord = DatosBanco[2];  //password
            MVWPago.ActiveViewIndex = 24;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    public void EliminarBanco()
    {
        try
        {
            string banco;
            string[] NumBanco;
            banco = ListBox9.SelectedValue;
            NumBanco = banco.Split(' ');
            Servicio.EliminarBanco(NumBanco[0]);
            Errores.Alert(this, "..::La Información ha sido eliminada satisfactoriamente::..");
            ActualizarLisbox9();
            ListBox9.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button59_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿Desea eliminar el Banco?", "EliminarBanco");


    }
    protected void ListBox14_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button46.Visible = true;
        Button47.Visible = true;
        Calendar3.Visible = true;
        Label25.Visible = true;
        Calendar3.SelectedDate = new DateTime();
        Button48.Visible = false;
    }
    protected void Button47_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;

    }
    protected void Button48_Click(object sender, EventArgs e)
    {
        try
        {
            EnviarConciliacionAux();
        }
        catch (Exception ex)
        {
            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "Button48(Enviar): ConciliacionesAuxiliares \n";
            //    string nombre_proyecto = "(Telebanca): ";
            //    string date = DateTime.Now.ToString();
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + ex.Message);
            //    writer.WriteLine(separador + metodo_error + date);
            //}

            Errores.Alert(this, "Error" + ex.Message);
            return;
        }

        ////new Errores(this).Confirmar("¿Realmente desea Enviar la Conciliación al " + ListBox14.SelectedValue.ToString().Substring(3) + "?", "EnviarConciliacionAux");
        //EnviarConciliacionAux();
    }
    public void EnviarConciliacionAux()
    {
        try
        {
            if (RadioButtonList11.SelectedIndex == 0)
            {
                if (Servicio.ConciliacionesAuxTransaccion(Calendar3.SelectedDate, ListBox14.SelectedValue.Substring(0, 2)))
                {
                    Errores.Alert(this, "La Conciliación fue enviada satisfactoriamente al " + ListBox14.SelectedValue.Substring(3));
                    this.TerminarConciliacionAux();
                }
                else
                {
                    Errores.Alert(this, "..::No hay Transacción para el Banco y Fecha seleccionados::..");
                    this.TerminarConciliacionAux();
                }
            }
            else
            {
                if (Servicio.ConciliacionesAuxReclamacion(Calendar3.SelectedDate, ListBox14.SelectedValue.Substring(0, 2)))
                {
                    Errores.Alert(this, "La Conciliación fue enviada satisfactoriamente al " + ListBox14.SelectedValue.Substring(3));
                    this.TerminarConciliacionAux();
                }
                else
                {
                    Errores.Alert(this, "..::No hay Reclamación para el Banco y Fecha seleccionados::..");
                    this.TerminarConciliacionAux();
                }
            }
        }
        catch (Exception ex)
        {
            TerminarConciliacionAux();
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    public void TerminarConciliacionAux()
    {
        RadioButtonList11.ClearSelection();
        Calendar3.SelectedDate = new DateTime();
        ListBox14.Items.Clear();
        Calendar3.Visible = false;
        Label14.Visible = false;
        Label25.Visible = false;
        ListBox14.Visible = false;
        Button46.Visible = false;
        Button48.Visible = false;
        Button47.Visible = false;
    }
    protected void ValidarChequeadoPS(object sender, EventArgs e)
    {
        CheckBox aux = (CheckBox)sender;

        foreach (DataGridItem row in asociadosSevPago.Items)
        {
            CheckBox item = (CheckBox)row.Cells[0].Controls[1];
            // string v = row.Cells[1].Text;

            if (!item.Equals(aux))
            {
                item.Checked = false;
            }
            Button10.Focus();
        }



    }
    protected void Button60_Click(object sender, EventArgs e)
    {
        //actualizar sucursales
        try
        {
            Servicio.ActualizarSucursales();
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void RadioButtonList6_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Button23.Focus();
    }
    protected void View18_Activate(object sender, EventArgs e)
    {
       
    }
    protected void Button69_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
        RadioButtonList17.ClearSelection();
        Button68.Enabled = false;
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void asociadosSevPago_PreRender(object sender, EventArgs e)
    {
        Button10.Enabled = PosicionAsociadoPagoSimple() != -1;
        
        string codServ = (string)Session["codServicio"];

        if (codServ == "01")
        {
            
            int contador = asociadosSevPago.Items.Count;

            for (int i = 0; i < contador; i++)
            {
                if (asociadosSevPago.Items[i].Cells[1].Text.Substring(2, 1) == "2")
                {
                    asociadosSevPago.Items[i].Cells[1].BackColor = System.Drawing.Color.GreenYellow;
                }

            }

            if (PosicionAsociadoPagoSimple() != -1)
            {
                int PosAsoc = this.PosicionAsociadoPagoSimple();

                string codigo_teleseleccion = asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(6, 2);

                if (codigo_teleseleccion.Substring(0,1) == "7")
                {
                    Label135.Text = Label158.Text = "La Habana";
                }
                if (codigo_teleseleccion == "21")
                {
                    Label135.Text = Label158.Text = "Guantánamo";
                }
                if (codigo_teleseleccion == "22")
                {
                    Label135.Text = Label158.Text = "Santiago de Cuba";
                }
                if (codigo_teleseleccion == "23")
                {
                    Label135.Text = Label158.Text = "Granma";
                }
                if (codigo_teleseleccion == "24")
                {
                    Label135.Text = Label158.Text = "Holguín";
                }
                if (codigo_teleseleccion == "31")
                {
                    Label135.Text = Label158.Text = "Las Tunas";
                }
                if (codigo_teleseleccion == "32")
                {
                    Label135.Text = Label158.Text = "Camagüey";
                }
                if (codigo_teleseleccion == "33")
                {
                    Label135.Text = Label158.Text = "Ciego de Ávila";
                }
                if (codigo_teleseleccion == "41")
                {
                    Label135.Text = Label158.Text = "Sancti Spíritus";
                }
                if (codigo_teleseleccion == "42")
                {
                    Label135.Text = Label158.Text = "Villa Clara";
                }
                if (codigo_teleseleccion == "43")
                {
                    Label135.Text = Label158.Text = "Cienfuegos";
                }
                if (codigo_teleseleccion == "45")
                {
                    Label135.Text = Label158.Text = "Matanzas";
                }
                if (codigo_teleseleccion == "46")
                {
                    Label135.Text = Label158.Text = "Isla de La Juventud";
                }
                if (codigo_teleseleccion == "47")
                {
                    Label135.Text = Label158.Text = "Artemisa o Mayabeque";
                }
                if (codigo_teleseleccion == "48")
                {
                    Label135.Text = Label158.Text = "Pinar del Río";
                }

                if (asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(6, 1) == "7" || asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(6, 2) == "21")
                {
                    Label121.Text = Label157.Text = asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(6, 4) + "-" + asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(10, 4);
                }
                else
                {
                    Label121.Text = Label157.Text = "( " + asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(6, 2) + " ) " + asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(8, 2) + "-" + asociadosSevPago.Items[PosAsoc].Cells[1].Text.Substring(10, 4);
                }

            }
        } 
    }
    protected void View8_Activate(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        string Tarjeta = Session["NoTarjeta"].ToString();
        Label162.Text = "";
        if (codServ == "03")
        {
            RadioButtonList9.Visible = true;
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);
            int cantidad = DT.Tables[0].Rows.Count;
            if (cantidad >= 2)
            {
                if (RadioButtonList9.Items.Count == 0)
                {
                    foreach (DataRow Row in DT.Tables[0].Rows)
                    {
                        RadioButtonList9.Items.Add(Row[1].ToString());
                    }
                }
            }
            if (cantidad == 1)
            {
                RadioButtonList9.Visible = false;
            }

            Button13.Enabled = true; // habilito el SI del pago
        }
        else
        {
            RadioButtonList9.Visible = false;
        }

        //Label7.Text = "";
        //Button13.Enabled = false;
        

        if (codServ == "04")
        {
            Button100.Visible = true;
        }
        else
        {
            Button100.Visible = false;
        }
        if (codServ == "05" || codServ == "11")
        {
            PagosComp.Enabled = false;
        }
        else
        {
            PagosComp.Enabled = true;
        }

        

        
        
        
    }
    protected void View7_Activate(object sender, EventArgs e)
    {
        Button11.Enabled = true;
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList6.Enabled = ((ListBox)sender).SelectedIndex != -1;
        RadioButtonList6.SelectedIndex = -1;
        Button23.Enabled = false;
    }
    protected void RadioButtonList6_SelectedIndexChanged2(object sender, EventArgs e)
    {
        Button23.Enabled = RadioButtonList6.Enabled && RadioButtonList6.SelectedIndex != -1;
    }

    //Descargar del FTP
    protected void BtnDescFTP_Click(object sender, EventArgs e)
    {

        #region DescargaFTP_Ensamblado
        string IdServ = Label29.Text;
        DateTime fecha = Calendar2.SelectedDate;         
        string mensaje = "";
        (BtnDescFTP).Enabled = false;
        if (Servicio.DescargarFicheroServicioFTP(IdServ, fecha, out mensaje) == true || mensaje.Contains("Operación Satisfactoria"))
        {
            Errores.Alert(this, "Carga del fichero:" + mensaje);
        }
        else if (Servicio.DescargarFicheroServicioFTP(IdServ, fecha, out mensaje) == false || mensaje.Contains("Error"))
        {
            Errores.Alert(this, "Fallo. " + mensaje);
        }
        #endregion

        # region codigo nuevo Raul comentareado
        //string IdServ = Label29.Text;
        //int cantidad_lineas = 0;
        //string path = "C:\\Empresas\\" + IdServ + "\\E" + IdServ + ".txt";
        ////using (FileStream fs = File.Open(path, FileMode.Append))
        ////{

        ////    //aqui trabjas con el file

        ////}

        //File.Delete(path);  

        ////FileStream file_stream = new FileStream(path, FileMode.Create, FileAccess.Read);
        ////file_stream.Close();
        ////file_stream.Dispose();

        ////File.Delete("C:\\Empresas\\" + IdServ + "\\E" + IdServ + ".txt");                

        //    //string fichero = @"C:\Empresas\" + IdServ + @"\E" + IdServ + ".txt";            
            
        //    //if (File.Exists(fichero))
        //    //{
        //    //    FileStream read = new FileStream(fichero, FileMode.Open, FileAccess.Read);
        //    //    try
        //    //    {                    
        //    //        using (var stream = File.Open(fichero,FileMode.Open,FileAccess.Read))
        //    //        {
        //    //            stream.Close();
        //    //            stream.Unlock(0, 10000000);
        //    //            File.Delete(fichero);
        //    //            stream.Dispose();
        //    //            stream.Close();
        //    //            read.Close();
        //    //        }

        //    //    }
        //    //    catch (Exception)
        //    //    {                    
        //    //        read.Close();
        //    //        if (File.Exists(fichero))
        //    //        { File.Delete(fichero); }
        //    //        //throw;
        //    //    }
        //    //    read.Close();
        //    //}


        //DateTime fecha = Calendar2.SelectedDate;
        //BtnDescFTP.Enabled = false;
        ////((Button)sender).Enabled = false;

        //string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;

        //SqlConnection conx = new SqlConnection(cadena_conexion);

        //try
        //{
                
        //        //Servicio.DescargarFicheroFtpCompleted += this.DescargaCompletada;
        //        //Servicio.DescargarFicheroFtpAsync(IdServ);
        //        if(Servicio.DescargarFicheroFtp(IdServ, fecha)== true)
        //        {
        //            StreamReader lector_fichero = new StreamReader(@"C:\Empresas\" + IdServ + @"\E" + IdServ + ".txt");
        //            try
        //            {
                        
        //                while (lector_fichero.ReadLine() != null)
        //                {
        //                    cantidad_lineas++;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }

        //            try
        //            {
        //                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM TLB_SERV_" + Label13.Text, conx);
        //                conx.Open();

        //                object[] resultado = new Object[1];

        //                resultado[0] = comm.ExecuteScalar();
        //                int count_fichero = (int)resultado[0];

        //                if (cantidad_lineas == count_fichero)
        //                {
        //                    BtnDescFTP.ClientSideEvents.SetEventHandler("ItemClick", "function(s, e) { alert('Fichero totalmente copiado en la BD'); }");
        //                    Errores.Alert(this, " Fichero copiado satisfactoriamente ");
        //                }
        //                else
        //                {
        //                    Errores.Alert(this, " Fichero copiado incompletamente ");
        //                }
        //            }
        //            catch (SqlException p)
        //            {
        //                throw new Exception(p.Message);
        //            }
        //            finally
        //            {
        //                conx.Close();
        //            }

        //            Errores.Alert(this, " Este proceso puede demorarar unos minutos. Por favor espere ");

        //            lector_fichero.Close();
        //        }
                
        //}
        //catch (Exception m)
        //{

        //    //Errores.Alert(this, " Ha ocurrido un error o el tiempo de ejecucion ha expirado para esta operacion ");
        //}      

        #endregion

        #region Codigo_Original
        //string IdServ = Label29.Text;
        //File.Delete("C:\\Empresas\\" + IdServ + "\\E" + IdServ + ".txt");
        //DateTime fecha = Calendar2.SelectedDate;
        //(BtnDescFTP).Enabled = false;
        ////Servicio.DescargarFicheroFtpCompleted += this.DescargaCompletada;
        ////Servicio.DescargarFicheroFtpAsync(IdServ);

        //Server.ScriptTimeout = 240; // tiempo de 4 min

        //if (Servicio.DescargarFicheroFtp(IdServ, fecha) == false)
        //{
        //    Errores.Alert(this, "El fichero no se encuentra en el FTP");
        //}

        #endregion

    }
    //public void DescargaCompletada(object sender, TeleBancaWS.DescargarFicheroFtpCompletedEventArgs args)
    //{
    //    BtnDescFTP.Enabled = true;
    //}
    ///
    //Nuevo para contratar servicios(21/06/07)******************************
    protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
    {

        ListItem LI = DropDownList5.Items.FindByText(ListBox5.SelectedItem.Text);

        if (ListBox5.SelectedItem.Text != "Multas" && ListBox5.SelectedItem.Text != "Onat" && ListBox5.SelectedItem.Text != "Contravencion" && ListBox5.SelectedItem.Text != "TransPropioCliente")
        {
            if (LI != null)
            {

                Button62.Enabled = true;
                Button66.Enabled = true;
                Button61.Enabled = false;

                if (ListBox5.SelectedItem.Text == "Etecsa")
                {
                    Session["codServicio"] = "01";
                }
                if (ListBox5.SelectedItem.Text == "Electrica")
                {
                    Session["codServicio"] = "02";
                }
                if (ListBox5.SelectedItem.Text == "Aguas")
                {
                    Session["codServicio"] = "05";
                }
                // Gas
                if (ListBox5.SelectedItem.Text == "Gas")
                {
                    Session["codServicio"] = "11";
                }
 

            }
            else
            {
                Button61.Enabled = true;
                Button62.Enabled = false;
                Button66.Enabled = false;

                if (ListBox5.SelectedItem.Text == "Etecsa")
                {
                    Session["codServicio"] = "01";
                }
                if (ListBox5.SelectedItem.Text == "Electrica")
                {
                    Session["codServicio"] = "02";
                }
                if (ListBox5.SelectedItem.Text == "Aguas")
                {
                    Session["codServicio"] = "05";
                }
                // Gas
                if (ListBox5.SelectedItem.Text == "Gas")
                {
                    Session["codServicio"] = "11";
                }
            }
        }
        else
        {
            Button61.Enabled = false;
            Button62.Enabled = false;
            Button66.Enabled = false;
        }

    }
    protected void Button62_Click(object sender, EventArgs e)
    {
        LlenarAsociados2new();
        MVWPago.ActiveViewIndex = 35;
        Label22.Text = "???";
    }
    protected void Button61_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 34;
        Label21.Text = ListBox5.SelectedItem.Text;
    }
    protected void TextBox33_TextChanged(object sender, EventArgs e)
    {
        //TextBox34.Visible = true;
    }
    protected void TextBox34_TextChanged(object sender, EventArgs e)
    {
        //TextBox39.Visible = true;
    }
    protected void TextBox39_TextChanged1(object sender, EventArgs e)
    {
        //TextBox40.Visible = true;
    }
    protected void TextBox40_TextChanged(object sender, EventArgs e)
    {
        //TextBox44.Visible = true;
    }
    protected void Button67_Click(object sender, EventArgs e)
    {
        string nomservicio = ListBox5.SelectedItem.Text;
        string id01 = TextBox33.Text;
        string id02 = TextBox34.Text;
        string id03 = TextBox39.Text;
        string id04 = TextBox40.Text;
        string id05 = TextBox44.Text;
        string Cant = TextBox48.Text;
        int CantInt = System.Convert.ToInt16(Cant);
        string[] AscociadoNew = new string[CantInt];
        //******************************************
        if (CantInt == 1) { AscociadoNew[0] = TextBox33.Text; }
        if (CantInt == 2) { AscociadoNew[0] = TextBox33.Text; AscociadoNew[1] = TextBox34.Text; }
        if (CantInt == 3) { AscociadoNew[0] = TextBox33.Text; AscociadoNew[1] = TextBox34.Text; AscociadoNew[2] = TextBox39.Text; }
        if (CantInt == 4) { AscociadoNew[0] = TextBox33.Text; AscociadoNew[1] = TextBox34.Text; AscociadoNew[2] = TextBox39.Text; AscociadoNew[3] = TextBox40.Text; }
        if (CantInt == 5) { AscociadoNew[0] = TextBox33.Text; AscociadoNew[1] = TextBox34.Text; AscociadoNew[2] = TextBox39.Text; AscociadoNew[3] = TextBox40.Text; AscociadoNew[4] = TextBox44.Text; }

        try
        {
            bool resp = Servicio.ContratarServicio(nomservicio, AscociadoNew);
            if (resp)
            {
                Errores.Alert(this, "..::La Información ha sido guardada Satisfactoriamente::..");
            }
            else
            {
                Errores.Alert(this, "..::La Información no ha sido Actualizada::..");
            }
            object[] servicios = new object[1];
            servicios = Servicio.MostrarServiciosContratados();

            string[] nombres = (string[])servicios[1];
            string[] codServ = (string[])servicios[0];
            DropDownList5.DataSource = nombres;
            DropDownList5.DataBind();
            for (int i = 0; i < codServ.Length; i++)
            {
                DropDownList5.Items[i].Value = codServ[i];
            }

            MVWPago.ActiveViewIndex = 33;
            TextBox48.Text = "";
            TextBox33.Text = "";
            TextBox34.Text = "";
            TextBox39.Text = "";
            TextBox40.Text = "";
            TextBox44.Text = "";
            //TextBox48.Visible = false;
            TextBox33.Visible = false;
            TextBox34.Visible = false;
            TextBox39.Visible = false;
            TextBox40.Visible = false;
            TextBox44.Visible = false;
            TextBox48.ReadOnly = false;
            Button92.Visible = false;
            Button93.Visible = false;
            Button94.Visible = false;
            Button95.Visible = false;
            Button96.Visible = false;
            Label23.Text = "";
        }
        catch (Exception ex)
        {
            SqlConnection conx = new SqlConnection();
            string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
            conx.ConnectionString = cadena_conexion;
            conx.Open();

            SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','Contratar_Servicio',GETDATE(),'Intenta contratar el id_asociado: " + AscociadoNew[0].ToString().Trim()+"',ERROR CONTRATO SERVICIO: " + ex.Message.Trim() + "')", conx);
            int i = cm.ExecuteNonQuery();
        }

        

    }
    protected void Button81_Click(object sender, EventArgs e)
    {

        //TextBox48.Text = "";
        TextBox33.Text = "";
        TextBox34.Text = "";
        TextBox39.Text = "";
        TextBox40.Text = "";
        TextBox44.Text = "";
        //TextBox48.Visible = false;
        TextBox33.Visible = false;
        TextBox34.Visible = false;
        TextBox39.Visible = false;
        TextBox40.Visible = false;
        TextBox44.Visible = false;
        TextBox48.ReadOnly = false;
        Button92.Visible = false;
        Button93.Visible = false;
        Button94.Visible = false;
        Button95.Visible = false;
        Button96.Visible = false;
        Label23.Text = "";
        

        string Cant = TextBox48.Text;
        if (Cant != "")
        {
            int CantInt = System.Convert.ToInt16(Cant);
            if (Cant == "" ^ CantInt <= 0 ^ CantInt > 5)
            {
                TextBox48.Text = "";
                //Button48.Enabled = false;
            }
            else
            {
                if (CantInt == 1) TextBox33.Visible = true; Button92.Visible = true;
                if (CantInt == 2) { TextBox33.Visible = true; TextBox34.Visible = true; Button92.Visible = true; Button93.Visible = true; }
                if (CantInt == 3) { TextBox33.Visible = true; TextBox34.Visible = true; TextBox39.Visible = true; Button92.Visible = true; Button93.Visible = true; Button94.Visible = true; }
                if (CantInt == 4) { TextBox33.Visible = true; TextBox34.Visible = true; TextBox39.Visible = true; TextBox40.Visible = true; Button92.Visible = true; Button93.Visible = true; Button94.Visible = true; Button95.Visible = true; }
                if (CantInt == 5) { TextBox33.Visible = true; TextBox34.Visible = true; TextBox39.Visible = true; TextBox40.Visible = true; TextBox44.Visible = true; Button92.Visible = true; Button93.Visible = true; Button94.Visible = true; Button95.Visible = true; Button96.Visible = true; }
                //Button81.Enabled = false;
                //TextBox48.ReadOnly = true;
            }
        }
    }
    protected void TextBox48_TextChanged(object sender, EventArgs e)
    {
        //Button81.Enabled = true;
    }
    protected void Button66_Click(object sender, EventArgs e)
    {
        string nomservicio = ListBox5.SelectedItem.Text;
        bool resp = Servicio.DescontratarServicio(nomservicio);
        if (resp)
        {
            Errores.Alert(this, "..::La Información ha sido guardada Satisfactoriamente::..");
        }
        else
        {
            Errores.Alert(this, "..::La Información no ha sido Actualizada::..");
        }
        object[] servicios = new object[1];
        servicios = Servicio.MostrarServiciosContratados();

        string[] nombres = (string[])servicios[1];
        string[] codServ = (string[])servicios[0];
        DropDownList5.DataSource = nombres;
        DropDownList5.DataBind();

    }
    protected void LlenarAsociados2new()
    {

        string servicioamod = ListBox5.SelectedItem.Text;
        ListItem LI = DropDownList5.Items.FindByText(servicioamod);
        string codservamod = LI.Value;
        object[] datos = Servicio.MostrarDatosAsociadosServicio(codservamod);
        datosnew = datos;
        bool tieneAsicdos = (bool)datos[0];
        string[] nombresDat = null;
        if (tieneAsicdos)
            nombresDat = (string[])datos[1];
        Session["tieneAsicdos"] = tieneAsicdos;
        if (!tieneAsicdos)
        {

        }
        else
        {

            Panel_ListAsociados.Visible = true;

            LlenarAsociadosnew(nombresDat, datos, 2);
        }


    }
    protected void LlenarAsociadosnew(string[] nombresDat, object[] datos, int pos)
    {
        DataTable tabla = new DataTable();
        tabla.Columns.Add("marcar", typeof(CheckBox));
        foreach (string var in nombresDat)
        {
            tabla.Columns.Add(var, "".GetType());
        }

        for (int i = pos; i < datos.Length; i++)
        {
            string[] var = (string[])datos[i];
            CheckBox aux = new CheckBox();
            aux.Checked = false;
            DataRow row = tabla.NewRow();
            row[0] = aux;
            for (int j = 0; j < var.Length; j++)
            {
                row[j + 1] = var[j];
            }
            tabla.Rows.Add(row);
        }
        DataGrid1.DataSource = tabla;
        DataGrid1.DataBind();

    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string a;
    }
    //protected void Button82_Click(object sender, EventArgs e)
    //{
    //    TextBox49.Visible = true;
    //    Button84.Visible = true;
    //    Button83.Enabled = false;
    //    Button82.Enabled = false;
    //}
    protected void Button84_Click(object sender, EventArgs e)
    {
        //string id = TextBox49.Text;
        //if(id.Length==15 && id.Substring(2,1)== "2")
        //{
        //    Errores.Alert(this, "Este ID de Factura de Teléfono no puede ser contratado pues es en Moneda Libremente Convertible MLC, de momento no se permite el pago de este servicio en esta moneda por TeleBanca");
        //    TextBox49.Text = "";
        //}
        //else
        //{
            LlenarAsociados3new();
            //TextBox49.Text.Remove();
            TextBox49.Text = "";
            Panel6.Visible = false;
        //}




    }
    protected void LlenarAsociados3new()
    {
        int a = datosnew.Length;
        object[] datos1 = new object[a + 1];
        datosnew.CopyTo(datos1, 0);
        string[] prueba = new string[1];
        prueba[0] = TextBox49.Text;
        datos1[a] = prueba;
        bool tieneAsicdos = (bool)datosnew[0];
        string[] nombresDat = null;
        if (tieneAsicdos)
            nombresDat = (string[])datos1[1];
        Session["tieneAsicdos"] = tieneAsicdos;
        if (!tieneAsicdos)
        {

        }
        else
        {

            Panel_ListAsociados.Visible = true;
            datosnew = datos1;
            LlenarAsociadosnew(nombresDat, datos1, 2);
        }
    }
    
    protected void asociadosSevPago_EditCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void DataGrid1_EditCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void DataGrid1_PreRender(object sender, EventArgs e)
    {
        foreach (DataGridItem i in DataGrid1.Items)
        {
            //int i = 0;
            //foreach (DataGridItem row in asociadosSevPago.Items)
            // {
            CheckBox item = (CheckBox)i.Cells[0].Controls[1];
            if (item.Checked)
            {
                //return i;
                Button83.Enabled = true;
                break;
            }
            else { Button83.Enabled = false; }
            //i++;
            // }
            // return -1;
        }

    }
    protected void Button83_Click(object sender, EventArgs e)
    {
        List<int> items = new List<int>();
        foreach (DataGridItem i in DataGrid1.Items)
        {
            CheckBox item = (CheckBox)i.Cells[0].Controls[1];
            if (item.Checked)
            {
                int index = i.ItemIndex;
                items.Add(index + 2);

            }
        }
        object[] datosnewnew = new object[datosnew.Length - items.Count];
        int count = 0;
        for (int i = 0; i < datosnew.Length; i++)
        {
            if (!items.Contains(i))
            {
                datosnewnew[count] = datosnew[i];
                count++;
            }
        }
        datosnew = datosnewnew;
        LlenarAsociados4new();

        Button83.Enabled = false;
    }
    protected void LlenarAsociados4new()
    {
        string[] nombresDat = (string[])datosnew[1];
        Panel_ListAsociados.Visible = true;
        LlenarAsociadosnew(nombresDat, datosnew, 2);
    }
    protected void Button85_Click(object sender, EventArgs e)
    {
        string[] Asociados = new string[datosnew.Length - 2];
        for (int i = 2; i < datosnew.Length; i++)
        {
            string[] asociado1 = (string[])datosnew[i];
            Asociados[i - 2] = asociado1[0].ToString();
        }
        string nomservicio = ListBox5.SelectedItem.Text;

        bool resp = Servicio.ModificarContratoServicio(nomservicio, Asociados);
        if (resp)
        {
            Errores.Alert(this, "..::La Información ha sido guardada satisfactoriamente::..");
        }
        else
        {
            Errores.Alert(this, "..::La Información no ha sido Actualizada::..");
        }
        object[] servicios = new object[1];
        servicios = Servicio.MostrarServiciosContratados();

        string[] nombres = (string[])servicios[1];
        string[] codServ = (string[])servicios[0];
        DropDownList5.DataSource = nombres;
        DropDownList5.DataBind();
        for (int i = 0; i < codServ.Length; i++)
        {
            DropDownList5.Items[i].Value = codServ[i];
        }
        MVWPago.ActiveViewIndex = 33;

    }
    protected void Button77_Click(object sender, EventArgs e)
    {
        // EstadoNavegPago = new EstadoNavegacionPago();
        TextBox48.Text = "";
        TextBox33.Text = "";
        TextBox34.Text = "";
        TextBox39.Text = "";
        TextBox40.Text = "";
        TextBox44.Text = "";
        //TextBox48.Visible = false;
        TextBox33.Visible = false;
        TextBox34.Visible = false;
        TextBox39.Visible = false;
        TextBox40.Visible = false;
        TextBox44.Visible = false;
        TextBox48.ReadOnly = false;
        Button92.Visible = false;
        Button93.Visible = false;
        Button94.Visible = false;
        Button95.Visible = false;
        Button96.Visible = false;
        Label23.Text = "";
        
        MVWPago.ActiveViewIndex = 33;
    }
    protected void Button82_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button86_Click(object sender, EventArgs e)
    {
        TextBox49.Text = "";
        Panel6.Visible = false;
        MVWPago.ActiveViewIndex = 33;
    }
    protected void Button87_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button88_Click(object sender, EventArgs e)
    {
        //object[] aux = new object[2];

        //aux[0] = "ReporteTransacciones";
        if (Calendar6.SelectedDate.CompareTo(Calendar7.SelectedDate) <= 0)
        {

            //    object[] aux3 = Servicio.getLitadoTransacciones(Calendar4.SelectedDate.Date, Calendar5.SelectedDate.Date);

            //    if (aux3.Length == 0)
            //    {
            //        Errores.Alert(this, " No existen transacciones en dicho rango ");
            //        return;
            //    }
            //    aux[1] = aux3;
            //    Application["Datos"] = aux;
            //    Navegador.RedirectToPopUp(this, "Reportes.aspx");
        }
        else
            Errores.Alert(this, "..::Fecha de Inicio mayor que fecha de Fin::..");
    }
    protected void Button90_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button89_Click(object sender, EventArgs e)
    {
        //Reporte Reclamaciones
        if (Calendar8.SelectedDate.CompareTo(Calendar9.SelectedDate) <= 0)
        {
            //Lleno dataset
            //Class1 MyClass = new Class1();
            //MyDataSet DTS = MyClass.IReclamaciones(Calendar8.SelectedDate.Date, Calendar9.SelectedDate.Date);
            //Le paso a la pagina myreport

            Navegador.RedirectToPopUp(this, ("MyNewPaginasReportes\\\\ReporteReclamaciones.aspx?Desde=" + Calendar8.SelectedDate.Date + "&Hasta=" + Calendar9.SelectedDate.Date));
        }
        else Errores.Alert(this, "..::Fecha de Inicio mayor que fecha de Fin::..");
    }
    protected void Button87_Click1(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button88_Click1(object sender, EventArgs e)
    {
        //Reportes Contratos
        string Operador = TextBox57.Text;
        string Servicio = DropDownList10.SelectedValue.ToString();
        if (Calendar6.SelectedDate.CompareTo(Calendar7.SelectedDate) <= 0)
        {
            //Lleno dataset
            // Class1 MyClass = new Class1();
            //MyDataSet DTS = MyClass.IContratodeServicios(Calendar6.SelectedDate.Date, Calendar7.SelectedDate.Date,DropDownList8.SelectedValue.ToString());
            //Le paso a la pagina myreport
            //Navegador.RedirectToPopUp(this, "MyNewPaginasReportes//ReporteContratos.aspx?Desde=" + Calendar6.SelectedDate.Date + "&Hasta=" + Calendar7.SelectedDate.Date + "&por=" + DropDownList8.SelectedValue.ToString());
            //Navegador.RedirectToPopUp(this, ("MyNewPaginasReportes\\\\ReportePrueba.aspx"));
            Navegador.RedirectToPopUp(this, ("MyNewPaginasReportes\\\\ReporteContratos.aspx?Desde=" + Calendar6.SelectedDate.Date + "&Hasta=" + Calendar7.SelectedDate.Date + "&por=" + DropDownList8.SelectedValue.ToString() + "&oper=" + Operador + "&serv=" + Servicio));




        }
        else Errores.Alert(this, "..::Fecha de Inicio mayor que fecha de Fin::..");
    }
    protected void Button91_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label22.Text = cl.NombreCliente(TextBox49.Text, codServ);
    }
    protected void Button92_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label23.Text = cl.NombreCliente(TextBox33.Text, codServ);
    }
    protected void Button93_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label24.Text = cl.NombreCliente(TextBox34.Text, codServ);
    }
    protected void Button94_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label34.Text = cl.NombreCliente(TextBox39.Text, codServ);
    }
    protected void Button95_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label30.Text = cl.NombreCliente(TextBox40.Text, codServ);
    }
    protected void Button96_Click(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        Class1 cl = new Class1();
        Label35.Text = cl.NombreCliente(TextBox44.Text, codServ);
    }
    protected void Button97_Click(object sender, EventArgs e)
    {
        //**********************Consulta saldos integrada
        try
        {
            Label36.Text = "";
            GridView2.Visible = false;
            DataSet DT = new DataSet();
            string tarjeta = TextBox50.Text;
            string estado = Servicio.BuscarTarjeta(tarjeta);
            if (estado == "A")
            {
                DT = Servicio.ConsultarSaldoIntegrada(tarjeta);
                Label36.Text = Servicio.DarNombrePro();
                GridView2.Visible = true;
                GridView2.DataSource = DT.Tables[0];
                GridView2.DataBind();
            }
            else
            {
                Errores.Alert(this, "..::La Tarjeta no esta activa o no existe en Telebanca::..");  // Es un mensaje
                return;
            }
            TextBox50.Text = "";

        }
        catch (Exception ex)
        {
            //throw new Exception("ErrorCBD" + ex.Message);

            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "Button97(Buscar): ConsultaSaldoIntegrada \n";
            //    string nombre_proyecto = "(Telebanca): ";
            //    string date = DateTime.Now.ToString();
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + ex.Message);
            //    writer.WriteLine(separador + metodo_error + date);
            //}

            Errores.Alert(this, "Error" + ex.Message);
            return;
        }
    }

    //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08*****************
    protected void Button98_Click(object sender, EventArgs e)
    {
        Button99.Enabled = false;
        DateTime Fecha = Calendar10.SelectedDate.Date;
        if (Fecha.AddDays(60) < System.DateTime.Now.Date)
        {
            Errores.Alert(this, "..::La multa no puede ser pagada porque sobrepasa el plazo de 60 días::..");
            Button99.Enabled = false;
        }
        else
        {
            string[] Datos = new string[2];
            string articulo = DropDownList13.SelectedValue;
            string inciso = DropDownList14.SelectedValue;
            string digito = DropDownList15.SelectedValue;
            string Folio = TextBox55.Text;
            string peligrosidad = DropDownList16.SelectedValue;
            Datos = Servicio.ObtenerMontoMulta(articulo, inciso, peligrosidad);
            if (Datos[0] == "False")
            {
                Errores.Alert(this, Datos[1].ToString());
                Button99.Enabled = false;
            }
            else
            {

                //RegularExpressionValidator33.Visible = false;
                //RegularExpressionValidator34.Visible = false;
                //RegularExpressionValidator35.Visible = false;
                //RegularExpressionValidator36.Visible = false;
                //RegularExpressionValidator37.Visible = false;
                //RequiredFieldValidator37.Visible = false;
                //RequiredFieldValidator38.Visible = false;
                //RegularExpressionValidator33.Validate();
                //RegularExpressionValidator34.Validate();
                RegularExpressionValidator35.Validate();
                RegularExpressionValidator36.Validate();
                //RegularExpressionValidator37.Validate();
                RequiredFieldValidator37.Validate();
                RequiredFieldValidator38.Validate();
                bool valido =  RegularExpressionValidator35.IsValid && RegularExpressionValidator36.IsValid && RequiredFieldValidator37.IsValid && RequiredFieldValidator38.IsValid;
                if (!valido)
                {
                    Errores.Alert(this, "..::Entrada de datos no válida::.. ");
                }
                else
                {
                    if (Fecha.AddDays(30).Date >= System.DateTime.Now.Date)
                    {
                        Label37.Text = "$ " + Datos[0].ToString();
                        Label39.Text = Datos[0].ToString();
                    }
                    else
                    {
                        decimal valor = Convert.ToDecimal(Datos[0].ToString()) * 2;
                        Label37.Text = "$ " + valor.ToString();
                        Label39.Text = valor.ToString();
                    }
                    Button99.Enabled = true;
                    //deshabilitar los textbox
                    DropDownList13.Enabled = false;
                    DropDownList14.Enabled = false;
                    DropDownList15.Enabled = false;
                    DropDownList16.Enabled = false;
                    TextBox55.Enabled = false;
                    Calendar10.Enabled = false;
                }
            }
        }
    }
    protected void View39_Activate(object sender, EventArgs e)
    {
        Calendar10.SelectedDate = DateTime.Now;
        DropDownList13.Enabled = true;
        DropDownList14.Enabled = true;
        DropDownList15.Enabled = true;
        TextBox55.Enabled = true;
        Calendar10.Enabled = false;
        TextBox55.Focus();
    }
    protected void Button100_Click(object sender, EventArgs e)
    {
        if ((string)Session["codServicio"] == "04")
        {
            MVWPago.ActiveViewIndex = 39;
        }
        if ((string)Session["codServicio"] == "06")
        {
            MVWPago.ActiveViewIndex = 50;
        }

    }

    #region <Raul: (anterior a lo del USD) Boton Efectuar Pago Multas>
    //protected void Button99_Click(object sender, EventArgs e)
    //{
    //    //retorno : nombre, importe, informativo
    //    string[] dat = new string[5];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false;

    //    try
    //    {

    //        dat[0] = "000000000";
    //        dat[1] = Calendar10.SelectedDate.Date.ToString("dd/MM/yy");
    //        dat[02] = CI_Pago.Value;
    //        dat[03] = "02" + Label39.Text.Trim();
    //        dat[04] = "12T    " + "FEC_IMP:" + Calendar10.SelectedDate.Date.ToString("dd/MM/yy") + " DIG:" + DropDownList15.SelectedValue + " FOLIO:" + "00" + TextBox55.Text + " ARTINC:" + DropDownList13.SelectedValue + DropDownList14.SelectedValue + " T:2";

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        string tipo_mon = "";
    //        if (moneda == false)
    //        {
    //            tipo_mon = "CUP";
    //        }

    //        if (moneda == true)
    //        {
    //            tipo_mon = "CUC";
    //        }

    //        if (cantidad == 1)
    //        {
    //            if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;
    //            }
    //            else
    //            {
    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);
    //            }
    //        }
    //        else if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;

    //        }





    //        Button13.Enabled = true;
    //        Calendar10.SelectedDate = DateTime.Now;
    //        TextBox55.Text = "";
    //        DropDownList13.ClearSelection();
    //        DropDownList14.ClearSelection();
    //        DropDownList15.ClearSelection();
    //        DropDownList16.ClearSelection();

    //        Label37.Text = "";
    //        Label39.Text = "";
    //        Label134.Text = "Fecha";
    //        Label134.ForeColor = System.Drawing.Color.Black;
    //        Button99.Enabled = false;
    //        CI_Pago.Value = "";

    //        //RegularExpressionValidator33.Visible = false;
    //        //RegularExpressionValidator34.Visible = false;
    //        //RegularExpressionValidator35.Visible = false;
    //        //RegularExpressionValidator36.Visible = false;
    //        //RegularExpressionValidator37.Visible = false;
    //        //Habilitar textbox
    //        DropDownList13.Enabled = true;
    //        DropDownList14.Enabled = true;
    //        DropDownList15.Enabled = true;
    //        TextBox55.Enabled = true;
    //        Calendar10.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        ///*escribir en el log*/

    //        //string path = @"C:\Logs_Telebanca\log_error.txt";

    //        //using (TextWriter writer = File.AppendText(path))
    //        //{
    //        //    string separador = " : ";
    //        //    string metodo_error = "Button99(Si): DatosMultas \n";
    //        //    string nombre_proyecto = "(Telebanca): ";
    //        //    string date = DateTime.Now.ToString();
    //        //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + ex.Message);
    //        //    writer.WriteLine(separador + metodo_error + date);
    //        //}

    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Button13.Enabled = true;

    //    }
    //}
    #endregion
    protected void Button99_Click(object sender, EventArgs e)
    {
        //retorno : nombre, importe, informativo
        string[] dat = new string[5];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0;

        try
        {

            dat[0] = "000000000";
            dat[1] = Calendar10.SelectedDate.Date.ToString("dd/MM/yy");
            dat[02] = CI_Pago.Value;
            dat[03] = "02" + Label39.Text.Trim();
            dat[04] = "12T    " + "FEC_IMP:" + Calendar10.SelectedDate.Date.ToString("dd/MM/yy") + " DIG:" + DropDownList15.SelectedValue + " FOLIO:" + "00" + TextBox55.Text + " ARTINC:" + DropDownList13.SelectedValue + DropDownList14.SelectedValue + " T:2";

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            string tipo_mon = "";
            if (moneda == 0)
            {
                tipo_mon = "CUP";
            }


            if (moneda == 1)
            {
                tipo_mon = "CUC";
            }
            
            if (moneda == 2)
            {
                tipo_mon = "USD";
            }

            if (cantidad == 1)
            {
                if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")) || ((tipo_mon == "CUP") && (mon_cue == "USD")) || ((tipo_mon == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;
                }
                else
                {
                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);
                }
            }
            else if (cantidad == 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }
            else if (cantidad == 3)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }
            

            
            
            Button13.Enabled = true;
            Calendar10.SelectedDate = DateTime.Now;
            TextBox55.Text = "";
            DropDownList13.ClearSelection();
            DropDownList14.ClearSelection();
            DropDownList15.ClearSelection();
            DropDownList16.ClearSelection();
            
            Label37.Text = "";
            Label39.Text = "";
            Label134.Text = "Fecha";
            Label134.ForeColor = System.Drawing.Color.Black;
            Button99.Enabled = false;
            CI_Pago.Value = "";
            
            //RegularExpressionValidator33.Visible = false;
            //RegularExpressionValidator34.Visible = false;
            //RegularExpressionValidator35.Visible = false;
            //RegularExpressionValidator36.Visible = false;
            //RegularExpressionValidator37.Visible = false;
            //Habilitar textbox
            DropDownList13.Enabled = true;
            DropDownList14.Enabled = true;
            DropDownList15.Enabled = true;
            TextBox55.Enabled = true;
            Calendar10.Enabled = true;
        }
        catch (Exception ex)
        {
            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "Button99(Si): DatosMultas \n";
            //    string nombre_proyecto = "(Telebanca): ";
            //    string date = DateTime.Now.ToString();
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + ex.Message);
            //    writer.WriteLine(separador + metodo_error + date);
            //}

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Button13.Enabled = true;

        }
    }
    protected void Button101_Click(object sender, EventArgs e)
    {
        //MVWPago.ActiveViewIndex = 5;
        Calendar10.SelectedDate = DateTime.Now;
        DropDownList13.ClearSelection();
        DropDownList14.ClearSelection();
        DropDownList15.ClearSelection();
        DropDownList16.ClearSelection();
        RadioButtonList16.ClearSelection();
        DropDownList14.Enabled = true;
        DropDownList15.Enabled = true;
        TextBox55.Text = "";
        DropDownList16.Enabled = true;
        Label163.Text = "---";
        Label37.Text = "";
        Label39.Text = "";
        CI_Pago.Value = "";
        Button99.Enabled = false;
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
        Button13.Enabled = true;
        Label134.Text = "Fecha";
        Label134.ForeColor = System.Drawing.Color.Black;
    }

    public void ConsultaIntegrada()
    {
        try
        {
            Label36.Text = "";
            GridView2.Visible = false;
            DataSet DT = new DataSet();
            string tarjeta = TextBox50.Text;
            string estado = Servicio.BuscarTarjeta(tarjeta);
            if (estado == "A")
            {
                DT = Servicio.ConsultarSaldoIntegrada(tarjeta);
                Label36.Text = Servicio.DarNombrePro();
                GridView2.Visible = true;
                GridView2.DataSource = DT.Tables[0];
                GridView2.DataBind();
            }
            else
            {
                Errores.Alert(this, "..::La Tarjeta no está activa o no existe en Telebanca::..");  // Es un mensaje
                return;
            }
            TextBox50.Text = "";

        }
        catch (Exception ex)
        {
            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "ConsultaSaldoIntegrada:  \n";
            //    string nombre_proyecto = "(Telebanca): ";
            //    string date = DateTime.Now.ToString();
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + ex.Message);
            //    writer.WriteLine(separador + metodo_error + date);
            //}

            //throw new Exception("ErrorCBD" + ex.Message);
            Errores.Alert(this, "Error" + ex.Message);
            return;
        }
    }

    //protected void Button102_Click(object sender, EventArgs e)
    //{
    //    #region validacion
    //    RegularExpressionValidator2.Visible = true;
    //    RegularExpressionValidator3.Visible = true;
    //    RegularExpressionValidator4.Visible = true;
    //    RequiredFieldValidator20.Visible = true;
    //    RequiredFieldValidator21.Visible = true;
    //    RequiredFieldValidator22.Visible = true;

    //    RequiredFieldValidator20.Validate();
    //    RequiredFieldValidator21.Validate();
    //    RequiredFieldValidator22.Validate();
    //    RegularExpressionValidator2.Validate();
    //    RegularExpressionValidator3.Validate();
    //    RegularExpressionValidator4.Validate();
    //    #endregion

    //    bool valido = RequiredFieldValidator20.IsValid && RequiredFieldValidator21.IsValid && RequiredFieldValidator22.IsValid && RegularExpressionValidator2.IsValid && RegularExpressionValidator3.IsValid && RegularExpressionValidator4.IsValid;
    //    if (!valido)
    //        Errores.Alert(this, " Entrada de datos no válida ");
    //    else
    //        try
    //        {


    //            string aux = TextBox9.Value + TextBox8.Value + TextBox10.Value;
    //            string estado = Servicio.BuscarTarjeta(aux);
    //            if (estado.StartsWith("operadora|"))
    //            {
    //                // estado = estado.Replace("operadora|", "");
    //                Button2_Click(null, null);
    //                Errores.Alert(this, " Usted no puede pagarse a sí mismo");  // Es un mensaje
    //            }
    //            if (estado == "A")
    //            {
    //                EstadoNavegPago.AutenticadoTarjeta = true;
    //                Label41.Text = Servicio.DarNombrePro();
    //                int[] ping = Servicio.PreguntarPin();
    //                string[] alf ={ "primero", "segundo", "tercero", "cuarto" };
    //                Label42.Text = alf[ping[0]];
    //                Label43.Text = alf[ping[1]];
    //                TextBox41.Focus();
    //                EstadoNavegPago.UltimaPagina = 2;
    //                MVWPago.ActiveViewIndex = 2;
    //            }
    //            if (estado == "D")
    //            {
    //                Button2_Click(null, null);
    //                Errores.Alert(this, " La tarjeta esta desabilitada ");  // Es un mensaje
    //            }
    //            //  
    //            if (estado == "P")
    //            {
    //                Button2_Click(null, null);
    //                Errores.Alert(this, " La tarjeta esta pedida ");  // Es un mensaje
    //            }
    //            if (estado == "C")
    //            {
    //                Button2_Click(null, null);
    //                Errores.Alert(this, " La tarjeta esta creada ");  // Es un mensaje
    //            }
    //            if (estado == "")
    //            {//cuando el numero no esta
    //                EstadoNavegPago.CantNumTarjIM++;
    //                if (EstadoNavegPago.CantNumTarjIM >= EstadoNavegPago.CantIntentos)
    //                {
    //                    Button2_Click(null, null);
    //                    Errores.Alert(this, " Ha realizado el numero máximo de intentos ");
    //                }
    //                else
    //                {
    //                    Errores.Alert(this, " El número de la tarjeta no se encuentra registrada en la Banca Telefónica ");
    //                }
    //                TextBox9.Value = "";
    //                TextBox8.Value = "";
    //                TextBox10.Value = "";
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            Button2_Click(null, null);
    //            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        }
    //}
    //protected void Text4_ServerChange(object sender, EventArgs e)
    //{

    //}
    protected void MVWPago_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox50_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox41_ServerChange(object sender, EventArgs e)
    {

    }
    protected void TextBox51_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button102_Click(object sender, EventArgs e)
    {
        //Reportes Tarj Calientes
        if (Calendar11.SelectedDate.CompareTo(Calendar12.SelectedDate) <= 0)
        {
            string oper = TextBox56.Text;
            Navegador.RedirectToPopUp(this, ("MyNewPaginasReportes\\\\ReporteTarjetasCalientes.aspx?Desde=" + Calendar11.SelectedDate.Date + "&Hasta=" + Calendar12.SelectedDate.Date + "&operador=" + oper + "&descripcion=" + DropDownList9.SelectedValue.ToString()));
        }
    }

    protected void View36_Activate(object sender, EventArgs e)
    {        


        Calendar6.SelectedDate = DateTime.Now;
        Calendar7.SelectedDate = DateTime.Now;
        DataSet servicios = new DataSet();
        DropDownList10.Items.Clear();

        SqlConnection conx = new SqlConnection();

        try
        {
            string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
            conx.ConnectionString = cadena_conexion;
            conx.Open();

            SqlCommand cm = new SqlCommand("SELECT serv_nom FROM [Servicios Activos Contratados Telebanca]", conx);
            SqlDataAdapter adaptador = new SqlDataAdapter(cm);
            adaptador.Fill(servicios);
            if (servicios != null)
            {
                DropDownList10.Items.Add("Todos");
                foreach (DataRow item in servicios.Tables[0].Rows)
                {
                    DropDownList10.Items.Add(item[0].ToString().Trim());
                }
            }

            //DropDownList10.DataSource = servicios;
            //DropDownList10.DataBind();
        }
        catch (Exception ex)
        {            
            //ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Error: '" + ex.Message + ");", true);
            throw new Exception(ex.Message);
        }

        conx.Close();
    }
    protected void View37_Activate(object sender, EventArgs e)
    {
        Calendar8.SelectedDate = DateTime.Now;
        Calendar9.SelectedDate = DateTime.Now;
    }
    protected void View42_Activate(object sender, EventArgs e)
    {
        Calendar11.SelectedDate = DateTime.Now;
        Calendar12.SelectedDate = DateTime.Now;
    }
    protected void Button104_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox58.Text.Substring(0, 2) == "95")
            {
                string tarjeta = TextBox58.Text;
                Class1 MyClass = new Class1();
                MyDataSet DTS = MyClass.DatosTarjeta(tarjeta);
                DTS.DatosTarjetas.Columns[0].ColumnName = "Tarjeta";
                DTS.DatosTarjetas.Columns[3].ColumnName = "Apellidos";
                DTS.DatosTarjetas.Columns[5].ColumnName = "Sucursal";
                DTS.DatosTarjetas.Columns[10].ColumnName = "Lote";
                DTS.DatosTarjetas.Columns[12].ColumnName = "DNI";
                DTS.DatosTarjetas.Columns[11].ColumnName = "No.Documento";
                DTS.DatosTarjetas.Columns.RemoveAt(14);
                DTS.DatosTarjetas.Columns.RemoveAt(13);
                DTS.DatosTarjetas.Columns.RemoveAt(9);
                DTS.DatosTarjetas.Columns.RemoveAt(7);
                DTS.DatosTarjetas.Columns.RemoveAt(6);
                DTS.DatosTarjetas.Columns.RemoveAt(4);
                DTS.DatosTarjetas.Columns.RemoveAt(1);


                GridView3.Visible = true;
                GridView3.DataSource = DTS.DatosTarjetas;
                GridView3.DataBind();
                //Response.Redirect("MyNewPaginasReportes\\ReporteDatosTarjeta.aspx?tarjeta=" + tarjeta); 
            }

            //if (NoTarjeta.Substring(0, 2) == "06")
            //{
            //    GridView3.Visible = true;
            //    GridView3.DataSource = Servicio.BuscarDatosTarjeta(NoTarjeta);
            //    GridView3.DataBind(); 
            //}
        }
        catch (Exception Ex)
        {
            Errores.Alert(this, "Ha ocurrido un error al comprobar los Datos de la Tarjeta " + Ex.ToString());
        }

    }
    protected void View43_Activate(object sender, EventArgs e)
    {
        TextBox58.Text = "";
        GridView3.Visible = false;
    }
    protected void View44_Activate(object sender, EventArgs e)
    {
        Calendar17.SelectedDate = DateTime.Now;
        Calendar19.SelectedDate = DateTime.Now;
        Label44.Text = "Ejemplo: " + DateTime.Today.Year;
    }
    protected void Button106_Click(object sender, EventArgs e)
    {
        Calendar17.SelectedDate = DateTime.Today;
        Calendar19.SelectedDate = DateTime.Today;
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button105_Click(object sender, EventArgs e)
    {
        DateTime fecha = Calendar13.SelectedDate;
        Navegador.RedirectToPopUp(this, ("MyNewPaginasReportes\\\\ParteDiario.aspx?fecha=" + fecha));
    }
    protected void Button109_Click(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 0;
    }
    protected void Button107_Click(object sender, EventArgs e)
    {
        string Traza = TextBox59.Text;
        DateTime Fecha = Calendar14.SelectedDate;
        Class1 MyClass = new Class1();
        DataSet DTS = MyClass.GetOperacionReversar(Traza, Fecha);
        if (DTS.Tables[0].Rows.Count == 0)
        {
            Errores.Alert(this, "..::!No he encontrado ninguna operación con los datos proporcionados!::..");  // Es un mensaje
            GridView4.Visible = false;
            Button108.Visible = false;
        }
        else
        {
            GridView4.Visible = true;
            GridView4.DataSource = DTS.Tables[0];
            GridView4.DataBind();
            Button108.Visible = true;
        }

        GridView4.Visible = true;
        GridView4.DataSource = DTS.Tables[0];
        GridView4.DataBind();
    }
    protected void View45_Activate(object sender, EventArgs e)
    {
        Calendar14.SelectedDate = DateTime.Now;
        GridView4.Visible = false;
        Button108.Visible = false;
        TextBox59.Text = "";
    }
    protected void Button108_Click(object sender, EventArgs e)
    {
        ReversarOperacion();
       // new Errores(this).Confirmar("¿Realmente desea reversar la Operación?", "ReversarOperacion"); // line que estaba anteriormente y que hacia que diera error
        //string Id_Transaccion = GridView4.Rows[0].Cells[0].Text.ToString();
        //try
        //{
        //    Class1 MyClass = new Class1();
        //    //MyClass.ReversarOperacion(Id_Transaccion,Operador);
        //    Servicio.ReversarOperacion(Id_Transaccion);
        //    Errores.Alert(this, "La operacion ha sido reversada con exito");
        //    TextBox59.Text = "";
        //    Calendar14.SelectedDate = DateTime.Now;
        //    GridView4.Visible = false;
        //    Button108.Visible = false;
        //}
        //catch (Exception Ex)
        //{
        //    Errores.Alert(this, "Ha ocurrido un error con la base de datos "+Ex.ToString());
        //}
    }
    public void ReversarOperacion()
    {
        string Id_Transaccion = GridView4.Rows[0].Cells[0].Text.ToString();
        try
        {
            Class1 MyClass = new Class1();
            //MyClass.ReversarOperacion(Id_Transaccion,Operador);
            Servicio.ReversarOperacion(Id_Transaccion);
            Errores.Alert(this, "Operación Reversada");
            TextBox59.Text = "";
            Calendar14.SelectedDate = DateTime.Now;
            GridView4.Visible = false;
            Button108.Visible = false;
        }
        catch (Exception Ex)
        {
            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "ReversarOperacion: \n";
            //    string nombre_proyecto = "(Telebanca): ";
            //    string date = DateTime.Now.ToString();
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + Ex.Message);
            //    writer.WriteLine(separador + metodo_error + date);
            //}

            Errores.Alert(this, "Ha ocurrido un error con la Base de Datos " + Ex.ToString());
        }
    }
    protected void Button110_Click(object sender, EventArgs e)
    {
       
        if (Calendar17.SelectedDate.CompareTo(Calendar19.SelectedDate) <= 0)
        {
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteOperacionesReversadas.aspx?Desde=" + Calendar17.SelectedDate.Date + "&Hasta=" + Calendar19.SelectedDate.Date);
        }
        //para probar metodo de tablaresumen anual
        //Class1 MyClass = new Class1();
        //MyDataSet DTS = MyClass.TablaResumenAnual();

        //para probar metodo de tablaresumen anual
        //Class1 MyClass = new Class1();
        //MyDataSet DTS = MyClass.TablaResumenMensual("2007");

    }
    protected void Button112_Click(object sender, EventArgs e)
    {
        //para probar metodo de tablaresumen anual
        //Class1 MyClass = new Class1();
        //MyDataSet DTS = MyClass.TablaResumenAnual();
        Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\TablaResumen.aspx");
        
    }
    protected void Button114_Click(object sender, EventArgs e)
    {
        if (TextBox60.Text == "")
        {
            Errores.Alert(this, "Debe Insertar un año");
        }
        else
        {
            if (TextBox60.Text.Length != 4)
            {
                Errores.Alert(this, "Inserte el año correctamente");
            }
            else
            {
                string anno = TextBox60.Text;
                Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\TablaResumen.aspx?anno=" + anno);
            }
        }
    }
    protected void View49_Activate(object sender, EventArgs e)
    {
        Calendar15.SelectedDate = DateTime.Now;
        Calendar16.SelectedDate = DateTime.Now;
    }
    protected void Button116_Click(object sender, EventArgs e)
    {
        if (Calendar15.SelectedDate.CompareTo(Calendar16.SelectedDate) <= 0)
        {
            string oper = TextBox61.Text;
            string TipoOper = "Saldos";
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteOperaciones.aspx?Desde=" + Calendar15.SelectedDate.Date + "&Hasta=" + Calendar16.SelectedDate.Date + "&operador=" + oper + "&tipooper=" + TipoOper);
        }
    }

    protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void View28_Activate(object sender, EventArgs e)
    {
        Button42.Visible = false;
        DataGrid2.Visible = false;
        TextBox26.Text = "";
        TextBox63.Text = "";
        Label45.Visible = false;
        // DropDownList7.ClearSelection();
    }


    bool dia_feriado_habil(DateTime[] dia_feriado, DateTime fecha)
    {
        for (int i=0;i<dia_feriado.Length;i++)
        {
            TimeSpan delta = fecha.Subtract(dia_feriado[i]);

            if (delta.Days==0)
                return true;
        }

        return false;
    }


    //Implementación del Servicio de Multas por Contravención
    protected void Button119_Click(object sender, EventArgs e)
    {
        string modelo_talon = DropDownList12.Text;
        string decreto_o_ley = TextBox64.Text;
        string no_multa = TextBox68.Text;
        string importe = TextBox71.Text + "." + TextBox65.Text;
        string moneda = "???";
        string doc_ident = TextBox69.Text.Substring(0, 2);
        int anno_actual = DateTime.Now.Year;
        int anno_nacimiento = anno_actual - 16;
        string digitos_nacimiento = anno_nacimiento.ToString().Substring(2, 2);
        int digitos_nacimiento1 = Convert.ToInt32(digitos_nacimiento);


        DateTime fecha_imposicion = Calendar18.SelectedDate.Date;
        DateTime fecha_duplicacion = fecha_imposicion.Date.AddDays(30);
        DateTime fecha_actual = DateTime.Today;
        double importe1 = Convert.ToDouble(importe);
   

        Label47.Text = "";
        Button120.Enabled = false;
        Button123.Enabled = false; 


        if (decreto_o_ley != "175")

        {
            Image18.Visible = false;
            Image16.Visible = true;
        }
        
        
        if (decreto_o_ley == "175") //Validar los 3 días hábiles para este Decreto
        {
            fecha_duplicacion = DateTime.MaxValue;
            int contador = 0;
           
            DateTime[] dia_feriado= new DateTime[9]; // Aquí se declara el arreglo para la cantidad de dias feriados en el año (Actualmente son 9 días)

            dia_feriado[0] = new DateTime(DateTime.Today.Year, 1, 1);
            dia_feriado[1] = new DateTime(DateTime.Today.Year, 1, 2);
            dia_feriado[2] = new DateTime(DateTime.Today.Year, 5, 1);
            dia_feriado[3] = new DateTime(DateTime.Today.Year, 7, 25);
            dia_feriado[4] = new DateTime(DateTime.Today.Year, 7, 26);
            dia_feriado[5] = new DateTime(DateTime.Today.Year, 7, 27);
            dia_feriado[6] = new DateTime(DateTime.Today.Year, 10, 10);
            dia_feriado[7] = new DateTime(DateTime.Today.Year, 12, 25);
            dia_feriado[8] = new DateTime(DateTime.Today.Year, 12, 31);


            ArrayList dias_habiles = new ArrayList(); //Para guardar cuáles son los días hábiles para esta fecha de imposición

            for (int i = 1; fecha_imposicion.AddDays(i) > fecha_imposicion; i++)
            {
                if (fecha_imposicion.AddDays(i).DayOfWeek == DayOfWeek.Saturday) continue;
                if (fecha_imposicion.AddDays(i).DayOfWeek == DayOfWeek.Sunday) continue;
                if (dia_feriado_habil(dia_feriado, fecha_imposicion.AddDays(i))) continue;

                dias_habiles.Add(fecha_imposicion.AddDays(i));
                contador++;
                if (contador == 4)
                    break;
               
            }

            if (Convert.ToDateTime(dias_habiles[3]) <= DateTime.Today)
            {

                string mensaje = "Operación DENEGADA, este Cliente tuvo el" + Convert.ToDateTime(dias_habiles[2]) + "como último día hábil para el pago de esta Multa";
                Image16.Visible = true;
                Image18.Visible = true;
                Image18.ToolTip = Label47.Text = "Operación DENEGADA, para el Decreto y/o Ley No. 175 este Cliente tuvo el " + Convert.ToDateTime(dias_habiles[2]).ToString("dd/MM/yy") + " como último día hábil para el pago de esta Multa";
                Button122.Enabled = false;
            }

            else
            
                Image18.Visible = false;
            
           

        }

        if (decreto_o_ley == "272" || decreto_o_ley == "62")
        {

            fecha_duplicacion = DateTime.MaxValue;
            
        }
        
    
        

        //Si el número de Multa es menor que 7 dígitos

        if (no_multa.Length < 7)
        {
            Label47.Text = "El No. de Multa es incorrecto, tiene como minímo 7 dígitos y usted ha tecleado menos que esa cantidad";
            Image6.Visible = true;
        }
        else
            Image6.Visible = false;

        if (no_multa.Length == 9 || no_multa.Length == 10 || no_multa.Length == 10 || no_multa.Length == 11 || no_multa.Length == 12)
        {
            Label47.Text = "El No. de Multa es incorrecto, " + no_multa.Length + " dígitos no aceptados";
            Image6.Visible = true;
        }
        else
            Image6.Visible = false;


        //Si el número de Multa es con el Formato Viejo

        if (no_multa.Length == 8)//Para las que son en CUP
        {
            Label46.Text = moneda = "CUP";
        }

        if (no_multa.Length == 7)//Para las que son en CUC
        {




            int delimitador_folio = Convert.ToInt32(no_multa.Substring(2, 5));


            if (no_multa.Substring(0, 2) == "G0")
            {
                if ((32101 <= delimitador_folio) && (delimitador_folio <= 32250))
                {
                    moneda = "CUC";
                }
               
            }
            

            if (no_multa.Substring(0, 2) == "g0")
            {
                if ((32101 <= delimitador_folio) && (delimitador_folio <= 32250))
                {
                    moneda = "CUC";
                }
                
            }
            

            if (no_multa.Substring(0, 2) == "M2")
            {
                if ((46001 <= delimitador_folio) && (delimitador_folio <= 46075))
                {
                    moneda = "CUC";
                }
                

                if ((46201 <= delimitador_folio) && (delimitador_folio <= 46225))
                {
                    moneda = "CUC";
                }
                

                if ((46076 <= delimitador_folio) && (delimitador_folio <= 46200))
                {
                    moneda = "CUC";
                }
               
            }
            

            if (no_multa.Substring(0, 2) == "m2")
            {
                if ((46001 <= delimitador_folio) && (delimitador_folio <= 46075))
                {
                    moneda = "CUC";
                }
                

                if ((46201 <= delimitador_folio) && (delimitador_folio <= 46225))
                {
                    moneda = "CUC";
                }
                

                if ((46076 <= delimitador_folio) && (delimitador_folio <= 46200))
                {
                    moneda = "CUC";
                }

                
            }


            Label46.Text = moneda;

        }

        //Validación para saber si el documento de identificación del infractor es un menor de edad (Válido hasta el 2016 pues puede ser que haya exista alguien que haya nacido en el 1900 o 2000)

        if (doc_ident.Length == 11)
        {
            int doc_ident1 = Convert.ToInt32(doc_ident);

            if (doc_ident1 > digitos_nacimiento1)
            {
                Image7.Visible = true;
                Image2.Visible = false;
                Image7.ToolTip = Label47.Text = "Este Documento de Identificación pertenece a un menor de edad, no puede efectuar el Pago.";
            }

            if (doc_ident1 < digitos_nacimiento1)
            {
                Image2.Visible = true;
                Image7.Visible = false;
                Label48.Text = "";
                Label49.Text = "";
                Label50.Text = "";
                Label51.Visible = false;
                Label52.Visible = false;
                Label61.Text = "";
                Label62.Visible = false;
                Label63.Text = "";
                Label65.Text = "";


            }
        }

        //Si el número de Multa es con el Formato Nuevo
        if (no_multa.Length == 13)
        {
            string folio_original = TextBox68.Text;

            int posicion2 = Convert.ToInt32(folio_original.Substring(11, 1)) * 3;
            int posicion3 = Convert.ToInt32(folio_original.Substring(10, 1)) * 1;
            int posicion4 = Convert.ToInt32(folio_original.Substring(9, 1)) * 3;
            int posicion5 = Convert.ToInt32(folio_original.Substring(8, 1)) * 1;
            int posicion6 = Convert.ToInt32(folio_original.Substring(7, 1)) * 3;
            int posicion7 = Convert.ToInt32(folio_original.Substring(6, 1)) * 1;
            int posicion8 = Convert.ToInt32(folio_original.Substring(5, 1)) * 3;
            int posicion9 = Convert.ToInt32(folio_original.Substring(4, 1)) * 1;
            int posicion10 = Convert.ToInt32(folio_original.Substring(3, 1)) * 3;
            int posicion11 = Convert.ToInt32(folio_original.Substring(2, 1)) * 1;
            int posicion12 = Convert.ToInt32(folio_original.Substring(1, 1)) * 3;
            int posicion13 = Convert.ToInt32(folio_original.Substring(0, 1)) * 1;

            int suma = (posicion2 + posicion3 + posicion4 + posicion5 + posicion6 + posicion7 + posicion8 + posicion9 + posicion10 + posicion11 + posicion12 + posicion13);
            string suma1 = Convert.ToString(suma);
            string decena = "";

            if (suma1.Length == 3)
            {
                decena = (Convert.ToString(suma).Substring(0, 2));
            }
            else 
            
                decena = (Convert.ToString(suma).Substring(0, 1));
            
            
            int decena1 = Convert.ToInt32(decena) + 1;
            string decena2 = Convert.ToString(decena1) + "0";
            int resta = Convert.ToInt32(decena2) - suma;

            if (Convert.ToInt32(folio_original.Substring(12, 1)) != resta)
            {
                Label47.Text = "El número de folio no es válido";
                Button122.Enabled = false;
                Button120.Enabled = false;
                Image6.Visible = true;
                Image1.Visible = false;
                moneda = "??";
                Image10.Visible = true;
                Image5.Visible = false;

            }

            if (Convert.ToInt32(folio_original.Substring(12, 1)) == resta)
            {
                Button122.Enabled = true;
                Button120.Enabled = true;
                Image6.Visible = false;
                Image1.Visible = true;

                if (Convert.ToInt32(folio_original.Substring(4, 1)) == 1)
                {
                    moneda = "CUP";
                }


                if (Convert.ToInt32(folio_original.Substring(4, 1)) == 2)
                {
                    moneda = "CUC";
                }



                Label46.Text = moneda;
            }   
                


            
        }


        if (moneda == "CUC")
        {
            Image10.Visible = true;
            Image5.Visible = false;
            Image10.ToolTip = Label47.Text = "Por el momento los Clientes que se le hayan impuesto Multas en Pesos Convertibles (CUC) no pueden realizar el pago por Banca Telefónica";
            Button122.Enabled = false;
            Button120.Enabled = false;
        }

        if (moneda == "CUP")
        {

            Image5.Visible = true;
            //Image1.Visible = true;
            Image10.Visible = false;

            

            //Validación para saber si la fecha de la multa es posterior al dia actual.
           
            if (fecha_actual < fecha_imposicion)
            {
                Image8.Visible = true;
                Image3.Visible = false;
                Label47.Text = "La Fecha seleccionada no es aceptada pues pertenece al futuro";

            }
            if (fecha_imposicion <= fecha_actual)
            {
                Image3.Visible = true;
                Image8.Visible = false;

            }


            //Validación para saber si la multa esta duplicada
            if (fecha_actual >= fecha_duplicacion)
            {

                Image3.Visible = true;
                Image13.Visible = true;
                Label62.Text = Convert.ToString(importe1 * 2);
                Image13.ToolTip = "Esta Multa desde el " + fecha_duplicacion.ToString().Substring(0, 10) + " ha sido duplicada";
                Image14.Visible = true;
                Image14.ToolTip = "El Importe Duplicado es de $" + Label62.Text;
                Label51.Text = "Sí";
                Label52.Text = fecha_duplicacion.ToString().Substring(0, 10);
                Label47.Text = "Esta Multa desde el " + fecha_duplicacion.ToString().Substring(0, 10) + " ha sido duplicada" + "... El Infractor ahora debe pagar $" + Label62.Text;
            }

            if (fecha_actual < fecha_duplicacion)
            {
                Image13.Visible = false;
                Image14.Visible = false;
                Label51.Text = "No";
                Label51.Visible = false;
                Label52.Text = "";
                Label62.Visible = false;
                Label62.Text = TextBox71.Text + "." + TextBox65.Text;

            }


            if (Image6.Visible == true || Image7.Visible == true || Image8.Visible == true || Image9.Visible == true || Image10.Visible == true || Image18.Visible == true)
            {
                Button122.Enabled = false;
                Button120.Enabled = false;
                Button119.Text = "Corregir";
            }
            else            
            
            {
                Label47.Text = "La información brindada por el Cliente ha sido procesada y verificada correctamente, usted puede Aceptar estos datos y efectuar el Pago.";
                Button122.Enabled = true;
                Button119.Text = "Procesar";
                Button120.Enabled = false;
            }  
            
        }
    }
    protected void Calendar18_SelectionChanged(object sender, EventArgs e)
    {
        TextBox70.Text = Calendar18.SelectedDate.ToShortDateString();
        Button122.Enabled = false;
        Button120.Enabled = false;
        TextBox70.Focus();

    }
    protected void Button122_Click(object sender, EventArgs e)
    {
        Label67.Text = DropDownList12.Text;
        Label65.Text = TextBox64.Text;
        Label48.Text = TextBox68.Text;
        Label49.Text = TextBox69.Text;
        Label50.Text = TextBox70.Text;
        Label61.Text = TextBox71.Text + "." + TextBox65.Text;
        Label62.Visible = true;
        Label63.Text = Label46.Text;
        Label51.Visible = true;
        Label52.Visible = true;
        Button120.Enabled = true;

        TextBox64.Enabled = false;
        TextBox65.Enabled = false;
        TextBox68.Enabled = false;
        TextBox69.Enabled = false;
        TextBox70.Enabled = false;
        TextBox71.Enabled = false;
        DropDownList12.Enabled = false;

        Image1.Visible = false;
        Image2.Visible = false;
        Image3.Visible = false;
        Image4.Visible = false;
        Image5.Visible = false;
        Image16.Visible = false;
        Image19.Visible = false;
        Image20.Visible = false;

        Button122.Enabled = false;
        Button119.Enabled = false;
        Button123.Enabled = true;

        Calendar18.SelectedDate = DateTime.Today;



    }
    protected void TextBox68_TextChanged(object sender, EventArgs e)
    {
        Button122.Enabled = false;
    }
    protected void Button121_Click(object sender, EventArgs e)
    {
        EstadoNavegPago.UltimaPagina = 5;
        MVWPago.ActiveViewIndex = 5;
        TextBox64.Text = "";
        TextBox65.Text = "00";
        TextBox68.Text = "";
        TextBox69.Text = "";
        TextBox70.Text = "";
        TextBox71.Text = "";

        TextBox64.Enabled = true;
        TextBox65.Enabled = true;
        TextBox68.Enabled = true;
        TextBox69.Enabled = true;
        TextBox70.Enabled = true;
        TextBox71.Enabled = true;
        DropDownList12.Enabled = true;
        DropDownList12.ClearSelection();

        Calendar18.SelectedDate = DateTime.Now;
        Button119.Enabled = true;
        Button122.Enabled = false;
        Button120.Enabled = false;
        Button123.Enabled = false;
        Label46.Text = "?";
        Label47.Text = "";
        Label48.Text = "";
        Label49.Text = "";
        Label50.Text = "";
        Label51.Text = "";
        Label52.Text = "";
        Label61.Text = "";
        Label62.Text = "";
        Label63.Text = "";
        Label65.Text = "";
        Label67.Text = "";
        Image1.Visible = false;
        Image2.Visible = false;
        Image3.Visible = false;
        Image4.Visible = false;
        Image5.Visible = false;
        Image6.Visible = false;
        Image7.Visible = false;
        Image8.Visible = false;
        Image9.Visible = false;
        Image10.Visible = false;
        Image11.Visible = false;
        Image12.Visible = false;
        Image13.Visible = false;
        Image14.Visible = false;
        Image15.Visible = false;
        Image16.Visible = false;
        Image19.Visible = false;
        Image20.Visible = false;
        CI_Pago.Value = "";
    }

    #region <Raul: (anterior a lo del USD) Boton Pagar Multa Contravencion View50>
    //protected void Button120_Click(object sender, EventArgs e)
    //{
    //    string[] dat = new string[5];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false;

        
    //    try
    //    {
    //        //nombre, importe, informativo
    //        string tipo_mon = "";
    //        tipo_mon = Label46.Text;

            
            
    //        dat[0] = "00000000";
    //        dat[1] = Calendar18.SelectedDate.Date.ToString("dd/MM/yy");
    //        dat[2] = Label49.Text;
    //        if (Label62.Text == "")
    //        {
    //            dat[3] = "02" + Label61.Text.Trim();
    //        }
    //        else
    //        {
    //            dat[3] = "02" + Label62.Text.Trim();
    //        }
    //        dat[04] = "12" + " FEC_IMP:" + Calendar18.SelectedDate.Date.ToString("dd/MM/yy") + " MULTA:" + Label48.Text + " CONVENIO:00" + " MONEDA:" + tipo_mon + " DL:" + Label65.Text + " DPA:" + Label48.Text.Substring(0, 4) + " TC:2";
            
    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (cantidad == 1)
    //        {
    //            if (mon_cue == "CUP")
    //            {
    //                moneda = false;

    //            }
    //            if (mon_cue == "CUC")
    //            {
    //                moneda = true;

    //            }

    //            if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;

    //            }
    //            else
    //            {
    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

       
    //                EstadoNavegPago.UltimaPagina = 5;
    //                MVWPago.ActiveViewIndex = 5;
                    
    //            }
    //        }
    //        else if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;

    //        }

    //        TextBox64.Text = "";
    //        TextBox65.Text = "00";
    //        TextBox68.Text = "";
    //        TextBox69.Text = "";
    //        TextBox70.Text = "";
    //        TextBox71.Text = "";
    //        DropDownList12.ClearSelection();

    //        TextBox64.Enabled = true;
    //        TextBox65.Enabled = true;
    //        TextBox68.Enabled = true;
    //        TextBox69.Enabled = true;
    //        TextBox70.Enabled = true;
    //        TextBox71.Enabled = true;
    //        DropDownList12.Enabled = true;

    //        Button119.Enabled = true;
    //        Button122.Enabled = false;
    //        Button120.Enabled = false;
    //        Button123.Enabled = false;

    //        Label47.Text = "";
            

    //        Calendar18.SelectedDate = DateTime.Today;
    //        Button122.Enabled = false;
    //        Button120.Enabled = false;
    //        Label46.Text = "?";
    //        Label47.Text = "";
    //        Label48.Text = "";
    //        Label49.Text = "";
    //        Label50.Text = "";
    //        Label51.Text = "";
    //        Label52.Text = "";
    //        Label61.Text = "";
    //        Label62.Text = "";
    //        Label63.Text = "";
    //        Label65.Text = "";
    //        Label67.Text = "";
    //        Image1.Visible = false;
    //        Image2.Visible = false;
    //        Image3.Visible = false;
    //        Image4.Visible = false;
    //        Image5.Visible = false;
    //        Image6.Visible = false;
    //        Image7.Visible = false;
    //        Image8.Visible = false;
    //        Image9.Visible = false;
    //        Image10.Visible = false;
    //        Image11.Visible = false;
    //        Image12.Visible = false;
    //        Image13.Visible = false;
    //        Image14.Visible = false;
    //        Image15.Visible = false;
    //        Image16.Visible = false;

    //        CI_Pago.Value = "";
                
    //     }
    //     catch (Exception ex)
    //     {
    //         Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //         Button13.Enabled = true;

    //     }
    //}

    #endregion

    protected void Button120_Click(object sender, EventArgs e)
    {
        string[] dat = new string[5];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0;


        try
        {
            //nombre, importe, informativo
            string tipo_mon = "";
            tipo_mon = Label46.Text;



            dat[0] = "00000000";
            dat[1] = Calendar18.SelectedDate.Date.ToString("dd/MM/yy");
            dat[2] = Label49.Text;
            if (Label62.Text == "")
            {
                dat[3] = "02" + Label61.Text.Trim();
            }
            else
            {
                dat[3] = "02" + Label62.Text.Trim();
            }
            dat[04] = "12" + " FEC_IMP:" + Calendar18.SelectedDate.Date.ToString("dd/MM/yy") + " MULTA:" + Label48.Text + " CONVENIO:00" + " MONEDA:" + tipo_mon + " DL:" + Label65.Text + " DPA:" + Label48.Text.Substring(0, 4) + " TC:2";

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            if (cantidad == 1)
            {
                if (mon_cue == "CUP")
                {
                    moneda = 0;

                }
                if (mon_cue == "CUC")
                {
                    moneda = 1;
                }
                if (mon_cue == "USD")
                {
                    moneda = 2;
                }

                if (((tipo_mon == "CUP") && (mon_cue == "CUC")) || ((tipo_mon == "CUC") && (mon_cue == "CUP")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;

                }
                else
                {
                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);


                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;

                }
            }
            else if (cantidad >= 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_mon, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }

            TextBox64.Text = "";
            TextBox65.Text = "00";
            TextBox68.Text = "";
            TextBox69.Text = "";
            TextBox70.Text = "";
            TextBox71.Text = "";
            DropDownList12.ClearSelection();

            TextBox64.Enabled = true;
            TextBox65.Enabled = true;
            TextBox68.Enabled = true;
            TextBox69.Enabled = true;
            TextBox70.Enabled = true;
            TextBox71.Enabled = true;
            DropDownList12.Enabled = true;

            Button119.Enabled = true;
            Button122.Enabled = false;
            Button120.Enabled = false;
            Button123.Enabled = false;

            Label47.Text = "";


            Calendar18.SelectedDate = DateTime.Today;
            Button122.Enabled = false;
            Button120.Enabled = false;
            Label46.Text = "?";
            Label47.Text = "";
            Label48.Text = "";
            Label49.Text = "";
            Label50.Text = "";
            Label51.Text = "";
            Label52.Text = "";
            Label61.Text = "";
            Label62.Text = "";
            Label63.Text = "";
            Label65.Text = "";
            Label67.Text = "";
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;
            Image7.Visible = false;
            Image8.Visible = false;
            Image9.Visible = false;
            Image10.Visible = false;
            Image11.Visible = false;
            Image12.Visible = false;
            Image13.Visible = false;
            Image14.Visible = false;
            Image15.Visible = false;
            Image16.Visible = false;

            CI_Pago.Value = "";

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Button13.Enabled = true;

        }
    }




    protected void Button123_Click(object sender, EventArgs e)
    {
        TextBox64.Enabled = true;
        TextBox65.Enabled = true;
        TextBox68.Enabled = true;
        TextBox69.Enabled = true;
        TextBox70.Enabled = true;
        TextBox71.Enabled = true;
        DropDownList12.Enabled = true;

        Button119.Enabled = true;
        Button122.Enabled = false;
        Button120.Enabled = false;

        Label47.Text = "";

        Label46.Text = "?";
        Label47.Text = "";
        Label48.Text = "";
        Label49.Text = "";
        Label50.Text = "";
        Label51.Text = "";
        Label52.Text = "";
        Label61.Text = "";
        Label62.Text = "";
        Label63.Text = "";
        Label65.Text = "";
        Label67.Text = "";
    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox64.Focus();
        if (DropDownList12.SelectedValue == "OC-13")
        {
            TextBox64.Enabled = false;
            TextBox65.Enabled = false;
            TextBox68.Enabled = false;
            TextBox69.Enabled = false;
            TextBox70.Enabled = false;
            TextBox71.Enabled = false;
            Calendar18.SelectedDate = DateTime.Today;

            TextBox64.Text = "";
            TextBox65.Text = "";
            TextBox68.Text = "";
            TextBox69.Text = "";
            TextBox70.Text = "";
            TextBox71.Text = "";
            
            Button119.Enabled = false;
            Button122.Enabled = false;
            Button123.Enabled = false;
            Button120.Enabled = false;
            Image19.Visible = false;
            Image20.Visible = true;
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image16.Visible = false;

            Label47.Text = "El Modelo de Talón OC-13 es una Multa por Contravención Convenida, Banca Telefónica no acepta este pago; infórmele  al Cliente que para efectuar su pago debe dirigirse a la Sucursal del Banco Metropolitano mas cercana a él...";
        }

        if (DropDownList12.SelectedValue == "OC-1")
        {
            TextBox64.Enabled = true;
            TextBox65.Enabled = true;
            TextBox65.Text = "00";
            TextBox68.Enabled = true;
            TextBox69.Enabled = true;
            TextBox70.Enabled = true;
            TextBox71.Enabled = true;

            Button119.Enabled = true;
            Button122.Enabled = false;
            Button123.Enabled = false;
            Button120.Enabled = false;
            Image19.Visible = true;
            Image20.Visible = false;

            Label47.Text = "";
        }
        if (DropDownList12.SelectedValue == "")
        {
            Image19.Visible = false;
            Image20.Visible = false;
  
        }

    }
    //Para no permitir seleccionar dias del futuro y fechas que no estén en el rango de 365 días a partir de su fecha de imposición...

    protected void Calendar18_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }

        if (e.Day.Date.AddDays(365) < DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...Operación Denegada, esta Multa por su fecha de imposición no esta en el rango de 365 días naturales para efectuar su pago...";

        }
    }

    protected void Calendar10_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }

        if (e.Day.Date.AddDays(365) < DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...Operación Denegada, esta Multa por su fecha de imposición no esta en el rango de 365 días naturales para efectuar su pago...";

        }

        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
    }

    protected void View40_Activate(object sender, EventArgs e)
    {
        Label72.Text = Servicio.getUsuariActivo()[2];
    }

    protected void Calendar4_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    protected void Calendar5_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    protected void Calendar3_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar11_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar12_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    protected void Calendar15_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar16_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
    }
    protected void Calendar13_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    protected void Calendar8_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar9_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
    }
    protected void Button124_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar7_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    protected void Calendar6_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar14_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

    }
    

    protected void View3_Activate(object sender, EventArgs e)
    {
        TextBox41.Focus();
    }


    protected void View29_Activate(object sender, EventArgs e)
    {
        TextBox30.Text = "";
    }
    protected void View2_Activate(object sender, EventArgs e)
    {
        string cllamadas = Servicio.CLlamadas();
        if ((cllamadas.Length.ToString()) == "4")
        {
            TextBox9.Value = cllamadas.ToString().Substring(2,2);
            TextBox8.Focus();
        }
        else
        {
            TextBox9.Value = cllamadas;
            TextBox8.Focus();
        }
        

        
    }
    protected void Button100_Click1(object sender, EventArgs e)
    {
        MVWPago.ActiveViewIndex = 39;
    }
    protected void Calendar17_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }
    }
    protected void Calendar19_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
    }

    protected void View10_Activate(object sender, EventArgs e)
    {
        string Tarjeta = Session["NoTarjeta"].ToString();

        DataSet DT = new DataSet();
        DT = Servicio.ConsultarSaldo(Tarjeta);
        GridView6.DataSource = DT.Tables[0];
        GridView6.DataBind();

    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        BtnDescFTP.Enabled = true;
    }

    protected void View51_Activate(object sender, EventArgs e)
    {
        
        DropDownList17.ClearSelection();
        DropDownList18.Items.Clear();
        DropDownList18.ClearSelection();
        GridView7.SelectedIndex = -1;
        GridView7.DataBind();
        RadioButtonList7.ClearSelection();
        TextBox51.Text = "";
        TextBox52.Text = "00";
        Button126.Enabled = false;
        

        string Tarjeta = Session["NoTarjeta"].ToString();

        DataSet DT = new DataSet();
        DT = Servicio.Monedas(Tarjeta);
        if (RadioButtonList7.Items.Count == 0)
            foreach (DataRow Row in DT.Tables[0].Rows)
            {
                RadioButtonList7.Items.Add(Row[1].ToString());
            }

        Label10.Text = Servicio.MostrarCI_Transf(Tarjeta);
        
        DataSet dseti = new DataSet();

        DataRow myDataRowP;
        DataTable dp;
        dp = new DataTable();

        DataColumn Cod_Provin;
        DataColumn Nom_Provin;

        Cod_Provin = new DataColumn("Cod_Provin");
        Nom_Provin = new DataColumn("Nom_Provin");

        dp.Columns.Add(Cod_Provin);
        dp.Columns.Add(Nom_Provin);

        dseti.Tables.Add(dp);

        
        dseti = Servicio.TransferenciasProv();

        myDataRowP = dseti.Tables[0].NewRow();
        myDataRowP["Cod_Provin"] = "-1";
        myDataRowP["Nom_Provin"] = "-- Seleccione Provincia --";
        dseti.Tables[0].Rows.InsertAt(myDataRowP, 0);
        DropDownList17.DataSource = dseti.Tables[0];
        DropDownList17.DataTextField = "NOM_PROVIN";
        DropDownList17.DataValueField = "COD_PROVIN";
        DropDownList17.DataBind();
        
        
    }
    protected void DropDownList17_SelectedIndexChanged(object sender, EventArgs e)
    {
        string codigo = DropDownList17.SelectedValue;
        DataSet dseti = new DataSet();

        DataRow myDataRowP;
        DataTable dp;
        dp = new DataTable();

        DataColumn Cod_Provin;
        DataColumn Nom_Provin;

        Cod_Provin = new DataColumn("cod_dpa");
        Nom_Provin = new DataColumn("nom_munic");

        dp.Columns.Add(Cod_Provin);
        dp.Columns.Add(Nom_Provin);

        dseti.Tables.Add(dp);


        dseti = Servicio.TransferenciasMunicipio(codigo);

        myDataRowP = dseti.Tables[0].NewRow();
        myDataRowP["cod_dpa"] = "-1";
        myDataRowP["nom_munic"] = "-- Seleccione Municipio --";
        dseti.Tables[0].Rows.InsertAt(myDataRowP, 0);
        DropDownList18.DataSource = dseti.Tables[0];
        DropDownList18.DataTextField = "NOM_MUNIC";
        DropDownList18.DataValueField = "COD_DPA";
        DropDownList18.DataBind();
    }
    protected void DropDownList18_SelectedIndexChanged(object sender, EventArgs e)
    {

        string codigo = DropDownList18.SelectedValue;

        DataSet tabla = new DataSet();
        tabla = Servicio.TransferenciasBanco(codigo);
        GridView7.DataSource = tabla;
        GridView7.DataBind();
    }

    protected void Button98_Click1(object sender, EventArgs e)
    {
        Button126.Enabled = true;
        
        string debitar = TextBox51.Text + "." + TextBox52.Text;
    }

    #region<Raul: (anterior a lo del USD) Boton Efectuar Transferencia al propio cliente View51>
    //protected void Button126_Click(object sender, EventArgs e)
    //{
        
    //        string[] dat = new string[5];
    //        string banco = GridView7.SelectedRow.Cells[1].Text.Trim();
    //        string suc = GridView7.SelectedRow.Cells[3].Text.Trim();
    //        DateTime fecha = new DateTime();
    //        string importe = (TextBox51.Text.Trim() + "." + TextBox52.Text.Trim());
    //        bool moneda = false;

    //        if (RadioButtonList7.SelectedItem.Text == "CUP")
    //        {
    //            moneda = false;
    //        }
    //        if (RadioButtonList7.SelectedItem.Text == "CUC")
    //        {
    //            moneda = true;
    //        }
    //        try
    //        {

    //            //nombre, importe, informativo
    //            dat[0] = "00000000";
    //            dat[1] = fecha.Date.ToString("dd/MM/yy");
    //            dat[2] = Label10.Text.Trim();
    //            dat[03] = "02" + importe;
    //            dat[04] = "12" + "B:" + banco + " S:" + suc + " D:" + DropDownList18.SelectedValue;

    //            //identificar monedas asociadas a bt.
    //            string Tarjeta = Session["NoTarjeta"].ToString();
    //            DataSet DT = new DataSet();
    //            DT = Servicio.Monedas(Tarjeta);

    //            int cantidad = DT.Tables[0].Rows.Count;
    //            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //            string tipo_moneda = RadioButtonList7.SelectedItem.Text;

    //            if (cantidad == 1)
    //            {

    //                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")))
    //                {
    //                    List<object> contiene = new List<object>();
    //                    //redirecciono para la vista de aplicar tipo de cambio
    //                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                    Session["contiene"] = contiene;
    //                    MVWPago.ActiveViewIndex = 53;

    //                }
    //                else
    //                {

    //                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                    Errores.Alert(this, traza);
    //                    EstadoNavegPago.UltimaPagina = 4;
    //                    MVWPago.ActiveViewIndex = 4;

    //                }
    //            }
    //            if (cantidad == 2)
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 54;

    //            }


    //            DropDownList17.ClearSelection();
    //            DropDownList18.ClearSelection();
    //            GridView7.SelectedIndex = -1;
    //            RadioButtonList7.ClearSelection();
    //            TextBox51.Text = "";
    //            TextBox52.Text = "00";
    //            Label10.Text = "";


    //        }

    //        catch (Exception ex)
    //        {
    //            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

    //        }
        
    //}
    #endregion

    protected void Button126_Click(object sender, EventArgs e)
    {

        string[] dat = new string[5];
        string banco = GridView7.SelectedRow.Cells[1].Text.Trim();
        string suc = GridView7.SelectedRow.Cells[3].Text.Trim();
        DateTime fecha = new DateTime();
        string importe = (TextBox51.Text.Trim() + "." + TextBox52.Text.Trim());
        int moneda = 0;

        if (RadioButtonList7.SelectedItem.Text == "CUP")
        {
            moneda = 0;
        }
        if (RadioButtonList7.SelectedItem.Text == "CUC")
        {
            moneda = 1;
        }
        if (RadioButtonList7.SelectedItem.Text == "USD")
        {
            moneda = 2;
        }
        try
        {

            //nombre, importe, informativo
            dat[0] = "00000000";
            dat[1] = fecha.Date.ToString("dd/MM/yy");
            dat[2] = Label10.Text.Trim();
            dat[03] = "02" + importe;
            dat[04] = "12" + "B:" + banco + " S:" + suc + " D:" + DropDownList18.SelectedValue;

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;
            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            string tipo_moneda = RadioButtonList7.SelectedItem.Text;

            if (cantidad == 1)
            {

                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")) || ((tipo_moneda == "CUP") && (mon_cue == "USD")) || ((tipo_moneda == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;

                }
                else
                {

                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;

                }
            }
            else if (cantidad == 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }
            else if (cantidad == 3)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;
            }


            DropDownList17.ClearSelection();
            DropDownList18.ClearSelection();
            GridView7.SelectedIndex = -1;
            RadioButtonList7.ClearSelection();
            TextBox51.Text = "";
            TextBox52.Text = "00";
            Label10.Text = "";


        }

        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

        }

    }

    protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button126.Enabled = true;
      
    }
    protected void RadioButtonList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView7.SelectedIndex != -1)
        {
            TextBox51.Enabled = true;
            TextBox52.Enabled = true;
            Button126.Enabled = true;
        }
        else
        {
            TextBox51.Enabled = false;
            TextBox52.Enabled = false;
            Button126.Enabled = false;
        }
       
    }
    protected void Button125_Click(object sender, EventArgs e)
    {
        DropDownList17.ClearSelection();
        DropDownList18.ClearSelection();
        GridView7.SelectedIndex = -1;
        RadioButtonList7.ClearSelection();
        TextBox51.Text = "";
        TextBox52.Text = "00";
        Label10.Text = "";
        TextBox51.Enabled = false;
        TextBox52.Enabled = false;
        Button126.Enabled = false;
    
        EstadoNavegPago.UltimaPagina = 55;
        MVWPago.ActiveViewIndex = 55;
    }
    protected void View41_Activate(object sender, EventArgs e)
    {
        if (EstadoNavegPago.AutenticadoTarjeta == false)
        {
            Label42.Text = "";
        }
        EstadoNavegPago.AutenticadoTarjeta = false;
        EstadoNavegPago.AutenticadoPin = false;
        TextBox9.Value = "";
        TextBox8.Value = "";
        TextBox10.Value = "";
        Menu1.Items[0].Selected = true;

        
    }


    protected void Button127_Click(object sender, EventArgs e)
    {
        
        try
        {
            string codServ = (string)Session["codServicio"];
            string pnr = TextBox53.Text.Trim();
            object[] datos = Servicio.BuscarDatosMuestraPagComplejo(codServ, pnr);
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        
        if (DetailsView1.Rows.Count!=0)
        {
            
            IFormatProvider culture = new System.Globalization.CultureInfo("es-ES" , true);
            DateTime fecha_hoy = DateTime.Today.Date;
                        
            DateTime fecha_limite = Convert.ToDateTime(DetailsView1.Rows[9].Cells[1].Text.Trim(), culture);

            if (fecha_limite < fecha_hoy)
            {
                Button128.Enabled = false;
                Label142.Text = "!DENEGADO! La fecha de hoy excede la fecha límite de Pago ";   
            }
            else
            {
                Button128.Enabled = true;
                Label142.Text = "";
            }

         }
         if (DetailsView1.Rows.Count == 0)
         {
             Label142.Text = "";
         }
    }

    protected void TextBox53_TextChanged(object sender, EventArgs e)
    {
        DetailsView1.DataBind();
        Button127.Focus();
    }

    #region<Raul:(anterior a lo del USD) Boton Efectuar Pago Vuelos Aerocaribean View52>
    //protected void Button128_Click(object sender, EventArgs e)
    //{
        
        
    //    string[] dat = new string[5];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false;

    //    string tipo_moneda = "";

        
    //    try
    //    {
    //        string codServ = (string)Session["codServicio"];
    //        object[] datos1 = Servicio.BuscarDatosMuestraPagComplejo(codServ, TextBox53.Text.Trim());
    //        string[] dpc1 = (string[])datos1[0];
            

    //        //nombre, importe, informativo
    //        dat[0] = dpc1[0];
    //        dat[1] = DetailsView1.Rows[9].Cells[1].Text.Trim();//Fecha límite de pago
    //        dat[2] = DetailsView1.Rows[0].Cells[1].Text.Trim();//PNR Numerico
    //        dat[03] = "02" + DetailsView1.Rows[3].Cells[1].Text.Substring(1).Trim();//Importe
    //        dat[04] = "12" + " FEC_VUE:" + DetailsView1.Rows[5].Cells[1].Text.Trim() + " No. Vuelo:" + DetailsView1.Rows[4].Cells[1].Text.Trim() + " PNR ALfanumerico:" + DetailsView1.Rows[1].Cells[1].Text.Trim() + " MONEDA:" + tipo_moneda + " Origen-Destino:" + DetailsView1.Rows[6].Cells[1].Text.Trim() + "-" + DetailsView1.Rows[7].Cells[1].Text.Trim();

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;
           
    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (moneda == false)
    //        {
    //            tipo_moneda = "CUP";
    //        }
    //        else
    //        {
    //            tipo_moneda = "CUC";
    //        }

    //        if (cantidad == 1)
    //        {
    //            if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;
    //            }

    //            else
    //            {

    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

    //                DetailsView1.DataBind();
    //                if (DetailsView1.Rows.Count == 0)
    //                {
    //                    EstadoNavegPago.UltimaPagina = 4;
    //                    MVWPago.ActiveViewIndex = 4;
    //                }
                    
    //            }
    //        }

    //        if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;
    //        }
            
            
    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Button13.Enabled = true;
    //    }
    //}
    #endregion

    protected void Button128_Click(object sender, EventArgs e)
    {


        string[] dat = new string[5];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0;

        string tipo_moneda = "";


        try
        {
            string codServ = (string)Session["codServicio"];
            object[] datos1 = Servicio.BuscarDatosMuestraPagComplejo(codServ, TextBox53.Text.Trim());
            string[] dpc1 = (string[])datos1[0];


            //nombre, importe, informativo
            dat[0] = dpc1[0];
            dat[1] = DetailsView1.Rows[9].Cells[1].Text.Trim();//Fecha límite de pago
            dat[2] = DetailsView1.Rows[0].Cells[1].Text.Trim();//PNR Numerico
            dat[03] = "02" + DetailsView1.Rows[3].Cells[1].Text.Substring(1).Trim();//Importe
            dat[04] = "12" + " FEC_VUE:" + DetailsView1.Rows[5].Cells[1].Text.Trim() + " No. Vuelo:" + DetailsView1.Rows[4].Cells[1].Text.Trim() + " PNR ALfanumerico:" + DetailsView1.Rows[1].Cells[1].Text.Trim() + " MONEDA:" + tipo_moneda + " Origen-Destino:" + DetailsView1.Rows[6].Cells[1].Text.Trim() + "-" + DetailsView1.Rows[7].Cells[1].Text.Trim();

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            if (moneda == 0)
            {
                tipo_moneda = "CUP";
            }
            else if (moneda == 1)
            {
                tipo_moneda = "CUC";
            }
            else if (moneda == 2)
            {
                tipo_moneda = "USD";
            }

            if (cantidad == 1)
            {
                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")) || ((tipo_moneda == "CUP") && (mon_cue == "USD")) || ((tipo_moneda == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;
                }

                else
                {

                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);

                    DetailsView1.DataBind();
                    if (DetailsView1.Rows.Count == 0)
                    {
                        EstadoNavegPago.UltimaPagina = 4;
                        MVWPago.ActiveViewIndex = 4;
                    }

                }
            }

            if (cantidad >= 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;
            }


        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Button13.Enabled = true;
        }
    }

    protected void Button129_Click(object sender, EventArgs e)
    {
        TextBox53.Text = "";
        Label142.Text = "";
        DetailsView1.DataBind();
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
    }
    protected void View52_Activate(object sender, EventArgs e)
    {
        TextBox53.Text = "";
    }
    protected void View6_Activate(object sender, EventArgs e)
    {
        string codServ = (string)Session["codServicio"];
        if (codServ =="03")
        {
            Label18.Text = "Carné de Identidad o NIP";
            CI_Pago.MaxLength.ToString("16");
        }
    }
    
    public List<Object> datos_pago_tc(string mon_cuenta, string mon_factura, string[] datos_pago)
    {
        List<object> contenedor = new List<object>();
        contenedor.Add(mon_cuenta);
        contenedor.Add(mon_factura);
        contenedor.Add(datos_pago);
        return contenedor;
    }

    #region<Raul:(anterior a lo del USD) Boton SI Finalizar Pago Aplicando Tipo Cambio View53>
    //protected void Button98_Click2(object sender, EventArgs e)
    //{
    //    List<object> contiene = (List<object>)Session["contiene"];

    //    string[] lista1 = new string[5];
    //    lista1 = (string[])contiene[2];
    //    bool moneda;

    //    try
    //    {
    //        if (contiene[0].ToString() == "CUC")
    //        {
    //            moneda = true;
    //        }
    //        else if (contiene[0].ToString() == "CUP")
    //        {
    //            moneda = false;
    //        }
    //        else
    //        {
    //            return;
    //        }

    //        if (contiene[0].ToString() != contiene[1].ToString())
    //        {
    //            Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
    //            string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
    //            Errores.Alert(this, traza);
    //        }
    //        Session["codServicio"] = "0" + Convert.ToString(Convert.ToInt32(Session["codServicio"]) - 50);

    //        if (((string)Session["codServicio"] == "09") || ((string)Session["codServicio"] == "59"))
    //        {
    //            DetailsView2.DataBind();
    //            TextBox74.Text = "";
    //            TextBox77.Text = "";
    //            //GridView11.SelectedIndex = -1;
    //            ASPxGridView3.FocusedRowIndex = -1;
    //            //GridView11.FocusedRowIndex = -1;

    //            if (DetailsView2.Rows.Count == 0)
    //            {
    //                EstadoNavegPago.UltimaPagina = 4;
    //                MVWPago.ActiveViewIndex = 4;
    //            }
    //            else
    //            {
    //                EstadoNavegPago.UltimaPagina = 5;
    //                MVWPago.ActiveViewIndex = 5;
    //            }
    //        }

    //        if (((string)Session["codServicio"] == "08") || ((string)Session["codServicio"] == "58"))
    //        {
    //            DetailsView1.DataBind();

    //            if (DetailsView1.Rows.Count == 0)
    //            {
    //                EstadoNavegPago.UltimaPagina = 4;
    //                MVWPago.ActiveViewIndex = 4;
    //            }
    //            else
    //            {
    //                EstadoNavegPago.UltimaPagina = 5;
    //                MVWPago.ActiveViewIndex = 5;
    //            }
    //        }

    //        if (((string)Session["codServicio"] == "07") || ((string)Session["codServicio"] == "57"))
    //        {
    //            DropDownList17.ClearSelection();
    //            DropDownList18.ClearSelection();
    //            GridView7.SelectedIndex = -1;
    //            RadioButtonList7.ClearSelection();
    //            TextBox51.Text = "";
    //            TextBox52.Text = "00";
    //            Label10.Text = "";

    //            EstadoNavegPago.UltimaPagina = 4;
    //            MVWPago.ActiveViewIndex = 4;
    //        }

    //        if (((string)Session["codServicio"] == "06") || ((string)Session["codServicio"] == "56"))
    //        {
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            TextBox64.Text = "";
    //            TextBox65.Text = "00";
    //            TextBox68.Text = "";
    //            TextBox69.Text = "";
    //            TextBox70.Text = "";
    //            TextBox71.Text = "";
    //            DropDownList12.ClearSelection();

    //            TextBox64.Enabled = true;
    //            TextBox65.Enabled = true;
    //            TextBox68.Enabled = true;
    //            TextBox69.Enabled = true;
    //            TextBox70.Enabled = true;
    //            TextBox71.Enabled = true;
    //            DropDownList12.Enabled = true;

    //            Button119.Enabled = true;
    //            Button122.Enabled = false;
    //            Button120.Enabled = false;
    //            Button123.Enabled = false;

    //            Label47.Text = "";


    //            Calendar18.SelectedDate = DateTime.Today;
    //            Button122.Enabled = false;
    //            Button120.Enabled = false;
    //            Label46.Text = "?";
    //            Label47.Text = "";
    //            Label48.Text = "";
    //            Label49.Text = "";
    //            Label50.Text = "";
    //            Label51.Text = "";
    //            Label52.Text = "";
    //            Label61.Text = "";
    //            Label62.Text = "";
    //            Label63.Text = "";
    //            Label65.Text = "";
    //            Label67.Text = "";
    //            Image1.Visible = false;
    //            Image2.Visible = false;
    //            Image3.Visible = false;
    //            Image4.Visible = false;
    //            Image5.Visible = false;
    //            Image6.Visible = false;
    //            Image7.Visible = false;
    //            Image8.Visible = false;
    //            Image9.Visible = false;
    //            Image10.Visible = false;
    //            Image11.Visible = false;
    //            Image12.Visible = false;
    //            Image13.Visible = false;
    //            Image14.Visible = false;
    //            Image15.Visible = false;
    //            Image16.Visible = false;

    //            CI_Pago.Value = "";

    //        }

    //        if (((string)Session["codServicio"] == "04") || ((string)Session["codServicio"] == "54"))
    //        {
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Button13.Enabled = true;
    //            Calendar10.SelectedDate = DateTime.Now;
    //            TextBox55.Text = "";
    //            DropDownList13.ClearSelection();
    //            DropDownList14.ClearSelection();
    //            DropDownList15.ClearSelection();
    //            DropDownList16.ClearSelection();

    //            Label37.Text = "";
    //            Label39.Text = "";
    //            Label134.Text = "Fecha";
    //            Label134.ForeColor = System.Drawing.Color.Black;
    //            Button99.Enabled = false;
    //            CI_Pago.Value = "";

    //            //RegularExpressionValidator33.Visible = false;
    //            //RegularExpressionValidator34.Visible = false;
    //            //RegularExpressionValidator35.Visible = false;
    //            //RegularExpressionValidator36.Visible = false;
    //            //RegularExpressionValidator37.Visible = false;
    //            //Habilitar textbox
    //            DropDownList13.Enabled = true;
    //            DropDownList14.Enabled = true;
    //            DropDownList15.Enabled = true;
    //            TextBox55.Enabled = true;
    //            Calendar10.Enabled = true;
    //        }

    //        if (((string)Session["codServicio"] == "03") || ((string)Session["codServicio"] == "53"))
    //        {
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
                
    //                RadioButtonList9.Visible = false;
    //                Label162.Visible = false;
    //                Label162.Text = "";
                
    //            Button13.Enabled = false;
    //        }

    //        if (((string)Session["codServicio"] == "01") || ((string)Session["codServicio"] == "02") || ((string)Session["codServicio"] == "51") || ((string)Session["codServicio"] == "52") || ((string)Session["codServicio"] == "53") || ((string)Session["codServicio"] == "55"))
    //        {

    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Button13.Enabled = true;
               
    //        }
    //        //Salir
    //        Session.Remove("contiene");
            
    //     }

    //    catch (Exception ex)
    //    {
    //        //Salir
    //        Session.Remove("contiene");
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //    }
    // }
    #endregion

    //Raul: Boton SI Finalizar Pago Aplicando Tipo Cambio View53
    protected void Button98_Click2(object sender, EventArgs e)
    {
        List<object> contiene = (List<object>)Session["contiene"];

        string[] lista1 = new string[5];
        lista1 = (string[])contiene[2];
        int moneda;

        try
        {
            if (contiene[0].ToString() == "CUC")
            {
                moneda = 1;
            }
            else if (contiene[0].ToString() == "CUP")
            {
                moneda = 0;
            }
            else if (contiene[0].ToString() == "USD")
            {
                moneda = 2;
            }
            else
            {
                return;
            }

            if (contiene[0].ToString() != contiene[1].ToString())
            {
                Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
                Errores.Alert(this, traza);
            }
            Session["codServicio"] = "0" + Convert.ToString(Convert.ToInt32(Session["codServicio"]) - 50);

            if (((string)Session["codServicio"] == "09") || ((string)Session["codServicio"] == "59"))
            {
                DetailsView2.DataBind();
                TextBox74.Text = "";
                TextBox77.Text = "";
                //GridView11.SelectedIndex = -1;
                ASPxGridView3.FocusedRowIndex = -1;
                //GridView11.FocusedRowIndex = -1;

                if (DetailsView2.Rows.Count == 0)
                {
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;
                }
                else
                {
                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;
                }
            }

            if (((string)Session["codServicio"] == "08") || ((string)Session["codServicio"] == "58"))
            {
                DetailsView1.DataBind();

                if (DetailsView1.Rows.Count == 0)
                {
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;
                }
                else
                {
                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;
                }
            }

            if (((string)Session["codServicio"] == "07") || ((string)Session["codServicio"] == "57"))
            {
                DropDownList17.ClearSelection();
                DropDownList18.ClearSelection();
                GridView7.SelectedIndex = -1;
                RadioButtonList7.ClearSelection();
                TextBox51.Text = "";
                TextBox52.Text = "00";
                Label10.Text = "";

                EstadoNavegPago.UltimaPagina = 4;
                MVWPago.ActiveViewIndex = 4;
            }

            if (((string)Session["codServicio"] == "06") || ((string)Session["codServicio"] == "56"))
            {
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                TextBox64.Text = "";
                TextBox65.Text = "00";
                TextBox68.Text = "";
                TextBox69.Text = "";
                TextBox70.Text = "";
                TextBox71.Text = "";
                DropDownList12.ClearSelection();

                TextBox64.Enabled = true;
                TextBox65.Enabled = true;
                TextBox68.Enabled = true;
                TextBox69.Enabled = true;
                TextBox70.Enabled = true;
                TextBox71.Enabled = true;
                DropDownList12.Enabled = true;

                Button119.Enabled = true;
                Button122.Enabled = false;
                Button120.Enabled = false;
                Button123.Enabled = false;

                Label47.Text = "";


                Calendar18.SelectedDate = DateTime.Today;
                Button122.Enabled = false;
                Button120.Enabled = false;
                Label46.Text = "?";
                Label47.Text = "";
                Label48.Text = "";
                Label49.Text = "";
                Label50.Text = "";
                Label51.Text = "";
                Label52.Text = "";
                Label61.Text = "";
                Label62.Text = "";
                Label63.Text = "";
                Label65.Text = "";
                Label67.Text = "";
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
                Image6.Visible = false;
                Image7.Visible = false;
                Image8.Visible = false;
                Image9.Visible = false;
                Image10.Visible = false;
                Image11.Visible = false;
                Image12.Visible = false;
                Image13.Visible = false;
                Image14.Visible = false;
                Image15.Visible = false;
                Image16.Visible = false;

                CI_Pago.Value = "";

            }

            if (((string)Session["codServicio"] == "04") || ((string)Session["codServicio"] == "54"))
            {
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                Button13.Enabled = true;
                Calendar10.SelectedDate = DateTime.Now;
                TextBox55.Text = "";
                DropDownList13.ClearSelection();
                DropDownList14.ClearSelection();
                DropDownList15.ClearSelection();
                DropDownList16.ClearSelection();

                Label37.Text = "";
                Label39.Text = "";
                Label134.Text = "Fecha";
                Label134.ForeColor = System.Drawing.Color.Black;
                Button99.Enabled = false;
                CI_Pago.Value = "";

                //RegularExpressionValidator33.Visible = false;
                //RegularExpressionValidator34.Visible = false;
                //RegularExpressionValidator35.Visible = false;
                //RegularExpressionValidator36.Visible = false;
                //RegularExpressionValidator37.Visible = false;
                //Habilitar textbox
                DropDownList13.Enabled = true;
                DropDownList14.Enabled = true;
                DropDownList15.Enabled = true;
                TextBox55.Enabled = true;
                Calendar10.Enabled = true;
            }

            if (((string)Session["codServicio"] == "03") || ((string)Session["codServicio"] == "53"))
            {
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;

                RadioButtonList9.Visible = false;
                Label162.Visible = false;
                Label162.Text = "";

                //Button13.Enabled = false;
                Button13.Enabled = true;
            }

            if (((string)Session["codServicio"] == "01") || ((string)Session["codServicio"] == "02") || ((string)Session["codServicio"] == "51") || ((string)Session["codServicio"] == "52") || ((string)Session["codServicio"] == "53") || ((string)Session["codServicio"] == "55"))
            {

                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                Button13.Enabled = true;

            }
            //Salir
            Session.Remove("contiene");

        }

        catch (Exception ex)
        {
            //Salir
            Session.Remove("contiene");
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    protected void Button130_Click(object sender, EventArgs e)
    {
        Session.Remove("TCambio");
        Label144.Text = "";
        Label145.Text = "";
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
    }
    
    protected void Button132_Click(object sender, EventArgs e)
    {
        Session.Remove("TCambio");
        Label146.Text = "";
        Label147.Text = "";
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
        RadioButtonList10.ClearSelection();
    }

    #region<Anterior Radiobutton10>
    //protected void RadioButtonList10_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    List<object> contiene = (List<object>)Session["contiene"]; // contiene[0]: moneda princpal con la que va a pagar
    //    // contiene[1]: moneda del servicio que va a pagar

    //    contiene[0] = RadioButtonList10.SelectedItem.Text.ToString();

    //    string[] lista = (string[])contiene[2];
    //    //Actualizar los mensajes

    //    Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
    //    Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + lista[3].ToString().Substring(2) + " " + contiene[1].ToString() +
    //                    (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + Session["TCambio"].ToString() + " " + contiene[0].ToString());

    //    float t_cambio = float.Parse(Session["TCambio"].ToString());
    //    if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("CUC").Selected == true && contiene[1] == "CUP"))
    //    {
    //        Button131.Enabled = false;
    //        Label177.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
    //        Label177.Visible = true;
    //    }
    //    else
    //    {
    //        Button131.Enabled = true;
    //        Label177.Visible = false;
    //    }


    //}
    #endregion

    //RadioButton10 para seleccionar la moneda y ver el TC con que va a pagar
    protected void RadioButtonList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> contiene = (List<object>)Session["contiene"]; // contiene[0]: moneda princpal con la que va a debitar

        contiene[0] = RadioButtonList10.SelectedItem.Text.ToString();

        string[] lista = (string[])contiene[2];
        float calculo = 0;
        float calculo_usd = 0;
        //float calculo_cuc = 0;
        DateTime fecha = DateTime.Now;
        float importe_acreditar = float.Parse(lista[3].ToString().Substring(2).Trim());

        if (contiene[1].ToString() == "CUP" && contiene[0].ToString() != "USD") // si la moneda de la factura a pagar es CUP y paga con moneda distinata a USD
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) / 24; // el banco compra el CUC a 24 CUP

            if (RadioButtonList10.Items.FindByText("CUP") != null) // si el CUP aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("CUP").Selected == true) // si el CUP esta seleccionado
                {
                    goto moneda_selected; 
                }
            }

            if (RadioButtonList10.Items.FindByText("USD") != null) // si el USD aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("USD").Selected == true) // si el USD esta seleccionado
                {
                    goto moneda_selected;
                }
            }

            if (RadioButtonList10.Items.FindByText("CUC") != null) // si el CUC aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("CUC").Selected == true) // si el CUC esta seleccionado
                {
                    goto moneda_selected;
                }
            }
        }
        if (contiene[1].ToString() == "CUC" && contiene[0].ToString() != "USD")
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) * 25; // el banco vende el CUC a 25 CUP

            if (RadioButtonList10.Items.FindByText("CUC") != null)  // si el CUC aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("CUC").Selected == true) // si el CUC esta seleccionado
                {
                    goto moneda_selected;
                }
            }
            if (RadioButtonList10.Items.FindByText("USD") != null) // si el USD aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("USD").Selected == true) // si el USD esta seleccionado
                {
                    goto moneda_selected;
                }
            }
            if (RadioButtonList10.Items.FindByText("CUP") != null) // si el CUP aparece dentro de los Items del RadioButton10
            {
                if (RadioButtonList10.Items.FindByText("CUP").Selected == true) // si el CUP esta seleccionado
                {
                    goto moneda_selected;
                }
            }
        }
        else
        {
            calculo = float.Parse(lista[3].ToString().Substring(2));

            if (RadioButtonList10.Items.FindByText("USD") != null)
            { if(RadioButtonList10.Items.FindByText("USD").Selected == true) goto moneda_selected; }

            if (RadioButtonList10.Items.FindByText("CUP") != null)
            { if(RadioButtonList10.Items.FindByText("CUP").Selected == true) goto moneda_selected; }

            if (RadioButtonList10.Items.FindByText("CUC") != null)
            { if(RadioButtonList10.Items.FindByText("CUC").Selected == true) goto moneda_selected; }

        }


        moneda_selected:
        Session["TCambio"] = null;
        Session["TCambio"] = calculo.ToString("F2");


        //Actualizar los mensajes
        if (contiene[0].ToString() == "USD") // si la moneda a debitar es USD
        {
            if (contiene[1].ToString() == "CUP") // si la moneda de la factura es CUP
            {
                string moneda_origen = contiene[0].ToString();
                string moneda_destino = contiene[1].ToString();

                // llamar al sp de carlos a traves del webservice 2 veces( de cup a cuc y de cuc a usd)
                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);

                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                {
                    calculo_usd = float.Parse(importes_debitar.Tables[0].Rows[1]["Importe"].ToString());
                    Session["TC_USD_CUC"] = calculo_usd.ToString("F2");

                    Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                    Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar.ToString() + " " + contiene[1].ToString() +
                        (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());

                    float t_cambio = float.Parse(Session["TC_USD_CUC"].ToString());
                    if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("USD").Selected == true && contiene[1] == "CUP"))
                    {
                        Button131.Enabled = false;
                        Label177.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.25 CUP es igual a 0";
                        Label177.Visible = true;
                    }
                    else
                    {
                        Button131.Enabled = true;
                        Label177.Visible = false;
                    }
                }

            }
            else if (contiene[1].ToString() == "CUC")
            {
                string moneda_origen = contiene[1].ToString();
                string moneda_destino = contiene[0].ToString();

                //DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);
                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_destino, moneda_origen, fecha, importe_acreditar);
                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                {
                    calculo_usd = float.Parse(importes_debitar.Tables[0].Rows[0]["Importe"].ToString());
                    Session["TC_USD_CUC"] = calculo_usd.ToString("F2");

                    if (moneda_origen == "CUC" && moneda_destino == "USD")
                    {
                        Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                        Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar + " " + contiene[1].ToString() +
                            (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());
                    }
                    else
                    {
                        Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                        Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar + " " + contiene[0].ToString() +
                            (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());
                    }

                    float t_cambio = float.Parse(Session["TC_USD_CUC"].ToString());
                    if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("USD").Selected == true && contiene[1] == "CUC"))
                    {
                        Button131.Enabled = false;
                        Label177.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.25 CUC es igual a 0";
                        Label177.Visible = true;
                    }
                    else
                    {
                        Button131.Enabled = true;
                        Label177.Visible = false;
                    }
                }

            }
        }
        else
        {
            Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
            Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + lista[3].ToString().Substring(2) + " " + contiene[1].ToString() +
                            (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + Session["TCambio"].ToString() + " " + contiene[0].ToString());

            float t_cambio = float.Parse(Session["TCambio"].ToString());
            if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("CUC").Selected == true && contiene[1] == "CUP"))
            {
                Button131.Enabled = false;
                Label177.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
                Label177.Visible = true;
            }
            else
            {
                Button131.Enabled = true;
                Label177.Visible = false;
            }
        }


    }


    #region <Raul: (Boton Anterior a lo nuevo USD) Boton de Aceptar el Pago cuando selecciona la moneda con la q va a pagar>
    //protected void Button131_Click(object sender, EventArgs e)
    //{
    //    List<object> contiene = (List<object>)Session["contiene"];
    //    string[] lista1 = (string[])contiene[2];


    //    bool moneda;

    //    try
    //    {
    //        if (contiene[0].ToString() == "CUC")
    //        {
    //            moneda = true;
    //        }
    //        else if (contiene[0].ToString() == "CUP")
    //        {
    //            moneda = false;
    //        }
    //        else
    //        {
    //            return;
    //        }

    //        if (contiene[0].ToString() != contiene[1].ToString())
    //        {
    //            //lista1[3] = "02" + Session["TCambio"].ToString();//Importe
    //            Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
    //        }
    //        else
    //            Session["codServicio"] = Session["codServicio"];


    //        string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
    //        Errores.Alert(this, traza);

    //        if (((string)Session["codServicio"] == "09") || ((string)Session["codServicio"] == "59"))
    //        {
    //            DetailsView2.DataBind();
    //            TextBox74.Text = "";
    //            TextBox77.Text = "";
    //            //GridView11.SelectedIndex = -1;
    //            ASPxGridView3.FocusedRowIndex = -1;

    //            if (DetailsView2.Rows.Count == 0)
    //            {
    //                EstadoNavegPago.UltimaPagina = 4;
    //                MVWPago.ActiveViewIndex = 4;
    //            }
    //        }

    //        if (((string)Session["codServicio"] == "08") || ((string)Session["codServicio"] == "58"))
    //        {
    //            DetailsView1.DataBind();

    //            if (DetailsView1.Rows.Count == 0)
    //            {
    //                EstadoNavegPago.UltimaPagina = 4;
    //                MVWPago.ActiveViewIndex = 4;
    //            }
    //        }

    //        if (((string)Session["codServicio"] == "07") || ((string)Session["codServicio"] == "57"))
    //        {
    //            DropDownList17.ClearSelection();
    //            DropDownList18.ClearSelection();
    //            GridView7.SelectedIndex = -1;
    //            RadioButtonList7.ClearSelection();
    //            TextBox51.Text = "";
    //            TextBox52.Text = "00";
    //            Label10.Text = "";

    //            EstadoNavegPago.UltimaPagina = 4;
    //            MVWPago.ActiveViewIndex = 4;
    //        }

    //        if (((string)Session["codServicio"] == "06") || ((string)Session["codServicio"] == "56"))
    //        {
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            TextBox64.Text = "";
    //            TextBox65.Text = "00";
    //            TextBox68.Text = "";
    //            TextBox69.Text = "";
    //            TextBox70.Text = "";
    //            TextBox71.Text = "";
    //            DropDownList12.ClearSelection();

    //            TextBox64.Enabled = true;
    //            TextBox65.Enabled = true;
    //            TextBox68.Enabled = true;
    //            TextBox69.Enabled = true;
    //            TextBox70.Enabled = true;
    //            TextBox71.Enabled = true;
    //            DropDownList12.Enabled = true;

    //            Button119.Enabled = true;
    //            Button122.Enabled = false;
    //            Button120.Enabled = false;
    //            Button123.Enabled = false;

    //            Label47.Text = "";


    //            Calendar18.SelectedDate = DateTime.Today;
    //            Button122.Enabled = false;
    //            Button120.Enabled = false;
    //            Label46.Text = "?";
    //            Label47.Text = "";
    //            Label48.Text = "";
    //            Label49.Text = "";
    //            Label50.Text = "";
    //            Label51.Text = "";
    //            Label52.Text = "";
    //            Label61.Text = "";
    //            Label62.Text = "";
    //            Label63.Text = "";
    //            Label65.Text = "";
    //            Label67.Text = "";
    //            Image1.Visible = false;
    //            Image2.Visible = false;
    //            Image3.Visible = false;
    //            Image4.Visible = false;
    //            Image5.Visible = false;
    //            Image6.Visible = false;
    //            Image7.Visible = false;
    //            Image8.Visible = false;
    //            Image9.Visible = false;
    //            Image10.Visible = false;
    //            Image11.Visible = false;
    //            Image12.Visible = false;
    //            Image13.Visible = false;
    //            Image14.Visible = false;
    //            Image15.Visible = false;
    //            Image16.Visible = false;

    //            CI_Pago.Value = "";

    //        }

    //        if (((string)Session["codServicio"] == "04") || ((string)Session["codServicio"] == "54"))
    //        {
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Button13.Enabled = true;
    //            Calendar10.SelectedDate = DateTime.Now;
    //            TextBox55.Text = "";
    //            DropDownList13.ClearSelection();
    //            DropDownList14.ClearSelection();
    //            DropDownList15.ClearSelection();
    //            DropDownList16.ClearSelection();

    //            Label37.Text = "";
    //            Label39.Text = "";
    //            Label134.Text = "Fecha";
    //            Label134.ForeColor = System.Drawing.Color.Black;
    //            Button99.Enabled = false;
    //            CI_Pago.Value = "";

    //            //RegularExpressionValidator33.Visible = false;
    //            //RegularExpressionValidator34.Visible = false;
    //            //RegularExpressionValidator35.Visible = false;
    //            //RegularExpressionValidator36.Visible = false;
    //            //RegularExpressionValidator37.Visible = false;
    //            //Habilitar textbox
    //            DropDownList13.Enabled = true;
    //            DropDownList14.Enabled = true;
    //            DropDownList15.Enabled = true;
    //            TextBox55.Enabled = true;
    //            Calendar10.Enabled = true;
    //        }

    //        if (((string)Session["codServicio"] == "03") || ((string)Session["codServicio"] == "53"))
    //        {
    //            if (RadioButtonList9.Items.Count == 2)
    //            {
    //                RadioButtonList9.Items.FindByText("CUC").Selected = false;
    //                RadioButtonList9.Items.FindByText("CUC").Enabled = true;
    //                RadioButtonList9.Items.FindByText("CUP").Selected = false;
    //                RadioButtonList9.Items.FindByText("CUP").Enabled = true;
    //            }
    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Button13.Enabled = false;
    //        }

    //        if (((string)Session["codServicio"] == "01") || ((string)Session["codServicio"] == "51") || ((string)Session["codServicio"] == "02") || ((string)Session["codServicio"] == "52") || ((string)Session["codServicio"] == "05") || ((string)Session["codServicio"] == "55") || ((string)Session["codServicio"] == "11") || ((string)Session["codServicio"] == "61"))
    //        {

    //            EstadoNavegPago.UltimaPagina = 5;
    //            MVWPago.ActiveViewIndex = 5;
    //            Button13.Enabled = true;
    //            asociadosSevPago.SelectedIndex = -1;
    //        }
    //        //Salir
    //        Session.Remove("contiene");
    //        Session.Remove("TCambio");
    //        RadioButtonList10.ClearSelection();
    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        EstadoNavegPago.UltimaPagina = 4;
    //        MVWPago.ActiveViewIndex = 4;
    //        RadioButtonList10.ClearSelection();
    //    }
    //}
    #endregion

    protected void Button131_Click(object sender, EventArgs e)
    {
        List<object> contiene = (List<object>)Session["contiene"];
        string[] lista1 = (string[])contiene[2];


        int moneda;

        try
        {
            if (contiene[0].ToString() == "CUC")
            {
                moneda = 1;
            }
            else if (contiene[0].ToString() == "CUP")
            {
                moneda = 0;
            }
            else if (contiene[0].ToString() == "USD")
            {
                moneda = 2;
            }
            else
            {
                return;
            }

            if (contiene[0].ToString() != contiene[1].ToString())
            {
                //lista1[3] = "02" + Session["TCambio"].ToString();//Importe
                Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
            }
            else
                Session["codServicio"] = Session["codServicio"];


            string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
            Errores.Alert(this, traza);

            if (((string)Session["codServicio"] == "09") || ((string)Session["codServicio"] == "59"))
            {
                DetailsView2.DataBind();
                TextBox74.Text = "";
                TextBox77.Text = "";
                //GridView11.SelectedIndex = -1;
                ASPxGridView3.FocusedRowIndex = -1;

                if (DetailsView2.Rows.Count == 0)
                {
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;
                }
            }

            if (((string)Session["codServicio"] == "08") || ((string)Session["codServicio"] == "58"))
            {
                DetailsView1.DataBind();

                if (DetailsView1.Rows.Count == 0)
                {
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;
                }
            }

            if (((string)Session["codServicio"] == "07") || ((string)Session["codServicio"] == "57"))
            {
                DropDownList17.ClearSelection();
                DropDownList18.ClearSelection();
                GridView7.SelectedIndex = -1;
                RadioButtonList7.ClearSelection();
                TextBox51.Text = "";
                TextBox52.Text = "00";
                Label10.Text = "";

                EstadoNavegPago.UltimaPagina = 4;
                MVWPago.ActiveViewIndex = 4;
            }

            if (((string)Session["codServicio"] == "06") || ((string)Session["codServicio"] == "56"))
            {
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                TextBox64.Text = "";
                TextBox65.Text = "00";
                TextBox68.Text = "";
                TextBox69.Text = "";
                TextBox70.Text = "";
                TextBox71.Text = "";
                DropDownList12.ClearSelection();

                TextBox64.Enabled = true;
                TextBox65.Enabled = true;
                TextBox68.Enabled = true;
                TextBox69.Enabled = true;
                TextBox70.Enabled = true;
                TextBox71.Enabled = true;
                DropDownList12.Enabled = true;

                Button119.Enabled = true;
                Button122.Enabled = false;
                Button120.Enabled = false;
                Button123.Enabled = false;

                Label47.Text = "";


                Calendar18.SelectedDate = DateTime.Today;
                Button122.Enabled = false;
                Button120.Enabled = false;
                Label46.Text = "?";
                Label47.Text = "";
                Label48.Text = "";
                Label49.Text = "";
                Label50.Text = "";
                Label51.Text = "";
                Label52.Text = "";
                Label61.Text = "";
                Label62.Text = "";
                Label63.Text = "";
                Label65.Text = "";
                Label67.Text = "";
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
                Image6.Visible = false;
                Image7.Visible = false;
                Image8.Visible = false;
                Image9.Visible = false;
                Image10.Visible = false;
                Image11.Visible = false;
                Image12.Visible = false;
                Image13.Visible = false;
                Image14.Visible = false;
                Image15.Visible = false;
                Image16.Visible = false;

                CI_Pago.Value = "";

            }

            if (((string)Session["codServicio"] == "04") || ((string)Session["codServicio"] == "54"))
            {
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                Button13.Enabled = true;
                Calendar10.SelectedDate = DateTime.Now;
                TextBox55.Text = "";
                DropDownList13.ClearSelection();
                DropDownList14.ClearSelection();
                DropDownList15.ClearSelection();
                DropDownList16.ClearSelection();

                Label37.Text = "";
                Label39.Text = "";
                Label134.Text = "Fecha";
                Label134.ForeColor = System.Drawing.Color.Black;
                Button99.Enabled = false;
                CI_Pago.Value = "";

                //RegularExpressionValidator33.Visible = false;
                //RegularExpressionValidator34.Visible = false;
                //RegularExpressionValidator35.Visible = false;
                //RegularExpressionValidator36.Visible = false;
                //RegularExpressionValidator37.Visible = false;
                //Habilitar textbox
                DropDownList13.Enabled = true;
                DropDownList14.Enabled = true;
                DropDownList15.Enabled = true;
                TextBox55.Enabled = true;
                Calendar10.Enabled = true;
            }

            if (((string)Session["codServicio"] == "03") || ((string)Session["codServicio"] == "53"))
            {
                if (RadioButtonList9.Items.Count >= 2)
                {
                    if (RadioButtonList9.Items.FindByText("CUC") != null)
                    {
                        RadioButtonList9.Items.FindByText("CUC").Selected = false;
                        RadioButtonList9.Items.FindByText("CUC").Enabled = true;
                    }
                    if (RadioButtonList9.Items.FindByText("CUP") != null)
                    {
                        RadioButtonList9.Items.FindByText("CUP").Selected = false;
                        RadioButtonList9.Items.FindByText("CUP").Enabled = true;                        
                    }
                    if (RadioButtonList9.Items.FindByText("USD") != null)
                    {
                        RadioButtonList9.Items.FindByText("USD").Selected = false;
                        RadioButtonList9.Items.FindByText("USD").Enabled = true;                        
                    }


                }
                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                //Button13.Enabled = false;
                Button13.Enabled = true;
            }

            if (((string)Session["codServicio"] == "01") || ((string)Session["codServicio"] == "51") || ((string)Session["codServicio"] == "02") || ((string)Session["codServicio"] == "52") || ((string)Session["codServicio"] == "05") || ((string)Session["codServicio"] == "55") || ((string)Session["codServicio"] == "11") || ((string)Session["codServicio"] == "61"))
            {

                EstadoNavegPago.UltimaPagina = 5;
                MVWPago.ActiveViewIndex = 5;
                Button13.Enabled = true;
                asociadosSevPago.SelectedIndex = -1;
            }
            //Salir
            Session.Remove("contiene");
            Session.Remove("TCambio");
            RadioButtonList10.ClearSelection();
        }
        catch (Exception ex)
        {
            Session["Texto_Error"] = "";

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            EstadoNavegPago.UltimaPagina = 4;
            MVWPago.ActiveViewIndex = 4;
            RadioButtonList10.ClearSelection();

            /*nuevo*/
                //SqlConnection conx = new SqlConnection();

                //try
                //{
                //    string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                //    conx.ConnectionString = cadena_conexion;
                //    conx.Open();                  

                //    SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','Pago_Servicio',GETDATE(),'Intenta pagar el id_asociado: " + lista1[2].ToString().Trim() + " con moneda: " + contiene[0].ToString().Trim() + " con el importe: " + lista1[3].Substring(2).ToString().Trim() + ". Operador que atiende: "++,'ERROR PAGO SERVICIO: " + ex.Message.Trim() + "')", conx);
                //    int i = cm.ExecuteNonQuery();


                //}
                //catch (Exception ex1)
                //{
                //    enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
                //    Session["Texto_Error"] = enviar_error;
                //    Response.Redirect("~/Error500.aspx");
                //    //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

                //}

                //conx.Close();
                //enviar_error = ex.Message.ToString().Trim();
                //Session["Texto_Error"] = enviar_error;
                //Response.Redirect("~/Error500.aspx");

            /*/nuevo*/
        }
    }
    
    protected void View53_Activate(object sender, EventArgs e)
    {
        List<object> contiene = (List<object>)Session["contiene"];

        float calculo = 0;

        string[] lista = (string[])contiene[2];
        //string inform = lista[5];

        //Calcular cambio
        if (contiene[1].ToString() == "CUP")
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) / 24;
        }
        if (contiene[1].ToString() == "CUC")
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) * 25;
        }

        //Session["TCambio"] = calculo.ToString("F2");

        Session["TCambio"] = null;

        if (float.Parse(calculo.ToString("F2")) <= 0.00)
        {
            Label176.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
            Label176.Enabled = true;
            Button98.Enabled = false;
        }        

        if (Session["codServicio"].ToString() == "07" || Session["codServicio"].ToString() == "57")
        {
            Session["TCambio"] = calculo.ToString("F2");
            Label144.Text = "Enviando Transferencia en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
            Label145.Text = "Importe Real: " + lista[3].ToString().Substring(2) + " " + contiene[1].ToString() + " CAMBIO: " + Session["TCambio"].ToString() + " " + contiene[0].ToString();
        }
        else
        {
            Session["TCambio"] = calculo.ToString("F2");
            Label144.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
            Label145.Text = "Importe Real: " + lista[3].ToString().Substring(2) + " " + contiene[1].ToString() + " CAMBIO: " + Session["TCambio"].ToString() + " " + contiene[0].ToString();
        }

    }
    
    protected void View54_Activate(object sender, EventArgs e)
    {
        List<object> contiene = (List<object>)Session["contiene"]; // contiene[0]: moneda con la que va a pagar el servicio    -------- origen
                                                                   // contiene[1]: moneda de la factura del servicio que va a pagar --- destino            

        string Tarjeta = Session["NoTarjeta"].ToString();
        float calculo = 0;
        float calculo_usd = 0;
        //float calculo_cuc = 0;
        DateTime fecha = DateTime.Now;

        string[] lista = (string[])contiene[2];
        
        float importe_acreditar = float.Parse(lista[3].ToString().Substring(2));
        //string inform = lista[5];

        DataSet DT = new DataSet();
        DT = Servicio.Monedas(Tarjeta);
        if (RadioButtonList10.Items.Count == 0)
            foreach (DataRow Row in DT.Tables[0].Rows)
                RadioButtonList10.Items.Add(Row[1].ToString());

        //Calcular cambio
        if (contiene[1].ToString() == "CUP" && contiene[0].ToString() != "USD")
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) / 24;
            if (RadioButtonList10.Items.FindByText("CUP") != null)
                RadioButtonList10.Items.FindByText("CUP").Selected = true;
            if (RadioButtonList10.Items.FindByText("USD") != null)
                RadioButtonList10.Items.FindByText("USD").Selected = true;
        }
        if (contiene[1].ToString() == "CUC" && contiene[0].ToString() != "USD")
        {
            calculo = float.Parse(lista[3].ToString().Substring(2)) * 25;
            if (RadioButtonList10.Items.FindByText("CUC") != null)
                RadioButtonList10.Items.FindByText("CUC").Selected = true;
            if (RadioButtonList10.Items.FindByText("USD") != null)
                RadioButtonList10.Items.FindByText("USD").Selected = true;
        }
        else
        {
            calculo = float.Parse(lista[3].ToString().Substring(2));

            if (RadioButtonList10.Items.FindByText("USD") != null)
            { RadioButtonList10.Items.FindByText("USD").Selected = true; goto moneda_selected; }

            if (RadioButtonList10.Items.FindByText("CUP") != null)
            { RadioButtonList10.Items.FindByText("CUP").Selected = true; goto moneda_selected; }

            if (RadioButtonList10.Items.FindByText("CUC") != null)
            { RadioButtonList10.Items.FindByText("CUC").Selected = true; goto moneda_selected; }
                
        }


        moneda_selected:
        Session["TCambio"] = null;
        Session["TCambio"] = calculo.ToString("F2");


        if (float.Parse(calculo.ToString("F2")) <= 0.00 && contiene[0] == "CUC")
        {
            Label177.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
            Label177.Enabled = true;
            Button131.Enabled = false;
        }
        else
        {
            Label177.Visible = false;
            Button131.Enabled = true;
        }

        contiene[0] = RadioButtonList10.SelectedItem.Text.ToString();

        // calculo de tc del USD

        if (contiene[0].ToString() == "USD")
        {
            if (contiene[1].ToString() == "CUP")
            {
                string moneda_origen = contiene[0].ToString();
                string moneda_destino = contiene[1].ToString();

                //calculo_cuc = float.Parse(lista[3].ToString().Substring(2).Trim()) / 24;
                //float variab = float.Parse(calculo_cuc.ToString("F2"));

                //moneda_origen = "CUC";
                //moneda_destino = contiene[0].ToString();


                // llamar al sp de lizardo a traves del webservice 2 veces( de cup a cuc y de cuc a usd)
                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);

                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                {
                    calculo_usd = float.Parse(importes_debitar.Tables[0].Rows[1]["Importe"].ToString());
                    Session["TC_USD_CUC"] = calculo_usd.ToString("F2");

                    Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                    Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar.ToString() + " " + contiene[1].ToString() +
                        (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());

                    float t_cambio = float.Parse(Session["TC_USD_CUC"].ToString());
                    Session["TCambio"] = t_cambio;
                    if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("USD").Selected == true && contiene[1] == "CUP"))
                    {
                        Button131.Enabled = false;
                        Label177.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.25 CUP es igual a 0";
                        Label177.Visible = true;
                    }
                    else
                    {
                        Button131.Enabled = true;
                        Label177.Visible = false;
                    }
                }

            }
            else if (contiene[1].ToString() == "CUC")
            {
                string moneda_origen = contiene[1].ToString();
                string moneda_destino = contiene[0].ToString();

                //DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);
                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_destino, moneda_origen, fecha, importe_acreditar);
                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                {
                    calculo_usd = float.Parse(importes_debitar.Tables[0].Rows[0]["Importe"].ToString());
                    Session["TC_USD_CUC"] = calculo_usd.ToString("F2");

                    if (moneda_origen == "CUC" && moneda_destino == "USD")
                    {
                        Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                        Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar + " " + contiene[1].ToString() +
                            (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());
                    }
                    else                    
                    { 
                        Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
                        Label147.Text = "Importe " + (contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + importe_acreditar + " " + contiene[0].ToString() +
                            (contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + calculo_usd.ToString() + " " + contiene[0].ToString());
                    }

                    float t_cambio = float.Parse(Session["TC_USD_CUC"].ToString());
                    Session["TCambio"] = t_cambio;
                    if (t_cambio <= 0.00 && (RadioButtonList10.Items.FindByText("USD").Selected == true && contiene[1] == "CUC"))
                    {
                        Button131.Enabled = false;
                        Label177.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.25 CUC es igual a 0";
                        Label177.Visible = true;
                    }
                    else
                    {
                        Button131.Enabled = true;
                        Label177.Visible = false;
                    }
                }

            }
        }
        // fin del calculo de tc del USD
        else
        {
            Label146.Text = "Pagando Servicio en " + contiene[1].ToString() + " con cuenta en " + contiene[0].ToString();
            Label147.Text = "Importe " + ((contiene[0].ToString() == contiene[1].ToString() ? "" : "Real: ") + lista[3].ToString().Substring(2) + " " + contiene[1].ToString()) +
                            ((contiene[0].ToString() == contiene[1].ToString() ? "" : " CAMBIO: " + Session["TCambio"].ToString() + " " + contiene[0].ToString()));
        }



    }
    protected void Button133_Click(object sender, EventArgs e)
    {
        if(RadioButtonList12.SelectedValue == "0")
        {
            MVWPago.ActiveViewIndex = 51;
        }
        if (RadioButtonList12.SelectedValue == "1")
        {
            MVWPago.ActiveViewIndex = 56;
        }
    }
    protected void View55_Activate(object sender, EventArgs e)
    {
        RadioButtonList12.SelectedIndex = -1;
    }
    protected void RadioButtonList14_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList14.SelectedIndex != -1)
        {
            TextBox78.Text = "";
            TextBox78.Enabled = false;
            RadioButtonList15.ClearSelection();
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT1 = new DataSet();
            DT1 = Servicio.ConsultarSaldoIntegrada(Tarjeta);

            if (RadioButtonList14.SelectedValue.ToString() == "CUP")
            {
                if (DT1.Tables[0].Rows[0][2].ToString() == Tarjeta && DT1.Tables[0].Rows[0][3].ToString() == "CUP")
                {
                    TextBox66.Text = DT1.Tables[0].Rows[0][1].ToString().Substring(0, 4);
                    TextBox67.Text = DT1.Tables[0].Rows[0][1].ToString().Substring(5, 4);
                    TextBox72.Text = DT1.Tables[0].Rows[0][1].ToString().Substring(10, 4);
                    TextBox73.Text = DT1.Tables[0].Rows[0][1].ToString().Substring(15, 4);
                    TextBox76.Text = DT1.Tables[0].Rows[0][0].ToString();

                    RadioButtonList13.Items.FindByText("CUP").Enabled = false;
                    RadioButtonList13.Items.FindByText("CUC").Enabled = true;
                    RadioButtonList13.Items.FindByText("CUP").Selected = false;
                    Label152.Text = "CUP";
                    Button136.Enabled = true;
                    Label150.Text = "";
                    Label160.Text = "";
                    Label161.Text = "";
                    Label159.Text = "";
                    TextBox66.Enabled = false;
                    TextBox67.Enabled = false;
                    TextBox72.Enabled = false;
                    TextBox73.Enabled = false;
                    TextBox76.Enabled = false;
                    Button134.Enabled = false;

                }
               
            }
            if (RadioButtonList14.SelectedValue.ToString() == "CUC")
            {
                if (DT1.Tables[0].Rows[1][2].ToString() == Tarjeta && DT1.Tables[0].Rows[1][3].ToString() == "CUC")
                {
                    TextBox66.Text = DT1.Tables[0].Rows[1][1].ToString().Substring(0, 4);
                    TextBox67.Text = DT1.Tables[0].Rows[1][1].ToString().Substring(5, 4);
                    TextBox72.Text = DT1.Tables[0].Rows[1][1].ToString().Substring(10, 4);
                    TextBox73.Text = DT1.Tables[0].Rows[1][1].ToString().Substring(15, 4);
                    TextBox76.Text = DT1.Tables[0].Rows[1][0].ToString();

                    RadioButtonList13.Items.FindByText("CUC").Enabled = false;
                    RadioButtonList13.Items.FindByText("CUP").Enabled = true;
                    RadioButtonList13.Items.FindByText("CUC").Selected = false;
                    Label152.Text = "CUC";
                    Button136.Enabled = true;
                    Label150.Text = "";
                    Label160.Text = "";
                    Label161.Text = "";
                    Label159.Text = "";
                    TextBox66.Enabled = false;
                    TextBox67.Enabled = false;
                    TextBox72.Enabled = false;
                    TextBox73.Enabled = false;
                    TextBox76.Enabled = false;
                    Button134.Enabled = false;
                }
            }

        }       

       

    }
    protected void RadioButtonList15_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButtonList14.ClearSelection();
            RadioButtonList13.ClearSelection();
            Button134.Enabled = false;
            Button136.Enabled = true;
            TextBox78.Text = "";
            TextBox78.Enabled = false;

            if (RadioButtonList13.Items.Count >= 2)
            {
                //if (RadioButtonList9.Items.FindByText("CUC") != null)
                //{ 
                //    RadioButtonList13.Items.FindByText("CUC").Enabled = true;
                //    RadioButtonList13.Items.FindByText("CUC").Selected = false;
                //}
                //if (RadioButtonList9.Items.FindByText("CUP") != null)
                //{
                //    RadioButtonList13.Items.FindByText("CUP").Enabled = true;
                //    RadioButtonList13.Items.FindByText("CUP").Selected = false;
                //}
                if (RadioButtonList9.Items.FindByText("USD") != null)
                {
                    RadioButtonList13.Items.FindByText("USD").Enabled = true;
                    RadioButtonList13.Items.FindByText("USD").Selected = false;
                }            
            }
      
            if (RadioButtonList15.SelectedValue.ToString() == "0")
            {
                TextBox66.Text = "";
                TextBox67.Text = "";
                TextBox72.Text = "";
                TextBox73.Text = "";
                TextBox76.Text = "";
                Label150.Text = "";
                Label152.Text = "";
                Label159.Text = "";
                Label160.Text = "";
                Label161.Text = "";
                TextBox66.Enabled = true;
                TextBox67.Enabled = true;
                TextBox72.Enabled = true;
                TextBox73.Enabled = true;
                TextBox76.Enabled = false;

            }
       
            if (RadioButtonList15.SelectedValue.ToString() == "1")
            {
            
                TextBox66.Text = "";
                TextBox67.Text = "";
                TextBox72.Text = "";
                TextBox73.Text = "";
                TextBox76.Text = "";
                Label150.Text = "";
                Label152.Text = "";
                Label159.Text = "";
                Label160.Text = "";
                Label161.Text = "";
                TextBox66.Enabled = false;
                TextBox67.Enabled = false;
                TextBox72.Enabled = false;
                TextBox73.Enabled = false;
                TextBox76.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            /*nuevo*/
            SqlConnection conx = new SqlConnection();

            try
            {
                string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                conx.ConnectionString = cadena_conexion;
                conx.Open();

                SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','Pago_Servicio',GETDATE(),'Intenta seleccionar Tarjeta magnetica o Cta estandarizada destino a Transferir','ERROR: RadioButtonList15: '" + ex.Message.Trim() + ")", conx);
                int i = cm.ExecuteNonQuery();

            }
            catch (Exception ex1)
            {
                enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
                Session["Texto_Error"] = enviar_error;
                Response.Redirect("~/Error500.aspx");
                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
            }

            conx.Close();
            //enviar_error = ex.Message.ToString().Trim();
            //Session["Texto_Error"] = enviar_error;
            //Response.Redirect("~/Error500.aspx");
            //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

            /*/nuevo*/
        }

        
    }
    protected void View56_Activate(object sender, EventArgs e)
    {
        string Tarjeta = Session["NoTarjeta"].ToString();
        RadioButtonList13.Items.Clear();
        DataSet DT = new DataSet();
        DT = Servicio.Monedas(Tarjeta);
        if (RadioButtonList13.Items.Count == 0)
            foreach (DataRow Row in DT.Tables[0].Rows)
            {
                RadioButtonList13.Items.Add(Row[1].ToString());
            }


        int cantidad = DT.Tables[0].Rows.Count;

        if (cantidad == 1)
        {
            RadioButtonList14.Enabled = false;
            RadioButtonList14.Visible = false;
            RadioButtonList15.Enabled = true;
            
        }

        if (cantidad >= 2)
        {
            RadioButtonList14.Visible = true;
            RadioButtonList14.Enabled = true;
        }
        
        
        RadioButtonList15.ClearSelection();
        RadioButtonList14.ClearSelection();
        RadioButtonList13.ClearSelection();
        TextBox66.Text = "";
        TextBox67.Text = "";
        TextBox72.Text = "";
        TextBox73.Text = "";
        TextBox76.Text = "";
        TextBox78.Text = "";
        Label160.Text = "";
        Label161.Text = "";
        Label150.Text = "";
        Label152.Text = "";
        Label159.Text = "";
        Button134.Enabled = false;
    }

    #region <Raul: (Anterior a lo del USD) Seleccionar la moneda desde donde va a transferir.>
    //protected void RadioButtonList13_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (TextBox78.Text != "")
    //        {
    //            RegularExpressionValidator34.Validate();
    //            bool valido = RegularExpressionValidator34.IsValid;
    //            if (!valido)
    //            {
    //                TextBox78.Focus();
    //                RadioButtonList13.ClearSelection();
    //            }
    //            else
    //            {
    //                Label159.Text = "";
    //                if (RadioButtonList13.SelectedItem.Text != Label152.Text)
    //                {

    //                    float calculo = 0;

    //                    //Calcular cambio
    //                    if (RadioButtonList13.SelectedItem.Text == "CUC")
    //                    {
    //                        calculo = float.Parse(TextBox78.Text.Trim()) / 24;
    //                    }
    //                    if (RadioButtonList13.SelectedItem.Text == "CUP")
    //                    {
    //                        calculo = float.Parse(TextBox78.Text.Trim()) * 25;
    //                    }

    //                    Session["TC"] = calculo.ToString("F2");
    //                    Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
    //                    TextBox78.Enabled = false;

    //                    //if (Convert.ToDouble(TextBox78.Text.Trim()) <= 0.11 && Label152.Text == "CUP") // condicion anterior con minimo 0.11 cup
    //                    if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.25 && Label152.Text == "CUP") // condicion actual minimo 0.25 cup
    //                    {
    //                        TextBox78.Enabled = false;
    //                        Button134.Enabled = false;
    //                        Label159.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
    //                    }
    //                }

    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

    //    }
    //}
    #endregion

    protected void RadioButtonList13_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TextBox78.Text != "")
            {
                RegularExpressionValidator34.Validate();
                bool valido = RegularExpressionValidator34.IsValid;
                if (!valido)
                {
                    TextBox78.Focus();
                    RadioButtonList13.ClearSelection();
                }
                else
                {
                    Label159.Text = "";
                    if (RadioButtonList13.SelectedItem.Text != Label152.Text)
                    {

                        float calculo = 0;
                        float calculo_usd = 0;

                        //Calcular cambio
                        if (RadioButtonList13.SelectedItem.Text == "CUC")
                        {
                            calculo = float.Parse(TextBox78.Text.Trim()) / 24;
                        }
                        if (RadioButtonList13.SelectedItem.Text == "CUP")
                        {
                            calculo = float.Parse(TextBox78.Text.Trim()) * 25;
                        }
                        if (RadioButtonList13.SelectedItem.Text == "USD")
                        {
                            if (Label152.Text == "CUP")
                            {
                                string moneda_origen = "USD";
                                string moneda_destino = Label152.Text;
                                DateTime fecha = DateTime.Now;
                                float importe_acreditar = float.Parse(TextBox78.Text.Trim());

                                // llamar al sp de lizardo a traves del webservice 2 veces( de cup a cuc y de cuc a usd)
                                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);

                                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                                {
                                    foreach (DataRow item in importes_debitar.Tables[0].Rows)
                                    {
                                        if (item["Moneda"].ToString() == "USD")
                                        {
                                            calculo_usd = float.Parse(item["Importe"].ToString());

                                            Session["TC_USD"] = calculo_usd.ToString("F2");
                                            Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC_USD"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
                                            TextBox78.Enabled = false;

                                            if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.25 && Label152.Text == "CUP") // condicion actual minimo 0.25 cup
                                            {
                                                TextBox78.Enabled = false;
                                                Button134.Enabled = false;
                                                Label159.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.25 CUP es igual a 0";
                                            }
                                        }
                                    }
                                }

                            }
                            else if (Label152.Text == "CUC")
                            {
                                string moneda_origen = "USD";
                                string moneda_destino = Label152.Text;
                                DateTime fecha = DateTime.Now;
                                float importe_acreditar = float.Parse(TextBox78.Text.Trim());

                                // llamar al sp de lizardo a traves del webservice 2 veces( de cup a cuc y de cuc a usd)
                                DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);

                                if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                                {
                                    //foreach (DataRow item in importes_debitar.Tables[1].Rows)
                                    foreach (DataRow item in importes_debitar.Tables[0].Rows)
                                    {
                                        //if (item["Moneda"].ToString() == "CUC")
                                        if (item["Moneda"].ToString() == "USD")
                                        {
                                            calculo_usd = float.Parse(item["Importe"].ToString());

                                            Session["TC_USD_CUC"] = calculo_usd.ToString("F2");
                                            Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC_USD_CUC"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
                                            TextBox78.Enabled = false;

                                            if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.05 && Label152.Text == "CUC") // condicion actual minimo 0.05 cuc
                                            {
                                                TextBox78.Enabled = false;
                                                Button134.Enabled = false;
                                                Label159.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.05 CUC es igual a 0";
                                            }
                                        }
                                    }
                                }
                            }
                            //else if (Label152.Text == "USD")
                            //{
                            //    string moneda_origen = "USD";
                            //    string moneda_destino = Label152.Text;
                            //    DateTime fecha = DateTime.Now;
                            //    float importe_acreditar = float.Parse(TextBox78.Text.Trim());

                            //    // llamar al sp de lizardo a traves del webservice 2 veces( de cup a cuc y de cuc a usd)
                            //    DataSet importes_debitar = Servicio.Importe_Conv_USD_to_CUP(moneda_origen, moneda_destino, fecha, importe_acreditar);

                            //    if (importes_debitar != null || importes_debitar.Tables.Count != 0)
                            //    {
                            //        foreach (DataRow item in importes_debitar.Tables[0].Rows)
                            //        {
                            //            if (item["Moneda"].ToString() == "CUC")
                            //            {
                            //                calculo_usd = float.Parse(item["Importe"].ToString());

                            //                Session["TC_USD_CUC"] = calculo_usd.ToString("F2");
                            //                Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC_USD_CUC"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
                            //                TextBox78.Enabled = false;

                            //                if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.05 && Label152.Text == "CUC") // condicion actual minimo 0.05 cuc
                            //                {
                            //                    TextBox78.Enabled = false;
                            //                    Button134.Enabled = false;
                            //                    Label159.Text = "Operación Denegada, la conversión a USD de un importe menor que 0.05 CUC es igual a 0";
                            //                }
                            //            }
                            //        }
                            //    }
                            //}

                        }
                        else if (Label152.Text == "USD" && RadioButtonList13.SelectedItem.Text != Label152.Text)
                        {
                            TextBox78.Enabled = false;
                            Button134.Enabled = false;
                            Label159.Text = "Operación Denegada, no puede transferir de una cuenta CUP o CUC hacia una USD";
                        }
                        else
                        {
                            Session["TC"] = calculo.ToString("F2");
                            Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
                            TextBox78.Enabled = false;

                            //if (Convert.ToDouble(TextBox78.Text.Trim()) <= 0.11 && Label152.Text == "CUP") // condicion anterior con minimo 0.11 cup
                            if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.25 && Label152.Text == "CUP") // condicion actual minimo 0.25 cup
                            {
                                TextBox78.Enabled = false;
                                Button134.Enabled = false;
                                Label159.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
                            }
                        }
                    }
                    else if (RadioButtonList13.SelectedItem.Text != Label152.Text && RadioButtonList13.SelectedItem.Text !="USD")
                    {
                        float calculo = 0;

                        //Calcular cambio
                        if (RadioButtonList13.SelectedItem.Text == "CUC")
                        {
                            calculo = float.Parse(TextBox78.Text.Trim()) / 24;
                        }
                        if (RadioButtonList13.SelectedItem.Text == "CUP")
                        {
                            calculo = float.Parse(TextBox78.Text.Trim()) * 25;
                        }

                        Session["TC"] = calculo.ToString("F2");
                        Label159.Text = "Se aplicará tipo de cambio, se está transfiriendo " + Session["TC"].ToString() + " " + RadioButtonList13.SelectedItem.Text + " para recibir " + TextBox78.Text + " " + Label152.Text;
                        TextBox78.Enabled = false;

                        //if (Convert.ToDouble(TextBox78.Text.Trim()) <= 0.11 && Label152.Text == "CUP") // condicion anterior con minimo 0.11 cup
                        if (Convert.ToDouble(TextBox78.Text.Trim()) < 0.25 && Label152.Text == "CUP") // condicion actual minimo 0.25 cup
                        {
                            TextBox78.Enabled = false;
                            Button134.Enabled = false;
                            Label159.Text = "Operación Denegada, la conversión a CUC de un importe menor que 0.25 CUP es igual a 0";
                        }
                    }
                    else if (RadioButtonList13.SelectedItem.Text == Label152.Text)
                    {
                        Button134.Enabled = true;
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            
        }
    }
    protected void View57_Activate(object sender, EventArgs e)
    {
        TextBox75.Text = "";
        CheckBox4.Checked = false;
        TextBox75.Enabled = false;
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked)
        {
            TextBox75.Enabled = true;
            Button137.Enabled = true;
        }
        else
        {
            TextBox75.Enabled = false;
            TextBox75.Text = "";
        }
    }

    #region<Raul: (anterior a lo del USD) Boton Pagar Etecsa>
    // boton de pagar Etecsa
    //protected void Button137_Click(object sender, EventArgs e)
    //{
    //    string[] arreglo = new string[5];
    //    arreglo = (string[])Session["datosPComp1"];
    //    string[] dat = new string[5];
    //    bool moneda = false;
    //    string tipo_moneda = "";

    //    if (Label156.Text.Substring(2, 1) == "1")
    //        tipo_moneda = "CUP";
    //    if (Label156.Text.Substring(2, 1) == "2")
    //        tipo_moneda = "CUC";
    //    try
    //    {

    //        //nombre, importe, informativo
    //        if (GridView8.Rows.Count == 1)
    //        {

    //            dat[1] = Server.HtmlDecode(GridView8.Rows[0].Cells[1].Text.Trim());//Titular del Contrato
    //            dat[2] = GridView8.Rows[0].Cells[0].Text.Trim();//Id Asociado
    //            if (CheckBox4.Checked)
    //            {
    //                dat[03] = "02" + TextBox75.Text.Trim();//Importe
    //                dat[0] = "00000000";
    //                if (Convert.ToDouble(TextBox75.Text.Trim()) > Convert.ToDouble(GridView8.Rows[0].Cells[2].Text.Trim()))
    //                {
    //                    dat[04] = "12" + "Pago Parcial +";
    //                }
    //                if (Convert.ToDouble(TextBox75.Text.Trim()) < Convert.ToDouble(GridView8.Rows[0].Cells[2].Text.Trim()))
    //                {
    //                    dat[04] = "12" + "Pago Parcial -";
    //                }

    //            }
    //            else
    //            {
    //                dat[03] = "02" + GridView8.Rows[0].Cells[2].Text.Trim();//Importe
    //                dat[0] = arreglo[0];  //ID de la tabla de datos de factura
    //                dat[04] = "12" + "Pago Total";
    //            }
    //        }
    //        else
    //        {
    //            dat[0] = "00000000";
    //            dat[1] = "Teléfono de " + Label158.Text;
    //            dat[2] = Label156.Text; ;//Id Asociado
    //            dat[03] = "02" + TextBox75.Text.Trim();//Importe
    //            dat[04] = "12" + "Importe captado según lo informado por el Cliente ";
    //        }

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (mon_cue == "CUP")
    //        {
    //            moneda = false;
    //        }
    //        else if (mon_cue == "CUC")
    //        {
    //            moneda = true;
    //        }
    //        else
    //        {
    //            return;
    //        }


    //        if (cantidad == 1)
    //        {
    //            if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;

    //            }
    //            else
    //            {

    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);
    //                EstadoNavegPago.UltimaPagina = 5;
    //                MVWPago.ActiveViewIndex = 5;
    //            }
    //        }

    //        if (cantidad == 2) // si es > 1
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;

    //        }

    //        if (CheckBox4.Checked == true)
    //        {
    //            TextBox75.Text = "";
    //            CheckBox4.Checked = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

    //    }
    //}
    #endregion

    // boton de pagar Etecsa
    protected void Button137_Click(object sender, EventArgs e)
    {
        string[] arreglo = new string[5];
        arreglo = (string[])Session["datosPComp1"];
        string[] dat = new string[5];
        int moneda = 0;
        string mon_cue = "";
        string tipo_moneda = ""; // tipo de moneda de la factura

        if (Label156.Text.Substring(2, 1) == "1")
            tipo_moneda = "CUP";
        if (Label156.Text.Substring(2, 1) == "2")
            tipo_moneda = "CUC";
        try
        {

            //nombre, importe, informativo
            if (GridView8.Rows.Count == 1)
            {

                dat[1] = Server.HtmlDecode(GridView8.Rows[0].Cells[1].Text.Trim());//Titular del Contrato
                dat[2] = GridView8.Rows[0].Cells[0].Text.Trim();//Id Asociado
                if (CheckBox4.Checked)
                {
                    dat[03] = "02" + TextBox75.Text.Trim();//Importe
                    dat[0] = "00000000";
                    if (Convert.ToDouble(TextBox75.Text.Trim()) > Convert.ToDouble(GridView8.Rows[0].Cells[2].Text.Trim()))
                    {
                        dat[04] = "12" + "Pago Parcial +";
                    }
                    if (Convert.ToDouble(TextBox75.Text.Trim()) < Convert.ToDouble(GridView8.Rows[0].Cells[2].Text.Trim()))
                    {
                        dat[04] = "12" + "Pago Parcial -";
                    }
                    
                }
                else
                {
                    dat[03] = "02" + GridView8.Rows[0].Cells[2].Text.Trim();//Importe
                    dat[0] = arreglo[0];  //ID de la tabla de datos de factura
                    dat[04] = "12" + "Pago Total";
                }
            }
            else
            {
                dat[0] = "00000000";
                dat[1] = "Teléfono de " + Label158.Text;
                dat[2] = Label156.Text; ;//Id Asociado
                dat[03] = "02" + TextBox75.Text.Trim();//Importe
                dat[04] = "12" + "Importe captado según lo informado por el Cliente ";
            }

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            mon_cue = DT.Tables[0].Rows[0][1].ToString();

            if (mon_cue == "CUP")
            {
                moneda = 0;
            }
            else if (mon_cue == "CUC")
            {
                moneda = 1;
            }
            else if (mon_cue == "USD")
            {
                moneda = 2;
            }
            else
            {
                return;
            }


            if (cantidad == 1)
            {
                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")) || ((tipo_moneda == "CUP") && (mon_cue == "USD")) || ((tipo_moneda == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;

                }
                else
                {
                    
                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);
                    EstadoNavegPago.UltimaPagina = 5;
                    MVWPago.ActiveViewIndex = 5;
                }
            }

            if (cantidad == 2) // si es > 1
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }

            if (cantidad == 3) // si es > 2 incluye USD
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;

            }

            if (CheckBox4.Checked == true)
            {
                TextBox75.Text = "";
                CheckBox4.Checked = false;
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));

            /*nuevo*/
                //SqlConnection conx = new SqlConnection();

                //try
                //{
                //    string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                //    conx.ConnectionString = cadena_conexion;
                //    conx.Open();

                //    SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES(" + NoTarjeta + ",'','','','','','Pago_Servicio',GETDATE(),'Intenta pagar el id_asociado: " + dat[2].ToString().Trim() + " con moneda: " + mon_cue + " con el importe: " + dat[3].Substring(2).ToString().Trim() + "','ERROR PAGO SERVICIO: " + ex.Message.Trim() + "')", conx);
                //    int i = cm.ExecuteNonQuery();

                //}
                //catch (Exception ex1)
                //{
                //    enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
                //    Session["Texto_Error"] = enviar_error;
                //    Response.Redirect("~/Error500.aspx");
                //    //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
                //}

                //conx.Close();
                //enviar_error = ex.Message.ToString().Trim();
                //Session["Texto_Error"] = enviar_error;
                //Response.Redirect("~/Error500.aspx");
                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

            /*/nuevo*/
        }
    }
    protected void Button138_Click(object sender, EventArgs e)
    {
        TextBox75.Text = "";
        Label156.Text = "";
        Label157.Text = "";
        Label158.Text = "";
        Label164.Text = "";
        CheckBox4.Checked = false;
        GridView8.DataBind();
        EstadoNavegPago.UltimaPagina = 5;
        MVWPago.ActiveViewIndex = 5;
        
    }

    // boton procesar de Transferencia
    protected void Button136_Click(object sender, EventArgs e)
    {
        RadioButtonList13.ClearSelection();
        string Tarjeta = Session["NoTarjeta"].ToString();
        int tipo_d_cuenta = 2;
        string cuenta = "";
        bool filtro = false;
        bool deshabilitar = false;
        string moneda_d_cuenta = "";
        string sigla_moneda = "";
        DataSet info_cuenta = new DataSet();
        try
        {
            Label159.Text = "";
            DataSet NT = new DataSet();
            string banco = "";

            //Filtro para enviar a otros bancos por el SLBTR
            if (TextBox67.Text != "")
            {
                string cllamadas = Servicio.CLlamadas();
                string cllamadas1 = "";
                string cllamadas2 = "";
                

                if (cllamadas.Length.ToString() == "4") //Por los dos códigos de BPA
                {
                    cllamadas1 = cllamadas.ToString().Substring(0, 2);
                    cllamadas2 = cllamadas.ToString().Substring(2, 2);
                }


                if ((cllamadas != TextBox67.Text.Substring(0, 2)) || (cllamadas1 == TextBox67.Text.Substring(0, 2)) || (cllamadas2 == TextBox67.Text.Substring(0, 2)))
                {
                    if ((TextBox67.Text.Substring(0, 2) == "95") || (TextBox67.Text.Substring(0, 2) == "06") || (TextBox67.Text.Substring(0, 2) == "02") || (TextBox67.Text.Substring(0, 2) == "12"))
                    {
                        if (TextBox67.Text.Substring(0, 2) == "02" || TextBox67.Text.Substring(0, 2) == "12")
                        {
                            banco = "BPA - Banco Popular de Ahorro";
                        }
                        if (TextBox67.Text.Substring(0, 2) == "06")
                        {
                            banco = "BANDEC - Banco de Crédito y Comercio";
                        }
                        if (TextBox67.Text.Substring(0, 2) == "95")
                        {
                            banco = "BANMET - Banco Metropolitano";
                        }
                        filtro = false;
                        Label150.ForeColor = System.Drawing.Color.Red;
                        Label150.Text = "!Esta transferencia será enviada por el SLBTR - Sistema de Liquidación Bruta en Tiempo Real hacia una cuenta de " + banco;
                        Label152.Text = "";
                        Label159.Text = "";
                        Label160.Text = "";
                        Label161.Text = "";

                    }
                    else
                    {
                        filtro = false;
                        Label150.ForeColor = System.Drawing.Color.Red;
                        Label150.Text = "Error No. Tarjeta no válida, por favor verifíquela";
                        Label160.Text = "";
                        Label161.Text = "";
                    }

                }
                else
                {
                    filtro = true;
                }
            }
            else
            {
                filtro = false;
                Label150.ForeColor = System.Drawing.Color.Red;
                Label150.Text = "Error No. Tarjeta no válida, por favor verifíquela";
                Label160.Text = "";
                Label161.Text = "";
            }


            if (TextBox76.Text != "")
            {
                string cllamadas = Servicio.CLlamadas();
                string cllamadas3 = "";
                string cllamadas4 = "";

                if (cllamadas.Length.ToString() == "4") //Por los dos codigos de BPA
                {
                    cllamadas3 = cllamadas.ToString().Substring(0, 2);
                    cllamadas4 = cllamadas.ToString().Substring(2, 2);
                }

                if ((cllamadas.Substring(1, 1) != TextBox76.Text.Substring(1, 1)) || (cllamadas3 == TextBox76.Text.Substring(0, 2)) || (cllamadas4 == TextBox76.Text.Substring(0, 2)))
                {
                    if ((TextBox76.Text.Substring(0, 2) == "05") || (TextBox76.Text.Substring(0, 2) == "06") || (TextBox76.Text.Substring(0, 2) == "02") || (TextBox76.Text.Substring(0, 2) == "12"))
                    {
                        if (TextBox76.Text.Substring(0, 2) == "02" || TextBox76.Text.Substring(0, 2) == "12")
                        {
                            banco = "BPA - Banco Popular de Ahorro";
                        }
                        if (TextBox76.Text.Substring(0, 2) == "06")
                        {
                            banco = "BANDEC - Banco de Crédito y Comercio";
                        }
                        if (TextBox76.Text.Substring(0, 2) == "05")
                        {
                            banco = "BANMET - Banco Metropolitano";
                        }
                        filtro = false;
                        Label150.ForeColor = System.Drawing.Color.Red;
                        Label150.Text = "!Esta transferencia será enviada por el SLBTR - Sistema de Liquidación Bruta en Tiempo Real hacia una cuenta de " + banco;
                        Label152.Text = "";
                        Label159.Text = "";
                        Label160.Text = "";
                        Label161.Text = "";

                    }
                    else
                    {
                        filtro = false;
                        Label150.ForeColor = System.Drawing.Color.Red;
                        Label150.Text = "Error No. Cuenta no válida, por favor verifíquela";
                        Label160.Text = "";
                        Label161.Text = "";
                        TextBox78.Enabled = false;
                        RadioButtonList13.Enabled = false;
                    }

                }
                else
                {
                    filtro = true;
                }

            }

            if (filtro == true)
            {
                if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
                {
                    tipo_d_cuenta = 0;
                    cuenta = TextBox66.Text + TextBox67.Text + TextBox72.Text + TextBox73.Text;

                    try
                    {
                        info_cuenta = Servicio.Get_Info_Cuenta_Transferencia(cuenta);                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
                {
                    tipo_d_cuenta = 1;
                    cuenta = TextBox76.Text;
                }
                NT = Servicio.Titular(Tarjeta, tipo_d_cuenta, cuenta); //Llamar al metodo del webservice de metro para verificar la existencia del # de cuenta o # de tarjeta mágnetica
                string ver = NT.Tables[0].Rows[0][1].ToString();


                if (NT.Tables[0].Rows[0][1].ToString() != "true" || NT.Tables[0].Rows[0][1].ToString() != "false")
                {
                    if (RadioButtonList15.SelectedIndex != -1)
                    {
                        Label150.ForeColor = System.Drawing.Color.Red;
                        Label150.Text = "El " + RadioButtonList15.SelectedItem.Text.ToString() + " solicitada no es válida, por favor verifique";
                        Label152.Text = "";
                        Label159.Text = "";
                        Label160.Text = "";
                        Label161.Text = "";
                        Button134.Enabled = false;
                    }
                }

                if (NT.Tables[0].Rows[0][1].ToString() == "true")
                {
                    RadioButtonList13.Enabled = true;
                    TextBox78.Enabled = true;
                    Session["CD"] = moneda_d_cuenta;
                    if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
                    {                        
                        if (info_cuenta.Tables.Count > 0 && info_cuenta.Tables[0].Rows.Count > 0)
                        {
                            Label160.Text = moneda_d_cuenta = info_cuenta.Tables[0].Rows[0][2].ToString().Trim();
                        }
                        else
                        {
                            Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
                            deshabilitar = true;
                        }

                    }

                    if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
                    {
                        if (TextBox76.Text.Substring(14, 1) == "1")
                        {
                            Label161.Text = moneda_d_cuenta = "CUP";
                        }
                        if (TextBox76.Text.Substring(14, 1) == "2")
                        {
                            Label161.Text = moneda_d_cuenta = "CUC";
                        }
                        if (TextBox76.Text.Substring(14, 1) == "3")
                        {
                            Label161.Text = moneda_d_cuenta = "USD";
                        }

                    }
                    if (Label160.Text == "")
                    {
                        Label152.Text = Label161.Text;
                    }
                    else if (Label161.Text == "")
                    {
                        Label152.Text = Label160.Text;
                    }

                    Label150.ForeColor = System.Drawing.Color.LimeGreen;
                    Label150.Text = "Orden de Transferencia aceptada para " + NT.Tables[0].Rows[0][0].ToString();
                    Button134.Enabled = true;

                }
                if (NT.Tables[0].Rows[0][1].ToString() == "false")
                {
                    Label150.ForeColor = System.Drawing.Color.Red;
                    Label150.Text = "Orden de Transferencia NO aceptada";
                    Label152.Text = "";
                    Label159.Text = "";
                    TextBox78.Enabled = false;
                    TextBox78.Text = "";
                    Button134.Enabled = false;
                    RadioButtonList13.Enabled = false;
                }
            }
            if (filtro == false)
            {
                RadioButtonList13.Enabled = true;
                TextBox78.Enabled = true;
                Session["CD"] = moneda_d_cuenta;
                if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
                {

                    if (TextBox66.Text.Substring(0, 2) == "92" && TextBox67.Text.Substring(0,2) == "95")
                    {                        
                        if (info_cuenta.Tables.Count > 0 && info_cuenta.Tables[0].Rows.Count > 0)
                        {
                            Label160.Text = moneda_d_cuenta = info_cuenta.Tables[0].Rows[0][2].ToString().Trim();
                        }
                        else
                        {
                            Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
                            deshabilitar = true;
                        }
                    }
                    else if (TextBox66.Text.Substring(0, 2) == "92" && TextBox67.Text.Substring(0, 2) != "95")
                    {

                        if ((TextBox66.Text == "9204") || (TextBox66.Text == "9224") || (TextBox66.Text == "9205") || (TextBox66.Text == "9206") || (TextBox66.Text == "9212"))
                        {
                            Label160.Text = moneda_d_cuenta = "CUP";
                        }
                        else if ((TextBox66.Text == "9200") || (TextBox66.Text == "9202") || (TextBox66.Text == "9203") || (TextBox66.Text == "9210") || (TextBox66.Text == "9213"))
                        {
                            Label160.Text = moneda_d_cuenta = "CUC";
                        }
                        else if ((TextBox66.Text == "9225") || (TextBox66.Text == "9226"))
                        {
                            Label160.Text = moneda_d_cuenta = "USD";
                        }
                        else
                        {
                            Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
                            deshabilitar = true;
                        }
                    }
                    else
                    {
                        Label150.Text = "El # de Tarjeta Magnética a procesar no pertenece al código de RED (92## #### #### ####)";
                        TextBox78.Enabled = false;
                        RadioButtonList13.Enabled = false;
                        deshabilitar = true;
                    }
                }
                if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
                {
                    if (TextBox76.Text.Substring(14, 1) == "1")
                    {
                        Label161.Text = moneda_d_cuenta = "CUP";
                    }
                    if (TextBox76.Text.Substring(14, 1) == "2")
                    {
                        Label161.Text = moneda_d_cuenta = "CUC";
                    }
                    if (TextBox76.Text.Substring(14, 1) == "3")
                    {
                        Label161.Text = moneda_d_cuenta = "USD";
                    }

                }
                if (Label160.Text == "")
                {
                    Label152.Text = Label161.Text;
                }
                else if (Label161.Text == "")
                {
                    Label152.Text = Label160.Text;
                }

                if (deshabilitar)
                {
                    Button134.Enabled = false;
                }
                else
                { Button134.Enabled = true; }

            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }




    #region <Boton Procesar Transferencia Viejo>
    //protected void Button136_Click(object sender, EventArgs e)
    //{
    //    RadioButtonList13.ClearSelection();
    //    string Tarjeta = Session["NoTarjeta"].ToString();
    //    int tipo_d_cuenta = 2;
    //    string cuenta = "";
    //    bool filtro = false;
    //    bool deshabilitar = false;
    //    string moneda_d_cuenta = "";
    //    try
    //    {
    //        Label159.Text = "";
    //        DataSet NT = new DataSet();
    //        string banco = "";


    //        //Filtro para enviar a otros bancos por el SLBTR
    //        if (TextBox67.Text != "" && ((TextBox66.Text == "9204") || (TextBox66.Text == "9224") || (TextBox66.Text == "9205") || (TextBox66.Text == "9206") || (TextBox66.Text == "9212") || (TextBox66.Text == "9200") || (TextBox66.Text == "9202") || (TextBox66.Text == "9203") || (TextBox66.Text == "9210") || (TextBox66.Text == "9211") || (TextBox66.Text == "9213") || (TextBox66.Text == "9214") || (TextBox66.Text == "9225") /*|| (TextBox66.Text == "9226")*/))
    //        {
    //            string cllamadas = Servicio.CLlamadas();
    //            string cllamadas1 = "";
    //            string cllamadas2 = "";

    //            if (cllamadas.Length.ToString() == "4") //Por los dos códigos de BPA
    //            {
    //                cllamadas1 = cllamadas.ToString().Substring(0, 2);
    //                cllamadas2 = cllamadas.ToString().Substring(2, 2);
    //            }


    //            if ((cllamadas != TextBox67.Text.Substring(0, 2)) || (cllamadas1 == TextBox67.Text.Substring(0, 2)) || (cllamadas2 == TextBox67.Text.Substring(0, 2)))
    //            {
    //                if ((TextBox67.Text.Substring(0, 2) == "95") || (TextBox67.Text.Substring(0, 2) == "06") || (TextBox67.Text.Substring(0, 2) == "02") || (TextBox67.Text.Substring(0, 2) == "12"))
    //                {
    //                    if (TextBox67.Text.Substring(0, 2) == "02" || TextBox67.Text.Substring(0, 2) == "12")
    //                    {
    //                        banco = "BPA - Banco Popular de Ahorro";
    //                    }
    //                    if (TextBox67.Text.Substring(0, 2) == "06")
    //                    {
    //                        banco = "BANDEC - Banco de Crédito y Comercio";
    //                    }
    //                    if (TextBox67.Text.Substring(0, 2) == "95")
    //                    {
    //                        banco = "BANMET - Banco Metropolitano";
    //                    }
    //                    filtro = false;
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                    Label150.Text = "!Esta transferencia será enviada por el SLBTR - Sistema de Liquidación Bruta en Tiempo Real hacia una cuenta de " + banco;
    //                    Label152.Text = "";
    //                    Label159.Text = "";
    //                    Label160.Text = "";
    //                    Label161.Text = "";

    //                }
    //                else
    //                {
    //                    filtro = false;
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                    Label150.Text = "Error No. Tarjeta no válida, por favor verifíquela";
    //                    Label160.Text = "";
    //                    Label161.Text = "";
    //                }

    //            }
    //            else
    //            {
    //                filtro = true;
    //            }
    //        }
    //        else
    //        {
    //            filtro = false;
    //            Label150.ForeColor = System.Drawing.Color.Red;
    //            Label150.Text = "Error No. Tarjeta no válida, por favor verifíquela";
    //            Label160.Text = "";
    //            Label161.Text = "";
    //        }


    //        if (TextBox76.Text != "")
    //        {
    //            string cllamadas = Servicio.CLlamadas();
    //            string cllamadas3 = "";
    //            string cllamadas4 = "";

    //            if (cllamadas.Length.ToString() == "4") //Por los dos codigos de BPA
    //            {
    //                cllamadas3 = cllamadas.ToString().Substring(0, 2);
    //                cllamadas4 = cllamadas.ToString().Substring(2, 2);
    //            }

    //            if ((cllamadas.Substring(1, 1) != TextBox76.Text.Substring(1, 1)) || (cllamadas3 == TextBox76.Text.Substring(0, 2)) || (cllamadas4 == TextBox76.Text.Substring(0, 2)))
    //            {
    //                if ((TextBox76.Text.Substring(0, 2) == "05") || (TextBox76.Text.Substring(0, 2) == "06") || (TextBox76.Text.Substring(0, 2) == "02") || (TextBox76.Text.Substring(0, 2) == "12"))
    //                {
    //                    if (TextBox76.Text.Substring(0, 2) == "02" || TextBox76.Text.Substring(0, 2) == "12")
    //                    {
    //                        banco = "BPA - Banco Popular de Ahorro";
    //                    }
    //                    if (TextBox76.Text.Substring(0, 2) == "06")
    //                    {
    //                        banco = "BANDEC - Banco de Crédito y Comercio";
    //                    }
    //                    if (TextBox76.Text.Substring(0, 2) == "05")
    //                    {
    //                        banco = "BANMET - Banco Metropolitano";
    //                    }
    //                    filtro = false;
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                    Label150.Text = "!Esta transferencia será enviada por el SLBTR - Sistema de Liquidación Bruta en Tiempo Real hacia una cuenta de " + banco;
    //                    Label152.Text = "";
    //                    Label159.Text = "";
    //                    Label160.Text = "";
    //                    Label161.Text = "";

    //                }
    //                else
    //                {
    //                    filtro = false;
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                    Label150.Text = "Error No. Cuenta no válida, por favor verifíquela";
    //                    Label160.Text = "";
    //                    Label161.Text = "";
    //                    TextBox78.Enabled = false;
    //                    RadioButtonList13.Enabled = false;
    //                }

    //            }
    //            else
    //            {
    //                filtro = true;
    //            }

    //        }

    //        if (filtro == true)
    //        {
    //            if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
    //            {
    //                tipo_d_cuenta = 0;
    //                cuenta = TextBox66.Text + TextBox67.Text + TextBox72.Text + TextBox73.Text;
    //            }
    //            if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
    //            {
    //                tipo_d_cuenta = 1;
    //                cuenta = TextBox76.Text;
    //            }
    //            NT = Servicio.Titular(Tarjeta, tipo_d_cuenta, cuenta); //Llamar al metodo del webservice de metro para verificar la existencia del # de cuenta o # de tarjeta mágnetica
    //            string ver = NT.Tables[0].Rows[0][1].ToString();


    //            if (NT.Tables[0].Rows[0][1].ToString() != "true" || NT.Tables[0].Rows[0][1].ToString() != "false")
    //            {
    //                if (RadioButtonList15.SelectedIndex != -1)
    //                {
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                    Label150.Text = "El " + RadioButtonList15.SelectedItem.Text.ToString() + " solicitada no es válida, por favor verifique";
    //                    Label152.Text = "";
    //                    Label159.Text = "";
    //                    Label160.Text = "";
    //                    Label161.Text = "";
    //                    Button134.Enabled = false;
    //                }
    //            }

    //            if (NT.Tables[0].Rows[0][1].ToString() == "true")
    //            {
    //                RadioButtonList13.Enabled = true;
    //                TextBox78.Enabled = true;
    //                Session["CD"] = moneda_d_cuenta;
    //                if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
    //                {
    //                    //9200 MLC CUC, 9202 Nómina CUC, 9203 Ahorro CUC 9204 y 9224 Nómina CUP, 9205 Ahorro CUP, 9206 Jubilados CUP, 9210 Colaboradores CUC, 9211 Suplementarios de Colaboradores CUC, 9212 TCP - Trabajador por Cuenta Propia y/o Cuenta Corriente en CUP, 9213 TCP - Trabajador por Cuenta Propia y/o Cuenta Corriente en CUC
    //                    if ((TextBox66.Text == "9204") || (TextBox66.Text == "9224") || (TextBox66.Text == "9205") || (TextBox66.Text == "9206") || (TextBox66.Text == "9212"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "CUP";
    //                    }
    //                    //else
    //                    //{
    //                    //    Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
    //                    //}

    //                    //|| (TextBox66.Text == "9211") || (TextBox66.Text == "9214") ---  productos que se quitaron del if debajo xq no deben acreditarse (colaboradores)
    //                    else if ((TextBox66.Text == "9200") || (TextBox66.Text == "9202") || (TextBox66.Text == "9203") || (TextBox66.Text == "9210") || (TextBox66.Text == "9213"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "CUC";
    //                    }
    //                    else if ((TextBox66.Text == "9225") || (TextBox66.Text == "9226"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "USD";
    //                    }
    //                    else
    //                    {
    //                        Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
    //                        deshabilitar = true;
    //                    }

    //                }

    //                if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
    //                {
    //                    if (TextBox76.Text.Substring(14, 1) == "1")
    //                    {
    //                        Label161.Text = moneda_d_cuenta = "CUP";
    //                    }
    //                    if (TextBox76.Text.Substring(14, 1) == "2")
    //                    {
    //                        Label161.Text = moneda_d_cuenta = "CUC";
    //                    }
    //                    if (TextBox76.Text.Substring(14, 1) == "3")
    //                    {
    //                        Label161.Text = moneda_d_cuenta = "USD";
    //                    }

    //                }
    //                if (Label160.Text == "")
    //                {
    //                    Label152.Text = Label161.Text;
    //                }
    //                else if (Label161.Text == "")
    //                {
    //                    Label152.Text = Label160.Text;
    //                }

    //                Label150.ForeColor = System.Drawing.Color.LimeGreen;
    //                Label150.Text = "Orden de Transferencia aceptada para " + NT.Tables[0].Rows[0][0].ToString();
    //                Button134.Enabled = true;

    //            }
    //            if (NT.Tables[0].Rows[0][1].ToString() == "false")
    //            {
    //                Label150.ForeColor = System.Drawing.Color.Red;
    //                Label150.Text = "Orden de Transferencia NO aceptada";
    //                Label152.Text = "";
    //                Label159.Text = "";
    //                TextBox78.Enabled = false;
    //                TextBox78.Text = "";
    //                Button134.Enabled = false;
    //                RadioButtonList13.Enabled = false;
    //            }
    //        }
    //        if (filtro == false)
    //        {
    //            RadioButtonList13.Enabled = true;
    //            TextBox78.Enabled = true;
    //            Session["CD"] = moneda_d_cuenta;
    //            if ((RadioButtonList15.SelectedIndex == 0) || (RadioButtonList14.SelectedIndex == 0))
    //            {

    //                if (TextBox66.Text.Substring(0, 2) == "92")
    //                {
    //                    //9200 MLC CUC, 9202 Nómina CUC, 9203 Ahorro CUC 9204 y 9224 Nómina CUP, 9205 Ahorro CUP, 9206 Jubilados CUP, 9210 Colaboradores CUC, 9211 Suplementarios de Colaboradores CUC
    //                    if ((TextBox66.Text == "9204") || (TextBox66.Text == "9224") || (TextBox66.Text == "9205") || (TextBox66.Text == "9206") || (TextBox66.Text == "9212"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "CUP";
    //                    }
    //                    //|| (TextBox66.Text == "9211") || (TextBox66.Text == "9214") ---  productos que se quitaron del if debajo xq no deben acreditarse (colaboradores)
    //                    else if ((TextBox66.Text == "9200") || (TextBox66.Text == "9202") || (TextBox66.Text == "9203") || (TextBox66.Text == "9210") || (TextBox66.Text == "9213"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "CUC";
    //                    }
    //                    else if ((TextBox66.Text == "9225") || (TextBox66.Text == "9226"))
    //                    {
    //                        Label160.Text = moneda_d_cuenta = "USD";
    //                    }
    //                    else
    //                    {
    //                        Label160.Text = "Error, no se ha podido identificar la moneda de la cuenta";
    //                        deshabilitar = true;
    //                    }
    //                }
    //                else
    //                {
    //                    Label150.Text = "El # de Tarjeta Magnética a procesar no pertenece al código de RED (92## #### #### ####)";
    //                    TextBox78.Enabled = false;
    //                    RadioButtonList13.Enabled = false;
    //                    deshabilitar = true;
    //                }
    //            }
    //            if ((RadioButtonList15.SelectedIndex == 1) || (RadioButtonList14.SelectedIndex == 1))
    //            {
    //                if (TextBox76.Text.Substring(14, 1) == "1")
    //                {
    //                    Label161.Text = moneda_d_cuenta = "CUP";
    //                }
    //                if (TextBox76.Text.Substring(14, 1) == "2")
    //                {
    //                    Label161.Text = moneda_d_cuenta = "CUC";
    //                }
    //                if (TextBox76.Text.Substring(14, 1) == "3")
    //                {
    //                    Label161.Text = moneda_d_cuenta = "USD";
    //                }

    //            }
    //            if (Label160.Text == "")
    //            {
    //                Label152.Text = Label161.Text;
    //            }
    //            else if (Label161.Text == "")
    //            {
    //                Label152.Text = Label160.Text;
    //            }

    //            if (deshabilitar)
    //            {
    //                Button134.Enabled = false;
    //            }
    //            else
    //            { Button134.Enabled = true; }

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //    }

    //}
    #endregion

    protected void Button135_Click(object sender, EventArgs e)
    {
        TextBox66.Text = "";
        TextBox67.Text = "";
        TextBox72.Text = "";
        TextBox73.Text = "";
        TextBox78.Text = "";
        TextBox76.Text = "";
        TextBox76.Enabled = false;
        if (RadioButtonList13.Items.Count >= 2)
        {
            if (RadioButtonList13.Items.FindByText("CUC") != null)
                RadioButtonList13.Items.FindByText("CUC").Enabled = false;
            else if(RadioButtonList13.Items.FindByText("CUP") != null)
                RadioButtonList13.Items.FindByText("CUP").Enabled = false;
            else if(RadioButtonList13.Items.FindByText("USD") != null)
                RadioButtonList13.Items.FindByText("USD").Selected = false;
            
            Button134.Enabled = false;
        }
        RadioButtonList13.ClearSelection();
        RadioButtonList13.Items.Clear();
        RadioButtonList14.ClearSelection();
        RadioButtonList15.ClearSelection();
        Label150.Text = "";
        Label152.Text = "";
        Label159.Text = "";
        Label160.Text = "";
        Label161.Text = "";
        EstadoNavegPago.UltimaPagina = 55;
        MVWPago.ActiveViewIndex = 55;
    }

    #region<Raul: (anterior a lo del USD) Boton Ordenar Transferencia>
    //protected void Button134_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Session["codServicio"] = "07";
    //        string[] dat = new string[5];
    //        //Para saber en que moneda se efectuó el pago.
    //        bool moneda = false;
    //        string tipo_moneda = "";
    //        int cont = RadioButtonList13.Items.Count;
    //        if (cont == 2)
    //        {
    //            if (RadioButtonList13.Items.FindByText("CUP").Selected == true)
    //            {
    //                moneda = false;
    //            }
    //            else if (RadioButtonList13.Items.FindByText("CUC").Selected == true)
    //            {
    //                moneda = true;
    //            }
    //            else
    //            {
    //                return;
    //            }

    //            if (moneda == false)
    //                tipo_moneda = "CUP";
    //            else if (moneda == true)
    //                tipo_moneda = "CUC";
    //            else
    //            {
    //                return;
    //            }
    //        }
    //        if (cont == 1)
    //        {
    //            if (RadioButtonList13.Text == "CUP")
    //            {
    //                moneda = false;
    //                tipo_moneda = "CUP";
    //            }
    //            else if (RadioButtonList13.Text == "CUC")
    //            {
    //                moneda = true;
    //                tipo_moneda = "CUC";
    //            }
    //            else
    //            {
    //                return;
    //            }
    //        }

    //        string tipo_cuenta_destino = "";
    //        string cuenta_destino = "";
    //        if (RadioButtonList14.SelectedIndex != -1)
    //        {
    //            tipo_cuenta_destino = "1 Cuenta Estandarizada de " + RadioButtonList14.SelectedItem.Text;
    //            cuenta_destino = TextBox76.Text;

    //        }
    //        if (RadioButtonList15.SelectedIndex != -1)
    //        {
    //            if (RadioButtonList15.SelectedValue.ToString() == "0")
    //            {
    //                tipo_cuenta_destino = "0 Tarjeta Magnética";
    //                cuenta_destino = TextBox66.Text + TextBox67.Text + TextBox72.Text + TextBox73.Text;
    //            }

    //            if (RadioButtonList15.SelectedValue.ToString() == "1")
    //            {
    //                tipo_cuenta_destino = "1 Cuenta Estandarizada";
    //                cuenta_destino = TextBox76.Text;
    //            }
    //        }

    //        //nombre, importe, informativo
    //        dat[0] = "00000000";
    //        dat[1] = tipo_cuenta_destino.Substring(0, 1);//Tipo de Cuenta Destino
    //        dat[2] = cuenta_destino;//# Cuenta Destino
    //        dat[03] = "02" + TextBox78.Text.Trim();//Importe
    //        dat[04] = "12" + " " + tipo_cuenta_destino;//

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;
    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (cantidad == 1)
    //        {
    //            if (((tipo_moneda == "CUP") && (Label152.Text == "CUC")) || ((tipo_moneda == "CUC") && (Label152.Text == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(Label152.Text, tipo_moneda, dat);
    //                Session["contiene"] = contiene;

    //                List<object> contiene1 = (List<object>)Session["contiene"];
    //                string[] lista1 = (string[])contiene1[2];

    //                if (contiene[0].ToString() != contiene[1].ToString())
    //                {

    //                    Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
    //                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
    //                    Errores.Alert(this, traza);

    //                    EstadoNavegPago.UltimaPagina = 4;
    //                    MVWPago.ActiveViewIndex = 4;
    //                }
    //                else
    //                    Session["codServicio"] = Session["codServicio"];

    //            }
    //            else
    //            {
    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

    //                //Salir
    //                Session.Remove("contiene");
    //                Session.Remove("CD");
    //                EstadoNavegPago.UltimaPagina = 4;
    //                MVWPago.ActiveViewIndex = 4;
    //            }
    //        }

    //        if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(Label152.Text, tipo_moneda, dat);
    //            Session["contiene"] = contiene;

    //            List<object> contiene1 = (List<object>)Session["contiene"];
    //            string[] lista1 = (string[])contiene1[2];

    //            if (contiene[0].ToString() != contiene[1].ToString())
    //            {

    //                Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
    //            }
    //            else
    //                Session["codServicio"] = Session["codServicio"];


    //            string ver = Session["codServicio"].ToString();
    //            string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
    //            Errores.Alert(this, traza);

    //            //Salir
    //            Session.Remove("contiene");
    //            Session.Remove("CD");
    //            EstadoNavegPago.UltimaPagina = 4;
    //            MVWPago.ActiveViewIndex = 4;

    //        }

    //        RadioButtonList13.ClearSelection();
    //        RadioButtonList14.ClearSelection();
    //        RadioButtonList15.ClearSelection();
    //        TextBox78.Text = "";
    //        Label152.Text = "";
    //        Label150.Text = "";
    //        Label160.Text = "";
    //        Label161.Text = "";
    //        Label159.Text = "";
    //        TextBox66.Text = "";
    //        TextBox67.Text = "";
    //        TextBox72.Text = "";
    //        TextBox73.Text = "";
    //        TextBox76.Text = "";
    //        if (RadioButtonList13.Items.Count == 2)
    //        {
    //            RadioButtonList13.Items.FindByText("CUC").Enabled = false;
    //            RadioButtonList13.Items.FindByText("CUP").Enabled = false;
    //            RadioButtonList13.Items.FindByText("CUC").Selected = false;
    //            RadioButtonList13.Items.FindByText("CUP").Selected = false;
    //            Button134.Enabled = false;
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Session.Remove("codServicio");
    //        Label150.ForeColor = System.Drawing.Color.Red;
    //        Label150.Text = "Orden de Transferencia NO aceptada";
    //        Label159.Text = "";
    //        Button134.Enabled = false;
    //        Label150.Text = "";
    //        Label160.Text = "";
    //        Label161.Text = "";
    //    }
    //}
    #endregion
    protected void Button134_Click(object sender, EventArgs e)
    {
        try
        {
            Session["codServicio"] = "07";
                string[] dat = new string[5];
                //Para saber en que moneda se efectuó el pago.
                int moneda = 0;
                string tipo_moneda = "";
                int cont = RadioButtonList13.Items.Count;
                if (cont == 1)
                {
                    if (RadioButtonList13.Text == "CUP")
                    {
                        moneda = 0;
                        tipo_moneda = "CUP";
                    }
                    else if (RadioButtonList13.Text == "CUC")
                    {
                        moneda = 1;
                        tipo_moneda = "CUC";
                    }
                    else if (RadioButtonList13.Text == "USD")
                    {
                        moneda = 2;
                        tipo_moneda = "USD";
                    }
                    else
                    {
                        return;
                    }
                }
                else if (cont == 2)
                {
                    if (RadioButtonList13.Items.FindByText("CUP") != null || RadioButtonList13.Items.FindByText("CUC") != null || RadioButtonList13.Items.FindByText("USD") != null)
                    {
                        if (RadioButtonList13.Items.FindByText("CUP") != null && RadioButtonList13.Items.FindByText("CUP").Selected == true)
                        {                            
                          moneda = 0;                            
                        }
                        else if (RadioButtonList13.Items.FindByText("CUC") != null && RadioButtonList13.Items.FindByText("CUC").Selected == true)
                        {                            
                          moneda = 1;                         
                        }
                        else if (RadioButtonList13.Items.FindByText("USD") != null && RadioButtonList13.Items.FindByText("USD").Selected == true)
                        {
                          moneda = 2;                          
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (moneda == 0)
                        tipo_moneda = "CUP";
                    else if (moneda == 1)
                        tipo_moneda = "CUC";
                    else if (moneda == 2)
                        tipo_moneda = "USD"; 
                    else
                    {
                        return;
                    }
                }
                else if (cont == 3)
                {
                    if (RadioButtonList13.Items.FindByText("CUP") != null && RadioButtonList13.Items.FindByText("CUP").Selected == true)
                    {
                        moneda = 0;
                    }
                    else if (RadioButtonList13.Items.FindByText("CUC") != null && RadioButtonList13.Items.FindByText("CUC").Selected == true)
                    {
                        moneda = 1;
                    }
                    else if (RadioButtonList13.Items.FindByText("USD") != null && RadioButtonList13.Items.FindByText("USD").Selected == true)
                    {
                        moneda = 2;
                    }
                    else
                    {
                        return;
                    }

                    if (moneda == 0)
                        tipo_moneda = "CUP";
                    else if (moneda == 1)
                        tipo_moneda = "CUC";
                    else if (moneda == 2)
                        tipo_moneda = "USD";
                    else
                    {
                        return;
                    }
                }

                string tipo_cuenta_destino = "";
                string cuenta_destino = "";
                if (RadioButtonList14.SelectedIndex != -1)
                {
                    tipo_cuenta_destino = "1 Cuenta Estandarizada de " + RadioButtonList14.SelectedItem.Text;
                    cuenta_destino = TextBox76.Text;

                }
                if (RadioButtonList15.SelectedIndex != -1)
                {
                    if (RadioButtonList15.SelectedValue.ToString() == "0")
                    {
                        tipo_cuenta_destino = "0 Tarjeta Magnética";
                        cuenta_destino = TextBox66.Text + TextBox67.Text + TextBox72.Text + TextBox73.Text;
                    }

                    if (RadioButtonList15.SelectedValue.ToString() == "1")
                    {
                        tipo_cuenta_destino = "1 Cuenta Estandarizada";
                        cuenta_destino = TextBox76.Text;
                    }
                }

                //nombre, importe, informativo
                dat[0] = "00000000";
                dat[1] = tipo_cuenta_destino.Substring(0, 1);//Tipo de Cuenta Destino
                dat[2] = cuenta_destino;//# Cuenta Destino
                dat[03] = "02" + TextBox78.Text.Trim();//Importe
                dat[04] = "12" + " " + tipo_cuenta_destino;//

                //identificar monedas asociadas a bt.
                string Tarjeta = Session["NoTarjeta"].ToString();
                DataSet DT = new DataSet();
                DT = Servicio.Monedas(Tarjeta);

                int cantidad = DT.Tables[0].Rows.Count;
                string mon_cue = DT.Tables[0].Rows[0][1].ToString();
                
                if (cantidad == 1)
                {
                    if (tipo_moneda != Label152.Text && Label152.Text == "USD")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Las transferencias desde cuentas CUP o CUC hacia USD no esta permitida');", true);
                        Button134.Enabled = false;
                    }
                    else
                    if (((tipo_moneda == "CUP") && (Label152.Text == "CUC")) || ((tipo_moneda == "CUC") && (Label152.Text == "CUP")) || ((tipo_moneda == "USD") && (Label152.Text == "CUP")) || ((tipo_moneda == "USD") && (Label152.Text == "CUC")))
                    {
                        List<object> contiene = new List<object>();
                        //redirecciono para la vista de aplicar tipo de cambio
                        contiene = this.datos_pago_tc(Label152.Text, tipo_moneda, dat);
                        Session["contiene"] = contiene;

                        List<object> contiene1 = (List<object>)Session["contiene"];
                        string[] lista1 = (string[])contiene1[2];

                        if (contiene[0].ToString() != contiene[1].ToString())
                        {

                            Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
                            string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
                            Errores.Alert(this, traza);

                            EstadoNavegPago.UltimaPagina = 4;
                            MVWPago.ActiveViewIndex = 4;
                        }
                        else
                            Session["codServicio"] = Session["codServicio"];

                    }
                    else
                    {
                        string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                        Errores.Alert(this, traza);

                        //Salir
                        Session.Remove("contiene");
                        Session.Remove("CD");
                        EstadoNavegPago.UltimaPagina = 4;
                        MVWPago.ActiveViewIndex = 4;
                    }
                }

                if (cantidad == 2)
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(Label152.Text, tipo_moneda, dat);
                    Session["contiene"] = contiene;

                    List<object> contiene1 = (List<object>)Session["contiene"];
                    string[] lista1 = (string[])contiene1[2];

                    if (contiene[0].ToString() != contiene[1].ToString())
                    {

                        Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
                    }
                    else
                        Session["codServicio"] = Session["codServicio"];


                    string ver = Session["codServicio"].ToString();
                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
                    Errores.Alert(this, traza);
                    
                    //Salir
                    Session.Remove("contiene");
                    Session.Remove("CD");
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;

                }                
                if (cantidad == 3)
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(Label152.Text, tipo_moneda, dat);
                    Session["contiene"] = contiene;

                    List<object> contiene1 = (List<object>)Session["contiene"];
                    string[] lista1 = (string[])contiene1[2];

                    if (contiene[0].ToString() != contiene[1].ToString())
                    {

                        Session["codServicio"] = Convert.ToString(Convert.ToInt32(Session["codServicio"]) + 50);
                    }
                    else
                        Session["codServicio"] = Session["codServicio"];


                    string ver = Session["codServicio"].ToString();
                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], lista1, moneda);
                    Errores.Alert(this, traza);
                    
                    //Salir
                    Session.Remove("contiene");
                    Session.Remove("CD");
                    EstadoNavegPago.UltimaPagina = 4;
                    MVWPago.ActiveViewIndex = 4;
                }
                

                RadioButtonList13.ClearSelection();
                RadioButtonList14.ClearSelection();
                RadioButtonList15.ClearSelection();
                TextBox78.Text = "";
                Label152.Text = "";
                Label150.Text = "";
                Label160.Text = "";
                Label161.Text = "";
                Label159.Text = "";
                TextBox66.Text = "";
                TextBox67.Text = "";
                TextBox72.Text = "";
                TextBox73.Text = "";
                TextBox76.Text = "";
                if (RadioButtonList13.Items.Count >= 2)
                {
                    if (RadioButtonList13.Items.FindByText("CUC") != null)
                        RadioButtonList13.Items.FindByText("CUC").Enabled = false;
                    else if(RadioButtonList13.Items.FindByText("CUP") != null)
                        RadioButtonList13.Items.FindByText("CUP").Enabled = false;
                    else if (RadioButtonList13.Items.FindByText("USD") != null)
                        RadioButtonList13.Items.FindByText("USD").Selected = false;
                    
                    Button134.Enabled = false;
                }

            }
        
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Session.Remove("codServicio");
            Label150.ForeColor = System.Drawing.Color.Red;
            Label150.Text = "Orden de Transferencia NO aceptada";
            Label159.Text = "";
            Button134.Enabled = false;
            Label150.Text = "";
            Label160.Text = "";
            Label161.Text = "";
        }
    }




    // boton que procesa los datos recopilados de la multa:
    protected void Button139_Click(object sender, EventArgs e)
    {
        Button99.Enabled = false;
        Label34.Text = "Fecha";
        
        
            string[] Datos = new string[2];
            string articulo = DropDownList13.SelectedValue;
            string inciso = DropDownList14.SelectedValue;
            string digito = DropDownList15.SelectedValue;
            string Folio = TextBox55.Text;
            string peligrosidad = DropDownList16.SelectedValue;
            Datos = Servicio.ObtenerMontoMulta(articulo, inciso, peligrosidad);
            if (Datos[0] == "False")
            {
                Errores.Alert(this, Datos[1].ToString());
                Button99.Enabled = false;
            }
            else
            {

                RegularExpressionValidator35.Validate();
                RegularExpressionValidator36.Validate();
                RequiredFieldValidator37.Validate();
                RequiredFieldValidator38.Validate();
                bool valido = RegularExpressionValidator35.IsValid && RegularExpressionValidator36.IsValid && RequiredFieldValidator37.IsValid && RequiredFieldValidator38.IsValid;
                if (!valido)
                {
                    Errores.Alert(this, "..::Entrada de Datos no Válida::.. ");
                    Calendar10.SelectedDate = DateTime.Now;
                    Button99.Enabled = false;
                }
                else
                {
                    DateTime Fecha = Calendar10.SelectedDate.Date;
                    int contador = 0;
                    DateTime[] dia_feriado = new DateTime[9]; // Aquí se declara el arreglo para la cantidad de dias feriados en el año (Actualmente son 9 días)

                    dia_feriado[0] = new DateTime(DateTime.Today.Year, 1, 1);
                    dia_feriado[1] = new DateTime(DateTime.Today.Year, 1, 2);
                    dia_feriado[2] = new DateTime(DateTime.Today.Year, 5, 1);
                    dia_feriado[3] = new DateTime(DateTime.Today.Year, 7, 25);
                    dia_feriado[4] = new DateTime(DateTime.Today.Year, 7, 26);
                    dia_feriado[5] = new DateTime(DateTime.Today.Year, 7, 27);
                    dia_feriado[6] = new DateTime(DateTime.Today.Year, 10, 10);
                    dia_feriado[7] = new DateTime(DateTime.Today.Year, 12, 25);
                    dia_feriado[8] = new DateTime(DateTime.Today.Year, 12, 31);


                    ArrayList dias_habiles = new ArrayList(); //Para guardar cuáles son los días hábiles para esta fecha de imposición

                    for (int i = 1; Fecha.AddDays(i) > Fecha; i++)
                    {
                        if (Fecha.AddDays(i).DayOfWeek == DayOfWeek.Saturday) continue;
                        if (Fecha.AddDays(i).DayOfWeek == DayOfWeek.Sunday) continue;
                        if (dia_feriado_habil(dia_feriado, Fecha.AddDays(i))) continue;

                        dias_habiles.Add(Fecha.AddDays(i));
                        contador++;
                        if (contador == 3)
                            break;

                    }
                    //if (Fecha.AddDays(60) < System.DateTime.Now.Date)
                    //{
                    //    Errores.Alert(this, "..::La Multa no puede ser pagada porque excede el plazo de 60 días::..");
                    //    Button99.Enabled = false;
                    //}

                    try
                    {
                        if (Fecha.AddDays(30).Date >= System.DateTime.Now.Date)
                        {
                            if (DateTime.Today <= Convert.ToDateTime(dias_habiles[2]))
                            {
                                if (RadioButtonList16.SelectedValue == "0")
                                {
                                    Label37.Text = Datos[0].ToString() + ".00";
                                    Label39.Text = Datos[0].ToString() + ".00";
                                    Label163.Text = "No puede aplicar por la Bonificación a pesar de estar en tiempo por tener marcado el 94-1";
                                }
                                else
                                {
                                    Label163.Text = "Se aplica la Bonificación del 50 % del Importe a Pagar cuando se efectúa el Pago el mismo día de la Fecha de Imposición o dentro de los 3 días hábiles posteriores a esta";
                                    decimal valor1 = Convert.ToDecimal(Datos[0].ToString()) / 2;
                                    Label37.Text = Datos[0].ToString() + ".00";
                                    Label39.Text = valor1.ToString() + ".00";
                                }
                            }
                            else
                            {
                                if (RadioButtonList16.SelectedValue == "0")
                                {
                                    decimal valor2 = Convert.ToDecimal(Datos[0].ToString()) * 2;
                                    Label37.Text = Datos[0].ToString() + ".00";
                                    Label39.Text = valor2.ToString() + ".00";
                                    Label163.Text = "Importe Duplicado por tener marcado el 94-1";
                                }
                                else
                                {
                                    Label37.Text = Datos[0].ToString() + ".00";
                                    Label39.Text = Datos[0].ToString() + ".00";
                                }
                            }

                        }
                        else 
                        {
                            if (RadioButtonList16.SelectedValue == "0")
                            {
                                decimal valor1 = Convert.ToDecimal(Datos[0].ToString()) * 4;
                                Label37.Text = Datos[0].ToString() + ".00";
                                Label39.Text = valor1.ToString() + ".00";
                                Label134.ForeColor = System.Drawing.Color.Red;
                                Label134.Text = "!Doblemente Duplicada!";
                                Label163.Text = "El importe ha sido Duplicado por exceder los 30 días naturales contados a partir de la Fecha de Imposición y además tener marcado el 94-1";

                            }
                            else
                            {
                                decimal valor = Convert.ToDecimal(Datos[0].ToString()) * 2;
                                Label37.Text = Datos[0].ToString() + ".00";
                                Label39.Text = valor.ToString() + ".00";
                                Label134.ForeColor = System.Drawing.Color.Red;
                                Label134.Text = "!Duplicada!";
                                Label163.Text = "El importe ha sido Duplicado por exceder los 30 días naturales contados a partir de la Fecha de Imposición";
                            }
                        }

                        Button99.Enabled = true;
                        //deshabilitar los textbox
                        //DropDownList13.Enabled = false;
                        //DropDownList14.Enabled = false;
                        //DropDownList15.Enabled = false;
                        DropDownList16.Enabled = false;
                        //TextBox55.Enabled = false;
                        //Calendar10.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                    }



                }
            }
            
    }
    protected void Calendar10_SelectionChanged(object sender, EventArgs e)
    {
        Label134.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }
    protected void DropDownList15_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label34.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }
    protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label34.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }
    protected void DropDownList14_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label34.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }
    protected void DropDownList16_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label34.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }
    protected void RadioButtonList16_SelectedIndexChanged(object sender, EventArgs e)
    {
        Calendar10.Enabled = true;
        Label34.Text = "Fecha";
        Label37.Text = "";
        Label39.Text = "";
        Label163.Text = "";
        Button99.Enabled = false;
    }



    protected void Button140_Click(object sender, EventArgs e)
    {
        RadioButtonList12.ClearSelection();
        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
    }


    protected void RadioButtonList17_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button68.Enabled = true;
    }
    protected void Calendar5_SelectionChanged(object sender, EventArgs e)
    {
        RadioButtonList17.Enabled = true;
    }
    protected void Button144_Click(object sender, EventArgs e)
    {        

        Label174.Visible = false;
        Label175.Visible = false;
        Label172.Visible = false;
        Label173.Visible = false;
        TextBox77.Visible = false;
        Button143.Visible = false;
        fila_verde_info_cred.Visible = false;
        fila_verde3.Visible = false;
        fila_label_efectuar_pago.Visible = false;
        fila_verde5.Visible = false;
        fila_verde4.Visible = false;
        Button141.Visible = false;
        Button142.Visible = false;
        ASPxButton7.Enabled = false;
        ASPxGridView3.FocusedRowIndex = -1;

        Regex rx = new Regex("^([0-9]{1,11})"); // expresion regular ^: inicia, ([0-9]): solo numeros, {1,11}: desde 1 posicion a 11

        if (!rx.IsMatch(TextBox74.Text))
        {
            Label175.Visible = true;
            Label175.Text = "El numero de carne no cumple el formato establecido";
            TextBox74.Focus();
            
        }

        string Tarjeta = Session["NoTarjeta"].ToString();

        DetailsView2.Visible = false;

        if (TextBox74.Text != "" && TextBox74.Text.Length <= 11)
        {
            string ci = TextBox74.Text;
            Session["IdentCliente"] = ci;                      

                DataSet CE = new DataSet();
                CE = Servicio.Credito(Tarjeta, ci);

                if (CE != null)
                {
                    if (CE.Tables[0].Rows.Count > 0)
                    {
                        //GridView11.DataSource = CE;

                        ASPxGridView3.DataSource = CE;
                        ASPxGridView3.DataBind();
                        ASPxGridView3.Visible = true;

                        fila_label_creditos_asociados.Visible = true;                        
                        fila_verde1.Visible = true;

                        //GridView11.KeyFieldName = "cuenta";
                        //GridView11.DataBind();
                        Button141.Enabled = false;
                        ASPxButton7.Visible = true;
                        ASPxButton7.Enabled = true;
                        //ASPxButton1.Enabled = false;
                        //GridView11.Visible = true;
                    }
                    else
                    {
                        DetailsView2.DataSource = null;
                        DetailsView2.DataBind();

                        //GridView11.DataSource = null;
                        //GridView11.DataBind();

                        ASPxGridView3.DataSource = null;
                        ASPxGridView3.DataBind();
                        ASPxGridView3.Visible = false;

                        ASPxButton7.Visible = false;
                        ASPxButton7.Enabled = false;

                        //GridView11.Visible = false;
                        Button141.Enabled = false;
                        //ASPxButton1.Enabled = false;
                        DetailsView2.Visible = false;

                        Label175.Visible = true;
                        Label175.Text = "Esta persona no posee credito(s)";
                        fila_label_creditos_asociados.Visible = false;
                        fila_verde1.Visible = false;
                        fila_verde_info_cred.Visible = false;
                        fila_verde3.Visible = false;
                        fila_verde4.Visible = false;
                        fila_label_efectuar_pago.Visible = false;

                    }
                }
                else if (CE == null)
                {
                    DetailsView2.DataSource = null;
                    DetailsView2.DataBind();

                    fila_label_notificacion.Visible = true;
                    //GridView11.DataSource = null;
                    //GridView11.DataBind();

                    ASPxButton7.Visible = false;
                    ASPxButton7.Enabled = false;

                    ASPxGridView3.DataSource = null;
                    ASPxGridView3.DataBind();
                    ASPxGridView3.Visible = false;

                    //GridView11.Visible = false;
                    Button141.Enabled = false;
                    //ASPxButton1.Enabled = false;
                    DetailsView2.Visible = false;

                    Label175.Visible = true;
                    Label175.Text = "Esta persona no posee credito(s)";
                }                            

            Button141.Enabled = false;
                //ASPxButton1.Enabled = false;
        }
        else
        {
            DetailsView2.DataSource = null;
            DetailsView2.DataBind();

            fila_label_notificacion.Visible = true;
            //GridView11.DataSource = null;
            //GridView11.DataBind();

            ASPxGridView3.DataSource = null;
            ASPxGridView3.DataBind();
            ASPxGridView3.Visible = false;

            ASPxButton7.Visible = false;
            ASPxButton7.Enabled = false;

            //GridView11.Visible = false;
            Button141.Enabled = false;
            //ASPxButton1.Enabled = false;
            DetailsView2.Visible = false;

            Label175.Visible = true;
            Label175.Text = "Rectifique el Carnet Identidad";
        }
            

    }
    protected void Button143_Click(object sender, EventArgs e)
    {
        string Tarjeta = Session["NoTarjeta"].ToString();
        string serv = Session["codServicio"].ToString();
        //string ce = GridView11.SelectedRow.Cells[1].Text.Trim();
        string ce = ASPxGridView3.GetRowValues(ASPxGridView3.FocusedRowIndex, ASPxGridView3.KeyFieldName).ToString().Trim();
        //DataRow row = GridView11.GetDataRow(GridView11.FocusedRowIndex); //Selection.ToString().Trim();
        //string ce = row[1].ToString();
        int meses = Convert.ToInt32(TextBox77.Text.Trim());
        DataSet Datos = new DataSet();
        Datos = Servicio.DatosCredito(Tarjeta, serv, ce, meses);

        if (Datos != null)
        {
            DetailsView2.DataSource = Datos;
            DetailsView2.DataBind();
            Button141.Enabled = true;
            //Button141.Enabled = false;
            //ASPxButton1.Enabled = true;
        }
        else
            Button141.Enabled = false;
            //ASPxButton1.Enabled = false;

    }

    #region<Raul: (anterior a lo del USD) Boton de Pago Amortizacion View58>
    // Boton Efectuar Pago de Amortizacion 
    //protected void Button141_Click(object sender, EventArgs e)
    //{
    //    string[] dat = new string[5];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false; //Los creditos a personas naturales se otorgan solo en CUP

    //    string tipo_moneda = "";
    //    Button141.Enabled = false;
    //    //ASPxButton1.Enabled = false;


    //    try
    //    {
    //        string codServ = (string)Session["codServicio"];
           
    //        //nombre, importe, informativo
    //        dat[0] = "12" + Session["IdentCliente"].ToString(); //"0000000000";// Raul: la linea que estaba era la de abajo
    //        //dat[0] = "0000000000";
    //        dat[1] = DetailsView2.Rows[18].Cells[1].Text.Trim();//Importe Mensual
    //        //dat[2] = GridView11.SelectedRow.Cells[1].Text.Trim();//CE 
    //        dat[2] = ASPxGridView3.GetSelectedFieldValues("cuenta").ToString().Trim();//CE 
    //        //dat[2] = GridView11.GetDataRow(GridView11.FocusedRowIndex)[1].ToString();
    //        dat[03] = "02" + DetailsView2.Rows[19].Cells[1].Text.Trim();//Importe Total a Pagar
    //        dat[04] = DetailsView2.Rows[12].Cells[1].Text.Trim();

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (moneda == false)
    //        {
    //            tipo_moneda = "CUP";
    //        }
    //        else
    //        {
    //            tipo_moneda = "CUC";
    //        }

    //        if (cantidad == 1)
    //        {
    //            if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;
    //            }

    //            else
    //            {

    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

    //                DetailsView1.DataBind();
    //                if (DetailsView1.Rows.Count == 0)
    //                {
    //                    EstadoNavegPago.UltimaPagina = 4;
    //                    MVWPago.ActiveViewIndex = 4;
    //                }

    //            }
    //        }

    //        if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Button13.Enabled = true;
    //    }
    //}
    #endregion

    // Boton Efectuar Pago de Amortizacion View58
    protected void Button141_Click(object sender, EventArgs e)
    {
        string[] dat = new string[5];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0; //Los creditos a personas naturales se otorgan solo en CUP

        string tipo_moneda = "";
        Button141.Enabled = false;
        //ASPxButton1.Enabled = false;


        try
        {
            string codServ = (string)Session["codServicio"];

            //nombre, importe, informativo
            dat[0] = "12" + Session["IdentCliente"].ToString(); //"0000000000";// Raul: la linea que estaba era la de abajo
            //dat[0] = "0000000000";
            dat[1] = DetailsView2.Rows[18].Cells[1].Text.Trim();//Importe Mensual
            //dat[2] = GridView11.SelectedRow.Cells[1].Text.Trim();//CE 
            dat[2] = ASPxGridView3.GetSelectedFieldValues("cuenta").ToString().Trim();//CE 
            //dat[2] = GridView11.GetDataRow(GridView11.FocusedRowIndex)[1].ToString();
            dat[03] = "02" + DetailsView2.Rows[19].Cells[1].Text.Trim();//Importe Total a Pagar
            dat[04] = DetailsView2.Rows[12].Cells[1].Text.Trim();

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            if (moneda == 0)
            {
                tipo_moneda = "CUP";
            }
            else if(moneda == 1)
            {
                tipo_moneda = "CUC";
            }
            else if (moneda == 2)
            {
                tipo_moneda = "USD";
            }

            if (cantidad == 1)
            {
                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")) || ((tipo_moneda == "CUP") && (mon_cue == "USD")) || ((tipo_moneda == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;
                }
                else
                {

                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);

                    DetailsView1.DataBind();
                    if (DetailsView1.Rows.Count == 0)
                    {
                        EstadoNavegPago.UltimaPagina = 4;
                        MVWPago.ActiveViewIndex = 4;
                    }

                }
            }

            if (cantidad >= 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Button13.Enabled = true;
        }
    }
    protected void GridView11_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsView2.DataSource = null;
        DetailsView2.DataBind();
        Label174.Visible = false;
        Label174.Enabled = false;

        string Tarjeta = Session["NoTarjeta"].ToString();
        string serv = Session["codServicio"].ToString();
        //string ce = GridView11.SelectedRow.Cells[1].Text.Trim();

        //******************************************************
        string ce = "";
        if (ASPxGridView3.FocusedRowIndex == -1 || ASPxGridView3.FocusedRowIndex == null || ASPxGridView3.FocusedRowIndex < 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "cta_est", "alert('SI DESEA VER LOS DETALLES DEBE SELECCIONAR UNA DE LAS CUENTAS DE CREDITO QUE SE MUESTRAN EN EL LISTADO');", true);// este muestra el mensaje como un modal
            //Label174.Text = "DEBE SELECCIONAR UNA DE LAS CUENTAS PARA MOSTRAR DETALLES";
            //Label174.Visible = true;
            //Label174.Enabled = true;
            return;
            //ScriptManager.RegisterStartupScript(this, GetType(), "cuenta_null", "alert('DEBE SELECCIONAR UNA CUENTA PARA VER DETALLES')", true);
        }
        else
        {
            string c_estandarizada = ASPxGridView3.GetRowValues(ASPxGridView3.FocusedRowIndex, ASPxGridView3.KeyFieldName).ToString().Trim();// obteniendo el valor de la celda de la fila seleccionada usando el campo llave especificado del grid
            var products = ASPxGridView3.GetSelectedFieldValues("cuenta"); // obteniendo el valor de la celda de la fila seleccionada en esa columna especificando el nombre de la columna

            ce = c_estandarizada.Trim();
            Session["CE"] = ce;
        }

        ASPxLabel3.Text = Session["CE"].ToString();
        ASPxLabel3.Visible = true;


        //******************************************************
        DataSet Datos = new DataSet();
        Datos = Servicio.DatosCredito(Tarjeta, serv, ce, 1);

        if (Datos == null)
        { 
            Button141.Enabled = false;
            Button141.Visible = false;
            Button142.Enabled = false;
            Button142.Visible = false;

            //ASPxButton1.Enabled = false;
            DetailsView2.Visible = false;
            Label174.Visible = true;
            Label174.Text = "Hubo un Fallo. No se pudo recibir informacion del Centro Contable al que pertenece el credito.";
            fila_label_notificacion2.Visible = true;
            TextBox77.Visible = false; Label172.Visible = false; Label173.Visible = false;
            fila_verde3.Visible = false;
            fila_verde4.Visible = false;
            fila_verde5.Visible = false;
            fila_label_efectuar_pago.Visible = false;
            fila_verde_info_cred.Visible = false;
        }
        else if (Datos.Tables[0].Rows.Count==0)
        {
            Button141.Enabled = false;
            Button141.Visible = false;
            Button142.Enabled = false;
            Button142.Visible = false;

            //ASPxButton1.Enabled = false;
            DetailsView2.Visible = false;
            Label174.Visible = true;
            Label174.Text = "Hubo un fallo. No se encontraron los datos del credito a Amortizar.";
            fila_label_notificacion2.Visible = true;
            TextBox77.Visible = false; Label172.Visible = false; Label173.Visible = false;
            fila_verde3.Visible = false;
            fila_verde4.Visible = false;
            fila_verde5.Visible = false;
            fila_label_efectuar_pago.Visible = false;
            fila_verde_info_cred.Visible = false;
        }
        else if (Datos.Tables.Contains("ERROR"))
        {
            Label174.Visible = true;
            Label174.Text = "No se puede. "+ Datos.Tables["ERROR"].Rows[0]["Mensaje"].ToString();
            fila_label_notificacion2.Visible = true;

            DetailsView2.Visible = false;
            this.Button141.Visible = false;
            this.Button141.Enabled = false;            
            this.Button142.Visible = false;
            this.Button142.Enabled = false;
            this.Button143.Visible = false;
            TextBox77.Visible = false; Label172.Visible = false; Label173.Visible = false;
            fila_verde3.Visible = false;
            fila_verde4.Visible = false;
            fila_verde5.Visible = false;
            fila_label_efectuar_pago.Visible = false;
            fila_verde_info_cred.Visible = false;
        }

        else if (Datos.Tables[0].Rows.Count > 0)
        {
            TextBox77.Text = "1"; TextBox77.Visible = true; Label172.Visible = true; Label173.Visible = true; 
            DetailsView2.Visible = true;
            this.Button141.Visible = true;
            this.Button141.Enabled = true;
            //this.Button141.Enabled = false;
            this.Button142.Visible = true;
            this.Button142.Enabled = true;
            this.Button143.Visible = true;
            //ASPxButton1.Enabled = true;
            DetailsView2.DataSource = Datos;
            DetailsView2.DataBind();

            Label174.Visible = false;
            fila_verde_info_cred.Visible = true;
            fila_verde3.Visible = true;
            fila_verde4.Visible = true;
            fila_verde5.Visible = true;
            fila_label_efectuar_pago.Visible = true;
        }
        
    }

    protected void Button142_Click(object sender, EventArgs e)
    {
        DetailsView2.DataSource = null;
        DetailsView2.DataBind();

        //GridView11.DataSource = null;
        //GridView11.DataBind();

        //GridView11.Visible = false;

        ASPxGridView3.DataSource = null;
        ASPxGridView3.DataBind();

        ASPxGridView3.Visible = false;

        //Button141.Enabled = false;
        //ASPxButton1.Enabled = false;
        DetailsView2.Visible = false;

        TextBox74.Text = "";

        Button141.Visible = false;
        Button142.Visible = false;
        TextBox77.Visible = false; Label172.Visible = false;

        EstadoNavegPago.UltimaPagina = 4;
        MVWPago.ActiveViewIndex = 4;
    }

    #region<Raul: (anterior a lo del USD) Boton Pagar Amortizacion>
    //boton de Pago Amortizacion
    //protected void ASPxButton1_Click(object sender, EventArgs e)
    //{

    //    string[] dat = new string[5];
    //    //Para saber en que moneda se efectuó el pago.
    //    bool moneda = false; //Los creditos a personas naturales se otorgan solo en CUP

    //    string tipo_moneda = "";
    //    Button141.Enabled = false;
    //    //ASPxButton1.Enabled = false;


    //    try
    //    {
    //        string codServ = (string)Session["codServicio"];

    //        //nombre, importe, informativo
    //        dat[0] = "12" + Session["IdentCliente"].ToString(); //"0000000000";// Raul: la linea que estaba era la de abajo
    //        //dat[0] = "0000000000";
    //        dat[1] = DetailsView2.Rows[18].Cells[1].Text.Trim();//Importe Mensual
    //        //dat[2] = GridView11.SelectedRow.Cells[1].Text.Trim();//CE 
    //        //dat[2] = ASPxGridView3.GetSelectedFieldValues("cuenta").ToString().Trim();//CE
    //        dat[2] = Session["CE"].ToString();//CE
    //        //dat[2] = GridView11.GetDataRow(GridView11.FocusedRowIndex)[1].ToString(); 
    //        dat[03] = "02" + DetailsView2.Rows[19].Cells[1].Text.Trim();//Importe Total a Pagar
    //        dat[04] = DetailsView2.Rows[12].Cells[1].Text.Trim();

    //        //identificar monedas asociadas a bt.
    //        string Tarjeta = Session["NoTarjeta"].ToString();
    //        DataSet DT = new DataSet();
    //        DT = Servicio.Monedas(Tarjeta);

    //        int cantidad = DT.Tables[0].Rows.Count;

    //        string mon_cue = DT.Tables[0].Rows[0][1].ToString();

    //        if (moneda == false)
    //        {
    //            tipo_moneda = "CUP";
    //        }
    //        else
    //        {
    //            tipo_moneda = "CUC";
    //        }

    //        if (cantidad == 1)
    //        {
    //            if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")))
    //            {
    //                List<object> contiene = new List<object>();
    //                //redirecciono para la vista de aplicar tipo de cambio
    //                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //                Session["contiene"] = contiene;
    //                MVWPago.ActiveViewIndex = 53;
    //            }

    //            else
    //            {

    //                string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
    //                Errores.Alert(this, traza);

    //                DetailsView1.DataBind();
    //                if (DetailsView1.Rows.Count == 0)
    //                {
    //                    EstadoNavegPago.UltimaPagina = 4;
    //                    MVWPago.ActiveViewIndex = 4;
    //                }

    //            }
    //        }

    //        if (cantidad == 2)
    //        {
    //            List<object> contiene = new List<object>();
    //            //redirecciono para la vista de aplicar tipo de cambio
    //            contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
    //            Session["contiene"] = contiene;
    //            MVWPago.ActiveViewIndex = 54;
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //        Button13.Enabled = true;
    //    }
    //}
    #endregion

    //boton de Pago Amortizacion
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        
        string[] dat = new string[5];
        //Para saber en que moneda se efectuó el pago.
        int moneda = 0; //Los creditos a personas naturales se otorgan solo en CUP

        string tipo_moneda = "";
        Button141.Enabled = false;
        //ASPxButton1.Enabled = false;


        try
        {
            string codServ = (string)Session["codServicio"];

            //nombre, importe, informativo
            dat[0] = "12" + Session["IdentCliente"].ToString(); //"0000000000";// Raul: la linea que estaba era la de abajo
            //dat[0] = "0000000000";
            dat[1] = DetailsView2.Rows[18].Cells[1].Text.Trim();//Importe Mensual
            //dat[2] = GridView11.SelectedRow.Cells[1].Text.Trim();//CE 
            //dat[2] = ASPxGridView3.GetSelectedFieldValues("cuenta").ToString().Trim();//CE
            dat[2] = Session["CE"].ToString();//CE
            //dat[2] = GridView11.GetDataRow(GridView11.FocusedRowIndex)[1].ToString(); 
            dat[03] = "02" + DetailsView2.Rows[19].Cells[1].Text.Trim();//Importe Total a Pagar
            dat[04] = DetailsView2.Rows[12].Cells[1].Text.Trim();

            //identificar monedas asociadas a bt.
            string Tarjeta = Session["NoTarjeta"].ToString();
            DataSet DT = new DataSet();
            DT = Servicio.Monedas(Tarjeta);

            int cantidad = DT.Tables[0].Rows.Count;

            string mon_cue = DT.Tables[0].Rows[0][1].ToString();

            if (moneda == 0)
            {
                tipo_moneda = "CUP";
            }
            else if(moneda == 1)
            {
                tipo_moneda = "CUC";
            }
            else if (moneda == 2)
            {
                tipo_moneda = "USD";
            }

            if (cantidad == 1)
            {
                if (((tipo_moneda == "CUP") && (mon_cue == "CUC")) || ((tipo_moneda == "CUC") && (mon_cue == "CUP")) || ((tipo_moneda == "CUP") && (mon_cue == "USD")) || ((tipo_moneda == "CUC") && (mon_cue == "USD")))
                {
                    List<object> contiene = new List<object>();
                    //redirecciono para la vista de aplicar tipo de cambio
                    contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                    Session["contiene"] = contiene;
                    MVWPago.ActiveViewIndex = 53;
                }

                else
                {

                    string traza = Servicio.EnviarTransaccionPagoComplejo((string)Session["codServicio"], dat, moneda);
                    Errores.Alert(this, traza);

                    DetailsView1.DataBind();
                    if (DetailsView1.Rows.Count == 0)
                    {
                        EstadoNavegPago.UltimaPagina = 4;
                        MVWPago.ActiveViewIndex = 4;
                    }

                }
            }

            if (cantidad >= 2)
            {
                List<object> contiene = new List<object>();
                //redirecciono para la vista de aplicar tipo de cambio
                contiene = this.datos_pago_tc(mon_cue, tipo_moneda, dat);
                Session["contiene"] = contiene;
                MVWPago.ActiveViewIndex = 54;
            }


        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Button13.Enabled = true;
        }
    }


    //protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
    //{
    //    DetailsView2.DataSource = null;
    //    DetailsView2.DataBind();

    //    string Tarjeta = Session["NoTarjeta"].ToString();
    //    string serv = Session["codServicio"].ToString();
    //    string ce = ASPxGridView1.Selection.SelectRow().SelectedRow.Cells[1].Text.Trim();
    //    //string ce = GridView11.Selection.ToString().Trim();

    //    DataSet Datos = new DataSet();
    //    Datos = Servicio.DatosCredito(Tarjeta, serv, ce, 1);

    //    if (Datos == null)
    //    {
    //        Button141.Enabled = false;
    //        //ASPxButton1.Enabled = false;
    //        DetailsView2.Visible = false;
    //        Label174.Visible = true;
    //        Label174.Text = "No se encontraron los datos del credito a Amortizar.";
    //    }
    //    if (Datos.Tables[0].Rows.Count == 0)
    //    {
    //        Label174.Visible = true;
    //        Label174.Text = "No se encontraron los datos del credito a Amortizar.";
    //    }
    //    else if (Datos.Tables[0].Rows.Count > 0)
    //    {
    //        TextBox77.Text = "1"; TextBox77.Visible = true; Label172.Visible = true; Label173.Visible = true;
    //        DetailsView2.Visible = true;
    //        this.Button141.Visible = true;
    //        this.Button141.Enabled = true;
    //        this.Button142.Visible = true;
    //        this.Button142.Enabled = true;
    //        this.Button143.Visible = true;
    //        //ASPxButton1.Enabled = true;
    //        DetailsView2.DataSource = Datos;
    //        DetailsView2.DataBind();

    //    }
    //}

    //Raul: 15-03-2019 Ultimos Movimientos
    protected void Active_59_UltimosMov(object sender, EventArgs e)
    {
        ASPxGridView1.DataSource = null;
        ASPxGridView1.DataBind();
        ASPxGridView1.Visible = false;

        string Tarjeta = Session["NoTarjeta"].ToString();
        RadioButtonList19.Items.Clear();
        DataSet DT = new DataSet();

        try
        {
            DT = Servicio.Monedas(Tarjeta);
            if (RadioButtonList19.Items.Count == 0)
            {
                foreach (DataRow Row in DT.Tables[0].Rows)
                {
                    RadioButtonList19.Items.Add(Row[1].ToString());
                }
                RadioButtonList19.Enabled = true;


            }
        }
        catch (Exception msg)
        {

            throw new Exception("Ocurrio un problema a la hora de cargar la ventana de los Ultimos Movimientos: " + msg.Message.ToString());
        }

    }

    // Raul: Boton Consultar Ultimos Movimientos
    protected void ASPxButton1_Click1(object sender, EventArgs e)
    {
        string service = "00";
        DataSet ds = new DataSet();
        string tarjeta = NoTarjeta;
        //string moneda = RadioButtonList19.SelectedItem.Value.Equals("CUP") ? "40" : "43";
        string moneda_seleccionada = RadioButtonList19.SelectedItem.Value.ToString().Trim();
        string moneda = "";

        if (moneda_seleccionada == "CUP")
            moneda = "40";
        else if (moneda_seleccionada == "CUC")
            moneda = "43";
        else if (moneda_seleccionada == "USD")
            moneda = "01";
        
        string serv = DropDownList19.SelectedValue.ToString();

        string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;

        SqlConnection conx = new SqlConnection(cadena_conexion);
        conx.Open();
        SqlCommand comando = new SqlCommand("SELECT ID_SERV FROM dbo.TLB_C_SERVBT WHERE SERV_NOM ='" + serv + "'", conx);

        try
        {
            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                service = lector[0].ToString();
            }

            ds = Servicio.Ultimos_Movimientos(tarjeta, moneda, service);
            //ds.Tables[0].Columns.RemoveAt(6);           

            DataTable table = new DataTable();

            table = ds.Tables[0];

            ASPxGridView1.DataSource = table;
            ASPxGridView1.DataBind();
            ASPxGridView1.Visible = true;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    // Boton Cancelar Ultimos Movimientos
    protected void ASPxButton4_Click(object sender, EventArgs e)
    {
        ASPxGridView1.DataSource = null;
        ASPxGridView1.DataBind();

        RadioButtonList19.Items.Clear();
        DropDownList19.Items.Clear();

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }
    protected void RadioButtonList19_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList19.Items.Clear();
        ASPxGridView1.DataSource = null;
        ASPxGridView1.DataBind();

        if (RadioButtonList19.SelectedValue != null)
        {
            DropDownList19.Items.Add("Todos");
            string[] services = (string[])Session["Serv_Contratados"];
            for (int i = 0; i < services.Length; i++)
            {
                //ASPxComboBox1.Items.Add(services[i].ToString());
                DropDownList19.Items.Add(services[i].ToString());
            }

            DropDownList19.Enabled = true;
            ASPxButton1.Enabled = true;
        }
    }

    // Raul: Cancelar Registro Banca Movil
    protected void View60_Activate(object sender, EventArgs e)
    {
        TextBox79.Text = "";
        TextBox79.Focus();

        //ASPxButton2.Enabled = false;
    }

    // Boton Cancelar
    protected void ASPxButton3_Click(object sender, EventArgs e)
    {
        TextBox79.Text = "";

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }

    // Raul: Boton Aceptar Cancelar Registro Banca Movil
    protected void ASPxButton2_Click(object sender, EventArgs e)
    {
        string tarjeta = NoTarjeta;
        string movil = "53"+ TextBox79.Text;
        Regex rx = new Regex("^([535]{3})[0-9]{7}"); // expresion regular ^: inicia, ([535]): los tres primeros digitos obligados 535, [0-9]{7}: 7 digitos solo numeros

        if (!rx.IsMatch(movil) && movil.Length != 10)
        {
            TextBox79.Text = "";
            TextBox79.Focus();
            ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Numero de movil incorrecto o formato incorrecto');", true);
        }
        else
        {
 
            try
            {                
                    string resultado = Servicio.Cancelar_Registro_BancaMovil(tarjeta, movil);
                    if (resultado.Contains("REGISTRO CANCELADO"))
                    {
                        TextBox79.Text = "";
                        TextBox79.Focus();
                        Errores.Alert(this, resultado);
                    }
                    // aqui poner la condicion de si el resultado.Contains("el mensaje del error cuando fue cancelado anteriormente")
                    else
                    {
                        TextBox79.Text = "";
                        TextBox79.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Puede que el movil no este asociado a la tarjeta Telebanca, No se haya encontrado o fue Cancelado anteriormente');", true);
                    }
            }
            catch (Exception ex)
            {
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
        }


    }
    // localizacion
    protected void View64_LocaTransf_Activate(object sender, EventArgs e)
    {
        TextBox80.Text = "";
        TextBox80.Focus();
        ASPxGridView2.DataSource = null;
        ASPxGridView2.DataBind();
        Label184.Visible = false;
        Label184.Text = "";
    }

    // Raul: Evento que se encarga de cargar e ir preparando el Grid y luego dentro colorea las celdas dependiendo del estado del credito
    protected void ASPxGridView3_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
    {        

        if (e.DataColumn.FieldName == "estado")
        {
            string txt = e.CellValue.ToString();
             
            if (e.CellValue.ToString() == "Liquidado".ToUpper())
            {
                e.Cell.BackColor = Color.GreenYellow;
            }        
            else
            if (e.CellValue.ToString() == "Vencido".ToUpper())
            {
                e.Cell.BackColor = Color.LightCoral;
            }
            else
            if (e.CellValue.ToString() == "Cancelado".ToUpper())
            {
                e.Cell.BackColor = Color.NavajoWhite;
            }
            
        }


    }
    protected void ASPxGridView3_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
    {
        string ce = ASPxGridView3.GetDataRow(ASPxGridView3.FocusedRowIndex)["cuenta"].ToString();

        for (int i = 0; i < ASPxGridView3.VisibleRowCount; i++)
        {
            int id = Convert.ToInt32(ASPxGridView3.GetRowValues(i, ASPxGridView1.KeyFieldName));

        }

        string tx = ASPxGridView3.GetRowValues(1, ASPxGridView1.KeyFieldName).ToString();

        var products = ASPxGridView3.GetSelectedFieldValues("cuenta");
        ce = products[0].ToString();

        DataTable ds = (DataTable)ASPxGridView3.DataSource;
        var ide = ds.Rows[ASPxGridView3.FocusedRowIndex]["cuenta"];
    }
    protected void View58_Activate(object sender, EventArgs e)
    {
        ASPxButton7.Visible = false;
        fila_label_creditos_asociados.Visible = false;
        fila_label_notificacion.Visible = false;
        fila_verde1.Visible = false;
        fila_verde_info_cred.Visible = false;
        fila_verde3.Visible = false;
        fila_verde4.Visible = false;
        fila_verde5.Visible = false;
        fila_label_notificacion2.Visible = false;
        fila_label_efectuar_pago.Visible = false;
    }
    protected void ASPxGridView3_FocusedRowChanged(object sender, EventArgs e)
    {
        ASPxButton7.Enabled = true;
    }

    //boton ACEPTAR Localizar Transf Exterior
    protected void ASPxButton5_Click(object sender, EventArgs e)
    {
        try
        {

            Regex rx = new Regex("^([0-9]{1,11})"); // expresion regular ^: inicia, ([0-9]): solo numeros, {1,11}: desde 1 posicion a 11
            string num = TextBox80.Text.ToString().Trim();
            if (!rx.IsMatch(num))
            {
                Label184.Visible = true;
                Label184.Text = "El numero de carne no cumple el formato establecido";
                TextBox80.Focus();
                ASPxGridView2.DataSource = null;
                ASPxGridView2.DataBind();
                ASPxGridView2.Visible = false;
            }
            else
            {
                DataSet ds = new DataSet();
                string tarjeta = NoTarjeta;
                string num_ideper = TextBox80.Text;

                ds = Servicio.Localizar_TransfExterior(tarjeta, num_ideper);
                if (ds == null)
                {
                    Label184.Text = "Hubo un fallo. La Informacion solicitada desde la BD Telebanca hacia SABIC es nula";
                    Label184.Visible = true;
                    ASPxGridView2.DataSource = null;
                    ASPxGridView2.DataBind();
                    ASPxGridView2.Visible = false;
                }
                //else if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                //{
                //    Label184.Text = ds.Tables[]
                //    Label184.Visible = true;
                //    ASPxGridView2.DataSource = null;
                //    ASPxGridView2.DataBind();
                //    ASPxGridView2.Visible = false;
                //}
                else
                {
                    DataTable table = new DataTable();

                    table = ds.Tables[0];

                    Label184.Visible = false;
                    ASPxGridView2.DataSource = table;
                    ASPxGridView2.DataBind();
                    ASPxGridView2.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    protected void ASPxButton6_Click(object sender, EventArgs e)
    {
        ASPxGridView2.DataSource = null;
        ASPxGridView2.DataBind();
        TextBox80.Text = "";
        Label184.Visible = false;
        Label184.Text = "";

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }
    protected void View61_Activate(object sender, EventArgs e)
    {
        TextBox81.Text = "";
    }
    protected void Button147_Click(object sender, EventArgs e)
    {
        if (Calendar20.SelectedDate.CompareTo(Calendar21.SelectedDate) <= 0)
        {
            string oper = TextBox81.Text;
            string TipoOper = "UltimosMovimientos";
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteUltimosMov.aspx?Desde=" + Calendar20.SelectedDate.Date + "&Hasta=" + Calendar21.SelectedDate.Date + "&operador=" + oper + "&tipooper=" + TipoOper);
        }
    }
    protected void Button146_Click(object sender, EventArgs e)
    {
        TextBox81.Text = "";

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }
    protected void View63_Activate(object sender, EventArgs e)
    {
        TextBox82.Text = "";
    }

    protected void Button148_Click(object sender, EventArgs e)
    {
        DateTime fechaI = Calendar22.SelectedDate;
        DateTime fechaF = Calendar23.SelectedDate;

        if (fechaI.CompareTo(fechaF) <= 0)
        {
            string oper = TextBox82.Text;
            string TipoOper = "CancelacionBancaMovil";
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteCancelarBancaMovil.aspx?Desde=" + fechaI.Date + "&Hasta=" + fechaF.Date + "&operador=" + oper + "&tipooper=" + TipoOper);
        }
    }
    protected void TextBox74_TextChanged(object sender, EventArgs e)
    {
        Label174.Visible = false;
        Label175.Visible = false;
        Label172.Visible = false;
        Label173.Visible = false;
        TextBox77.Visible = false;
        Button143.Visible = false;
        fila_verde_info_cred.Visible = false;
        fila_verde3.Visible = false;
        fila_label_efectuar_pago.Visible = false;
        fila_verde5.Visible = false;
        fila_verde4.Visible = false;
        Button141.Visible = false;
        Button142.Visible = false;
        ASPxButton7.Enabled = false;
        ASPxGridView3.FocusedRowIndex = -1;
    }
    protected void Button149_Click(object sender, EventArgs e)
    {
        TextBox82.Text = "";

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }
    protected void View65_Activate(object sender, EventArgs e)
    {
        TextBox83.Text = "";        
    }
    protected void Button8_Click1(object sender, EventArgs e)
    {
        DateTime fechaI = Calendar24.SelectedDate;
        DateTime fechaF = Calendar25.SelectedDate;

        if (fechaI.CompareTo(fechaF) <= 0)
        {
            string oper = TextBox83.Text;
            string TipoOper = "ReportLocalizaTransf";
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteLocalizaTransfExterior.aspx?Desde=" + fechaI.Date + "&Hasta=" + fechaF.Date + "&operador=" + oper + "&tipooper=" + TipoOper);
        }
    }
    protected void Button150_Click(object sender, EventArgs e)
    {
        TextBox83.Text = "";
        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }
    protected void Button151_Click(object sender, EventArgs e)
    {
        string tb = "";
        bool error = false;

        try
        {
            string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;

            SqlConnection conx = new SqlConnection(cadena_conexion);
            conx.Open();
            SqlCommand comando = new SqlCommand("SSP_ACTUALIZAR_IDEPER_TB", conx);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_TARJETA", NoTarjeta);

            comando.Parameters.Add("@WRETURN", SqlDbType.VarChar, 1000);
            comando.Parameters["@WRETURN"].Direction = ParameterDirection.Output;
            comando.Parameters["@WRETURN"].Value = "";

            comando.Parameters.Add("@WRET", SqlDbType.Bit, 1);
            comando.Parameters["@WRET"].Direction = ParameterDirection.Output;
            comando.Parameters["@WRET"].Value = 0;

            comando.CommandTimeout = 180;

            comando.ExecuteNonQuery();

            Label188.Text = comando.Parameters["@WRETURN"].Value.ToString();
            error = bool.Parse(comando.Parameters["@WRET"].Value.ToString());

            if (error == true) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error. No se pudo actualizar la informacion');", true);   
            } 
            else if (error == false) 
            {
                Label188.BackColor = Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Informacion actualizadad satisfactoriamente');", true);
                this.View66_Activate(sender, e);
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    
    protected void View66_Activate(object sender, EventArgs e)
    {
        //ASPxButton8_Click(sender, e,"");
        //Button btn = new Button();
        //btn.Click += new EventHandler((snd,e1) => ASPxButton8_Click(snd,e1,"name"));
        Label188.Text = "";
        Label195.Text = "";

        this.DetailsView3.DataSource = null;
        this.DetailsView4.DataSource = null;
        this.DetailsView5.DataSource = null;

        string num_ideper_sabic="";
        string id_pais_sabic="";
        string tipid_sabic="";
        string num_ideper_telebanca="";
        string tipid_telebanca = "";
        string idpais_telebanca="";
        string num_ideper_bmovil="";
        string tipid_bmovil = "";
        string idpais_bmovil="";
       
        Class1 MyClass = new Class1();

        //buscar los datos en telebanca
        string telebanca = NoTarjeta;
        try
        {
            if (telebanca != null)
            {
                MyDataSet DTS = MyClass.DatosTarjeta(telebanca);
                if (DTS.DatosTarjetas != null && DTS.DatosTarjetas.Rows.Count != 0)
                {
                    DTS.DatosTarjetas.Columns[0].ColumnName = "Tarjeta";
                    DTS.DatosTarjetas.Columns[5].ColumnName = "Sucursal";
                    DTS.DatosTarjetas.Columns[13].ColumnName = "Identificacion Pais";
                    DTS.DatosTarjetas.Columns[12].ColumnName = "Tipo Identificacion";
                    DTS.DatosTarjetas.Columns[11].ColumnName = "No.Identidad";
                    DTS.DatosTarjetas.Columns.RemoveAt(15); // coordenada
                    DTS.DatosTarjetas.Columns.RemoveAt(14);
                    DTS.DatosTarjetas.Columns.RemoveAt(10);
                    DTS.DatosTarjetas.Columns.RemoveAt(9);
                    DTS.DatosTarjetas.Columns.RemoveAt(8);// estado
                    DTS.DatosTarjetas.Columns.RemoveAt(7);
                    DTS.DatosTarjetas.Columns.RemoveAt(6);
                    DTS.DatosTarjetas.Columns.RemoveAt(4);
                    DTS.DatosTarjetas.Columns.RemoveAt(3);// apellido1
                    DTS.DatosTarjetas.Columns.RemoveAt(2); // nombre
                    DTS.DatosTarjetas.Columns.RemoveAt(1);// pin

                    num_ideper_telebanca = DTS.DatosTarjetas[0].IdentificacionCliente.ToString().Trim();
                    tipid_telebanca = DTS.DatosTarjetas[0].TipoIdentificacion.ToString().Trim();
                    idpais_telebanca = DTS.DatosTarjetas[0]["Identificacion Pais"].ToString().Trim();

                    //TextBox84.Text = num_ideper_telebanca;
                    //TextBox85.Text = tipid_telebanca;
                    //TextBox86.Text = idpais_telebanca;

                    // llenar el detailView de Telebanca

                    this.DetailsView4.DataSource = DTS.DatosTarjetas;
                    this.DetailsView4.DataBind();
                }
                else 
                { 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se encontro informacion en Telebanca');", true);
                    //return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Tarjeta telebanca no autenticada');", true);
                return;
            }
                //buscar los datos ahora en sabic
                DataSet m_tarj = this.Servicio.Datos_Mtarj(NoTarjeta);
                if (m_tarj != null && m_tarj.Tables[0].Rows.Count != 0)
                {

                    m_tarj.Tables[0].Columns[0].ColumnName = "Tarjeta";
                    m_tarj.Tables[0].Columns[2].ColumnName = "No.Identidad";
                    m_tarj.Tables[0].Columns[3].ColumnName = "Identificacion Pais";
                    m_tarj.Tables[0].Columns[4].ColumnName = "Tipo Identificacion";
                    m_tarj.Tables[0].Columns.RemoveAt(5);
                    m_tarj.Tables[0].Columns.RemoveAt(1);
            
                    num_ideper_sabic = m_tarj.Tables[0].Rows[0]["No.Identidad"].ToString();
                    id_pais_sabic = m_tarj.Tables[0].Rows[0]["Identificacion Pais"].ToString();
                    tipid_sabic = m_tarj.Tables[0].Rows[0]["Tipo Identificacion"].ToString();

                    // llenar el detailView de sabic
                    this.DetailsView3.DataSource = m_tarj;
                    this.DetailsView3.DataBind();

                    
                    //ASPxLabel4.Visible = true;
                    //TextBox84.Visible = true;
                    Button151.Visible = true;
                    Button152.Visible = true;

                    columna_verde_sucursal.Visible = true;
                    columna_verde_telebanca.Visible = true;            

                }
                else 
                { 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se encontro informacion en M_TARJ del SABIC');", true);
                    //return;
                }

                // buscar datos en banca movil
                
                MyDataSet DTS2 = MyClass.DatosClienteBmovil(telebanca);
                if (DTS2.DatosClienteBMovil != null && DTS2.DatosClienteBMovil.Rows.Count != 0)
                {

                    DTS2.DatosClienteBMovil.Columns[0].ColumnName = "Tarjeta";
                    DTS2.DatosClienteBMovil.Columns[1].ColumnName = "No.Identidad";
                    DTS2.DatosClienteBMovil.Columns[2].ColumnName = "Tipo Identificacion";
                    DTS2.DatosClienteBMovil.Columns[3].ColumnName = "Identificacion Pais";


                    num_ideper_bmovil = DTS2.DatosClienteBMovil[0].NUM_IDEPER.ToString().Trim();
                    tipid_bmovil = DTS2.DatosClienteBMovil[0].COD_TIPID.ToString().Trim();
                    idpais_bmovil = DTS2.DatosClienteBMovil[0].COD_PAEXID.ToString().Trim();

                    //TextBox84.Text = num_ideper_telebanca;
                    //TextBox85.Text = tipid_telebanca;
                    //TextBox86.Text = idpais_telebanca;

                    // llenar el detailView de Banca Movil

                    this.DetailsView5.DataSource = DTS2.DatosClienteBMovil;
                    this.DetailsView5.DataBind();
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Este cliente no tiene informacion en Banca Movil');", true);
                    //return;
                }

                if (num_ideper_sabic != num_ideper_bmovil || tipid_sabic != tipid_bmovil || id_pais_sabic != idpais_bmovil || num_ideper_sabic != num_ideper_telebanca || tipid_sabic != tipid_telebanca || id_pais_sabic != idpais_telebanca)
                {
                    Label195.Text = "* La informacion del cliente en la Sucursal no coincide con la del resto de los sistemas. !Actualicelo! *";
                    Label195.ForeColor = Color.Red;
                    Label195.Visible = true;

                    Label188.Visible = false;
                    
                    Button151.Enabled = true;

                    #region Comparacion de los tres campos llaves:
                    //chequear si los num_ideper son distintos a los del M_TARJ del SABIC
                    if (num_ideper_sabic != num_ideper_telebanca || num_ideper_sabic != num_ideper_bmovil)
                    {
                        foreach (DetailsViewRow row in DetailsView3.Rows)
                        {
                            if (row.Cells[0].Text == "No.Identidad") // verificando el No.Identidad
                            {
                                foreach (DetailsViewRow item in DetailsView4.Rows) // detailview de telebanca
                                {
                                    while(item.Cells[0].Text == "No.Identidad")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }
                                foreach (DetailsViewRow item in DetailsView5.Rows) // detailview de bancamovil
                                {
                                    while (item.Cells[0].Text == "No.Identidad")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }

                                //row.Cells[1].ForeColor = Color.Red;
                            }
                            else if (row.Cells[0].Text == "Identificacion Pais") // verificando el Identificacion Pais
                            {
                                foreach (DetailsViewRow item in DetailsView4.Rows) // detailview de telebanca
                                {
                                    while (item.Cells[0].Text == "Identificacion Pais")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }
                                foreach (DetailsViewRow item in DetailsView5.Rows) // detailview de bancamovil
                                {
                                    while (item.Cells[0].Text == "Identificacion Pais")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }                                
                            }
                            else if (row.Cells[0].Text == "Tipo Identificacion") // verificando el Tipo Identificacion
                            {
                                foreach (DetailsViewRow item in DetailsView4.Rows) // detailview de telebanca
                                {
                                    while (item.Cells[0].Text == "Tipo Identificacion")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }
                                foreach (DetailsViewRow item in DetailsView5.Rows) // detailview de bancamovil
                                {
                                    while (item.Cells[0].Text == "Tipo Identificacion")
                                    {
                                        if (row.Cells[1].Text == item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Green;
                                            break;
                                        }
                                        if (row.Cells[1].Text != item.Cells[1].Text)
                                        {
                                            item.Cells[1].ForeColor = Color.Red;
                                            break;
                                        }
                                    }
                                }
                            }
                            
                        }
                        //foreach (DetailsViewRow row in DetailsView4.Rows)
                        //{
                        //    if (row.Cells[0].Text == "No.Identidad")
                        //    {
                        //        row.Cells[1].ForeColor = Color.Red;
                        //    }
                        //}
                    }
                    ////chequear si los tipid son distintos
                    //if (tipid_sabic != tipid_telebanca)
                    //{
                    //    foreach (DetailsViewRow row in DetailsView3.Rows)
                    //    {
                    //        if (row.Cells[0].Text == "Tipo Identificacion")
                    //        {
                    //            row.Cells[1].ForeColor = Color.Red;
                    //        }
                    //    }
                    //    foreach (DetailsViewRow row in DetailsView4.Rows)
                    //    {
                    //        if (row.Cells[0].Text == "Tipo Identificacion")
                    //        {
                    //            row.Cells[1].ForeColor = Color.Red;
                    //        }
                    //    }
                    //}
                    ////chequear si los idpais son distintos
                    //if (id_pais_sabic != idpais_telebanca)
                    //{
                    //    foreach (DetailsViewRow row in DetailsView3.Rows)
                    //    {
                    //        if (row.Cells[0].Text == "Identificacion Pais")
                    //        {
                    //            row.Cells[1].ForeColor = Color.Red;
                    //        }
                    //    }
                    //    foreach (DetailsViewRow row in DetailsView4.Rows)
                    //    {
                    //        if (row.Cells[0].Text == "Identificacion Pais")
                    //        {
                    //            row.Cells[1].ForeColor = Color.Red;
                    //        }
                    //    }
                    //}
                    #endregion
                }
                else
                {
                    Label188.Text = "La informacion del cliente esta correctamente y no necesita ser actualizada";
                    Label188.Visible = true;

                    Label195.Visible = false;
                    
                    Button151.Enabled = false;
                }
        }
        catch (Exception)
        {
            throw;
        }



    }

    // boton ver datos del cliente en telebanca
    protected void ASPxButton8_Click(object sender, EventArgs e, string name)
    {
        string telebanca = NoTarjeta;
        try 
	    {	        
            if (telebanca != null)
            {
                Class1 MyClass = new Class1();
                MyDataSet DTS = MyClass.DatosTarjeta(telebanca);
                if (DTS.DatosTarjetas != null)
                {
                    DTS.DatosTarjetas.Columns[0].ColumnName = "Tarjeta";
                    DTS.DatosTarjetas.Columns[5].ColumnName = "Sucursal";
                    DTS.DatosTarjetas.Columns[13].ColumnName = "Identificacion Pais";
                    DTS.DatosTarjetas.Columns[12].ColumnName = "Tipo Identificacion";
                    DTS.DatosTarjetas.Columns[11].ColumnName = "No.Identidad";
                    DTS.DatosTarjetas.Columns.RemoveAt(15); // coordenada
                    DTS.DatosTarjetas.Columns.RemoveAt(14);
                    DTS.DatosTarjetas.Columns.RemoveAt(10);
                    DTS.DatosTarjetas.Columns.RemoveAt(9);
                    DTS.DatosTarjetas.Columns.RemoveAt(8);// estado
                    DTS.DatosTarjetas.Columns.RemoveAt(7);
                    DTS.DatosTarjetas.Columns.RemoveAt(6);
                    DTS.DatosTarjetas.Columns.RemoveAt(4);
                    DTS.DatosTarjetas.Columns.RemoveAt(3);// apellido1
                    DTS.DatosTarjetas.Columns.RemoveAt(2); // nombre
                    DTS.DatosTarjetas.Columns.RemoveAt(1);// pin

                    string num_ideper_telebanca = DTS.DatosTarjetas[0].IdentificacionCliente.ToString();
                    string tipid_telebanca = DTS.DatosTarjetas[0].TipoIdentificacion.ToString();
                    string idpais_telebanca = DTS.DatosTarjetas[0]["Identificacion Pais"].ToString();

                    //TextBox84.Text = num_ideper_telebanca;
                    //TextBox85.Text = tipid_telebanca;
                    //TextBox86.Text = idpais_telebanca;

                    // llenar el detailView de Telebanca

                    this.DetailsView4.DataSource = DTS.DatosTarjetas;
                    this.DetailsView4.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se encontro informacion en Telebanca');", true); }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Tarjeta telebanca no autenticada');", true);
            }	        	
	    }
	    catch (Exception)
	    {
		    throw;
	    }

        
    }

    //protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (CheckBox5.Checked)
    //    {
    //        this.TextBox84.Text = "";
    //        this.TextBox85.Text = "";
    //        this.TextBox86.Text = "";

    //        this.TextBox84.Enabled = true;
    //        this.TextBox85.Enabled = true;
    //        this.TextBox86.Enabled = true;
    //    }
    //    else
    //    {
    //        this.TextBox84.Text = "";
    //        this.TextBox85.Text = "";
    //        this.TextBox86.Text = "";

    //        this.TextBox84.Enabled = false;
    //        this.TextBox85.Enabled = false;
    //        this.TextBox86.Enabled = false;
    //    }

    //}
    protected void Button153_Click(object sender, EventArgs e)
    {
        try
        {
            // conformar las 2 coordenadas
            string c1 = Servicio.PreguntarCoordenada();
            string c2 = Servicio.PreguntarCoordenada();
            if (c1 != "" && c2 != "")
            {
                Label196.Text = c1 + " - " + c2;
                Label196.Visible = true;
            }
            else 
            {
                Label192.Text = "Error. Coordenadas en blanco";
                Label192.Visible = true;
            }
        }       
        catch (Exception ex)
        {
            throw new Exception("Hubo un error a la hora de generar el par de coordenadas. "+ ex.Message);
        }
    }

    #region <Boton Procesa Anterior para lo del PIN Digital>
    //protected void Button155_Click(object sender, EventArgs e)
    //{
    //    //vaciando el GridView5 del resultado de inicio
    //    ASPxGridView5.DataSource = null;
    //    ASPxGridView5.DataBind();

    //    //label192 del texto de error a mostrar, limpiarlo de inicio
    //    Label192.Visible = false;
    //    Label192.Text = "";

    //    // boton guardar de inicio deshabilitado
    //    Button156.Enabled = false;

    //    // label193 de las coordenadas limpiar desde el inicio
    //    Label193.Visible = false;
    //    Label193.Text = "";

    //    string nombre_bt = "";
    //    string num_pan="";
    //    string tarjeta_bt = "";
    //    string numideper = "";
    //    string codtipid = "";
    //    string codpais = "";
    //    string resultado_coordenadas = "";

    //    bool validado = false;
    //    string mensaje = "";
    //    int codigo_error = 0;
    //    string[] array_coord = new string[2];

    //    DataSet ws_resultado = new DataSet();
    //    DataSet data_set_save = new DataSet();
        
    //    DataSet info_pan = new DataSet();
    //    DataTable tabla_resultado_ok = new DataTable();
    //    tabla_resultado_ok.Columns.Add("Cliente");
    //    tabla_resultado_ok.Columns.Add("Identificacion");
    //    tabla_resultado_ok.Columns.Add("Tipo_Identificacion");
    //    tabla_resultado_ok.Columns.Add("Codigo_Pais");
    //    tabla_resultado_ok.Columns.Add("Tarjeta_Magnetica");
    //    tabla_resultado_ok.Columns.Add("Categoria_Persona");
    //    tabla_resultado_ok.Columns.Add("Coordenadas");

    //    DataTable tabla_resultado_error = new DataTable();
    //    tabla_resultado_error.Columns.Add("Mensaje_Error");
    //    tabla_resultado_error.Columns.Add("Codigo_Error");

    //    info_pan.Tables.Add(tabla_resultado_ok);
    //    info_pan.Tables.Add(tabla_resultado_error);

    //    DataRow fila1 = info_pan.Tables[0].NewRow();
    //    DataRow fila2 = info_pan.Tables[1].NewRow();

    //    string texto_error = "";
    //    int cod_err = 0;

    //    string estado_ok_encrypt = "";

    //    try
    //    {
    //        if (TextBox87.Value != "" && TextBox88.Value != "" && TextBox89.Value != "" && TextBox90.Value != "")
    //        {
    //            num_pan = TextBox87.Value + TextBox88.Value + TextBox89.Value + TextBox90.Value;
    //            tarjeta_bt = NoTarjeta;
    //            nombre_bt = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Cliente").ToString().Trim();
    //            numideper = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Identificacion").ToString().Trim();
    //            codtipid = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Codigo_Identificacion").ToString().Trim();
    //            codpais = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Codigo_Pais").ToString().Trim();
    //            resultado_coordenadas = "";

    //            // primero busco los datos de la tarjeta magnetica para verificar que este asociada al # de telebanca:
    //            ws_resultado = Servicio.Datos_PAN(num_pan, tarjeta_bt, numideper, codtipid, codpais, out texto_error, out cod_err);

    //            if (ws_resultado != null && ws_resultado.Tables[1].Rows[0][1].ToString() == "0" && cod_err == 0)
    //            {
    //                foreach (DataTable item in ws_resultado.Tables)
    //                {
    //                    foreach (DataRow rowitem in item.Rows)
    //                    {
    //                        string nombre = rowitem["Nombre_Titular"].ToString();
    //                        string numidentidad = rowitem["Num_Identidad"].ToString();
    //                        string tipoidentif = rowitem["Tipo_Identificacion"].ToString();
    //                        Session["Tipid_Magnetica"] = tipoidentif;

    //                        string codigopais = rowitem["Cod_Pais"].ToString();
    //                        Session["CodPais_Magnetica"] = codpais;

    //                        string tarjeta_pan = rowitem["Tarjeta_Magnetica"].ToString();
    //                        string codigocategoria = rowitem["Cod_CatPer"].ToString();
    //                        string categoria = rowitem["Cat_Per"].ToString().Trim();                            

    //                        fila1[0] = nombre;
    //                        fila1[1] = numidentidad;
    //                        fila1[2] = tipoidentif;
    //                        fila1[3] = codigopais;
    //                        fila1[4] = tarjeta_pan;                            
    //                        fila1[5] = categoria;

    //                        //if (codigocategoria.Trim() == "30" && categoria.Trim() == "Titular" && numideper.Trim() == numidentidad && codtipid.Trim() == tipoidentif && codpais.Trim() == codigopais)
    //                        if (tarjeta_pan.Trim() == num_pan.Trim() && numideper.Trim() == numidentidad.Trim() && codtipid.Trim() == tipoidentif.Trim() && codpais.Trim() == codigopais.Trim())
    //                        {
    //                            string clave_activa_des = "";
    //                            string clave_activa_hmac = "";
    //                            #region<Generando las coordenadas - Generando PINBLOCK - Cifrando PINBLOCK>
    //                            try
    //                            {
    //                                // conformar las 2 coordenadas que se le muestra al cliente:
    //                                string c1 = Servicio.PreguntarCoordenada();
    //                                string c2 = Servicio.PreguntarCoordenada();
    //                                if (c1 != "" && c2 != "")
    //                                {
    //                                    resultado_coordenadas = c1 + " - " + c2;
    //                                    fila1[6] = resultado_coordenadas;
    //                                    //Label193.Text = c1 + " - " + c2;
    //                                    //Label193.Visible = true;
    //                                    array_coord[0] = c1;
    //                                    array_coord[1] = c2;

    //                                    //obteniendo el valor de las coordenadas
    //                                    string[] valores_coord = Servicio.ObtenerValoresCoordenadas(array_coord);
                                        
    //                                    string pin_coordenada = String.Join("", valores_coord); // esta es la linea que debe ir, la de abajo es para la prueba con REDSA

    //                                    //string pin_coordenada = "1234"; // pin para la prueba con REDSA

    //                                    //generar el pinblock (pin generado por el par de coordenadas + num tarj magnetica)
    //                                    string pin_block = generarPINBlock(pin_coordenada, num_pan);


    //                                    // cifrar el PINBLOCK (definir si va a ser con HMAC o DES)

    //                                    #region <con DES>
    //                                    // probando con DES:
    //                                    try
    //                                    {
    //                                        EncryptDES des = new EncryptDES();
                                                                                        
    //                                        byte[] key = EncryptDES.StringToBinary("43B6C19B2CEA3743"); // aqui deberia buscar la llave que debe estar almacenada en sabic en una tabla

    //                                        byte[] pinblock_byte = EncryptDES.StringToBinary(pin_block);

    //                                        byte[] cifrado = EncryptDES.Encrypt_DES(EncryptDES.Modo.ENCRIPTAR, key, pinblock_byte);

    //                                        clave_activa_des = EncryptDES.ByteArrString(cifrado);


    //                                    }
    //                                    catch (Exception)
    //                                    {

    //                                        throw;
    //                                    }
    //                                    #endregion

    //                                    #region <con HMAC256>
    //                                    // probando con HMAC256:
    //                                    //try
    //                                    //{
    //                                    //    clave_activa_hmac = Encrypt_HMAC_256.CreateToken(pin_block, "metropolitano209");
    //                                    //}
    //                                    //catch (Exception)
    //                                    //{

    //                                    //    throw;
    //                                    //}
    //                                    #endregion

    //                                    if (clave_activa_des != "" && clave_activa_des.Length == 16)
    //                                    {
    //                                        estado_ok_encrypt = "0";
    //                                    }
    //                                    //DateTime vencimiento_activa = DateTime.Now;

    //                                    //salvando la informacion en sabic
    //                                    //data_set_save = Servicio.GuardarInfoPAN_Activacion(num_pan, numideper, code, estado_ok, out mensaje, out codigo_error);

    //                                    if (estado_ok_encrypt == "0")
    //                                    {
    //                                        //salvando la informacion en sabic, en la tabla M_PANACTTMP
    //                                        data_set_save = Servicio.GuardarInfoPAN_Activacion(num_pan, numideper, clave_activa_des, estado_ok_encrypt, out mensaje, out codigo_error);
    //                                        if (data_set_save != null)
    //                                        {
    //                                            if (mensaje == "Resultado satisfactorio" && codigo_error == 0)
    //                                            {                                                                                                     
    //                                                //info_pan.Tables.Remove("Table2");

    //                                                tabla_resultado_ok.Rows.Add(fila1);
    //                                                tabla_resultado_ok.Columns.Remove("Tipo_Identificacion");
    //                                                tabla_resultado_ok.Columns.Remove("Codigo_Pais");
    //                                                tabla_resultado_ok.Columns.Remove("Categoria_Persona");

    //                                                ASPxGridView5.DataSource = info_pan;
    //                                                ASPxGridView5.DataBind();
    //                                                ASPxGridView5.Visible = true;

    //                                                // darle color a la celda del PAN y las coordenadas
    //                                                ASPxGridView5.Columns[3].CellStyle.BackColor = Color.Aqua; // color del fondo de la celda de la coordenada azulagua
    //                                                ASPxGridView5.Columns[3].CellStyle.ForeColor = Color.Black; // color del texto de la coordenada negro
    //                                                ASPxGridView5.Columns[3].CellStyle.Font.Bold = true; // texto de la coordenada en negrita


    //                                                Label193.Text = ASPxGridView5.GetRowValues(0, "Coordenadas").ToString().Trim();
    //                                                Label193.Visible = true;
    //                                                Button155.Enabled = false;

    //                                                Session["Pan_Magnetica"] = num_pan;
    //                                                Session["Coord_Magnetica"] = Label193.Text;
    //                                                Session["NumIdeper_Magnetica"] = numidentidad;
    //                                                Session["Tipid_Magnetica"] = tipoidentif;
    //                                                Session["CodPais_Magnetica"] = codpais;
    //                                            }
    //                                            else
    //                                            {
    //                                                Label192.Text = mensaje;
    //                                                Label192.Visible = true;

    //                                                ASPxGridView5.DataSource = info_pan;
    //                                                ASPxGridView5.DataBind();
    //                                                ASPxGridView5.Visible = true;

    //                                                Button156.Enabled = false;
    //                                            }

    //                                        }
    //                                        else
    //                                        {
    //                                            Label192.Text = "Ha ocurrido un error a la hora de procesar la solicitud";
    //                                            Label192.Visible = true;

    //                                            ASPxGridView5.DataSource = null;
    //                                            ASPxGridView5.DataBind();
    //                                            ASPxGridView5.Visible = false;

    //                                            Button156.Enabled = false;

    //                                            this.Insertar_Bitacora(tarjeta_pan, "", numideper, tipoidentif, codpais, "S", "Solicitud_Pin", "GETDATE()", "Solicita el PIN Digital de la tarjeta magnetica: " + tarjeta_pan + " pero no se pudo guardar la informacion en SABIC.", "ERROR: Fallo en el intento de guardar la informacion en SABIC. El DataSet del resultado a la hora de guardar la informacion en SABIC esta NULL. Verifique el SP ssp_BTSetPanInfo");
    //                                        }
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    Label192.Text = "Error. Coordenadas no generadas";
    //                                    Label192.Visible = true;

    //                                    ASPxGridView5.DataSource = null;
    //                                    ASPxGridView5.DataBind();
    //                                    ASPxGridView5.Visible = false;
                                        
    //                                    Button156.Enabled = false;

    //                                    this.Insertar_Bitacora(tarjeta_pan, "", numideper, tipoidentif, codpais, "S", "Solicitud_Pin", "GETDATE()", "Solicita el PIN Digital de la tarjeta magnetica: " + tarjeta_pan + " pero no se generaron correctamente las coordenadas.", "ERROR: Fallo en a la hora de generar las coordenadas");

    //                                }
    //                            }
    //                            catch (Exception)
    //                            {
    //                                throw;
    //                            }
    //                            #endregion

    //                            //info_pan.Tables.Remove("Table2");
    //                            break;
    //                        }
    //                        else
    //                        {
    //                            Label192.Text = "Cliente no autorizado para solicitar la activacion de esta tarjeta";
    //                            Label192.Visible = true;

    //                            ASPxGridView5.DataSource = null;
    //                            ASPxGridView5.DataBind();
    //                            ASPxGridView5.Visible = false;

    //                            Button156.Enabled = false;

    //                            this.Insertar_Bitacora(tarjeta_pan, "", numideper, tipoidentif, codpais, "S", "Solicitud_Pin", "GETDATE()", "Solicita el PIN Digital de la tarjeta magnetica: " + tarjeta_pan + " pero no esta autorizado.", "ERROR: Cliente no autorizado para solicitar PIN");
    //                            break;
    //                        }
    //                    }
    //                    break;
    //                }


    //                //ASPxGridView5.DataSource = info_pan;
    //                //ASPxGridView5.DataBind();
    //                //ASPxGridView5.Visible = true;
    //                if (mensaje == "Resultado satisfactorio" && codigo_error == 0)
    //                { 
    //                    if (info_pan != null && info_pan.Tables[0].Rows[0]["Coordenadas"].ToString().Trim() != "")
    //                    {
    //                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Estimado Cliente: Para la activacion de su tarjeta: " + num_pan.Substring(0, 4) + "-" + num_pan.Substring(4, 4) + "-" + num_pan.Substring(8, 4) + "-" + num_pan.Substring(12, 4) + " debe dirigirse a un cajero automatico y por la opcion: ACTIVACION DE TARJETA, introducir el valor de las coordenadas: " + resultado_coordenadas + " los cuales corresponden a su tarjeta telebanca. Nota: Para mayor seguridad este pin inicial debe ser cambiado posteriormente');", true);
    //                        Button156.Enabled = true;
    //                        Button155.Enabled = false;
                        
    //                    }
    //                    else
    //                    {
    //                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Ha ocurrido un error a la hora de procesar la activacion del PIN del numero de de la cuenta: " + num_pan.Substring(0, 4) + "-" + num_pan.Substring(4, 4) + "-" + num_pan.Substring(8, 4) + "-" + num_pan.Substring(12, 4) + ". Favor de verificar que la tarjeta telebanca este asociada al numero de tarjeta magnetica');", true);
    //                        Button156.Enabled = false;
    //                        Button155.Enabled = true;

    //                        //guardar en el bitacora de telebanca
    //                        string tarj_pan = info_pan.Tables[0].Rows[0]["Pan"].ToString().Trim();
    //                        string ideper = info_pan.Tables[0].Rows[0]["Identificacion"].ToString().Trim();
    //                        string fecha_actual = "GETDATE()";
    //                        string coord = info_pan.Tables[0].Rows[0]["Coordenadas"].ToString().Trim();
    //                        string observacion = "Intento solicitud del PIN Digital de la tarjeta magnetica: " + tarj_pan + ". #BT: " + tarjeta_bt.Trim();
    //                        this.Insertar_Bitacora(tarj_pan, "", ideper, codtipid, codpais, "S", "Solicitud_Pin", fecha_actual, observacion, "ERROR: " + mensaje + ". CODIGO_ERROR: " + cod_err.ToString().Trim());
    //                    }                    
    //                }
    //            }
    //            else if (ws_resultado != null && ws_resultado.Tables[1].Rows[0][0].ToString() != "" && cod_err == 0)
    //            {
    //                foreach (DataRow rowitem2 in ws_resultado.Tables[1].Rows)
    //                {                                                

    //                    string txt_error = rowitem2["Mensaje"].ToString();
    //                    string codigoerror = rowitem2["Cod_Error"].ToString();

    //                    fila2[0] = txt_error;
    //                    fila2[1] = codigoerror;

    //                    tabla_resultado_error.Rows.Add(fila2);

    //                    Label192.Text = txt_error;
    //                    Label192.Visible = true;

    //                    //ASPxGridView5.Columns.Clear();

    //                    //ASPxGridView5.DataSource = tabla_resultado_error;
    //                    //ASPxGridView5.DataBind();
    //                    //ASPxGridView5.Visible = true;

    //                    Button156.Enabled = false;
    //                    Button155.Enabled = true;

    //                    if (this.Insertar_Bitacora(num_pan, "", numideper, codtipid, codpais, "S", "Solicitud_Pin", "GETDATE()", "Solicita el PIN Digital de la tarjeta magnetica: " + num_pan + " pero los datos no coinciden. Verificar si esta asociada a la persona: "+nombre_bt.Trim()+" NUM_IDEPER: "+numideper.Trim()+" BT: " + tarjeta_bt + ". ", "ERROR: " + txt_error+". Codigo: "+codigo_error))
    //                    {
    //                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('La informacion relacionada con la tarjeta no corresponde con la informacion almacenada. Verifique que: NUMERO IDENTIDAD, TIPO IDENTIFICACION, CODIGO PAIS coincidan con lo registrado en la sucursal. " + txt_error + "');", true);
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Numero de cuenta incorrecto. Verifique que todos los campos esten correctamente');", true);
    //            Label192.Text = "Numero de cuenta incorrecto";
    //            Label192.Visible = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        TextBox87.Value = "";
    //        TextBox88.Value = "";
    //        TextBox89.Value = "";
    //        TextBox90.Value = "";

    //          /*nuevo*/
    //            SqlConnection conx = new SqlConnection();

    //            try
    //            {
    //                string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
    //                conx.ConnectionString = cadena_conexion;
    //                conx.Open();

    //                string excepcion = ex.Message.Replace("'", "");
    //                excepcion = excepcion.Replace(":", "");

    //                SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES('" + num_pan + "','','" + numideper + "','" + codtipid + "','" + codpais + "','S','Solicitud_Pin',GETDATE(),'Solicitud del PIN digital de la tarjeta magnetica: " + num_pan + "','ERROR SOLICITUD PIN DIGITAL. " + excepcion.Trim() + "')", conx);
    //                int i = cm.ExecuteNonQuery();
    //                if (i != 1)
    //                {
    //                    Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //                }

    //            }
    //            catch (Exception ex1)
    //            {
    //                enviar_error = "Error al intentar insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
    //                Errores.Alert(this, enviar_error);
                    
    //                //Session["Texto_Error"] = enviar_error;
    //                //Response.Redirect("~/Error500.aspx");
    //                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
    //            }

    //            //conx.Close();
    //            //enviar_error = ex.Message.ToString().Trim();
    //            //Session["Texto_Error"] = enviar_error;
    //            //Response.Redirect("~/Error500.aspx");
    //            //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

    //            /*/nuevo*/  

    //            this.View67_Activate(sender, e);
                       
    //        ASPxGridView5.DataSource = null;
    //        ASPxGridView5.DataBind();
    //        ASPxGridView5.Visible = false;

    //        Label192.Visible = true;
    //        Label192.Text = "Ha ocurrido un problema. Verifique problemas de conexion o de datos incorrectos";

    //        Button156.Enabled = false;

    //        Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
    //    }
    //}

    #endregion

    protected void Button155_Click(object sender, EventArgs e)
    {
        //vaciando el GridView5 del resultado de inicio
        ASPxGridView5.DataSource = null;
        ASPxGridView5.DataBind();

        //label192 del texto de error a mostrar, limpiarlo de inicio
        Label192.Visible = false;
        Label192.Text = "";

        // boton guardar de inicio deshabilitado
        //Button156.Enabled = false;

        // label193 de las coordenadas limpiar desde el inicio
        Label196.Visible = false;
        Label196.Text = "";

        string nombre_bt = "";
        string num_pan = "";
        string tarjeta_bt = "";
        string numideper = "";
        string codtipid = "";
        string codpais = "";
        string resultado_coordenadas = "";
        string mensaje = "";

        DataSet info_pan = new DataSet();
        DataTable tabla_resultado_ok = new DataTable();
        tabla_resultado_ok.Columns.Add("Cliente");
        tabla_resultado_ok.Columns.Add("Tarjeta_Magnetica");
        tabla_resultado_ok.Columns.Add("Coordenadas");

        DataTable tabla_resultado_error = new DataTable();
        tabla_resultado_error.Columns.Add("Mensaje_Error");
        tabla_resultado_error.Columns.Add("Codigo_Error");

        info_pan.Tables.Add(tabla_resultado_ok);
        info_pan.Tables.Add(tabla_resultado_error);

        DataRow fila1 = info_pan.Tables[0].NewRow();
        DataRow fila2 = info_pan.Tables[1].NewRow();


        try
        {
            if (ASPxGridView6.FocusedRowIndex == -1 || ASPxGridView6.FocusedRowIndex == null || ASPxGridView6.FocusedRowIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "cta_pan", "alert('PARA ACTIVAR EL PIN DEBE SELECCIONAR UNA DE LAS TARJETAS');", true);// este muestra el mensaje como un modal
                return;
            }
            else
            if (ASPxGridView6.VisibleRowCount != 0)
            {

                num_pan = ASPxGridView6.GetRowValues(ASPxGridView6.FocusedRowIndex, ASPxGridView6.KeyFieldName).ToString().Trim();
                tarjeta_bt = NoTarjeta;
                nombre_bt = ASPxGridView4.GetRowValues(ASPxGridView4.FocusedRowIndex,"Cliente").ToString().Trim();
                numideper = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Identificacion").ToString().Trim();
                codtipid = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Codigo_Identificacion").ToString().Trim();
                codpais = ASPxGridView4.GetRowValues(ASPxGridView4.GetRowLevel(0), "Codigo_Pais").ToString().Trim();
                resultado_coordenadas = "";
                

                DataSet ds_activacion = new DataSet();
                ds_activacion = Servicio.Solicitud_PinDigital_Magnetica(tarjeta_bt, num_pan);
                if (ds_activacion.Tables.Count > 0)
                {
                    if (ds_activacion.Tables.Count == 1)
                    {
                        mensaje = ds_activacion.Tables[0].Rows[0][0].ToString().Trim();
                        Label192.Text = "Lo sentimos. " + num_pan + " : " + mensaje;
                        Label192.Visible = true;
                        Label196.Text = "";
                        Label196.Visible = false;
                        ASPxGridView5.DataSource = null;
                        ASPxGridView5.DataBind();
                        ASPxGridView5.Visible = false;
                    }
                    else
                    {
                            foreach (DataRow row in ds_activacion.Tables[1].Rows)
                            {
                                int cant_caracteres_coord = row.ItemArray[0].ToString().Trim().Length;
                                if (row.ItemArray[0].ToString() != "" && cant_caracteres_coord >= 5 && cant_caracteres_coord <= 7)
                                {
                                    resultado_coordenadas = row.ItemArray[0].ToString().Trim();

                                    fila1[0] = nombre_bt;
                                    fila1[1] = num_pan;
                                    fila1[2] = resultado_coordenadas;

                                    tabla_resultado_ok.Rows.Add(fila1);
                                    ASPxGridView5.DataSource = info_pan;
                                    ASPxGridView5.DataBind();
                                    ASPxGridView5.Visible = true;
                                    Label196.Text = resultado_coordenadas;
                                    Label196.Visible = true;
                                    //Button156.Enabled = true;
                                    Button158.Enabled = true;
                                    Label192.Visible = false;

                                    //this.Pan_Magnetica = num_pan;
                                    //this.Coord_Magnetica = resultado_coordenadas;
                                    //this.NumIdeper_Magnetica = numideper;
                                    //this.Tipid_Magnetica = codtipid;
                                    //this.CodPais_Magnetica = codpais;   


                                    Session["Pan_Magnetica"] = num_pan;
                                    Session["Coord_Magnetica"] = resultado_coordenadas;
                                    Session["NumIdeper_Magnetica"] = numideper;
                                    Session["Tipid_Magnetica"] = codtipid;
                                    Session["CodPais_Magnetica"] = codpais;

                                    //for (int i = 0; i < ASPxGridView6.VisibleRowCount; i++ )
                                    //{
                                    //    string tarjet = ASPxGridView6.GetRowValues(i, "TARJETA").ToString().Trim();
                                    //    if (ASPxGridView6.GetRowValues(ASPxGridView6.FocusedRowIndex, ASPxGridView6.KeyFieldName).ToString().Trim() == tarjet)
                                    //    {
                                    //        DataRowView CurrentDataRow = (DataRowView)ASPxGridView6.GetRow(i); 
                                    //        CurrentDataRow.Row.
                                    //        ASPxGridView6.Columns[0].CellStyle.BackColor = Color.Green;

                                    //    }
                                    //}

                                    //this.Button156_Click(sender, e); // este metodo era el que tenia en el Guardar viejor, lo que hace es insertar en la Bitacora

                                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El proximo paso para la activacion de su tarjeta: " + num_pan.Substring(0, 4) + "-" + num_pan.Substring(4, 4) + "-" + num_pan.Substring(8, 4) + "-" + num_pan.Substring(12, 4) + " es dirigirse a un cajero automatico y el mismo le pedirá introducir el valor de las coordenadas: " + resultado_coordenadas + " correspondientes a su tarjeta telebanca. Siga las instrucciones que le indique el cajero');", true);

                                }
                                else if (cant_caracteres_coord > 7)
                                {
                                    //ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Numero de cuenta incorrecto. Verifique que todos los campos esten correctamente');", true);

                                    mensaje = row.ItemArray[0].ToString().Trim();
                                    Label192.Text = "Lo sentimos. " + num_pan +" : "+ mensaje;
                                    Label192.Visible = true;
                                    Label196.Text = "";
                                    Label196.Visible = false;
                                    ASPxGridView5.DataSource = null;
                                    ASPxGridView5.DataBind();
                                    ASPxGridView5.Visible = false;
                                }
 
                        }
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Numero de cuenta incorrecto. Verifique que todos los campos esten correctamente');", true);
                Label192.Text = "No se encontraron tarjetas magneticas asociadas a este cliente. Verifique en el maestro de SABIC";
                Label192.Visible = true;
            }
        }
        catch (Exception ex)
        {           

            /*nuevo*/
            SqlConnection conx = new SqlConnection();

            try
            {
                string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
                conx.ConnectionString = cadena_conexion;
                conx.Open();

                string excepcion = ex.Message.Replace("'", "");
                excepcion = excepcion.Replace(":", "");

                SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES('" + num_pan + "','','" + numideper + "','" + codtipid + "','" + codpais + "','S','Solicitud_Pin',GETDATE(),'Solicitud del PIN digital de la tarjeta magnetica: " + num_pan + "','ERROR SOLICITUD PIN DIGITAL. " + excepcion.Trim() + "')", conx);
                int i = cm.ExecuteNonQuery();
                if (i != 1)
                {
                    Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
                }

            }
            catch (Exception ex1)
            {
                enviar_error = "Error al intentar insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
                Errores.Alert(this, enviar_error);

                //Session["Texto_Error"] = enviar_error;
                //Response.Redirect("~/Error500.aspx");
                //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
            }

            //conx.Close();
            //enviar_error = ex.Message.ToString().Trim();
            //Session["Texto_Error"] = enviar_error;
            //Response.Redirect("~/Error500.aspx");
            //Response.Redirect("Error500.aspx?Label1=" + enviar_error);

            /*/nuevo*/

            this.View67_Activate(sender, e);

            ASPxGridView5.DataSource = null;
            ASPxGridView5.DataBind();
            ASPxGridView5.Visible = false;

            Label192.Visible = true;
            Label192.Text = "Ha ocurrido un problema. Verifique problemas de conexion o de datos incorrectos";

            //Button156.Enabled = false;

            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    public bool Insertar_Bitacora(string tarj, string suc, string ideper, string tipid, string idpais, string estado, string funcionalidad, string fecha, string obs, string msg)
    {
        bool resultado = false;
        /*nuevo*/
        SqlConnection conx = new SqlConnection();

        try
        {
            string cadena_conexion = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
            conx.ConnectionString = cadena_conexion;
            conx.Open();

            SqlCommand cm = new SqlCommand("INSERT dbo.TLB_BITACORA VALUES('" + tarj + "','" + suc + "','" + ideper + "','" + tipid + "','" + idpais + "','" + estado + "','" + funcionalidad + "'," + fecha + ",'" + obs + "','" + msg + "')", conx);
            int i = cm.ExecuteNonQuery();
            if (i>0)
            {
                resultado = true;
            }

        }
        catch (Exception ex1)
        {
            enviar_error = "Intentando insertar el error dado en la BITACORA de Telebanca. " + ex1.Message.ToString().Trim();
            Session["Texto_Error"] = enviar_error;
            Response.Redirect("~/Error500.aspx");
            //Response.Redirect("Error500.aspx?Label1=" + enviar_error);
        }

        return resultado;
    }

    private string generarPINBlock(string pin, string cuenta)
    {
        string Xor = "";
        string[] hex = new string[16];

        //variante2
        int long_pin = pin.Length;
        string pin_block = "0" + long_pin.ToString() + pin;
        pin_block = pin_block.PadRight(16, 'F');
        string cuenta_block = "0000" + cuenta.Substring((cuenta.Length - 13), 12);

        Int64[] result = new Int64[16];

        if (pin_block.Length == cuenta_block.Length)
        {
            for (int i = 0; i < pin_block.Length; i++)
            {
                result[i] = Convert.ToInt64(pin_block.Substring(i, 1), 16) ^ Convert.ToInt64(cuenta_block.Substring(i, 1), 16); // ^ es el operador logico booleano XOR
                hex[i] = result[i].ToString("X");
            }

            //cojo el arreglo y adjunto  sus valores en un string, por cada valor del arreglo le aplico la conv a hexdecimal
            Xor = String.Join("", hex);

        }
        else
        {
            throw new Exception("La longitud del Pinblock y Cuentablock no coinciden");
        }




        //variante1
        //if (pin.Length == cuenta.Length)
        //{
        //    Int64 value1 = Convert.ToInt64(pin,16);
        //    Int64 value2 = Convert.ToInt64(cuenta,16);

        //    Int64 xor = value1 ^ value2; // operador de disyuncion(^): entero con entero: suma. Hex con entero: diferencia

        //    resultado = xor.ToString("X");
        //}

        return Xor;
    }

    // Activar tarjeta magnetica
    protected void View67_Activate(object sender, EventArgs e)
    {
        try
        {            

            ASPxGridView4.DataSource = null;
            ASPxGridView4.DataBind();

            Button158.Enabled = true;

            ASPxGridView5.DataSource = null;
            ASPxGridView5.DataBind();
            ASPxGridView5.Visible = false;

            ASPxGridView6.DataSource = null;
            ASPxGridView6.DataBind();

            Label192.Text = "";
            Label192.Visible = false;

            //Button156.Enabled = false;

            Label196.Text = "";
            Label196.Visible = false;

            string tarjeta_bt = NoTarjeta;
            Class1 MyClass = new Class1();
            MyDataSet DTS = MyClass.DatosTarjeta(tarjeta_bt);
            if (DTS != null)
            {
                string nombre = DTS.DatosTarjetas[0][2].ToString();
                string apellido1 = DTS.DatosTarjetas[0][3].ToString();
                string apellido2 = DTS.DatosTarjetas[0][4].ToString();

                string num_idepe = DTS.DatosTarjetas[0][11].ToString();
                string codtipid = DTS.DatosTarjetas[0][12].ToString().Trim().ToUpper();
                string codpais = DTS.DatosTarjetas[0][13].ToString();

                DataSet datos_mostrar = new DataSet();
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Tarjeta_Telebanca");
                tabla.Columns.Add("Cliente");
                tabla.Columns.Add("Identificacion");
                tabla.Columns.Add("Codigo_Identificacion");
                tabla.Columns.Add("Codigo_Pais");

                datos_mostrar.Tables.Add(tabla);
                DataRow fila = datos_mostrar.Tables[0].NewRow();

                fila[0] = tarjeta_bt;
                fila[1] = nombre.Trim().ToUpper() + " " + apellido1.Trim().ToUpper() + " " + apellido2.Trim().ToUpper();
                fila[2] = num_idepe;
                fila[3] = codtipid;
                fila[4] = codpais;

                tabla.Rows.Add(fila);

                ASPxGridView4.DataSource = datos_mostrar;
                ASPxGridView4.DataBind();
                ASPxGridView4.Visible = true;

                ASPxGridView4.Columns[0].CellStyle.Font.Bold = true;
                //ASPxGridView4.Columns[0].CellStyle.BackColor = Color.Aqua;
                ASPxGridView4.Columns[2].CellStyle.Font.Bold = true;
                //ASPxGridView4.Columns[2].CellStyle.BackColor = Color.Aqua;
                ASPxGridView4.Columns[3].CellStyle.Font.Bold = true;
                //ASPxGridView4.Columns[3].CellStyle.BackColor = Color.Aqua;
                ASPxGridView4.Columns[4].CellStyle.Font.Bold = true;
                //ASPxGridView4.Columns[4].CellStyle.BackColor = Color.Aqua;
            
                
                //traer las tarjetas magneticas que tiene el cliente
                DataSet tarjetas_magneticas = new DataSet();
                tarjetas_magneticas = Servicio.TarjetasMagneticas_Cliente(num_idepe, codtipid, codpais);

                if (tarjetas_magneticas.Tables.Count > 0)
                {
                    ASPxGridView6.DataSource = tarjetas_magneticas;
                    ASPxGridView6.DataBind();
                    ASPxGridView6.Visible = true;

                    ASPxGridView6.Columns[0].CellStyle.Font.Bold = true;
                    ASPxGridView6.Columns[0].CellStyle.BackColor = Color.GreenYellow;

                }

            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    

    // Boton Guardar Info Tarjeta Magnetica
    protected void Button156_Click(object sender, EventArgs e)
    {

        //guardar en el bitacora de telebanca                               
        string fecha_actual = "GETDATE()";

        string tarj_magnetica = Session["Pan_Magnetica"].ToString().Trim();
        string coord_generadas = Session["Coord_Magnetica"].ToString().Trim();
        string ideper_magnetica = Session["NumIdeper_Magnetica"].ToString().Trim();
        string tipid_magnetica = Session["Tipid_Magnetica"].ToString().Trim();
        string codpais_magnetica = Session["CodPais_Magnetica"].ToString().Trim();

        string observacion = "Solicita el PIN Digital de la tarjeta magnetica: " + tarj_magnetica + ". Se le genero la coordenada: " + coord_generadas + " correspondiente a la BT: " + NoTarjeta.Trim();
        if (this.Insertar_Bitacora(tarj_magnetica, "", ideper_magnetica, tipid_magnetica, codpais_magnetica, "O", "Solicitud_Pin", fecha_actual, observacion, "OK"))
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "confirm", "alert('La informacion de la activacion ha sido registrada satisfactoriamente en Telebanca');", true);
            //Label196.Text = "";
            //Label196.Visible = false;
            //ASPxGridView5.DataSource = null;
            //ASPxGridView5.DataBind();
            //ASPxGridView5.Visible = false;
            //Button156.Enabled = false;

            ASPxGridView6.FocusedRowIndex = -1;
            //Button158.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirm", "alert('No se pudo guardar la informacion de la activacion en Telebanca');", true);
        }

        //ASPxGridView5.DataSource = null;
        //ASPxGridView5.DataBind();
        //ASPxGridView5.Visible = false;
    }

    protected void ASPxGridView6_Load(object sender, EventArgs e)
    {
        if (IsPostBack) // entro si hubo algun click de un button en la pagina
        {
            if (NoTarjeta != null) // entro si NoTarjeta tiene ya valor, o sea, que se haya autenticado la tarjeta telebanca
            {                

                //traer las tarjetas magneticas que tiene el cliente
                DataSet tarjetas_magneticas = new DataSet();

                if (ASPxGridView4.VisibleRowCount > 0) // entro si muestra el GridView con los datos de la tarjeta telebanca autenticada (muestra tarjeta, nombre, numideper, codtipid, idpais)
                {
                    string num_idepe = ASPxGridView4.GetRowValues(ASPxGridView4.FocusedRowIndex, "Identificacion").ToString().Trim();
                    string codtipid = ASPxGridView4.GetRowValues(ASPxGridView4.FocusedRowIndex, "Codigo_Identificacion").ToString().Trim();
                    string codpais = ASPxGridView4.GetRowValues(ASPxGridView4.FocusedRowIndex, "Codigo_Pais").ToString().Trim();

                    tarjetas_magneticas = Servicio.TarjetasMagneticas_Cliente(num_idepe, codtipid, codpais);

                    if (tarjetas_magneticas.Tables.Count > 0)
                    {
                        ASPxGridView6.DataSource = tarjetas_magneticas;
                        ASPxGridView6.DataBind();
                        ASPxGridView6.Visible = true;

                        ASPxGridView6.Columns[0].CellStyle.Font.Bold = true;
                        ASPxGridView6.Columns[0].CellStyle.BackColor = Color.GreenYellow;

                        ASPxGridView6.Settings.ShowFilterRowMenu = true;
                        ASPxGridView6.SettingsBehavior.FilterRowMode = (GridViewFilterRowMode)Enum.Parse(typeof(GridViewFilterRowMode), "Auto", true);
                       
                    }
                }
            }
        }
    }
    protected void Button154_Click(object sender, EventArgs e)
    {
        ASPxGridView4.DataSource = null;
        ASPxGridView4.DataBind();

        ASPxGridView5.DataSource = null;
        ASPxGridView5.DataBind();

        ASPxGridView6.DataSource = null;
        ASPxGridView6.DataBind();

        Label196.Text = "";
        Label196.Visible = false;

        //Button156.Enabled = false;

        EstadoNavegPago.UltimaPagina = 3;
        MVWPago.ActiveViewIndex = 40;
    }


    protected void ASPxGridView6_SelectionChanged(object sender, EventArgs e)
    {
        if (ASPxGridView6.FocusedRowIndex != -1 && (ASPxGridView6.GetRowValues(ASPxGridView6.FocusedRowIndex, "TARJETA").ToString().Contains("92")))
        {
            Button158.Enabled = true;
        }
    }
    
    protected void ASPxGridView6_FocusedRowChanged(object sender, EventArgs e)
    {
        Button158.Enabled = true;
    }
    protected void Button153_Click1(object sender, EventArgs e)
    {
        DateTime fechaI = Calendar26.SelectedDate;
        DateTime fechaF = Calendar27.SelectedDate;

        if (fechaI.CompareTo(fechaF) <= 0)
        {
            string oper = TextBox84.Text;
            string TipoOper = "ReportePinDigital";
            Navegador.RedirectToPopUp(this, "MyNewPaginasReportes\\\\ReporteSolicitudPinDigitalTM.aspx?Desde=" + fechaI.Date + "&Hasta=" + fechaF.Date + "&operador=" + oper + "&tipooper=" + TipoOper);
        }
    }

    protected void View70_Activate(object sender, EventArgs e)
    {
        this.tabla_info_bancamovil.Visible = false;

        //ASPxRadioButtonList1.Items.Clear();
        //ASPxRadioButtonList1.SelectedIndex = -1;
        RadioButtonList20.Items.Clear();
        RadioButtonList20.SelectedIndex = -1;
        ASPxLabel4_desde.Visible = false;
        ASPxLabel5_hasta.Visible = false;
        ASPxLabel8.Text = "N/I";
        ASPxLabel10.Text = "N/I";
        ASPxLabel12.Text = "N/I";
        ASPxLabel14.Text = "N/I";
        ASPxLabel16.Text = "N/I";
        ASPxLabel18.Text = "N/I";
        TextBox85.Text = "";
        TextBox85.Enabled = false;
        CheckBox6.Checked = false;
        CheckBox6.Visible = false;
        Calendar28.Enabled = false;
        Calendar29.Enabled = false;

        ASPxGridView9.DataSourceID = null;
        ASPxGridView9.DataBind();
        ASPxGridView10.DataSourceID = null;
        ASPxGridView10.DataBind();
        ASPxGridView11.DataSourceID = null;
        ASPxGridView11.DataBind();

        ASPxGridView9.Visible = false;
        ASPxGridView10.Visible = false;
        ASPxGridView11.Visible = false;



        ASPxButton9.Enabled = false;

        RadioButtonList20.Items.Add("Telefono Movil");
        RadioButtonList20.Items.Add("Tarjeta Telebanca");
        RadioButtonList20.Items.Add("Carnet Identidad");
        RadioButtonList20.Visible = true;
    }
    protected void ASPxButton9_Click(object sender, EventArgs e)
    {
        DataSet bm = new DataSet();

        if (TextBox85.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Inserte el valor de busqueda');", true);
        }

        // limpiar los aspxgridview para que no de errores con las columnas que se quedan pegadas en los datasources
        if (ASPxGridView9.DataSourceID != null || ASPxGridView9.DataSourceID != "" || ASPxGridView9.DataColumns.Count != 0)
        {
            ASPxGridView9.Columns.Clear();
            ASPxGridView9.AutoGenerateColumns = true;
            ASPxGridView9.KeyFieldName = String.Empty;
            ASPxGridView9.DataBind();
        }
        if (ASPxGridView10.DataSourceID != null || ASPxGridView10.DataSourceID != "" || ASPxGridView10.DataColumns.Count != 0)
        {
            ASPxGridView10.Columns.Clear();
            ASPxGridView10.AutoGenerateColumns = true;
            ASPxGridView10.KeyFieldName = String.Empty;
            ASPxGridView10.DataBind();
        }
        if (ASPxGridView11.DataSourceID != null || ASPxGridView11.DataSourceID != "" || ASPxGridView11.DataColumns.Count != 0)
        {
            ASPxGridView11.Columns.Clear();
            ASPxGridView11.AutoGenerateColumns = true;
            ASPxGridView11.KeyFieldName = String.Empty;
            ASPxGridView11.DataBind();
        }
        

        //tabla con el registro del cliente que siempre se va a mostrar
        DataTable tabla_datos_registro = new DataTable();
        tabla_datos_registro.Columns.Add("Nombre");
        tabla_datos_registro.Columns.Add("Telebanca");
        tabla_datos_registro.Columns.Add("Movil");
        tabla_datos_registro.Columns.Add("Num Identidad");
        tabla_datos_registro.Columns.Add("Cod Pais");
        tabla_datos_registro.Columns.Add("Tipo Ident");
        tabla_datos_registro.Columns.Add("Estado");
        tabla_datos_registro.Columns.Add("Registrado");


        string num_cel = "";
        string tarj_teleb = "";
        string carne_ident = "";  
        DateTime inicio = new DateTime(1900, 01, 01);
        DateTime fin = new DateTime(1900, 01, 01);         

        if (TextBox85.Text != null)
        {
            for (int i = 0; i < RadioButtonList20.Items.Count; i++)
            {
                if (RadioButtonList20.Items[i].Selected && RadioButtonList20.Items[i].Text == "Telefono Movil")
	            {
		            num_cel = "53" + TextBox85.Text.Trim();

                    Regex rx = new Regex("^([535]{3})[0-9]{7}"); // expresion regular ^: inicia, ([535]): los tres primeros digitos obligados 535, [0-9]{7}: 7 digitos solo numeros

                    if (!rx.IsMatch(num_cel) || num_cel.Length != 10)
                    {
                        TextBox85.Text = "";
                        TextBox85.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Numero de movil incorrecto o formato incorrecto');", true);
                        return;
                    }

                    tarj_teleb = "0";
                    carne_ident = "0";
                    if (CheckBox6.Checked)
                    {
                        inicio = Calendar28.SelectedDate.Date;
                        fin = Calendar29.SelectedDate.Date;
                    }
                    else if (!CheckBox6.Checked)
                    {
                        inicio = new DateTime(1900, 01, 01);
                        fin = new DateTime(1900, 01, 01);
                    }
                    break;
	            }
                else if (RadioButtonList20.Items[i].Selected && RadioButtonList20.Items[i].Text == "Tarjeta Telebanca")
	            {
		            tarj_teleb = TextBox85.Text.Trim();
                    
                    Regex rx = new Regex("^([95]{2})[0-9]{8}"); // expresion regular ^: inicia, ([95]): los dos primeros digitos obligados 95, [0-9]{8}: 8 digitos solo numeros
                    if (!rx.IsMatch(tarj_teleb) || tarj_teleb.Length != 10)
                    {
                        TextBox85.Text = "";
                        TextBox85.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('Numero de tarjeta telebanca incorrecto');", true);
                        return;
                    }

                    num_cel = "0";
                    carne_ident = "0";
                    inicio = new DateTime(1900, 01, 01);
                    fin = new DateTime(1900, 01, 01);
                    break;
	            }
                else if (RadioButtonList20.Items[i].Selected && RadioButtonList20.Items[i].Text == "Carnet Identidad")
	            {
		            carne_ident = TextBox85.Text.Trim();
                    tarj_teleb = "0";
                    num_cel = "0";
                    inicio = new DateTime(1900, 01, 01);
                    fin = new DateTime(1900, 01, 01);
                    break;
	            }
            }

            try
            {
                string msg = "";
                int coderr = 0;

                bm = Servicio.Informacion_Telebanca_BancaMovil(tarj_teleb, num_cel, carne_ident, inicio, fin, out msg, out coderr);

                if (bm.Tables.Count > 0 && msg == "" && coderr == 0)
                {
                    if (bm != null && bm.Tables.Count > 0)
                    {
                        if (bm.Tables[bm.Tables.Count - 1] == null || bm.Tables[bm.Tables.Count - 1].Rows.Count == 0)
                        {
                            ASPxLabel8.Text = "N/I";
                            ASPxLabel10.Text = "N/I";
                            ASPxLabel12.Text = "N/I";
                            ASPxLabel14.Text = "N/I";
                            ASPxLabel16.Text = "N/I";
                            ASPxLabel18.Text = "N/I";
                        }

                        if (tarj_teleb != "0")
                        {
                            //tabla usada cuando se hace por #telebanca
                            DataTable tabla_cuentas_bancamovil = new DataTable();
                            tabla_cuentas_bancamovil.Columns.Add("NumIdeper");
                            tabla_cuentas_bancamovil.Columns.Add("CodTipid");
                            tabla_cuentas_bancamovil.Columns.Add("CodPais");
                            tabla_cuentas_bancamovil.Columns.Add("Cuenta");

                            DataTable tabla_cuentas_sabic = new DataTable();
                            tabla_cuentas_sabic.Columns.Add("NumIdeper");
                            tabla_cuentas_sabic.Columns.Add("CodTipid");
                            tabla_cuentas_sabic.Columns.Add("CodPais");
                            tabla_cuentas_sabic.Columns.Add("Cuenta");


                            tabla_cuentas_sabic = bm.Tables[0];
                            ASPxGridView9.DataSource = tabla_cuentas_sabic;
                            ASPxGridView9.DataBind();
                            ASPxGridView9.SettingsText.Title = "Cuentas en SABIC asociadas a la tarjeta telebanca";
                            ASPxGridView9.Visible = true;
                            ASPxGridView9.Enabled = true;

                            tabla_cuentas_bancamovil = bm.Tables[1];
                            ASPxGridView10.DataSource = tabla_cuentas_bancamovil;
                            if (tabla_cuentas_bancamovil.Rows.Count == 0)
                                ASPxGridView10.SettingsText.EmptyDataRow = "No tiene cuentas activas operando en Banca Movil";
                            ASPxGridView10.DataBind();
                            ASPxGridView10.SettingsText.Title = "Cuentas que operan con Banca Movil";
                            ASPxGridView10.Visible = true;
                            ASPxGridView10.Enabled = true;
                            
                            tabla_datos_registro = bm.Tables[2];
                            ASPxGridView11.DataSource = tabla_datos_registro;
                            if (tabla_datos_registro.Rows.Count == 0)
                            {
                                ASPxLabel8.Text = "Sin registro"; // telebanca
                                ASPxLabel10.Text = "Sin registro";// movil
                                ASPxLabel12.Text = "Sin registro";// numideper
                                ASPxLabel14.Text = "Sin registro";// codpais
                                ASPxLabel16.Text = "Sin registro";// tipid
                                ASPxLabel18.Text = "Sin registro";// estado
                            }
                            else
                            {
                                ASPxGridView11.DataBind();
                                ASPxGridView11.SettingsText.Title = "Informacion de Registro en Banca Movil";
                                ASPxGridView11.Visible = true;
                                ASPxGridView11.Enabled = true;

                                ASPxLabel8.Text = bm.Tables[2].Rows[0][0].ToString().Trim(); // telebanca
                                ASPxLabel10.Text = bm.Tables[2].Rows[0][1].ToString().Trim();// movil
                                ASPxLabel12.Text = bm.Tables[2].Rows[0][2].ToString().Trim();// numideper
                                ASPxLabel14.Text = bm.Tables[2].Rows[0][3].ToString().Trim();// codpais
                                ASPxLabel16.Text = bm.Tables[2].Rows[0][4].ToString().Trim();// tipid

                                if (bm.Tables[2].Rows[0][5].ToString().Trim() == "Cancelado")
                                {
                                    ASPxLabel18.Text = bm.Tables[2].Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Red;
                                    ASPxLabel18.Font.Bold = true;
                                }
                                else if (bm.Tables[2].Rows[0][5].ToString().Trim() == "Activo")
                                {
                                    ASPxLabel18.Text = bm.Tables[2].Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Green;
                                    ASPxLabel18.Font.Bold = true;
                                }
                            }

                        }
                        else if (num_cel != "0")
                        {
                            //tabla usada cuando se hace por #movil
                            DataTable tabla_operaciones_movil = new DataTable();
                            tabla_operaciones_movil.Columns.Add("Fecha");
                            tabla_operaciones_movil.Columns.Add("Funcionalidad");
                            tabla_operaciones_movil.Columns.Add("Accion");

                            tabla_operaciones_movil = bm.Tables[0];
                            ASPxGridView9.DataSource = tabla_operaciones_movil;
                            ASPxGridView9.DataBind();
                            ASPxGridView9.SettingsText.Title = "Ultimas operaciones con el movil";
                            ASPxGridView9.Visible = true;
                            ASPxGridView9.Enabled = true;

                            tabla_datos_registro = bm.Tables[1];
                            ASPxGridView11.DataSource = tabla_datos_registro;
                            if (tabla_datos_registro.Rows.Count == 0)
                            {
                                ASPxLabel8.Text = "Sin registro"; // telebanca
                                ASPxLabel10.Text = "Sin registro";// movil
                                ASPxLabel12.Text = "Sin registro";// numideper
                                ASPxLabel14.Text = "Sin registro";// codpais
                                ASPxLabel16.Text = "Sin registro";// tipid
                                ASPxLabel18.Text = "Sin registro";// estado
                            }
                            else
                            {
                                ASPxGridView11.DataBind();
                                ASPxGridView11.SettingsText.Title = "Informacion de Registro en Banca Movil";
                                ASPxGridView11.Visible = true;
                                ASPxGridView11.Enabled = true;

                                ASPxLabel8.Text = bm.Tables[1].Rows[0][0].ToString().Trim(); // telebanca
                                ASPxLabel10.Text = bm.Tables[1].Rows[0][1].ToString().Trim();// movil
                                ASPxLabel12.Text = bm.Tables[1].Rows[0][2].ToString().Trim();// numideper
                                ASPxLabel14.Text = bm.Tables[1].Rows[0][3].ToString().Trim();// codpais
                                ASPxLabel16.Text = bm.Tables[1].Rows[0][4].ToString().Trim();// tipid

                                if (bm.Tables[1].Rows[0][5].ToString().Trim() == "Cancelado")
                                {
                                    ASPxLabel18.Text = bm.Tables[1].Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Red;
                                    ASPxLabel18.Font.Bold = true;
                                }
                                else if (bm.Tables[1].Rows[0][5].ToString().Trim() == "Activo")
                                {
                                    ASPxLabel18.Text = bm.Tables[1].Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Green;
                                    ASPxLabel18.Font.Bold = true;
                                }
                            }

                            ASPxGridView10.Visible = false;

                        }
                        else if (carne_ident != "0")
                        {
                            //tabla usada cuando se hace por #ci
                            DataTable tabla_cuentas_bancamovil = new DataTable();
                            tabla_cuentas_bancamovil.Columns.Add("NumIdeper");
                            tabla_cuentas_bancamovil.Columns.Add("CodTipid");
                            tabla_cuentas_bancamovil.Columns.Add("CodPais");
                            tabla_cuentas_bancamovil.Columns.Add("Cuenta");

                            //tabla usada cuando se hace por #ci
                            DataTable tabla_cuentas_sabic = new DataTable();
                            tabla_cuentas_sabic.Columns.Add("NumIdeper");
                            tabla_cuentas_sabic.Columns.Add("CodTipid");
                            tabla_cuentas_sabic.Columns.Add("CodPais");
                            tabla_cuentas_sabic.Columns.Add("Cuenta");

                            tabla_cuentas_sabic = bm.Tables[0];
                            ASPxGridView9.DataSource = tabla_cuentas_sabic;
                            ASPxGridView9.DataBind();
                            ASPxGridView9.SettingsText.Title = "Cuentas en SABIC asociadas a la tarjeta telebanca";
                            ASPxGridView9.Visible = true;
                            ASPxGridView9.Enabled = true;

                            tabla_cuentas_bancamovil = bm.Tables[1];
                            ASPxGridView10.DataSource = tabla_cuentas_bancamovil;
                            if (tabla_cuentas_bancamovil.Rows.Count == 0)
                                ASPxGridView10.SettingsText.EmptyDataRow = "No tiene cuentas activas operando en Banca Movil";
                            ASPxGridView10.DataBind();
                            ASPxGridView10.SettingsText.Title = "Cuentas que operan con Banca Movil";
                            ASPxGridView10.Visible = true;
                            ASPxGridView10.Enabled = true;

                            tabla_datos_registro = bm.Tables[2];
                            ASPxGridView11.DataSource = tabla_datos_registro;
                            if (tabla_datos_registro.Rows.Count == 0)
                            {
                                ASPxLabel8.Text = "Sin registro"; // telebanca
                                ASPxLabel10.Text = "Sin registro";// movil
                                ASPxLabel12.Text = "Sin registro";// numideper
                                ASPxLabel14.Text = "Sin registro";// codpais
                                ASPxLabel16.Text = "Sin registro";// tipid
                                ASPxLabel18.Text = "Sin registro";// estado
                            }
                            else
                            {
                                ASPxGridView11.DataBind();
                                ASPxGridView11.SettingsText.Title = "Informacion de Registro en Banca Movil";
                                ASPxGridView11.Visible = true;
                                ASPxGridView11.Enabled = true;


                                ASPxLabel8.Text = tabla_datos_registro.Rows[0][0].ToString().Trim(); // telebanca
                                ASPxLabel10.Text = tabla_datos_registro.Rows[0][1].ToString().Trim();// movil
                                ASPxLabel12.Text = tabla_datos_registro.Rows[0][2].ToString().Trim();// numideper
                                ASPxLabel14.Text = tabla_datos_registro.Rows[0][3].ToString().Trim();// codpais
                                ASPxLabel16.Text = tabla_datos_registro.Rows[0][4].ToString().Trim();// tipid

                                if (tabla_datos_registro.Rows[0][5].ToString().Trim() == "Cancelado")
                                {
                                    ASPxLabel18.Text = tabla_datos_registro.Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Red;
                                    ASPxLabel18.Font.Bold = true;
                                }
                                else if (tabla_datos_registro.Rows[0][5].ToString().Trim() == "Activo")
                                {
                                    ASPxLabel18.Text = tabla_datos_registro.Rows[0][5].ToString().Trim();// estado registro
                                    ASPxLabel18.ForeColor = Color.Green;
                                    ASPxLabel18.Font.Bold = true;
                                }
                            }

                        }
                    }
                }
                else if(msg != "" && coderr != 0)
                {
                    ASPxLabel8.Text = "Sin registro"; // telebanca
                    ASPxLabel10.Text = "Sin registro";// movil
                    ASPxLabel12.Text = "Sin registro";// numideper
                    ASPxLabel14.Text = "Sin registro";// codpais
                    ASPxLabel16.Text = "Sin registro";// tipid
                    ASPxLabel18.Text = "Sin registro";// estado

                    ASPxGridView9.Visible = true;
                    ASPxGridView9.Enabled = false;

                    ASPxGridView10.Visible = true;
                    ASPxGridView10.Enabled = false;

                    ASPxGridView11.Visible = true;
                    ASPxGridView11.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "show_alert", "alert('No se encontro informacion, Verifique los datos');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                Errores.Alert(this, ex.Message);
            }
        }
    }
    //protected void ASPxRadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ASPxLabel4_desde.Visible = false;
    //    ASPxLabel5_hasta.Visible = false;
    //    ASPxLabel8.Text = "N/I";
    //    ASPxLabel10.Text = "N/I";
    //    ASPxLabel12.Text = "N/I";
    //    ASPxLabel14.Text = "N/I";
    //    ASPxLabel16.Text = "N/I";
    //    ASPxLabel18.Text = "N/I";
    //    ASPxLabel18.ForeColor = Color.Black;
    //    ASPxLabel18.Font.Bold = false;
    //    TextBox85.Text = "";
    //    TextBox85.Enabled = false;
    //    CheckBox6.Checked = false;
    //    CheckBox6.Visible = false;
    //    Calendar28.Enabled = false;
    //    Calendar29.Enabled = false;

    //    ASPxGridView9.Visible = false;
    //    ASPxGridView10.Visible = false;
    //    ASPxGridView11.Visible = false;

    //    ASPxGridView9.DataSourceID = null;
    //    ASPxGridView9.DataBind();
    //    ASPxGridView10.DataSourceID = null;
    //    ASPxGridView10.DataBind();
    //    ASPxGridView11.DataSourceID = null;
    //    ASPxGridView11.DataBind();


    //    for (int i = 0; i < ASPxRadioButtonList1.Items.Count; i++)
    //    {
    //        if (ASPxRadioButtonList1.Items[i].Selected)
    //        {
    //            if (ASPxRadioButtonList1.Items[i].Text == "Telefono Movil")
    //            {
    //                TextBox85.MaxLength = 8;
    //                TextBox85.Focus();
    //                TextBox85.Enabled = true;
    //                CheckBox6.Checked = true;
    //                CheckBox6.Visible = true;
    //                ASPxLabel4_desde.Visible = true;
    //                ASPxLabel5_hasta.Visible = true;
    //                Calendar28.Enabled = true;
    //                Calendar29.Enabled = true;
    //                Calendar28.Visible = true;
    //                Calendar29.Visible = true;
    //                ASPxButton9.Enabled = true;
    //            }
    //            else if (ASPxRadioButtonList1.Items[i].Text == "Tarjeta Telebanca")
    //            {
    //                TextBox85.MaxLength = 10;
    //                TextBox85.Enabled = true;
    //                TextBox85.Focus();
    //                CheckBox6.Checked = false;
    //                CheckBox6.Visible = false;
    //                ASPxLabel4_desde.Visible = false;
    //                ASPxLabel5_hasta.Visible = false;
    //                Calendar28.Visible = false;
    //                Calendar29.Visible = false;
    //                Calendar28.Enabled = false;
    //                Calendar29.Enabled = false;
    //                ASPxButton9.Enabled = true;
    //            }
    //            else if (ASPxRadioButtonList1.Items[i].Text == "Carnet Identidad")
    //            {
    //                TextBox85.MaxLength = 11;
    //                TextBox85.Enabled = true;
    //                TextBox85.Focus();
    //                CheckBox6.Checked = false;
    //                CheckBox6.Visible = false;
    //                ASPxLabel4_desde.Visible = false;
    //                ASPxLabel5_hasta.Visible = false;
    //                Calendar28.Visible = false;
    //                Calendar29.Visible = false;
    //                Calendar28.Enabled = false;
    //                Calendar29.Enabled = false;
    //                ASPxButton9.Enabled = true;
    //            }

    //        }
    //    }
    //}
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
        {
            ASPxLabel4_desde.Visible = true;
            ASPxLabel5_hasta.Visible = true;
            Calendar28.Visible = true;
            Calendar29.Visible = true;
        }
        else if (!CheckBox6.Checked)
        {
            ASPxLabel4_desde.Visible = false;
            ASPxLabel5_hasta.Visible = false;
            Calendar28.Visible = false;
            Calendar29.Visible = false;
        }

    }

    protected void ASPxButton10_Click(object sender, EventArgs e)
    {
        //ASPxTextBox1.Text = "";
        //ASPxRadioButtonList1.Items.Clear();
        //ASPxRadioButtonList1.SelectedIndex = -1;
        //ASPxLabel4_desde.Visible = false;
        //ASPxLabel5_hasta.Visible = false;
        //ASPxLabel8.Text = "N/I";
        //ASPxLabel10.Text = "N/I";
        //ASPxLabel12.Text = "N/I";
        //ASPxLabel14.Text = "N/I";
        //ASPxLabel16.Text = "N/I";
        //ASPxLabel18.Text = "N/I";
        //ASPxTextBox1.Text = "";
        //ASPxTextBox1.Enabled = false;
        //CheckBox6.Checked = false;
        //CheckBox6.Visible = false;
        //Calendar28.Enabled = false;
        //Calendar29.Enabled = false;

        //ASPxGridView9.DataSourceID = null;
        //ASPxGridView9.DataBind();
        //ASPxGridView10.DataSourceID = null;
        //ASPxGridView10.DataBind();
        //ASPxGridView11.DataSourceID = null;
        //ASPxGridView11.DataBind();

        //ASPxGridView9.Visible = false;
        //ASPxGridView10.Visible = false;
        //ASPxGridView11.Visible = false;

        //EstadoNavegPago.UltimaPagina = 3;
        //MVWPago.ActiveViewIndex = 40;

        this.View70_Activate(sender, e);
    }
    protected void RadioButtonList20_SelectedIndexChanged(object sender, EventArgs e)
    {
        ASPxLabel4_desde.Visible = false;
        ASPxLabel5_hasta.Visible = false;
        ASPxLabel8.Text = "N/I";
        ASPxLabel10.Text = "N/I";
        ASPxLabel12.Text = "N/I";
        ASPxLabel14.Text = "N/I";
        ASPxLabel16.Text = "N/I";
        ASPxLabel18.Text = "N/I";
        ASPxLabel18.ForeColor = Color.Black;
        ASPxLabel18.Font.Bold = false;
        TextBox85.Text = "";
        TextBox85.Enabled = false;
        CheckBox6.Checked = false;
        CheckBox6.Visible = false;
        Calendar28.Enabled = false;
        Calendar29.Enabled = false;

        ASPxGridView9.Visible = false;
        ASPxGridView10.Visible = false;
        ASPxGridView11.Visible = false;

        ASPxGridView9.DataSourceID = null;
        ASPxGridView9.DataBind();
        ASPxGridView10.DataSourceID = null;
        ASPxGridView10.DataBind();
        ASPxGridView11.DataSourceID = null;
        ASPxGridView11.DataBind();


        for (int i = 0; i < RadioButtonList20.Items.Count; i++)
        {
            if (RadioButtonList20.Items[i].Selected)
            {
                if (RadioButtonList20.Items[i].Text == "Telefono Movil")
                {
                    TextBox85.MaxLength = 8;
                    TextBox85.Focus();
                    TextBox85.Enabled = true;
                    CheckBox6.Checked = true;
                    CheckBox6.Visible = true;
                    ASPxLabel4_desde.Visible = true;
                    ASPxLabel5_hasta.Visible = true;
                    Calendar28.Enabled = true;
                    Calendar29.Enabled = true;
                    Calendar28.Visible = true;
                    Calendar29.Visible = true;
                    ASPxButton9.Enabled = true;
                }
                else if (RadioButtonList20.Items[i].Text == "Tarjeta Telebanca")
                {
                    TextBox85.MaxLength = 10;
                    TextBox85.Enabled = true;
                    TextBox85.Focus();
                    CheckBox6.Checked = false;
                    CheckBox6.Visible = false;
                    ASPxLabel4_desde.Visible = false;
                    ASPxLabel5_hasta.Visible = false;
                    Calendar28.Visible = false;
                    Calendar29.Visible = false;
                    Calendar28.Enabled = false;
                    Calendar29.Enabled = false;
                    ASPxButton9.Enabled = true;
                }
                else if (RadioButtonList20.Items[i].Text == "Carnet Identidad")
                {
                    TextBox85.MaxLength = 11;
                    TextBox85.Enabled = true;
                    TextBox85.Focus();
                    CheckBox6.Checked = false;
                    CheckBox6.Visible = false;
                    ASPxLabel4_desde.Visible = false;
                    ASPxLabel5_hasta.Visible = false;
                    Calendar28.Visible = false;
                    Calendar29.Visible = false;
                    Calendar28.Enabled = false;
                    Calendar29.Enabled = false;
                    ASPxButton9.Enabled = true;
                }

            }
        }
    }
};


   