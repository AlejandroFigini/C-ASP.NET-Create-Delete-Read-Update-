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
    public class LogicaPronostico
    {
        public static List<Pronostico> ListarPronostico_Fecha(DateTime pFecha) //Lista de pronosticos segun fecha
        {
            //Creo lista de Pronostico
            List<Pronostico> Pronosticos_Fecha = PersistenciaPronostico.ListarPronostico_Fecha(pFecha);
            return Pronosticos_Fecha;
        }
        public static void Agregar(Pronostico pPronostico)
        {
            PersistenciaPronostico.Agregar(pPronostico);
        }
        public static List<Pronostico> ListarPronostico_Ciudad(Ciudad cCiudad)
        {
            //Creo lista de Pronostico
            List<Pronostico> _Pronostico = PersistenciaPronostico.ListarPronostico_Ciudad(cCiudad);

            return _Pronostico;
        }
        public static List<Pronostico> ListarPronostico_FechaDescendente()
        {
            List<Pronostico> _Pronostico = PersistenciaPronostico.ListarPronostico_FechaDescendente();

            return _Pronostico;
        }



    }
}
