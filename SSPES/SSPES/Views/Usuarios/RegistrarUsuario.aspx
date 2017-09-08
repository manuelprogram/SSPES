<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SSPES.Views.Usuarios.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>Registrar usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-md-6">
      <h1 class="page-header">Registrar usuario</h1>
      <div class="form-group">
        <label>Primer Nombre *</label>
        <input type="text"  class="form-control" placeholder="Primer Nombre" />
        <br />
        <label>Segundo Nombre</label>
        <input type="text" class="form-control" placeholder="Segundo Nombre" />
        <br />
        <label>Primer Apellido *</label>
        <input type="text" class="form-control" placeholder="Primer Apellido" />
        <br />
        <label>Segundo Apellido</label>
        <input type="text" class="form-control" placeholder="Segundo Apellido" />
        <br />
        <label>Tipo de documento</label>
        <select class="form-control">
          <option>Tarjeta de Identidad</option>
          <option>Cedula de ciudadania</option>
          <option>Cedula de extranjería</option>
        </select>
        <br />
        <label>Numero de Documento</label>
        <input type="text" class="form-control" placeholder="0000000000" />
        <br />
        <label>Telefono</label>
        <input type="tel" class="form-control" placeholder="000000000" />
        <br />
        <label>Profesión</label>
        <input type="text" class="form-control" placeholder="Profesión" />
        <br />
        <label>Correo Electronico *</label>
        <input type="email" class="form-control" placeholder="Example@www.com" />
        <br />
        <label>Usuario *</label>
        <input type="text" class="form-control" placeholder="Usuario" />
        <br />
        <label>Contraseña *</label>
        <input type="password" class="form-control" placeholder="Contraseña" />
        <br />
        <input type="submit" class="btn btn-primary btn-block" name="BRegistrar" id="boton" value="Registrar" class="form-control"/>
      </div>
    </div>
  </div>
</asp:Content>
