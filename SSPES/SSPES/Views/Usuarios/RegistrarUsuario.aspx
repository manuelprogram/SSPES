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
        <input type="text" id="LPrimerN" class="form-control" placeholder="Primer Nombre" />
        <br />
        <label>Segundo Nombre</label>
        <input type="text" id="LSegundoN" class="form-control" placeholder="Segundo Nombre" />
        <br />
        <label>Primer Apellido *</label>
        <input type="text" id="LPrimerA" class="form-control" placeholder="Primer Apellido" />
        <br />
        <label>Segundo Apellido</label>
        <input type="text" id="LSegundoA" class="form-control" placeholder="Segundo Apellido" />
        <br />
        <label>Tipo de documento</label>
        <select class="form-control">
          <option>Tarjeta de Identidad</option>
          <option>Cedula de ciudadania</option>
          <option>Cedula de extranjería</option>
        </select>
        <br />
        <label>Numero de Documento</label>
        <input type="text" id="TDoc" class="form-control" placeholder="0000000000" />
        <br />
        <label>Telefono</label>
        <input type="tel" id="TeTelef" class="form-control" placeholder="000000000" />
        <br />
        <label>Profesión</label>
        <select class="form-control">
          <option>Ingeniería Agroecologica</option>
          <option>Bilogía</option>
          <option>Química</option>
        </select>
        <br />
        <label>Correo Electronico *</label>
        <input type="email" id="ECorreo" class="form-control" placeholder="Example@www.com" />
        <br />
        <label>Usuario *</label>
        <input type="text" id="TUsuario" class="form-control" placeholder="Usuario" />
        <br />
        <label>Contraseña *</label>
        <input type="password" id="TContrase" class="form-control" placeholder="Contraseña" />
        <br />
        <label>Verifique su Contraseña *</label>
        <input type="password" id="TVContra" class="form-control" placeholder="Verifique Contraseña" />
        <br />
        <input type="submit" class="btn btn-primary btn-block" name="BRegistrar" id="boton" value="Registrar" />
      </div>
    </div>
  </div>
</asp:Content>
