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
     public class LogicaPais
    {
        public static List<Pais> Listar()
        {
            //Creo lista de Paises
            List<Pais> _Pais = PersistenciaPais.Listar();
            return _Pais;
        }
        public static Pais Buscar(string cCodigo_Pais)
        {
            Pais pPais = (Pais)PersistenciaPais.Buscar(cCodigo_Pais);
            return pPais;
        }
        public static void Agregar(Pais pPais)
        {
           PersistenciaPais.Agregar(pPais);
        }
        public static void Eliminar(Pais pPais)
        {
            PersistenciaPais.Eliminar(pPais);
        }
        public static void Modificar(Pais pPais)
        {
            PersistenciaPais.Modificar(pPais);
        }
    }
}
