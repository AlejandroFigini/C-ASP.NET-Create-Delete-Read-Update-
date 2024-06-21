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
    public class LogicaCiudad
    {
     
        public static List<Ciudad> ListarCiudad() //Listo las Ciudades guardadas en la Base de Datos
        {
            List<Ciudad> _Ciudad = PersistenciaCiudad.ListaCiudad();
            return _Ciudad;
        }
        public static List<Ciudad> ListarCiudad_Pais(Pais pPais) //Listo las Ciudades segun pais
        {
            List<Ciudad> _Ciudad = PersistenciaCiudad.ListaCiudad();
            List<Ciudad> _CiudadPorPais = new List<Ciudad>();
            foreach (EntidadesCompartidas.Ciudad C in _Ciudad)
            {
                if (C.Pais.Codigo_Pais == pPais.Codigo_Pais)
                    _CiudadPorPais.Add(C);
            }
            return _CiudadPorPais;
        }
        public static Ciudad Buscar(string cCodigo_Ciudad, string cCodigo_Pais)
        {
            Ciudad cCiudad = (Ciudad)PersistenciaCiudad.Buscar(cCodigo_Ciudad, cCodigo_Pais);
            return cCiudad;
        }
        public static void Agregar(Ciudad cCiudad)
        {
           PersistenciaCiudad.Agregar(cCiudad);
        }
        public static void Modificar(Ciudad cCiudad)
        {
            PersistenciaCiudad.Modificar(cCiudad);
        }
        public static void Eliminar(Ciudad cCiudad)
        {
            PersistenciaCiudad.Eliminar(cCiudad);
        }
    }
}