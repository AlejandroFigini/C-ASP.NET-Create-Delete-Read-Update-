using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

//Referencias
using EntidadesCompartidas;
using Logica;
public partial class PronósticosPorCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Obetenemos la lista
            List<Pais> _Pais = LogicaPais.Listar();
            //Al menos la lista debe contener al menos un elemento 
            if (_Pais.Count > 0)
            {
                //Cargar ddl
                ddlPais.DataSource = _Pais;
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "Codigo_Pais";
                ddlPais.DataBind();
                //Como trabajamos con esta lista, la mantendremos en la session
                Session["ListaPais"] = _Pais;
            }
            else
            {
                lblError.Text = "Error: no exite ningun Pais. Debe ingresar primero";
            }
        }
    }
    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pPais = LogicaPais.Buscar(ddlPais.SelectedValue);
            Session["pPais"] = pPais;
            //Obtengo todas las ciudades
            List<Ciudad> _CiudadPorPais = LogicaCiudad.ListarCiudad_Pais(pPais);
            Session["ListaCiudadPais"] = _CiudadPorPais;

            lblCiudad.Visible = true;
            lblCiudad.Text = "Ciudades para el pais de  " + pPais.Nombre;
            GvCiudad.DataSource = _CiudadPorPais;
            GvCiudad.DataBind();

            lblCiudad.Visible = true;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void GvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Pais pPais = (Pais)Session["pPais"];
            //obtengo ciudad Seleccionada     
            Ciudad cCiudad = LogicaCiudad.Buscar(Convert.ToString(GvCiudad.SelectedRow.Cells[2].Text), pPais.Codigo_Pais);
            List<Pronostico> pPronosticosCiudad = LogicaPronostico.ListarPronostico_Ciudad(cCiudad);
            Session["ListaPronosticosCiudad"] = pPronosticosCiudad;


            lblPronostico.Visible = true;
            lblPronostico.Text = "Se encuentran "+pPronosticosCiudad.Count+" pronosticos para la ciudad de   " + cCiudad.Nombre;
            GvPronostico.DataSource = pPronosticosCiudad;
            GvPronostico.DataBind();

            lblPronostico.Visible = true;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void GvCiudad_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCiudad.PageIndex = e.NewPageIndex;//Pasamos a la siguente pagina
        GvCiudad.DataSource = (List<Ciudad>)Session["ListaCiudadPais"];//Cargamos la siguente grilla
        GvCiudad.DataBind();
    }
    protected void GvPronostico_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPronostico.PageIndex = e.NewPageIndex;
        GvPronostico.DataSource = (List<Pronostico>)Session["ListaPronosticosCiudad"];
        GvPronostico.DataBind();
    }
}