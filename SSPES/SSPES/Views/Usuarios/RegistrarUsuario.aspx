<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SSPES.Views.Usuarios.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Registrar usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header" align="center">Registrar usuario</h1>
        <div class="col-md-6 control-label">
            <div class="form-group">
                <br />
                <label id="labelnombre" runat="server">Primer Nombre *</label>
                <input type="text" id="nombre1" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                <br />
                <label>Primer Apellido *</label>
                <input type="text" id="apellido1" class="form-control" runat="server" placeholder="Primer Apellido" />
                <br />
                <label>Rol</label>
                <select class="form-control" id="rol" runat="server">
                </select>
                <br />
                <label>Usuario *</label>
                <input type="text" id="Usuario" class="form-control" runat="server" placeholder="Usuario" />
                <br />
                <label>Contraseña *</label>
                <input type="password" id="password" class="form-control" runat="server" placeholder="Contraseña" />
                <br />
                <label>Verifique su Contraseña *</label>
                <input type="password" id="rpassword" class="form-control" runat="server" placeholder="Verifique Contraseña" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 control-label">
                <br />
                <label>Segundo Nombre</label>
                <input type="text" id="nombre2" class="form-control" runat="server" placeholder="Segundo Nombre" />
                <br />
                <label>Segundo Apellido</label>
                <input type="text" id="apellido2" class="form-control" runat="server" placeholder="Segundo Apellido" />
                <br />
                <label>Correo Electronico *</label>
                <input type="email" id="correo" class="form-control" runat="server" placeholder="Example@www.com" />
                <br />
                <label>Tipo de documento</label>
                <select class="form-control" runat="server" id="tDocumento">
                    <option>Tarjeta de Identidad</option>
                    <option>Cedula de ciudadania</option>
                    <option>Cedula de extranjería</option>
                </select>
                <br />
                <label>Numero de Documento</label>
                <input type="text" id="nDocumento" class="form-control" runat="server" placeholder="0000000000" />
                <br />
                <label>Telefono</label>
                <input type="tel" id="nTelefono" class="form-control" runat="server" placeholder="000000000" />
                <br />
                <label id="resultado" runat="server">...</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <br />
                <asp:Button ID="Button1" align="center" Class="btn btn-primary btn-block" Text="Registrar" OnClick="Registrar" runat="server" />
                <br />
                <br />
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</asp:Content>
