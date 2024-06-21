using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Session["Usuario"] is EntidadesCompartidas.Usuario)) //Si el objeto no es de tipo usuario se redirecciona al formulario default
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }
}
