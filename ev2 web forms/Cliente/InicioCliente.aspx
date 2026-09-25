<%@ Page Title="Área Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioCliente.aspx.cs" Inherits="ev2_web_forms.Cliente.InicioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2>Área Cliente Congelandia</h2>

        <hr />

        <asp:Label 
            ID="lblBienvenida" 
            runat="server">
        </asp:Label>

        <br />
        <br />

        <p>
            Bienvenido al área privada de clientes.
        </p>

        <asp:Button
            ID="btnCerrar"
            runat="server"
            Text="Cerrar sesión"
            CssClass="btn btn-danger"
            OnClick="btnCerrar_Click" />

    </div>

</asp:Content>