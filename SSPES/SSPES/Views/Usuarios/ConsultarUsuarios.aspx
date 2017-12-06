<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="SSPES.Views.Usuarios.ConsultarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Consultar usuarios</title>
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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Consultar Usuario</h1>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-7"></div>
                                <a href="../Reportes/Reporte.aspx?tipo=3" class="btn btn-success">reporte de usuarios</a>
                                <div class="col-lg-1"></div>
                                <asp:Button ID="Nuevo" CssClass="btn btn-success" EnableViewState="false" runat="server" Text="Registrar Usuario" OnClick="Nuevo_Click" />
                            </div>
                            <br />
                            <div class="row col-lg-12">
                                <table id="dataTables-example" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>N°</th>
                                            <th>Identificación</th>
                                            <th>Nombre</th>
                                            <th>Apellido</th>
                                            <th>Celular</th>
                                            <th>Correo</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%for (int i = 0; i < dtConsulta.Rows.Count; i++) {
                                                drConsulta = dtConsulta.Rows[i];
                                        %>
                                        <tr class='<%= (i % 2 == 0 ? "info" : "warning") %>'>
                                            <td><%= (i+1)%></td>
                                            <td><%=drConsulta["Documento"].ToString().ToUpper() %></td>
                                            <td><%=drConsulta["Nombre"].ToString().ToUpper() %></td>
                                            <td><%=drConsulta["Apellido"].ToString().ToUpper() %></td>
                                            <td><%=drConsulta["Celular"].ToString().ToUpper() %></td>
                                            <td><%=drConsulta["Correo"].ToString().ToUpper() %></td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
