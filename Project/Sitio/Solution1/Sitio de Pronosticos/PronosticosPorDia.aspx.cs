using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;
public partial class PronosticosPorDia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        try
        {
            DateTime Fecha = ClrFecha.SelectedDate.Date;
            List<Pronostico> pPronosticosFecha = LogicaPronostico.ListarPronostico_Fecha(Fecha);
            if (pPronosticosFecha.Count == 0)
            {
                lblError.Text = "No hay pronosticos registrados para dicha fecha";
            }

            Session["ListaPronosticos_Fecha"] = pPronosticosFecha;
            lblPronostico.Visible = true;
            lblPronostico.Text = "Se registraron "+ pPronosticosFecha.Count+ " pronosticos para la fecha " + Fecha.ToShortDateString();
            GvPronostico.DataSource = pPronosticosFecha;
            GvPronostico.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void GvPronostico_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPronostico.PageIndex = e.NewPageIndex;
        GvPronostico.DataSource = (List<Pronostico>)Session["ListaPronosticos_Fecha"];
        GvPronostico.DataBind();
    }

}