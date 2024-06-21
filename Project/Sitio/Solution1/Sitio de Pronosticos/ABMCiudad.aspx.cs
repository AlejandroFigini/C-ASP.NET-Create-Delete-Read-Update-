using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;


public partial class ABMCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
    }
    private void LimpiarFormulario()
    {
        txtCodigo_Ciudad.Text = "";
        txtCodigo_Pais.Text = "";
        txtNombre.Text = "";
        txtCodigo_Pais.Enabled = true;
    }
    private void DesactivarBotones()
    {
        //Deja todas las entradas en falso, menos el buscar
        BtnBuscarPais.Enabled = true;
        BtnBuscarPais.Visible = true;

        BtnBuscarCiudad.Enabled = false;
        BtnBuscarCiudad.Visible = false;

        //Desactivar Botones
        BtnBaja.Enabled = false;
        BtnModificar.Enabled = false;
        BtnAgregar.Enabled = false;

        //Oculto botones
        BtnBaja.Visible = false;
        BtnModificar.Visible = false;
        BtnAgregar.Visible = false;

    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        this.LimpiarFormulario();
        this.DesactivarBotones();
    }
    private void ActivarBotones_Agregar() //Oculto y activo botones segun funcion agregar
    {
        BtnAgregar.Enabled = true;
        BtnAgregar.Visible = true;

        BtnBaja.Enabled = false;
        BtnBaja.Visible = false;

        BtnModificar.Enabled = false;
        BtnModificar.Visible = false;

        txtCodigo_Ciudad.Enabled = false;
        txtCodigo_Pais.Enabled = false;
        txtNombre.Enabled = true;
    }
    private void ActivarBotones_ModificarEliminar()
    {
        BtnAgregar.Enabled = false;
        BtnAgregar.Visible = false;

        BtnModificar.Enabled = true;
        BtnModificar.Visible = true;

        txtCodigo_Pais.Enabled = false;
        txtCodigo_Ciudad.Enabled = false;
        txtNombre.Enabled = true;

        BtnBaja.Enabled = true;
        BtnBaja.Visible = true;
    }

    protected void BtnBuscarPais_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        //Obetenemos el codigo del txt
        string Codigo_Pais = txtCodigo_Pais.Text;

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
                txtCodigo_Pais.Text = pPais.Codigo_Pais;

                lblError.Text = "Pais encontrado en base de datos";
                Session["ABMCiudad_P"] = pPais;

                txtCodigo_Ciudad.Enabled = true;
                BtnBuscarCiudad.Enabled = true;
                BtnBuscarCiudad.Visible = true;
            }
            else
            {
                lblError.Text = "No se encontro Pais";
                return;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBuscarCiudad_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        //Obetenemos el codigo del txt
        string Codigo_Ciudad = txtCodigo_Ciudad.Text;

        //Verifico que no sea nulo
        if (Codigo_Ciudad == "")
        {
            lblError.Text = "Codigo de Ciudad nulo";
            return;
        }

        try
        {
            Pais pPais = (Pais)Session["ABMCiudad_P"];
            Ciudad cCiudad = LogicaCiudad.Buscar(Codigo_Ciudad, pPais.Codigo_Pais);
            if (cCiudad != null)
            {
                //Si no es nula, podemos activar botones
                txtCodigo_Ciudad.Text = cCiudad.Codigo_Ciudad;
                txtCodigo_Pais.Text = cCiudad.Pais.Codigo_Pais;
                txtNombre.Text = cCiudad.Nombre;

                Session["ABMCiudad_C"] = cCiudad;
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
        string Codigo_Pais = txtCodigo_Pais.Text;
        string Codigo_Ciudad = txtCodigo_Ciudad.Text;
        string Nombre = txtNombre.Text;

        if (Nombre == "")
        {
            lblError.Text = "No se permiten campos nulos";
        }
        else
        {
            //Creamos con el contructor 
            Ciudad cCiudad = new Ciudad(Codigo_Ciudad, Nombre, (Pais)Session["ABMCiudad_P"]);
            try
            {
                LogicaCiudad.Agregar(cCiudad);

                lblError.Text = "Alta con Exito, "+cCiudad.ToString();

                this.LimpiarFormulario();
                this.DesactivarBotones();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        Ciudad cCiudad = (Ciudad)Session["ABMCiudad_C"];
        cCiudad.Nombre = txtNombre.Text;      
        try
        {
            LogicaCiudad.Modificar(cCiudad);
            lblError.Text = "Modificacion Exitosa, " + cCiudad.ToString();

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
            Ciudad cCiudad = (Ciudad)Session["ABMCiudad_C"];
            LogicaCiudad.Eliminar(cCiudad);
            lblError.Text = "Eliminacion Exitosa, "+cCiudad.ToString();

            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

}