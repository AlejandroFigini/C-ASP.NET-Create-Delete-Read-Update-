using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Ciudad
    {
        //Atributos
        private string codigo_Ciudad;
        private string nombre;
        private Pais pais;

        //Propiedades
        public string Codigo_Ciudad
        {
            get { return codigo_Ciudad; }
            set
            {
                if (value.Length == 3)
                {
                    codigo_Ciudad = value;
                }
                else
                {
                    throw new Exception("Error en largo de Codigo Ciudad");
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
                    throw new Exception("Nombre de Ciudad incorrecto");
                }
            }
        }

        public Pais Pais
        {
            get { return pais; }
            set
            {
                if (value != null)
                {
                    pais = value;
                }
                else
                {
                    throw new Exception("Se necesita ingresar Pais");
                }
            }
        }


        //Constructor
        public Ciudad(string pCodigo_Ciudad, string pNombre, Pais pPais)
        {
            Codigo_Ciudad = pCodigo_Ciudad;
            Nombre = pNombre;
            Pais = pPais;
        }
        //Mostrar informacion pais
        public override string ToString()
        {
            return ("Pais: "+Pais.Codigo_Pais+" Codigo de Ciudad: "+codigo_Ciudad+" Nombre: "+nombre);
        }
    }
}