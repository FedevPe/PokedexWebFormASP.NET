<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPokemons.aspx.cs" Inherits="PokedexWebForms.ListPokemons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
</asp:Content>
