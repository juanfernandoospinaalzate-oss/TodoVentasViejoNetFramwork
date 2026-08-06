<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentSuccessful.aspx.cs" Inherits="WebPublica.PasarelasDePago.RedirectUrlsPayPal.PaymentSuccessful" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pago realizado con éxito</title>
    <style>
        .centrar {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 400px;
            margin-left: -200px;
            height: 300px;
            margin-top: -130px;
            padding: 5px;
        }

        .tamanioImagen {
            -webkit-transform: rotateY(10deg);
            background: blue;
            height: 200px;
            width: 400px;
        }

        .centrarH1 {
            text-align: center;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
    </style>
</head>
<body style="height: 362px">
    <h1 class="centrarH1">Pago realizado correctamente!</h1>
    <div class="centrar">
        <img class="tamanioImagen" src="../Graficas/Imagenes/LOGO-GOOGLE.jpg" />
        <asp:Button CssClass="button" ID="BtnRedirectCarrito" runat="server" Text="Regresar a TodoVentasColombia" Width="401px" OnClick="BtnRedirectCarrito_Click" />
    </div>
</body>
</html>
