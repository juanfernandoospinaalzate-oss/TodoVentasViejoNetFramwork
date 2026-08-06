<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucVistaPreviaArticulo.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucVistaPreviaArticulo" %>
<html>
<head>
    <title>Titulo de la web</title>

</head>
<body>

    <div style="width:700px">

        <div style="float:left">
            <a href="" id="linkImagenPresentacionArticulo" runat="server">
                <img alt="" src="" style="width:200px;height:200px" id="Imagen" runat="server" />
            </a>
        </div>

        <div>
                <a href="" id="linkPresentacionArticulo" runat="server"></a>
                <br>
                <label id="LblDescripcionBreve" runat="server"></label>
                <br>
                Precio: <label id="LblPrecio" runat="server"></label>
        </div>

    </div>
</body>
</html>
