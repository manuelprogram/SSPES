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
                                <div class="col-md-3 control-label">
                                    <div class="form-group">
                                        <br />
                                        <label id="labelnombre" class="text-center" runat="server">SIGLGAS</label>
                                        <input type="text" id="sigla" name="pr" runat="server" class="form-control" placeholder="Primer Nombre" />
                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-6 control-label">
                                    <div class="form-group">
                                        <br />
                                        <label id="label1" class="text-center" runat="server">DESCRIPCION</label>
                                        <textarea id="descripcion" class="form-control" cols="30" rows="15" runat="server"></textarea>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-3 control-label">
                                    <div class="form-group">
                                        <br />
                                        <label id="label2" class="text-center" runat="server">INSTITUCION</label>
                                        <input type="text" id="institucion" name="institucion" runat="server" class="form-control" />
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
</asp:Content>
