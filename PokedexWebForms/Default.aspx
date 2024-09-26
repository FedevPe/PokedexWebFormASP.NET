<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokedexWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-4">
        <div class="col-12 text-center">
            <img class="sizeImg" src="https://upload.wikimedia.org/wikipedia/commons/5/51/Pokebola-pokeball-png-0.png">
            <span class="fs-2">Bienvenidos a la Pokedex!</span>
        </div>   
    </div>
        <hr>
    <div class="container-fluid rounded border border-light shadowCard">
        <div class="row">
            <div class="col">
                <span class="fw-bold fs-4">Buscar Pokemon</span>
            </div>
        </div>
        <div class="row g-2">
            <div class="col mb-3">
                <div class="form-floating">
                    <input class="form-control" id="txtSearch" type="text" placeholder="">  
                    <label class="form-label" for="txtSearch">Nombre o número</label>
                </div>
            </div>
            <div class="col-md-4 col-12 align-content-center text-end ">
                <button class="btn btn-primary"><i class="fa-solid fa-circle-plus me-2"></i>Agregar Pokemon</button>
            </div>
        </div>
    </div>
    <hr>
    <div class="row mt-4">
        <%foreach (Dominio.Pokemon pokemon in ListaPokemons)
          {%>
            <div class="col-xl-3 col-md-6 col-sm-12 mb-2">
                <div class="card cardAnimation shadowCard h-100">
                    <div class="card-img-top text-center">
                        <img src="<%:pokemon.ImgUrl%>" alt="" class="imgPokemon">
                    </div>
                    <div class="card-header">
                        <div class="text-start">
                            <h5><%:pokemon.Nombre%></h5>
                        </div>
                        <div class="card-text">                            
                            <div class="text-end">
                                <span class="btn btn-light fs-6 fst-italic fw-bold">N° <%:pokemon.Numero%></span>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        <%} %>
    </div>
    
    <style>
    .sizeImg{
        height: 100px;
        width: 100px;
        filter: drop-shadow(4px 6px 7px black);
    }
    .imgPokemon{
        height: 250px;
        width: 250px;
        filter: drop-shadow(4px 6px 7px grey);
        transition: all 0.3s ease;
    }
    .imgPokemon:hover{
        transform: scale(1.03);
    }
    .cardAnimation{
        transition: all 0.3s ease;
    }
    .cardAnimation:hover{
        transform: scale(1.01);
    }
    .shadowCard{
        box-shadow: 0.5px 0px 5px grey; 
    }
    </style>
</asp:Content>


<%--<div class="container mt-2">
    <div class="card-text">
            <span>Tipo: </span>
        <div class="row text-center mx-auto">                            
            <%foreach (Dominio.Elemento tipo in pokemon.Tipos)
                {%>
                    <div class="col-6 text-center">
                        <button class="btn btn-primary mb-2"><%:tipo.Descripcion%></button>
                    </div>
               <% } %>
        </div> 
            <span>Debilidades: </span>
         <div class="row text-center">                            
            <%foreach (Dominio.Elemento tipo in pokemon.Debilidades)
                {%>
                     <div class="col-6 text-center">
                        <button class="btn btn-warning mb-2"><%:tipo.Descripcion%></button>
                     </div>
               <% } %>
        </div>
            <span>Habilidades: </span>                         
            <%foreach (Dominio.Habilidad habilidad in pokemon.Habilidades)
                {%>
                    <div class="row">                            
                        <div class="btn-group text-center">
                            <button class="btn btn-success mb-2"><%:habilidad.Nombre%></button>
                            <button class="btn btn-info mb-2"><%:habilidad.Tipo.Descripcion%></button>
                        </div>
                    </div> 
               <% } %>
    </div>
</div>--%>

<%--<div class="row mt-4">            
    <div class="text-center">
        <div id="carouselPokemons" class="carousel carousel-dark slide">
            <div class="carousel-inner">          
                <%foreach (Dominio.Pokemon pokemon in ListaPokemons)
                  {%>
                    <%if (flag)
                      { %>
                        <%:flag=false %>
                        <div class="carousel-item <%: activeClass%>">                                
                   <% } 
                      else
                      { %>
                         <div class="carousel-item">
                     <% }%>
                        <div class="card">
                            <div class="card-img-top">
                                <img src="<%:pokemon.UrlImagen%>" alt="" class="imgPokemon">                                                                  
                            </div>
                            <div class="card-header">
                                <h5><%:pokemon.Nombre%></h5>
                                <div>
                                    <button class="btn btn-success me-2">Tipo: <%:pokemon.Tipo.Descripcion%></button>
                                    <button class="btn btn-warning">Debilidad: <%:pokemon.Debilidad.Descripcion%></button>
                                </div>
                            </div>
                        </div>
                    </div>
                <%} %>                      
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselPokemons" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselPokemons" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>              
    </div>
</div>--%>
