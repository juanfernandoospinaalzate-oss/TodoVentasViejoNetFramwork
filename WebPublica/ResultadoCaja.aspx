<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="ResultadoCaja.aspx.cs" Inherits="WebPublica.ResultadoCaja" %>
<%@ Register Src="~/ControlesDeUsuario/WucResultadocajaListado.ascx" TagPrefix="uc1" TagName="WucResultadocajaListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <div id="t-contenedor" class="ui grid">
            <uc1:WucResultadocajaListado runat="server" id="WucResultadocajaListado" />
        </div>
    </div>
    <br/>
</asp:Content>
