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
using System.Drawing;
using System.Text.RegularExpressions;


public partial class WebUserControla : System.Web.UI.UserControl
{
    
    int sabados = -1;
    TeleBancaWS.TeleBancaWS Servicio;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox17.Attributes.Add("onkeypress", "javascript:return Money(event);");

        if (Servicio == null)
            if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];


        if (!this.IsPostBack)
        {
            try
            {
                string[][] datosMenu = Servicio.GetDataMenu(3);
                Menu1.Items.Clear();

                MenuItem subMenu1 = new MenuItem();
                subMenu1.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu1.Selected = false;
                Menu1.Items.Add(subMenu1);

                MenuItem subMenu2 = new MenuItem();
                subMenu2.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu2.Selected = false;
                subMenu2.Text = "Servicio de información";
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
            }
            catch
            {
                Errores.Alert(this, "Accion no Permitida"); return;
                Response.Redirect("Default.aspx");
                //Response.Redirect("Default06.aspx");
            }


           

        }

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MVwInformacion.ActiveViewIndex = Convert.ToInt32(e.Item.Value);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 4;
    }

    //Insertat Entidad
    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || DropDownList9.Text == "" || TextBox7.Text == "")
            {

                RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator4.Visible = true;
                RequiredFieldValidator1.Validate(); RequiredFieldValidator2.Validate(); RequiredFieldValidator3.Validate(); RequiredFieldValidator4.Validate();
                bool valid = RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && RequiredFieldValidator3.IsValid && RequiredFieldValidator4.IsValid;  
                if (!valid)
                {
                    RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator4.Visible = true;
                    Errores.Alert(this, "Entrada de datos no valida");
                    return;
                }

            }
            else
            {
                RegularExpressionValidator1.Visible = RegularExpressionValidator2.Visible = RegularExpressionValidator6.Visible = RegularExpressionValidator13.Visible = true;
                RegularExpressionValidator1.Validate(); RegularExpressionValidator2.Validate(); RegularExpressionValidator6.Validate(); RegularExpressionValidator13.Validate();
                if (!RegularExpressionValidator1.IsValid || !RegularExpressionValidator2.IsValid || !RegularExpressionValidator6.IsValid || !RegularExpressionValidator13.IsValid)
                {
                    RegularExpressionValidator1.Visible = RegularExpressionValidator2.Visible = RegularExpressionValidator6.Visible = RegularExpressionValidator13.Visible = true;
                    Errores.Alert(this, "Entrada de datos no válida");
                    return;
                }
                if (Servicio.ExisteEntidad(TextBox1.Text))
                {
                    Errores.Alert(this, "La entidad que se intenta insertar ya existe");
                }
                else
                    new Errores(this).Confirmar("¿ Está seguro que desea insertar esta Entidad ?", "InsertarEntidad");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
        
    }
    public void InsertarEntidad()
    {
        try
        {
            string telefonos = "";
            for (int i = 0; i < DropDownList9.Items.Count; i++) 
            {
                telefonos = DropDownList9.Items[i] + ";" + telefonos;
            }
            string correos = "";
            for (int i = 0; i < DropDownList10.Items.Count; i++) 
            {
                correos = DropDownList10.Items[i] + ";" + correos;
            }
            string sitios = "";
            for (int i = 0; i < DropDownList11.Items.Count; i++)
            {
                sitios = DropDownList11.Items[i] + ";" + sitios;
            }
                Servicio.InsertarEntidad(TextBox1.Text, TextBox2.Text, telefonos, TextBox4.Text, TextBox7.Text,
                                      TextBox6.Text, correos, sitios);
            MVwInformacion.ActiveViewIndex = 3;
            Errores.Alert(this, "Se ha insertado satisfactoriamente la Entidad");
            DropDownList9.Items.Clear();
            DropDownList10.Items.Clear();
            DropDownList11.Items.Clear();
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    

    //Gestion de Agenda Electronica
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ListBox1.Items.Clear();
        MVwInformacion.ActiveViewIndex = 3;

        /*try
        {
            object[] aux = Servicio.Lista_Entidades();

            for (int i = 0; i < aux.Length; i++)
            {
                ListBox1.Items.Add(new ListItem(((object[])aux.GetValue(i)).GetValue(0).ToString(),
                                                  ((object[])aux.GetValue(i)).GetValue(1).ToString()));
            }
            //ListBox1.DataSource = aux;
            //ListBox1.DataBind();
        }
        catch (Exception ex)
        {
            ListBox1.Items.Add("No existen entidades en la Agenda Electrónica.");
        }*/
    }

    //Insertar Entidad en la Agenda Electronica(inicio)
    protected void Button5_Click1(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 4;
        TextBox1.Text = null;
        TextBox2.Text = null;
        TextBox3.Text = null;
        TextBox4.Text = null;
        TextBox5.Text = null;
        TextBox6.Text = null;
        TextBox7.Text = null;
        TextBox18.Text = null;
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        Button1_Click(sender, e);
    }

    //Cancelar insertar Entidad
    protected void Button9_Click1(object sender, EventArgs e)
    {
        DropDownList9.Items.Clear();
        DropDownList10.Items.Clear();
        DropDownList11.Items.Clear();
        Button1_Click(sender, e);
    }

    //Modificiar Entidad (inicio)
    protected void Button6_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 5;
        Button6.Enabled = Button7.Enabled = false;

    }

    //Cancelar Modificar Entidad
    protected void Button13_Click(object sender, EventArgs e)
    {
        DropDownList12.Items.Clear();
        DropDownList13.Items.Clear();
        DropDownList14.Items.Clear();
        TextBox9.Text = "";
        TextBox11.Text = "";
        TextBox21.Text = "";
        MVwInformacion.ActiveViewIndex = 3;
        Button1_Click(sender, e);
    }

    //Gestion de Informacin de Procesos
    protected void Button2_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 6;
    }

    //Insertar Informacion de Proceso
    protected void Button18_Click(object sender, EventArgs e)
    {
        TextBox14.Text = TextBox15.Text = TextBox16.Text = "";
        MVwInformacion.ActiveViewIndex = 7;
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add(new ListItem("Seleccione un Tema Padre", "0"));
        try
        {
            object[] aux = Servicio.Lista_Temas();
            for (int i = 0; i < aux.Length; i++)
            {
                DropDownList1.Items.Add(new ListItem(((object[])aux.GetValue(i)).GetValue(0).ToString(),
                                         ((object[])aux.GetValue(i)).GetValue(1).ToString()));
            }
        }
        catch
        {
            ListBox1.Items.Add("No existe Información de Proceso.");
        }
    }

    //Modificar Informacion de Proceso
    protected void Button19_Click(object sender, EventArgs e)
    {
        if (ListBox2.SelectedIndex != -1)
        {
            MVwInformacion.ActiveViewIndex = 8;
            Button19.Enabled = Button20.Enabled = false;
            Label5.Text = "";
            TextBox19.Text = "";
            TextBox20.Text = "";
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("Seleccione un Tema Padre", "0"));
            try
            {
                object[] datosTema = Servicio.DatosTema(Convert.ToInt16(ListBox2.Items[ListBox2.SelectedIndex].Value));
                
                HiddenField1.Value = datosTema[0].ToString();
                Label5.Text = datosTema[1].ToString();
                TextBox19.Text = datosTema[2].ToString();
                foreach (object var in (object[])datosTema[4])
                {
                    TextBox20.Text += var.ToString() + "; ";
                }
                object[] aux = Servicio.Lista_Temas();
                int index = 0;
                for (int i = 0; i < aux.Length; i++)
                {
                    if (datosTema[0].ToString() != ((object[])aux.GetValue(i)).GetValue(1).ToString())
                    {
                        DropDownList2.Items.Add(new ListItem(((object[])aux.GetValue(i)).GetValue(0).ToString(),
                        ((object[])aux.GetValue(i)).GetValue(1).ToString()));
                        if (datosTema[3].ToString() == ((object[])aux.GetValue(i)).GetValue(1).ToString())
                            index = DropDownList2.Items.Count - 1;
                    }
                }
                DropDownList2.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
            Errores.Alert(this, "Debe seleccionar el tema a modificar.");
    }

    //Cancelar Insertar Tema
    protected void Button22_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 7;
        Button2_Click(sender, e);
    }

    protected void Button26_Click(object sender, EventArgs e)
    {
        Button2_Click(sender, e);
    }

    //buscar por tema de Informacion de Procesos
    protected void Button34_Click(object sender, EventArgs e)
    {
        Label6.Text = "Buscar Información de Procesos por Tema";
        try
        {
            Button36.Enabled = false;
            ListBox4.Items.Clear();
            foreach (string Nombre in Servicio.ListaTemas())
            {
                ListBox4.Items.Add(Nombre);
            }
            if (ListBox4.Items.Count == 0)
            {
                MVwInformacion.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
                Errores.Alert(this, "No existen Temas en la Información de Procesos");
            }
        }
        catch (Exception error)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
        }
        MVwInformacion.ActiveViewIndex = 13;
    }

    //buscar por palabra clave de Informacion de Procesos
    protected void Button35_Click(object sender, EventArgs e)
    {
        Label6.Text = "Buscar Información de Procesos por Palabra(s) Clave(s)";
        MVwInformacion.ActiveViewIndex = 15;
    }

    
    //mostrar datos de tema seleccionado de la busqueda
    protected void Button36_Click(object sender, EventArgs e)
    {
        //if (Lis)
        //{
            
        //}
        try 
	    {
            string[] DatosTema = Servicio.ObtenerDatosTema(ListBox4.SelectedValue);
            Label31.Text = DatosTema[0];
            TextBox30.Text = DatosTema[1];
            Label32.Text = DatosTema[4];
            Label2.Text = DatosTema[2];

            string[] SubT = DatosTema[3].Split(';');
            foreach (string E in SubT)
            {
                ListBox5.Items.Clear();
                ListBox5.Items.Add(E);
            }

            MVwInformacion.ActiveViewIndex = 14;
    	
	    }
	    catch (Exception error)
	    {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
		}
    }

    //Buscar en la Agenda Electronica
    protected void Button3_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 9;
    }

    //Buscar en Informacin de Procesos
    protected void Button4_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 12;

    }

    //Cancelar modificar Tema
    protected void Button26_Click1(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 7;
        Button2_Click(sender, e);
    }

    //Buscar en la Agenda Electronica por...
    protected void Button31_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator14.Validate();
            RegularExpressionValidator15.Validate();
            RegularExpressionValidator16.Validate();
            if (!RegularExpressionValidator14.IsValid || !RegularExpressionValidator15.IsValid || !RegularExpressionValidator16.IsValid || !RegularExpressionValidator17.IsValid || !RegularExpressionValidator18.IsValid)
            {
                Errores.Alert(this, "Datos Icorrectos");
                return;
            }
            ListBox3.Items.Clear();
            string[] Filas = Servicio.ConsultaAgendaElectronica(TextBox22.Text, TextBox23.Text, TextBox25.Text, TextBox24.Text, TextBox33.Text, TextBox26.Text, TextBox27.Text, TextBox28.Text);
            if (Filas.Length > 1)
            {
                foreach (string Elemento in Filas)
                {
                    ListBox3.Items.Add(Elemento);
                }
                MVwInformacion.ActiveViewIndex = 10;
            }
            else
            {
                if (Filas.Length == 1)
                {
                    ListBox3.Items.Add(Filas[0]);
                    ListBox3.SelectedIndex = 0;
                    Button32_Click(null, null);
                }
                else
                {
	                Errores.Alert(this, "No se ha encontrado ninguna información asociada a los criterios seleccionados.");
                }

            }
            TextBox22.Text = TextBox23.Text = TextBox24.Text = TextBox25.Text = TextBox26.Text = TextBox27.Text = TextBox28.Text = TextBox29.Text = TextBox33.Text = "";
        }
        catch(Exception error)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
        }
    }

    //Mostrar datos Entidad seleccionada del Buscar
    protected void Button32_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox3.SelectedIndex >= 0)
            {
                string[] Fila = Servicio.BusquedaPorNombre(ListBox3.SelectedValue.Trim());
                Label24.Text = Fila[0];//Fila.Nombre
                Label25.Text = Fila[1];//Fila.Direccion
                Label27.Text = Fila[2];//Fila.Fax
                Label26.Text = Fila[3];//Fila.Telefono
                Label1.Text = Fila[4];//Fila.F_CorreosElectronicos
                Label28.Text = Fila[5];//Fila.F_SitiosWeb
                Label29.Text = Fila[6];//Fila.CodigoAnterior
                Label30.Text = Fila[7];//Fila.Codigo
                              
                MVwInformacion.ActiveViewIndex = 11;
            }
        }
        catch (Exception error)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
        }
    }

    //Mostrar datos Entidad seleccionada del Buscar
    protected void Button15_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 9;
    }

    //Guardar en historico informacion solicitada 
    protected void Button33_Click(object sender, EventArgs e)
    {
        try
        {
            //{Filas[0].Cod_Entidad,Filas[0].CodAntSucursal,Filas[0].Direccion,Filas[0].Fax,Filas[0].Telefono,Filas[0].CorreoElectronico,Filas[0].SitioWeb,Filas[0].NombreC};
            Servicio.ActualizarFilaAgendaElectronica(CheckBox5.Checked?1:0, CheckBox4.Checked ? 1:0, CheckBox2.Checked?1:0, CheckBox3.Checked ? 1:0, CheckBox6.Checked ? 1:0, CheckBox8.Checked ? 1:0, CheckBox7.Checked ?1:0 ,CheckBox1.Checked ? 1:0,DateTime.Today.Date , Label24.Text.Trim(), Servicio.getUsuariActivo()[0]);
            MVwInformacion.ActiveViewIndex = 0;
            Menu1.Items[1].Selected = true;
            CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = CheckBox4.Checked = CheckBox5.Checked = CheckBox6.Checked = CheckBox7.Checked = CheckBox8.Checked = false;
            
        }
        catch(Exception error)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
        }
    }

    //cancelar la busqueda de informacion de proceso
    protected void Button14_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 12;
    }

    //buscar datos de temas seleccionado
    protected void Button37_Click(object sender, EventArgs e)
    {
        try
        {
            Servicio.ActualizarBusquedaProcesos(DateTime.Today.Date, Servicio.getUsuariActivo()[0],Label31.Text.Trim());
            Label31.Text = TextBox30.Text = Label32.Text = Label2.Text ="";
            ListBox5.Items.Clear();
            MVwInformacion.ActiveViewIndex = 13;
        }
        catch (Exception error)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(error.Message));
        }
    }

    //guardar tema consultado
    protected void Button38_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }

    //buscar por palabra clave 
    protected void Button39_Click(object sender, EventArgs e)
    {
        try
        {
            string[] Palabras = Servicio.BuscarPorPalabraClave(TextBox29.Text.Trim());
            TextBox29.Text = "";
            if (Palabras.Length > 1)
            {
                ListBox4.Items.Clear();
                Button36.Enabled = false;
                foreach (string E in Palabras)
                {
                    ListBox4.Items.Add(E);
                }
                MVwInformacion.ActiveViewIndex = 13;
            }
            else 
            {
                if (Palabras.Length == 1)
                {
                    ListBox4.Items.Clear();
                    Button36.Enabled = false;
                    ListBox4.Items.Add(Palabras[0].Trim());
                    ListBox4.SelectedIndex = 0;
                    Button36_Click(null, null);
                }
                else
                {
                    Errores.Alert(this, "No hay Datos que cumplan con los criterios de búsqueda");
                }
            }
        }
        catch (Exception errores)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(errores.Message));
        }
    }

    //mostrar datos de tema seleccionado de la busqueda por palabra clave
    protected void Button40_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 17;
        try
        {
            ListBox7.Items.Clear();
            object[] datosTema = Servicio.DatosTema(Convert.ToInt16(ListBox6.Items[ListBox6.SelectedIndex].Value));
            Label33.Text = datosTema[0].ToString();
            TextBox31.Text = datosTema[1].ToString();
            Label34.Text = datosTema[2].ToString();

            //palabras  clave
            //Label3.Text = datosTema[1].ToString(); //tema padre

            //cargar subtemas
            /*object[] subTemas = Servicio.SubTemas("idTema");
            for (int i = 0; i < subTemas.Length; i++)
            {
                ListBox6.Items.Add(new ListItem(((object[])subTemas.GetValue(i)).GetValue(0).ToString(),
                                         ((object[])subTemas.GetValue(i)).GetValue(1).ToString()));
            }*/
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //cancelar mostrar datos de tema seleccionado de la busqueda por palabra clave
    protected void Button41_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 12;
    }

    //mostrar datos de tema seleccionado de la busqueda por palabra clave
    protected void Button42_Click(object sender, EventArgs e)
    {
        /*
         Buscar
         */
    }
    protected void Button43_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }

    //Insertar Tema
    protected void Button21_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox14.Text == "" || TextBox15.Text == "" || TextBox16.Text == "")
            {
                RequiredFieldValidator5.Visible = RequiredFieldValidator6.Visible = RequiredFieldValidator7.Visible = true;
                RequiredFieldValidator5.Validate(); RequiredFieldValidator6.Validate(); RequiredFieldValidator7.Validate();
                bool valid = RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid && RequiredFieldValidator7.IsValid;
                if (!valid)
                {
                    RequiredFieldValidator5.Visible = RequiredFieldValidator6.Visible = RequiredFieldValidator7.Visible = true;
                    Errores.Alert(this, "Entrada de datos no valida.");
                    return;
                }
            }
            else
            {
                if (Servicio.ExisteInformacion(TextBox14.Text))
                {
                    Errores.Alert(this, "La Informacion de Proceso que se intenta insertar ya existe.");
                }
                else
                    new Errores(this).Confirmar("¿ Estás seguro que desea insertar esta Informacion de Proceso ?", "Insertar");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    public string[] QuitarEspacios( string cadena)
    {
            if (cadena.Length>0)
	        {
	    	    if (cadena[0] == ' ')
	            {
                    cadena = cadena.Remove(0);
	            }
                if (cadena.Length > 0)
                {
                    if (cadena[cadena.Length - 1] == ' ')
                    {
                        cadena = cadena.Remove(TextBox16.Text.Length-1);
                    }
                }
	        }
            System.Collections.Generic.List<string> Palabras = new System.Collections.Generic.List<string>();
            string [] Arreglo = cadena.Split(';');
            for (int i = 0; i < Arreglo.Length; i++)
			{
                Arreglo[i] = Arreglo[i].Trim();
                if (Arreglo[i].Length > 0)
                    Palabras.Add(Arreglo[i]);
			}
            if (Palabras.Count == 0)
            {
                Errores.Alert(this,"Cadena Vacía");
                return null;
           }
            return Palabras.ToArray();
    } 
    public void Insertar()
    {
        try
        {
            string[] Arreglo = QuitarEspacios(TextBox16.Text.Trim());
            if (Arreglo.Length > 0)
            {
                Servicio.InsertarInformacion(TextBox14.Text, Arreglo, int.Parse(DropDownList1.SelectedItem.Value.Trim()), TextBox15.Text);
                Errores.Alert(this, " Se ha insertado satisfactoriamente la Información de Proceso.");
                MVwInformacion.ActiveViewIndex = 6;
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        try
        {
            if (Servicio.InsertarEntidad(TextBox1.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text,
                                     TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox21.Text))
                Button1_Click(sender, e);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    //Eliminar en Entidad
    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox1.SelectedIndex != -1)
            {
                new Errores(this).Confirmar("¿Esta seguro que desea eliminar la entidad selecionada?", "EliminarDefinitivo");
                MVwInformacion.ActiveViewIndex = 3;
                Button6.Enabled = Button7.Enabled = false;
            }
            
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    public void EliminarDefinitivo() 
    {
        object[] entidad = Servicio.BuscarDatosEntidad(ListBox1.Items[ListBox1.SelectedIndex].Text);
        string nombre =Convert.ToString(entidad[0]);
        string direccion = Convert.ToString(entidad[1]);
        string telefono = Convert.ToString(entidad[2]);
        string fax = Convert.ToString(entidad[3]);
        string codigoactual = Convert.ToString(entidad[4]);
        string codigoanterior = Convert.ToString(entidad[5]);
        string correo = Convert.ToString(entidad[6]);
        string sitioweb = Convert.ToString(entidad[7]);
        if (Servicio.EliminarEntidad(ListBox1.SelectedItem.Text))
        {
            Servicio.InsertarHistoricoEntidad(nombre, direccion, telefono, fax, codigoactual, codigoanterior, correo, sitioweb);
            Errores.Alert(this, "Se a eliminado satisfactoriamente la entidad.");
            View4_Activate(View4, EventArgs.Empty);
        }
        else
            throw new Exception("La entidad no ha podido ser eliminada.");
    }

    //Eliminar Tema
    protected void Button20_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox2.SelectedIndex != -1)
            {
                if (TieneSubTemas(Convert.ToInt16(ListBox2.SelectedValue)))
                {
                    Errores.Alert(this, "No se puede eliminar temas con subtemas asociados.");
                    return;
                }
                new Errores(this).Confirmar("¿ Estás seguro que desea eliminar esta Informacion de Proceso ?", "Eliminar");
                MVwInformacion.ActiveViewIndex = 6;
                Button19.Enabled = Button20.Enabled = false;
            }
            else
                Errores.Alert(this, "Debe seleccionar una Información de Proceso a eliminar.");
        }
        catch (Exception ex)
            {
                Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
            }
    }
    public bool TieneSubTemas(int idTema)
    {
        object[] aux = Servicio.Lista_Temas();
        object[] datos = new object[5];
        for (int i = 0; i < aux.Length; i++)
        {
            datos = Servicio.DatosTema(Convert.ToInt16(
                ((object[])aux.GetValue(i)).GetValue(1)
                ));
            if (datos[3].ToString() == idTema.ToString())
                return true;
            datos = new object[5];
        }
        return false;

    }
    public void Eliminar()
    {
        if (Servicio.EliminarInformacion(Convert.ToInt16(ListBox2.SelectedValue)))
            {
               Errores.Alert(this," Se ha eliminado satisfactoriamente la Información de Proceso");
               View7_Activate(View7, EventArgs.Empty);
           }
            else
                throw new Exception("La Información de Proceso no ha podido ser eliminada.");
    }
    
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox2.SelectedIndex != -1)
        {
            Button19.Enabled = Button20.Enabled = true;
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        object[] TempData = new object[3];
        if (DropDownList5.SelectedValue == "AE")
        {
            TempData[0] = "PersonalDetalladoAE";
            TempData[1] = Servicio.ReportePersonalDetalladoAE(Calendar1.SelectedDate, Calendar2.SelectedDate, ListBox8.SelectedValue);
        }
        if (DropDownList5.SelectedValue == "IP")
        {
            TempData[0] = "PersonalDetalladoIP";
            TempData[1] = Servicio.ReportePersonalDetalladoIP(Calendar1.SelectedDate, Calendar2.SelectedDate, ListBox8.SelectedValue);
        }
        TempData[2] = DropDownList5.SelectedValue;

        Application["Datos"] = TempData;
        Navegador.RedirectToPopUp(this, "Reportes.aspx");
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 19;
    }

    protected void Button12_Click1(object sender, EventArgs e)
    {

        try
        {

                RequiredFieldValidator9.Visible = RequiredFieldValidator10.Visible = RequiredFieldValidator11.Visible = true;
                RequiredFieldValidator9.Validate(); RequiredFieldValidator10.Validate(); RequiredFieldValidator11.Validate();
                bool valid = RequiredFieldValidator9.IsValid && RequiredFieldValidator10.IsValid && RequiredFieldValidator11.IsValid;
                if (!valid)
                {
                    RequiredFieldValidator9.Visible = RequiredFieldValidator10.Visible = RequiredFieldValidator11.Visible = true;
                    Errores.Alert(this, "Entrada de datos no valida");
                    return;
                }
                else
                {
                    RegularExpressionValidator7.Visible = RegularExpressionValidator8.Visible = RegularExpressionValidator9.Visible = true;
                    RegularExpressionValidator7.Validate(); RegularExpressionValidator8.Validate(); RegularExpressionValidator9.Validate(); 
                    if (!RegularExpressionValidator7.IsValid || !RegularExpressionValidator8.IsValid || !RegularExpressionValidator9.IsValid)
                    {
                        RegularExpressionValidator7.Visible = RegularExpressionValidator8.Visible = RegularExpressionValidator9.Visible = true;
                        Errores.Alert(this, "Entrada de datos no válida");
                        return;
                    }
                    new Errores(this).Confirmar("¿ Está seguro que desea modificar la Entidad ?", "ModificarEntidad");
                }
            }

       
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }

    }
    public void ModificarEntidad()
    {
            string telefonos = "";
            for (int i = 0; i < DropDownList12.Items.Count; i++) 
            {
                telefonos = DropDownList12.Items[i] + ";" + telefonos;
            }
            string correos = "";
            for (int i = 0; i < DropDownList14.Items.Count; i++) 
            {
                correos = DropDownList14.Items[i] + ";" + correos;
            }
            string sitios = "";
            for (int i = 0; i < DropDownList13.Items.Count; i++)
            {
                sitios = DropDownList13.Items[i] + ";" + sitios;
            }

            Servicio.ModificarEntidad(Label4.Text, TextBox8.Text, telefonos,
                TextBox10.Text, TextBox13.Text, TextBox12.Text, sitios, correos);
            MVwInformacion.ActiveViewIndex = 3;
            Errores.Alert(this, "Se ha modificado la entidad satisfactoriamente");
            DropDownList12.Items.Clear();
            DropDownList13.Items.Clear();
            DropDownList14.Items.Clear();
        
    }
    protected void Button46_Click(object sender, EventArgs e)
    {
        if ((DropDownList3.SelectedValue == "D") && (DropDownList4.SelectedValue == "P"))
        {
            MVwInformacion.ActiveViewIndex = 20;
            DropDownList5.SelectedValue = "-1";
        }
        if ((DropDownList3.SelectedValue == "R") && (DropDownList4.SelectedValue == "P"))
        {
            MVwInformacion.ActiveViewIndex = 21;

        }
        if ((DropDownList3.SelectedValue == "D") && (DropDownList4.SelectedValue == "G"))
        {
            MVwInformacion.ActiveViewIndex = 22;

        }
        if ((DropDownList3.SelectedValue == "R") && (DropDownList4.SelectedValue == "G"))
        {
            object[] TempData = new object[3];


            TempData[0] = "GeneralResumen";
            TempData[1] = Servicio.ReporteGeneralResumen(Calendar1.SelectedDate, Calendar2.SelectedDate);

            Application["Datos"] = TempData;
            Navegador.RedirectToPopUp(this, "Reportes.aspx");                    

        }
    }

    protected void Button23_Click(object sender, EventArgs e)
    {
        object[] TempData = new object[3];

        TempData[0] = "PersonalResumen";
        TempData[1] = Servicio.ReportePersonalResumen(ListBox10.SelectedValue, Calendar1.SelectedDate, Calendar2.SelectedDate);

        Application["Datos"] = TempData;
        Navegador.RedirectToPopUp(this, "Reportes.aspx");
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 19;
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        object[] TempData = new object[3];
        if (DropDownList7.SelectedValue == "AE")
        {
            TempData[0] = "GeneralDetalladoAE";
            TempData[1] = Servicio.ReporteGeneralDetalladoAE(Calendar1.SelectedDate, Calendar2.SelectedDate);
        }
        if (DropDownList7.SelectedValue == "IP")
        {
            TempData[0] = "GeneralDetalladoIP";
            TempData[1] = Servicio.ReporteGeneralDetalladoIP(Calendar1.SelectedDate, Calendar2.SelectedDate);
        }
        TempData[2] = DropDownList7.SelectedValue;
        Application["Datos"] = TempData;
        Navegador.RedirectToPopUp(this, "Reportes.aspx");
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 19;
    }
    protected void Button27_Click(object sender, EventArgs e)
    {

        object[] TempData = new object[3];
        if ((DropDownList6.SelectedValue == "AE") && (DropDownList8.SelectedValue == "D"))
        {
            TempData[0] = "ConsultasAE";
            TempData[1] = Servicio.ReporteConsultasAE(Calendar3.SelectedDate, Calendar4.SelectedDate);
        }
        if ((DropDownList6.SelectedValue == "AE") && (DropDownList8.SelectedValue == "A"))
        {
            TempData[0] = "ConsultasAEA";
            TempData[1] = Servicio.ReporteConsultasAE(Calendar3.SelectedDate, Calendar4.SelectedDate);
        }
        if ((DropDownList6.SelectedValue == "IP") && (DropDownList8.SelectedValue == "D"))
        {
            TempData[0] = "ConsultasIP";
            TempData[1] = Servicio.ReporteConsultasIP(Calendar3.SelectedDate, Calendar4.SelectedDate);
        }
        if ((DropDownList6.SelectedValue == "IP") && (DropDownList8.SelectedValue == "A"))
        {
            TempData[0] = "ConsultasIPA";
            TempData[1] = Servicio.ReporteConsultasIP(Calendar3.SelectedDate, Calendar4.SelectedDate);
        }
        TempData[2] = DropDownList8.SelectedValue;

        Application["Datos"] = TempData;
        Navegador.RedirectToPopUp(this, "Reportes.aspx");
    }
    protected void Button28_Click(object sender, EventArgs e)
    {

    }
    protected void Button50_Click(object sender, EventArgs e)
    {

    }
    protected void Button51_Click(object sender, EventArgs e)
    {

    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 23;
    }
    protected void Calendar3_Init(object sender, EventArgs e)
    {
        ((Calendar)sender).SelectedDate = DateTime.Today;
    }
    protected void Calendar1_Init(object sender, EventArgs e)
    {
        ((Calendar)sender).SelectedDate = DateTime.Today;
    }
    protected void Calendar2_Init(object sender, EventArgs e)
    {
        ((Calendar)sender).SelectedDate = DateTime.Today;
    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)sender).Items.FindByValue("-1") != null)
            ((DropDownList)sender).Items.Remove(((DropDownList)sender).Items.FindByValue("-1"));
        if (((DropDownList)sender).SelectedValue == "AE")
        {
            ListBox8.Items.Clear();
            string[][] TempOperadoras = Servicio.OperadorasAE(Calendar1.SelectedDate, Calendar2.SelectedDate);
            for (int i = 0; i < TempOperadoras[0].Length; i++)
                ListBox8.Items.Add(new ListItem("(" + TempOperadoras[1][i] + ") " + TempOperadoras[0][i], TempOperadoras[1][i]));
        }
        if (((DropDownList)sender).SelectedValue == "IP")
        {
            ListBox8.Items.Clear();
            string[][] TempOperadoras = Servicio.OperadorasIP(Calendar1.SelectedDate, Calendar2.SelectedDate);
            for (int i = 0; i < TempOperadoras[0].Length; i++)
                ListBox8.Items.Add(new ListItem("(" + TempOperadoras[1][i] + ") " + TempOperadoras[0][i], TempOperadoras[1][i]));
        }


    }
    protected void View22_Activate(object sender, EventArgs e)
    {
        ListBox10.Items.Clear();
        string[][] TempOperadoras = Servicio.Operadoras(Calendar1.SelectedDate, Calendar2.SelectedDate);
        for (int i = 0; i < TempOperadoras[0].Length; i++)
            ListBox10.Items.Add(new ListItem("(" + TempOperadoras[1][i] + ") " + TempOperadoras[0][i], TempOperadoras[1][i]));
    }
    protected void View21_Activate(object sender, EventArgs e)
    {
        try
        {
            DropDownList5.SelectedValue = "-1";
        }
        catch
        {
            DropDownList5.Items.Add(new ListItem("<< Seleccione un Tipo de Reporte >>", "-1"));
        }
       /* if (DropDownList5.SelectedValue == "-1")*/ ListBox8.Items.Clear();
    }
    protected void Button28_Click1(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 19;
    }
    protected void Button29_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 23;
    }
    protected void Button30_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 18;
    }
    protected void Button44_Click1(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 18;
    }

    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar3.SelectedDate > Calendar4.SelectedDate)
        {
            Calendar3.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            Errores.Alert(this, " Entrada de datos no válida.");

            Button27.Enabled = false;

        }
        else
        {
            Calendar3.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Calendar4.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Button27.Enabled = true;
        }

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > Calendar2.SelectedDate)
        {
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            Errores.Alert(this, " Entrada de datos no válida.");

            Button46.Enabled = false;

        }
        else
        {
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Calendar2.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Button46.Enabled = true;
        }

    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > Calendar2.SelectedDate)
        {
            Calendar2.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            Errores.Alert(this, " Entrada de datos no válida.");

            Button46.Enabled = false;

        }
        else
        {
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Calendar2.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Button46.Enabled = true;
        }
    }
    protected void View21_Load(object sender, EventArgs e)
    {

    }
    protected void ListBox8_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button10.Enabled = ((ListBox8.SelectedIndex > -1) && (DropDownList5.SelectedValue != "-1"));
    }
    protected void Button45_Click1(object sender, EventArgs e)
    {
        DropDownList9.Items.Add(TextBox3.Text.ToString());
        TextBox3.Text = "";
    }
    protected void Button47_Click(object sender, EventArgs e)
    {

    }
    protected void Button47_Click1(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator3.Validate(); RequiredFieldValidator8.Validate();
            if (RegularExpressionValidator3.IsValid && RequiredFieldValidator8.IsValid)
            {
                DropDownList9.Items.Add(TextBox3.Text);
                TextBox3.Text = "";
            }
            else 
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch(Exception ex)
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
                
           
    }


    protected void Button53_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator10.Validate(); RequiredFieldValidator17.Validate();
            if (RegularExpressionValidator10.IsValid && RequiredFieldValidator17.IsValid)
            {
                DropDownList12.Items.Add(TextBox9.Text);
                TextBox9.Text = "";
            }
            else
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
        
    }
    protected void Calendar4_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar3.SelectedDate > Calendar4.SelectedDate)
        {
            Calendar4.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            Errores.Alert(this, " Entrada de datos no válida.");

            Button27.Enabled = false;

        }
        else
        {
            Calendar3.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Calendar4.SelectedDayStyle.BackColor = System.Drawing.Color.Empty;
            Button27.Enabled = true;
        }
    }
    protected void ListBox10_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button23.Enabled = ListBox10.SelectedIndex > -1;
    }
    protected void Button25_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Label5.Text == "" || TextBox19.Text == "" || TextBox20.Text == "")
            {
                RequiredFieldValidator13.Visible = RequiredFieldValidator14.Visible = true;
                RequiredFieldValidator13.Validate(); RequiredFieldValidator14.Validate();
                bool valid = RequiredFieldValidator13.IsValid && RequiredFieldValidator14.IsValid;
                if (!valid)
                {
                    RequiredFieldValidator13.Visible = RequiredFieldValidator14.Visible = true;
                    Errores.Alert(this, "Entrada de datos no válida.");
                    return;
                }
            }
            else
            {
                new Errores(this).Confirmar("¿ Está seguro que desea Modificar la Información de Proceso ?", "Modificar");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));
        }
   }
    public void Modificar()
    {

        string[] Arreglo = QuitarEspacios(TextBox20.Text.Trim());
        if (Arreglo.Length > 0)
        {
            Servicio.ModificarInformacion(Label5.Text,Arreglo,int.Parse(DropDownList2.Items[DropDownList2.SelectedIndex].Value.Trim()), TextBox19.Text, Convert.ToInt16(HiddenField1.Value));
            Button2_Click(this, EventArgs.Empty);
            Errores.Alert(this, "Se ha modificado satisfactoriamente la Información de Proceso.");
            // Para contar los elementos del DropDownList
            //string[] lista = new string[DropDownList1.Items.Count];

            //string aux = TextBox20.Text;

            //for (int i = 0; i < DropDownList1.Items.Count ; i++)
            //{
            //    lista[i] = DropDownList1.Items[0].Text;
            //}
        }
    }
    protected void View7_Activate(object sender, EventArgs e)
    {
        ListBox2.Items.Clear();
        try
        {
            Button19.Enabled = Button20.Enabled = false;
             object[] aux = Servicio.Lista_Temas();

            for (int i = 0; i < aux.Length; i++)
            {
                ListBox2.Items.Add(new ListItem(((object[])aux.GetValue(i)).GetValue(0).ToString(),
                                         ((object[])aux.GetValue(i)).GetValue(1).ToString()));
            }
        }
        catch
        {
            Errores.Alert(this,"No existe Información de Procesos.");
        }
    }
    protected void Button49_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator4.Validate(); RequiredFieldValidator15.Validate();
            if (RegularExpressionValidator4.IsValid && RequiredFieldValidator15.IsValid)
            {
                DropDownList10.Items.Add(TextBox5.Text);
                TextBox5.Text = "";
            }
            else
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch(Exception ex) 
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
        
    }
    protected void Button51_Click1(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator5.Validate(); RequiredFieldValidator16.Validate();
            if (RegularExpressionValidator5.IsValid && RequiredFieldValidator16.IsValid)
            {
                DropDownList11.Items.Add(TextBox18.Text);
                TextBox18.Text = "";
            }
            else
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch (Exception ex) 
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
        
    }
    protected void Button55_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator11.Validate(); RequiredFieldValidator18.Validate();
            if (RegularExpressionValidator11.IsValid && RequiredFieldValidator18.IsValid)
            {
                DropDownList13.Items.Add(TextBox11.Text);
                TextBox11.Text = "";
            }
            else
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
        
    }
    protected void Button57_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator12.Validate(); RequiredFieldValidator19.Validate();
            if (RegularExpressionValidator12.IsValid && RequiredFieldValidator19.IsValid)
            {
                DropDownList14.Items.Add(TextBox21.Text);
                TextBox21.Text = "";
            }
            else
            {
                Errores.Alert(this, "Entrada de datos no válida");
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error a ocurrido: " + ex.Message);
        }
        
    }
    protected void Button45_Click2(object sender, EventArgs e)
    {
        DropDownList9.Items.Remove(DropDownList9.SelectedItem);
    }
    protected void Button48_Click(object sender, EventArgs e)
    {
        DropDownList10.Items.Remove(DropDownList10.SelectedItem);
    }
    protected void Button50_Click1(object sender, EventArgs e)
    {
        DropDownList11.Items.Remove(DropDownList11.SelectedItem);
    }
    protected void Button52_Click(object sender, EventArgs e)
    {
        DropDownList12.Items.Remove(DropDownList12.SelectedItem);
    }
    protected void Button54_Click(object sender, EventArgs e)
    {
        DropDownList13.Items.Remove(DropDownList13.SelectedItem);
    }
    protected void Button56_Click(object sender, EventArgs e)
    {
        DropDownList14.Items.Remove(DropDownList14.SelectedItem);
    }
    public void HabilitarBoton(CheckBox Ch, Button Bu) 
    {
        Bu.Enabled = false;
        if (Ch.Checked)
        {
            Bu.Enabled = true;
        }
    }

    protected void View12_Activate(object sender, EventArgs e)
    {
        Button33.Enabled = false;
        
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        HabilitarBoton((CheckBox)sender, Button33);
    }
    protected void View14_Activate(object sender, EventArgs e)
    {
        
    }
    protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox4.Items.Count > 0)
        {
            Button36.Enabled = true;

        }
    }
    protected void View4_Activate(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        try
        {
            Button6.Enabled = Button7.Enabled = false;
            object[] aux = Servicio.Lista_Entidades();

            for (int i = 0; i < aux.Length; i++)
            {
                ListBox1.Items.Add(new ListItem(((object[])aux.GetValue(i)).GetValue(0).ToString(),
                                                  ((object[])aux.GetValue(i)).GetValue(1).ToString()));
            }
        }
        catch 
        {
            ListBox1.Items.Add("No existen entidades en la Agenda Electrónica.");
        }
    }
    protected void View6_Activate(object sender, EventArgs e)
    {
        try
        {
            if (ListBox1.SelectedIndex != -1)
            {
                object[] entidad = Servicio.BuscarDatosEntidad(ListBox1.Items[ListBox1.SelectedIndex].Text);
                Label4.Text = entidad[0].ToString();
                TextBox8.Text = entidad[1].ToString();
                char[] c ={ ';' };
                
                string [] telefonos = entidad[2].ToString().Split(c);
                for(int i=0;i<telefonos.Length-1;i++)
                {
                    DropDownList12.Items.Add(telefonos[i]);
                }
                TextBox10.Text = entidad[3].ToString();
                string [] sitios=entidad[6].ToString().Split(c);
                for (int j = 0; j < sitios.Length - 1; j++) 
                {
                    DropDownList13.Items.Add(sitios[j]);
                }
                TextBox12.Text = entidad[5].ToString();
                TextBox13.Text = entidad[4].ToString();
                string[] correos = entidad[7].ToString().Split(c);
                for (int h = 0; h < correos.Length - 1; h++) 
                {
                    DropDownList14.Items.Add(correos[h]);
                }
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex != -1)
        {
            Button6.Enabled = Button7.Enabled = true;
        }
    }
   protected void Button58_Click(object sender, EventArgs e)
    {
        CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = CheckBox4.Checked = CheckBox5.Checked = CheckBox6.Checked = CheckBox7.Checked = CheckBox8.Checked = false;
        MVwInformacion.ActiveViewIndex = 9;
    }
    protected void Button59_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 2;
    }
    protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox3.SelectedIndex != -1)

            Button32.Enabled = true;
    }
    protected void View11_Activate(object sender, EventArgs e)
    {
        Button32.Enabled = false;
    }
    protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox6.SelectedIndex != -1)

            Button40.Enabled = true;
    }
    protected void View17_Activate(object sender, EventArgs e)
    {
        Button40.Enabled = true;
    }
    protected void Calendar5_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = false;

        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }

        if (e.Day.Date.DayOfWeek.Equals(DayOfWeek.Saturday))
        {
            if (!e.Day.IsOtherMonth)
                sabados++;

            if (Math.Abs(Math.IEEERemainder(sabados, 2)).Equals(0) && !e.Day.IsOtherMonth)
            {
                e.Cell.BackColor = System.Drawing.Color.DarkKhaki;
            }

        }
    }
    protected void Button60_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 24;
        DropDownList15.SelectedIndex = -1;
    }
    protected void View25_Activate(object sender, EventArgs e)
    {
        if (DateTime.Today.Month == 1 || DateTime.Today.Month == 2 || DateTime.Today.Month == 3 || DateTime.Today.Month == 6 || DateTime.Today.Month == 7 || DateTime.Today.Month == 9 || DateTime.Today.Month == 10  || DateTime.Today.Month == 11)
        {
            Label8.Text = "1"; 
        }

        if (DateTime.Today.Month == 4 || DateTime.Today.Month == 5 || DateTime.Today.Month == 8 || DateTime.Today.Month == 12)
        {
            Label8.Text = "2";
           
        }
           
        
    }
    protected void Calendar6_DayRender(object sender, DayRenderEventArgs e)
    {

        e.Day.IsSelectable = false;

        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }


        if (e.Day.Date.DayOfWeek.Equals(DayOfWeek.Saturday))
        {
            if (!e.Day.IsOtherMonth)
                sabados++;

            if (Math.Abs(Math.IEEERemainder(sabados, 2)).Equals(1) && !e.Day.IsOtherMonth)
            {
                e.Cell.BackColor = System.Drawing.Color.DarkKhaki;
            }

        }

    }
    protected void Button64_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 25;
    }
    protected void Button61_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 26;
        DropDownList16.SelectedIndex = -1;
    }
    protected void Button63_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 27;
        DropDownList17.SelectedIndex = 2; //Aqui se cambia el orden de la provincia que se quiere mostrar primero
        DropDownList18.SelectedIndex = -1;
    }
    protected void Button62_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 28;
        RadioButtonList1.SelectedIndex = -1;
    }

    protected void Button65_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 29;
    }

    protected void Button67_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 30;
        DropDownList20.SelectedIndex = -1;
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
    protected void Calendar4_DayRender(object sender, DayRenderEventArgs e)
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
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedIndex != -1)
        {
            if (RadioButtonList2.SelectedValue == "1")
            {
                Panel27.Visible = true;
            }
            else
            {
                Panel27.Visible = false;
                
            }
            if (RadioButtonList2.SelectedValue == "2")
            {
                Panel28.Visible = true;
            }
            else
            {
                
                Panel28.Visible = false;
            }
            if (RadioButtonList2.SelectedValue == "3")
            {
                Panel29.Visible = true;
            }
            else
            {

                Panel29.Visible = false;
            }
            if (RadioButtonList2.SelectedValue == "4")
            {
                Panel31.Visible = true;
            }
            else
            {

                Panel31.Visible = false;
            }
            if (RadioButtonList2.SelectedValue == "5")
            {
                Panel4.Visible = true;
            }
            else
            {
                Panel4.Visible = false;

            }
        }
    }
    protected void Button66_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 31;
    }
    protected void View32_Activate(object sender, EventArgs e)
    {
        RadioButtonList2.SelectedIndex = -1;
        Panel27.Visible = false;
        Panel28.Visible = false;
        Panel29.Visible = false;
        Panel31.Visible = false;
    }
    protected void GridView7_DataBound(object sender, EventArgs e)
    {
        Label37.Text = Convert.ToString(GridView7.Rows.Count);
    }
    protected void Button68_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 32;
    }
    
    protected void DropDownList21_SelectedIndexChanged(object sender, EventArgs e)
    {
        double a = 0;
        double b = 0;
        for (int i = 0; i < GridView4.Rows.Count; i++)
            if (DropDownList21.SelectedValue.ToString() == GridView4.Rows[i].Cells[1].Text)
            {
                
                a = Convert.ToDouble(GridView4.Rows[i].Cells[3].Text); // columna de la Compra
                b = Convert.ToDouble(GridView4.Rows[i].Cells[4].Text); // columna de la Venta
                break;
            }

        Session["a"] = a; // Compra
        Session["b"] = b; // Venta
    }
    protected void Button69_Click(object sender, EventArgs e)
    {
        try
        {
            double calcompra = 0;
            double calventa = 0;
            if (TextBox17.Text.Trim() != "" && DropDownList21.SelectedValue.ToString() != "0")
            {
                //if (DropDownList21.SelectedValue.ToString() == "GBP" || DropDownList21.SelectedValue.ToString() == "EUR")
                //{
                //    calcompra = (Convert.ToDouble(TextBox17.Text.Trim()) * Convert.ToDouble(Session["a"])) - (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 3.25) / 100);
                //    calventa = (Convert.ToDouble(TextBox17.Text.Trim()) * Convert.ToDouble(Session["a"])) + (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 10) / 100);

                //}
                //else
                //{
                //    if (DropDownList21.SelectedValue.ToString() == "USD")
                //    {
                //        calcompra = (Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) - (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 10) / 100);
                //        calventa = (Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["b"])) + (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 3.25) / 100);
                //    }
                //    else
                //    {
                //        calcompra = (Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) - (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 3.25) / 100);
                //        calventa = (Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["b"])) + (((Convert.ToDouble(TextBox17.Text.Trim()) / Convert.ToDouble(Session["a"])) * 3.25) / 100);
                //    }
                //}

                // cambios hechos 13/03/2018 Raul: Hacer el calculo con los valores q tiene en SABIC real

                DataSet tipo_cambio = new DataSet();

                tipo_cambio = Servicio.Calcular_Tipo_Cambio(DateTime.Now.Date);

                DataRow[] fila = tipo_cambio.Tables[0].Select("sig_moneda = '" + DropDownList21.SelectedValue.ToString() + "'");

                double cant_a_cambiar = Convert.ToDouble(TextBox17.Text);
                //double valor_compra = Convert.ToDouble(Session["a"]);
                //double valor_venta = Convert.ToDouble(Session["b"]);

                Session["v_real_compra"] = fila[0]["compra"].ToString();
                Session["v_real_venta"] = fila[0]["venta"].ToString();

                double valor_compra = (Convert.ToDouble(Session["v_real_compra"]));
                double valor_venta = (Convert.ToDouble(Session["v_real_venta"]));


                if (DropDownList21.SelectedValue.ToString() == "USD")
                {
                    calcompra = Convert.ToDouble((cant_a_cambiar / valor_compra)) - Convert.ToDouble((((cant_a_cambiar / valor_compra) * 10) / 100));     /*(Convert.ToDouble(10 / 100));*/
                    calventa = (cant_a_cambiar / valor_venta);
                }
                else
                {
                    calcompra = (cant_a_cambiar * valor_compra);
                    calventa = (cant_a_cambiar * valor_venta);
                }

                Label40.Text = "Por vendernos " + TextBox17.Text.Trim() + " " + DropDownList21.SelectedValue.ToString() + " a " + Session["a"] + " le pagamos $ " + calcompra.ToString("F2") + " CUC";
                Label41.Text = "Por comprarnos " + TextBox17.Text.Trim() + " " + DropDownList21.SelectedValue.ToString() + " a " + Session["b"] + " le cobramos $ " + calventa.ToString("F2") + " CUC";
            }
            else
            {
                Label40.Text = "";
                Label41.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void DropDownList21_DataBound(object sender, EventArgs e)
    {
        DropDownList21.Items.Insert(0, new ListItem("", "0"));
    }
    protected void Button70_Click(object sender, EventArgs e)
    {
        MVwInformacion.ActiveViewIndex = 33;
    }
    protected void View35_Activate(object sender, EventArgs e)
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
        CheckBox20.Checked = false;
        CheckBox20.Visible = false;
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
                    CheckBox20.Checked = true;
                    CheckBox20.Visible = true;
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
                    CheckBox20.Checked = false;
                    CheckBox20.Visible = false;
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
                    CheckBox20.Checked = false;
                    CheckBox20.Visible = false;
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
    protected void CheckBox20_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox20.Checked)
        {
            ASPxLabel4_desde.Visible = true;
            ASPxLabel5_hasta.Visible = true;
            Calendar28.Visible = true;
            Calendar29.Visible = true;
        }
        else if (!CheckBox20.Checked)
        {
            ASPxLabel4_desde.Visible = false;
            ASPxLabel5_hasta.Visible = false;
            Calendar28.Visible = false;
            Calendar29.Visible = false;
        }
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
                    if (CheckBox20.Checked)
                    {
                        inicio = Calendar28.SelectedDate.Date;
                        fin = Calendar29.SelectedDate.Date;
                    }
                    else if (!CheckBox20.Checked)
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
                else if (msg != "" && coderr != 0)
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
    protected void ASPxButton10_Click(object sender, EventArgs e)
    {
        this.View35_Activate(sender, e);
    }
}