<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonDetails.aspx.cs" Inherits="PokedexWebForms.PokemonDetails" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Inconsolata:wght@200..900&family=Jacquarda+Bastarda+9&family=Jersey+10&family=Jersey+25&family=Micro+5+Charted&family=Tiny5&display=swap" rel="stylesheet">


    <link rel="stylesheet" href="/css/pokemonDetails/bisagraPokedex.css">
    <link rel="stylesheet" href="/css/pokemonDetails/screenPokedex.css">
    <link rel="stylesheet" href="/css/pokemonDetails/cuadroIzq.css">
    <link rel="stylesheet" href="/css/pokemonDetails/cuadroDer.css">
    <link rel="stylesheet" href="/css/pokemonDetails/pokedexStyle.css">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="containerDetails">
        <div class="cuadroDerInvert">
            <div class="cuadroDerIntInvert">
                <div class="cartasInvert">                    
                    <div class="card tiny5-regular cardType">
                        <div class="card-header">Descripción</div>
                        <div class="card-body">
                            <div class="card-text">> <%:Pokemon.Bio%></div>               
                        </div>
                    </div>
                    <div class="card tiny5-regular cardType mt-2">
                        <div class="card-header">Habilidades Principales</div>
                        <div class="card-body">
                            <%foreach (Dominio.Habilidad habilidad in Pokemon.Habilidades)
                                {%>
                                    <div class="card-text">> <%:habilidad.Descripcion %></div>               
                              <%} %>
                        </div>
                    </div>
                </div>
            </div>        
        </div>
        <div class="cuadroIzq">
            <div class="cuadroIzqSup d-flex">
                <div class="circleSup">
                    <div class="circleSupIn">
                        <div class="shineCircle"></div>
                    </div>            
                </div>
                <div class="containerNot">
                    <div class="circleNot" style="background-color: rgb(240, 148, 112);">
                        <div class="shineCircleNot"></div>
                    </div>
                    <div class="circleNot" style="background-color: rgb(250, 239, 90);">
                        <div class="shineCircleNot"></div>
                    </div>
                    <div class="circleNot" style="background-color: rgb(14, 218, 14);">
                        <div class="shineCircleNot"></div>
                    </div>   
                </div>
                <div class="cuadroIzqInf"></div>
            </div>
            <div class="screenFrame">
                <div class="screen text-center">
                    <img src="<%:Pokemon.ImgUrl%>" alt="" class="imgPokemon">
                    <div class="screenFront"></div>
                </div>
            </div>
            <div class="pokeName tiny5-regular text-center">
                <label class="p-2" for=""><%: Pokemon.Nombre %></label>
            </div>
            <div class="pokeNumber tiny5-regular text-center align-content-center">
                <label for="">N°<%: Pokemon.Numero %></label>
            </div>
            <div class="bisagra" hidden>
                <div class="bisagraSup"></div>
                <div class="bisagraInf"></div>
            </div>   
        </div>
        <div class="cuadroDer">
            <div class="cuadroDerInt">
                <div class="containerFisic">
                    <div class="card tiny5-regular cardTypeFisic">
                        <div class="card-header">Peso</div>
                        <div class="card-body">
                            <div class="card-text">> <%: Pokemon.Peso %>Kg</div>               
                        </div>
                    </div>
                    <div class="card tiny5-regular cardTypeFisic">
                        <div class="card-header">Altura</div>
                        <div class="card-body">
                            <div class="card-text">> <%: Pokemon.Altura %>m</div>               
                        </div>
                    </div>
                </div>
                <div class="card tiny5-regular cardType">
                    <div class="card-header">Tipo</div>
                    <div class="card-body">
                        <%foreach (Dominio.Elemento tipo in Pokemon.Tipos)
                            {%>
                                <div class="card-text">> <%:tipo.Descripcion %></div>               
                          <%} %>
                    </div>
                </div>
                <div class="card tiny5-regular cardType mt-2">
                    <div class="card-header">Debilidades</div>
                    <div class="card-body">
                        <%foreach (Dominio.Elemento debilidad in Pokemon.Debilidades)
                            {%>
                                <div class="card-text">> <%:debilidad.Descripcion %></div>               
                          <%} %>
                    </div>
                </div>
            </div>        
        </div>
    </div>
</asp:Content>
