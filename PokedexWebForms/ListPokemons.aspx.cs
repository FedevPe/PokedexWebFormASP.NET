using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWebForms
{
    public partial class ListPokemons : Page
    {
        //private readonly bool _flag = true;
        //private readonly string _activeClass = "active";
        private readonly int _elementsxPage = 12;

        public List<Pokemon> PokemonList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FilterList();
            if (!IsPostBack)
            {
                ViewState.Add("CurrentPage", 1);
                LoadPokemonsList();
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
            FilterList();
            LoadPokemonsList();
        }
        private void LoadPokemonsList(int page = 1)
        {
            if (Session["PokemonsList"] != null)
            {
                FilterList();

                int totalPokemons = PokemonList.Count;
                int totalPages = (int)Math.Ceiling((double)totalPokemons / _elementsxPage);

                List<Pokemon> PaginatedList = PokemonList.Skip((page - 1) * _elementsxPage).Take(_elementsxPage).ToList();

                cardPokemonRepeater.DataSource = PaginatedList;
                cardPokemonRepeater.DataBind();

                var pages = Enumerable.Range(1, totalPages).ToList();
                pageNumberRepeater.DataSource = pages;
                pageNumberRepeater.DataBind();

                ViewState["CurrentPage"] = page;
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        protected void PageNumber_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int page = int.Parse(btn.CommandArgument);
            ViewState["CurrentPage"] = Convert.ToInt32(btn.CommandArgument);
            LoadPokemonsList(page);
        }
        private void FilterList()
        {
            PokemonList = null;

            if (!string.IsNullOrWhiteSpace(TxtSearch.Text.Trim()))
            {
                PokemonList = ((List<Pokemon>)Session["PokemonsList"]).FindAll(
                    x => x.Nombre.ToLower().Contains(TxtSearch.Text.ToLower()));
            }
            else
            {
                PokemonList = (List<Pokemon>)Session["PokemonsList"];
            }
        }
    }
}