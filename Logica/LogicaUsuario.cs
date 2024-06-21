using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static EntidadesCompartidas.Usuario Logueo(string Usu, string Pass)
        {
            return (Persistencia.PersistenciaUsuario.Logueo(Usu, Pass));
        } //Logueo
        public static int CantTotalPronosticos_Usuario(Usuario uUsuario) //Cantidad de Pronosticos por Usuario
        {
            return (PersistenciaUsuario.CantTotalPronosticos_Usuario(uUsuario));
        }
        public static Usuario Buscar(string uNombre_Usuario) //Busqueda de Usuario
        {
            Usuario uUsuario = null;
            uUsuario = (Usuario)PersistenciaUsuario.Buscar(uNombre_Usuario);
            return uUsuario;
        }
        public static void Agregar(Usuario uUsuario) //Alta Usuario
        {
             PersistenciaUsuario.Agregar(uUsuario);
        }
        public static void Eliminar(Usuario uUsuario)//Eliminar Usuario
        {
            PersistenciaUsuario.Eliminar(uUsuario);
        }
        public static void Modificar(Usuario uUsuario)//Modificar Usuario
        {
            PersistenciaUsuario.Modificar(uUsuario);
        }
    }
}
