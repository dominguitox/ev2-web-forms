
<%@ Page Title="Panel Técnico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelTecnico.aspx.cs" Inherits="ev2_web_forms.Tecnico.PanelTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2>Panel de Técnico - Help Desk TI</h2>

        <hr />

        <asp:Label
            ID="lblBienvenida"
            runat="server"
            Font-Size="Large">
        </asp:Label>

        <br />

        <asp:Label
            ID="lblEspecialidad"
            runat="server"
            CssClass="text-muted">
        </asp:Label>

        <br /><br />

        <asp:Label
            ID="lblMensaje"
            runat="server">
        </asp:Label>

        <asp:Panel ID="pnlContenido" runat="server">

            <h4>Mis tickets asignados</h4>

            <div class="table-responsive">

                <asp:GridView
                    ID="gvTickets"
                    runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="IdTicket"
                    CssClass="table table-striped table-bordered table-hover"
                    EmptyDataText="No tienes tickets asignados."
                    GridLines="None"
                    OnSelectedIndexChanged="gvTickets_SelectedIndexChanged">

                    <Columns>

                        <asp:CommandField
                            ShowSelectButton="True"
                            SelectText="Gestionar" />

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
                            DataField="Estado"
                            HeaderText="Estado" />

                        <asp:BoundField
                            DataField="Prioridad"
                            HeaderText="Prioridad" />

                        <asp:BoundField
                            DataField="FechaCreacion"
                            HeaderText="Fecha"
                            DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                    </Columns>

                </asp:GridView>

            </div>

            <hr />

            <asp:Panel
                ID="pnlActualizar"
                runat="server"
                Visible="False">

                <h4>Actualizar ticket seleccionado</h4>

                <asp:Label
                    ID="lblTicketSeleccionado"
                    runat="server"
                    Font-Bold="True">
                </asp:Label>

                <br /><br />

                <div class="mb-3">

                    <asp:Label
                        ID="lblEstado"
                        runat="server"
                        Text="Estado del ticket">
                    </asp:Label>

                    <asp:DropDownList
                        ID="ddlEstado"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>

                </div>

                <div class="mb-3">

                    <asp:Label
                        ID="lblSolucion"
                        runat="server"
                        Text="Solución o comentarios técnicos">
                    </asp:Label>

                    <asp:TextBox
                        ID="txtSolucion"
                        runat="server"
                        TextMode="MultiLine"
                        Rows="4"
                        CssClass="form-control">
                    </asp:TextBox>

                </div>

                <asp:Button
                    ID="btnGuardar"
                    runat="server"
                    Text="Guardar cambios"
                    CssClass="btn btn-success"
                    OnClick="btnGuardar_Click" />

                <asp:Button
                    ID="btnCancelar"
                    runat="server"
                    Text="Cancelar"
                    CssClass="btn btn-secondary"
                    CausesValidation="False"
                    OnClick="btnCancelar_Click" />

            </asp:Panel>

        </asp:Panel>

        <br />

        <asp:Button
            ID="btnCerrar"
            runat="server"
            Text="Cerrar sesión"
            CssClass="btn btn-danger"
            OnClick="btnCerrar_Click" />

    </div>

</asp:Content>
