<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarIntegrantesProyectos.aspx.cs" Inherits="SSPES.Views.IntegrantesProyectos.RegistrarIntegranteProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Registrar integrante proyecto</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="page-header" align="center">Registrar integrantes</h2>
    <br />

    <div class="col-lg-4">
        <h4>Seleccione el proyecto:</h4>
        <asp:ListBox ID="proyectos" runat="server" Width="300" Height="200"
            OnSelectedIndexChanged="proyectos_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
        <br />

        <br />
        <h4 id="descripcion" runat="server">Descripcion Proyecto.</h4>
        <asp:TextBox ID="texto" runat="server" ReadOnly="true" Height="100" Width="300"
            BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1">
                    Texto.
        </asp:TextBox>
    </div>

    <div class="col-lg-4">
        <h4>¿Que usuario desea agregar?</h4>
        <asp:ListBox ID="user" runat="server" Width="300" Height="200"
            OnSelectedIndexChanged="user_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    </div>

    <div class="col-lg-4">
        <h4>Seleccione el rol a asignar.</h4>
        <asp:ListBox ID="rolProyecto" runat="server" Width="300" Height="200"></asp:ListBox>
        <br />
        <br />
        <asp:Button CssClass="btn btn-primary col-lg-5" ID="boton" runat="server" OnClick="boton_Click" Text="Registrar usuario" />
    </div>

</asp:Content>
