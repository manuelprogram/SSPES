<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.ModificarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header" align="center">Modificar Proyecto</h1>
        <div class="col-md-6 control-label">
            <div class="form-group">
                <br />
                <label>Nombre Proyecto*</label>
                <input type="text" id="nombreProyecto" name="pr" runat="server" class="form-control" placeholder="Nombre Proyecto" />
                <br />
                <label>Descripción</label>
                <textarea class="form-control" rows="5" id="descripcionProyecto" runat="server"></textarea>
                <br />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 control-label">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <label>Archivo</label>
                <input name="archivo" type="file" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <br />
            <asp:Button ID="Button1" Class="btn btn-primary btn-block" Text="Modificar Proyecto" runat="server" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
