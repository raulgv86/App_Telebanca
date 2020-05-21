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
/// Clase para la manipulaci�n de los errores
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
    /// Constructor v�lido para la captura de las confirmaciones en las P�ginas.
    /// </summary>
    /// <param name="pPage">Instancia de la p�gina que contiene los componentes de manipulaci�n de errores.</param>
    public Errores(Page pPage)
    {
        aPage = pPage;
        Mensajes = (BunnyBear.msgBox)aPage.FindControl("Mensajes");
        HdnWhoConfirm = (HtmlInputHidden)aPage.FindControl("HdnWhoConfirm");
        HdnConfirm = (HtmlInputHidden)aPage.FindControl("HdnConfirm");
    }

    /// <summary>
    /// Constructor v�lido para el lanzamiento de las confirmaciones en los WebUserControls.
    /// </summary>
    /// <param param name="pControl">Instancia del WebUserControl que contiene el m�todo a utilizar.</param>
    public Errores(UserControl pControl)
    {
        aPage = pControl.Page;
        aControl = pControl;
        Mensajes = (BunnyBear.msgBox)aPage.FindControl("Mensajes");
        HdnWhoConfirm = (HtmlInputHidden)aPage.FindControl("HdnWhoConfirm");
        HdnConfirm = (HtmlInputHidden)aPage.FindControl("HdnConfirm");
    }

    #endregion 
 
    #region M�todos

    /// <summary>
    /// M�todo para el lanzamiento de mensajes de error y alertas
    /// </summary>
    /// <param name="pControl">WebUserControl desde donde se lanzar� el error o la alerta</param>
    /// <param name="pMensaje">Texto del Mensaje que ser� lanzado</param>
    public static void Alert(UserControl pControl, string pMensaje)
    {
        ((BunnyBear.msgBox)pControl.Page.FindControl("Mensajes")).alert(pMensaje);        
    }

    /// <summary>
    /// M�todo para el lanzamiento de mensajes de error y alertas
    /// </summary>
    /// <param name="pPage">P�gina desde donde se lanzar� el error o la alerta</param>
    /// <param name="pMensaje">Texto del Mensaje que ser� lanzado</param>
    public static void Alert(Page pPage, string pMensaje)
    {
        ((BunnyBear.msgBox)pPage.FindControl("Mensajes")).alert(pMensaje);
    }

    /// <summary>
    /// M�todo destinado al lanzamiento de confirmaciones
    /// </summary>
    /// <param name="pMensaje">Texto del Mensaje que ser� lanzado</param>
    /// <param name="pMethodToRedirect">Nombre del m�todo que ser� invocado si la confirmaci�n es positiva</param>
    public void Confirmar(string pMensaje, string pMethodToRedirect)
    {
        
        MethodToRedirect = aControl.ID + "." + pMethodToRedirect;
        HdnWhoConfirm.Value = MethodToRedirect;
        Mensajes.confirm(pMensaje, "HdnConfirm");
        
    }


    /// <summary>
    /// M�todo utilizado para la captura de la Respuesta de una la confirmaci�n...
    /// </summary>
    /// <returns>Devuelve el resultado de la confirmaci�n.</returns>
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
