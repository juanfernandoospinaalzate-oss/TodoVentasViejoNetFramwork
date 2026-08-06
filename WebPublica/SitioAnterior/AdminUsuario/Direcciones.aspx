<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Direcciones.aspx.cs" Inherits="WebPublica.AdminUsuario.Direcciones" %>

<%@ Register Src="~/ControlesDeUsuario/WucPaisDepartamentoCiudad.ascx" TagName="WucPaisDepartamentoCiudad" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="t-contenido">
        <br />
        <div class="ui segment">

            <div class="ui form">
                <h3 class="ui dividing header">
                    <asp:Label ID="LblTitulo" runat="server" Text="Gestión de Direcciones"></asp:Label>
                </h3>

                <div>

                    <div class="ui two fields">

                        <div class="field">
                            <div class="field">
                                <asp:Label ID="LblNombreDestinatario" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtNomDestinatario" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="field">
                                <asp:Label ID="LblDireccionEnvio" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="field">
                                <asp:Label ID="LblTelefono" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                        </div>

                        <div class="field">
                            <div class="field">
                                <uc1:WucPaisDepartamentoCiudad ID="WucPaisDepartamentoCiudad1" runat="server" />
                            </div>
                        </div>

                    </div>

                    <div class="two fields">
                        <asp:GridView ID="DgvDireccion" runat="server" AutoGenerateColumns="False" DataKeyNames="IdDireccion,IdPais,IdDepartamento,IdCiudad" OnRowEditing="DgvDireccion_RowEditing" OnRowUpdating="DgvDireccion_RowUpdating" OnRowDataBound="DgvDireccion_RowDataBound" OnRowCancelingEdit="DgvDireccion_RowCancelingEdit" OnRowDeleting="DgvDireccion_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <EditItemTemplate>
                                        <uc1:WucPaisDepartamentoCiudad ID="WucPaisDepartamentoCiudad2" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LblPais" runat="server" Text='<%# Bind("NombrePais") %>'></asp:Label>
                                        <asp:Label ID="LblDepartamento" runat="server" Text='<%# Bind("NombreDepartamento") %>'></asp:Label>
                                        <asp:Label ID="LboCiudad" runat="server" Text='<%# Bind("NombreCiudad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombreDestinatario" HeaderText="	" />
                                <asp:BoundField DataField="DireccionEnvio" HeaderText="" />
                                <asp:BoundField DataField="Telefono" HeaderText="" />
                                <asp:CommandField CancelText="Cancelar" CausesValidation="False" DeleteText="Eliminar" EditText="Editar" InsertText="Ingresar" SelectText="Seleccionar" ShowEditButton="True" UpdateText="Actualizar" />
                                <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="ui buttons">
                        <asp:Button CssClass="ui red button" ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Agregar" style="margin-top: 30%;" />
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
