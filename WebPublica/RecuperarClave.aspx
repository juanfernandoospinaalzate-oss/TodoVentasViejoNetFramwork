<%@ Page Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="RecuperarClave.aspx.cs" Inherits="WebPublica.RecuperarClave" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .cssEnviarSMS {
            color: white !important;
        }
    </style>

    <script type="text/javascript">
        function errorAlert() {
            swal({                           
                type: 'error',
                title: 'Código capcha NO válido!',
                text: 'El código no fue ingresado correctamente, verifique. ',
                icon: "warning",
                button: "Aceptar",
                dangerMode: true
            });
        }

        
        function errorEmailAlert() {
            swal({
                type: 'error',
                title: 'Email no encontrado!',
                text: 'El Email no se encuentra registrado en el sistema, verifique. ',
                icon: "warning",
                button: "Aceptar",
                dangerMode: true
            });
        }

        
        function errorNroCelularAlert() {
            swal({
                type: 'error',
                title: 'Celular NO válido!',
                text: 'El número de celular registrado en el sistema no es válido, Actualice su información. ',
                icon: "warning",
                button: "Aceptar",
                dangerMode: true
            });
        }


    </script>


    <div id="t-contenido" style="margin-bottom: 70px; margin-right: 30px;">

        <asp:Label ID="LblEmail" runat="server" Text="Ingresar Correo Electrónico"></asp:Label><br />
        <div class="ui left icon input">
            <asp:TextBox ID="TxtEmail" runat="server" Style="width: 500px;"></asp:TextBox>
        </div>

        <div style="margin-top: 2%;">
            <asp:Image ID="ImgCaptcha" ImageUrl="~/UtilidadesCaptcha/Captcha.ashx" runat="server" Width="500px" Height="200px" /><br /><br />
            <asp:LinkButton ID="LkbtnRefresh" runat="server" OnClick="LkbtnRefresh_Click">Recargar capcha</asp:LinkButton>
        </div>

        <asp:Label ID="LblException" runat="server"></asp:Label>
        <div style="margin-top: 3%;">
            <div class="ui left icon input">
                <asp:TextBox ID="txtCaptcha" placeholder="Escribe el texto de seis(6) digitos" MaxLength="6" runat="server" Style="width: 500px;"></asp:TextBox><br />
            </div>
            <div class="ui red submit button">
                <asp:LinkButton ID="LkBtnEnviarSMS" runat="server" OnClick="LkBtnEnviarSMS_Click" CssClass="cssEnviarSMS">ENVIAR TEXTO</asp:LinkButton>
            </div>
        </div>


    </div>

</asp:Content>
