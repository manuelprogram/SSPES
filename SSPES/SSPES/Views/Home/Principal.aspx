<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SSPES.Views.Home.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Principal</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-md-6">
                <h1 class="page-header">Bienvenido a SSPES
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-folder-open fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"><%= numeroPro %></div>
                                <div>PROYECTOS</div>
                            </div>
                        </div>
                    </div>
                    <a href="../Proyectos/VisualizarProyecto.aspx">
                        <div class="panel-footer">
                            <span class="pull-left">Visualizar</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-green">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-street-view fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"><%=numeroUser.ToString()%></div>
                                <div>USUARIOS</div>
                            </div>
                        </div>
                    </div>
                    <a href="../Usuarios/ConsultarUsuarios.aspx">
                        <div class="panel-footer">
                            <span class="pull-left">Visualizar</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-folder-o fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"><%=numeroTer%></div>
                                <div>FINALIZADOS</div>
                            </div>
                        </div>
                    </div>
                    <a href="../Proyectos/VisualizarProyecto.aspx">
                        <div class="panel-footer">
                            <span class="pull-left">Visualizar</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
