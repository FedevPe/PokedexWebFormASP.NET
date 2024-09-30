using Dominio;
using Negocio;
using Service;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace PokedexWebForms
{
    public partial class Default : Page
    {
        private readonly PokemonNegocio pokemonNegocio = new PokemonNegocio();
        private readonly ElementoNegocio elementoNegocio = new ElementoNegocio();
        private readonly HabilidadNegocio habilidadNegocio = new HabilidadNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("ListPokemons",pokemonNegocio.Listar());
            Session.Add("ListHabilities", habilidadNegocio.ListAllHabilities());
            Session.Add("ListElementos", elementoNegocio.Listar());
        }
    }
}