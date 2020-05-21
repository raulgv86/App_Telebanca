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
using System.Security;
using System.Threading;




public partial class WebUserControl_Administracion : System.Web.UI.UserControl
{
    private TeleBancaWS.TeleBancaWS Servicio;
    private static Thread Rest;
    private static Thread Salv;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (Servicio == null)
            if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];

        if (!this.IsPostBack)
        {
            try
            {
                string[][] datosMenu = Servicio.GetDataMenu(1);
                Menu1.Items.Clear();

                MenuItem subMenu1 = new MenuItem();
                subMenu1.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu1.Selected = false;
                Menu1.Items.Add(subMenu1);

                MenuItem subMenu2 = new MenuItem();
                subMenu2.SeparatorImageUrl = "~/Images/Imagenes/separador del menú lateral .jpg";
                subMenu2.Selected = false;
                subMenu2.Text = "Administración";
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
            }

           
        }

    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MultiView1.ActiveViewIndex = Convert.ToInt32(e.Item.Value);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator3.Validate(); RegularExpressionValidator4.Validate();RegularExpressionValidator22.Validate();
        int a = 0;
        foreach (char i in TextBoxCrearUsuarioClave.Text.ToCharArray())
        {
            if (i == ' ') 
            {
                a++;
            }
        }
        if(a == TextBoxCrearUsuarioClave.Text.ToCharArray().Length)
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (!RegularExpressionValidator3.IsValid || !RegularExpressionValidator4.IsValid || !RegularExpressionValidator22.IsValid) 
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (TextBoxCrearUsuarioNombre.Text == "" || TextBoxCrearUsuarioUsuario.Text == "" || TextBoxCrearUsuarioNombre.Text.StartsWith(" ") || TextBoxCrearUsuarioUsuario.Text.StartsWith(" "))
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (TextBoxCrearUsuarioClave.Text != TextBoxCrearUsuarioConfirmClave.Text)
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        Session["pass"] = TextBoxCrearUsuarioClave.Text;

        try
        {
            if (this.AdicionarUsuario()) {
                Errores.Alert(this, "Usuario creado con exito");
            }
            else
                Errores.Alert(this, "Usuario no creado. Verificar que ya no exista el usuario o el Carnet identidad");
        }
        catch (Exception)
        {
            throw;
        }
        //new Errores(this).Confirmar("¿ Está seguro que desea guardar el nuevo usuario? ", "AdicionarUsuario");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        GridView3.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string[] user = Servicio.getUsuariActivo();
        string error = "";
        string nombre=TextBoxModificarUsuarioNombre.Text;
        string rol = DropDownListModificarUsuarioRol.Text;
        string nombre_usuario = TextBoxModificarUsuarioUsuario.Text;
        string ci = TextBoxModificarUsuarioCarnet.Text;

        RegularExpressionValidator5.Validate(); RegularExpressionValidator14.Validate(); RegularExpressionValidator23.Validate();
        int a = 0,b = 0;
        foreach (char i in TextBoxModificarUsuarioClave.Text.ToCharArray())
        {
            if (i == ' ') 
            {
                a++;
            }
        }
        if (a == TextBoxModificarUsuarioClave.Text.ToCharArray().Length) 
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (!RegularExpressionValidator5.IsValid || !RegularExpressionValidator14.IsValid || !RegularExpressionValidator23.IsValid) 
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if ((TextBoxModificarUsuarioClave.Text != TextBoxModificarUsuarioConfirmClave.Text))
        {
            Errores.Alert(this, "Contraseña y Confirmar Contraseña no coinciden"); return;
        }

        if (TextBoxModificarUsuarioNombre.Text == "" || TextBoxModificarUsuarioUsuario.Text == "" || TextBoxModificarUsuarioNombre.Text.StartsWith(" ") || TextBoxModificarUsuarioUsuario.Text.StartsWith(" "))
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }

        if (TextBoxModificarUsuarioClave.Text == TextBoxModificarUsuarioUsuario.Text)
        {
            Errores.Alert(this, "La Contraseña no puede ser igual al Usuario"); return;
        }

        if (!SecurInstallSabic.ClaveAcceso.ValidarFortalezaClave(TextBoxModificarUsuarioClave.Text, out error, 6, true, true, true, true))
        {
            Errores.Alert(this, error); return;
        }

        // Raul: Modificar Usuario

        string passNew = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TextBoxModificarUsuarioClave.Text);
        
        if (Servicio.ModificarUsuario(nombre, passNew,rol,nombre_usuario,true,ci) == true)
        {
            Errores.Alert(this, "Modificacion realizada satisfactoriamente");
           
        }
        // 

        //validar con las contraseñas anteriores yisel
        //string cAnterior = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TextBoxModificarUsuarioClave.Text);
        //try
        //{
        //    string[] tmpUsuario = Servicio.getUsuariActivo();

        //    if (tmpUsuario[1].ToLower().Equals(cAnterior.ToLower()))
        //    {
        //        Session["pass1"]  = TextBoxModificarUsuarioClave.Text;
        //        new Errores(this).Confirmar("¿Está seguro que desea guardar los cambios realizados ?", "ModificarUsuario");
        //    }
        //    else
        //        Errores.Alert(this, "Contraseña incorrecta");
        
        //}
        //catch (Exception ex)
        //{
        //    Errores.Alert(this, "Error... " + ex.Message);
        //}
        Session["pass1"] = TextBoxModificarUsuarioClave.Text;
        //new Errores(this).Confirmar("¿Está seguro que desea guardar los cambios realizados ?", "ModificarUsuario");

    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        TextBoxModificarUsuarioNombre.Text = "";
        TextBoxModificarUsuarioUsuario.Text = "";
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator7.Validate(); RegularExpressionValidator8.Validate();
        if (!RegularExpressionValidator7.IsValid || !RegularExpressionValidator8.IsValid) 
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (CheckBoxListCrearRolFuncionalidades.SelectedIndex == -1)
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (TextBoxCrearRolNombre.Text == "" || TextBoxCrearRolDescripcion.Text == "" || TextBoxCrearRolNombre.Text.StartsWith(" ") || TextBoxCrearRolDescripcion.Text.StartsWith(" "))
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        //new Errores(this).Confirmar("¿ Desea guardar el nuevo rol ?", "AdicionarRol");

        if (this.AdicionarRol()) {
            Errores.Alert(this, "Rol creado con exito");
        }
        else
            Errores.Alert(this, "Rol no se pudo ser creado");
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        TextBoxCrearRolNombre.Text = "";
        TextBoxCrearRolDescripcion.Text = "";
        MultiView1.ActiveViewIndex = 4;
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        TextBoxModificarRolNombre.Text = "";
        TextBoxD.Text = "";
        MultiView1.ActiveViewIndex = 4;
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator9.Validate(); RegularExpressionValidator10.Validate();
        if (!RegularExpressionValidator9.IsValid || !RegularExpressionValidator10.IsValid)
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (CheckBoxListModificarRolFuncionalidades.SelectedIndex == -1)
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        if (TextBoxModificarRolNombre.Text == "" || TextBoxD.Text == "" || TextBoxModificarRolNombre.Text.StartsWith(" ") || TextBoxD.Text.StartsWith(" "))
        {
            Errores.Alert(this, "Entrada de datos no válida"); return;
        }
        //new Errores(this).Confirmar("¿ Desea guardar los datos ?", "ModificarRol");
        if (this.ModificarRol())
        {
            Errores.Alert(this, "Rol modificado con exito"); return;
        }
        else
            Errores.Alert(this, "No se pudo modificar el Rol"); return;
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
    }

    protected void Button25_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }
    protected void Button26_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        //new Errores(this).Confirmar("¿ Desea eliminar el rol ?", "EliminarRol");
        if (this.EliminarRol()) {
            Errores.Alert(this, "Rol eliminado con exito");
        }
        else
            Errores.Alert(this, "Rol no eliminado ");
    }

    protected void Button28_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 17;
    }
    protected void Button29_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button30_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button33_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 10;
    }
    protected void Button34_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 10;
    }
    protected void Button36_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 17;
    }
    protected void Button35_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 14;
    }
    protected void Button37_Click(object sender, EventArgs e)
    {
        if (RadioButtonListSalvarRestaurarDatos.SelectedIndex == 0)
            MultiView1.ActiveViewIndex = 0;
        if (RadioButtonListSalvarRestaurarDatos.SelectedIndex == 1)
            MultiView1.ActiveViewIndex = 0;

    }
    protected void Button38_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }

    protected void Button43_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 15;
    }
    protected void Button44_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 15;
    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 19;
    }


    protected void Button48_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 29;
    }
    protected void Button49_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 27;
    }
    protected void Button50_Click(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RangeValidator1.Visible = RegularExpressionValidator1.Visible = RegularExpressionValidator15.Visible = RegularExpressionValidator16.Visible = RegularExpressionValidator17.Visible = RegularExpressionValidator18.Visible = RegularExpressionValidator19.Visible = RegularExpressionValidator20.Visible = RangeValidator2.Visible = true;
        RequiredFieldValidator1.Validate(); RequiredFieldValidator2.Validate(); RangeValidator1.Validate(); RegularExpressionValidator1.Validate(); RegularExpressionValidator15.Validate(); RegularExpressionValidator16.Validate(); RegularExpressionValidator17.Validate(); RegularExpressionValidator18.Validate(); RegularExpressionValidator19.Validate(); RegularExpressionValidator20.Validate(); RangeValidator2.Validate();
        bool valid = RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && RangeValidator1.IsValid && RegularExpressionValidator1.IsValid && RegularExpressionValidator15.IsValid && RegularExpressionValidator16.IsValid && RegularExpressionValidator17.IsValid && RegularExpressionValidator18.IsValid && RegularExpressionValidator19.IsValid && RegularExpressionValidator20.IsValid && RangeValidator2.IsValid;
        if (!valid)
        {
            RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RangeValidator1.Visible = RegularExpressionValidator1.Visible = RegularExpressionValidator15.Visible = RegularExpressionValidator16.Visible = RegularExpressionValidator17.Visible = RegularExpressionValidator18.Visible = RegularExpressionValidator19.Visible = RegularExpressionValidator20.Visible = RangeValidator2.Visible= true;
            Errores.Alert(this, " Entrada de datos no válida ");
            return;
        }
        RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RangeValidator1.Visible = RegularExpressionValidator1.Visible = RegularExpressionValidator15.Visible = RegularExpressionValidator16.Visible = RegularExpressionValidator17.Visible = RegularExpressionValidator18.Visible = RegularExpressionValidator19.Visible = RegularExpressionValidator20.Visible = RangeValidator2.Visible = true;
       
        //new Errores(this).Confirmar("¿ Está seguro que desea modificar la Informacion de la Banca ?", "ModificarInformacionTb");

        try
        {
            this.ModificarInformacionTb();
        }
        catch (Exception)
        {
            throw;
        }
    }


    protected void Button51_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }

    protected void Button53_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 28;
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Session["passPast"] = Servicio.BuscarUsuario(ListBoxGestionarUsuarioUsuarios.SelectedValue).GetValue(2).ToString();
        MultiView1.ActiveViewIndex = 3;
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        //new Errores(this).Confirmar("¿ Está seguro que desea eliminar el usuario ?", "EliminarUsuario");
        if (this.EliminarUsuario()) {
            Errores.Alert(this, "Usuario eliminado con exito");
        }
        else
            Errores.Alert(this, "Usuario no eliminado");
    }
    protected void View9_Load(object sender, EventArgs e)
    {
        Button15.Enabled = false;
        Button16.Enabled = false;
        Panel2.Visible = false;
    }
    protected void Button7_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }
    protected void CheckBoxListCrearRolFuncionalidades_Load(object sender, EventArgs e)
    {
        try
        {
            CheckBoxListCrearRolFuncionalidades.DataSource = Servicio.ObtenerListaFuncionalidades();
            CheckBoxListCrearRolFuncionalidades.DataBind();
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos" );
        }
    }
    protected void Button6_Click1(object sender, EventArgs e)
    {

        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }
    protected void Button10_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;

    }
    protected void ListBoxGestionarUsuarioUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ListBoxGestionarUsuarioUsuarios.SelectedIndex == -1)
        {
            Button2.Enabled = false;
            Button3.Enabled = false;
        }
        try
        {
            Panel1.Visible = true;
            string[] datosUsuario = Servicio.BuscarUsuario(ListBoxGestionarUsuarioUsuarios.SelectedValue);
            string nombre = datosUsuario[0];
            string usuario = datosUsuario[1];
            string rol = datosUsuario[3];
            string carnet = datosUsuario[5];
            LabelGestionarUsuarioNombre.Text = nombre;
            LabelGestionarUsuarioUsuario.Text = usuario;
            LabelGestionarUsuarioRol.Text = rol;
            LabelGestionarUsuarioCarnet.Text = carnet;
            Button2.Enabled = true;
            Button3.Enabled = true;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }
    }
    protected void gestionarInformTb_Activate(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Visible = RequiredFieldValidator2.Visible = RangeValidator1.Visible = RegularExpressionValidator1.Visible = false;
        try
        {
            bool creada = true;
            if (creada == true)
            {
                string[] tmpInfTB = Servicio.GetInformacionTb();
                TextBox30.Text = tmpInfTB[0];
                TextBox31.Text = tmpInfTB[1];
                TextBox32.Text = tmpInfTB[2];
                TextBox33.Text = tmpInfTB[3];
                TextBox34.Text = tmpInfTB[4];
                TextBox35.Text = tmpInfTB[5];
                TextBox36.Text = tmpInfTB[6];
                TextBox37.Text = tmpInfTB[7];
                TextBox38.Text = tmpInfTB[9];
                TextBox39.Text = tmpInfTB[8];
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos");
            MultiView1.ActiveViewIndex = 0;
        }

    }
    protected void gestionarUsuario_Activate(object sender, EventArgs e)
    {
        try
        {
            ListBoxGestionarUsuarioUsuarios.DataSource = Servicio.GetListaUsuarios();
            ListBoxGestionarUsuarioUsuarios.DataBind();
        }
        catch (Exception ex)
        {
            Panel1.Visible = false;
            Errores.Alert(this, "Error de conexión con la base de datos");            
        }
    }
    protected void gestionarRoles_Activate(object sender, EventArgs e)
    {
        ListBoxGestionatRolesRoles.SelectedIndex = -1;
        try
        {
            ListBoxGestionatRolesRoles.DataSource = Servicio.ObtenerListaRoles();
            ListBoxGestionatRolesRoles.DataBind();
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

    }
    protected void modificarUsuario_Activate(object sender, EventArgs e)
    {
        try
        {
            string[] TempUser = Servicio.BuscarUsuario(ListBoxGestionarUsuarioUsuarios.SelectedValue);
            TextBoxModificarUsuarioNombre.Text = TempUser[0];
            TextBoxModificarUsuarioUsuario.Text = ListBoxGestionarUsuarioUsuarios.SelectedValue;
            TextBoxModificarUsuarioUsuario.Enabled = false;
            TextBoxModificarUsuarioCarnet.Text = TempUser[5];
            DropDownListModificarUsuarioRol.DataSource = Servicio.ObtenerListaRoles();
            DropDownListModificarUsuarioRol.DataBind();
            DropDownListModificarUsuarioRol.SelectedIndex = DropDownListModificarUsuarioRol.Items.IndexOf(
            DropDownListModificarUsuarioRol.Items.FindByText(TempUser[3]));
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

    }

    protected void crearRol_Activate(object sender, EventArgs e)
    {

        try
        {
            CheckBoxListCrearRolFuncionalidades.DataSource = Servicio.ObtenerListaFuncionalidades();
            CheckBoxListCrearRolFuncionalidades.DataBind();
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }
    }
    protected void modificarRol_Activate(object sender, EventArgs e)
    {
        try
        {
            TextBoxModificarRolNombre.Text = ListBoxGestionatRolesRoles.SelectedValue;
            TextBoxModificarRolNombre.Enabled = false;
            CheckBoxListModificarRolFuncionalidades.DataSource = Servicio.ObtenerListaFuncionalidades();
            CheckBoxListModificarRolFuncionalidades.DataBind();

            string[] arr = Servicio.BuscarRol(ListBoxGestionatRolesRoles.SelectedValue);
            TextBoxD.Text = arr[1];
            for (int i = 2; i < arr.Length; i++)
            {
                for (int a = 0; a < CheckBoxListModificarRolFuncionalidades.Items.Count; a++)
                {
                    if (CheckBoxListModificarRolFuncionalidades.Items[a].Text == arr[i].ToString())
                    {
                        CheckBoxListModificarRolFuncionalidades.Items[a].Selected = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

    }
    protected void crearUsuario_Activate(object sender, EventArgs e)
    {
        Button4.Focus();
        try
        {
            DropDownListCrearUsuarioRol.DataSource = Servicio.ObtenerListaRoles();
            DropDownListCrearUsuarioRol.DataBind();
        }
        catch (Exception)
        {
            Errores.Alert(this, "Error de conexión con la base de datos");
        }
    }
    protected void gestionarUsuario_Load(object sender, EventArgs e)
    {
        Button2.Enabled = false;
        Button3.Enabled = false;
        Panel1.Visible = false;
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        RegularExpressionValidator11.Visible = RegularExpressionValidator12.Visible = RegularExpressionValidator21.Visible = RegularExpressionValidator13.Visible = RegularExpressionValidator6.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator4.Visible = RequiredFieldValidator5.Visible = RequiredFieldValidator6.Visible = true;
        RegularExpressionValidator11.Validate(); RegularExpressionValidator12.Validate(); RegularExpressionValidator13.Validate(); RegularExpressionValidator6.Validate(); RegularExpressionValidator21.Validate(); RequiredFieldValidator3.Validate(); RequiredFieldValidator4.Validate(); RequiredFieldValidator5.Validate(); RequiredFieldValidator6.Validate();
        bool valid = RegularExpressionValidator11.IsValid && RegularExpressionValidator12.IsValid && RegularExpressionValidator13.IsValid && RegularExpressionValidator6.IsValid && RegularExpressionValidator21.IsValid && RequiredFieldValidator3.IsValid && RequiredFieldValidator4.IsValid && RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid;
        if (!(valid) && ((DdlImprPin.SelectedValue == "-1")&&(DdlImprTarj.SelectedValue == "-1")))
        {
            RegularExpressionValidator11.Visible = RegularExpressionValidator12.Visible = RegularExpressionValidator13.Visible = RegularExpressionValidator21.Visible = RegularExpressionValidator6.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator4.Visible = RequiredFieldValidator5.Visible = RequiredFieldValidator6.Visible = true;
            Errores.Alert(this, " Entrada de datos no válida ");
            return;        
        }

        RegularExpressionValidator11.Visible = RegularExpressionValidator12.Visible = RegularExpressionValidator13.Visible = RegularExpressionValidator21.Visible = RegularExpressionValidator6.Visible = RequiredFieldValidator3.Visible = RequiredFieldValidator4.Visible = RequiredFieldValidator5.Visible = RequiredFieldValidator6.Visible = true;

        new Errores(this).Confirmar("¿ Está seguro que desea modificar la Configuración de la Banca ?", "ModificarConfiguracion");
    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        TextBox6.Text = DropDownList3.Text + ":" + DropDownList5.Text + ":" + DropDownList6.Text;
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        TextBox8.Text = DropDownList9.Text + ":" + DropDownList8.Text + ":" + DropDownList7.Text;
    }
    protected void gConfiguracion_Activate(object sender, EventArgs e)
    {
        try
        {
            bool creada = Servicio.ExisteConfCreada();

            if (creada == true)
            {
                string[] arrConf = Servicio.ObtenerConfiguracion();
                TextBox6.Text = (Convert.ToDateTime(arrConf[1]).TimeOfDay).ToString();
                TextBox1.Text = (Convert.ToDateTime(arrConf[7]).TimeOfDay).ToString();
                TextBox5.Text = arrConf[0];
                TextBox8.Text = (Convert.ToDateTime(arrConf[6]).TimeOfDay).ToString();
                TextBox19.Text = arrConf[5];
                TextBox14.Text = arrConf[2];
                TextBox7.Text = arrConf[3];
                TextBox11.Text = arrConf[4];
                TextBox2.Text = (Convert.ToDateTime(arrConf[8]).TimeOfDay).ToString();

                bool Error1 = false; bool Error2 = false;
                //////BTPRINTERLISTCTRLLib.PrinterListCtrlClass TempObj = new BTPRINTERLISTCTRLLib.PrinterListCtrlClass();
                //////Error1 = Error2 = TempObj.BtGetPrinterCount() <= 0;
                //////List<string> TempList = new List<string>();
                //////for (short i = 0; i < TempObj.BtGetPrinterCount() && !Error1; i++)
                //////{
                //////    try
                //////    {
                //////        TempList.Add(TempObj.BtGetPrinterName(i));
                //////        Error1 |= TempObj.BtGetPrinterName(i).Equals(arrConf[9]);
                //////        Error2 |= TempObj.BtGetPrinterName(i).Equals(arrConf[10]);
                //////    }
                //////    catch { }
                //////}
                //////if (Error1 || TempList.Count == 0) TempList.Add(arrConf[9]);
                //////if (Error2 || TempList.Count == 1) TempList.Add(arrConf[10]);

                //////string[] TempArray = TempList.ToArray();
                //////DdlImprTarj.DataSource = TempArray;
                //////DdlImprPin.DataSource = TempArray;
                //////DdlImprPin.DataBind(); DdlImprTarj.DataBind();


                //////if (arrConf[9] == "" || arrConf[9] == null)
                //////{
                //////    DdlImprPin.Items.Insert(0, new ListItem("<<Seleccione una Impresora>>", "-1"));
                //////    DdlImprPin.SelectedIndex = 0;
                //////}
                //////else
                //////{
                //////    DdlImprTarj.Items.Remove(arrConf[9]);
                //////    DdlImprPin.SelectedValue = arrConf[9];
                //////}

                //////if (arrConf[10] == "" || arrConf[10] == null)
                //////{
                //////    DdlImprTarj.Items.Insert(0, new ListItem("<<Seleccione una Impresora>>", "-1"));
                //////    DdlImprPin.SelectedIndex = 0;
                //////}
                //////else
                //////{
                //////    DdlImprPin.Items.Remove(arrConf[10]);
                //////    DdlImprTarj.SelectedValue = arrConf[10];
                //////}
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, Errores.FiltrarMensaje(ex.Message));/*"Error de conexión con la base de datos");*/
            MultiView1.ActiveViewIndex = 0;
        }

        
    }

    protected void Button25_Click1(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿ Está seguro que desea restaurar los datos? ", "RestaurarDatos");       
    }
    protected void Button26_Click1(object sender, EventArgs e)
    {
        TextBox1.Text = DropDownList10.Text + ":" + DropDownList11.Text + ":" + DropDownList12.Text;
    }

    protected void RadioButtonListSalvarRestaurarDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList16.Visible = Button25.Visible = Button38.Visible = !(Button30.Visible = Button32.Visible = ((RadioButtonList)sender).SelectedIndex == 0);
        if (DropDownList16.Visible)
        {
            string[] o = Servicio.SalvasRestaurar();
            foreach (string i in o)
            {
                DropDownList16.Items.Add(i);
            }
        }

    }
    protected void RadioButtonListSalvarRestaurarDatos_PreRender(object sender, EventArgs e)
    {
        DropDownList16.Visible = Button25.Visible = Button38.Visible = !(Button30.Visible = Button32.Visible = ((RadioButtonList)sender).SelectedIndex == 0);
    }
    protected void Button30_Click1(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿ Está seguro que desea salvar los datos? ", "SalvarDatos");             
    }
    protected void ListBoxGestionatRolesRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBoxGestionatRolesRoles.SelectedIndex == -1)
        {
            Button15.Enabled = false;
            Button16.Enabled = false;
        }
        try
        {
            Panel2.Visible = true;
            string nombre = Servicio.BuscarRol(ListBoxGestionatRolesRoles.SelectedValue).GetValue(0).ToString();
            string descripcion = Servicio.BuscarRol(ListBoxGestionatRolesRoles.SelectedValue).GetValue(1).ToString();

            string[] arr = Servicio.BuscarRol(ListBoxGestionatRolesRoles.SelectedValue);
            ListBox1ListaFuncionalidades.Items.Clear();
            for (int i = 2; i < arr.Length; i++)
            {
                ListBox1ListaFuncionalidades.Items.Add(arr[i].ToString());
            }
            Label6.Text = nombre;
            Label7.Text = descripcion;
            Button15.Enabled = true;
            Button16.Enabled = true;

        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }
    }

    protected void Button31_Click(object sender, EventArgs e)
    {
        TextBox2.Text = DropDownList13.Text + ":" + DropDownList14.Text + ":" + DropDownList15.Text;
    }
    protected void Button32_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    public bool EliminarUsuario()
    {
        bool eliminado = false;
        try
        {
            string pass = Servicio.BuscarUsuario(LabelGestionarUsuarioUsuario.Text).GetValue(2).ToString();
            string[] usuariosActivos = Servicio.getUsuariActivo();
            if (!Servicio.EliminarUsuario(LabelGestionarUsuarioUsuario.Text.ToLower()))
            {
                Errores.Alert(this, "No se puede eliminar un usuario en sección activa"); return false;
            }
            ListBoxGestionarUsuarioUsuarios.DataSource = Servicio.GetListaUsuarios();
                ListBoxGestionarUsuarioUsuarios.DataBind();
                LabelGestionarUsuarioNombre.Text = "";
                LabelGestionarUsuarioUsuario.Text = "";
                LabelGestionarUsuarioRol.Text = "";
                LabelGestionarUsuarioCarnet.Text = "";
                Errores.Alert(this, "Se eliminó el usuario con éxito");
                eliminado = true;
                MultiView1.ActiveViewIndex = 1;
                Panel1.Visible = false;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

        return eliminado;
    }
    public bool EliminarRol()
    {
        bool eliminado = false;
        try
        {
            string nombre = ListBoxGestionatRolesRoles.SelectedValue;
            if (!Servicio.ExisteUsuarioConRol(nombre) && Servicio.EliminarRol(nombre))
            {
                 ListBoxGestionatRolesRoles.DataSource = Servicio.ObtenerListaRoles();
                 ListBoxGestionatRolesRoles.DataBind();
                 eliminado = true;
                 Errores.Alert(this, "Se eliminó el rol con éxito");
                 MultiView1.ActiveViewIndex = 4;
            }
            else
            {
                Errores.Alert(this, "El rol no puede estar asignado a ningún usuario"); return false;
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

        return eliminado;
    }
    public void ModificarUsuario()
    {
        try
        {

            string clave = "";
            bool encrip = false;
            if (Session["pass1"].ToString() == "")
            {
                clave = Session["passPast"].ToString(); encrip = true; Session["passPast"] = null;
            }
            else
            {
                clave = Session["pass1"].ToString();
                Session["pass1"] = null;
            } 
            
            TextBoxModificarUsuarioUsuario.Text = ListBoxGestionarUsuarioUsuarios.SelectedValue;
            string usuario = TextBoxModificarUsuarioUsuario.Text;
            if (usuario == Servicio.BuscarUsuario(usuario).GetValue(1).ToString() && encrip == false)
            {
                Servicio.ModificarUsuario
                    (
                        TextBoxModificarUsuarioNombre.Text,
                        CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(clave),
                        DropDownListModificarUsuarioRol.SelectedValue,
                        usuario,
                        true,
                        TextBoxModificarUsuarioCarnet.Text
                    );
                Errores.Alert(this, "Se modificó el usuario con éxito");
                TextBoxModificarUsuarioNombre.Text = "";
                TextBoxModificarUsuarioUsuario.Text = "";
                TextBoxModificarUsuarioCarnet.Text = "";
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                if (usuario == Servicio.BuscarUsuario(usuario).GetValue(1).ToString() && encrip == true) 
                {
                    Servicio.ModificarUsuario
                    (
                        TextBoxModificarUsuarioNombre.Text,
                        clave,
                        DropDownListModificarUsuarioRol.SelectedValue,
                        usuario,
                        true,
                        TextBoxModificarUsuarioCarnet.Text
                    );
                    Errores.Alert(this, "Se modificó el usuario con éxito");
                    TextBoxModificarUsuarioNombre.Text = "";
                    TextBoxModificarUsuarioUsuario.Text = "";
                    TextBoxModificarUsuarioCarnet.Text = "";
                    MultiView1.ActiveViewIndex = 1;
                } 
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

    }
    public bool ModificarRol()
    {
        bool success = false;
        if (TextBoxModificarRolNombre.Text != "" || TextBoxD.Text != "")
        {
            try
            {
                if (CheckBoxListModificarRolFuncionalidades.Items.FindByValue("Imprimir Pines").Selected &&
                CheckBoxListModificarRolFuncionalidades.Items.FindByValue("Imprimir Tarjetas").Selected == true)
                {
                    Errores.Alert(this, "No se pueden seleccionar a la vez las funcionalidades: Imprimir Pines e Imprimir Tarjetas");
                    CheckBoxListModificarRolFuncionalidades.Items.FindByValue("Imprimir Pines").Selected = false;
                    CheckBoxListModificarRolFuncionalidades.Items.FindByValue("Imprimir Tarjetas").Selected = false;
                    return false;
                }
                List<string> aux = new List<string>();
                for (int i = 0; i < CheckBoxListModificarRolFuncionalidades.Items.Count; i++)
                    if (CheckBoxListModificarRolFuncionalidades.Items[i].Selected)
                        aux.Add(CheckBoxListModificarRolFuncionalidades.Items[i].Value.ToString());

                string[] funcionalidades = new string[aux.Count];
                string[] arr = Servicio.BuscarRol(TextBoxModificarRolNombre.Text);
                for (int i = 0; i < aux.Count; i++)
                {
                    funcionalidades[i] = aux[i].ToString();
                }
                if(Servicio.ExisteRolConNombre(TextBoxModificarRolNombre.Text))
                {
                    if (Servicio.ModificarRol(TextBoxModificarRolNombre.Text, TextBoxD.Text, funcionalidades))
                    {
                        Errores.Alert(this, "Se modificó el rol con éxito");
                        success = true;
                        TextBoxModificarRolNombre.Text = "";
                        TextBoxD.Text = "";
                        MultiView1.ActiveViewIndex = 4;
                    }
                    else
                    {
                        Errores.Alert(this, "No pueden existir dos roles con las mismas funcionalidades"); return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
            }
        }
        else
        {
            MultiView1.ActiveViewIndex = 4; return false;
        }

        return success;
    }
    public bool AdicionarUsuario()
    {
        bool creado = false;
        try
        {
            string nombre = TextBoxCrearUsuarioNombre.Text;
            string usuario = TextBoxCrearUsuarioUsuario.Text;
            string clave = Session["pass"].ToString();
            Session["pass"] = null;
            string rol = DropDownListCrearUsuarioRol.SelectedValue;
            string carnet = TextBoxCrearUsuarioCarnet.Text;
            if (Servicio.BuscarUsuario(usuario) == null)
            {
                Servicio.AdicionarUsuario(nombre,  CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(clave), rol, usuario, true,carnet);
                Errores.Alert(this, "Se creó el usuario con éxito");
                creado = true;
                MultiView1.ActiveViewIndex = 1;
                TextBoxCrearUsuarioNombre.Text = "";
                TextBoxCrearUsuarioUsuario.Text = "";
                TextBoxCrearUsuarioCarnet.Text = "";
            }
            else
            {
                if ((Servicio.BuscarUsuario(usuario).GetValue(1).ToString() != usuario) ||(Servicio.BuscarUsuario(usuario).GetValue(5).ToString() != carnet))
                {
                    Servicio.AdicionarUsuario(nombre, CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(clave), rol, usuario, false,carnet);
                    Errores.Alert(this, "Se creó el usuario con éxito");
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    Errores.Alert(this, "Ya existe un usuario con ese nombre ó carnet de identidad");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

        return creado;
    }
    public bool AdicionarRol()
    {
        bool creado = false;
        try
        {

            for (int i = 0; i < CheckBoxListCrearRolFuncionalidades.Items.Count; i++)
            {
                if (
                  (CheckBoxListCrearRolFuncionalidades.Items[i].Text == "Imprimir Pines") &&
                  (CheckBoxListCrearRolFuncionalidades.Items[i].Selected) &&
                  (CheckBoxListCrearRolFuncionalidades.Items[i + 1].Text == "Imprimir Tarjetas") &&
                  (CheckBoxListCrearRolFuncionalidades.Items[i + 1].Selected)
                  )
                {
                    Errores.Alert(this, "No se pueden seleccionar a la vez las funcionalidades: Imprimir Pines e Imprimir Tarjetas");
                    CheckBoxListCrearRolFuncionalidades.Items[i].Selected = false;
                    CheckBoxListCrearRolFuncionalidades.Items[i + 1].Selected = false;
                    return false;
                }
            }
            int cant = 0;
            List<string> aux = new List<string>();
            for (int i = 0; i < CheckBoxListCrearRolFuncionalidades.Items.Count; i++)
            {

                if (CheckBoxListCrearRolFuncionalidades.Items[i].Selected)
                {
                    cant++;
                    aux.Add(CheckBoxListCrearRolFuncionalidades.Items[i].Value.ToString());
                }
            }
            string[] funcionalidades = new string[cant];
            for (int i = 0; i < aux.Count; i++)
            {
                funcionalidades[i] = aux[i].ToString();
            }
            bool existeRolF = Servicio.ExisteRolConFuncionalidades(funcionalidades);
            bool existeRolN = Servicio.ExisteRolConNombre(TextBoxCrearRolNombre.Text);
            
            if (existeRolF == true) 
            {
                Errores.Alert(this, "No pueden existir dos roles con las mismas funcionalidades"); return false;
            }
            if (existeRolN == true) 
            {
                Errores.Alert(this, "El rol ya existe"); return false;
            }
                Servicio.AdicionarRol(TextBoxCrearRolNombre.Text, TextBoxCrearRolDescripcion.Text, funcionalidades);
                creado = true;
                Errores.Alert(this, "Se adicionó el rol con éxito");                
                TextBoxCrearRolNombre.Text = "";
                TextBoxCrearRolDescripcion.Text = "";
                MultiView1.ActiveViewIndex = 4;
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "El siguiente error ha ocurrido: " + ex.Message);
        }

        return creado;
    }
     
    public void ModificarInformacionTb()
    {

        try
        {
            bool accion = Servicio.ModificarInformacionTb(TextBox30.Text, TextBox31.Text, TextBox32.Text, TextBox33.Text, TextBox34.Text,
                                                         TextBox35.Text, TextBox36.Text, TextBox37.Text, TextBox38.Text, TextBox39.Text);

            if (accion == true)
            {
                TextBox30.Text = "";
                TextBox31.Text = "";
                TextBox32.Text = "";
                TextBox33.Text = "";
                TextBox34.Text = "";
                TextBox35.Text = "";
                TextBox36.Text = "";
                TextBox37.Text = "";
                TextBox38.Text = "";
                TextBox39.Text = "";

                Errores.Alert(this, " Se ha modificado la Informacion de la Banca con éxito ");

                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                Errores.Alert(this, " No se pudo modificar la Informacion de la Banca ");
                MultiView1.ActiveViewIndex = 0;
            }

        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos");
            MultiView1.ActiveViewIndex = 9;
        }
    }

    public void ModificarConfiguracion()
    {
        try
        {
                string direccionServidorBd = TextBox5.Text;
                string usuarioBD = ""; // Raul- Cambiar despues que el texto lo coja del textbox nuevo que hay que agregar en la vista
                string contrasenaBD = ""; // Raul- Cambiar despues que el texto lo coja del textbox nuevo que hay que agregar en la vista

                DateTime HoraConciliaciones = Convert.ToDateTime(TextBox6.Text);
                DateTime TiempoInactividad = Convert.ToDateTime(TextBox1.Text);

                string direccionServidorFtp = TextBox14.Text;
                string UsuarioFtp = TextBox7.Text;
                string ContraseñaFtp = TextBox11.Text;
                string direccionSalvaBd = TextBox19.Text;
                DateTime horaInicioPeticiones = Convert.ToDateTime(TextBox8.Text);
                DateTime horaSalva = Convert.ToDateTime(TextBox2.Text);
                string imprPin = ((DdlImprPin.SelectedValue != "-1") ||(DdlImprPin.SelectedValue != "0"))? DdlImprPin.SelectedValue: "";
                string imprTarj = (DdlImprTarj.SelectedValue != "-1" || (DdlImprTarj.SelectedValue != "0")) ? DdlImprTarj.SelectedValue : "";


                //bool accion = Servicio.ModificarConfiguracion(direccionServidorBd, HoraConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, TiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj);

                bool accion = Servicio.ModificarConfiguracion(direccionServidorBd,usuarioBD,contrasenaBD, HoraConciliaciones, direccionServidorFtp, UsuarioFtp, ContraseñaFtp, TiempoInactividad, direccionSalvaBd, horaInicioPeticiones, horaSalva, imprPin, imprTarj);// Raul
             
            if (accion)
                {
                    
                    TextBox6.Text = "";
                    TextBox1.Text = "";
                    TextBox5.Text = "";
                    TextBox8.Text = "";
                    TextBox19.Text = "";
                    TextBox2.Text = "";
                    TextBox14.Text = "";
                    TextBox7.Text = "";
                    TextBox11.Text = "";

                    Errores.Alert(this, " Se ha modificado la Configuración de la Banca con éxito ");

                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    Errores.Alert(this, " No se pudo modificar la Configuración de la Banca ");
                    MultiView1.ActiveViewIndex = 7;

                }
            }          
        
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos");
        }

    }
    protected void Button13_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 10;
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        new Errores(this).Confirmar("¿ Está seguro que desea eliminar las notificaciones seleccionadas ?", "EliminarNotificacion");

    }

    protected void MostrarNotificaciones_Activate(object sender, EventArgs e)
    {

        Label1.Text = Convert.ToString(GridView1.Rows.Count);
        GridView1.DataBind();
        //Button19.Enabled = false;
        //try
        //{
        //    CheckBoxList1.Items.Clear();

        //    // Servicio.CargarNotificacionesBD();

        //    string[][] listaNotificaciones = Servicio.ObtenerListaNotificaciones();

        //    if (listaNotificaciones.Length > 0)
        //    {
        //        for (int i = 0; i < listaNotificaciones[1].Length; i++)
        //        {
        //            string mensaje = " ";
        //            mensaje = mensaje + "[ " + listaNotificaciones[3][i].ToString() + " ] : ";
        //            mensaje = mensaje + listaNotificaciones[1][i].ToString();
        //            CheckBoxList1.Items.Add(mensaje);

        //        }

        //        Label1.Text = listaNotificaciones[1].Length.ToString();

        //    }
        //    else
        //    {
        //        Errores.Alert(this, "  No existen notificaciones.  ");
        //        MultiView1.ActiveViewIndex = 0;
        //    }

        //}
        //catch (Exception ex)
        //{

        //    Errores.Alert(this, "Error de conexión con la base de datos");
        //}
    }
    public void RestaurarDatos()
    {
        try
        {
            string direc = Servicio.ObtenerConfiguracion()[5];
            string select = DropDownList16.SelectedValue;
            Servicio.RestaurarDatos(direc + select);        
            Rest = new Thread(new ThreadStart(RestaurarThread));
            Rest.Start();
            Rest.Join();
            Errores.Alert(this, Aux);
            Aux = "";
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos");
        }
    }


    public void SalvarDatos()
    {
        try
        {
            Servicio.SalvarDatos();
            Salv = new Thread(new ThreadStart(SalvarThread));
            Salv.Start();
            Salv.Join();
            Errores.Alert(this, Aux);
            Aux = "";
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error de conexión con la base de datos" + ex.Message);
        }
    }

    public void EliminarNotificacion()
    {
        //List<int> posnotEliminar = new List<int>();

        //for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        //{
        //    if (CheckBoxList1.Items[i].Selected == true)
        //    {
        //        posnotEliminar.Add(i);
        //    }
        //}
        //try
        //{
        //    string[][] listaIDdelasNotificaciones = Servicio.ObtenerListaNotificaciones();

        //    List<int> listaIdNotificaciones = new List<int>();

        //    for (int n = 0; n < posnotEliminar.Count; n++)
        //    {
        //        int tmpPos = posnotEliminar[n];
        //        listaIdNotificaciones.Add(int.Parse(listaIDdelasNotificaciones[0][tmpPos]));
        //    }

        //    for (int i = 0; i < listaIdNotificaciones.Count; i++)
        //    {
        //        Servicio.EliminarNotificacion(listaIdNotificaciones[i]);

        //    }
        //    Errores.Alert(this, "Las notificaciones seleccionadas se eliminaron correctamente");
        //    CheckBoxList1.Items.Clear();
        //    string[][] listaNotificaciones = Servicio.ObtenerListaNotificaciones();
        //    for (int i = 0; i < listaNotificaciones[1].Length; i++)
        //    {
        //        CheckBoxList1.Items.Add(listaNotificaciones[1][i].ToString());
        //    }

        //    Label1.Text = listaNotificaciones[1].Length.ToString();
        //}
        //catch (Exception ex)
        //{
        //    Errores.Alert(this, " Error de conexión con la base de datos ");
        //}
    }
    protected void Button13_Click2(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }

    //******************************************************************
    protected void RestaurarThread()
    {
        try
        {
            while (Aux == "")
            {
                Thread.Sleep(2 * 1000);
                Aux = Servicio.InformacionMantenimiento("R");
            }
        }
        catch (Exception)
        {
            throw; 
        }
        finally
        {
            Rest.Abort();
        }        
    }



    string Aux = ""; // esta es global 


    protected void SalvarThread()
    {
        try
        {
            while (Aux == "")
            {
                Thread.Sleep(2 * 1000);
                Aux = Servicio.InformacionMantenimiento("BK");

            }
        }
        catch (Exception)
        {

            throw;
        }

        finally
        {
            Salv.Abort();
        }
    }

    //protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (CheckBoxList1.SelectedIndex != -1)
    //    {
    //        Button19.Enabled = Button28.Enabled = true;
    //    }
    //    else
    //        Button19.Enabled = Button28.Enabled = false;
    //}
    protected void DdlImprPin_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TempValue = DdlImprTarj.SelectedValue;
        DdlImprTarj.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
        DdlImprTarj.DataBind();
        DdlImprTarj.Items.Remove(DdlImprPin.SelectedItem.Text);

        if (DdlImprPin.Items[0].Value == "-1")
            DdlImprPin.Items.RemoveAt(0);
        if (TempValue == "-1")
            DdlImprTarj.Items.Insert(0, new ListItem("<<Seleccione una Impresora>>", "-1"));
            
        DdlImprTarj.SelectedValue = TempValue;

    }

    protected void DdlImprTarj_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TempValue = DdlImprPin.SelectedValue;
        DdlImprPin.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
        DdlImprPin.DataBind();
        DdlImprPin.Items.Remove(DdlImprTarj.SelectedItem.Text);

        if (DdlImprTarj.Items[0].Value == "-1")
            DdlImprTarj.Items.RemoveAt(0);
        if (TempValue == "-1")
            DdlImprPin.Items.Insert(0, new ListItem("<<Seleccione una Impresora>>", "-1"));
           
        DdlImprPin.SelectedValue = TempValue;
    }
    protected void Button27_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        //{
        //    if (!CheckBoxList1.Items[i].Selected)
        //    {
        //        CheckBoxList1.Items[i].Selected = true;
        //    }
        //}
        //if (CheckBoxList1.SelectedIndex != -1)
        //{
        //    Button19.Enabled = Button28.Enabled = true;
        //}
    }
    protected void Button28_Click1(object sender, EventArgs e)
    {
        //for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        //{
        //    if (CheckBoxList1.Items[i].Selected)
        //    {
        //        CheckBoxList1.Items[i].Selected = false;
        //    }
        //}

        //if (CheckBoxList1.SelectedIndex == -1)
        //{
        //    Button19.Enabled = Button28.Enabled = false;
        //}
    }
    protected void Button33_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button29_Click1(object sender, EventArgs e)
    {
        string Report = DropDownList1.SelectedValue;
        Response.Redirect("MyNewPaginasReportes\\ReporteTarjetas.aspx?Report="+Report);
    }
   
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label1.Text = Convert.ToString(GridView1.Rows.Count);
    }
    protected void Button34_Click1(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void Button35_Click1(object sender, EventArgs e)
    {
        string aux = GridView2.SelectedRow.Cells[0].Text;
        int anno = Convert.ToInt32(aux);

        bool satisfecho;
        satisfecho=Servicio.SalvarTransacciones(anno);
        if (satisfecho==true)
        {
            Errores.Alert(this, "Las Transacciones del año seleccionado se eliminaron correctamente");
        }
        else
	{
            Errores.Alert(this, "La salva de las Transacciones no se ha realizado");
	}
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        Button40.Focus();
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView3.SelectedIndex != -1)
        {
            Button37.Enabled = true;
        }
        
    }
    protected void View2_Activate(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        GridView3.SelectedIndex = -1;
        GridView3.DataBind();
        Button37.Enabled = false;
        Label19.Visible = false;
        Label19.Text = "";
    }
    protected void Button37_Click1(object sender, EventArgs e)
    {
        string usuario = GridView3.SelectedRow.Cells[0].Text.ToString();

        if (Servicio.Desbloqueo_User(usuario))
        {

            TextBox3.Text = "";
            GridView3.SelectedIndex = -1;
            GridView3.DataBind();
            Button37.Enabled = false;

            Label19.Visible = true;
            Label19.Text = "Usuario desbloqueado";
        }

        else
        {
            Label19.Visible = true;
            Label19.Text = "Error, inténtelo nuevamente";
        }
    }
    protected void Button39_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        GridView3.SelectedIndex = -1;
        GridView3.DataBind();
        Button37.Enabled = false;
        Label19.Visible = false;
        Label19.Text = "";

        MultiView1.ActiveViewIndex = 0;
        
    }
    protected void UpdateFecContButton_Click(object sender, EventArgs e)
    {
        try
        {
            TeleBancaWS.TeleBancaWS nuevo = new TeleBancaWS.TeleBancaWS();

            DateTime fecha = (DateTime)ASPxDateEdit1.Value;
            nuevo.Modificar_Fecha_Contable_BD(fecha);

            Errores.Alert(this, "Fecha Contable Modificada con exito en la BD de Telebanca");
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error a la hora de actualizar la Fecha Contable en la BD de Telebanca. Error: "+ex.Message);
            throw;
        }
    }
}
