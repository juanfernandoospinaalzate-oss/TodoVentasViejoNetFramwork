<%@ Page Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="ConfimarCodigoVerificacion.aspx.cs" Inherits="WebPublica.ConfimarCodigoVerificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .cssEnviarSMS {
            color: white !important;
        }

        .cssTxtCodigoVerificacion {
            margin-right: 5% !important;
        }
    </style>

    <script type="text/javascript">
        function errorAlert() {
            swal({                           
                type: 'error',
                title: 'Código NO válido!',
                text: 'El código de verificación NO es válido',
                icon: "warning",
                button: "Aceptar",
                dangerMode: true
            });
        }

        function infoAlert() {
            swal({
                type: 'info',
                title: 'Código vacío!',
                text: 'Debe ingresar el código de verificación enviado a su celular',
                icon: "info",
                button: "Aceptar",
                dangerMode: true
            });
        }


    </script>


    <div id="t-contenido" style="margin-bottom: 70px; margin-right: -6%;">

        <h3>Ingresar código de verificación</h3>
        <div class="ui left icon input">
            <asp:TextBox ID="TxtCodigoVerificacion" MaxLength="6" CssClass="cssTxtCodigoVerificacion" runat="server"></asp:TextBox>
            <div class="ui red submit button">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="cssEnviarSMS">VERIFICAR</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>

