<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucMenuCategorias.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucMenuCategorias" %>
<asp:Menu ID="MenuCategorias" runat="server" EnableViewState="False" OnMenuItemClick="MenuCategorias_MenuItemClick">
    <LevelMenuItemStyles>
        <asp:MenuItemStyle ForeColor="White" Font-Size="18px" Font-Names="Lato,'Helvetica Neue',Arial,Helvetica,sans-serif" />
        <asp:MenuItemStyle ForeColor="White" Font-Size="17px" Width="210px" Font-Names="Lato,'Helvetica Neue',Arial,Helvetica,sans-serif" />
        <asp:MenuItemStyle ForeColor="White" Font-Size="17px" Width="340px" Font-Names="Lato,'Helvetica Neue',Arial,Helvetica,sans-serif" />
        <asp:MenuItemStyle ForeColor="White" Font-Size="17px" Width="195px" Font-Names="Lato,'Helvetica Neue',Arial,Helvetica,sans-serif" />
    </LevelMenuItemStyles>

    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#cccccc" ForeColor="Black"  />
    <DynamicMenuStyle BackColor="#212121" />
    <DynamicSelectedStyle BackColor="#507CD1" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"  />
</asp:Menu>

<%--Expanded="False" ShowExpandCollapse="False" --%>