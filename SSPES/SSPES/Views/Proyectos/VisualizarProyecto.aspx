<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VisualizarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.VisualizarProyecto" %>

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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Visualizar Proyectos</h1>
                                </div>
                            </div>
                            <br />

                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-4">
                                        <div class='<%#  ProcessMyDataItem((string)Eval("ESTADO"))%>'>
                                            <div class="panel-heading">
                                                <%# Eval("NOMBRE") %>
                                            </div>
                                            <div class="panel-body">
                                                <p><%# Eval("DESCRIPCION") %></p>
                                            </div>
                                            <div class="panel-footer">
                                                <%# "Fecha de Inicio : " + Eval("FECHA_INICIO").ToString().Substring(0, 10) %>
                                                <br />
                                                <%# "Fecha de Fin &nbsp;&nbsp;: " + Eval("FECHA_FIN").ToString().Substring(0, 10)+ "&nbsp;--> "%>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
