using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        //Atributos
        private Usuario usuario;
        private Ciudad ciudad;
        private Pais pais;
        private int codigo_Interno;
        private int maxima;
        private int minima;
        private DateTime fecha_Hora;
        private int velViento;
        private int probabilidad;
        private string tipo_Cielo;

        //Propiedades
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                if (value != null)
                {
                    usuario = value;
                }
                else
                {
                    throw new Exception("Se necesita Usuario");
                }
            }
        }

        public Ciudad Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value != null)
                {
                    ciudad = value;
                }
                else
                {
                    throw new Exception("Debe ingresar Ciudad");
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
                    throw new Exception("Debe ingresar Pais");
                }
            }
        }

        public int Codigo_Interno
        {
            get { return codigo_Interno; }
            set { codigo_Interno = value; }
        }

        public int Maxima
        {
            get { return maxima; }
            set
            {
                if (value < 55)
                {
                    maxima = value;
                }
                else
                {
                    throw new Exception("Temperatura maxima supera limite permitido");
                }
            }
        }

        public int Minima
        {
            get { return minima; }
            set
            {
                if (value > -20)
                {
                    minima = value;
                }
                else
                {
                    throw new Exception("Temperatura minima por debajo de limite permitido");
                }
            }
        }

        public DateTime Fecha_Hora
        {
            get { return fecha_Hora; }
            set
            {
                if (value != null)
                {
                    fecha_Hora = value;
                }
                else
                {
                    throw new Exception("Se necesita fecha para pronostico");
                }
            }
        }

        public int VelViento
        {
            get { return velViento; }
            set
            {
                if (value > 0)
                {
                    velViento = value;
                }
                else
                {
                    throw new Exception("Velocidad de viento incorrecta");
                }
            }
        }

        public int Probabilidad
        {
            get { return probabilidad; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    probabilidad = value;
                }
                else
                {
                    throw new Exception("Valor para probabilidad de lluvias incorrecto");
                }
            }
        }

        public string Tipo_Cielo
        {
            get { return tipo_Cielo; }
            set
            {
                if (value == "Despejado" || value == "Parcialmente Nuboso" || value == "Nuboso")
                {
                    tipo_Cielo = value;
                }
                else
                {
                    throw new Exception("Error en tipo de cielo");
                }
            }
        }

        //Constructor
        public Pronostico(int pCodigo_Interno,Usuario pUsuario, Ciudad pCiudad, Pais pPais, int pMaxima, int pMinima, DateTime pFecha_Hora, int pVelViento, int pProbabilidad, string pTipo_Cielo)
        {
            codigo_Interno = pCodigo_Interno;
            Usuario = pUsuario;
            Ciudad = pCiudad;
            Pais = pPais;
            Maxima = pMaxima;
            Minima = pMinima;
            Fecha_Hora = pFecha_Hora;
            VelViento = pVelViento;
            Probabilidad = pProbabilidad;
            Tipo_Cielo = pTipo_Cielo;
        }
        //Informacion sobre usuario y ciudad

        public override string ToString()
        {
            return ("Usuario: "+Usuario.Nombre_Usuario +"Pais: " + Pais.Codigo_Pais + "  Ciudad: " + Ciudad.Codigo_Ciudad + " Codigo: "+codigo_Interno+"  Maxima: " + maxima + "  Minima: " + minima + "  Fecha: " + fecha_Hora.ToShortDateString()+" Viento: "+velViento+" Probabilidad: "+probabilidad+" Tipo Cielo: "+tipo_Cielo);
        }
    }
}
