<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.AdministrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .chkBoxList tr {
            height: 30px;
        }

        .chkBoxList td {
            width: 160px; /* or percent value: 25% */
        }
    </style>

    <div class="row">
        <h1 class="page-header" align="center">Administrar Proyectos</h1>
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
                                                <li class="active"><a href="#Seleccionar" data-toggle="tab">Seleccionar</a> </li>
                                                <li><a href="#AsignarVariables" data-toggle="tab">Asignar variables</a> </li>
                                                <li><a href="#AsignarIntegrantes" data-toggle="tab">Asignar integrantes</a> </li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div class="tab-content">

                                        <div class="tab-pane fade in active" id="Seleccionar">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-5 control-label">
                                                        <br />
                                                        <h4>Seleccione el proyecto.</h4>
                                                        <asp:DropDownList ID="proyectos" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="col-md-5 control-label">
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="seleccionar" runat="server" OnClick="Button_Click"
                                                            CssClass="btn btn-primary col-lg-5" Text="Seleccionar" />
                                                    </div>
                                                </div>
                                                <br />
                                                <label id="nombrePro" runat="server">Proyecto selecionado:</label>

                                                <br />
                                                <br />


                                                <%--<h4 id="descripcion" runat="server">Descripcion Proyecto.</h4>
                                                                    <asp:TextBox ID="texto" runat="server" ReadOnly="true" Height="100" Width="300"
                                                                        BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1">
                                                                        Texto.
                                                                    </asp:TextBox>--%>
                                            </div>
                                        </div>



                                        <div class="tab-pane fade" id="AsignarVariables">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-12 control-label">
                                                        <div class="panel panel-default">
                                                            <div class="panel-body">
                                                                <h4>Asignacion de variables</h4>
                                                                <br />
                                                                <asp:CheckBoxList ID="radio"
                                                                    CssClass="chkBoxList" RepeatColumns="6" RepeatLayout="Table" RepeatDirection="Horizontal"
                                                                    runat="server">
                                                                </asp:CheckBoxList>
                                                                <br />
                                                                <asp:Button CssClass="btn btn-primary col-lg-2" ID="asignarVariable" runat="server" Text="Asignar variable" OnClick="asignarVariable_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="tab-pane fade" id="AsignarIntegrantes">
                                            <div class="row">
                                                <div class="col-md-12 control-label">
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">

                                                            <h4>Asignacion de integrantes</h4>
                                                            <br />

                                                            <h4>¿Que usuarios desea agregar?</h4>
                                                            <br />

                                                            <asp:CheckBoxList ID="users"
                                                                CssClass="chkBoxList" RepeatColumns="6" RepeatLayout="Table" RepeatDirection="Horizontal"
                                                                runat="server">
                                                            </asp:CheckBoxList>
                                                            <br />

                                                            <div class="col-lg-4">
                                                                <h4>Seleccione el rol a asignar.</h4>
                                                                <br />
                                                                <asp:DropDownList ID="rolProyectos" runat="server" CssClass="btn-default" Width="150"></asp:DropDownList>
                                                                <br />
                                                                <br />
                                                                <asp:Button CssClass="btn btn-primary col-lg-6" ID="boton" runat="server" OnClick="boton_Click" Text="Registrar usuario" />
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
        </div>
    </div>
</asp:Content>
