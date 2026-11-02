
<%@ Page Title="Administrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdministrador.aspx.cs" Inherits="ev2_web_forms.Administrador.PanelAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2>Panel Administrador - Help Desk TI</h2>

        <hr />

        <asp:Label
            ID="lblAdmin"
            runat="server"
            Font-Size="Large">
        </asp:Label>

        <br /><br />

        <p>
            Desde este panel el administrador puede consultar
            y gestionar las solicitudes de soporte informático.
        </p>

        <hr />

        <!-- ACCESO A CONSULTAS LINQ -->
        <h4>Herramientas de administración</h4>

        <div class="card mb-4">
            <div class="card-body">

                <h5 class="card-title">
                    Consultas LINQ
                </h5>

                <p class="card-text">
                    Accede al módulo de consultas para analizar
                    los tickets registrados mediante LINQ y
                    Entity Framework.
                </p>

                <a href="ConsultasLINQ.aspx"
                   class="btn btn-info">
                    Acceder a Consultas LINQ
                </a>

            </div>
        </div>

        <hr />

        <!-- ESTADO DE CONEXIÓN -->
        <h4>Estado de la conexión a la base de datos</h4>

        <asp:Label
            ID="lblResultado"
            runat="server"
            CssClass="alert alert-info d-block">
        </asp:Label>

        <br />

        <!-- LISTADO DE TICKETS -->
        <h4>Tickets registrados</h4>

        <div class="table-responsive">

            <asp:GridView
                ID="gvTickets"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered table-hover"
                GridLines="None"
                EmptyDataText="No existen tickets registrados."
                HeaderStyle-CssClass="table-dark">

                <Columns>

                    <asp:BoundField
                        DataField="IdTicket"
                        HeaderText="N.º Ticket" />

                    <asp:BoundField
                        DataField="Titulo"
                        HeaderText="Título" />

                    <asp:BoundField
                        DataField="Descripcion"
                        HeaderText="Descripción" />

                    <asp:BoundField
                        DataField="IdUsuario"
                        HeaderText="ID Usuario" />

                    <asp:BoundField
                        DataField="IdTecnico"
                        HeaderText="ID Técnico" />

                    <asp:BoundField
                        DataField="IdEstado"
                        HeaderText="ID Estado" />

                    <asp:BoundField
                        DataField="IdPrioridad"
                        HeaderText="ID Prioridad" />

                    <asp:BoundField
                        DataField="FechaCreacion"
                        HeaderText="Fecha de creación"
                        DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                </Columns>

            </asp:GridView>

        </div>

        <br />

        <!-- CERRAR SESIÓN -->
        <asp:Button
            ID="btnCerrar"
            runat="server"
            Text="Cerrar sesión"
            CssClass="btn btn-danger"
            OnClick="btnCerrar_Click" />

    </div>

</asp:Content>
