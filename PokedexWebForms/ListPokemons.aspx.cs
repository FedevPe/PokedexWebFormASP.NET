using Dominio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWebForms
{
    public partial class ListPokemons : Page
    {
        public bool flag = true;
        public string activeClass = "active";
        public List<Pokemon> ListaPokemons { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListPokemons"] != null)
            {
                ListaPokemons = Session["ListPokemons"] as List<Pokemon>;
                cardPokemonRepeater.DataSource = ListaPokemons;
                cardPokemonRepeater.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        protected void BtnDetails_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            Session.Add("IdPokemonDetail", id);
            Response.Redirect("PokemonDetails", false);
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                List<Pokemon> listaFiltro = new List<Pokemon>();
                listaFiltro = ((List<Pokemon>)Session["ListPokemons"]).FindAll(
                    x => x.Nombre.ToLower().Contains(TxtSearch.Text.ToLower()));

                cardPokemonRepeater.DataSource = listaFiltro;
            }
            else
            {
                ListaPokemons = Session["ListPokemons"] as List<Pokemon>;
                cardPokemonRepeater.DataSource = ListaPokemons;
                
            }
            cardPokemonRepeater.DataBind();
        }
    }
}