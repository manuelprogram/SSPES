<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarVariables.aspx.cs" Inherits="SSPES.Views.AsignacionVariables.AsignarVariables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="page-header" align="center">Registrar nueva variable</h2>
    <br />

    <div class="row">
        <div class="col-md-5 control-label">
            <asp:ListBox ID="proyecto" runat="server" Width="300" Height="200"
                OnSelectedIndexChanged="Button_Click" AutoPostBack="true"></asp:ListBox>
        </div>

        <div class="col-md-5 control-label">
            <asp:ListBox ID="variable" runat="server" Width="300" Height="200"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="asignarVariable" runat="server" Text="Asignar variable" OnClick="asignarVariable_Click" />
        </div>
    </div>
</asp:Content>
