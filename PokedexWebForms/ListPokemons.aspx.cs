using Dominio;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWebForms
{
    public partial class ListPokemons : Page
    {
        //private readonly bool _flag = true;
        //private readonly string _activeClass = "active";
        private readonly int _elementosPagina = 12;

        public List<Pokemon> ListaPokemons { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && TxtSearch != null)
            {
                ViewState.Add("CurrentPage", 1);
                LoadPokemonsList(1);
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
        private void LoadPokemonsList(int pagina)
        {
            if (Session["ListPokemons"] != null)
            {
                ListaPokemons = (List<Pokemon>)Session["ListPokemons"] ;

                int totalRegistros = ListaPokemons.Count;
                int paginasTotales = (int)Math.Ceiling((double)totalRegistros / _elementosPagina);

                List<Pokemon> listaPaginada = ListaPokemons.Skip((pagina - 1) * _elementosPagina).Take(_elementosPagina).ToList();

                cardPokemonRepeater.DataSource = listaPaginada;
                cardPokemonRepeater.DataBind();

                var pages = Enumerable.Range(1, paginasTotales).ToList();
                pageNumberRepeater.DataSource = pages;
                pageNumberRepeater.DataBind();

                
                btnPrevious.Enabled = pagina > 1;
                btnNext.Enabled = pagina < paginasTotales;

                
                ViewState["CurrentPage"] = pagina;
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        protected void PageNumber_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int pagina = int.Parse(btn.CommandArgument);
            ViewState["CurrentPage"] = Convert.ToInt32(btn.CommandArgument);
            LoadPokemonsList(pagina);
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            int paginaActual = Convert.ToInt32(ViewState["CurrentPage"]);
            paginaActual--;
            LoadPokemonsList(paginaActual);
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            int paginaActual = Convert.ToInt32(ViewState["CurrentPage"]);
            paginaActual++;
            LoadPokemonsList(paginaActual);
        }
    }
}