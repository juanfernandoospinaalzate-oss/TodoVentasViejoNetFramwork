<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="ResultadoCajaCategoria.aspx.cs" Inherits="WebPublica.ResultadoCajaCategoria" %>
<%@ Register Src="~/ControlesDeUsuario/WucResultadocajaListadoCategoria.ascx" TagPrefix="uc1" TagName="WucResultadocajaListadoCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <div id="t-contenedor" class="ui grid">
            <uc1:WucResultadocajaListadoCategoria runat="server" id="WucResultadocajaListadoCategoria" />
        </div>
    </div>
    <br/>
</asp:Content>