<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="SSPES.Views.Usuarios.ConsultarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Consultar usuarios</title>
    <link rel="stylesheet" href="../../public/Admin/dist/css/jquery.dataTables.min.css"/>
    <script src=" ../../public/Admin/dist/js/jquery-3.2.1.min.js"></script>
    <script src=".../../public/Admin/dist/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Persona').DataTable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2 class="page-header" align="center">Consultar usuarios</h2>
        </div>
        <div class="row col-lg-11">
            <table id="Persona" class="table table-hover table-bordered table-responsive fa-table">
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
                <tfoot>
                    <tr>
                        <th>N°</th>
                        <th>Identificación</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Celular</th>
                        <th>Correo</th>
                    </tr>
                </tfoot>

                <tbody>
                    <%for (int i = 0; i < dtConsulta.Rows.Count; i++) {
                            drConsulta = dtConsulta.Rows[i];
                    %>
                    <tr class=<%= i % 2 == 0 ? "success" : "warnin"%>>
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
    
</asp:Content>
