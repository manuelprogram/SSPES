<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SSPES.Views.Usuarios.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <br />
  <div class="tab-content">
    <div class="tab-pane active">
      <div class="row">
        <div class="col-lg-12">
          <div class="panel panel-default">
            <div class="panel-body">
              <div class="card card-inverse" style="padding: 5px; background-color: #0099CC; border-color: #333;">
                <div class="card-block">
                  <h1 class="page-header" style="color: #ffffff;" align="center">Registrar usuario</h1>
                </div>
              </div>
              <%-- -------------------------------------------------------------------------- --%>
              <div class="form-group">

                <div class="col-md-12 control-label">
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <br />
                      <label id="labelnombre" runat="server">Primer Nombre *</label>
                      <input type="text" id="nombre1" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                      <br />
                    </div>
                  </div>
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <br />
                      <label>Segundo Nombre</label>
                      <input type="text" id="nombre2" class="form-control" runat="server" placeholder="Segundo Nombre" />
                      <br />
                    </div>
                  </div>
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <br />
                      <label>Primer Apellido *</label>
                      <input type="text" id="apellido1" class="form-control" runat="server" placeholder="Primer Apellido" />
                    </div>
                  </div>
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <br />
                      <label>Segundo Apellido</label>
                      <input type="text" id="apellido2" class="form-control" runat="server" placeholder="Segundo Apellido" />
                    </div>
                  </div>
                </div>
                <%-- -------------------------------------------------------------------------- --%>
                <div class="col-md-12 control-label">
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <label>Tipo de documento</label>
                      <select class="form-control" runat="server" id="tDocumento">
                        <option>Tarjeta de Identidad</option>
                        <option>Cedula de ciudadania</option>
                        <option>Cedula de extranjería</option>
                      </select>
                    </div>
                  </div>
                  <div class="col-md-3 control-label">
                    <div class="form-group">
                      <label>Numero de Documento</label>
                      <input type="text" id="nDocumento" class="form-control" runat="server" placeholder="0000000000" />
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-md-6 control-label">
                      <label>Correo Electronico *</label>
                      <input type="email" id="Email1" class="form-control" runat="server" placeholder="Example@www.com" />
                    </div>
                  </div>
                </div>
                <%-- -------------------------------------------------------------------------- --%>
                <div class="form-group">
                  <div class="col-md-12 control-label">

                    <div class="col-md-6 control-label">
                      <div class="form-group">
                        <label>Rol</label>
                        <select class="form-control" id="rol" runat="server">
                        </select>
                      </div>
                    </div>

                    <div class="col-md-6 control-label">
                      <label>Telefono</label>
                      <input type="tel" id="nTelefono" class="form-control" runat="server" placeholder="000000000" />
                    </div>
                  </div>
                </div>
                <%-- -------------------------------------------------------------------------- --%>
                <div class="form-group">
                  <div class="col-md-12 control-label">

                    <div class="col-md-4 control-label">
                      <div class="form-group">
                        <label>Usuario *</label>
                        <input type="text" id="Usuario" class="form-control" runat="server" placeholder="Usuario" />
                      </div>
                    </div>

                    <div class="col-md-4 control-label">
                      <div class="form-group">
                        <label>Contraseña *</label>
                        <input type="password" id="password" class="form-control" runat="server" placeholder="Contraseña" />
                      </div>
                    </div>

                    <div class="col-md-4 control-label">
                      <div class="form-group">
                        <label>Verifique su Contraseña *</label>
                        <input type="password" id="Password1" class="form-control" runat="server" placeholder="Verifique Contraseña" />
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                  <br />
                  <asp:Button ID="Button1" align="center" Class="btn btn-primary btn-block" Text="Registrar" OnClick="Registrar" runat="server" />
                  <br />
                </div>
                <div class="col-md-4">
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
