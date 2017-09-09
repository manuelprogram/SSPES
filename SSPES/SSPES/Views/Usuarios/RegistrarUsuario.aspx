<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SSPES.Views.Usuarios.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Registrar usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1 class="page-header">Registrar usuario</h1>
            <div class="form-group">
                <label id="q" runat="server">Primer Nombre *</label>
                <input type="text" id="nombre1" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                <br />
                <label>Segundo Nombre</label>
                <input type="text" id="nombre2" class="form-control" runat="server" placeholder="Segundo Nombre" />
                <br />
                <label>Primer Apellido *</label>
                <input type="text" id="apellido1" class="form-control" runat="server" placeholder="Primer Apellido" />
                <br />
                <label>Segundo Apellido</label>
                <input type="text" id="apellido2" class="form-control" runat="server" placeholder="Segundo Apellido" />
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
                <label>Profesión</label>
                <select class="form-control" id="profesion" runat="server">
                    <option>Ingeniería Agroecologica</option>
                    <option>Bilogía</option>
                    <option>Química</option>
                </select>
                <br />
                <label>Correo Electronico *</label>
                <input type="email" id="correo" class="form-control" runat="server" placeholder="Example@www.com" />
                <br />
                <label>Usuario *</label>
                <input type="text" id="Usuario" class="form-control" runat="server" placeholder="Usuario" />
                <br />
                <label>Contraseña *</label>
                <input type="password" id="password" class="form-control" runat="server" placeholder="Contraseña" />
                <br />
                <label>Verifique su Contraseña *</label>
                <input type="password" id="rpassword" class="form-control" runat="server" placeholder="Verifique Contraseña" />
                <br />
                <asp:Button ID="Button1" Text="Registrar" OnClick="Registrar" runat="server" />
                <%--<input type="submit" class="btn btn-primary btn-block" runat="server"  name="BRegistrar" id="boton" value="Registrar" />--%>
                <label id="resultado" runat="server">...</label>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
