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
    public class PersistenciaUsuario
    {
        public static EntidadesCompartidas.Usuario Logueo(string Usu, string Pass)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _comando = new SqlCommand("Logueo", _Conexion);
            _comando.CommandType = CommandType.StoredProcedure;

            Usuario uUsuario = null;

            //parametros
            _comando.Parameters.AddWithValue("@Nombre_Usuario", Usu);
            _comando.Parameters.AddWithValue("@Contraseña", Pass);

            try
            {
                _Conexion.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _NomUsu = (string)_lector["Nombre_Usuario"];
                    string _NomCom = (string)_lector["Nombre_Completo"];
                    string _Pass = (string)_lector["Contraseña"];
                    uUsuario = new EntidadesCompartidas.Usuario(_NomCom, _NomUsu, _Pass);
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
            return uUsuario;
        } //Logueo de Usuario
        public static int CantTotalPronosticos_Usuario(Usuario uUsuario)//Cantidad de pronosticos por usuario
        {
            int _Cant = 0;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("CantidadPronosticos_Usuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Nombre_Usuario", uUsuario.Nombre_Usuario);

            SqlParameter _cant = new SqlParameter("@Cant", SqlDbType.Int);
            _cant.Direction = ParameterDirection.Output;
            _Comando.Parameters.Add(_cant);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                //obtengo valor
                _Cant = Convert.ToInt32(_cant.Value);

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _Cant;
        }
        public static Usuario Buscar(string uNombre_Usuario)
        {
            Usuario uUsuario = null;
            string uNombre_Completo, uContraseña;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("BuscarUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Nombre_Usuario", uNombre_Usuario);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                {
                    uNombre_Completo = (string)_Reader["Nombre_Completo"];
                    uContraseña = (string)_Reader["Contraseña"];
                    //Creo Usuario
                    uUsuario = new Usuario(uNombre_Completo, uNombre_Usuario, uContraseña);
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
            //Retorno Usuario
            return uUsuario;
        }
        public static void Agregar(Usuario uUsuario)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            //Invoco procedimiento almacenado
            SqlCommand _Comando = new SqlCommand("AgregarUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Agrego los parametros al comando
            _Comando.Parameters.AddWithValue("@Nombre_Usuario", uUsuario.Nombre_Usuario);
            _Comando.Parameters.AddWithValue("@Nombre_Completo", uUsuario.Nombre_Completo);
            _Comando.Parameters.AddWithValue("@Contraseña", uUsuario.Contraseña);

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
                    throw new Exception("Nombre de usuario en uso");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al realizar alta de usuario");
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
        public static void Eliminar(Usuario uUsuario)
        {
            //Operacion eliminar que recibe lo que se quiere eliminar
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("EliminarUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Nombre_Usuario", uUsuario.Nombre_Usuario);

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

                if (Convert.ToInt32(_Retorno.Value) == 0)
                {                   
                    throw new Exception("Hay Pronosticos Asociados a dicho Usuario - No se Elimina");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -1)
                {
                    throw new Exception("Error al realizar baja - No se Elimina");
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
        public static void Modificar(Usuario uUsuario)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ModificarUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            //Paso todos los elementos a travez de la coleccion de parametros del comando
            _Comando.Parameters.AddWithValue("@Contraseña", uUsuario.Contraseña);
            _Comando.Parameters.AddWithValue("@Nombre_Completo", uUsuario.Nombre_Completo);
            _Comando.Parameters.AddWithValue("@Nombre_Usuario", uUsuario.Nombre_Usuario);


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
                    throw new Exception("No existe nombre de Usuario - No se modifica");
                }
                else if (Convert.ToInt32(_Retorno.Value) == -2)
                {
                    throw new Exception("Error al modificar Usuario - No se modifica");
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