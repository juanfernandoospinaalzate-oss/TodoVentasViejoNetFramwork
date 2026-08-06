<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucListaVistaPreviaArticulo.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucListaVistaPreviaArticulo" %>
<%@ Register src="WucVistaPreviaArticulo.ascx" tagname="WucVistaPreviaArticulo" tagprefix="uc1" %>

<html>
<head>
</head>
<body>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <uc1:WucVistaPreviaArticulo ID="WucVistaPreviaArticulo1" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</body>
</html>
