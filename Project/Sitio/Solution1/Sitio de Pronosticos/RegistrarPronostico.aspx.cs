using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//Referencias
using EntidadesCompartidas;
using Logica; 

public partial class RegistrarPronostico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ListaCiudades"]= LogicaCiudad.ListarCiudad();
            GvCiudad.DataSource = LogicaCiudad.ListarCiudad(); //Cargo Ciudades en la GV
            GvCiudad.DataBind();
            this.LimpiarFormulario();
        }
    }
    private void LimpiarFormulario()
    {
        ClrFecha.SelectedDates.Clear();
        GvCiudad.SelectedIndex = -1;
        txtMaxima.Text = "";
        txtMinima.Text = "";
        txtViento.Text = "";
        txtProbabilidad.Text = "";
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }
    protected void GvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Ciudad cCiudad = null;
            List<Ciudad> _lista = (List<Ciudad>)Session["ListaCiudades"];
            foreach (Ciudad C in _lista)
            {
                if (C.Codigo_Ciudad == Convert.ToString(GvCiudad.SelectedRow.Cells[2].Text))
                {
                    cCiudad = C;
                }
            }
            Pais pPais = LogicaPais.Buscar(cCiudad.Pais.Codigo_Pais);
            Session["Pais"] = pPais;
            Session["Ciudad"] = cCiudad;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCiudad.PageIndex = e.NewPageIndex;//Pasamos a la siguente pagina
        GvCiudad.DataSource = (List<Ciudad>)Session["ListaCiudades"];//Cargamos la siguente grilla
        GvCiudad.DataBind();
    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        Usuario uUsuario = (Usuario)Session["Usuario"];
        Pais pPais = (Pais)Session["Pais"];
        Ciudad cCiudad = (Ciudad)Session["Ciudad"];

        try
        {
            DateTime Fecha = ClrFecha.SelectedDate;
            DateTime Hora = Convert.ToDateTime(ddlHora.SelectedValue);
            int VelocidadViento = Convert.ToInt32(txtViento.Text);
            int Probabilidad = Convert.ToInt32(txtProbabilidad.Text);
            int Maxima = Convert.ToInt32(txtMaxima.Text);
            int Minima = Convert.ToInt32(txtMinima.Text);
            string TipoCielo = Convert.ToString(ddlTipoCielo.SelectedValue);
            DateTime Fecha_Hora = Fecha.AddHours(Hora.Hour).AddMinutes(Hora.Minute).AddSeconds(Hora.Second);
            Pronostico pPronostico = new Pronostico(0, uUsuario, cCiudad, pPais, Maxima, Minima, Fecha_Hora, VelocidadViento, Probabilidad, TipoCielo);

            LogicaPronostico.Agregar(pPronostico);
            lblError.Text = "Alta Exitosa, " + pPronostico.ToString(); 
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            //Mensaje de error
            lblError.Text = ex.Message;
        }
    }   
}