using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    //Clase donde configuro el acceso a la DB para reducir las lineas de código de las clases Negocio.
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader reader;

        //Propiedad que me permite leer el reader desde el exterior
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        //Constructor de la clase
        public AccesoDatos()
        {
            //Intanciación de objetos
            conexion = new SqlConnection("server = .\\SQLEXPRESS; database = POKEDEX_DB; integrated security = true");
            cmd = new SqlCommand();
        }

        //Metodos de configuración
        public void ConfigurarConsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }

        //Metodo para abrir la conexion con la DB, ejecutar la lectura y guardar los datos en el reader
        public void EjecutarLectura()
        {
            cmd.Connection = conexion;
            
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Metodo para abrir la conexion con la DB, en este caso no ejecuta una lectura porque
        //es para insertar un nuevo registro (insert) es por eso que el comando es de tipo NonQuery
        public void EjecutarAccion()
        {
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery(); //Los comandos del tipo NonQuery se utilizan cuando se necesita ejecutar una operacion que
                                       //que no devuelven un conjunto de resultados, sino que realizan cambio en la DB (Inser, Deleter, Update)
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Metodo para cerrar la conexion y el reader, siempre y cuando el reader contenga datos.
        public void CerrarConexion()
        {
            reader?.Close(); // forma corta de comprobar si el reader es = null [ if (reader != null){reader.Close();} ]
            conexion.Close();
        }

        //Metodo que me permite configurar ciertos parametros de la consulto Insert, en este caso
        //como necesito insertar en la tabla POKEMONS de la DB el IdTipo y IdDebilidad que dependen de
        //de la tabla ELEMENTOS y la columna Descripción de la misma, utilizo este metodo para "relacionar"
        //y agregar los valores correctos.
        public void ConfigurarParametros(string parametro, object variable)
        {
            cmd.Parameters.AddWithValue(parametro, variable);
        }


    }
}
