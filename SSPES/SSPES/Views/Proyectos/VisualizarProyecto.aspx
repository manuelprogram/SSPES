<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VisualizarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.VisualizarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header" align="center">Visualizar Proyectos</h1>
        <br />

        <asp:Repeater ID="rep" runat="server">
            <ItemTemplate>

                <div class="col-lg-4">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <%# Eval("NOMBRE") %>
                        </div>
                        <div class="panel-body">
                            <p><%# Eval("DESCRIPCION") %></p>
                        </div>
                        <div class="panel-footer">
                            <%# "Fecha de inicio " + Eval("FECHA_INICIO").ToString().Substring(0, 10) + ", " %>
                        <asp:LinkButton ID="linkboton"
                            runat="server"
                            CommandArgument='<%# Eval("PK_PROYECTO") %>'
                            OnCommand="descargar">
                            Documento</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
