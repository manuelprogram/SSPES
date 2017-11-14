<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarMuestra.aspx.cs" Inherits="SSPES.Views.Muestras.ModificarMuestra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function panelAsignarVariables() {
            $('#hrefAsignar').trigger('click');
            return true;
        };
    </script>
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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Modificar Muestras</h1>
                                </div>
                            </div>
                            <%--<fin del encabezado>--%>

                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#Seleccionar" data-toggle="tab">Seleccionar</a> </li>
                                            <li><a id="hrefAsignar" href="#AsignarVariables" data-toggle="tab">Modificar muestras</a> </li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="tab-content">

                                    <div class="tab-pane fade in active" id="Seleccionar">
                                        <div class="row">
                                            <div class="col-md-12 control-label">
                                                <div class="panel panel-default">
                                                    <div class="panel-body">

                                                        <div class="row">
                                                            <div class="col-md-6 control-label">
                                                                <br />
                                                                <h4>Seleccione el proyecto.</h4>
                                                                <asp:ListBox ID="proyecto" runat="server" CssClass="form-control"
                                                                    OnSelectedIndexChanged="Button_Click" AutoPostBack="true"
                                                                    Height="190" Width="400"></asp:ListBox>
                                                            </div>
                                                            <br />

                                                            <div class="col-md-6 control-label">
                                                                <h4 id="nombrePro" runat="server">Proyecto selecionado:</h4>
                                                                <asp:TextBox ID="nombreProyecto" runat="server" ReadOnly="true" Height="30" Width="300"
                                                                    BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1"></asp:TextBox>
                                                                <br />
                                                                <br />
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

                                        <div class="row">
                                            <div class="col-md-12 control-label">
                                                <div class="panel panel-default">
                                                    <div class="panel-body">
                                                        <h4>Muestras</h4>
                                                        <h5 id="cantidad" runat="server"></h5>

                                                        <div class="row">
                                                            <div class="col-md-6 control-label">
                                                                <h4 id="H1" runat="server">Seleccione la muestra</h4>
                                                                <asp:ListBox ID="ListaMuestras" runat="server" CssClass="form-control"
                                                                    OnSelectedIndexChanged="ListaMuestras_SelectedIndexChanged" AutoPostBack="true"
                                                                    Height="190" Width="400"></asp:ListBox>
                                                            </div>
                                                            <div class="col-md-6 control-label">
                                                                <h4 id="H2" runat="server">Muestra seleccionada:</h4>
                                                                <asp:TextBox ID="muestraSeleccionada" runat="server" ReadOnly="true" Height="30" Width="300"
                                                                    BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1"></asp:TextBox>
                                                                <br />
                                                                <br />
                                                                <h4 id="H3" runat="server">Observaciones de la muestra.</h4>
                                                                <asp:TextBox ID="descripcionMuestra" runat="server" ReadOnly="true" Height="100" Width="400"
                                                                    BorderColor="#D3D3D3" BorderStyle="Solid" BorderWidth="1"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />

                                                        <h4>Variables</h4>
                                                        <div class="row">
                                                            <asp:Repeater ID="rep" runat="server">
                                                                <ItemTemplate>
                                                                    <div class="col-md-4">
                                                                        <label>Nombre: <%# Eval("NOMBRE_VARIABLE")%></label>
                                                                        <h5>Tipo: <%# Eval("TIPO_DE_DATO")%></h5>
                                                                        <asp:TextBox ID="text" runat="server" Text='<%# Eval("VALOR_VARIABLE")%>' Width="250"></asp:TextBox>
                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                        <br />
                                                        <br />

                                                        <div class="col-md-4">
                                                            <asp:Button ID="ActualizarMuestra" runat="server" OnClick="ActualizarMuestra_Click" Class="btn btn-primary btn-block" Text="Actualizar muestra" />
                                                        </div>
                                                        <br />
                                                        <br />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
