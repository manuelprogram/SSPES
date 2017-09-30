<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarRol.aspx.cs" Inherits="SSPES.Views.Roles.ModificarRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>holita</title>
    <link rel="shortcut icon" href="Imagenes/SSPES.png" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="MainContent_Contenido">
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_1">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-5"></div>
                                                        <label>Roles</label>
                                                    </div>
                                                    <%--<select name="roles" id="select_roles" class="form-control" multiple="" required="" style="height: 80px;" runat="server"></select>--%>
                                                    <%--<select name="usuario" id="select_roles" class="form-control select2 select2-hidden-accessible" required="" tabindex="-1" aria-hidden="true" runat="server"> </select>--%>
                                                    <select class="form-control" id="select_roles" runat="server"> </select>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                        </div>
                                                        <label>Registrados</label>
                                                    </div>
                                                    <select name="usuario" id="MainContent_t_student" class="form-control select2 select2-hidden-accessible" required="" tabindex="-1" aria-hidden="true"> </select>
                                                    <span class="select2 select2-container select2-container--default" dir="ltr" style="width: 504px;"><span class="selection"><span class="select2-selection select2-selection--single" role="combobox" aria-autocomplete="list" aria-haspopup="true" aria-expanded="false" tabindex="0" aria-labelledby="select2-MainContent_t_student-container"><span class="select2-selection__rendered" id="select2-MainContent_t_student-container" title=""></span><span class="select2-selection__arrow" role="presentation"><b role="presentation"></b></span></span></span><span class="dropdown-wrapper" aria-hidden="true"></span></span>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-5"></div>
                                                        <input type="submit" name="CambiarRol" value="Cambiar rol" id="MainContent_UpdateStudent" class="btn btn-primary" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-5"></div>
                                                        <label>Nuevo rol</label>
                                                    </div>
                                                    <input name="ctl00$MainContent$t_nrol" type="text" id="MainContent_t_nrol" class="form-control" required="" />
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-5"></div>
                                                        <input type="submit" name="ctl00$MainContent$CreateRol" value="Crear rol" id="MainContent_CreateRol" class="btn btn-primary" />
                                                    </div>
                                                </div>
                                            </div>
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
                                                                <h1>hola</h1>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box-footer">
                                        <div class="pull-right">
                                            <input type="submit" name="Actualizar" value="Actualizar" id="Actualizar" class="btn btn-primary" />
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
