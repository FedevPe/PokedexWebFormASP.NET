using Dominio;
using System;
using System.Collections.Generic;

namespace PokedexWebForms
{
    public partial class PokemonDetails : System.Web.UI.Page
    {
        public Pokemon Pokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pokemon> pokemons = Session["ListPokemons"] as List<Pokemon>;
            Pokemon = pokemons.Find(x => x.Id == (int)Session["IdPokemonDetail"]);
        }
    }
}