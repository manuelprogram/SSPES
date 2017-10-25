<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarProyecto.aspx.cs" Inherits="SSPES.Views.Proyectos.AdministrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function Confirm() {
            $('#myModal').modal('show');
            return true;
        };

        function CrearVariableModal() {
            $('#crearVariableModal').modal('show');
            return true;
        };
    </script>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm info">
            <div class="modal-content info">
                <div class="modal-header info">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Mensaje</h4>
                </div>
                <div class="modal-body">
                    <p><%=msj %></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="crearVariableModal" role="dialog">
        <div class="modal-dialog modal-sm info">
            <div class="modal-content info">
                <div class="modal-header info">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Crear variable</h4>
                </div>
                <div class="modal-body">

                    <label runat="server" id="Label1">Nombre de nueva variable *</label>
                    <input type="text" id="nombreVariable" name="pr" runat="server" class="form-control" placeholder="Nombre variable" />
                    <br />
                    <label>Descripcion de la variable *</label>
                    <input type="text" id="descripcionNuevaVariable" class="form-control" runat="server" placeholder="Descripcion de la variable" />
                    <br />
                    <label>Tipo de dato:</label>
                    <select class="form-control" runat="server" id="tDato">
                        <option>Numero entero</option>
                        <option>Numero decimal</option>
                        <option>Texto</option>
                    </select>
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="CrearVariable2" align="center" Class="btn btn-primary btn-block" Text="Registrar" runat="server" OnClick="CrearVariable_Click" />
                </div>
            </div>
        </div>
    </div>

    <style>
    .chkBoxList tr{
       height:30px;
    }

    .chkBoxList td{
       width:200px; /* or percent value: 25% */
    }
    </style>

    <div class="row">
        <div class="col-md-12">
            <br />
            <div class="tab-content">
                <div class="tab-pane active">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <h1 class="page-header" align="center">Administrar Proyectos</h1>
                                <div class="row">
                                    <div class="col-md-10"></div>
                                    <asp:Button ID="visualizar" runat="server" OnClick="visualizar_Click"
                                        CssClass="btn btn-primary" Text="Visualizar proyectos" />
                                    <br />
                                </div>

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <ul class="nav nav-tabs">
                                                <li class="active"><a href="#CrearProyecto" data-toggle="tab">Crear proyecto</a> </li>
                                                <li><a href="#Seleccionar" data-toggle="tab">Seleccionar</a> </li>
                                                <li><a href="#AsignarVariables" data-toggle="tab">Asignar variables</a> </li>
                                                <li><a href="#AsignarIntegrantes" data-toggle="tab">Asignar integrantes</a> </li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div class="tab-content">

                                        <div class="tab-pane fade in active" id="CrearProyecto">
                                            <div class="row">
                                                <div class="col-md-12 control-label">
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">

                                                            <div class="row">
                                                                <div class="col-md-6 control-label">
                                                                    <div class="form-group">
                                                                        <br />
                                                                        <label id="mensaje" runat="server">Nombre Proyecto*</label>
                                                                        <input type="text" id="nombreProyectoNuevo" name="pr" runat="server" class="form-control" placeholder="Nombre Proyecto" />
                                                                        <br />
                                                                        <label>Descripción</label>
                                                                        <textarea class="form-control" rows="5" id="descripcionProyecto" runat="server"></textarea>
                                                                        <br />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="col-md-6 control-label">
                                                                        <div class="row">
                                                                            <div class="col-md-5 control-label">
                                                                                <br />
                                                                                <label>fecha Inicio*</label>
                                                                                <br />
                                                                                <input type="date" runat="server" id="fechaInicio" />
                                                                            </div>
                                                                            <div class="col-md-5 control-label">
                                                                                <br />
                                                                                <label>fecha Fin*</label>
                                                                                <br />
                                                                                <input type="date" runat="server" id="fechaFin" />
                                                                            </div>
                                                                        </div>

                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                        <label>Archivo</label>
                                                                        <asp:FileUpload ID="archivo" size="20" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <br />
                                                                    <asp:Button ID="registrarProyecto" class="btn btn-primary btn-block" Text="Registrar Proyecto" runat="server" OnClick="registrarProyecto_Click" />
                                                                    <br />
                                                                    <br />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="tab-pane fade" id="Seleccionar">
                                            <div class="row">
                                                <div class="col-md-12 control-label">
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">

                                                            <div class="row">
                                                                <div class="col-md-7 control-label">
                                                                    <br />
                                                                    <h4>Seleccione el proyecto.</h4>
                                                                    <asp:ListBox ID="proyecto" runat="server" CssClass="form-control"
                                                                        OnSelectedIndexChanged="Button_Click" AutoPostBack="true"
                                                                        Height="150" Width="400"></asp:ListBox>
                                                                </div>

                                                            </div>

                                                            <br />
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-5 control-label">
                                                                    <h4 id="nombrePro" runat="server">Proyecto selecionado:</h4>
                                                                    <asp:TextBox ID="nombreProyecto" runat="server" ReadOnly="true" Height="30" Width="300"
                                                                        BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-6 control-label">
                                                                    <h4 id="descripcion" runat="server">Descripcion Proyecto.</h4>
                                                                    <asp:TextBox ID="texto" runat="server" ReadOnly="true" Height="100" Width="400"
                                                                        BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <br />
                                                            <br />

                                                        </div>
                                                    </div>
                                                </div>
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
                                                                    CssClass="chkBoxList" RepeatColumns="5" RepeatLayout="Table" RepeatDirection="Horizontal"
                                                                    runat="server">
                                                                </asp:CheckBoxList>
                                                                <br />
                                                                <br />

                                                                <div class="row">
                                                                    <div class="col-md-3 control-label">
                                                                        <asp:Button CssClass="btn btn-primary col-lg-9" ID="asignarVariable" runat="server"
                                                                            Text="Asignar variables" OnClick="asignarVariable_Click" />
                                                                    </div>
                                                                    <div class="col-md-3 control-label">
                                                                        <asp:Button CssClass="btn btn-primary col-lg-9" ID="crearVariable" runat="server"
                                                                            Text="Crear variable" OnClick="llamarModalVariable_Click" />
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                </div>
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
                                                                CssClass="chkBoxList" RepeatColumns="5" RepeatLayout="Table" RepeatDirection="Horizontal"
                                                                runat="server">
                                                            </asp:CheckBoxList>
                                                            <br />

                                                            <div class="col-lg-4">
                                                                <h4>Seleccione el rol a asignar.</h4>
                                                                <br />
                                                                <asp:DropDownList ID="rolProyectos" runat="server" CssClass="btn-default" Width="150"></asp:DropDownList>
                                                                <br />
                                                                <br />
                                                                <asp:Button CssClass="btn btn-primary col-lg-6" ID="boton" runat="server" OnClick="boton_Click" Text="Asignar usuarios" />
                                                                <br />
                                                                <br />
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
