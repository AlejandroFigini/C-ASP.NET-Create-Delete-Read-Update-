using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //Atributos
        private string nombre_Completo;
        private string nombre_Usuario;
        private string contraseña;

        //Propiedades
        public string Nombre_Completo
        {
            get { return nombre_Completo; }
            set
            {
                if (value != "")
                {
                    nombre_Completo = value;
                }
                else
                {
                    throw new Exception("Se necesita Nombre Completo");
                }
            }
        }

        public string Nombre_Usuario
        {
            get { return nombre_Usuario; }
            set
            {
                if (value != "")
                {
                    nombre_Usuario = value;
                }
                else
                {
                    throw new Exception("Se necesita Nombre de Usuario");
                }
            }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set
            {
                if (value != "")
                {
                    contraseña = value;
                }
                else
                {
                    throw new Exception("Contraseña Incorrecta");
                }
            }
        }
        //Contructor
        public Usuario(string pNombre_Completo, string pNombre_Usuario, string pContraseña)
        {
            Nombre_Completo = pNombre_Completo;
            Nombre_Usuario = pNombre_Usuario;
            Contraseña = pContraseña;
        }
        //Mostrar informacion
        public override string ToString()
        {
            return ("Nombre Completo: " + nombre_Completo + " Nombre de Usuario: " + nombre_Usuario + " Contraseña: " + contraseña);
        }
    }
}
