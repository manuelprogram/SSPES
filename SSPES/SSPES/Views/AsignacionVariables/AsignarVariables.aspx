<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarVariables.aspx.cs" Inherits="SSPES.Views.AsignacionVariables.AsignarVariables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2 class="page-header" align="center">Registrar nueva variable</h2>

        <div class="row">
            <div class="col-md-5 control-label">
                <select class="form-control" runat="server" id="proyectos" onchange="cambioProyecto">
                </select>
            </div>

            <div class="col-md-5 control-label">
                <label id="nombre_pro" runat="server">Proyecto seleccionado</label>
            </div>
            <br />
        </div>

        <div class="row">
            <div class="col-md-5 control-label">
                <br />
                <asp:Button ID="Button" runat="server" Text="Proyecto seleccionado:" OnClick="Button_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-5 control-label">
                <br />
                <br />
                <select class="form-control" runat="server" id="variables">
                    <option>Texto</option>
                </select>
                <br />
                <asp:Button ID="asignarVariable" runat="server" Text="Asignar variable" OnClick="asignarVariable_Click" />
            </div>
        </div>

    </div>
</asp:Content>
