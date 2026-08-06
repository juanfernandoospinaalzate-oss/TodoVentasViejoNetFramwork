<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucBusqueda.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucBusqueda" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Panel ID="Panel1" runat="server" DefaultButton="LinkButtonBuscar">
    <asp:TextBox ID="TxtBuscador" runat="server" placeholder="Buscar..." MaxLength="50"></asp:TextBox>
    <asp:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" ServiceMethod="GetCompletionList" DelimiterCharacters="" Enabled="True" ServicePath="/Index.aspx" TargetControlID="TxtBuscador" UseContextKey="True">
    </asp:AutoCompleteExtender>
    <asp:LinkButton ID="LinkButtonBuscar" runat="server" OnClick="LinkButtonBuscar_Click" CausesValidation="False">
        <div runat="server" id="DivBotonBuscar" class="ui red button">Buscar</div>
    </asp:LinkButton>
</asp:Panel>