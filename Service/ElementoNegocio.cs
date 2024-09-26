using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    //Clase que me permite obtener los datos de la DB, especificamente de la tabla "ELEMENTOS"
    public class ElementoNegocio
    {
        public List<Elemento> Listar()
        {
            List<Elemento> lista = new List<Elemento>();

            //Instacio un objeto de la clase AccesoDatos para luego utilizar sus metodos que me permiten obtener los datos de la DB
            //Además al tener y utilizar esta clase me queda un código mucha más limpio y ordenado
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Utilizo los metodos de la Clase AccesoDatos para obtener los datos de una tabla especifica
                datos.ConfigurarConsulta("Select Id, Descripcion from ELEMENTOS");
                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    Elemento aux = new Elemento()
                    {
                        Id = (int)datos.Reader["Id"],
                        Descripcion = (string)datos.Reader["Descripcion"]
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Elemento> ListElementTypeByIdPokemon(int id)
        {
            List<Elemento> lista = new List<Elemento >();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta($"Select PT.IdElemento, E.Descripcion from [Pokemons.Tipos] PT Inner Join Elementos E on PT.IdElemento = E.Id Inner Join Pokemons P on PT.IdPokemon = P.Id where PT.IdPokemon = {id}");
                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    lista.Add(new Elemento()
                    {
                        Id = (int)datos.Reader["IdElemento"],
                        Descripcion = datos.Reader["Descripcion"].ToString()
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Elemento> ListElementWeaknessByIdPokemon(int id)
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ConfigurarConsulta("Select PD.IdElemento, E.Descripcion " +
                    "from[Pokemons.Debilidades] PD " +
                    "Inner Join Elementos E on PD.IdElemento = E.Id " +
                    "Inner Join Pokemons P on PD.IdPokemon = P.Id " +
                    $"where PD.IdPokemon = {id}");
                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    lista.Add(new Elemento()
                    {
                        Id = (int)datos.Reader["IdElemento"],
                        Descripcion = datos.Reader["Descripcion"].ToString()
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
