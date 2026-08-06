<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucFiltroArticulo.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.FiltrosArticulo" %>

<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList_ItemDataBound" OnItemCommand="DataList_ItemCommand">
    <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" class="CajaFiltroArticulo" >Datos</asp:LinkButton>&nbsp;
    </ItemTemplate>
</asp:DataList>
<asp:HiddenField ID="HiddenFieldFiltroSeleccionado1" runat="server" />
<asp:HiddenField ID="HiddenFieldValorFiltroSeleccionado1" runat="server" />
<br />

<asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList_ItemDataBound" OnItemCommand="DataList_ItemCommand">
    <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" class="CajaFiltroArticulo">Datos</asp:LinkButton>&nbsp;
    </ItemTemplate>
</asp:DataList>
<asp:HiddenField ID="HiddenFieldFiltroSeleccionado2" runat="server" />
<asp:HiddenField ID="HiddenFieldValorFiltroSeleccionado2" runat="server" />
<br />

<asp:DataList ID="DataList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList_ItemDataBound" OnItemCommand="DataList_ItemCommand">
    <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" class="CajaFiltroArticulo" >Datos</asp:LinkButton>&nbsp;
    </ItemTemplate>
</asp:DataList>
<asp:HiddenField ID="HiddenFieldFiltroSeleccionado3" runat="server" />
<asp:HiddenField ID="HiddenFieldValorFiltroSeleccionado3" runat="server" />