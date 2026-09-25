<%@ Page Title="Administrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdministrador.aspx.cs" Inherits="ev2_web_forms.Administrador.PanelAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2>
            Panel Administrador Congelandia
        </h2>

        <hr />

        <asp:Label
            ID="lblAdmin"
            runat="server"
            Font-Size="Large">
        </asp:Label>


        <br /><br />


        <p>
            Desde este panel el administrador puede gestionar 
            información interna del emprendimiento.
        </p>


        <br />


        <asp:Button
            ID="btnCerrar"
            runat="server"
            Text="Cerrar sesión"
            CssClass="btn btn-danger"
            OnClick="btnCerrar_Click" />

    </div>

</asp:Content>