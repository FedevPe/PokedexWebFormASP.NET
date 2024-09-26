﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace PokedexWebForms
{
    public partial class _Default : Page
    {
        public bool flag = true;
        public string activeClass = "active";
        public List<Pokemon> ListaPokemons { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ListaPokemons = negocio.Listar();
        }
    }
}