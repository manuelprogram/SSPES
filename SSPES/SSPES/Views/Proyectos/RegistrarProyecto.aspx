<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.RegistrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header" align="center">Registrar Proyecto</h1>
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
                <label>fecha Inicio*</label>
                <br />
                <input type="date" runat="server" id="fechaInicio" />
                <br />
                <br />
                <br />
                <label>Archivo</label>
                <asp:FileUpload id="archivo" size="20" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <br />
            <asp:button id="Button1" class="btn btn-primary btn-block" text="Registrar Proyecto" runat="server" onclick="Button1_Click" />
            <br />
            <br />
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
