<%@ Page Title="Área Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioCliente.aspx.cs" Inherits="ev2_web_forms.Cliente.InicioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Área Cliente Congelandia</h2>
        <hr />
        <asp:Label ID="lblBienvenida" runat="server" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-3" />

        <h4 class="mt-4">Crear ticket</h4>
        <div class="mb-3">
            <asp:Label ID="lblTitulo" runat="server" Text="Título" AssociatedControlID="txtTitulo" />
            <asp:TextBox ID="txtTitulo" runat="server" MaxLength="150" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" AssociatedControlID="txtDescripcion" />
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad" AssociatedControlID="ddlPrioridad" />
            <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-control" />
        </div>
        <asp:Button ID="btnCrear" runat="server" Text="Crear ticket" CssClass="btn btn-primary" OnClick="btnCrear_Click" />

        <h4 class="mt-5">Mis tickets</h4>
        <div class="table-responsive">
            <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" EmptyDataText="No tienes tickets registrados.">
                <Columns>
                    <asp:BoundField DataField="IdTicket" HeaderText="N.º Ticket" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                    <asp:BoundField DataField="Solucion" HeaderText="Solución" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                </Columns>
            </asp:GridView>
        </div>

        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar sesión" CssClass="btn btn-danger" OnClick="btnCerrar_Click" />
    </div>
</asp:Content>