using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using TeleBancaWS;
using System.IO;


public partial class WebUserControlb : System.Web.UI.UserControl
{
    TeleBancaWS.TeleBancaWS Servicio;

    //------------------------------------------------------------------------

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Servicio == null)
            if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];


        if (!this.IsPostBack)
        {
            try
            {
                string[][] datosMenu = Servicio.GetDataMenu(4);
                Menu1.Items.Clear();

                MenuItem subMenu1 = new MenuItem();
                subMenu1.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu1.Selected = false;
                Menu1.Items.Add(subMenu1);

                MenuItem subMenu2 = new MenuItem();
                subMenu2.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu2.Selected = true;
                subMenu2.Text = "Gestión de Autenticación";
                subMenu2.Value = "0";
                Menu1.Items.Add(subMenu2);


                for (int i = 0; i < datosMenu[0].Length; i++)
                {
                    MenuItem subMenu = new MenuItem();
                    subMenu.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";

                    subMenu.Text = datosMenu[0][i];
                    subMenu.Value = datosMenu[1][i];
                    Menu1.Items.Add(subMenu);
                    if (subMenu.Text == "Imprimir Pines")
                    {
                        subMenu = new MenuItem();
                        subMenu.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                        subMenu.Text = "Reimprimir Pines";
                        subMenu.Value = "6";
                        Menu1.Items.Add(subMenu);
                    }
                    if (subMenu.Text == "Imprimir Tarjetas")
                    {
                        subMenu = new MenuItem();
                        subMenu.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                        subMenu.Text = "Reimprimir Tarjetas";
                        subMenu.Value = "9";
                        Menu1.Items.Add(subMenu);
                    }
                }
            }
            catch
            {
                Errores.Alert(this, "Accion no Permitida"); return;
                //Response.Redirect("Default06.aspx");
                Response.Redirect("Default.aspx");
            }

           

        }
        

    }

    //------------------------------------------------------------------------

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MultiView1.ActiveViewIndex = Convert.ToInt32(e.Item.Value);

    }


    //------------------------------------------------------------------------
    // CU CAPTAR MATRICES
    //------------------------------------------------------------------------

    protected void Matriz_Activate(object sender, EventArgs e)
    {
        try
        {
            TreeView1.Nodes.Clear();
           string [][] torres = Servicio.GetTorresA();

            TreeView1.Nodes.Add(new TreeNode("PC (" + Server.MachineName + ")", "PC", "~/Images/iconstreeview/xpMyComp.gif"));
            for (int i = 0; i < torres.Length; i++)
            {
                if (torres[i][1] == "Removable" )
                {
                    TreeView1.Nodes[0].ChildNodes.Add(new TreeNode(torres[i][0], torres[i][0], "~/Images/iconstreeview/xpDriveA.gif"));
                }
                else
                    if (torres[i][1] == "CDRom")
                {
                    TreeView1.Nodes[0].ChildNodes.Add(new TreeNode(torres[i][0], torres[i][0], "~/Images/iconstreeview/xpCdRom.gif"));
                }
                else
                {
                    TreeView1.Nodes[0].ChildNodes.Add(new TreeNode(torres[i][0], torres[i][0], "~/Images/iconstreeview/xpDrive.gif"));
                }                
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
 
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex != -1)
        {
            Button1.Enabled = true;
        }
    }
    

    //------------------------------------------------------------------------

    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox1.SelectedIndex != -1)
            {
                int va = Servicio.CargarEncriptarGuardarMatrices(TreeView1.SelectedNode.ValuePath.Substring(TreeView1.SelectedNode.ValuePath.IndexOf("/")+1) +"/"+ ListBox1.SelectedValue);
                if (va != -1)
                {
                    Errores.Alert(this, "Se captaron: " + va.ToString() + " nuevas matrices");
                }
                else
                    Errores.Alert(this, "No hay matrices a encriptar"); 
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------
    // CU CONCILIACIONES AUTOMATICAS
    //------------------------------------------------------------------------

    protected void View_Concilaciones_Activate(object sender, EventArgs e)
    {
        try
        {
            DropDownList_C_Bancos.Items.Clear();
            string[] ListaNombresBancos = Servicio.GetListaBancos();
            string[] IdBancos = Servicio.GetIDBancos();
            if (ListaNombresBancos.Length == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                Errores.Alert(this, "No hay Bancos Asociados ");
                Menu1.SelectedItem.Selected = false;
                Menu1.Items[1].Selected = true;
            }
            else
            {
                Calendar_C.SelectedDate = DateTime.Now.Date;
                DropDownList_C_Bancos.Items.Add("[Seleccione el Banco   ]");
                for (int i = 0; i < ListaNombresBancos.Length; i++)
                {
                    DropDownList_C_Bancos.Items.Add(new ListItem(ListaNombresBancos[i].ToString(), IdBancos[i].ToString()));
                }
                RadioButtonList_C.SelectedIndex = -1;
                DropDownList_C_Bancos.Enabled = false;
                Calendar_C.Visible = false;
                Button_C_Aceptar.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void RadioButtonList_C_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList_C.SelectedIndex != -1)
        {
            DropDownList_C_Bancos.Enabled = true;
        }
    }

    //------------------------------------------------------------------------

    protected void DropDownList_C_Bancos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList_C_Bancos.Items[0].Text == "[Seleccione el Banco   ]")
        {
            DropDownList_C_Bancos.Items.RemoveAt(0); 
        }
        Calendar_C.Visible = true;
        Button_C_Aceptar.Enabled = true;
    }

    //------------------------------------------------------------------------

    protected void Button_C_Aceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (int.Parse(RadioButtonList_C.SelectedItem.Value) == 0)
            {

                if (!Servicio.ExistenTarjetasActivasDeBancoEnDia(Calendar_C.SelectedDate.Date, DropDownList_C_Bancos.SelectedItem.Value))
                {
                    Errores.Alert(this, "No existen tarjetas activas en el día: " + Calendar_C.SelectedDate.ToShortDateString().ToString() + " para el banco: " + DropDownList_C_Bancos.SelectedItem.Value);
                }
                else
                {
                    new Errores(this).Confirmar("Está seguro que quiere enviar la Conciliación al Banco " + DropDownList_C_Bancos.SelectedItem.Text, "EnviarConciliaciones");
                }
            }
            if (int.Parse(RadioButtonList_C.SelectedItem.Value) == 1)
            {
                if (!Servicio.ExistenTarjetasCanceladasDeBancoEnDia(Calendar_C.SelectedDate.Date, DropDownList_C_Bancos.SelectedItem.Value))
                {
                    Errores.Alert(this, "No existen solicitudes de baja en el día: " + Calendar_C.SelectedDate.ToShortDateString().ToString() + " para el banco: " + DropDownList_C_Bancos.SelectedItem.Value);
                }
                else
                {
                    new Errores(this).Confirmar("Está seguro que quiere enviar la Conciliación al Banco " + DropDownList_C_Bancos.SelectedItem.Text, "EnviarConciliaciones");
                }
            }
            if (int.Parse(RadioButtonList_C.SelectedItem.Value) == 2)
            {
                if (!Servicio.ExistenTarjetasImpresasDeBancoEnDia(Calendar_C.SelectedDate.Date, DropDownList_C_Bancos.SelectedItem.Value))
                {
                    Errores.Alert(this, "No existen tarjetas creadas en el día: " + Calendar_C.SelectedDate.ToShortDateString().ToString() + " para el banco: " + DropDownList_C_Bancos.SelectedItem.Value);
                }
                else
                {
                    new Errores(this).Confirmar("Está seguro que quiere enviar la Conciliación al Banco " + DropDownList_C_Bancos.SelectedItem.Text, "EnviarConciliaciones");
                }
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }

    }

    //------------------------------------------------------------------------

    public void EnviarConciliaciones()
    {
        try
        {
            if (Convert.ToInt32(RadioButtonList_C.SelectedItem.Value) == 0)
            {
                string Impresas = Servicio.EnviarConciliacionImpresas(Convert.ToDateTime(Calendar_C.SelectedDate.ToShortDateString()), DropDownList_C_Bancos.SelectedItem.Value);
            }
            else
                if (Convert.ToInt32(RadioButtonList_C.SelectedItem.Value) == 1)
                {
                    string Canceladas = Servicio.EnviarConciliacionTarjetasCanceladas(Convert.ToDateTime(Calendar_C.SelectedDate.ToShortDateString()), DropDownList_C_Bancos.SelectedItem.Value);
                    Errores.Alert(this, Canceladas);
                }
                else
                    if (Convert.ToInt32(RadioButtonList_C.SelectedItem.Value) == 2)
                    {
                        string Creadas = Servicio.EnviarConciliacionTarjetasCreadas(Convert.ToDateTime(Calendar_C.SelectedDate.ToShortDateString()), DropDownList_C_Bancos.SelectedItem.Value);
                        Errores.Alert(this, Creadas);
                    }
            DropDownList_C_Bancos.Items.Clear();
            string[] ListaNombresBancos = Servicio.GetListaBancos();
            string[] IdBancos = Servicio.GetIDBancos();

            DropDownList_C_Bancos.Items.Add("[Seleccione el Banco   ]");
            for (int i = 0; i < ListaNombresBancos.Length; i++)
            {
                DropDownList_C_Bancos.Items.Add(new ListItem(ListaNombresBancos[i].ToString(), IdBancos[i].ToString()));
            }
            RadioButtonList_C.SelectedIndex = -1;
            Calendar_C.Visible = false;
            DropDownList_C_Bancos.Enabled = false;
            Button_C_Aceptar.Enabled = false;
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_C_Cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        //Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------
    // CU CREAR LOTES
    //------------------------------------------------------------------------

    protected void View_CrearLotes_Activate(object sender, EventArgs e)
    {   
        try
        {
            Object[] array = Servicio.ListarNoSucursalTarjetasNoIdLote();
            if (array.Length != 0)
            {
                //Panel3.Visible = false;
                Button_CL_Aceptar.Enabled = false;
                DropDownList_CL_Sucursales.Items.Clear();
                DropDownList_CL_Sucursales.Items.Add("Seleccione la Sucursal");
                for (int i = 0; i < array.Length; i++)
                {
                    DropDownList_CL_Sucursales.Items.Add(array[i].ToString());
                }
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
                Errores.Alert(this, "No hay tarjetas para crear lotes");
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void DropDownList_CL_Sucursales_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Object[] array = Servicio.DatosTarjetasPorSucursal(DropDownList_CL_Sucursales.SelectedValue);
            Label_CL_Nombre.Text = array[0].ToString();
            Label_CLCantidad.Text = array[1].ToString();
            //Panel3.Visible = true;
            Button_CL_Aceptar.Enabled = true;
            DropDownList_CL_Sucursales.Items.Remove("Seleccione la Sucursal");
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void Button_CL_Aceptar_Click(object sender, EventArgs e)
    {
        Label_CL_FechasNombre.Text = Label_CL_Nombre.Text;
        Label_CL_FechasNumero.Text = DropDownList_CL_Sucursales.SelectedValue;
        MultiView1.ActiveViewIndex = 4;
    }

    //------------------------------------------------------------------------

    protected void Button_CL_Cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------

    protected void View_CrearLotes_Fechas_Activate(object sender, EventArgs e)
    {   
        try
        {
            object[] aux = Servicio.MostrarFechaPorSucursalYCantidad(DropDownList_CL_Sucursales.SelectedValue);
            object[] fechas = (object[])aux[0];
            object[] can = (object[])aux[1];
            Button_CL_FechasCrear.Enabled = false;
            CheckBoxList_CL_Fechas.Items.Clear();
            Label_CL_FechasTotal.Text = "0";
            for (int i = 0; i < fechas.Length; i++)
            {
                CheckBoxList_CL_Fechas.Items.Add(new ListItem(fechas[i] + " ________________ " + can[i], can[i].ToString()));
            }

        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void CheckBoxList_CL_Fechas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int Contador = 0;
            for (int i = 0; i < CheckBoxList_CL_Fechas.Items.Count; i++)
            {
                if (CheckBoxList_CL_Fechas.Items[i].Selected)
                {
                    Contador += int.Parse(CheckBoxList_CL_Fechas.SelectedValue);
                }
            }
            if (Contador == 0)
            {
                Button_CL_FechasCrear.Enabled = false;
            }
            else
                Button_CL_FechasCrear.Enabled = true;

            Label_CL_FechasTotal.Text = Contador.ToString();
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_CL_FechasCrear_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿Está segura que desea crear el lote?", "CrearLote");

    }
    public void CrearLote()
    {
        try
        {
            ArrayList a = new ArrayList();
            for (int i = 0; i < CheckBoxList_CL_Fechas.Items.Count; i++)
            {
                if (CheckBoxList_CL_Fechas.Items[i].Selected)
                {
                    a.Add(CheckBoxList_CL_Fechas.Items[i].Text.Substring(0, CheckBoxList_CL_Fechas.Items[i].Text.IndexOf(" ")));
                }
            }
            if (Servicio.CrearLote(Label_CL_FechasNumero.Text, a.ToArray()))
            {
                Errores.Alert(this, "El lote ha sido creado satisfactoriamente");
                MultiView1.ActiveViewIndex = 3;
            }
            else
            {
                Errores.Alert(this, "El lote no ha sido creado");
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_CL_FechasCancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }
    //------------------------------------------------------------------------
    // CU IMPRIMIR PINES
    //------------------------------------------------------------------------

    protected void Imprimir_Pines_Activate(object sender, EventArgs e)
    {
        if (Servicio.ObtenerConfiguracion()[9] == "")
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, "No existe una impresora definida para los Pines...");
            return;

        }

        try
        {
            CheckBoxList_IP_Lotes.Items.Clear();
            string[][] Arreglo = Servicio.CantidadPinesPorLotes();
            if (Arreglo[0] != null)
            {
                Button_IP_Aceptar.Enabled = false;
                for (int j = 0; j < Arreglo[0].Length; j++)
                {
                    CheckBoxList_IP_Lotes.Items.Add(new ListItem(Arreglo[0][j] + " ___________________________ " + Arreglo[1][j], Arreglo[1][j]));
                }
            }
            else
            {
                Errores.Alert(this, "No se han encontrado Lotes pendientes de impresión de PIN");
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void CheckBoxList_IP_Lotes_SelectedIndexChanged(object sender, EventArgs e)
    {
            int Contador = 0;
            for (int i = 0; i < CheckBoxList_IP_Lotes.Items.Count; i++)
            {
                if (CheckBoxList_IP_Lotes.Items[i].Selected)
                {
                    Contador += int.Parse(CheckBoxList_IP_Lotes.Items[i].Value);
                }
            }
            if (Contador != 0)
            {
                Button_IP_Aceptar.Enabled = true;
            }
            else
            {
                Button_IP_Aceptar.Enabled = false;
            }
            Label_IP_Cantidad.Text = "";
            Label_IP_Cantidad.Text = Contador.ToString();
    }

    //------------------------------------------------------------------------

    protected void Button_IP_Aceptar_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿Esta seguro que desea imprimir? ", "ImprimirLotes");
    }


    //protected void Button_IP_Aceptar_Click(object sender, EventArgs e)
    public void ImprimirLotes()
    {
        try
        {
            ArrayList PinesSeleccionados = new ArrayList();
            for (int i = 0; i < CheckBoxList_IP_Lotes.Items.Count; i++)
            {
                if (CheckBoxList_IP_Lotes.Items[i].Selected)
                {
                    PinesSeleccionados.Add(CheckBoxList_IP_Lotes.Items[i].Text.Substring(0, CheckBoxList_IP_Lotes.Items[i].Text.IndexOf(" ")));

                }
            }
            string[][] datos = Servicio.DatosDeLotes(PinesSeleccionados.ToArray());
            TarjetaPersistenteReport[] datosList = new TarjetaPersistenteReport[datos[0].Length];
            for (int i = 0; i < datos[0].Length; i++)
            {
                TarjetaPersistenteReport tarjeta = new TarjetaPersistenteReport(datos[3][i], datos[4][i], datos[0][i], datos[1][i], datos[7][i], datos[2][i], datos[5][i], datos[6][i]);
                datosList[i] = tarjeta;
            }
            string ReportPath = Server.MapPath("Reports/Ping.rpt");

            CrystalDecisions.Web.CrystalReportSource TempSource = new CrystalDecisions.Web.CrystalReportSource();
            TempSource.ReportDocument.Load(ReportPath);
            TempSource.ReportDocument.SetDataSource(datosList);
            TempSource.ReportDocument.PrintOptions.PrinterName = Servicio.ObtenerConfiguracion()[9];
            TempSource.ReportDocument.PrintToPrinter(1, false, 1, TempSource.ReportDocument.Rows.Count / 3 + Convert.ToInt32(TempSource.ReportDocument.Rows.Count % 3 > 0));
            Servicio.ActualizarDatosLoteP(PinesSeleccionados.ToArray());

            MultiView1.ActiveViewIndex = 6;

        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_IP_Cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------

    protected void Button_IP_Reimprimir_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            object[] lista = Servicio.ListarDatosPinesAReimprimir(Convert.ToInt32(CheckBoxList1.SelectedItem.Text));
            if (lista.Length == 1)
            {
                Errores.Alert(this, lista[0].ToString());
            }
            else
            {
                DatosLote[] datos = new DatosLote[((string[])lista[0]).Length];
                int cantTarjetas = 1;
                for (int i = 0; i < ((string[])lista[0]).Length; i++)
                {
                    DropDownList1.Items.Add(cantTarjetas.ToString());
                    DropDownList2.Items.Add(cantTarjetas.ToString());
                    datos[i] = new DatosLote();
                    cantTarjetas++;
                }
                int pos = 0;
                foreach (string[] aux in lista)
                {
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (pos == 0)
                            datos[i].Indice = int.Parse(aux[i]);
                        if (pos == 1)
                            datos[i].NumeroTarjeta = aux[i];
                        if (pos == 2)
                            datos[i].Nombre = aux[i];
                        if (pos == 3)
                            datos[i].Apellido = aux[i];
                        if (pos == 4)
                            datos[i].IdCliente = aux[i];
                    }

                    pos++;
                }
                Session["TarjToRePrint"] = datos;
                GridView_IT_Reimp.PageIndex = 0;
                GridView_IP_Reimprimir.DataSource = datos;
                GridView_IP_Reimprimir.DataBind();
                MultiView1.ActiveViewIndex = 7;
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void Button_IP_ReimpFinalizar_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("Si finaliza no podrá volver a imprimir ninguno de los pines que forman el lote o los lotes escogidos por usted. ¿Esta seguro que desea finalizar? ", "FinalizarImpP");
    }
    public void FinalizarImpP()
    {
        try
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    Servicio.FinalizarImpresionDePines(Convert.ToInt32(CheckBoxList1.Items[i].Text));  
                }
            }
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, "El proceso de impresión ha concluido satisfactoriamente");


        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void View_Reimprimir_Pines3_Activate(object sender, EventArgs e)
    {   
        
    }

    
    //------------------------------------------------------------------------

    protected void GridView_IP_Reimprimir_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_IP_Reimprimir.PageIndex = e.NewPageIndex;
        GridView_IP_Reimprimir.DataSource = (DatosLote[])Session["TarjToRePrint"];
        GridView_IP_Reimprimir.DataBind();
    }

    
    //------------------------------------------------------------------------

    // 
    protected void Button_IP_ReimpAceptar_Click(object sender, EventArgs e)
    {  
            new Errores(this).Confirmar("¿Está seguro que desea reimprimir?", "ReimprimirPines");
               
    }

    //protected void Button_IP_ReimpAceptar_Click(object sender, EventArgs e)
    public void ReimprimirPines()
    {
        try
        {
            GridView_IP_Reimprimir.DataSource = (DatosLote[])Session["TarjToRePrint"];
            GridView_IP_Reimprimir.DataBind();
            string[][] temp = Servicio.PinesAReimprimir(Convert.ToInt32(DropDownList1.SelectedItem.Text), Convert.ToInt32(DropDownList2.SelectedItem.Text), Convert.ToInt32(CheckBoxList1.SelectedItem.Text));
            TarjetaPersistenteReport[] TempList = new TarjetaPersistenteReport[temp[0].Length];
            for (int i = 0; i < temp[0].Length; i++)
            {
                TarjetaPersistenteReport tempTrajeta = new TarjetaPersistenteReport(temp[1][i], temp[6][i], temp[2][i], temp[3][i], temp[8][i], temp[4][i], temp[5][i], temp[7][i]);
                TempList[i] = tempTrajeta;
            }

            string ReportPath = Server.MapPath("Reports/Ping.rpt");

            CrystalDecisions.Web.CrystalReportSource TempSource = new CrystalDecisions.Web.CrystalReportSource();
            TempSource.ReportDocument.Load(ReportPath);
            TempSource.ReportDocument.SetDataSource(TempList);
            TempSource.ReportDocument.PrintOptions.PrinterName = Servicio.ObtenerConfiguracion()[9];
            TempSource.ReportDocument.PrintToPrinter(1, false, 1, TempSource.ReportDocument.Rows.Count / 3 + Convert.ToInt32(TempSource.ReportDocument.Rows.Count % 3 > 0));

            Servicio.SalvarOperacionReimpresionP(Convert.ToInt32(DropDownList1.SelectedItem.Selected), Convert.ToInt32(DropDownList2.SelectedItem.Selected), Convert.ToInt32(CheckBoxList1.SelectedItem.Text));

            MultiView1.ActiveViewIndex = 6;
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }    

    //------------------------------------------------------------------------

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        int final = Convert.ToInt16(DropDownList1.Items[(DropDownList1.Items.Count) - 1].ToString());
        for (int i = Convert.ToInt16(DropDownList1.SelectedItem.Text); i <= final; i++)
        {
            DropDownList2.Items.Add(i.ToString());
        }
    }

    //------------------------------------------------------------------------

    protected void Button_IP_ReimpCancelar_Click(object sender, EventArgs e)
    {
        GridView_IP_Reimprimir.DataBind();
        MultiView1.ActiveViewIndex = 6;
    }

    //------------------------------------------------------------------------

    protected void View2_Activate(object sender, EventArgs e)
    {
        Button_IP_Reimprimir.Enabled = false;
        Button_IP_ReimpFinalizar.Enabled = false;
        try
        {
            CheckBoxList1.Items.Clear();
            string[][] arreglo = Servicio.ListarLotesDePinesImpresos();
            if (arreglo[0].Length == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                Errores.Alert(this, "No quedan lotes de pines por finalizar...");
                Menu1.Items[1].Selected = true;
            }
            else 
            {
                for (int i = 0; i < arreglo[0].Length; i++)
                {
                    CheckBoxList1.Items.Add(arreglo[0][i]);
                } 
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cantidad = 0;
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                cantidad++;
            }
        }
        if (cantidad == 1)
        {
            Button_IP_Reimprimir.Enabled = true;
            Button_IP_ReimpFinalizar.Enabled = true;
        }
        else 
        {
            if (cantidad > 1)
            {
                Button_IP_Reimprimir.Enabled = false;
                Button_IP_ReimpFinalizar.Enabled = true;
            }
            else 
            {
                Button_IP_Reimprimir.Enabled = false;
                Button_IP_ReimpFinalizar.Enabled = false;
            }
        }
    }

    //------------------------------------------------------------------------

    protected void Button6_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            CheckBoxList1.Items[i].Selected = true;
        }
        if (CheckBoxList2.Items.Count == 1)
        {
            Button_IP_Reimprimir.Enabled = true;
            Button_IP_ReimpFinalizar.Enabled = true;
        }
        else
        {
            Button_IP_Reimprimir.Enabled = false;
            Button_IP_ReimpFinalizar.Enabled = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button5_Click(object sender, EventArgs e)
    {
        Button_IP_Reimprimir.Enabled = false;
        Button_IP_ReimpFinalizar.Enabled = false;
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            CheckBoxList1.Items[i].Selected = false;
        }
    }


    //------------------------------------------------------------------------
    // CU IMPRIMIR TARJETAS
    //------------------------------------------------------------------------

    protected void View_Imprimir_Tarjetas4_Activate(object sender, EventArgs e)
    {
        if (Servicio.ObtenerConfiguracion()[10] == "")
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, "No existe una impresora definida para las Tarjetas...");
            return;
        }
        try
        {
            Button_IT_Aceptar.Enabled = false;
            CheckBoxList_IT_Lotes.Items.Clear();
            Label_IT_Cantidad.Text = "0";
            string[][] aux = Servicio.DatosLotesEstadoTCreado();
            if (aux[0] != null)
            {
                for (int i = 0; i < aux[0].Length; i++)
                {
                    CheckBoxList_IT_Lotes.Items.Add(new ListItem(aux[0][i] + " ___________________________ " + aux[1][i], aux[1][i]));
                }
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
                Menu1.SelectedItem.Selected = false;
                Errores.Alert(this, "No se han encontrado Lotes pendientes de impresión de Tarjetas.");
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------    

    protected void CheckBoxList_IT_Lotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = 0;
        for (int i = 0; i < CheckBoxList_IT_Lotes.Items.Count; i++)
        {
            if (CheckBoxList_IT_Lotes.Items[i].Selected)
            {
                count += int.Parse(CheckBoxList_IT_Lotes.Items[i].Value);
            }
        }
        if (count != 0)
        {
            Button_IT_Aceptar.Enabled = true;
        }
        else
        {
            Button_IT_Aceptar.Enabled = false;
        }
        Label_IT_Cantidad.Text = count.ToString();

    }

    //------------------------------------------------------------------------

    protected void Button_IT_Aceptar_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿Está seguro que desea imprimir? ", "ImprimirLotesT");

    }

    //------------------------------------------------------------------------

    public void ImprimirLotesT()
    {
        try
        {
            ArrayList lotesSeleccionados = new ArrayList();
            for (int i = 0; i < CheckBoxList_IT_Lotes.Items.Count; i++)
            {
                if (CheckBoxList_IT_Lotes.Items[i].Selected)
                {
                    lotesSeleccionados.Add(CheckBoxList_IT_Lotes.Items[i].Text.Substring(0, CheckBoxList_IT_Lotes.Items[i].Text.IndexOf(" ")));
                }
            }

            string[][] temp = Servicio.TarjetasAImprimir(lotesSeleccionados.ToArray());
            TarjetasAImprimir[] List = new TarjetasAImprimir[temp[0].Length];
            for (int i = 0; i < temp[0].Length; i++)
            {
                TarjetasAImprimir tempTarjeta = new TarjetasAImprimir(temp[0][i], temp[1][i], temp[2][i], temp[3][i], temp[4][i], temp[5][i], temp[6][i], temp[7][i], temp[8][i], temp[9][i], temp[10][i]);
                List[i] = tempTarjeta;
            }
            string ReportPath = Server.MapPath("Reports/Tarjeta.rpt");


            CrystalDecisions.Web.CrystalReportSource TempSource = new CrystalDecisions.Web.CrystalReportSource();
            TempSource.ReportDocument.Load(ReportPath);
            TempSource.ReportDocument.SetDataSource(List);
            TempSource.ReportDocument.PrintOptions.PrinterName = Servicio.ObtenerConfiguracion()[10];
            TempSource.ReportDocument.PrintToPrinter(1, false, 1, TempSource.ReportDocument.Rows.Count / 4 + Convert.ToInt32(TempSource.ReportDocument.Rows.Count % 4 > 0));

            Servicio.ActualizarDatosLoteT(lotesSeleccionados.ToArray());

            MultiView1.ActiveViewIndex = 9;
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_IT_Cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------

    protected void Button_IT_Reimprimir_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();
            object[] ListaTarjeta = Servicio.ListarDatosTarjetasAReimprimir(Convert.ToInt32(CheckBoxList2.SelectedItem.Text));
            if (ListaTarjeta.Length == 1)
            {
                Errores.Alert(this, ListaTarjeta[0].ToString());
            }
            else
            {
                int lista = ((string[])ListaTarjeta[0]).Length;
                DatosLote[] datoT = new DatosLote[lista];
                int nroTarjeta = 0;
                for (int i = 0; i < lista; i++)
                {
                    nroTarjeta++;
                    DropDownList3.Items.Add(nroTarjeta.ToString());
                    DropDownList4.Items.Add(nroTarjeta.ToString());
                    datoT[i] = new DatosLote();
                }
                Session["CantTarj"] = nroTarjeta;
                int pos = 0;

                foreach (string[] aux in ListaTarjeta)
                {
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (pos == 0)
                            datoT[i].Indice = int.Parse(aux[i]);
                        if (pos == 1)
                            datoT[i].NumeroTarjeta = aux[i];
                        if (pos == 2)
                            datoT[i].Nombre = aux[i];
                        if (pos == 3)
                            datoT[i].Apellido = aux[i];
                        if (pos == 4)
                            datoT[i].IdCliente = aux[i];
                    }
                    pos++;
                }
                Session["TarjToRePrint"] = datoT;
                GridView_IT_Reimp.PageIndex = 0;
                GridView_IT_Reimp.DataSource = datoT;
                GridView_IT_Reimp.DataBind();
            }
            MultiView1.ActiveViewIndex = 10; 
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }

    //------------------------------------------------------------------------    

    protected void Button_IT_Finalizar_Click(object sender, EventArgs e)
    {

        new Errores(this).Confirmar("Si finaliza no podrá volver a imprimir ninguna de las tarjetas que forman el lote o los lotes escogidos por usted. ¿Esta seguro que desea finalizar? ", "FinalizarImpT");

    }

    //------------------------------------------------------------------------    

    public void FinalizarImpT()
    {
        try
        {
            for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                if (CheckBoxList2.Items[i].Selected == true)
                {
                    Servicio.FinalizarImpresionDeTarjetas(Convert.ToInt32(CheckBoxList2.Items[i].Text));
                }
            }
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, "El proceso de impresión ha concluido satisfactoriamente");
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }

    //------------------------------------------------------------------------

    protected void View_Reimprimir_Tarjetas_Activate(object sender, EventArgs e)
    {
        //Panel2.Visible = false;
        //Button4.Visible = true;
    }
    

    //------------------------------------------------------------------------

    protected void GridView_IT_Reimp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView_IT_Reimp.PageIndex = e.NewPageIndex;
        GridView_IT_Reimp.DataSource = (DatosLote[])Session["TarjToRePrint"];
        GridView_IT_Reimp.DataBind();
    }

   

    //------------------------------------------------------------------------

    protected void Button_IT_ReimpAceptar_Click(object sender, EventArgs e)
    {   
       new Errores(this).Confirmar("¿Está seguro que desea reimprimir? ", "ReimprimirTarjetas");
    }

    //------------------------------------------------------------------------

    public void ReimprimirTarjetas()
    {
        try
        {
            string[][] temp = Servicio.TarjetasAReimprimir(Convert.ToInt32(DropDownList3.SelectedItem.Value), Convert.ToInt32(DropDownList4.SelectedItem.Value), Convert.ToInt32(CheckBoxList2.SelectedItem.Text));
            TarjetasAImprimir[] list = new TarjetasAImprimir[temp[0].Length];
            for (int i = 0; i < temp[0].Length; i++)
            {
                TarjetasAImprimir tarj = new TarjetasAImprimir(temp[0][i], temp[1][i], temp[2][i], temp[3][i], temp[4][i], temp[5][i], temp[6][i], temp[7][i], temp[8][i], temp[9][i], temp[10][i]);
                list[i] = tarj;
            }

            string ReportPath = Server.MapPath("Reports/Tarjeta.rpt");

            CrystalDecisions.Web.CrystalReportSource TempSource = new CrystalDecisions.Web.CrystalReportSource();
            TempSource.ReportDocument.Load(ReportPath);
            TempSource.ReportDocument.SetDataSource(list);
            TempSource.ReportDocument.PrintOptions.PrinterName = Servicio.ObtenerConfiguracion()[10];
            TempSource.ReportDocument.PrintToPrinter(1, false, 1, TempSource.ReportDocument.Rows.Count / 4 + Convert.ToInt32(TempSource.ReportDocument.Rows.Count % 4 > 0));

            Servicio.SalvarOperacionReimpresionT(Convert.ToInt32(DropDownList3.SelectedItem.Text), Convert.ToInt32(DropDownList4.SelectedItem.Text), Convert.ToInt32(CheckBoxList2.SelectedItem.Text));
            MultiView1.ActiveViewIndex = 9;
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }


    }

    //------------------------------------------------------------------------

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Temp = Convert.ToInt32(Session["CantTarj"]);
        DropDownList4.Items.Clear();
        for (int i = Convert.ToInt16(DropDownList3.SelectedItem.Text); i <= Temp; i++)
        {
            DropDownList4.Items.Add(i.ToString());
        }
    }
    

    //------------------------------------------------------------------------

    protected void Button_IT_ReimpCancelar_Click(object sender, EventArgs e)
    {
        GridView_IT_Reimp.DataBind();
        MultiView1.ActiveViewIndex = 9;
    }

    //------------------------------------------------------------------------

    protected void View3_Activate(object sender, EventArgs e)
    {
        Button_IT_Reimprimir.Enabled = false;
        Button_IT_Finalizar.Enabled = false;
        try
        {
            CheckBoxList2.Items.Clear();
            string[][] arreglo = Servicio.ListarLotesDeTarjetasImpresas();
            if (arreglo[0].Length == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                Errores.Alert(this, "No quedan lotes de tarjetas por finalizar...");
                Menu1.Items[1].Selected = true;
            }
            else 
            {
                for (int i = 0; i < arreglo[0].Length; i++)
                {
                    CheckBoxList2.Items.Add(arreglo[0][i]);   
                }
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------ 

    protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cantidad = 0;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
               cantidad++;   
            }
        }

        if (cantidad == 1)
        {
            Button_IT_Reimprimir.Enabled = true;
            Button_IT_Finalizar.Enabled = true;
        }
        else
            if (cantidad > 1)
            {
                Button_IT_Reimprimir.Enabled = false;
                Button_IT_Finalizar.Enabled = true;
            }
            else
            {
                Button_IT_Reimprimir.Enabled = false;
                Button_IT_Finalizar.Enabled = false;
            }
    }

    //------------------------------------------------------------------------ 

    protected void Button3_Click(object sender, EventArgs e)
    {   
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            CheckBoxList2.Items[i].Selected = true;
        }
        if (CheckBoxList2.Items.Count == 1)
        {
            Button_IT_Reimprimir.Enabled = true;
            Button_IT_Finalizar.Enabled = true;
        }
        else 
        {
            Button_IT_Reimprimir.Enabled = false;
            Button_IT_Finalizar.Enabled = true;
        }
    }

    //------------------------------------------------------------------------ 

    protected void Button4_Click(object sender, EventArgs e)
    {
        Button_IT_Reimprimir.Enabled = false;
        Button_IT_Finalizar.Enabled = false;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            CheckBoxList2.Items[i].Selected = false;
        }
    }

   
    //------------------------------------------------------------------------
    // CU REALIZAR REPORTES
    //------------------------------------------------------------------------

    protected void View_RealizarReporte_Activate(object sender, EventArgs e)
    {
        Button_RR_Aceptar.Enabled = false;
        RadioButtonList_RR.SelectedIndex = -1;
    }

    //------------------------------------------------------------------------

    protected void RadioButtonList_RR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList_RR.SelectedIndex != -1)
        {
            Button_RR_Aceptar.Enabled = true;
        }
    }


    //------------------------------------------------------------------------

    protected void Button_RR_Aceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(RadioButtonList_RR.SelectedItem.Value) == 0)
            {
                MultiView1.ActiveViewIndex = 12;
            }
            else
                
                if (Convert.ToInt32(RadioButtonList_RR.SelectedItem.Value) == 1)
                {

                    object[] TempData = new object[3];
                    TempData[0] = "ReportePorImprimir";
                    TempData[1] = Servicio.ObtenerLotesPorImprimir();
                    Application["Datos"] = TempData;
                    Navegador.RedirectToPopUp(this, "Reportes.aspx");                    
                }
        }
        catch (Exception ex)
        {
            if (Errores.FiltrarMensaje(ex.Message) == "1")
                Errores.Alert(this, "No existen lotes creados");
            else if (Errores.FiltrarMensaje(ex.Message) == "2")
                Errores.Alert(this, "Hay lotes creados sin tarjetas");
            else
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
        }
    }
    //------------------------------------------------------------------------------              
    protected void View_ReporteCreados_Activate(object sender, EventArgs e)
    {
        try
        {
            Button_RR_CreadosAceptar.Enabled = false;
            CheckBoxList3.SelectedIndex = -1;
            CheckBoxList3.Items.Clear();
            object[] lotes = Servicio.ObtenerLotesFinalizados();
            if (lotes.Length != 0)
            {
                foreach (object i in lotes)
                {
                    CheckBoxList3.Items.Add(i.ToString());
                }
            }
            else
            {
                Errores.Alert(this, "No se han impreso lotes en el día de hoy");
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
            }
        }
        catch (Exception ex)
        {   
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
        }
    }

    //------------------------------------------------------------------------

    protected void Button_RR_Camcelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.SelectedItem.Selected = false;
        Menu1.Items[1].Selected = true;
    }

    //------------------------------------------------------------------------

   



    //------------------------------------------------------------------------

    protected void Button_RR_CreadosCancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 11;
    }

    //------------------------------------------------------------------------  

    protected void Button_RR_CreadosAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> idlotes = new List<string>();
            for (int i = 0; i < CheckBoxList3.Items.Count; i++)
            {
                if (CheckBoxList3.Items[i].Selected)
                {
                    idlotes.Add(CheckBoxList3.Items[i].Text);
                }
            }
            object[] TempData = new object[3];
            TempData[0] = "ReporteTImpresas";
            TempData[1] = Servicio.ReporteTarjetasPorLote(idlotes.ToArray());

            Application["Datos"] = TempData;
            Navegador.RedirectToPopUp(this, "Reportes.aspx");
            
        }

        catch (Exception ex)
        {
            if (Errores.FiltrarMensaje(ex.Message) == "1")
                Errores.Alert(this, "El lote no tiene tarjetas");
            else
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            MultiView1.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
        }
    }

    
    protected void RellenarHijos(String dir)
    {
        TreeNode actual = TreeView1.FindNode(dir);
        for (int j = 0; j < actual.ChildNodes.Count; j++)
        {
            string[] arr = Servicio.GetSubCarpetas(actual.ChildNodes[j].ValuePath.Substring(actual.ChildNodes[j].ValuePath.IndexOf("/") + 1));

            for (int i = 0; i < arr.Length; i++)
            {
                actual.ChildNodes[j].ChildNodes.Add(new TreeNode(arr[i], arr[i], "~/Images/iconstreeview/xpFolder.gif"));
            }
        }
    }

  
    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)  
    {
        try
        {
            RellenarHijos(e.Node.ValuePath);
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            Button1.Enabled = false;
            ListBox1.Items.Clear();
  // Label2.Text = "Archivos disponibles: (" + TreeView1.SelectedNode.ValuePath.Substring(TreeView1.SelectedNode.ValuePath.IndexOf("/") + 1) + ")";

            string[] txt = Servicio.BuscarTxt(TreeView1.SelectedNode.ValuePath.Substring(TreeView1.SelectedNode.ValuePath.IndexOf("/") + 1));
            for (int i = 0; i < txt.Length; i++)
            {
                ListBox1.Items.Add(txt[i]);
            }
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 0;
            Menu1.SelectedItem.Selected = false;
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            Menu1.Items[1].Selected = true;
        }

    }

    protected void CheckBoxList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cant = 0;
        for (int i = 0; i < CheckBoxList3.Items.Count; i++)
        {
            if (CheckBoxList3.Items[i].Selected)
            {
                cant++; 
            }
        }
        if (cant == 0)
        {
            Button_RR_CreadosAceptar.Enabled = false;
        }
        else 
        {
            Button_RR_CreadosAceptar.Enabled = true;
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar_C_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date > DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "...No puede seleccionar una fecha del Futuro...";
        }

        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
    }
}
