using Dominio;
using Negocio;
using System;

namespace PokedexWebForms
{
    public partial class PokemonDetails : System.Web.UI.Page
    {
        private int _idPokemon;
        public Pokemon Pokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                _idPokemon = int.Parse(Request.QueryString["Id"]);
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon = negocio.GetPokemonById(_idPokemon);
            }
        }
    }
}