﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPokemons.aspx.cs" Inherits="PokedexWebForms.ListPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div class="container-fluid rounded border shadow-sm mt-4 bg-white">
        <div class="row">
            <div class="col">
                <span class="fw-bold fs-4">Buscar Pokemon</span>
            </div>
        </div>
        <div class="row g-2">
            <div class="col-md-8 col-sm-12 mb-3">
                <div class="form-floating">
                    <asp:TextBox cssclass="form-control" id="TxtSearch" type="text" placeholder="Nombre del Pokemon" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true" />  
                </div>
            </div>
            <div class="col-md-4 col-sm-12 align-content-center text-end">
                <asp:Button CssClass="btn btn-primary mb-2 " Text="Agregar Pokemon" runat="server"/>
            </div>
        </div>
    </div>
    <hr>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row mt-4"> 
                <asp:Repeater runat="server" ID="cardPokemonRepeater">
                    <ItemTemplate>
                           <div class="col-xl-3 col-md-6 col-sm-12 mb-2">
                            <div class="card cardAnimation shadow h-100">
                                <div class="card-img-top text-center">
                                    <img src="<%#Eval("ImgUrl")%>" alt="" class="imgPokemon">
                                </div>
                                <div class="card-header">
                                    <div class="text-start">
                                        <h5><%#Eval("Nombre")%></h5>                                                    
                                    </div>
                                </div>
                                <div class="card-text mt-2 mb-2 h-100">
                                    <div class="container text-start h-100">
                                        <p><%#Eval("Bio") %></p>                            
                                    </div>
                                </div> 
                                <div class="card-footer d-flex">
                                    <asp:Button runat="server" ID="btnDetails" CssClass="btn btn-outline-primary" OnClick="BtnDetails_Click" Text="Detalles" CommandArgument='<%#Eval("Id")%>'/>
                                </div>
                            </div>
                           </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row text-center mt-4">
                <div class="col-12">
                    <nav>
                        <ul class="pagination justify-content-center">
                            <%--<li class="page-item" id="previousPageItem">
                                <asp:LinkButton runat="server" ID="btnPrevious" CssClass="page-link" OnClick="BtnPrevious_Click">Previous</asp:LinkButton>
                            </li>--%>

                            <asp:Repeater runat="server" ID="pageNumberRepeater">
                                <ItemTemplate>
                                    <li class="page-item <%# Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(Container.DataItem) ? "active" : "" %>">
                                        <asp:LinkButton runat="server" CssClass="page-link" OnClick="PageNumber_Click" CommandArgument='<%# Container.DataItem %>'>
                                            <%# Container.DataItem %>
                                        </asp:LinkButton>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                            <%--<li class="page-item" id="nextPageItem">
                                <asp:LinkButton runat="server" ID="btnNext" CssClass="page-link" OnClick="BtnNext_Click">Next</asp:LinkButton>
                            </li>--%>
                        </ul>
                    </nav>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TxtSearch" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<style>
    .sizeImg{
        height: 100px;
        width: 100px;
        max-height: 100px;
        max-width: 100px;
        filter: drop-shadow(4px 6px 7px grey);
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

<%--    <div class="row">
        <div class="col">
            <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ID="dgvPokemons">                
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                </Columns>
            </asp:GridView>
        </div>
        
    </div>
    <style>
        .hidden{
            display:none;
        }
    </style>--%>
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

