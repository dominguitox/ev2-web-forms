
<%@ Page Title="Consultas LINQ"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ConsultasLINQ.aspx.cs"
    Inherits="ev2_web_forms.Administrador.ConsultasLINQ" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container mt-4">

        <h2>Consultas LINQ - Help Desk TI</h2>
        <hr />

        <p>
            Módulo de consultas a la base de datos mediante
            LINQ y Entity Framework.
        </p>

        <asp:Label
            ID="lblMensaje"
            runat="server"
            CssClass="alert alert-info d-block">
        </asp:Label>

        <hr />

        <h4>1. Consulta Where</h4>

        <p>Filtrar tickets según su estado.</p>

        <div class="form-group mb-3">

            <asp:DropDownList
                ID="ddlEstado"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>

        </div>

        <asp:Button
            ID="btnWhere"
            runat="server"
            Text="Consultar por estado"
            CssClass="btn btn-primary mb-4"
            OnClick="btnWhere_Click" />

        <hr />

        <h4>2. Consulta Select</h4>

        <p>Mostrar información específica de los tickets.</p>

        <asp:Button
            ID="btnSelect"
            runat="server"
            Text="Ejecutar Select"
            CssClass="btn btn-primary mb-4"
            OnClick="btnSelect_Click" />

        <hr />

        <h4>3. Consulta GroupBy</h4>

        <p>Agrupar tickets según su estado y contar registros.</p>

        <asp:Button
            ID="btnGroupBy"
            runat="server"
            Text="Agrupar tickets"
            CssClass="btn btn-primary mb-4"
            OnClick="btnGroupBy_Click" />

        <hr />

        <h4>4. Consulta Join</h4>

        <p>Relacionar tickets con los técnicos asignados.</p>

        <asp:Button
            ID="btnJoin"
            runat="server"
            Text="Consultar técnicos"
            CssClass="btn btn-primary mb-4"
            OnClick="btnJoin_Click" />

        <hr />

        <h4>5. Consulta First</h4>

        <p>Obtener el ticket más antiguo registrado.</p>

        <asp:Button
            ID="btnFirst"
            runat="server"
            Text="Obtener primer ticket"
            CssClass="btn btn-primary mb-4"
            OnClick="btnFirst_Click" />

        <hr />

        <h4>6. Consulta Find</h4>

        <p>Buscar un ticket utilizando su identificador.</p>

        <div class="form-group mb-3">

            <asp:TextBox
                ID="txtIdTicket"
                runat="server"
                TextMode="Number"
                CssClass="form-control"
                placeholder="Ingrese el ID del ticket">
            </asp:TextBox>

        </div>

        <asp:Button
            ID="btnFind"
            runat="server"
            Text="Buscar ticket"
            CssClass="btn btn-primary mb-4"
            OnClick="btnFind_Click" />

        <hr />

        <h4>7. Consulta ToList</h4>

        <p>Mostrar todos los tickets registrados.</p>

        <asp:Button
            ID="btnToList"
            runat="server"
            Text="Listar todos los tickets"
            CssClass="btn btn-primary mb-4"
            OnClick="btnToList_Click" />

        <hr />

        <asp:Panel
            ID="pnlResultados"
            runat="server"
            Visible="false">

            <h4>
                <asp:Label
                    ID="lblTituloResultado"
                    runat="server">
                </asp:Label>
            </h4>

            <div class="table-responsive">

                <asp:GridView
                    ID="gvResultados"
                    runat="server"
                    AutoGenerateColumns="true"
                    CssClass="table table-striped table-bordered table-hover"
                    GridLines="None"
                    EmptyDataText="No existen resultados para esta consulta."
                    HeaderStyle-CssClass="table-dark">

                </asp:GridView>

            </div>

        </asp:Panel>

        <hr />

        <a href="PanelAdministrador.aspx"
           class="btn btn-secondary">
            Volver al panel administrador
        </a>

    </div>

</asp:Content>
