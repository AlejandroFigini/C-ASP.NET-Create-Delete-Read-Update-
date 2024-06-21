using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;

public partial class ABMPais : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Verifica si se pide el formulario por primera vez
        if (!IsPostBack)
        {
            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
    }
    private void LimpiarFormulario()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtCodigo.Enabled = true;
    }
    private void DesactivarBotones()
    {
        //Deja todas las entradas en falso, menos el buscar
        BtnBuscar.Enabled = true;
        BtnBuscar.Visible = true;

        //Desactivar Botones
        BtnBaja.Enabled = false;
        BtnModificar.Enabled = false;
        BtnAgregar.Enabled = false;

        //Oculto botones
        BtnBaja.Visible = false;
        BtnModificar.Visible = false;
        BtnAgregar.Visible = false;

    }
    private void ActivarBotones_Agregar() //Oculto y activo botones segun funcion agregar
    {

        BtnAgregar.Enabled = true;
        BtnAgregar.Visible = true;

        BtnBaja.Enabled = false;
        BtnBaja.Visible = false;

        BtnModificar.Enabled = false;
        BtnModificar.Visible = false;

        txtNombre.Enabled = true;
        txtCodigo.Enabled = false;
    }
    private void ActivarBotones_ModificarEliminar()
    {

        BtnAgregar.Enabled = false;
        BtnAgregar.Visible = false;

        BtnModificar.Enabled = true;
        BtnModificar.Visible = true;

        txtCodigo.Enabled = false;
        txtNombre.Enabled = true;

        BtnBaja.Enabled = true;
        BtnBaja.Visible = true;
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        this.LimpiarFormulario();
        this.DesactivarBotones();
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        //Obetenemos el codigo del txt
        string Codigo_Pais = txtCodigo.Text;

        //Verifico que no sea nulo
        if (Codigo_Pais == "")
        {
            lblError.Text = "Codigo de Pais nulo";
            return;
        }

        try
        {
            Pais pPais = LogicaPais.Buscar(Codigo_Pais);
            if (pPais != null)
            {
                //Si no es nula, podemos activar botones
                txtCodigo.Text = pPais.Codigo_Pais;
                txtNombre.Text = pPais.Nombre;

                Session["ABMPais"] = pPais;
                ActivarBotones_ModificarEliminar();
            }
            else
            {
                ActivarBotones_Agregar();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        //Obtenemos el codigo del control
        string Codigo_Pais = txtCodigo.Text;
        string Nombre = txtNombre.Text;

        if (Nombre == "")
        {
            lblError.Text = "No se permiten campos nulos";
        }
        else
        {
            //Creamos con el contructor un nuevo pais
            Pais pPais = new Pais(Codigo_Pais, Nombre);
            try
            {
                LogicaPais.Agregar(pPais);

                lblError.Text = "Alta con Exito, "+pPais.ToString();

                this.LimpiarFormulario();
                this.DesactivarBotones();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        Pais pPais = (Pais)Session["ABMPais"];
        pPais.Nombre = txtNombre.Text;
        try
        {
            LogicaPais.Modificar(pPais);
            lblError.Text = "Modificacion Exitosa, " + pPais.ToString();

            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            //El pais se obtiene de la session de usuario
            Pais pPais = (Pais)Session["ABMPais"];

            LogicaPais.Eliminar(pPais);
            lblError.Text = "Eliminacion Exitosa, " + pPais.ToString();

            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}