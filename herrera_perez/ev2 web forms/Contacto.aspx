<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="ev2_web_forms.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Dudas? Consultas? Negocios?</h3>
        <address>
            742 Evergreen Terrace <br />
            Springfield<br />
            <abbr title="Phone">Número WSP:</abbr>
            +569 555 1234
        </address>

        <address>
            <strong>Consultas:</strong>   <a href="mailto:Support@example.com">Soporte@congelandia.cl</a><br />
            <strong>Negocios:</strong> <a href="mailto:Marketing@example.com">Negocios@congelandia.cl</a>
        </address>
    </main>
</asp:Content>
