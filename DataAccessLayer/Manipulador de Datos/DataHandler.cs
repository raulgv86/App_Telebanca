using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Timers;
using System.IO;
using System.Net;
using DataAccessLayer.WSBanco;
using Microsoft.SqlServer.Server;


namespace DataAccessLayer
{


    public partial class DataHandler
    {

        string cString = global::DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString3;
        public static HttpContext MyCurrent;

        #region CONECCIONES A PALO

        public bool IncertarMatricesEncriptadasBD(List<Matriz> listaMatricesEncriptadas)
        {

            DataSet1.TLB_MatrizDataTable TempTable = new DataSet1.TLB_MatrizDataTable();
            int UltimoID = (int)new DataSet1TableAdapters.TLB_MatrizTableAdapter().MayorID();

                for (int i = 0; i < listaMatricesEncriptadas.Count; i++)
                {
                    DataSet1.TLB_MatrizRow TempRow = TempTable.NewTLB_MatrizRow();

                    TempRow.Id_Matriz = listaMatricesEncriptadas[i].ID + UltimoID;
                    TempRow.C1 = listaMatricesEncriptadas[i].Filas[0];
                    TempRow.C2 = listaMatricesEncriptadas[i].Filas[1];
                    TempRow.C3 = listaMatricesEncriptadas[i].Filas[2];
                    TempRow.C4 = listaMatricesEncriptadas[i].Filas[3];
                    TempRow.C5 = listaMatricesEncriptadas[i].Filas[4];
                    TempRow.C6 = listaMatricesEncriptadas[i].Filas[5];
                    TempRow.C7 = listaMatricesEncriptadas[i].Filas[6];
                    TempRow.C8 = listaMatricesEncriptadas[i].Filas[7];
                    TempRow.C9 = listaMatricesEncriptadas[i].Filas[8];
                    TempRow.C10 = listaMatricesEncriptadas[i].Filas[9];

                    TempTable.AddTLB_MatrizRow(TempRow);
                }
                new DataSet1TableAdapters.TLB_MatrizTableAdapter().Update(TempTable);
            
            return true;
        }

        public bool HacerBackUp(string direccion)
        {


            SqlConnection myConnection = new SqlConnection(cString);

            SqlCommand updateJobStepUpCommand = new SqlCommand(

            " USE msdb " +

            " EXEC dbo.sp_update_jobstep " +

            " @job_name = N'HacerBackUp', " +

            " @step_id = 2, " + // si cambia el id del paso hay que cambiar aquí

            " @command = N\'declare @cad nvarchar(99)" +

            " set @cad =\"" + direccion + "\" + Replace(convert(nvarchar(80),getdate()),\":\",\"y\")+\".bak\"" +

            " BACKUP DATABASE TeleBanca TO DISK = @cad WITH FORMAT\'"

            , myConnection);


            SqlCommand execCommand = new SqlCommand(

            " USE msdb " +

            " EXEC dbo.sp_start_job " +

            " @job_name = N'HacerBackUp'; "

            , myConnection);

            try
            {
                myConnection.Open();
                updateJobStepUpCommand.ExecuteNonQuery();
                execCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                ///*escribir en el log*/

                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "HacerBackUp \n";
                //    string nombre_proyecto = "(DataAccessLayer): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                //}


                throw new Exception("Error: ", e);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public bool RestaurarBaseDato(string direccion)
        {
            //The system administrator restoring the full backup must be the only person currently using the database to be restored.

            SqlConnection myConnection = new SqlConnection(cString);

            SqlCommand updateJobStepUpCommand = new SqlCommand(

            " USE msdb" +

            " EXEC dbo.sp_update_jobstep" +

            " @job_name = N'RestaurarTeleBanca'," +

            " @step_id = 2, " +

            " @command = \"RESTORE DATABASE TeleBanca FROM DISK = N\'" + direccion + "\'" +

            " WITH RESTART, REPLACE\""



             //El REPLACE no es conveniente si hay otra BD con el mismo nombre

            , myConnection);

            SqlCommand execCommand = new SqlCommand(

            " USE msdb " +

            " EXEC dbo.sp_start_job " +

            " @job_name = N'RestaurarTeleBanca'; "

            , myConnection);

            try
            {
                myConnection.Open();
                updateJobStepUpCommand.ExecuteNonQuery();
                execCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public bool ActualizarScheduleBackUp(DateTime fechaTime)
        {

            string s = fechaTime.TimeOfDay.Hours.ToString() +

            fechaTime.TimeOfDay.Minutes.ToString() +

            fechaTime.TimeOfDay.Seconds.ToString();

            int time = Convert.ToInt32(s);

            SqlConnection myConnection = new SqlConnection(cString);

            SqlCommand updateJobScheduleCommand = new SqlCommand(

            " USE msdb " +

            " EXEC dbo.sp_update_schedule " +

            " @name = N'HacerBackUpSchedule', " +

            " @freq_type = 4, " + // frecuencia diaria

            " @freq_subday_type = 1, " + //En el tiempo especificado

            " @active_start_date = 19900101, " + //esta activa la fecha de inicio

            " @active_end_date = 99991231, " + // no tiene fin

            " @active_start_time = " + time + ";"

            , myConnection);

            try
            {
                myConnection.Open();
                updateJobScheduleCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
            finally
            {
                myConnection.Close();
            }
        }

        #endregion

        #region VERIFICAR CONEXION BD
        public bool VerificarConexion() // Verifica la Conexion con la BD......
        {
            return true;
        }
        #endregion

        #region MODULO ADMINISTRACION
        public bool Login(string usuario, string pass)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter login = new DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            return (int)login.Login(usuario.ToLower(), pass) == 1;
        }
        /*******************************************************************************************************/
        public UsuarioPersistente BuscarUsuario(string pUsuario)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            //DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataSet1TableAdapters.TLB_RolesTableAdapter();
            //DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter funcionalidad = new DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();
            //DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter RolFuncionalidad = new DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter();

            DataSet1 ds1 = new DataSet1();
            //funcionalidad.Fill(ds1.TLB_Funcionalidades);
            //rol.Fill(ds1.TLB_Roles);
            // RolFuncionalidad.Fill(ds1.TLB_Roles_TLB_Funcionalidades);
            ds1.Merge(usuario.BuscarUsuario(pUsuario));

            if (ds1.TLB_Usuario.Rows.Count != 1)
                return null;

            UsuarioPersistente result = new UsuarioPersistente();
            result.Nombre = ds1.TLB_Usuario[0].nombre;
            result.Contrasena = ds1.TLB_Usuario[0].contrasena;
            result.Usuario = ds1.TLB_Usuario[0].usuario;
            result.CarnetIdentidad = ds1.TLB_Usuario[0].CI;
            result.Rol = new RolPersistente();
            // result.Rol.Nombre = ds1.TLB_Usuario[0].TLB_RolesRow.Id_Rol;
            result.Rol.Nombre = ds1.TLB_Usuario[0].Id_Rol;
            //*********//
            //DataSet1.TLB_Roles_TLB_FuncionalidadesRow[] funcionalidades = ds1.TLB_Usuario[0].TLB_RolesRow.GetTLB_Roles_TLB_FuncionalidadesRows();
            DataSet Funcionalidades = FuncionalidadesUsuario(result.Rol.Nombre);
            //foreach (DataSet1.TLB_Roles_TLB_FuncionalidadesRow i in funcionalidades)
            //{
            //    result.Rol.Funcionalidades.Add(i.TLB_FuncionalidadesRow.Funcionalidad);
            //    try { result.Rol.NombreMenu.Add(i.TLB_FuncionalidadesRow.NombreEnMenu); }
            //    catch { result.Rol.NombreMenu.Add(""); }
            //    try { result.Rol.ValorMenu.Add(i.TLB_FuncionalidadesRow.ValorEnMenu); }
            //    catch { result.Rol.ValorMenu.Add(0); }
            //    result.Rol.Modulo.Add(i.TLB_FuncionalidadesRow.Modulo);
            //}
            foreach (DataRow i in Funcionalidades.Tables[0].Rows)
            {
                result.Rol.Funcionalidades.Add(i[0].ToString());
                try { result.Rol.NombreMenu.Add(i[1].ToString()); }
                catch { result.Rol.NombreMenu.Add(""); }
                try { result.Rol.ValorMenu.Add(Convert.ToInt32(i[2])); }
                catch { result.Rol.ValorMenu.Add(0); }
                result.Rol.Modulo.Add(Convert.ToInt32(i[3]));
            }
            return result;
        }

        //**********************************Metodo para buscar las funcionalidades del usuario
        public DataSet FuncionalidadesUsuario(string id_rol)
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("sp_FuncionalidadesUsuario", myConection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@Usuario", id_rol);
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_FuncionalidadesUsuario");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }
        //***********************************
        /*******************************************************************************************************/
        public bool EliminarUsuario(string pUsuario)
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1 ds1 = new DataSet1();

            rol.Fill(ds1.TLB_Roles);
            ds1.Merge(usuario.BuscarUsuario(pUsuario));

            ds1.TLB_Usuario[0].Activo = false;
            ds1.TLB_Usuario[0].Id_Rol = null;
            return usuario.Update(ds1) > 0;
        }
        /*******************************************************************************************************/
        public UsuarioPersistente GetUsuario(string pUsuario, string pContrasena)
        {
            UsuarioPersistente result = BuscarUsuario(pUsuario);
            if (result.Contrasena == pContrasena)
                return result;
            return null;
        }
        /*******************************************************************************************************/
        public bool AgregarUsuario(UsuarioPersistente usuarioP)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1TableAdapters.TLB_RolesTableAdapter roles = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1 ds1 = new DataSet1();

            roles.Fill(ds1.TLB_Roles);
            usuario.Fill(ds1.TLB_Usuario);
            if (ds1.TLB_Usuario.FindByusuario(usuarioP.Nombre) == null)
            {
                DataSet1.TLB_RolesRow tmp = ds1.TLB_Roles.FindById_Rol(usuarioP.Rol.Nombre);
                ds1.TLB_Usuario.AddTLB_UsuarioRow(usuarioP.Usuario, usuarioP.Contrasena, usuarioP.Nombre, usuarioP.CarnetIdentidad, tmp, true);
                usuario.Update(ds1.TLB_Usuario);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public bool ModificarUsuario(UsuarioPersistente usuarioP)
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter roles = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();

            bool result = false;

            DataSet1 ds1 = new DataSet1();
            roles.Fill(ds1.TLB_Roles);
            usuario.Fill(ds1.TLB_Usuario);

            DataSet1.TLB_UsuarioRow tmp = ds1.TLB_Usuario.FindByusuario(usuarioP.Usuario);
            if (tmp != null)
            {
                tmp.nombre = usuarioP.Nombre;
                tmp.contrasena = usuarioP.Contrasena;
                tmp.TLB_RolesRow = ds1.TLB_Roles.FindById_Rol(usuarioP.Rol.Nombre);
                tmp.CI = usuarioP.CarnetIdentidad;
                usuario.Update(ds1.TLB_Usuario);
                result = true;
            }
            return result;
        }
        /*******************************************************************************************************/
        public List<string> GetListaUsuarios()
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1 ds1 = new DataSet1();

            usuario.Fill(ds1.TLB_Usuario);
            List<string> result = new List<string>();

            foreach (DataSet1.TLB_UsuarioRow i in ds1.TLB_Usuario)
                result.Add(i.usuario.ToString());
            return result;
        }
        /*******************************************************************************************************/
        public bool ExisteRol(string rolP)
        {
            DataSet1.TLB_RolesDataTable roldt = new DataSet1TableAdapters.TLB_RolesTableAdapter().GetData();
            if (roldt.FindById_Rol(rolP) != null)
                return true;
            return false;
        }
        /*******************************************************************************************************/
        public bool ExisteUsuarioConRol(string rolP)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1 ds1 = new DataSet1();
            usuario.Fill(ds1.TLB_Usuario);
            return (int)usuario.ExisteUsuarioRol(rolP) > 0;
        }
        /*******************************************************************************************************/
        public bool EliminarRol(string rolP)
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter rolfunc = new DataAccessLayer.DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter();
            DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter func = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();
            DataSet1TableAdapters.TLB_NotificacionTableAdapter notif = new DataAccessLayer.DataSet1TableAdapters.TLB_NotificacionTableAdapter();

            DataSet1 ds1 = new DataSet1();
            rol.Fill(ds1.TLB_Roles);
            func.Fill(ds1.TLB_Funcionalidades);
            rolfunc.Fill(ds1.TLB_Roles_TLB_Funcionalidades);
            notif.Fill(ds1.TLB_Notificacion);

            if (!ExisteUsuarioConRol(rolP))
            {
                DataSet1.TLB_RolesRow temprow = ds1.TLB_Roles.FindById_Rol(rolP);
                if (temprow != null)
                {
                    temprow.Delete();
                    rol.Update(ds1.TLB_Roles);
                    return true;
                }
            }
            //else 
            //throw new Exception("Error... Verifique que no existan usuarios con el rol seleccionado");
            return false;
        }
        /*******************************************************************************************************/
        public bool AgregarRol(RolPersistente rolP)
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter funcionalidad = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();
            DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter rolFunc = new DataAccessLayer.DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter();

            DataSet1 ds1 = new DataSet1();
            funcionalidad.Fill(ds1.TLB_Funcionalidades);
            rol.Fill(ds1.TLB_Roles);
            rolFunc.Fill(ds1.TLB_Roles_TLB_Funcionalidades);

            bool result = false;

            if (ds1.TLB_Roles.FindById_Rol(rolP.Nombre) == null)
            {
                ds1.TLB_Roles.AddTLB_RolesRow(rolP.Nombre, rolP.Descripcion);
                foreach (string i in rolP.Funcionalidades)
                {
                    DataSet1.TLB_Roles_TLB_FuncionalidadesRow TempRF = ds1.TLB_Roles_TLB_Funcionalidades.NewTLB_Roles_TLB_FuncionalidadesRow();
                    TempRF.Id_Rol = rolP.Nombre;
                    TempRF.Funcionalidad = i;
                    ds1.TLB_Roles_TLB_Funcionalidades.AddTLB_Roles_TLB_FuncionalidadesRow(TempRF);
                }
                rol.Update(ds1.TLB_Roles);
                rolFunc.Update(ds1.TLB_Roles_TLB_Funcionalidades);
                result = true;
            }
            return result;
        }
        /*******************************************************************************************************/
        public bool ModificarRol(RolPersistente rolP)
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter funcionalidad = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();
            DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter rolFunc = new DataAccessLayer.DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter();

            DataSet1 ds1 = new DataSet1();
            funcionalidad.Fill(ds1.TLB_Funcionalidades);
            rol.Fill(ds1.TLB_Roles);
            rolFunc.Fill(ds1.TLB_Roles_TLB_Funcionalidades);

            bool result = false;

            DataSet1.TLB_RolesRow temp = ds1.TLB_Roles.FindById_Rol(rolP.Nombre);

            if (temp != null)
            {
                temp.Descripcion = rolP.Descripcion;
                foreach (DataSet1.TLB_Roles_TLB_FuncionalidadesRow i in temp.GetTLB_Roles_TLB_FuncionalidadesRows())
                    i.Delete();

                foreach (string i in rolP.Funcionalidades)
                {
                    DataSet1.TLB_Roles_TLB_FuncionalidadesRow TempRF = ds1.TLB_Roles_TLB_Funcionalidades.NewTLB_Roles_TLB_FuncionalidadesRow();
                    TempRF.Id_Rol = rolP.Nombre;
                    TempRF.Funcionalidad = i;
                    ds1.TLB_Roles_TLB_Funcionalidades.AddTLB_Roles_TLB_FuncionalidadesRow(TempRF);
                }
                rol.Update(ds1.TLB_Roles);
                rolFunc.Update(ds1.TLB_Roles_TLB_Funcionalidades);

                result = true;
            }
            return result;
        }
        /*******************************************************************************************************/
        public RolPersistente BuscarRol(string nombreRol)
        {
            DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter rolfunc = new DataAccessLayer.DataSet1TableAdapters.TLB_Roles_TLB_FuncionalidadesTableAdapter();
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();
            DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter AdptFunc = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();


            DataSet1 ds1 = new DataSet1();
            rol.Fill(ds1.TLB_Roles);
            AdptFunc.Fill(ds1.TLB_Funcionalidades);
            rolfunc.Fill(ds1.TLB_Roles_TLB_Funcionalidades);

            RolPersistente result = new RolPersistente();
            DataSet1.TLB_RolesRow rolrow = ds1.TLB_Roles.FindById_Rol(nombreRol);
            if (rolrow != null)
            {
                result.Nombre = rolrow.Id_Rol;
                result.Descripcion = rolrow.Descripcion;
                DataSet1.TLB_Roles_TLB_FuncionalidadesRow[] funcionalidades = rolrow.GetTLB_Roles_TLB_FuncionalidadesRows();
                foreach (DataSet1.TLB_Roles_TLB_FuncionalidadesRow i in funcionalidades)
                {
                    result.Funcionalidades.Add(i.TLB_FuncionalidadesRow.Funcionalidad);
                    try { result.NombreMenu.Add(i.TLB_FuncionalidadesRow.NombreEnMenu); }
                    catch { result.NombreMenu.Add(""); }
                    try { result.ValorMenu.Add(i.TLB_FuncionalidadesRow.ValorEnMenu); }
                    catch { result.ValorMenu.Add(0); }
                    result.Modulo.Add(i.TLB_FuncionalidadesRow.Modulo);
                }
                return result;
            }
            return result;
        }
        /*******************************************************************************************************/
        public List<RolPersistente> ObtenerListaRoles()
        {
            DataSet1TableAdapters.TLB_RolesTableAdapter rol = new DataAccessLayer.DataSet1TableAdapters.TLB_RolesTableAdapter();

            DataSet1 ds1 = new DataSet1();
            rol.Fill(ds1.TLB_Roles);

            List<RolPersistente> result = new List<RolPersistente>();

            foreach (DataSet1.TLB_RolesRow i in ds1.TLB_Roles)
                result.Add(BuscarRol(i.Id_Rol));
            return result;
        }
        /*******************************************************************************************************/
        public List<string> ObtenerListaFuncionalidades()
        {
            DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter funcionalidades = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();

            funcionalidades.Fill(ds1.TLB_Funcionalidades);
            List<string> result = new List<string>();
            foreach (DataSet1.TLB_FuncionalidadesRow i in ds1.TLB_Funcionalidades)
                result.Add(i.Funcionalidad.ToString());
            return result;
        }
        /*******************************************************************************************************/
        /*******************************************************************************************************/

        public bool ModificarClave(string usuario, string nuevacontrasenna)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter user = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1 ds1 = new DataSet1();

            user.Fill(ds1.TLB_Usuario);
            DataSet1.TLB_UsuarioRow usuarioRow = ds1.TLB_Usuario.FindByusuario(usuario);

           

            if (usuarioRow != null)
            {
                DataTable lista = new DataTable();

                lista = new DataSet1TableAdapters.TLB_Historico_ContrasenaTableAdapterTableAdapter().sp_lista_contrasennas(usuario);

                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    if (lista.Rows[i][0].ToString()==nuevacontrasenna)
                    {
                        return false;
                    }
                }
                
                    usuarioRow.contrasena = nuevacontrasenna;
                    user.Update(ds1.TLB_Usuario);
                    return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public bool ExisteInfCreada()
        {
            DataSet1.TLB_BancaTelefonicaDataTable bancadt = new DataSet1TableAdapters.TLB_BancaTelefonicaTableAdapter().GetData();
            return bancadt.Count == 1;
        }
        /*******************************************************************************************************/
        public InformacionTb GetInformacionTb()
        {
            DataSet1TableAdapters.TLB_BancaTelefonicaTableAdapter bancaTelefonica = new DataAccessLayer.DataSet1TableAdapters.TLB_BancaTelefonicaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            bancaTelefonica.Fill(ds1.TLB_BancaTelefonica);

            InformacionTb informacionTb = new InformacionTb();

            informacionTb.GetSetNombreTb = ds1.TLB_BancaTelefonica[0].nombre;
            informacionTb.GetSetDireccionTb = ds1.TLB_BancaTelefonica[0].Direccion;
            informacionTb.GetSetTelefonoTb = ds1.TLB_BancaTelefonica[0].Telefono;
            informacionTb.GetSetFaxTb = ds1.TLB_BancaTelefonica[0].Fax;
            informacionTb.GetSetUrlSitioWeb = ds1.TLB_BancaTelefonica[0].SitioWeb;
            informacionTb.GetSetLogoTipo = ds1.TLB_BancaTelefonica[0].LogoTipo;
            informacionTb.GetSetNombreDirector = ds1.TLB_BancaTelefonica[0].NombreDirector;
            informacionTb.GetSetCorreoElectronico = ds1.TLB_BancaTelefonica[0].CorreoElectr;
            informacionTb.GetSetDescripcionServicios = ds1.TLB_BancaTelefonica[0].DescripServicios;
            informacionTb.GetSetOrganismoTb = ds1.TLB_BancaTelefonica[0].Organismo;

            return informacionTb;
        }
        /*******************************************************************************************************/
        public bool ModificarInformacionTb(InformacionTb informacionTb)
        {
            DataSet1TableAdapters.TLB_BancaTelefonicaTableAdapter bancaTelefonica = new DataAccessLayer.DataSet1TableAdapters.TLB_BancaTelefonicaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            bancaTelefonica.Fill(ds1.TLB_BancaTelefonica);

            if (ds1.TLB_BancaTelefonica.Count > 0)
                ds1.TLB_BancaTelefonica[0].Delete();
            DataSet1.TLB_BancaTelefonicaRow TempRow = ds1.TLB_BancaTelefonica.NewTLB_BancaTelefonicaRow();

            TempRow.nombre = informacionTb.GetSetNombreTb;
            TempRow.NombreDirector = informacionTb.GetSetNombreDirector;
            TempRow.Organismo = informacionTb.GetSetOrganismoTb;
            TempRow.LogoTipo = informacionTb.GetSetLogoTipo;
            TempRow.Fax = informacionTb.GetSetFaxTb;
            TempRow.Direccion = informacionTb.GetSetDireccionTb;
            TempRow.DescripServicios = informacionTb.GetSetDescripcionServicios;
            TempRow.CorreoElectr = informacionTb.GetSetCorreoElectronico;
            TempRow.SitioWeb = informacionTb.GetSetUrlSitioWeb;
            TempRow.Telefono = informacionTb.GetSetTelefonoTb;

            ds1.TLB_BancaTelefonica.AddTLB_BancaTelefonicaRow(TempRow);
            return bancaTelefonica.Update(ds1.TLB_BancaTelefonica) > 0;
        }
        /*******************************************************************************************************/
        public bool ExisteConfCreada()
        {
            DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter conf = new DataAccessLayer.DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter();
            DataSet1 ds1 = new DataSet1();
            conf.Fill(ds1.TLB_Configuración);

            return ds1.TLB_Configuración.Count > 0;
        }
        /*******************************************************************************************************/
        public bool ModificarConfiguracion(Configuracion Cconf)
        {
            try
            {
                DataSet1.TLB_ConfiguraciónDataTable conf_dt = new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter().GetData();
                if (conf_dt.Rows.Count > 0)
                {
                    DataSet1.TLB_ConfiguraciónRow conf_row = (DataSet1.TLB_ConfiguraciónRow)conf_dt.Rows[0];

                    conf_row.DireccServBD = Cconf.DireccServBD;
                    conf_row.HoraConciliaciones = Cconf.HoraConciliaciones;
                    conf_row.DireccServFTP = Cconf.DireccionServidorFtp;
                    conf_row.UsuarioFTP = Cconf.UsuarioFTP;
                    conf_row.ContraseñaFTP = Cconf.ContraseñaFTP;
                    conf_row.HoraInicioPetic = Cconf.HoraInicioPetic;
                    conf_row.DireccSalvaBD = Cconf.DireccSalvaBD;
                    conf_row.TiempoInactividad = Cconf.TiempoInactividad;
                    conf_row.HoraSalva = Cconf.HoraSalva;
                    conf_row.ImpresoraPin = Cconf.ImpresoraPin;
                    conf_row.ImpresoraTarjeta = Cconf.ImpresoraTarjeta;


                    new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter().Update(conf_row);
                    return true;
                }
                else
                {
                    DataSet1.TLB_ConfiguraciónRow conf_row = conf_dt.NewTLB_ConfiguraciónRow();
                    conf_row.DireccServBD = Cconf.DireccServBD;
                    conf_row.HoraConciliaciones = Cconf.HoraConciliaciones;
                    conf_row.DireccServFTP = Cconf.DireccionServidorFtp;
                    conf_row.UsuarioFTP = Cconf.UsuarioFTP;
                    conf_row.ContraseñaFTP = Cconf.ContraseñaFTP;
                    conf_row.HoraInicioPetic = Cconf.HoraInicioPetic;
                    conf_row.DireccSalvaBD = Cconf.DireccSalvaBD;
                    conf_row.TiempoInactividad = Cconf.TiempoInactividad;
                    conf_row.HoraSalva = Cconf.HoraSalva;
                    conf_row.ImpresoraPin = Cconf.ImpresoraPin;
                    conf_row.ImpresoraTarjeta = Cconf.ImpresoraTarjeta;

                    conf_dt.AddTLB_ConfiguraciónRow(conf_row);
                    new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter().Update(conf_row);
                    return true;
                }

            }
            catch (Exception e)
            {
                GuardarNotificacion("Error de acceso a la BD " + e.Message, "Administrador");
                throw new Exception(e.Message);
            }
        }
        //******************************************************************************************************/
        public List<Notificacion> ObtenerListaNotificaciones()
        {
            try
            {
                List<Notificacion> l_not = new List<Notificacion>();
                DataSet1.TLB_RolesDataTable r_dt = new DataSet1TableAdapters.TLB_RolesTableAdapter().GetData();
                DataSet1.TLB_NotificacionDataTable n_dt = new DataSet1TableAdapters.TLB_NotificacionTableAdapter().GetData();
                foreach (DataSet1.TLB_NotificacionRow i in n_dt)
                {
                    Notificacion notif = new Notificacion();
                    notif.Id_Notificacion = i.Id_Notificacion;
                    notif.Descripcion = i.Descripcion;
                    notif.Id_Rol = i.Id_Rol;
                    notif.Fecha = i.fecha;
                    l_not.Add(notif);
                }
                return l_not;
            }
            catch (Exception e)
            {
                GuardarNotificacion("Error de acceso a la base de datos " + e.Message, "Administrador");
                throw new Exception(e.Message);
            }
        }
        //******************************************************************************************************/
        public bool EliminarNotificacion(int idNotif)
        {
            try
            {
                new DataSet1TableAdapters.TLB_NotificacionTableAdapter().DeleteNotificacion(idNotif);
                return true;
            }
            catch (Exception e)
            {
                GuardarNotificacion("Error de acceso a la base de datos " + e.Message, "Administrador");
                return false;
            }
        }
        //******************************************************************************************************/
        public string InformacionMantenimiento(string tipo)
        {
            try
            {

                DataSet1.TLB_MantenimientoDataTable mantdt = new DataSet1TableAdapters.TLB_MantenimientoTableAdapter().FechaDesc(tipo);
                DataSet1 ds1 = new DataSet1();
                string result = "";
                DataSet1.TLB_MantenimientoRow mantRow = ds1.TLB_Mantenimiento.NewTLB_MantenimientoRow();
                if (mantdt.Rows.Count > 0)
                {
                    mantRow = (DataSet1.TLB_MantenimientoRow)mantdt.Rows[0];
                    result = mantRow.Descripcion.ToString() + " " + mantRow.Fecha.ToString();
                    new DataSet1TableAdapters.TLB_MantenimientoTableAdapter().DeleteMant(tipo);
                    return result;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //******************************************************************************************************/
        #endregion

        #region MODULO SERVICIO DE PAGO

        //****
        public ReporteTransacciones[] ObtenerReporteTransac(DateTime fechaI, DateTime fechaF,string operador, string value, string Reportero)
        {
            try
            {
                List<ReporteTransacciones> listaReporte = new List<ReporteTransacciones>();
                fechaI = fechaI.Date;
                fechaF = fechaF.Date.Add(new TimeSpan(0, 23, 59, 59, 59));
                //string id="";
                //string id1 = "";
                //string idasociado="";
                string informativo = "";
                string bimestre = "";
                int tipomulta = 0;
                string tipomulta1 = "";
                string Infoconcat = "";
                string mon = "";
                if (value == "1")
                {
                    mon = "CUP";
                }
                if (value == "2")
                {
                    mon = "CUC";
                }
                if (value == "12")
                {
                    mon = "CUP(CUC)";
                }
                if (value == "21")
                {
                    mon = "CUC(CUP)";
                }
                DataSet Transacciones = this.RepTransacciones(fechaI, fechaF, operador, value);
                foreach (DataRow row in Transacciones.Tables[0].Rows)
                {
                    ReporteTransacciones repor = new ReporteTransacciones();
                    repor.Moneda = mon;
                    repor.Reportero = Reportero;
                    repor.Nombre = row[0].ToString();
                    repor.NoTarjeta = row[1].ToString();
                    repor.Servicio = row[3].ToString();
                    repor.Operador = row[4].ToString();
                    repor.Fecha = Convert.ToDateTime(row[5]);
                    repor.Importe = float.Parse(row[6].ToString());
                    Infoconcat = row[7].ToString() + "   " + row[9].ToString();
                    if (row[2].ToString() == "05")
                    {
                        informativo = row[10].ToString();
                        bimestre = informativo.Substring(0, 4);
                        Infoconcat = Infoconcat + "  " + bimestre;
                    }
                    if (row[2].ToString() == "04")
                    {
                        informativo = row[10].ToString();
                        tipomulta = informativo.IndexOf("T:");
                        if (tipomulta != -1)
                        {
                            tipomulta1 = informativo.Substring(tipomulta, 3);
                            Infoconcat = Infoconcat + "  " + tipomulta1;
                        }
                    }
                    //Para mostrar la Ruta y Folio del Servicio "Eléctrica" en "Reporte de Transacciones" del Módulo de Pago
                    if (row[2].ToString() == "02")
                    {
                        informativo = row[10].ToString();
                        Infoconcat = Infoconcat + "  " + informativo;
                    }
                    repor.Traza = Infoconcat;

                    listaReporte.Add(repor);
                  
                }

                return listaReporte.ToArray();
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }
        public DataSet RepTransacciones(DateTime fechaI, DateTime fechaF, string oper, string value)
    {

        string fechaIni = fechaI.ToString("yyyy-MM-dd");
        string fechaFin = fechaF.ToString("yyyy-MM-dd");
        //string fechaIni = fechaI.ToString("dd-MM-yyyy");
        //string fechaFin = fechaF.ToString("dd-MM-yyyy");
        string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
        SqlConnection myconection = new SqlConnection(stringConection);
        SqlCommand mycommand = new SqlCommand("sp_Transacciones", myconection);
        mycommand.CommandTimeout = 3000;
        mycommand.CommandType = CommandType.StoredProcedure;
        mycommand.Parameters.AddWithValue("@fechaI", fechaIni);
        mycommand.Parameters.AddWithValue("@fechaF", fechaFin);
        mycommand.Parameters.AddWithValue("@operador", oper);
        mycommand.Parameters.AddWithValue("@value", Convert.ToDecimal(value));
        SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
        DataSet DS = new DataSet();
        try
        {
            adapter.Fill(DS, "Transacciones");
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return DS;
    }

        public DataSet idasociadof(string id)
        {
            DataSet DS = new DataSet();
           // string StringConection = ClassLibraryBancaTelefonica.Properties.Settings.Default.ConnectionString;
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("select * from TLB_DatosTransaccion WHERE (id_Transaccion = '" + id + "') AND (Id_Datos='1' or Id_Datos='3' or Id_Datos='5' or Id_Datos = '6' or Id_Datos = '14')", myConection);
            mycommand.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
            //DataSet DS = new DataSet();

            try
            {
                adapter.Fill(DS, "Asociado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DS;
        }






        public void LimpiarServiciosComplejosTemp()
        {
            DataSet1TableAdapters.TLB_PagoComplejoTempTableAdapter TempAdpt1 = new DataSet1TableAdapters.TLB_PagoComplejoTempTableAdapter();
            try
            {
                TempAdpt1.DeleteAll();
            }
            catch { }
        }

        public bool LimpiarServiciosComplejos(string codigoServicio)
        {
            try
            {
                DataSet1TableAdapters.TLB_PagoComplejoTableAdapter TempAdpt = new DataSet1TableAdapters.TLB_PagoComplejoTableAdapter();
                DataSet1TableAdapters.TLB_PagoComplejoTempTableAdapter TempAdpt1 = new DataSet1TableAdapters.TLB_PagoComplejoTempTableAdapter();
                TempAdpt.BorrarPorIdServ(codigoServicio);

                DataSet1.TLB_PagoComplejoTempDataTable PCT1 = TempAdpt1.GetData();
                DataSet1.TLB_PagoComplejoDataTable PCT = new DataSet1.TLB_PagoComplejoDataTable();
                PCT.Merge((DataTable)PCT1, false, MissingSchemaAction.Ignore);
                for (int i = 0; i < PCT.Count; i++)
                    PCT[i].SetAdded();

                TempAdpt.Update(PCT);
                TempAdpt1.DeleteAll();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // 20/10/08 Limpiar servicios complejos a traves de SP
        public bool LimpiarServiciosComplejosNew(string codigoServicio)
        {
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myconection = new SqlConnection(stringConection);
            SqlCommand mycommand = new SqlCommand("sp_LimpiarServComplejo", myconection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@ID_SERV", codigoServicio);
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
            return true;
        }
        public bool GuardarServicioComplejo(PagoComplejo servComplejo)
        {
            try
            {
                DataSet1.TLB_PagoComplejoTempDataTable pc = new DataSet1.TLB_PagoComplejoTempDataTable();
                DataSet1.TLB_PagoComplejoTempRow TempRow = pc.NewTLB_PagoComplejoTempRow();
                TempRow.ID_SERV = servComplejo.Tipo;
                TempRow.Id_Asociado = servComplejo.Identificador;
                TempRow.Nombre = servComplejo.Nombre;
                TempRow.Importe = decimal.Parse(servComplejo.Importe.ToString());
                TempRow.descriptivo = servComplejo.Descriptivo;
                TempRow.Informativo = servComplejo.Informativo;
                pc.AddTLB_PagoComplejoTempRow(TempRow);
                new DataSet1TableAdapters.TLB_PagoComplejoTempTableAdapter().Update(pc);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        // 20/10/08 Guardar los servicios complejos a traves de SP
        public bool GuardarServicioComplejoNew(string codigoservicio, string fichero)
        {
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
            SqlConnection myconection = new SqlConnection(stringConection);

            if (codigoservicio == "03")
            {                
                SqlCommand mycommand = new SqlCommand("TLB_ACTUALIZAR_SERVICIO_ONAT", myconection);
                mycommand.CommandType = CommandType.StoredProcedure;               
                mycommand.CommandTimeout = 180;
            }
            else
            { 
                //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;                
                SqlCommand mycommand = new SqlCommand("sp_EjecutarDTS", myconection);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Parameters.AddWithValue("@cod_serv", codigoservicio);
                mycommand.CommandTimeout = 180;
                //mycommand.Parameters.AddWithValue("@Id_Asociado", servComplejo.Identificador);
                //mycommand.Parameters.AddWithValue("@Nombre", servComplejo.Nombre);
                //mycommand.Parameters.AddWithValue("@Importe", servComplejo.Importe);
                //mycommand.Parameters.AddWithValue("@Descriptivo", servComplejo.Descriptivo);
                //mycommand.Parameters.AddWithValue("@Informativo", servComplejo.Informativo);
                try
                {
                    myconection.Open();
                    mycommand.ExecuteNonQuery();
                    //result = Convert.ToInt32(mycommand.Parameters["@idSupplier"].Value);
                }
                catch (SqlException e)
                {
                    ///*escribir en el log*/

                    //string path = @"C:\Logs_Telebanca\log_error.txt";

                    //using (TextWriter writer = File.AppendText(path))
                    //{
                    //    string separador = " : ";
                    //    string metodo_error = "GuardarServicioComplejoNew \n";
                    //    string nombre_proyecto = "(DataAccesLayer): ";
                    //    string date = DateTime.Now.ToString() + " \n";
                    //    string separa = "-------------------------------------------------------";
                    //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                    //}

                    throw new Exception(e.Message);
                }
                finally
                {

                    myconection.Close();
                }
            }

            return true;
            //bool resultado_procedimiento = false;
            //DataSet datase = new DataSet();

            //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            //SqlConnection myconection = new SqlConnection(stringConection);
            //SqlCommand mycommand = new SqlCommand("sp_EjecutarDTS", myconection);
            //mycommand.CommandType = CommandType.StoredProcedure;
            //mycommand.Parameters.AddWithValue("@cod_serv", codigoservicio);
            //mycommand.CommandTimeout = 180;
            
            ////mycommand.Parameters.AddWithValue("@Id_Asociado", servComplejo.Identificador);
            ////mycommand.Parameters.AddWithValue("@Nombre", servComplejo.Nombre);
            ////mycommand.Parameters.AddWithValue("@Importe", servComplejo.Importe);
            ////mycommand.Parameters.AddWithValue("@Descriptivo", servComplejo.Descriptivo);
            ////mycommand.Parameters.AddWithValue("@Informativo", servComplejo.Informativo);
            //try
            //{
            //    myconection.Open();
            //    int val = mycommand.ExecuteNonQuery();
            //    //SqlDataAdapter adapter1 = new SqlDataAdapter();
            //    //adapter1.SelectCommand = mycommand;
            //    //adapter1.Fill(datase);

            //    string consulta_filas= "SELECT COUNT(*) FROM dbo.TLB_SERV_" + codigoservicio;
            //    SqlCommand comman = new SqlCommand(consulta_filas,myconection);

            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = comman;
            //    adapter.Fill(datase);

            //    //result = Convert.ToInt32(mycommand.Parameters["@idSupplier"].Value);

            //    StreamReader lector_fichero = new StreamReader(@"C:\Empresas\" + codigoservicio + @"\E" + codigoservicio + ".txt");
            //    double cantidad_lineas = 0;
            //    while (lector_fichero.Peek() != -1)
            //    {
            //        lector_fichero.ReadLine();
            //        cantidad_lineas++;
            //    }

            //    if ((double.Parse(datase.Tables[0].Rows[0].ItemArray[0].ToString()) == cantidad_lineas))
            //    {
            //        GuardarNotificacion("El fichero " + fichero + " del servicio " + codigoservicio + " se cargo en la tabla de la BD satisfactoriamente", "Administrador");
            //        resultado_procedimiento = true;
            //    }
            //    else
            //    {
            //        GuardarNotificacion("El fichero  " + fichero + " del servicio " + codigoservicio + " no se llego a cargar en la tabla de la BD completamente", "Administrador");
            //        resultado_procedimiento = false;
            //    }

            //    //if(VerificarFicheroCompleto(codigoservicio))
            //    //{ 
            //    //    GuardarNotificacion("El fichero "+fichero+ " del servicio "+codigoservicio+" se cargo en la tabla de la BD satisfactoriamente", "Administrador");
            //    //    resultado_procedimiento = true;
            //    //}
            //    //else
            //    //{
            //    //    GuardarNotificacion("El fichero  " + fichero + " del servicio " + codigoservicio + " no se llego a cargar en la tabla de la BD completamente", "Administrador");
            //    //    resultado_procedimiento = false;
            //    //}
            //}
            //catch (SqlException e)
            //{
            //    throw new Exception(e.Message);
            //}
            //finally
            //{

            //    myconection.Close();
            //}

            //return resultado_procedimiento;
        }

        private bool VerificarFicheroCompleto(string codigo_serv)
        {
            bool sucess = false;
            int cantidad_lineas = 0;
            string cadena_conexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;

            SqlConnection conx = new SqlConnection(cadena_conexion);

            try 
	        {	        
		        StreamReader lector_fichero= new StreamReader(@"C:\Empresas\" + codigo_serv + @"\E"+codigo_serv+ ".txt");

                while (lector_fichero.Peek() != -1)
                {
                    lector_fichero.ReadLine();
                    cantidad_lineas++;
                }

                //while (lector_fichero.ReadLine()!=null)
                //{
                //   cantidad_lineas ++; 
                //}
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }


            try
            {                
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM TLB_SERV_" + codigo_serv, conx);
                conx.Open();

                object[] resultado = new Object[1];

                resultado[0] = comm.ExecuteScalar();
                int count_fichero = (int)resultado[0];

                if (cantidad_lineas == count_fichero)
                {
                    sucess = true;                
                }
                
            }
            catch (SqlException m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conx.Close();
            }

            return sucess;
        }



        public DateTime BuscarFechaDescargaFTP(string codServicio)
        {
            try
            {
                DataSet1.TLB_C_SERVBTDataTable serv = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetServicioPorID(codServicio);
                return ((DataSet1.TLB_C_SERVBTRow)serv.Rows[0]).ProximaDescargaFTP;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public bool CambierEstadoServicio(string codServicio, string estado)
        {
            try
            {
                DataSet1.TLB_C_SERVBTDataTable serv = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetServicioPorID(codServicio);
                DataSet1.TLB_C_SERVBTRow servR = (DataSet1.TLB_C_SERVBTRow)serv.Rows[0];
                servR.SERV_EST = estado;
                new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().Update(servR);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //*****



        public string VerificarDatosBanco(string nombre, string webServices, string numBanco, string abreviatura)
        {
            DataSet1TableAdapters.TLB_BancoTableAdapter banco = new DataAccessLayer.DataSet1TableAdapters.TLB_BancoTableAdapter();
            DataSet1 ds1 = new DataSet1();
            banco.Fill(ds1.TLB_Banco);

            string result = "";

            foreach (DataSet1.TLB_BancoRow i in ds1.TLB_Banco.Rows)
            {
                if ((int)banco.VerifID(numBanco) == 1)
                    result += "Numero de Banco" + ",";
                if ((int)banco.VerifNombre(nombre) == 1)
                    result += "Nombre de banco" + ",";
                if ((int)banco.VerifWebService(webServices) == 1)
                    result += "Web Services" + ",";
                if ((int)banco.VerifAbreviatura(abreviatura) == 1)
                    if (abreviatura != "")
                        result += "Abreviatura" + ",";
            }
            return result;
        }
        /*******************************************************************************************************/
        public bool AdicionarBanco(BancoPersistente bancoP)
        {
            DataSet1TableAdapters.TLB_BancoTableAdapter banco = new DataAccessLayer.DataSet1TableAdapters.TLB_BancoTableAdapter();
            DataSet1 ds1 = new DataSet1();
            banco.Fill(ds1.TLB_Banco);

            DataSet1.TLB_BancoRow bancoRow = ds1.TLB_Banco.FindById_Banco(bancoP.NumBanco.ToString());
            if (bancoRow == null)
            {
                DataSet1.TLB_BancoRow bancoResult = ds1.TLB_Banco.NewTLB_BancoRow();
                bancoResult.Nombre = bancoP.Nombre;
                bancoResult.Abreviatura = bancoP.Abreviatura;
                bancoResult.Id_Banco = bancoP.NumBanco;
                bancoResult.WebService = bancoP.WebServices;
                bancoResult.Pasword = bancoP.PassWord;
                ds1.TLB_Banco.AddTLB_BancoRow(bancoResult);
                banco.Update(ds1.TLB_Banco);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public BancoPersistente BuscarBanco(string numBanco)
        {
            DataSet1TableAdapters.TLB_BancoTableAdapter banco = new DataAccessLayer.DataSet1TableAdapters.TLB_BancoTableAdapter();
            DataSet1 ds1 = new DataSet1();
            banco.Fill(ds1.TLB_Banco);

            BancoPersistente result = new BancoPersistente();
            DataSet1.TLB_BancoRow bancoRow = ds1.TLB_Banco.FindById_Banco(numBanco);

            if (bancoRow != null)
            {
                result.NumBanco = bancoRow.Id_Banco;
                result.Nombre = bancoRow.Nombre;
                result.WebServices = bancoRow.WebService;
                result.Abreviatura = bancoRow.Abreviatura;
                result.PassWord = bancoRow.Pasword;
                return result;
            }
            return result;
        }
        /*******************************************************************************************************/
        public List<BancoPersistente> ObtenerListaBanco()
        {
            try
            {
                List<BancoPersistente> LB = new List<BancoPersistente>();
                DataSet1.TLB_BancoDataTable BDT = new DataSet1TableAdapters.TLB_BancoTableAdapter().GetData();
                foreach (DataSet1.TLB_BancoRow i in BDT.Rows)
                {
                    BancoPersistente B = new BancoPersistente();
                    B.Abreviatura = i.Abreviatura;
                    B.Nombre = i.Nombre;
                    B.NumBanco = i.Id_Banco;
                    B.PassWord = i.Pasword;
                    B.WebServices = i.WebService;
                    LB.Add(B);
                }
                return LB;
            }
            catch (Exception)
            {
                throw new Exception("No se pueden obtener los Bancos Asociados por estar la conexión con la Base de Datos deshabilitada.");
            }
        }
        /*******************************************************************************************************/
        public bool ModificarBanco(BancoPersistente bancoP)
        {
            DataSet1TableAdapters.TLB_BancoTableAdapter banco = new DataAccessLayer.DataSet1TableAdapters.TLB_BancoTableAdapter();
            DataSet1 ds1 = new DataSet1();
            banco.Fill(ds1.TLB_Banco);

            DataSet1.TLB_BancoRow bancoRow = ds1.TLB_Banco.FindById_Banco(bancoP.NumBanco.ToString());

            if (bancoRow != null)
            {
                bancoRow.WebService = bancoP.WebServices;
                bancoRow.Pasword = bancoP.PassWord;
                bancoRow.Abreviatura = bancoP.Abreviatura;

                banco.Update(ds1.TLB_Banco);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public bool EliminarBanco(string numBanco)
        {
            DataSet1TableAdapters.TLB_BancoTableAdapter banco = new DataAccessLayer.DataSet1TableAdapters.TLB_BancoTableAdapter();
            DataSet1 ds1 = new DataSet1();
            banco.Fill(ds1.TLB_Banco);

            foreach (DataSet1.TLB_BancoRow i in ds1.TLB_Banco.Rows)
                if (i.Id_Banco == numBanco)
                {
                    i.Delete();
                    banco.Update(ds1.TLB_Banco);
                    return true;
                }
            return false;
        }
        /*******************************************************************************************************/
        public bool ExisteServicio(string NombreServicio, string idServ)
        {
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter serv = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();
            DataSet1 ds1 = new DataSet1();
            serv.Fill(ds1.TLB_C_SERVBT);
            return (int)serv.HayServicio(NombreServicio, idServ) == 1;
        }
        /*******************************************************************************************************/
        public ServicioPersistente BuscarServicio(string nombServ)
        {
            DataSet1 ds1 = new DataSet1();

            new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().Fill(ds1.TLB_C_SERVBT);

            new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().Fill(ds1.TLB_C_DATSER);

            new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().Fill(ds1.TLB_C_RELSD);

            DataSet1.TLB_C_SERVBTRow serv_row = null;

            foreach (DataSet1.TLB_C_SERVBTRow i in ds1.TLB_C_SERVBT)

                if (i.SERV_NOM.Equals(nombServ))
                {

                    serv_row = i;

                    break;

                }

            if (serv_row == null)

                throw new Exception("El servicio " + nombServ + " no existe");



            ServicioPersistente service = new ServicioPersistente();

            service.IdServicio = serv_row.ID_SERV.ToString();

            service.Nombre = serv_row.SERV_NOM;

            service.Estado = serv_row.SERV_EST;

            service.TipoServicio = serv_row.SERV_TIP;

            service.AutenticaPorCI = serv_row.Autentica_CI;

            service.AutenticaPorPin = serv_row.Autentica_Pin;

            service.AutenticaPorTarjeta = serv_row.Autentica_Tarjeta;

            service.CantCoord = Convert.ToInt32(serv_row.Autentica_Matriz);

            service.Frecuencia = Convert.ToInt32(serv_row.FrecuenciaDescargaFTP);

            service.FechaDescargaFTP = Convert.ToDateTime(serv_row.ProximaDescargaFTP);

            service.Asociados = serv_row.Asociados;



            foreach (DataSet1.TLB_C_RELSDRow i in ds1.TLB_C_RELSD)

                if (service.IdServicio == i.ID_SERV)
                {

                    DatoPersistente dp = new DatoPersistente(i.TLB_C_DATSERRow.DAT_NOM, i.DAT_CAR, i.TLB_C_DATSERRow.DAT_TIP, i.TLB_C_DATSERRow.DAT_TAM);

                    service.DatosPersistentes.Add(dp);

                }



            return service;



        }
        /*******************************************************************************************************/
        public bool InsertarServicio(ServicioPersistente servicio)
        {
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter servb = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();
            DataSet1TableAdapters.TLB_C_RELSDTableAdapter relsd = new DataAccessLayer.DataSet1TableAdapters.TLB_C_RELSDTableAdapter();
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();

            servb.Fill(ds1.TLB_C_SERVBT);
            datser.Fill(ds1.TLB_C_DATSER);
            relsd.Fill(ds1.TLB_C_RELSD);

            bool result = false;

            if (!ExisteServicio(servicio.Nombre, servicio.IdServicio))
            {
                DataSet1.TLB_C_SERVBTRow servRow = ds1.TLB_C_SERVBT.NewTLB_C_SERVBTRow();
                servRow.ID_SERV = servicio.IdServicio;
                servRow.SERV_NOM = servicio.Nombre;
                servRow.SERV_EST = servicio.Estado;
                servRow.SERV_TIP = servicio.TipoServicio;
                servRow.Autentica_CI = servicio.AutenticaPorCI;
                servRow.Autentica_Pin = servicio.AutenticaPorPin;
                servRow.Autentica_Tarjeta = servicio.AutenticaPorTarjeta;
                servRow.Autentica_Matriz = Convert.ToInt16(servicio.CantCoord);
                servRow.FrecuenciaDescargaFTP = Convert.ToInt16(servicio.Frecuencia);
                servRow.ProximaDescargaFTP = servicio.FechaDescargaFTP;
                servRow.Asociados = servicio.Asociados;

                ds1.TLB_C_SERVBT.AddTLB_C_SERVBTRow(servRow);
                servb.Update(ds1.TLB_C_SERVBT);

                DataSet1.TLB_C_SERVBTRow TempSevRow = ds1.TLB_C_SERVBT.NewTLB_C_SERVBTRow();
                DataSet1.TLB_C_DATSERRow TempDatRow = ds1.TLB_C_DATSER.NewTLB_C_DATSERRow();
                foreach (DataSet1.TLB_C_SERVBTRow i in ds1.TLB_C_SERVBT)
                    if (i.SERV_NOM == servicio.Nombre)
                    {
                        TempSevRow = i;
                        break;
                    }

                foreach (DatoPersistente i in servicio.DatosPersistentes)
                {
                    foreach (DataSet1.TLB_C_DATSERRow j in ds1.TLB_C_DATSER)
                        if (j.DAT_NOM == i.NombreDato)
                        {
                            TempDatRow = j;
                            break;
                        }

                    DataSet1.TLB_C_RELSDRow relsdRow = ds1.TLB_C_RELSD.NewTLB_C_RELSDRow();
                    if (TempDatRow.DAT_NOM == i.NombreDato)
                    {
                        relsdRow.ID_SERV = TempSevRow.ID_SERV;
                        relsdRow.ID_DATOS = TempDatRow.ID_DATOS;
                        relsdRow.DAT_CAR = i.TipoDato;
                    }
                    ds1.TLB_C_RELSD.AddTLB_C_RELSDRow(relsdRow);
                }
                // relsd.Update(ds1.TLB_C_RELSD);************quitado para no modificar clasificadores
                result = true;
            }
            return result;
        }
        /*******************************************************************************************************/
        public bool EliminarServicio(string NombreServicio)
        {
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter serv = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();
            DataSet1 ds1 = new DataSet1();
            serv.Fill(ds1.TLB_C_SERVBT);

            bool result = false;

            foreach (DataSet1.TLB_C_SERVBTRow i in ds1.TLB_C_SERVBT.Rows)
                if (i.SERV_NOM == NombreServicio)
                {
                    i.SERV_EST = "EL";
                    result = true;
                    serv.Update(ds1.TLB_C_SERVBT);
                    break;
                }
            return result;
        }
        /*******************************************************************************************************/
        public bool ModificarServicio(ServicioPersistente servicio)
        {
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter servb = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();
            DataSet1TableAdapters.TLB_C_RELSDTableAdapter relsd = new DataAccessLayer.DataSet1TableAdapters.TLB_C_RELSDTableAdapter();
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();

            servb.Fill(ds1.TLB_C_SERVBT);
            datser.Fill(ds1.TLB_C_DATSER);
            relsd.Fill(ds1.TLB_C_RELSD);

            bool result = false;

            DataSet1.TLB_C_SERVBTRow servbRow = null;
            DataSet1.TLB_C_DATSERRow datserRow = null;

            ds1.Merge(servb.GetServicioPorID(servicio.IdServicio));

            servbRow = ds1.TLB_C_SERVBT.FindByID_SERV(servicio.IdServicio);

            DataSet1.TLB_C_RELSDRow[] ListServRow = servbRow.GetTLB_C_RELSDRows();
            foreach (DataSet1.TLB_C_RELSDRow i in ListServRow)
                i.Delete();
            //relsd.Update(ds1.TLB_C_RELSD);**************quitado para no modificar clasificadores

            if (ExisteServicio(servicio.Nombre, servicio.IdServicio))
            {
                servbRow.SERV_EST = servicio.Estado;
                servbRow.SERV_TIP = servicio.TipoServicio;
                servbRow.Autentica_CI = servicio.AutenticaPorCI;
                servbRow.Autentica_Pin = servicio.AutenticaPorPin;
                servbRow.Autentica_Tarjeta = servicio.AutenticaPorTarjeta;
                servbRow.Autentica_Matriz = Convert.ToInt16(servicio.CantCoord);
                servbRow.FrecuenciaDescargaFTP = Convert.ToInt16(servicio.Frecuencia);
                servbRow.ProximaDescargaFTP = servicio.FechaDescargaFTP;
                servbRow.Asociados = servicio.Asociados;

                servb.Update(ds1.TLB_C_SERVBT);
                short orden = 1;
                foreach (DatoPersistente i in servicio.DatosPersistentes)
                {
                    foreach (DataSet1.TLB_C_DATSERRow j in ds1.TLB_C_DATSER)
                        if ((j.DAT_NOM == i.NombreDato))
                        {
                            datserRow = j;
                            break;
                        }
                    if (datserRow != null)
                        if ((datserRow.DAT_NOM == i.NombreDato) && (servbRow.SERV_NOM == servicio.Nombre))
                        {
                            DataSet1.TLB_C_RELSDRow relsdRow = ds1.TLB_C_RELSD.NewTLB_C_RELSDRow();
                            relsdRow.ID_SERV = servbRow.ID_SERV;
                            relsdRow.ID_DATOS = datserRow.ID_DATOS;
                            relsdRow.DAT_CAR = i.TipoDato;
                            relsdRow.ORDEN = orden; orden++;
                            ds1.TLB_C_RELSD.AddTLB_C_RELSDRow(relsdRow);
                            //relsd.Update(ds1.TLB_C_RELSD);**************quitado para no modificar clasificadores
                        }
                }
                result = true;
            }
            return result;
        }
        /*******************************************************************************************************/
        public List<ServicioPersistente> ListaServiciosExistentes()
        {
            DataSet1 ds1 = new DataSet1();
            new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().Fill(ds1.TLB_C_SERVBT);
            new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().Fill(ds1.TLB_C_DATSER);
            new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().Fill(ds1.TLB_C_RELSD);

            List<ServicioPersistente> result = new List<ServicioPersistente>();
            ServicioPersistente se = new ServicioPersistente();

            foreach (DataSet1.TLB_C_SERVBTRow i in ds1.TLB_C_SERVBT)
            {
                if ((i.SERV_EST == "AC") || (i.SERV_EST == "NA"))
                {
                    se = new ServicioPersistente();
                    se.IdServicio = i.ID_SERV;
                    se.Nombre = i.SERV_NOM;
                    se.TipoServicio = i.SERV_TIP;
                    se.Frecuencia = i.FrecuenciaDescargaFTP;
                    se.FechaDescargaFTP = i.ProximaDescargaFTP;
                    se.Estado = i.SERV_EST;
                    se.CantCoord = i.Autentica_Matriz;
                    se.AutenticaPorTarjeta = i.Autentica_Tarjeta;
                    se.AutenticaPorPin = i.Autentica_Pin;
                    se.AutenticaPorCI = i.Autentica_CI;
                    se.Asociados = i.Asociados;

                    foreach (DataSet1.TLB_C_RELSDRow j in ds1.TLB_C_RELSD)
                    {
                        if (i.ID_SERV == j.ID_SERV)
                        {
                            DatoPersistente dp = new DatoPersistente(j.TLB_C_DATSERRow.DAT_NOM, j.DAT_CAR, j.TLB_C_DATSERRow.DAT_TIP, j.TLB_C_DATSERRow.DAT_TAM);
                            se.DatosPersistentes.Add(dp);
                        }
                    }
                    result.Add(se);
                }
            }
            return result;
        }
        /*******************************************************************************************************/
        public bool ExisteDato(DatoPersistente dato)
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);
            return (int)datser.HayDatos(dato.NombreDato, dato.Tipo, dato.TamañoDato) == 1;
        }
        /*******************************************************************************************************/
        public DatoPersistente BuscarDato(DatoPersistente NombreDato)
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);

            DatoPersistente result = new DatoPersistente();

            foreach (DataSet1.TLB_C_DATSERRow i in ds1.TLB_C_DATSER.Rows)
                if (i.DAT_NOM == NombreDato.NombreDato)
                {
                    result.NombreDato = i.DAT_NOM;
                    result.TamañoDato = i.DAT_TAM;
                    result.Tipo = i.DAT_TIP;
                    break;
                }
            return result;
        }
        /*******************************************************************************************************/
        public int IdDato(string nombre)
        {
            DataSet1.TLB_C_DATSERDataTable datodt = new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().GetData();
            int result = 0;
            foreach (DataSet1.TLB_C_DATSERRow i in datodt)
                if (i.DAT_NOM == nombre)
                {
                    result = Convert.ToInt32(i.ID_DATOS);
                    break;
                }
            return result;
        }
        /*******************************************************************************************************/
        public bool AdicionarDato(DatoPersistente dato)
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);

            DataSet1.TLB_C_DATSERRow datserRow = ds1.TLB_C_DATSER.NewTLB_C_DATSERRow();

            if (!ExisteDato(dato))
            {
                datserRow.DAT_NOM = dato.NombreDato;
                datserRow.DAT_TAM = Convert.ToInt16(dato.TamañoDato);
                datserRow.DAT_TIP = dato.Tipo;

                ds1.TLB_C_DATSER.AddTLB_C_DATSERRow(datserRow);
                datser.Update(ds1.TLB_C_DATSER);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public List<DatoPersistente> GetDatosNoAsociados()
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1TableAdapters.TLB_C_RELSDTableAdapter relsd = new DataAccessLayer.DataSet1TableAdapters.TLB_C_RELSDTableAdapter();
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter servbt = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();

            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);
            servbt.Fill(ds1.TLB_C_SERVBT);
            relsd.Fill(ds1.TLB_C_RELSD);

            foreach (DataSet1.TLB_C_RELSDRow i in ds1.TLB_C_RELSD)
                try { i.TLB_C_DATSERRow.Delete(); }
                catch { }

            List<DatoPersistente> result = new List<DatoPersistente>();

            foreach (DataSet1.TLB_C_DATSERRow i in ds1.TLB_C_DATSER)
                if (i.RowState != DataRowState.Deleted)
                    result.Add(new DatoPersistente(i.DAT_NOM, "  ", i.DAT_TIP, i.DAT_TAM));

            return result;
        }
        /*******************************************************************************************************/
        public bool ModificarDato(DatoPersistente dato, string nombreAnt)
        {
            DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
            DataSet1.TLB_C_DATSERDataTable datodt = new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().GetData();
            DataSet1.TLB_C_RELSDDataTable relacdt = new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().GetData();

            bool datoNoAs = false;
            List<DatoPersistente> ListDatos = GetDatos();

            foreach (DatoPersistente i in ListDatos)
                if (nombreAnt != i.NombreDato)
                    if (dato.NombreDato == i.NombreDato)
                    {
                        datoNoAs = true;
                        break;
                    }

            if (!datoNoAs)
            {
                foreach (DataSet1.TLB_C_DATSERRow i in datodt)
                    if (i.DAT_NOM == nombreAnt)
                    {
                        i.DAT_NOM = dato.NombreDato;
                        i.DAT_TAM = Convert.ToInt16(dato.TamañoDato);
                        i.DAT_TIP = dato.Tipo;
                        new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().Update(datodt);
                        return true;
                    }
            }
            return false;
        }
        /*******************************************************************************************************/
        public bool EliminarDato(DatoPersistente dato)
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1TableAdapters.TLB_C_RELSDTableAdapter relsd = new DataAccessLayer.DataSet1TableAdapters.TLB_C_RELSDTableAdapter();
            DataSet1TableAdapters.TLB_C_SERVBTTableAdapter serv = new DataAccessLayer.DataSet1TableAdapters.TLB_C_SERVBTTableAdapter();
            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);
            serv.Fill(ds1.TLB_C_SERVBT);
            relsd.Fill(ds1.TLB_C_RELSD);

            bool datoNoAs = false;
            List<DatoPersistente> ListDatNoAs = GetDatosNoAsociados();

            foreach (DatoPersistente i in ListDatNoAs)
                if (dato.NombreDato == i.NombreDato)
                {
                    datoNoAs = true;
                    break;
                }

            if (datoNoAs)
            {
                foreach (DataSet1.TLB_C_DATSERRow i in ds1.TLB_C_DATSER.Rows)
                    if (dato.NombreDato == i.DAT_NOM)
                    {
                        i.Delete();
                        datser.Update(ds1.TLB_C_DATSER);
                        return true;
                    }
            }
            return false;
        }
        /*******************************************************************************************************/
        public List<DatoPersistente> GetDatos()
        {
            DataSet1TableAdapters.TLB_C_DATSERTableAdapter datser = new DataAccessLayer.DataSet1TableAdapters.TLB_C_DATSERTableAdapter();
            DataSet1 ds1 = new DataSet1();
            datser.Fill(ds1.TLB_C_DATSER);

            List<DatoPersistente> result = new List<DatoPersistente>();
            foreach (DataSet1.TLB_C_DATSERRow i in ds1.TLB_C_DATSER.Rows)
                result.Add(new DatoPersistente(i.DAT_NOM, "  ", i.DAT_TIP, i.DAT_TAM));
            return result;
        }
        /*******************************************************************************************************/
        public List<string> ActualizarServicioDatos(List<string> NombresBancos)
        {
            List<string> result = new List<string>();



            return result;
        }
        /*******************************************************************************************************/
        public string BuscarMetodoAutenticacion(string codigoServicio)
        {
            string result = "";
            try
            {
                DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
                DataSet1.TLB_C_SERVBTRow servRow = servdt.FindByID_SERV(codigoServicio);

                if (servRow != null)
                    result = servRow.SERV_TIP;
            }
            catch (Exception e)
            {
                GuardarNotificacion("Error de acceso a la BD " + e.Message, "Administrador");
            }
            return result;
        }
        /*******************************************************************************************************/
        public bool BuscarNivelAutenticacionPorCI(string codigoServicio)
        {
            DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
            DataSet1.TLB_C_SERVBTRow servRow = servdt.FindByID_SERV(codigoServicio);
            bool result = false;
            if (servRow != null)
                result = servRow.Autentica_CI;
            return result;
        }
        /*******************************************************************************************************/
        public int BuscarNivelAutenticacionPorCoord(string codigoServicio)
        {
            DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
            DataSet1.TLB_C_SERVBTRow servRow = servdt.FindByID_SERV(codigoServicio);
            Int16 result = 0;
            if (servRow != null)
                result = servRow.Autentica_Matriz;
            return result;
        }
        /*******************************************************************************************************/
        public bool GuardarFechaDescargaFTP(string codServicio, DateTime fecha)
        {
            DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
            DataSet1.TLB_C_SERVBTRow servRow = servdt.FindByID_SERV(codServicio);
            if (servRow != null)
            {
                servRow.ProximaDescargaFTP = fecha;
                new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().Update(servRow);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public List<Dato> BuscarDatosPago(string codServ)
        {
            List<Dato> result = new List<Dato>();
            try
            {
                DataSet1.TLB_C_RELSDDataTable reldt = new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().IdDatosPorServ(codServ, "2");
                foreach (DataSet1.TLB_C_RELSDRow i in reldt)
                    result.Add(new Dato(i.ID_DATOS.ToString(), ""));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /*******************************************************************************************************/
        public List<Dato> BuscarDatos(string codServ, string[] tiposDato)
        {
            List<Dato> result = new List<Dato>();
            try
            {
                foreach (string tipo in tiposDato)
                {
                    DataSet1.TLB_C_RELSDDataTable reldt = new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().IdDatosPorServ(codServ, tipo);
                    foreach (DataSet1.TLB_C_RELSDRow i in reldt)
                        result.Add(new Dato(i.ID_DATOS.ToString(), ""));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /*******************************************************************************************************/
        public string BuscarNombreServ(string codigoServ)
        {
            DataSet1.TLB_C_SERVBTDataTable servdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetData();
            DataSet1.TLB_C_SERVBTRow servRow = servdt.FindByID_SERV(codigoServ);
            return servRow.SERV_NOM;
        }
        /*******************************************************************************************************/
        public string BuscarNombreDato(int idDato)
        {
            DataSet1.TLB_C_DATSERDataTable datodt = new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().GetData();
            DataSet1.TLB_C_DATSERRow datRow = datodt.FindByID_DATOS(Convert.ToInt16(idDato));
            return datRow.DAT_NOM;
        }
        /*******************************************************************************************************/
        public List<string> TarjetasDadoBancoEstadoDiarias(string CodigoBanco, string estado)
        {
            DataSet1.TLB_TarjetaDataTable tarjdt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetData();
            List<string> result = new List<string>();

            foreach (DataSet1.TLB_TarjetaRow i in tarjdt)
                if ((i.Id_NoTarjeta.Substring(0, 2) == CodigoBanco) && (i.Estado == estado))
                    result.Add(i.Id_NoTarjeta);
            return result;
        }
        /*******************************************************************************************************/
        public List<Transaccion> TransaccionesDiariasDadoBanco(string CodigoBanco)
        {
            DataSet1.TLB_TransaccionDataTable transdt = new DataSet1TableAdapters.TLB_TransaccionTableAdapter().GetData();
            List<Transaccion> result = new List<Transaccion>();
            DateTime fechaTmp = DateTime.Now.Date;
            foreach (DataSet1.TLB_TransaccionRow i in transdt)
                if ((i.Id_NoTarjeta.Substring(0, 2) == CodigoBanco) && (i.FechaHora.Date == fechaTmp))
                    result.Add(new Transaccion(i.Traza, i.ID_SERV.ToString(), i.Id_NoTarjeta, i.Id_Usuario, i.FechaHora, null));
            return result;
        }
        /*******************************************************************************************************/
        public List<string> TrazasDeTransaccionesReclamadasDiariasDadoBanco(string CodigoBanco)
        {
            DataSet1.TLB_TransaccionDataTable transdt = new DataSet1TableAdapters.TLB_TransaccionTableAdapter().GetData();
            DataSet1.TLB_ReclamacionDataTable recdt = new DataSet1TableAdapters.TLB_ReclamacionTableAdapter().GetData();
            List<string> result = new List<string>();
            DateTime fechaTmp = DateTime.Now;
            foreach (DataSet1.TLB_ReclamacionRow i in recdt)
                if ((i.TLB_TransaccionRow.Id_NoTarjeta.Substring(0, 2) == CodigoBanco) && (i.TLB_TransaccionRow.FechaHora.Date == fechaTmp))
                    result.Add(i.TLB_TransaccionRow.Traza);
            return result;
        }

        public DateTime FechaContableUltima()
        {
            return new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter().GetData()[0].FechaContable;
        }

        public bool CambiarFechaContable(DateTime pFecha)
        {
            DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter TempAdpt = new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter();
            DataSet1.TLB_ConfiguraciónDataTable TempTable = TempAdpt.GetData();
            if (TempTable[0].FechaContable >= pFecha)
                return false;
            TempTable[0].FechaContable = pFecha;
            return TempAdpt.Update(TempTable) > 0;
        }
        //******************-TRANSFERENCIAS AL PROPIO CLIENTE-*****************************
        public DataSet TransfProv()
        {

            DataSet provincias = new DataSet();
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }

            try
            {
                
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                provincias = ws.GetProvincias();
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
            return provincias;

        }

        public DataSet TransfMun(string codigo)
        {
            
            DataSet municipios = new DataSet();
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }

            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                municipios = ws.GetMunicipios(codigo);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
            return municipios;
        }

        public DataSet TransfBanco(string codigo)
        {
           
            DataSet bancos = new DataSet();
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }

            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                bancos = ws.GetMuniSucursales(codigo);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
            return bancos;
        }


        #endregion

        #region MODULO SERVICIO INFORMACION
        public bool ExisteEntidad(string nombre)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidad = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();

            entidad.Fill(ds1.TLB_Entidades);
            if (ds1.TLB_Entidades.FindByNombre(nombre) != null)
                return true;
            return false;
        }
        /*******************************************************************************************************/
        public bool InsertarEntidad(EntidadPersistente entidadP)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidad = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();

            entidad.Fill(ds1.TLB_Entidades);
            DataSet1.TLB_EntidadesRow entRow = ds1.TLB_Entidades.FindByNombre(entidadP.Nombre);
            if (entRow == null)
            {
                //creo entRow
                entRow = ds1.TLB_Entidades.NewTLB_EntidadesRow();
                entRow.SitioWeb = "";
                entRow.CorreoElectronico = "";

                //lleno los campos de la fila
                entRow.CodActual = entidadP.Codigo;
                entRow.CodAntSucursal = entidadP.CodigoAnterior;
                entRow.Nombre = entidadP.Nombre;
                entRow.Direccion = entidadP.Direccion;
                entRow.Fax = entidadP.Fax;
                entRow.Telefono = entidadP.Telefono;
                foreach (string i in entidadP.SitiosWeb)
                    entRow.SitioWeb += i + ";";
                foreach (string i in entidadP.CorreoElectronico)
                    entRow.CorreoElectronico += i + ";";

                //agrego entRow a la Tabla
                ds1.TLB_Entidades.AddTLB_EntidadesRow(entRow);

                entidad.Update(ds1.TLB_Entidades);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public bool EliminarEntidad(string nombre)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidad = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1TableAdapters.TLB_HistoricoEntidadesTableAdapter histEntid = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoEntidadesTableAdapter();
            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter relUserEnt = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();

            DataSet1 ds1 = new DataSet1();
            entidad.Fill(ds1.TLB_Entidades);
            histEntid.Fill(ds1.TLB_HistoricoEntidades);
            relUserEnt.Fill(ds1.TLB_RelacionUserEntid);

            DataSet1.TLB_HistoricoEntidadesRow histoEntidRow = ds1.TLB_HistoricoEntidades.NewTLB_HistoricoEntidadesRow();
            DataSet1.TLB_EntidadesRow entRow = ds1.TLB_Entidades.FindByNombre(nombre);

            if (entRow != null)
            {
                //guardando en el historico de entidades
                histoEntidRow.CodActual = entRow.CodActual;
                histoEntidRow.CodAntSucursal = entRow.CodAntSucursal;
                histoEntidRow.correoElectronico = entRow.CorreoElectronico;
                histoEntidRow.Direccion = entRow.Direccion;
                histoEntidRow.Fax = entRow.Fax;
                histoEntidRow.nombre = entRow.Nombre;
                histoEntidRow.SitioWeb = entRow.SitioWeb;
                histoEntidRow.Telefono = entRow.Telefono;
                ds1.TLB_HistoricoEntidades.AddTLB_HistoricoEntidadesRow(histoEntidRow);

                histEntid.Update(ds1.TLB_HistoricoEntidades);

                // borro la entidad de la tabla RelacionUserEntidad
                DataSet1.TLB_RelacionUserEntidRow[] ListEntUserEnt = entRow.GetTLB_RelacionUserEntidRows();
                foreach (DataSet1.TLB_RelacionUserEntidRow i in ListEntUserEnt)
                    i.Delete();
                relUserEnt.Update(ds1.TLB_RelacionUserEntid);

                //foreach (DataSet1.TLB_RelacionUserEntidRow i in ds1.TLB_RelacionUserEntid)
                //{
                //    if (i.Nombre == nombre)
                //    {
                //        i.Delete();
                //        relUserEnt.Update(ds1.TLB_RelacionUserEntid);
                //    }
                //}

                // borro la Entidad
                entRow.Delete();
                entidad.Update(ds1.TLB_Entidades);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        public EntidadPersistente BuscarEntidad(string nombre)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidades = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();
            entidades.Fill(ds1.TLB_Entidades);

            EntidadPersistente result = new EntidadPersistente();
            DataSet1.TLB_EntidadesRow entRow = ds1.TLB_Entidades.FindByNombre(nombre);
            if (entRow != null)
            {
                try
                {
                    result.Codigo = entRow.CodActual;
                }
                catch
                {
                    result.Codigo = "";
                }
                try
                {
                    result.CodigoAnterior = entRow.CodAntSucursal;
                }
                catch
                {
                    result.CodigoAnterior = "";
                }
                result.Nombre = entRow.Nombre;
                result.Direccion = entRow.Direccion;

                try
                {
                    result.Fax = entRow.Fax;
                }
                catch
                {
                    result.Fax = "";
                }

                result.Telefono = entRow.Telefono;

                result.CorreoElectronico = new List<string>();
                try
                {
                    result.CorreoElectronico.AddRange(entRow.CorreoElectronico.Split(';'));
                }
                catch { }
                result.SitiosWeb = new List<string>();
                try
                {
                    result.SitiosWeb.AddRange(entRow.SitioWeb.Split(';'));
                }
                catch { }

            }
            return result;
        }
        /*******************************************************************************************************/
        public bool InsertarRelacUsuarioEntidad(string usuario, DateTime fecha, string nombreEntidad, string nombreCampo)
        {
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuarioT = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter relacUserEntid = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidadT = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();

            DataSet1 ds1 = new DataSet1();

            DataSet1.TLB_UsuarioRow userRow = ds1.TLB_Usuario.FindByusuario(usuario);
            DataSet1.TLB_EntidadesRow entidadRow = ds1.TLB_Entidades.FindByNombre(nombreEntidad);
            DataSet1.TLB_RelacionUserEntidDataTable relaUserEntidTable = relacUserEntid.ObtenerRelacionExistente(fecha, usuario, nombreEntidad);

            DataSet1.TLB_RelacionUserEntidRow relacUserEntidadRow = ds1.TLB_RelacionUserEntid.NewTLB_RelacionUserEntidRow();

            if (relaUserEntidTable.Count == 0)
            {

                if (userRow != null && entidadRow != null)
                {
                    relacUserEntidadRow.Nombre = nombreEntidad;
                    relacUserEntidadRow.Id_Usuario = usuario;
                    relacUserEntidadRow.Fecha = fecha;

                    if (nombreCampo == "codAnterior")
                        relacUserEntidadRow.CodAntSucursal += 1;

                    if (nombreCampo == "codActual")
                        relacUserEntidadRow.Cod_Entidad += 1;

                    if (nombreCampo == "direccion")
                        relacUserEntidadRow.Direccion += 1;

                    if (nombreCampo == "fax")
                        relacUserEntidadRow.Fax += 1;

                    if (nombreCampo == "correoElectronico")
                        relacUserEntidadRow.CorreoElectronico += 1;

                    if (nombreCampo == "sitioWeb")
                        relacUserEntidadRow.SitioWeb += 1;

                    if (nombreCampo == "direccion")
                        relacUserEntidadRow.Direccion += 1;

                    if (nombreCampo == nombreEntidad)
                        relacUserEntidadRow.NombreC += 1;

                    ds1.TLB_RelacionUserEntid.AddTLB_RelacionUserEntidRow(relacUserEntidadRow);
                    relacUserEntid.Update(ds1.TLB_RelacionUserEntid);

                    return true;
                }
            }
            else
            {

                if (nombreCampo == "codAnterior")
                    relaUserEntidTable[0].CodAntSucursal += 1;

                if (nombreCampo == "codActual")
                    relaUserEntidTable[0].Cod_Entidad += 1;

                if (nombreCampo == "direccion")
                    relaUserEntidTable[0].Direccion += 1;

                if (nombreCampo == "fax")
                    relaUserEntidTable[0].Fax += 1;

                if (nombreCampo == "correoElectronico")
                    relaUserEntidTable[0].CorreoElectronico += 1;

                if (nombreCampo == "sitioWeb")
                    relaUserEntidTable[0].SitioWeb += 1;

                if (nombreCampo == "direccion")
                    relaUserEntidTable[0].Direccion += 1;

                if (nombreCampo == nombreEntidad)
                    relaUserEntidTable[0].NombreC += 1;

                relacUserEntid.Update(ds1.TLB_RelacionUserEntid);
                return true;
            }

            return false;
        }
        /*******************************************************************************************************/
        public List<EntidadPersistente> ObtenerListaEntidades()
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidades = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();

            entidades.Fill(ds1.TLB_Entidades);
            List<EntidadPersistente> result = new List<EntidadPersistente>();

            foreach (DataSet1.TLB_EntidadesRow i in ds1.TLB_Entidades)
                result.Add(BuscarEntidad(i.Nombre));
            return result;
        }
        /*******************************************************************************************************/
        public bool ModificarEntidad(EntidadPersistente entidadP)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidad = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();
            entidad.Fill(ds1.TLB_Entidades);

            DataSet1.TLB_EntidadesRow entRow = ds1.TLB_Entidades.FindByNombre(entidadP.Nombre);
            if (entRow != null)
            {
                entRow.CodActual = entidadP.Codigo;
                entRow.CodAntSucursal = entidadP.CodigoAnterior;
                entRow.Direccion = entidadP.Direccion;
                entRow.Fax = entidadP.Fax;
                entRow.Telefono = entidadP.Telefono;
                entRow.CorreoElectronico = entRow.SitioWeb = string.Empty;
                foreach (string i in entidadP.CorreoElectronico)
                    entRow.CorreoElectronico += i + ";";
                foreach (string i in entidadP.SitiosWeb)
                    entRow.SitioWeb += i + ";";

                entidad.Update(ds1.TLB_Entidades);
                return true;
            }
            return false;
        }
        /*******************************************************************************************************/
        /*******************************************************************************************************/
        public InformacionPersistente MostrarDatosTema(string tema)
        {
            try
            {
                DataSet1TableAdapters.TLB_TemaTableAdapter temas = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
                DataSet1TableAdapters.TLB_PalabraClaveTableAdapter palabraClave = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
                DataSet1TableAdapters.TLB_RelacionTemasTableAdapter relacTemas = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();
                DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter temaPalabraClv = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();

                InformacionPersistente result = new InformacionPersistente();
                DataSet1.TLB_TemaDataTable Fila = temas.DatosTema(tema);
                if (Fila.Rows.Count > 0)
                {
                    result.IdTema = Fila[0].Id_Tema;
                    result.Tema = Fila[0].Tema;
                    result.Texto = Fila[0].Descripcion;
                    //SuperTema
                    DataSet1.TLB_RelacionTemasDataTable Relacion = relacTemas.ObtenerSuperTemas(result.IdTema);
                    if (Relacion.Rows.Count > 0)
                    {
                        result.SuperTema = temas.SeleccionarTema(Relacion[0].SuperTema)[0].Tema;
                        result.TemaPadre = Relacion[0].SuperTema;
                    }
                    //SubTemas
                    Relacion = relacTemas.ObtenerSubTemas(result.IdTema);
                    if (Relacion.Rows.Count > 0)
                    {
                        foreach (DataSet1.TLB_RelacionTemasRow F in Relacion)
                        {
                            Fila = temas.SeleccionarTema(F.SubTema);
                            foreach (DataSet1.TLB_TemaRow Fi in Fila)
                            {
                                result.FSubtemas.Add(Fi.Tema);
                            }
                        }
                    }
                    //Palabras Claves
                    DataSet1.TLB_PalabraClaveDataTable palabraClvTable = palabraClave.BuscarPalabrasRelacionadasConTema(result.IdTema);
                    foreach (DataSet1.TLB_PalabraClaveRow i in palabraClvTable)
                    {
                        result.PalabrasClaves.Add(i.Palabra);
                    }
                }

                return result;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public InformacionPersistente ObtenerDatosTema(int IdTema)
        {
            DataSet1TableAdapters.TLB_TemaTableAdapter temas = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1.TLB_TemaDataTable Fila = temas.SeleccionarTema(IdTema);
            try { return MostrarDatosTema(Fila[0].Tema); }
            catch { throw new Exception("No existe ningún tema con esas características"); }
        }
        public void ActualizarRelacionUserTema(DateTime Fecha, string idUsuario, string Tema)
        {
            try
            {
                DataSet1.TLB_TemaDataTable datosTema = new DataSet1TableAdapters.TLB_TemaTableAdapter().DatosTema(Tema);
                int IdTema = 0;
                if (datosTema.Rows.Count > 0)
                {
                    IdTema = datosTema[0].Id_Tema;
                    DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
                    DataSet1.TLB_RelacionUserTemaDataTable TablaDatos = Tabla.ObtenerDatos(IdTema, idUsuario, Fecha);
                    if (TablaDatos.Rows.Count == 0)
                    {
                        Tabla.Insert(Fecha, IdTema, idUsuario, 1);
                    }
                    else
                    {
                        Tabla.ActualizarContador(TablaDatos[0].Contador++, IdTema, idUsuario, Fecha);
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public string[] BuscarPorPalabra(string palabra)
        {
            try
            {
                string[] ArregloPalabras = palabra.Split(';');

                //tabla palabra
                DataSet1TableAdapters.TLB_PalabraClaveTableAdapter Palabras = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
                DataSet1.TLB_PalabraClaveDataTable PalabrasClaves = new DataSet1.TLB_PalabraClaveDataTable();

                //relacion tema palabra
                DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter RelacionTemaPalabra = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
                DataSet1.TLB_Tema_TLB_PalabraClaveDataTable TablaRelacionTemaPalabraClave = new DataSet1.TLB_Tema_TLB_PalabraClaveDataTable();

                //Tabla temas
                DataSet1TableAdapters.TLB_TemaTableAdapter Temas = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
                DataSet1.TLB_TemaDataTable DatosTemas = new DataSet1.TLB_TemaDataTable();

                //----------------------------
                List<string> ListaNombreTemas = new List<string>();
                foreach (string pal in ArregloPalabras)
                {
                    PalabrasClaves = Palabras.BuscarPalabraClave(pal);
                    foreach (DataSet1.TLB_PalabraClaveRow PalClave in PalabrasClaves)
                    {
                        TablaRelacionTemaPalabraClave = RelacionTemaPalabra.ObtenerIdTema_IdPalabra(PalClave.Id_Palabra);
                        foreach (DataSet1.TLB_Tema_TLB_PalabraClaveRow TemaPalClave in TablaRelacionTemaPalabraClave)
                        {
                            DatosTemas = Temas.SeleccionarTema(TemaPalClave.Id_Tema);
                            foreach (DataSet1.TLB_TemaRow R in DatosTemas)
                            {
                                ListaNombreTemas.Add(R.Tema);
                            }
                        }
                    }
                }
                return ListaNombreTemas.ToArray();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        /*******************************************************************************************************/
        public bool InsertarHistoricoEntidad(EntidadPersistente entidadP)
        {
            DataSet1TableAdapters.TLB_HistoricoEntidadesTableAdapter hent = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoEntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();
            hent.Fill(ds1.TLB_HistoricoEntidades);

            DataSet1.TLB_HistoricoEntidadesDataTable HistEnt = hent.BuscarNombre(entidadP.Nombre);

            if (HistEnt.Count == 0)
            {
                //creo entRow
                DataSet1.TLB_HistoricoEntidadesRow entRow = ds1.TLB_HistoricoEntidades.NewTLB_HistoricoEntidadesRow();
                entRow.SitioWeb = "";
                entRow.correoElectronico = "";

                //lleno los campos de la fila
                entRow.CodAntSucursal = entidadP.CodigoAnterior;
                entRow.nombre = entidadP.Nombre;
                entRow.Direccion = entidadP.Direccion;
                entRow.Fax = entidadP.Fax;
                entRow.Telefono = entidadP.Telefono;
                foreach (string i in entidadP.CorreoElectronico)
                    entRow.correoElectronico += i + ";";
                foreach (string i in entidadP.SitiosWeb)
                    entRow.SitioWeb += i + ";";
                entRow.CodActual = entidadP.Codigo;

                //agrego entRow a la Tabla
                ds1.TLB_HistoricoEntidades.AddTLB_HistoricoEntidadesRow(entRow);

                hent.Update(ds1.TLB_HistoricoEntidades);
                return true;
            }
            return false;
        }

        #endregion

        //********************** Funciones Auxiliares ***********************************
        private string IdDatoToString(string id)
        {
            if (id.Length < 2)
            {
                string aux = "0";
                aux += id;
                return aux;
            }
            else
                return id;
        }
        //*******************************************************************************
        /* private string[][] asu()
         {
             string[][] result = new string[4][];
             for (int i = 0; i < 4; i++)
             {
                 result[i] = new string[] { i.ToString(), "sucursal" + i.ToString() };
             }
             return result;
         }*/
        public List<string> ActualizarSucursales()
        {
            List<string> result = new List<string>();
            List<BancoPersistente> listB = ObtenerListaBanco();
            WSBanco.Service ws = new WSBanco.Service();
            foreach (BancoPersistente banco in listB)
            {
                ws.Url = banco.WebServices;
                DataSet1.TLB_SucursalDataTable su = new DataSet1.TLB_SucursalDataTable();
                try
                {
                    su = new DataSet1TableAdapters.TLB_SucursalTableAdapter().GetData();
                }
                catch (Exception)
                {
                    result.Add(banco.Nombre + ": error de conexión con la BD");
                }
                try
                {
                    //Esta funcion no esta en el webservice*********.
                    string[][] sucursales=new string[1][]; //= ws.ActualizarSucursales();

                    for (int i = 0; i < sucursales.Length; i++)
                    {
                        DataSet1.TLB_SucursalRow sucR = su.NewTLB_SucursalRow();
                        sucR.NoSucursal = sucursales[i][0];
                        sucR.Nombre = sucursales[i][1];
                        try
                        {
                            su.AddTLB_SucursalRow(sucR);
                        }
                        catch
                        { }
                    }
                    try
                    {
                        new DataSet1TableAdapters.TLB_SucursalTableAdapter().Update(su);
                    }
                    catch (Exception)
                    {
                        result.Add(banco.Nombre + ": error de conexión con la BD");
                    }
                }
                catch (Exception)
                {
                    result.Add(banco.Nombre + ": error de conexión con el WS");
                }
            }

            return result;
        }

        //**//Modificacion mostrar el monto de etecsa 22/04/2008
        public string ProcesarFicheroEtecsa(string idTelefono)
        {
            string line;
            string MontoaPagar = "";
            string idTelefono01;
            StreamReader st = null;
            try
            {
                try
                {
                     st = new StreamReader("C:\\Etecsa\\TBR103.txt", Encoding.Default);
                }
                catch(Exception ex)
                {
                    MontoaPagar = "";
                    this.GuardarNotificacion(ex.Message.ToString(), "Administrador");
                    return MontoaPagar;
                    
                }
                line = st.ReadLine();
                while (line.Length >= 15 && line.Length <= 175)
                {
                    //aux = new PagoComplejo();
                    // Tipo de Servicio – 2 posiciones (información llave)
                    //// aux.Tipo = line.Substring(0, 2);
                    //Identificador del cliente – 13 posiciones (información llave)
                    //// aux.Identificador = line.Substring(2, 13);
                    idTelefono01 = line.Substring(2, 15);
                    if (idTelefono == idTelefono01)
                    {
                        MontoaPagar = line.Substring(39, 16);
                    }


                    line = st.ReadLine();
                    if (line == null)
                        line = "fin";
                }
                if (MontoaPagar == "") MontoaPagar =" No encontrado";
                else MontoaPagar = MontoaPagar;
            }
            catch (Exception ex)
            {
                st.Close();
                this.GuardarNotificacion(ex.Message.ToString(), "Administrador");
                MontoaPagar = "";
                return MontoaPagar;


            }
            st.Close();
            return MontoaPagar;
        }
        //******************************************************


        ////Modificacion para que envie automaticamente operaciones de multas en estado T:2 
        //que sean confirmadas 23/04/08
        public DataSet OperacionesMultasxConfirmar()
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("SELECT * FROM TLB_MultasPendientes where confirmado = 'N'", myConection);
            mycommand.CommandType = CommandType.Text;
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_MultasPendientes");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }

        public DataSet OperacionesEnFicheroxCI(string CI)
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("SELECT ID,id_asociado,importe,informativo FROM TLB_PagoComplejo WHERE (ID_SERV = '04') and ltrim(rtrim(id_asociado)) = '"+CI+"'", myConection);
            mycommand.CommandType = CommandType.Text;
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_PagoComplejo");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }

        public void ModificarOperacionesMultasPendientes(string id_transaccion)
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            string sSQL = "UPDATE TLB_MultasPendientes SET Confirmado='S', FechaConfirmado='" + DateTime.Now.Date + "' where Id_Transaccion='" + id_transaccion + "'";
            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            try
            {
                SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
                myconexion.Open();

                mycomand.ExecuteNonQuery();
            }

            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {
                myconexion.Close();
            }

        }

        public void EliminarOperacionesdePagoComplejo(string ID)
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            string sSQL = "Delete from TLB_PagoComplejo where ID='" + ID + "'";
            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            try
            {
                SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
                myconexion.Open();

                mycomand.ExecuteNonQuery();
            }

            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {
                myconexion.Close();
            }

        }

        //metodo para confirmar al banco las operaciones
        public bool EnviarOperacionesConfirmadas(DataSet Operaciones)
        {
            
            WSBanco.Service ws = new WSBanco.Service();
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());

            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            ws.Url = bnk.WebServices;
            string[] Resp =  ws.MultasT2(Operaciones);
            if (Resp[0].ToString() == "0") return true;
            else return false;
           
        }

        //************************************************************************************

        //Metodo para obtener las tarjetas a reimprimir 10 junio 2008
        public void ConfirmarReimpresion()
        {
            DataSet Pedidas = new DataSet();
            WSBanco.Service ws = new WSBanco.Service();
            BancoPersistente bnk;
            List<string> tarjetas = new List<string>();
            try
            {

                bnk = GetBancoDadoID(this.N_CLlamadas());
                ws.Url = bnk.WebServices;
                Pedidas = this.TarjetasReimpresion();
                foreach (DataRow row in Pedidas.Tables[0].Rows)
                { 
                    tarjetas.Add(row[0].ToString());
                }
                string[] Resp = ws.ConfirmarReimpresion(tarjetas.ToArray());
                int cantidad = tarjetas.Count;
                this.GuardarNotificacion("Se procesaron "+cantidad.ToString()+" tarjeta(s) para reimpresion", "Operadora de Autenticación");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ConfirmarDesabilitadas()
        {
            DataSet Pedidas = new DataSet();
            WSBanco.Service ws = new WSBanco.Service();
            BancoPersistente bnk;
            List<string> tarjetas = new List<string>();
            try
            {

                bnk = GetBancoDadoID(this.N_CLlamadas());
                ws.Url = bnk.WebServices;
                Pedidas = this.TarjetasDesabilitadas();
                foreach (DataRow row in Pedidas.Tables[0].Rows)
                {
                    tarjetas.Add(row[0].ToString());
                }
                string[] Resp = ws.ConfirmarCanceladas(tarjetas.ToArray());
                int cantidad = tarjetas.Count;
                this.GuardarNotificacion("Se procesó " + cantidad.ToString() + " tarjeta(s) para deshabilitar", "Operadora de Autenticación");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataSet TarjetasReimpresion()
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("SELECT Id_NoTarjeta FROM TLB_Tarjeta where Estado = 'P'", myConection);
            mycommand.CommandType = CommandType.Text;
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_Tarjetas");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }

        public DataSet TarjetasDesabilitadas()
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("SELECT Id_NoTarjeta FROM TLB_Tarjeta where Estado = 'D'", myConection);
            mycommand.CommandType = CommandType.Text;
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_Tarjetas");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }

        public void ReversarOperacion(string Id_Transaccion, string Operador)
        {
            //int result;
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myconection = new SqlConnection(stringConection);
            SqlCommand mycommand = new SqlCommand("sp_ReversarOperacion", myconection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@Id_Transaccion", Id_Transaccion);
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
        }
        public string Desencriptar(string pin)
        {
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myconection = new SqlConnection(stringConection);
            SqlCommand mycommand = new SqlCommand("sp_Desencryt_PIN", myconection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@pin0", SqlDbType.NVarChar, 4000);
            mycommand.Parameters[0].Direction = ParameterDirection.Input;
            mycommand.Parameters[0].Value = pin;
            mycommand.Parameters.Add("@PINE", SqlDbType.NVarChar, 4000);
            mycommand.Parameters[1].Direction = ParameterDirection.Output;
            mycommand.Parameters[1].Value = "";

            try
            {
             
                myconection.Open();
                mycommand.ExecuteNonQuery();
                string clave = mycommand.Parameters[1].Value.ToString();
                return clave;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myconection.Close();
            }
        }

        //Limpiar datos de TLB_Transaccion
        public bool LimpiarTLB_Transaccion(int anno)
        {
            string satisfactorio="1";
            DataSet1 ds1 = new DataSet1();
            DataSet1TableAdapters.TLB_Limpiar_TransaccionTableAdapter salvar = new DataAccessLayer.DataSet1TableAdapters.TLB_Limpiar_TransaccionTableAdapter();
            salvar.sp_LimpiarTLB_Transaccion(anno, ref satisfactorio);
            return Convert.ToBoolean(satisfactorio);


        }

        public bool DesactivarUsuario(string usuario)
        {
            bool terminado = false;
            DataSet1TableAdapters.TLB_Historico_de_ContrasenaTableAdapter user = new DataAccessLayer.DataSet1TableAdapters.TLB_Historico_de_ContrasenaTableAdapter();
            user.sp_DesactivarUsuario(usuario);   
            terminado=true;
            return terminado;
        }

        public bool BloqueaUsuario(string usuario, string descripcion)
        {
            bool terminado = false;
            DataSet1TableAdapters.TLB_AccionesUsuarioTableAdapter user = new DataAccessLayer.DataSet1TableAdapters.TLB_AccionesUsuarioTableAdapter();
            user.sp_Insertar_quien_bloquea(usuario, descripcion);  
            terminado=true;
            return terminado;
        }
        
        public bool Desbloquearusuario(string usuario)
        {
            bool result = false;
            try
            {
            
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("UPDATE TLB_Usuario SET Activo = 1 WHERE usuario='" + usuario + "'", myConection);
            //mycommand.CommandType = CommandType.Text;
            
            myConection.Open();
            mycommand.ExecuteNonQuery();
            result = true;
            }

            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }

            return result;
        }
        public DataSet Fecha_Expira(string usuario)
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);
            SqlCommand mycommand = new SqlCommand("select top(1) fecha_expira from TLB_Historico_de_Contrasena where usuario='" + usuario + "' order by fecha_expira desc", myConection);
            mycommand.CommandType = CommandType.Text;
            DataSet DS = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
                adapter.Fill(DS, "TLB_Historico_de_Contrasena");

            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            return DS;
        }


        //Copiar fichero electrica a metro
        public bool CopiarFicheroaFTPMetro(string FileName, string DirFTP)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;
            try
            {
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(DirFTP);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                // UploadFile is not supported through an Http proxy
                // so we disable the proxy for this request.
                uploadRequest.Proxy = null;
                uploadRequest.Credentials = new NetworkCredential("osmel", "metrobanca");


                requestStream = uploadRequest.GetRequestStream();
                //uploadRequest.BeginGetRequestStream(new AsyncCallback(EndGetStreamCallback), state);

                fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read);

                byte[] buffer = new byte[1024];
                int bytesRead;
                while (true)
                {
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    requestStream.Write(buffer, 0, bytesRead);
                }

                // The request stream must be closed before getting 
                // the response.
                requestStream.Close();

                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                //Console.WriteLine("Upload complete.");
                GuardarNotificacion("Upload complete.", "Operadora de Autenticacion");
                //MessageBox.Show("Upload complete.");
                return true;
            }
            catch (UriFormatException ex)
            {
                // Console.WriteLine(ex.Message);
                GuardarNotificacion(ex.Message, "Operadora de Autenticacion");
                // MessageBox.Show(ex.ToString());
                return false;
            }
            catch (IOException ex)
            {
                // Console.WriteLine(ex.Message);
                GuardarNotificacion(ex.Message, "Operadora de Autenticacion");
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (WebException ex)
            {
                // Console.WriteLine(ex.Message);

                string status = ((FtpWebResponse)ex.Response).StatusDescription;
                GuardarNotificacion(status, "Operadora de Autenticacion");
                return false;
                //MessageBox.Show(status);
            }
            catch (Exception ex)
            {
                GuardarNotificacion(ex.Message, "Operadora de Autenticacion");
                return false;
            }
            finally
            {
                if (uploadResponse != null)
                    uploadResponse.Close();
                if (fileStream != null)
                    fileStream.Close();
                if (requestStream != null)
                    requestStream.Close();
            }

        }

        public bool ModificarFechaContable_TLB_Configuracion(DateTime nueva_fecha)
        {
            bool success = false;
            try
            {
                string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
                SqlConnection myConection = new SqlConnection(StringConection);
                SqlCommand mycommand = new SqlCommand("UPDATE dbo.TLB_Configuración SET FechaContable ='" + nueva_fecha + "'", myConection);
                //mycommand.CommandType = CommandType.Text;

                myConection.Open();
                mycommand.ExecuteNonQuery();
                success = true;
            }
            catch (SqlException)
            {

                throw;
            }
            return success;
        }

        #region<08.01.2020: Copia del metodo Descargar_Fichero_BD: anterior. En este no se le pasa el usuario que esta cargando el servicio>

        public bool Descargar_Fichero_BD(string downloadFTP, string SaveToDirectoryBD, string loadBD, string UserFtp, string PassFtp, string codigoservicio, out string mensaje)
        {
            // ejemplo de los parametros que se le pasa al sp
            //@downloadUrl = N'ftp://192.168.22.13/ONAT/onat/E032018.txt',
            //@SaveToDirectory = N'C:\\Empresas\\03',
            //@loadUrl = N'C:\\Empresas\\03\\E032018.txt',
            //@UserFtp = N'Telebanca',
            //@PassFtp = N'Metro*2017',
            //@idServicio = N'03',

            bool result = false;
            mensaje = "";
            int valor_retorno = 0;
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
            SqlConnection myconection = new SqlConnection(stringConection);

            //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;                
            SqlCommand mycommand = new SqlCommand("SSP_DESCARGAR_FTP", myconection);// sp en telebanca que dentro tiene el sp generado x el ensamblado
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@downloadUrl", downloadFTP);

            mycommand.Parameters.AddWithValue("@SaveToDirectory", SaveToDirectoryBD);
            mycommand.Parameters.AddWithValue("@loadUrl", loadBD);
            mycommand.Parameters.AddWithValue("@UserFtp", UserFtp);
            mycommand.Parameters.AddWithValue("@PassFtp", PassFtp);
            mycommand.Parameters.AddWithValue("@idServicio", codigoservicio);

            mycommand.Parameters.Add("@Wret", SqlDbType.Int, 2);
            mycommand.Parameters[6].Direction = ParameterDirection.Output;
            mycommand.Parameters[6].Value = 0;

            mycommand.Parameters.Add("@WCuenta", SqlDbType.VarChar, 1000);
            mycommand.Parameters[7].Direction = ParameterDirection.Output;
            mycommand.Parameters[7].Value = "";

            mycommand.CommandTimeout = 1800;
            try
            {
                myconection.Open();
                mycommand.ExecuteNonQuery();

                //Convert.ToInt32(mycommand.Parameters["@Wret"].Value) != 0

                mensaje = mycommand.Parameters["@WCuenta"].Value.ToString();
                valor_retorno = int.Parse(mycommand.Parameters["@WRet"].Value.ToString());
                if (!mensaje.Contains("Error") && valor_retorno == 0)
                    result = true;

                //result = Convert.ToInt32(mycommand.Parameters["@idSupplier"].Value);
            }
            catch (SqlException e)
            {
                ///*escribir en el log*/

                //mensaje = e.Message;
                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "Descargar_Fichero_BD \n";
                //    string nombre_proyecto = "(DataAccesLayer): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                //}

                result = false;

                //throw new Exception();
            }
            finally
            {

                myconection.Close();
            }


            return result;

        }

        #endregion

        #region<08.01.2020: Raul: Nuevo Descargar_Fichero_BD: agregarle parametro del usuario que esta cargando el servicio>
        //public bool Descargar_Fichero_BD(string downloadFTP, string SaveToDirectoryBD, string loadBD, string UserFtp, string PassFtp, string codigoservicio, string usuario_supervisor, out string mensaje)
        //{
        //    // ejemplo de los parametros que se le pasa al sp
        //    //@downloadUrl = N'ftp://192.168.22.13/ONAT/onat/E032018.txt',
        //    //@SaveToDirectory = N'C:\\Empresas\\03',
        //    //@loadUrl = N'C:\\Empresas\\03\\E032018.txt',
        //    //@UserFtp = N'Telebanca',
        //    //@PassFtp = N'Metro*2017',
        //    //@idServicio = N'03',
            
        //    bool result = false;
        //    mensaje = "";
        //    int valor_retorno = 0;
        //    string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
        //    SqlConnection myconection = new SqlConnection(stringConection);

        //    //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;                
        //    SqlCommand mycommand = new SqlCommand("SSP_DESCARGAR_FTP", myconection);// sp en telebanca que dentro tiene el sp generado x el ensamblado
        //    mycommand.CommandType = CommandType.StoredProcedure;
        //    mycommand.Parameters.AddWithValue("@downloadUrl", downloadFTP);

        //    mycommand.Parameters.AddWithValue("@SaveToDirectory", SaveToDirectoryBD);
        //    mycommand.Parameters.AddWithValue("@loadUrl", loadBD);
        //    mycommand.Parameters.AddWithValue("@UserFtp", UserFtp);
        //    mycommand.Parameters.AddWithValue("@PassFtp", PassFtp);
        //    mycommand.Parameters.AddWithValue("@idServicio", codigoservicio);
        //    mycommand.Parameters.AddWithValue("@usuario_supervisor", usuario_supervisor);

        //    mycommand.Parameters.Add("@Wret", SqlDbType.Int, 2);
        //    mycommand.Parameters[7].Direction = ParameterDirection.Output;
        //    mycommand.Parameters[7].Value = 0;

        //    mycommand.Parameters.Add("@WCuenta", SqlDbType.VarChar, 1000);
        //    mycommand.Parameters[8].Direction = ParameterDirection.Output;
        //    mycommand.Parameters[8].Value = "";

        //    mycommand.CommandTimeout = 1800;
        //    try
        //    {
        //        myconection.Open();
        //        mycommand.ExecuteNonQuery();

        //        //Convert.ToInt32(mycommand.Parameters["@Wret"].Value) != 0

        //        mensaje = mycommand.Parameters["@WCuenta"].Value.ToString();
        //        valor_retorno = int.Parse(mycommand.Parameters["@WRet"].Value.ToString());
        //        if (!mensaje.Contains("Error") && valor_retorno == 0)
        //            result = true;

        //        //result = Convert.ToInt32(mycommand.Parameters["@idSupplier"].Value);
        //    }
        //    catch (SqlException e)
        //    {
        //        ///*escribir en el log*/

        //        //mensaje = e.Message;
        //        //string path = @"C:\Logs_Telebanca\log_error.txt";

        //        //using (TextWriter writer = File.AppendText(path))
        //        //{
        //        //    string separador = " : ";
        //        //    string metodo_error = "Descargar_Fichero_BD \n";
        //        //    string nombre_proyecto = "(DataAccesLayer): ";
        //        //    string date = DateTime.Now.ToString() + " \n";
        //        //    string separa = "-------------------------------------------------------";
        //        //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
        //        //}

        //        result = false;

        //        //throw new Exception();
        //    }
        //    finally
        //    {

        //        myconection.Close();
        //    }


        //    return result;

        //}

        #endregion

        public bool Ftp_Download(String downloadUrl, String SaveToDirectory, String UserFtp, String PassFtp)
        {
            bool result = false;
            Stream responseStream = null;
            FileStream fileStream = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(downloadUrl);
                downloadRequest.Credentials = new NetworkCredential(UserFtp, PassFtp);
                downloadRequest.Timeout = 60000;
                downloadRequest.UsePassive = false;
                FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse();
                responseStream = downloadResponse.GetResponseStream();

                string fileName = Path.GetFileName(downloadRequest.RequestUri.AbsolutePath);
                if (fileName.Length == 0)
                {
                    reader = new StreamReader(responseStream);
                    SqlContext.Pipe.Send(reader.ReadToEnd());
                }
                else
                {
                    fileStream = File.Create(SaveToDirectory + "\\" + fileName);
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while (true)
                    {
                        bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                            break;
                        else
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            result = true;
                        }
                        
                    }
                    //OK = 1;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                else if (responseStream != null)
                    responseStream.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        public DataSet Calcular_TipoCambio(DateTime fecha)
        {            
            DataSet tc = new DataSet();
           
            try
            {
                WSBanco.Service ws = new Service();

                tc = ws.TipoCambio(fecha);

                if (tc.Tables[0].Rows.Count == 0)
                    throw new Exception("Fallo al obtener Tipo Cambio del SABIC");
            }                        
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tc;
        }

        //public DataSet Datos_MTARJ(string tarjeta, string num_ideper)
        //{
        //    DataSet resultado = new DataSet();
        //    BancoPersistente bnk;
        //    try
        //    {
        //        //WSBanco.Service ws = new Service();
        //        //ws.Url = bnk.WebServices;
                
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return resultado;
        //}

        public DataSet TarjetasMagneticas_Cliente(string numideper, string codtipi, string idpais)
        {
            DataSet tm = new DataSet();
           
            try
            {
                WSBanco.Service ws = new Service();

                tm = ws.GetTarjetasMagneticas_Cliente(numideper, codtipi, idpais);

                if (tm.Tables[0].Rows.Count == 0)
                    throw new Exception("Fallo al obtener las tarjetas magneticas que tiene asociada el cliente");
            }                        
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tm;
            
        }

        // Raul: <11.02.2020> nueva funcionalidad: Solicitud Pin Digital. Se ejecuta SP en SQL Telebanca
        public DataSet Solicitud_PinDigital_Magnetica(string tarjetaBT, string tarjetaPAN)
        {
            DataSet resultado_activacion = new DataSet();

            try
            {
                string stringConection_Telebanca = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
                SqlConnection myconection = new SqlConnection(stringConection_Telebanca);

                SqlCommand comando1 = new SqlCommand("SSP_BT_SOLICITUD_PINMAGNETICA", myconection);
                comando1.CommandType = CommandType.StoredProcedure;
                
                //especificar los parametros que se les pasara al SP
                comando1.Parameters.AddWithValue("@TARJETA_TELEBANCA", tarjetaBT);
                comando1.Parameters.AddWithValue("@TARJETA_MAGNETICA", tarjetaPAN);

                comando1.Parameters.Add("@COORD_PIN", SqlDbType.VarChar, 7); // de salida 
                comando1.Parameters[2].Direction = ParameterDirection.Output;
                comando1.Parameters[2].Value = "";

                comando1.Parameters.Add("@WRET", SqlDbType.Int, 2); // de salida 
                comando1.Parameters[3].Direction = ParameterDirection.Output;
                comando1.Parameters[3].Value = 0;

                comando1.Parameters.Add("@WMENSAJE", SqlDbType.VarChar, 200); // de salida 
                comando1.Parameters[4].Direction = ParameterDirection.Output;
                comando1.Parameters[4].Value = "";

                //crear el adaptador que me va a llenar el DataSet
                SqlDataAdapter adaptador = new SqlDataAdapter(comando1);
                adaptador.Fill(resultado_activacion);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado_activacion;
        }
    }
}
