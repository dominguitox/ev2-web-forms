<%@ Page Title="Login" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Login.aspx.cs" 
    Inherits="ev2_web_forms.Login" %>


<asp:Content ID="Content1" 
    ContentPlaceHolderID="MainContent" 
    runat="server">


    <div class="container mt-4">

        <h2 id="title">Inicio de sesión</h2>

        <hr />


        <div class="form-group">

            <asp:Label 
                ID="lblUsuario" 
                runat="server" 
                Text="Usuario">
            </asp:Label>


            <asp:TextBox 
                ID="txtUsuario" 
                runat="server"
                CssClass="form-control">
            </asp:TextBox>

        </div>


        <br />


        <div class="form-group">

            <asp:Label 
                ID="lblClave" 
                runat="server" 
                Text="Contraseña">
            </asp:Label>


            <asp:TextBox 
                ID="txtClave" 
                runat="server"
                TextMode="Password"
                CssClass="form-control">
            </asp:TextBox>

        </div>


        <br />


        <asp:Button 
            ID="btnIngresar"
            runat="server"
            Text="Ingresar"
            CssClass="btn btn-primary"
            OnClick="btnIngresar_Click" />


        <br />
        <br />


        <asp:Label
            ID="lblMensaje"
            runat="server"
            ForeColor="Red">
        </asp:Label>


    </div>


</asp:Content>