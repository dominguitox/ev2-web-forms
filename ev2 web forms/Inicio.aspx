<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ev2_web_forms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row mb-4" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">CONGELANDIA</h1>
            <p class="lead">Congelandia es una comercial de productos congelados, con presencia y despacho en Talca. Líderes en el área y casi 67 años de experiencia</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <div class="card">
                    <h2 id="">Compra en nuestro local físico</h2>
                    <p>
                        Nuestra casa central se ubica en pleno centro de Talca. Puedes venir y ver nuestro catálogo en persona.
                    </p>
          
                </div>

            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <div class="card">

                    <h2 id="librariesTitle">¿Por qúé Congelandia?</h2>
                    <p>
                        A diferencia de la competición, nuestros productos congelados duran un 67% más de tiempo congelados. Somos los reyes de los productos congelandos
                    </p>
                    <p>
                        <a class="btn btn-default" href="/Contacto.aspx">Contacto &raquo;</a>
                    </p>
                </div>

            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <div class="card">

                    <h2 id="hostingTitle">Soberanía de los productos congelados</h2>
                    <p>
                        Necesitamos <strong>15000</strong> firmas para lograr que Congelandia (la tierra de los productos congelados) sea un país independiente en Talca, 
                    registrate y participa para poder ser elegido como el embajador de Congelandia en Chile.
                    </p>
                    <p>
                        <a class="btn btn-default" href="/Login.aspx">Firmar &raquo;</a>
                    </p>
                </div>

            </section>
        </div>
        <div class="row">
            <p><a href="/QuienesSomos" class="btn btn-primary btn-md">Sobre Nosotros &raquo;</a></p>

        </div>
    </main>

</asp:Content>
