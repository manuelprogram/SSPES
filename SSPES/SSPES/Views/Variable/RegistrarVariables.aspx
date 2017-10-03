<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarVariables.aspx.cs" Inherits="SSPES.Views.Variables.CrearVariable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Crear nueva variable</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h1 class="page-header" align="center">Registrar nueva variable</h1>

        <div class="col-md-6 control-label">

            <br />
            <label runat="server" id ="mensaje">Nombre de nueva variable *</label>
            <input type="text" id="nombreVariable" name="pr" runat="server" class="form-control" placeholder="Nombre variable" />
            <br />
            <label>Descripcion de la variable *</label>
            <input type="text" id="descripcion" class="form-control" runat="server" placeholder="Descripcion de la variable" />
            <br />
        
            <label>Tipo de dato</label>
            <select class="form-control" runat="server" id="tDato">
                <option>Numero entero</option>
                <option>Numero decimal</option>
                <option>Texto</option>
            </select>
            <br />

            <label id ="resultado" runat="server">Resultado</label>
            <br />
        
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:Button ID="BOTON" align="center" Class="btn btn-primary btn-block" Text="Registrar" OnClick="Registrar" runat="server" />
                    <br />
                    <br />
                </div>
                <div class="col-md-4">
                </div>
            </div>

        </div>
    </div>
</asp:Content>
