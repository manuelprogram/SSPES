<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.RegistrarProyecto" %>

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
                  <h1 class="page-header" style="color: #ffffff;" align="center">Registrar Proyectos</h1>
                </div>
              </div>
              <div class="col-md-6 control-label">
                <div class="form-group">
                  <br />
                  <label id="mensaje" runat="server">Nombre Proyecto*</label>
                  <input type="text" id="nombreProyecto" name="pr" runat="server" class="form-control" placeholder="Nombre Proyecto" />
                  <br />
                  <label>Descripción</label>
                  <textarea class="form-control" rows="5" id="descripcionProyecto" runat="server"></textarea>
                  <br />
                </div>
              </div>
              <div class="form-group">
                <div class="col-md-6 control-label">
                  <div class="row">
                    <div class="col-md-5 control-label">
                      <br />
                      <label>fecha Inicio*</label>
                      <br />
                      <input type="date" runat="server" id="fechaInicio" />
                    </div>
                    <div class="col-md-5 control-label">
                      <br />
                      <label>fecha Fin*</label>
                      <br />
                      <input type="date" runat="server" id="fechaFin" />
                    </div>
                  </div>

                  <br />
                  <br />
                  <br />
                  <label>Archivo</label>
                  <asp:FileUpload ID="archivo" size="20" runat="server" />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
              </div>
              <div class="col-md-4">
                <br />
                <asp:Button ID="Button1" class="btn btn-primary btn-block" Text="Registrar Proyecto" runat="server" OnClick="Button1_Click" />
                <br />
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
