<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdminGrupo.aspx.cs" Inherits="SSPES.Views.Grupo.AdminGrupo" %>

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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Administrar Grupo</h1>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                               
                                <div class="col-lg-6">
                                    <br />
                                    <div class="col-lg-2"></div>
                                    <img src="../../Imagenes/configuracion.png" class="img-responsive" width="350"/>
                                </div>
                                <div class="col-lg-6">

                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4 control-label">
                                            <div class="form-group">
                                                <br />
                                                <label id="labelnombre" class="text-center" runat="server">SIGLAS</label>
                                                <input type="text" id="sigla" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 control-label">
                                            <div class="form-group">
                                                <label id="label3" class="text-center" runat="server">NOMBRE</label>
                                                <input type="text" id="nombre" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                                            </div>
                                        </div>
                                        <div class="col-md-6 control-label">
                                            <div class="form-group">
                                                <label id="label2" class="text-center" runat="server">INSTITUCIÓN</label>
                                                <input type="text" id="institucion" name="institucion" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 control-label">
                                            <div class="form-group">
                                                <label id="label1" class="text-center" runat="server">DESCRIPCIÓN</label>
                                                <textarea id="descripcion" class="form-control" cols="30" rows="15" runat="server"></textarea>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4">
                                        <br />
                                        <asp:Button ID="Button1" align="center" Class="btn btn-primary btn-block" Text="Actulizar" OnClick="Button1_Click" runat="server" />
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
        </div>
    </div>
</asp:Content>
