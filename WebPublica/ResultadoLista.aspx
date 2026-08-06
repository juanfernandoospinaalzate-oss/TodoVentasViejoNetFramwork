<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="ResultadoLista.aspx.cs" Inherits="WebPublica.ResultadoLista" %>

<%@ Register Src="~/ControlesDeUsuario/WucResultadoLista.ascx" TagPrefix="uc1" TagName="WucResultadoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <div id="t-contenedor" class="ui grid">
            <div id="t-productoslista" class="twelve wide column">
                <div class="ui items">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <uc1:WucResultadoLista runat="server" id="WucResultadoLista" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
