<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarGrupo.aspx.cs" Inherits="SSPES.Views.Grupo.RegistrarGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Registrar Grupo</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header" align="center">Registrar Grupo</h1>
        <div class="col-md-6 control-label">
            <div class="form-group">
                <br />
                <label>Nombre Grupo *</label>
                <input type="text" id="ngrup" name="Ngrupo" runat="server" class="form-control" placeholder="Nombre Grupo" />
                <br />
                <label id="labelnombre" runat="server">Primer Nombre *</label>
                <input type="text" id="GrupoNombre1" name="pr" runat="server" class="form-control" placeholder="Primer Nombre Director" />
                <br />
                <label>Primer Apellido *</label>
                <input type="text" id="GrupoApellido1" class="form-control" runat="server" placeholder="Primer Apellido Director" />
                <br />
                <label>Rol</label>
                <select class="form-control" id="GrupoRol" runat="server">
                </select>
                <br />
                <label>Usuario *</label>
                <input type="text" id="GrupoUsuario" class="form-control" runat="server" placeholder="Usuario" />
                <br />
                <label>Contraseña *</label>
                <input type="password" id="GrupoPassword1" class="form-control" runat="server" placeholder="Contraseña" />
                <br />
                <label>Verifique su Contraseña *</label>
                <input type="password" id="rpassword" class="form-control" runat="server" placeholder="Verifique Contraseña" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 control-label">
                <br />
                <label>Nombre Institución *</label>
                <input type="text" id="GrupoInstitucion" name="NInsti" runat="server" class="form-control" placeholder="Nombre Institución" />
                <br />
                <label>Segundo Nombre</label>
                <input type="text" id="GrupoNombre2" class="form-control" runat="server" placeholder="Segundo Nombre Director" />
                <br />
                <label>Segundo Apellido</label>
                <input type="text" id="GrupoApellido2" class="form-control" runat="server" placeholder="Segundo Apellido Director" />
                <br />
                <label>Correo Electronico *</label>
                <input type="email" id="GrupoCorreo" class="form-control" runat="server" placeholder="Example@www.com" />
                <br />
                <label>Tipo de documento</label>
                <select class="form-control" runat="server" id="tDocumento">
                    <option>Tarjeta de Identidad</option>
                    <option>Cedula de ciudadania</option>
                    <option>Cedula de extranjería</option>
                </select>
                <br />
                <label>Numero de Documento</label>
                <input type="text" id="GrupoDocumento" class="form-control" runat="server" placeholder="0000000000" />
                <br />
                <label>Telefono</label>
                <input type="tel" id="GrupoTelefono" class="form-control" runat="server" placeholder="000000000" />
                <br />
                <label id="GrupoResultado" runat="server">...</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <br />
                <asp:Button ID="GrupoButton" align="center" Class="btn btn-primary btn-block" Text="Registrar" OnClick="Registrar" runat="server" />
                <br />
                <br />
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</asp:Content>
