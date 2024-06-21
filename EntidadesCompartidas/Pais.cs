using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Pais
    {
        //Atributos
        private string codigo_Pais;
        private string nombre;

        //Propiedades
        public string Codigo_Pais
        {
            get { return codigo_Pais; }
            set
            {
                if (value.Length == 3)
                {
                    codigo_Pais = value;
                }
                else
                {
                    throw new Exception("Error en largo de Codigo Pais");
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length >= 4)
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Nombre de Pais incorrecto");
                }
            }
        }
        //Constructor
        public Pais(string pCodigo_Pais, string pNombre)
        {
            Codigo_Pais = pCodigo_Pais;
            Nombre = pNombre;
        }

        public override string ToString()
        {
            return ("Codigo de Pais: "+codigo_Pais+" Nombre: "+nombre);
        }
    }
}
