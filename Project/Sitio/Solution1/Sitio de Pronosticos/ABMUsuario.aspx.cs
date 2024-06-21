using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;


public partial class ABMUsuario : System.Web.UI.Page
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
        txtNombreU.Text = "";
        txtContraseña.Text = "";
        txtNombreC.Text = "";

        txtContraseña.Enabled = false;
        txtNombreC.Enabled = false;
        txtNombreU.Enabled = true;
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

        txtNombreU.Enabled = false;
        txtNombreC.Enabled = true;
        txtContraseña.Enabled = true;
    }
    private void ActivarBotones_Modificar(int CantidadPronostico)//Activar botones segun cantidad de pronosticos
    {
        BtnAgregar.Enabled = false;
        BtnAgregar.Visible = false;
       
        BtnModificar.Enabled = true;
        BtnModificar.Visible = true;

        txtNombreU.Enabled = false;
        txtNombreC.Enabled = true;
        txtContraseña.Enabled = true;

        if (CantidadPronostico>0)
        {
            BtnBaja.Enabled = false;
            BtnBaja.Visible = false;
            lblError.Text = "Usuario con Pronosticos asociados, solo se permite modificar";
        }
        else if (CantidadPronostico == 0) //Si no tiene pronosticos asociados tambien permito eliminar
        {
            BtnBaja.Enabled = true;
            BtnBaja.Visible = true;
            lblError.Text = "Usuario sin Pronosticos asociados";
        }
    } 
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        //Obetenemos nombre de usuario
        string Nombre_Usuario = txtNombreU.Text;

        //Verifico que no sea nulo
        if (Nombre_Usuario == "")
        {
            lblError.Text = "Nombre de Usuario nulo";
            return;
        }
        try
        {
            //Busco usuario
            Usuario uUsuario = LogicaUsuario.Buscar(Nombre_Usuario);
            if (uUsuario != null && (LogicaUsuario.CantTotalPronosticos_Usuario(uUsuario) > 0))
            {
                txtNombreU.Text = uUsuario.Nombre_Usuario;
                txtNombreC.Text = uUsuario.Nombre_Completo;
                txtContraseña.Text = uUsuario.Contraseña;

                Session["ABMUsuario"] = uUsuario;
                ActivarBotones_Modificar(LogicaUsuario.CantTotalPronosticos_Usuario(uUsuario));               
            }
            else if (uUsuario != null)
            {
                //Si no es nula, podemos activar botones
                txtNombreU.Text = uUsuario.Nombre_Usuario;
                txtNombreC.Text = uUsuario.Nombre_Completo;
                txtContraseña.Text = uUsuario.Contraseña;

                Session["ABMUsuario"] = uUsuario;
                ActivarBotones_Modificar(LogicaUsuario.CantTotalPronosticos_Usuario(uUsuario));
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
    }//Buscar Usuario
    protected void BtnAgregar_Click(object sender, EventArgs e)//Agregar Usuario
    {
        //Obtenemos el codigo del control
        string Nombre_Usuario = txtNombreU.Text;
        string Nombre_Completo = txtNombreC.Text;
        string Contraseña = txtContraseña.Text;

        if (Nombre_Completo == "" || Contraseña == "")
        {
            lblError.Text = "No se permiten campos nulos";
        }
        else
        {
            //Creamos con el contructor 
            Usuario uUsuario = new Usuario(Nombre_Completo, Nombre_Usuario, Contraseña);
            try
            {
                LogicaUsuario.Agregar(uUsuario);

                lblError.Text = "Alta con Exito, "+uUsuario.ToString();
                this.LimpiarFormulario();
                this.DesactivarBotones();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected void BtnBaja_Click(object sender, EventArgs e)//Eliminar Usuario
    {
        try
        {
            //El pais se obtiene de la session de usuario
            Usuario uUsuario = (Usuario)Session["ABMUsuario"];

            LogicaUsuario.Eliminar(uUsuario);
            lblError.Text = "Eliminacion Exitosa, " + uUsuario.ToString();

            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnModificar_Click(object sender, EventArgs e)//Modificar Usuario
    {
        Usuario uUsuario = (Usuario)Session["ABMUsuario"];
        uUsuario.Nombre_Completo = txtNombreC.Text;
        uUsuario.Contraseña = txtContraseña.Text;

        try
        {
            LogicaUsuario.Modificar(uUsuario);
            lblError.Text = "Modificacion Exitosa, "+uUsuario.ToString();

            this.LimpiarFormulario();
            this.DesactivarBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}