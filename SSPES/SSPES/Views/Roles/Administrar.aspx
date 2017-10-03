<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="SSPES.Views.Roles.Administrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <br />
            <div class="tab-content">
                <div class="tab-pane active">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <ul class="nav nav-tabs">
                                                <li class="active"><a href="#permisos" data-toggle="tab">Permisos</a> </li>
                                                <li><a href="#asignar" data-toggle="tab">Asignar</a> </li>
                                                <li><a href="#crear" data-toggle="tab">Crear</a> </li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div class="tab-content">
                                        <div class="tab-pane fade in active" id="permisos">
                                            <div class="form-group">
                                                <div class="row">
                                                    <h3 class="col-lg-2">Roles</h3>
                                                </div>
                                                <select name="roles" id="select_roles" class="form-control" multiple="true" style="width: 150px" runat="server"></select>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="box box-primary">
                                                        <div class="box-header">
                                                            <ul class="nav nav-tabs">
                                                                <li class="active">
                                                                    <h3 class="box-title">
                                                                        <span id="MainContent_TituloPermisos">Permisos Asignados</span>
                                                                    </h3>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <div class="box-body">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <br />
                                                                    <br />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane fade" id="asignar">
                                            <div class="form-group">
                                                <div class="row">
                                                    <h3 class="col-lg-2">Registrados</h3>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-8">
                                                        <select name="usuario" id="usuarios" class="form-control"  tabindex="-1" aria-hidden="true"></select>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="Cambiar_Rol" class="btn btn-primary col-lg-7" runat="server" Text="Actualizar" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="tab-pane fade" id="crear">
                                            <div class="form-group">
                                                <div class="row ">
                                                    <div class="col-lg-5"></div>
                                                    <h3 class="col-lg-5">Nuevo rol</h3>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4"></div>
                                                    <div class="col-lg-4">
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="reqRol" ControlToValidate="t_nrol" ErrorMessage="Please enter your name!" />--%>
                                                        <asp:TextBox ID="tx_rol" CssClass="form-control" runat="server" ></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-5"></div>
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="bt_crear_rol" Text="Crear" CssClass="btn btn-primary col-lg-7" OnClick="brt_Click" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>