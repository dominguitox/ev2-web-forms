<%@ Page Title="Quiénes Somos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuienesSomos.aspx.cs" Inherits="ev2_web_forms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2><span id="title">Congelandia: </span>Productos congelados en Talca</h2>
        <div class="row">
            <div class="col-md-6">
                <p>
                    En Congelandia nos especializamos en ofrecer productos congelados de alta calidad. Nuestro objetivo es llevar soluciones prácticas y deliciosas a tu mesa, manteniendo la cadena de frío en todo momento para garantizar la frescura, los nutrientes y el sabor de cada alimento.
                </p>
                <p>
                    Contamos con una amplia variedad de productos seleccionados para facilitar tu día a día, ya sea para el hogar o para tu negocio. Nos enfocamos en brindar un servicio rápido, seguro y confiable, asegurando que siempre encuentres lo que necesitas en óptimas condiciones.
                </p>
                <p>
                    Nuestro compromiso es ser tu mejor alternativa en alimentos congelados, combinando calidad, conveniencia y buena atención.
                </p>

            </div>


        </div>


    </main>
    <script>
        $('.carousel').carousel()
    </script>
</asp:Content>
