using Negocio;
using Service;
using System;
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
            Session.Add("PokemonsList", pokemonNegocio.Listar());
            Session.Add("SkillsList", habilidadNegocio.ListAllHabilities());
            Session.Add("ElementsList", elementoNegocio.Listar());
        }
    }
}