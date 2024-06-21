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
    public class PersistenciaPais
    {       
        public static Pais Buscar(string pCodigo_Pais)//Nos llega por parametro el codigo de pais que queremos buscar
        {
            string pNombre, pCodigo;
            Pais p = null;

            SqlDataReader _Reader;
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);

            SqlCommand _Comando = new SqlCommand("BuscarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Codigo_Pais", pCodigo_Pais);


            try
            {
                _Conexion.Open();
                //Obtenemos el sqldatareader
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                {
                    pNombre = (string)_Reader["Nombre"];
                    pCodigo = (string)_Reader["Codigo_Pais"];
                    p = new Pais(pCodigo, pNombre);
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
            return p;
        }
        public static List<Pais> Listar()
        {
            string codigo_Pais;
            string nombre;

            List<Pais> _ListarPais = new List<Pais>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ListarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    nombre = (string)_Reader["Nombre"];
                    codigo_Pais = (string)_Reader["Codigo_Pais"];

                    Pais pPais = new Pais(codigo_Pais, nombre);
                    _ListarPais.Add(pPais);
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
            return _ListarPais;
        }
        public static void Agregar(Pais pPais)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            //Invoco procedimiento almacenado
            SqlCommand _Comando = new SqlCommand("AgregarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Codigo_Pais", pPais.Codigo_Pais);
            _Comando.Parameters.AddWithValue("@Nombre", pPais.Nombre);

            //Parametro de retorno con el tipo de dato de la base de datos
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);
            try
            {
                _Conexion.Open();

                _Comando.ExecuteNonQuery();

                if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("Codigo de Pais en uso");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al realizar alta de Pais");
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
        public static void Eliminar(Pais pPais)
        {
            //Operacion eliminar que recibe lo que se quiere eliminar
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("EliminarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Codigo_Pais", pPais.Codigo_Pais);
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

                //Determino devolucion del sp

                if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("No se encuentra Pais asociado a dicho codigo");
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
        public static void Modificar(Pais pPais)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ModificarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Paso todos los elementos a travez de la coleccion de parametros del comando
            _Comando.Parameters.AddWithValue("@Codigo_Pais", pPais.Codigo_Pais);
            _Comando.Parameters.AddWithValue("@Nombre", pPais.Nombre);


            SqlParameter _Retorno = new SqlParameter();
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                //Analizo los retornos
                if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("No existe pais asociado a dicho codigo - No se modifica");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al modificar Pais - No se modifica");
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
