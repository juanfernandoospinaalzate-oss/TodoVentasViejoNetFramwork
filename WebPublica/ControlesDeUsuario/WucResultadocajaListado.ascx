<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucResultadocajaListado.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucResultadocajaListado" %>
<%@ Register Src="~/ControlesDeUsuario/WucResultadoCaja.ascx" TagPrefix="uc1" TagName="WucResultadoCaja" %>

<div> 
    <div style="display:block;margin-bottom:35px">
        <div style="display:inline-block;float:left">
            <asp:Label ID="LblInformacionPaginacion" runat="server" Text=""></asp:Label>
        </div>
        <div style="display:inline-block;text-align:right;float:right"><%--;width:100%--%>
            <asp:Label ID="LblTamanioPagina" runat="server" Text="Artículos por página: "></asp:Label>
            <asp:LinkButton ID="LinkButtonTamanioPagina10" runat="server" OnClick="LinkButtonTamanioPagina_Click" CommandArgument="10">10</asp:LinkButton> | 
            <asp:LinkButton ID="LinkButtonTamanioPagina25" runat="server" OnClick="LinkButtonTamanioPagina_Click" CommandArgument="25">25</asp:LinkButton> | 
            <asp:LinkButton ID="LinkButtonTamanioPagina50" runat="server" OnClick="LinkButtonTamanioPagina_Click" CommandArgument="50">50</asp:LinkButton> | 
            <asp:LinkButton ID="LinkButtonTamanioPagina100" runat="server" OnClick="LinkButtonTamanioPagina_Click" CommandArgument="100">100</asp:LinkButton>
        </div>
        <asp:HiddenField ID="HiddenFieldTamanioPagina" runat="server" />
        <br />
    </div>
    <div class="ui left aligned four column doubling grid">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <uc1:WucResultadoCaja runat="server" ID="WucResultadoCaja" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="text-align: center;">
        <div>
            <br />
            <br />
        </div>
        <asp:LinkButton ID="LinkButtonAnterior" runat="server" OnClick="LinkButtonAnterior_Click">< Anterior</asp:LinkButton>
        <asp:Repeater ID="RepeaterPaginacion" runat="server" OnItemDataBound="RepeaterPaginacion_ItemDataBound">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="LinkButtonNroPagina" OnClick="LinkButtonNroPagina_Click">LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="LinkButtonSiguiente" runat="server" OnClick="LinkButtonSiguiente_Click">Siguiente ></asp:LinkButton>
    </div>
    <div>
        <br />
    </div>
</div>


