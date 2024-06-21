using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//Referencias
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCiudad
    {
        public static List<Ciudad> ListaCiudad()
        {
            string codigo_Ciudad;
            Pais pais;
            string nombre;

            List<Ciudad> _ListarCiudad = new List<Ciudad>();
            SqlDataReader _Reader;
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ListarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    nombre = (string)_Reader["Nombre"];
                    codigo_Ciudad = (string)_Reader["Codigo_Ciudad"];
                    pais = PersistenciaPais.Buscar((string)_Reader["Codigo_Pais"]);

                    Ciudad _Ciudad = new Ciudad(codigo_Ciudad, nombre, pais);
                    _ListarCiudad.Add(_Ciudad);
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
            return _ListarCiudad;
        }
        public static Ciudad Buscar(string cCodigo_Ciudad, string cCodigo_Pais)//Nos llega por parametro el codigo de pais y codigo de ciudad que queremos buscar
        {
            Ciudad cCiudad = null;

            //Necesitamos objeto sql data reader para recorrer todos los registros
            SqlDataReader _Reader;
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("BuscarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Codigo_Ciudad", cCodigo_Ciudad);
            _Comando.Parameters.AddWithValue("@Codigo_Pais", cCodigo_Pais);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                {
                    string cNombre = (string)_Reader["Nombre"];
                    cCiudad = new Ciudad(cCodigo_Ciudad, cNombre, PersistenciaPais.Buscar(cCodigo_Pais));
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
            return cCiudad;
        }
        public static void Agregar(Ciudad cCiudad)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            //Invoco procedimiento almacenado
            SqlCommand _Comando = new SqlCommand("AgregarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Codigo_Ciudad", cCiudad.Codigo_Ciudad);
            _Comando.Parameters.AddWithValue("@Codigo_Pais", cCiudad.Pais.Codigo_Pais);
            _Comando.Parameters.AddWithValue("@Nombre", cCiudad.Nombre);

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
                    throw new Exception("No existe pais con dicho codigo");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("Ya existe Ciudad con dicho codigo");
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
        public static void Modificar(Ciudad cCiudad)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ModificarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Nombre", cCiudad.Nombre);
            _Comando.Parameters.AddWithValue("@Codigo_Ciudad", cCiudad.Codigo_Ciudad);
            _Comando.Parameters.AddWithValue("@Codigo_Pais", cCiudad.Pais.Codigo_Pais);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                //Analizo los retornos
                if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("No se encuentra ciudad con dichos datos");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al modificar Ciudad - No se modifica");
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
        public static void Eliminar(Ciudad cCiudad)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("EliminarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Codigo_Ciudad", cCiudad.Codigo_Ciudad);
            _Comando.Parameters.AddWithValue("@Codigo_Pais", cCiudad.Pais.Codigo_Pais);
            //Parametros
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            //Agrego parametros al comando
            _Comando.Parameters.Add(_Retorno);
            try
            {
                _Conexion.Open();
                //Ejecuto comando
                _Comando.ExecuteNonQuery();

                if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("Error al ingresar ciudad");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al eliminar Ciudad - No se Elimina");
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
    }
}
