<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ev2_web_forms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">CONGELANDIA</h1>
            <p class="lead">Congelandia es una comercial de productos congelados, con presencia y despacho en Talca. Líderes en el área y más de 67 años de experiencia</p>
            <p><a href="/QuienesSomos" class="btn btn-primary btn-md">Sobre Nosotros &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="">Compra en nuestro local físico</h2>
                <p>
                    Nuestra casa central se ubica en pleno centro de Talca. Puedes venir y ver nuestro catálogo en persona.</p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">¿Por qúé Congelandia?</h2>
                <p>
                    A diferencia de la competición, nuestros productos congelados duran un 67% más de tiempo congelados. Somos los reyes de los productos congelandos
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Soberanía de los productos congelados</h2>
                <p>
                    Necesitamos <strong>15000</strong> firmas para lograr que Congelandia (la tierra de los productos congelados) sea un país independiente en Talca, 
                    registrate y participa para poder ser elegido como el embajador de Congelandia en Chile.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
