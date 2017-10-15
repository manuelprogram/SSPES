<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarIntegrantesProyectos.aspx.cs" Inherits="SSPES.Views.IntegrantesProyectos.RegistrarIntegranteProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Registrar integrante proyecto</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="col-lg-4">
        <label>Proyecto:</label>
        <br />
        <asp:ListBox ID="proyectos" runat="server" Width="300" Height="200"
            OnSelectedIndexChanged="proyectos_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
        <br />

        <br />
        <label id="descripcion" runat="server">Descripcion Proyecto.</label>
        <br />
        <asp:TextBox ID="texto" runat="server" ReadOnly="true" Height="100" Width="300"
            BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1">
                    Texto.
        </asp:TextBox>
    </div>

    <div class="col-lg-4">
        <label>¿Que usuario desea agregar?</label>
        <br />
        <asp:ListBox ID="user" runat="server" Width="300" Height="200"
            OnSelectedIndexChanged="user_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    </div>

    <div class="col-lg-4">
        <label>Aca irian los checkbox</label>
        <br />
        <asp:ListBox ID="rolProyecto" runat="server" Width="300" Height="200"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="boton" runat="server" OnClick="boton_Click" Text="Registrar usuario" />
    </div>

</asp:Content>
