<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarVariables.aspx.cs" Inherits="SSPES.Views.AsignacionVariables.AsignarVariables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2 class="page-header" align="center">Registrar nueva variable</h2>

        <div class="col-md-6 control-label">

            <select class="form-control" runat="server" id="variables">
                <option>Numero entero</option>
                <option>Numero decimal</option>
                <option>Texto</option>
            </select>
            <br />
            <select class="form-control" runat="server" id="proyectos">
                <option>Numero entero</option>
                <option>Numero decimal</option>
                <option>Texto</option>
            </select>

        </div>
    </div>
</asp:Content>
