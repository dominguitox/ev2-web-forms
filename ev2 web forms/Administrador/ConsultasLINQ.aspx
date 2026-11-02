<%@ Page
    Title="Consultas LINQ"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ConsultasLINQ.aspx.cs"
    Inherits="ev2_web_forms.Administrador.ConsultasLINQ" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<style>
    .linq-container {
        max-width: 1150px;
        margin: 25px auto;
        padding: 15px;
    }

    .linq-header {
        margin-bottom: 25px;
    }

    .linq-card {
        background: #ffffff;
        border: 1px solid #dee2e6;
        border-radius: 10px;
        padding: 20px;
        margin-bottom: 18px;
        box-shadow: 0 2px 7px rgba(0,0,0,0.05);
    }

    .linq-card h4 {
        font-size: 18px;
        font-weight: 600;
        margin-bottom: 10px;
    }

    .linq-card p {
        color: #666;
        margin-bottom: 15px;
    }

    .linq-card code {
        background: #edf2f7;
        padding: 3px 7px;
        border-radius: 4px;
        color: #24527a;
    }

    .linq-input {
        max-width: 350px;
        margin-bottom: 12px;
    }

    .resultado-panel {
        background: #ffffff;
        border: 1px solid #dee2e6;
        border-radius: 10px;
        padding: 20px;
        margin-top: 25px;
        overflow-x: auto;
    }

    .mensaje {
        display: block;
        padding: 12px;
        margin-top: 15px;
        border-radius: 6px;
    }

    .mensaje.success {
        background: #d1e7dd;
        color: #0f5132;
    }

    .mensaje.info {
        background: #cff4fc;
        color: #055160;
    }

    .mensaje.error {
        background: #f8d7da;
        color: #842029;
    }
</style>

<div class="linq-container">

    <div class="linq-header">
        <h2>Consultas LINQ</h2>
        <p>
            Módulo de consultas y análisis de tickets
            mediante LINQ to Entities y Entity Framework.
        </p>

        <asp:HyperLink
            ID="hlVolver"
            runat="server"
            NavigateUrl="PanelAdministrador.aspx"
            CssClass="btn btn-secondary"
            Text="Volver al panel" />
    </div>

    <!-- WHERE -->

    <div class="linq-card">
        <h4>1. Buscar tickets por estado</h4>
        <p>
            Utiliza <code>Where()</code> para filtrar los tickets
            según el estado seleccionado.
        </p>

        <asp:DropDownList
            ID="ddlEstado"
            runat="server"
            CssClass="form-control linq-input">
        </asp:DropDownList>

        <asp:Button
            ID="btnWhere"
            runat="server"
            Text="Ejecutar WHERE"
            CssClass="btn btn-primary"
            OnClick="btnWhere_Click" />
    </div>

    <!-- SELECT -->

    <div class="linq-card">
        <h4>2. Seleccionar información de tickets</h4>
        <p>
            Utiliza <code>Select()</code> para obtener solamente
            los campos necesarios de cada ticket.
        </p>

        <asp:Button
            ID="btnSelect"
            runat="server"
            Text="Ejecutar SELECT"
            CssClass="btn btn-primary"
            OnClick="btnSelect_Click" />
    </div>

    <!-- GROUP BY -->

    <div class="linq-card">
        <h4>3. Agrupar tickets por estado</h4>
        <p>
            Utiliza <code>GroupBy()</code> para calcular
            la cantidad de tickets correspondiente a cada estado.
        </p>

        <asp:Button
            ID="btnGroupBy"
            runat="server"
            Text="Ejecutar GROUP BY"
            CssClass="btn btn-primary"
            OnClick="btnGroupBy_Click" />
    </div>

    <!-- JOIN -->

    <div class="linq-card">
        <h4>4. Relacionar tickets con técnicos</h4>
        <p>
            Utiliza <code>Join()</code> para relacionar los tickets
            con los técnicos responsables.
        </p>

        <asp:Button
            ID="btnJoin"
            runat="server"
            Text="Ejecutar JOIN"
            CssClass="btn btn-primary"
            OnClick="btnJoin_Click" />
    </div>

    <!-- FIRST -->

    <div class="linq-card">
        <h4>5. Obtener el primer ticket</h4>
        <p>
            Utiliza <code>First()</code> para recuperar
            el ticket más antiguo registrado.
        </p>

        <asp:Button
            ID="btnFirst"
            runat="server"
            Text="Ejecutar FIRST"
            CssClass="btn btn-primary"
            OnClick="btnFirst_Click" />
    </div>

    <!-- FIND -->

    <div class="linq-card">
        <h4>6. Buscar ticket por identificador</h4>
        <p>
            Utiliza <code>Find()</code> para localizar
            un ticket mediante su clave primaria.
        </p>

        <asp:TextBox
            ID="txtIdTicket"
            runat="server"
            CssClass="form-control linq-input"
            placeholder="Ingrese el ID del ticket">
        </asp:TextBox>

        <asp:Button
            ID="btnFind"
            runat="server"
            Text="Ejecutar FIND"
            CssClass="btn btn-primary"
            OnClick="btnFind_Click" />
    </div>

    <!-- TOLIST -->

    <div class="linq-card">
        <h4>7. Listar todos los tickets</h4>
        <p>
            Utiliza <code>ToList()</code> para recuperar
            los registros existentes en la base de datos.
        </p>

        <asp:Button
            ID="btnToList"
            runat="server"
            Text="Ejecutar TOLIST"
            CssClass="btn btn-primary"
            OnClick="btnToList_Click" />
    </div>

    <!-- MENSAJES -->

    <asp:Label
        ID="lblMensaje"
        runat="server"
        Visible="false">
    </asp:Label>

    <!-- RESULTADOS -->

    <asp:Panel
        ID="pnlResultados"
        runat="server"
        Visible="false"
        CssClass="resultado-panel">

        <h3>
            <asp:Label
                ID="lblTituloResultado"
                runat="server">
            </asp:Label>
        </h3>

        <hr />

        <asp:GridView
            ID="gvResultados"
            runat="server"
            AutoGenerateColumns="true"
            EmptyDataText="No existen registros para mostrar."
            CssClass="table table-striped table-bordered"
            GridLines="None">
        </asp:GridView>

    </asp:Panel>

</div>

</asp:Content>
