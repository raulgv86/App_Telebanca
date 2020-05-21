using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Navegador
/// </summary>
public class Navegador
{
    public Navegador()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void RedirectToPopUp(UserControl pActiveControl, string pPage)
    {
        string popupScript = "<script language='javascript'>" +
                             "PopURL='" + pPage + "';" +
                             "MyWin = PopWinOpen(800, 600);" +
                             "MyWin.focus();" +
                             "</script>";

        pActiveControl.Page.RegisterStartupScript("PopupScript", popupScript);
    }

    public static void RedirectToPopUp(Page pActivePage, string pPage)
    {
        string popupScript = "<script language='javascript'>" +
                             "window.open('" + pPage + "', 'CustomPopUp', " +
                             "'width=800, height=600%, menubar=yes, resizable=yes,alwaysRaised=yes')" +
                             "</script>";

        pActivePage.RegisterStartupScript("PopupScript", popupScript);
    }
}
