<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebformPruebas.aspx.cs" Inherits="WebPublica.WebformPruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        ActualizarArticulosDesdeBaseDatos_a_SitioWeb
        <asp:Button ID="ActualizarArticulosDesdeBaseDatos_a_SitioWeb" runat="server" OnClick="ActualizarArticulosDesdeBaseDatos_a_SitioWeb_Click" Text="ActualizarArticulosDesdeBaseDatos_a_SitioWeb()" />
        <p>
            &nbsp;</p>
        ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb
        <asp:Button ID="ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb" runat="server" OnClick="ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb_Click" Text="ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb()" />
        <p>
            &nbsp;</p>
        RemoverPublicacionesSitioWeb
        <asp:Button ID="RemoverPublicacionesSitioWeb" runat="server" OnClick="RemoverPublicacionesSitioWeb_Click" Text="RemoverPublicacionesSitioWeb()" />
    </form>
</body>
</html>
