<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarVariables.aspx.cs" Inherits="SSPES.Views.AsignacionVariables.AsignarVariables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="page-header" align="center">Registrar nueva variable</h2>
    <br />

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-5 control-label">
                    <h4>Seleccione el proyecto.</h4>
                    <asp:ListBox ID="proyecto" runat="server" Width="300" Height="200"
                        OnSelectedIndexChanged="Button_Click" AutoPostBack="true"></asp:ListBox>
                </div>

                <div class="col-md-5 control-label">
                    <h4>Seleccione la variable.</h4>
                    <asp:ListBox ID="variable" runat="server" Width="300" Height="200"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button CssClass="btn btn-primary col-lg-7" ID="asignarVariable" runat="server" Text="Asignar variable" OnClick="asignarVariable_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
