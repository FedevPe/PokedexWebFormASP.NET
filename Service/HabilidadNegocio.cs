using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace Service
{
    public class HabilidadNegocio
    {
        public List<Habilidad> ListAllHabilities()
        {
            List<Habilidad> lista = new List<Habilidad>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Select H.Id, H.Nombre, H.Descripcion, H.IdTipo, E.Descripcion from Habilidades H Inner join Elementos E on H.IdTipo = E.Id
                datos.SetProcedure("ListHabilities");
                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    lista.Add(new Habilidad()
                    {
                        Id = (int)datos.Reader["Id"],
                        Nombre = datos.Reader["Nombre"].ToString(),
                        Descripcion = datos.Reader["Descripcion"].ToString(),
                        Tipo = new Elemento()
                        {
                            Id = (int)datos.Reader["IdTipo"],
                            Descripcion = datos.Reader["DescripcionTipo"].ToString()
                        }
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
        public List<Habilidad> ListHabilitiesByPokemonId(int id)
        {
            List<Habilidad> lista = new List<Habilidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("Select H.Id, H.Nombre, H.Descripcion, H.IdTipo, E.Descripcion as DescripcionTipo, PH.IdHabilidad " +
                    "from Habilidades H " +
                    "Inner Join Elementos E on H.Id = E.Id " +
                    "Inner Join [Pokemons.Habilidades]PH on H.Id = PH.IdHabilidad " +
                    $"Inner Join Pokemons P on P.Id = PH.IdPokemon and P.Id = {id}");

                datos.EjecutarLectura();

                while (datos.Reader.Read())
                {
                    lista.Add(new Habilidad()
                    {
                        Id = (int)datos.Reader["Id"],
                        Nombre = datos.Reader["Nombre"].ToString(),
                        Descripcion = datos.Reader["Descripcion"].ToString(),
                        Tipo = new Elemento()
                        {
                            Id = (int)datos.Reader["IdTipo"],
                            Descripcion = datos.Reader["DescripcionTipo"].ToString()
                        }
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
