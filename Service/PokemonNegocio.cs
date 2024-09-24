using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.AccessControl;
using System.Collections;


namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> lista = new List<Pokemon>();

            //Instacio un objeto de la clase AccesoDatos para luego utilizar sus metodos que me permiten obtener los datos de la DB
            //Además al tener y utilizar esta clase me queda un código mucha más limpio y ordenado
            AccesoDatos datos = new AccesoDatos();  

            try 
            {
                //Utilizo los metodos de la Clase AccesoDatos para obtener los datos de una DB
                datos.ConfigurarConsulta("Select P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and P.IdDebilidad = D.Id and P.Activo = 1");
                datos.EjecutarLectura();

                //Asigno los datos al reader
                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon()
                    {
                        Id = (int)datos.Reader["Id"],
                        Numero = (int)datos.Reader["Numero"],
                        Nombre = (string)datos.Reader["Nombre"],
                        Descripcion = (string)datos.Reader["Descripcion"],
                        Tipo = new Elemento()
                        {
                            Id = (int)datos.Reader["IdTipo"],
                            Descripcion = (string)datos.Reader["Tipo"]
                        },
                        Debilidad = new Elemento()
                        {
                            Id = (int)datos.Reader["IdDebilidad"],
                            Descripcion = (string)datos.Reader["Debilidad"]
                        }
                    };

                    //Esto es una validacion de Null
                    //En caso de que la columna UrlUmagaen no sea nula se va a guardar en el lector
                    //Se utiliza para que en el programa no ocurra una exception o error, ya que 
                    //algunas columnas de la tabla POKEMONS son NotNull, es decir que no pueden quedar en nada
                    //deben tener algun dato si o si, incluso un varChar vacio ''
                    if (!(datos.Reader["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];
                    }

                    lista.Add(aux);
                }
                return lista; 
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
            

        }
        public void AgregarPokemon(Pokemon newPokemon)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta($"Insert into POKEMONS (Numero, Nombre, Descripcion, UrlImagen, IdTipo, IdDebilidad, Activo) values ({newPokemon.Numero}, '{newPokemon.Nombre}', '{newPokemon.Descripcion}',@UrlImagen, @IdTipo, @IdDebilidad, 1)");

                //newPokemon es un objeto de a clase Pokemon que recibe el metodo por parametro,
                //La propiedad Tipo del objeto contiene un Objeto de la Clase Elemento que a su vez obtengo el valor
                //del Id que se obtuvo al obtener los datos de la DB especificamente la tabla ELEMENTOS.

                //En esta instruccion indíco cuál es el parámetro que quiero configurar y el valor.
                datos.ConfigurarParametros("@IdTipo", newPokemon.Tipo.Id);
                datos.ConfigurarParametros("@IdDebilidad", newPokemon.Debilidad.Id);
                datos.ConfigurarParametros("@UrlImagen", newPokemon.UrlImagen);
                datos.EjecutarAccion();
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
        public void ModificarPokemon(Pokemon pokemon)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta($"update POKEMONS set Numero = {pokemon.Numero},Nombre = '{pokemon.Nombre}',Descripcion = '{pokemon.Descripcion}',UrlImagen = '{pokemon.UrlImagen}',IdTipo = {pokemon.Tipo.Id}, IdDebilidad = {pokemon.Debilidad.Id}, Activo = 1 where Id = {pokemon.Id}");
                datos.EjecutarAccion();
                                
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

        //Este metodo elimina de forma física el pokemon, es decir, desaparece de la DB y no puede
        //recuperarse. (Delete)
        public void EliminarPokemon(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta($"Delete from POKEMONS where id = {id}");
                datos.EjecutarAccion();

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
        //Este metodo elimina de forma lógica el pokemon, es decir, que cambiar el estado del pokemon es la DB. (Update)
        public void EliminarPokemonLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta($"Update POKEMONS set Activo = 0 where id = {id}");
                datos.EjecutarAccion();
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
        public List<Pokemon> Filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> list = new List<Pokemon>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and P.IdDebilidad = D.Id and P.Activo = 1 and ";

                if (campo == "Números")
                {
                    if (criterio == "Mayor a ")
                    {
                        consulta += $"P.Numero > {filtro}";
                    }
                    else if (criterio == "Menor a ")
                    {
                        consulta += "P.Numero < " + filtro;
                    }
                    else
                    {
                        consulta += "P.Numero = " + filtro;
                    }
                }
                else if (campo == "Nombres")
                {
                    if (criterio == "Comienza con ")
                    {
                        consulta += $"P.Nombre like '{filtro}%'";
                    }
                    else if (criterio == "Termina con ")
                    {
                        consulta += $"P.Nombre like '%{filtro}'";
                    }
                    else
                    {
                        consulta += $"P.Nombre like '%{filtro}%'";
                    }
                }
                else
                {
                    if (criterio == "Comienza con ")
                    {
                        consulta += $"E.Descripcion like '{filtro}%'";
                    }
                    else if (criterio == "Termina con ")
                    {
                        consulta += $"E.Descripcion like '%{filtro}'";
                    }
                    else
                    {
                        consulta += $"E.Descripcion like '%{filtro}%'";
                    }
                }

                datos.ConfigurarConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon()
                    {
                        Id = (int)datos.Reader["Id"],
                        Numero = (int)datos.Reader["Numero"],
                        Nombre = (string)datos.Reader["Nombre"],
                        Descripcion = (string)datos.Reader["Descripcion"],
                        Tipo = new Elemento()
                        {
                            Id = (int)datos.Reader["IdTipo"],
                            Descripcion = (string)datos.Reader["Tipo"]
                        },
                        Debilidad = new Elemento()
                        {
                            Id = (int)datos.Reader["IdDebilidad"],
                            Descripcion = (string)datos.Reader["Debilidad"]
                        }
                    };

                    //Esto es una validacion de Null
                    //En caso de que la columna UrlUmagaen no sea nula se va a guardar en el lector
                    //Se utiliza para que en el programa no ocurra una exception o error, ya que 
                    //algunas columnas de la tabla POKEMONS son NotNull, es decir que no pueden quedar en nada
                    //deben tener algun dato si o si, incluso un varChar vacio ''
                    if (!(datos.Reader["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];
                    }

                    list.Add(aux);
                }
                return list;
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
