using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;
public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }
    protected void BtnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Usuario uUsuario = LogicaUsuario.Logueo(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
            if (uUsuario != null)
            {
                Session["Usuario"] = uUsuario;
                //Si existe el usuario me redicciona al formulario principal
                Response.Redirect("Principal.aspx");
            }
            else if (txtUsuario.Text == "")
            {
                lblError.Text = "Debe ingresar Usuario";
            }
            else if (txtContraseña.Text=="")
            {
                lblError.Text = "Debe ingresar Contraseña";
            }
            else
            {
                txtContraseña.Text = "";
                txtUsuario.Text = "";
                lblError.Text = "Datos Incorrectos";
            }
        }
        catch (Exception ex)
        {
            //Mensaje de error
            lblError.Text = ex.Message;
        }
    }
}