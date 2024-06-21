using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

//Referencias
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPronostico
    {
        public static List<Pronostico> ListarPronostico_Fecha(DateTime pFecha) //Lista de pronosticos para fecha pasada por parametro
        {
            List<Pronostico> _ListaPronostico = new List<Pronostico>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ListarPronosticos_Fecha", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Fecha", pFecha);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int codigo_Interno = (int)_Reader["Codigo_Interno"];
                    int maxima = (int)_Reader["Maxima"];
                    int minima = (int)_Reader["Minima"];
                    int velViento = (int)_Reader["VelViento"];
                    int probabilidad = (int)_Reader["Probabilidad"];
                    string tipoCielo = (string)_Reader["Tipo_Cielo"];
                    DateTime fechaHora = (DateTime)_Reader["Fecha_Hora"];
                    Usuario usuario = PersistenciaUsuario.Buscar((string)_Reader["Usuario"]);
                    Ciudad ciudad = PersistenciaCiudad.Buscar((string)_Reader["Ciudad"], (string)_Reader["Pais"]);
                    Pais pais = PersistenciaPais.Buscar(Convert.ToString(_Reader["Pais"]));

                    //Creo el objeto pronostico
                    Pronostico _Pronostico = new Pronostico(codigo_Interno, usuario, ciudad, pais, maxima, minima, fechaHora, velViento, probabilidad, tipoCielo);
                    //Añado pronostico a la lista
                    _ListaPronostico.Add(_Pronostico);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
            return _ListaPronostico;
        }
        public static void Agregar(Pronostico pPronostico)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            //Invoco procedimiento almacenado
            SqlCommand _Comando = new SqlCommand("RegistrarPronostico", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Usuario", pPronostico.Usuario.Nombre_Usuario);
            _Comando.Parameters.AddWithValue("@Ciudad", pPronostico.Ciudad.Codigo_Ciudad);
            _Comando.Parameters.AddWithValue("@Pais", pPronostico.Pais.Codigo_Pais);
            _Comando.Parameters.AddWithValue("@Maxima", pPronostico.Maxima);
            _Comando.Parameters.AddWithValue("@Minima", pPronostico.Minima);
            _Comando.Parameters.AddWithValue("@Fecha_Hora", pPronostico.Fecha_Hora);
            _Comando.Parameters.AddWithValue("@VelViento", pPronostico.VelViento);
            _Comando.Parameters.AddWithValue("@Probabilidad", pPronostico.Probabilidad);
            _Comando.Parameters.AddWithValue("@Tipo_Cielo", pPronostico.Tipo_Cielo);

            //Parametro de retorno con el tipo de dato de la base de datos
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);
            try
            {
                _Conexion.Open();

                _Comando.ExecuteNonQuery();

                if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("No existe Ciudad con dicho codigo");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("No existe Pais con dicho codigo");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -3)
                {
                    throw new Exception("No se encuentra Usuario");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -4)
                {
                    throw new Exception("Error al ingresar fecha - No es posible ingresar fecha menor a la actual");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -5)
                {
                    throw new Exception("Error al realizar alta");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }
        public static List<Pronostico> ListarPronostico_Ciudad(Ciudad pCiudad) //Lista de pronosticos segun ciudad
        {
            List<Pronostico> _ListarPronosticoCiudad = new List<Pronostico>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ListarPronosticosCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Codigo_Pais", pCiudad.Pais.Codigo_Pais);
            _Comando.Parameters.AddWithValue("@Codigo_Ciudad", pCiudad.Codigo_Ciudad);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int codigo_Interno = (int)_Reader["Codigo_Interno"];
                    int maxima = (int)_Reader["Maxima"];
                    int minima = (int)_Reader["Minima"];
                    int velViento = (int)_Reader["VelViento"];
                    int probabilidad = (int)_Reader["Probabilidad"];
                    string tipo_Cielo = (string)_Reader["Tipo_Cielo"];
                    DateTime fecha_Hora = (DateTime)_Reader["Fecha_Hora"];
                    Usuario usuario = PersistenciaUsuario.Buscar((string)_Reader["Usuario"]);
                    Ciudad ciudad = PersistenciaCiudad.Buscar((string)_Reader["Ciudad"], (string)_Reader["Pais"]);
                    Pais pais = PersistenciaPais.Buscar(Convert.ToString(_Reader["Pais"]));

                    //Creo el objeto pronostico
                    Pronostico _Pronostico = new Pronostico(codigo_Interno, usuario, ciudad, pais, maxima, minima, fecha_Hora, velViento, probabilidad, tipo_Cielo);
                    //Añado pronostico a la lista
                    _ListarPronosticoCiudad.Add(_Pronostico);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
            return _ListarPronosticoCiudad;
        }
        public static List<Pronostico> ListarPronostico_FechaDescendente() 
        {
            List<Pronostico> _ListarPronostico = new List<Pronostico>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ListarPronosticoFechaDescendente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int codigo_Interno = (int)_Reader["Codigo_Interno"];
                    int maxima = (int)_Reader["Maxima"];
                    int minima = (int)_Reader["Minima"];
                    int velViento = (int)_Reader["VelViento"];
                    int probabilidad = (int)_Reader["Probabilidad"];
                    string tipo_Cielo = (string)_Reader["Tipo_Cielo"];
                    DateTime fecha_Hora = (DateTime)_Reader["Fecha_Hora"];
                    Usuario usuario = PersistenciaUsuario.Buscar((string)_Reader["Usuario"]);
                    Ciudad ciudad = PersistenciaCiudad.Buscar((string)_Reader["Ciudad"], (string)_Reader["Pais"]);
                    Pais pais = PersistenciaPais.Buscar(Convert.ToString(_Reader["Pais"]));

                    //Creo el objeto pronostico
                    Pronostico _Pronostico = new Pronostico(codigo_Interno, usuario, ciudad, pais, maxima, minima, fecha_Hora, velViento, probabilidad, tipo_Cielo);
                    //Añado pronostico a la lista
                    _ListarPronostico.Add(_Pronostico);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
            return _ListarPronostico;
        }
    }
}