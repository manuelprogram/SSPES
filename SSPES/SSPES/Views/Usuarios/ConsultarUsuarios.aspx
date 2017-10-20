<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="SSPES.Views.Usuarios.ConsultarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Consultar usuarios</title>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2 class="page-header" align="center">Consultar usuarios</h2>
        </div>
        <div class="row col-lg-11">
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
                    <tr>
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
