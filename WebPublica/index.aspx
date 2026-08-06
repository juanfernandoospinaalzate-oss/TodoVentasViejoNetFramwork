<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebPublica.Index" %>

<%@ Register Src="~/ControlesDeUsuario/WucBannerPrincipal.ascx" TagPrefix="uc1" TagName="WucBannerPrincipal" %>
<%@ Register Src="~/ControlesDeUsuario/WucResultadocajaListado.ascx" TagPrefix="uc1" TagName="WucResultadocajaListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentBanner" ContentPlaceHolderID="ContentPlaceHolderBanner" runat="server">
    <uc1:WucBannerPrincipal runat="server" ID="WucBannerPrincipal" />
    <div id="t-contenido">
        <div id="t-contenedor" class="ui grid">
            <uc1:WucResultadocajaListado runat="server" id="WucResultadocajaListado" />
        </div>
    </div>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
