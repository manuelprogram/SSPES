<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Cuentas.aspx.cs" Inherits="SSPES.Views.Cuenta.Cuentas" %>

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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Mis Datos</h1>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a id="datos" href="#misdatos" data-toggle="tab">Mis Datos</a> </li>
                                            <li><a id="grupo" href="#migrupo" data-toggle="tab">Mi Grupo</a> </li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="misdatos">
                                        <div class="row">
                                            <div class="col-md-12 control-label">
                                                <div class="panel panel-default">
                                                    <div class="panel-body">

                                                        <div class="col-md-4 text-center">
                                                            <div class="thumbnail">
                                                                <img src="../../Imagenes/user.jpg" class="img-rounded img-responsive" alt="Lights" style="width: 100%" />
                                                                <label id="nombre"><%= name %></label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-8">
                                                            <div class="col-lg-12">
                                                                <br />
                                                                <div class="panel panel-default">
                                                                    <div class="panel-body">

                                                                        <div class="row">
                                                                            <div class="col-md-6 control-label">
                                                                                <div class="form-group">
                                                                                    <label>Tipo de documento</label>
                                                                                    <select class="form-control" runat="server" id="udtipodoc">
                                                                                        <option>Tarjeta de Identidad</option>
                                                                                        <option>Cedula de ciudadania</option>
                                                                                        <option>Cedula de extranjería</option>
                                                                                    </select>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 control-label">
                                                                                <div class="form-group">
                                                                                    <label>Numero de Documento</label>
                                                                                    <input type="text" id="udnumero" class="form-control" runat="server" required="" />
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-6 control-label">
                                                                                <div class="form-group">
                                                                                    <label>Numero de Celular</label>
                                                                                    <input type="text" id="udcelular" class="form-control" runat="server" required="" />
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-6 control-label">
                                                                                <div class="form-group">
                                                                                    <label>Correo Electronico</label>
                                                                                    <input type="email" id="udemail" class="form-control" runat="server" required="" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-4"></div>
                                                                            <div class="col-md-4">
                                                                                <br />
                                                                                <asp:Button ID="Button1" align="center" Class="btn btn-primary btn-block" Text="Actualizar" OnClick="Button1_Click" runat="server" />
                                                                                <br />
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

                                    <div class="tab-pane fade" id="migrupo">
                                        <div class="row">
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
