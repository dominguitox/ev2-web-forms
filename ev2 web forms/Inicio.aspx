<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ev2_web_forms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <div class="row mb-4">

            <!-- SECCIÓN HERO: -->
            <section class="row mb-5">
                <div class="col-12 position-relative p-0">
                    <div class="col-12">
                        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">

                                <div class="carousel-item active">
                                    <img class="d-block w-100" src="./congelandia1.jpg" alt="First slide" style="max-height: 500px; object-fit: cover; filter: brightness(0.6);">
                                </div>
                                <div class="carousel-item">
                                    <img class="d-block w-100" src="./congelandia2.jpg" alt="Second slide" style="max-height: 500px; object-fit: cover; filter: brightness(0.6);">
                                </div>
                                <div class="carousel-item">
                                    <img class="d-block w-100" src="./congelandia3.jpg" alt="Third slide" style="max-height: 500px; object-fit: cover; filter: brightness(0.6);">
                                </div>
                            </div>
                            <a class="carousel-control-prev" data-bs-target="#carouselExampleControls" role="button" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" data-bs-target="#carouselExampleControls" role="button" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                    <div class="position-absolute top-50 start-50 translate-middle text-center w-75 text-white" style="z-index: 10;">
                        <h1 id="aspnetTitle" class="display-3 fw-bold" style="color: white; text-shadow: 1px 1px 0.5px black;">CONGELANDIA</h1>
                        <p class="lead fw-normal" style="text-shadow: 1px 1px 4px rgba(0,0,0,0.8); margin: 0 20px 10px 20px;">
                            Congelandia es una comercial de productos congelados, con presencia y despacho en Talca. Líderes en el área y casi 67 años de experiencia
                        </p>

                        <div class="row" style="justify-content: center;">
                            <div class="col-3">
                                <p><a href="/QuienesSomos" class="btn btn-primary btn-md" style="width: 100%;">Sobre Nosotros &raquo;</a></p>
                            </div>
                            <div class="col-3">
                                <p><a href="#catalogo" class="btn btn-primary btn-md" style="width: 100%;">Catálogo de productos &raquo;</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <!-- SECCION 1 -->
            <div class="row mb-6 mt-5">
                <div class="col-12 text-center mb-5">
                    <h2 class="fw-bold">Sobre Congelandia</h2>
                    <hr style="width: 50px; margin: 0 auto; border-top: 3px solid #007bff;">
                </div>

                <div class="col-md-4 mb-4">
                    <section aria-labelledby="porqueCongelandia">
                        <div class="card mb-3 p-3">
                            <h2 id="librariesTitle">¿Por qúé Congelandia?</h2>
                            <p>
                                A diferencia de la competición, nuestros productos congelados duran un 67% más de tiempo congelados. Somos los reyes de los productos congelandos
      
                            </p>
                            <p>
                                <a class="btn btn-default" href="/Contacto.aspx">Contacto &raquo;</a>
                            </p>
                        </div>
                    </section>

                </div>

                <div class="col-md-4 mb-4">

                    <section aria-labelledby="compraEnNuestroLocal">
                        <div class="card mb-3 p-3">
                            <h2 id="compraEnNuestroLocalTitle">Compra en nuestro local físico</h2>
                            <p>
                                Nuestra casa central se ubica en pleno centro de Talca. Puedes venir y ver nuestro catálogo en persona.
      
                            </p>
                        </div>
                    </section>
                </div>

                <div class="col-md-4 mb-4">

                    <section aria-labelledby="soberaniaProductosCongelados">
                        <div class="card mb-3 p-3">
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
            </div>


            <!-- SECCIÓN 2 catalogo-->
            <div class="row mb-6 mt-5" id="catalogo">
                <div class="col-12 text-center mb-5">
                    <h2 class="fw-bold">Catálogo de Productos</h2>
                    <hr style="width: 50px; margin: 0 auto; border-top: 3px solid #007bff;">
                </div>

                <!-- Producto 1 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./papasprefritas.jpg" class="card-img-top" alt="Papas Prefritas" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Papas Prefritas Corte Fino (1Kg)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$3.500</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>

                <!-- Producto 2 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./empanadas.jpg" class="card-img-top" alt="Empanadas de Queso" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Empanadas de Queso (20 unid)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$4.000</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>

                <!-- Producto 3 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./reineta.jpg" class="card-img-top" alt="Filetes de Reineta" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Filetes de Reineta (1Kg)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$6.500</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>

                <!-- Producto 4 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./choclo.jpg" class="card-img-top" alt="Choclo Desgranado" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Choclo Desgranado (1Kg)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$2.500</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>

                <!-- Producto 5 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./verduras.jpg" class="card-img-top" alt="Mix de Verduras" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Mix de Verduras Campesinas (500g)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$2.200</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>

                <!-- Producto 6 -->
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="./pulpa.jpg" class="card-img-top" alt="Pulpa de Frambuesa" style="height: 200px; object-fit: cover; background-color: #eee;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title">Pulpa de Frambuesa (1Kg)</h4>
                            <h5 class="text-primary fw-bold mt-auto">$3.800</h5>
                            <a href="#" class="btn btn-outline-primary mt-3">Ver Detalle</a>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </main>
</asp:Content>
