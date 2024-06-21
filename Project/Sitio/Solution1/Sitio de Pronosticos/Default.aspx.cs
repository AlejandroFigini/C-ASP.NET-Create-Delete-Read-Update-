using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias
using EntidadesCompartidas;
using Logica;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
        try
        {
            //Limpio lista 
            LstPronosticos.Items.Clear();
            //Obtenemos la lista de la logica
            List<Pronostico> PronosticosDelDia = LogicaPronostico.ListarPronostico_Fecha(DateTime.Now);
            if (PronosticosDelDia.Count!=0) //Verifico cantidad de pronosticos mayor a cero
            {
                for (int i = 0; i < PronosticosDelDia.Count; i++)
                {
                    //Recorremos la lista con un for y vamos agregando Pronosticos 
                    LstPronosticos.Items.Add(PronosticosDelDia[i].ToString());
                }
            }
            else if (PronosticosDelDia.Count == 0)
            {
                LblError.Text = "No se encuentran pronósticos para el día de hoy";
            }
        }
        catch (Exception EX)
        {
            LblError.Text = EX.Message;
        }
        
    }
}