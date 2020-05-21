using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BunnyBear;



/// <summary>
/// Clase para la manipulación de los errores
/// Se divide en:  
///         - Lanzamiento de mensajes de error y alertas 
///         - Lanzamiento de Confirmaciones 
/// </summary>
/// 
public class Errores
{

    #region Atributos Privados

    private Page aPage;
    private UserControl aControl;
    private BunnyBear.msgBox Mensajes;
    private HtmlInputHidden HdnWhoConfirm;
    private HtmlInputHidden HdnConfirm;
    private bool ConfirmResult;
    private string MethodToRedirect;

    #endregion 
    
    #region Contructores

    /// <summary>
    /// Constructor válido para la captura de las confirmaciones en las Páginas.
    /// </summary>
    /// <param name="pPage">Instancia de la página que contiene los componentes de manipulación de errores.</param>
    public Errores(Page pPage)
    {
        aPage = pPage;
        Mensajes = (BunnyBear.msgBox)aPage.FindControl("Mensajes");
        HdnWhoConfirm = (HtmlInputHidden)aPage.FindControl("HdnWhoConfirm");
        HdnConfirm = (HtmlInputHidden)aPage.FindControl("HdnConfirm");
    }

    /// <summary>
    /// Constructor válido para el lanzamiento de las confirmaciones en los WebUserControls.
    /// </summary>
    /// <param param name="pControl">Instancia del WebUserControl que contiene el método a utilizar.</param>
    public Errores(UserControl pControl)
    {
        aPage = pControl.Page;
        aControl = pControl;
        Mensajes = (BunnyBear.msgBox)aPage.FindControl("Mensajes");
        HdnWhoConfirm = (HtmlInputHidden)aPage.FindControl("HdnWhoConfirm");
        HdnConfirm = (HtmlInputHidden)aPage.FindControl("HdnConfirm");
    }

    #endregion 
 
    #region Métodos

    /// <summary>
    /// Método para el lanzamiento de mensajes de error y alertas
    /// </summary>
    /// <param name="pControl">WebUserControl desde donde se lanzará el error o la alerta</param>
    /// <param name="pMensaje">Texto del Mensaje que será lanzado</param>
    public static void Alert(UserControl pControl, string pMensaje)
    {
        ((BunnyBear.msgBox)pControl.Page.FindControl("Mensajes")).alert(pMensaje);        
    }

    /// <summary>
    /// Método para el lanzamiento de mensajes de error y alertas
    /// </summary>
    /// <param name="pPage">Página desde donde se lanzará el error o la alerta</param>
    /// <param name="pMensaje">Texto del Mensaje que será lanzado</param>
    public static void Alert(Page pPage, string pMensaje)
    {
        ((BunnyBear.msgBox)pPage.FindControl("Mensajes")).alert(pMensaje);
    }

    /// <summary>
    /// Método destinado al lanzamiento de confirmaciones
    /// </summary>
    /// <param name="pMensaje">Texto del Mensaje que será lanzado</param>
    /// <param name="pMethodToRedirect">Nombre del método que será invocado si la confirmación es positiva</param>
    public void Confirmar(string pMensaje, string pMethodToRedirect)
    {
        
        MethodToRedirect = aControl.ID + "." + pMethodToRedirect;
        HdnWhoConfirm.Value = MethodToRedirect;
        Mensajes.confirm(pMensaje, "HdnConfirm");
        
    }


    /// <summary>
    /// Método utilizado para la captura de la Respuesta de una la confirmación...
    /// </summary>
    /// <returns>Devuelve el resultado de la confirmación.</returns>
    public bool CapturarConfirmacion()
    {
        ConfirmResult = aPage.Request.Form["HdnConfirm"] == "1";
        if (ConfirmResult)
        {

            MethodToRedirect = aPage.Request.Form["HdnWhoConfirm"];
            //aControl = (UserControl)aPage.FindControl(MethodToRedirect.Split('.')[0]);
            MethodToRedirect = MethodToRedirect.Split('.')[1];
            Type TempClass = aControl.GetType();
            TempClass.GetMethod(MethodToRedirect).Invoke(aControl, null);
            aPage.Request.Form["HdnConfirm"].Replace("1", "0");
        }
        return ConfirmResult;
    }

    public static string FiltrarMensaje(string pMessage)
    {
        string[] TempList = pMessage.Split(new string[1] { "--->" }, StringSplitOptions.RemoveEmptyEntries);
        string Result = (TempList.Length > 1) ? TempList[1] : TempList[0];
        TempList = Result.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        Result = TempList[0];
        Result = Result.Substring(Result.IndexOf(":") + 2);
        return Result; 
    }
    #endregion 
    
}
