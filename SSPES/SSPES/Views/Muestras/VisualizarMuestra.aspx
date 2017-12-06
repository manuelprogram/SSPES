<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VisualizarMuestra.aspx.cs" Inherits="SSPES.Views.Muestras.VisualizarMuestra" %>

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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Visualizar Muestras</h1>
                                </div>
                            </div>
                            <%--<fin del encabezado>--%>

                            <div class="panel-body">

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

                                                        <asp:Button ID="botonReporte" runat="server" Text="Generar reporte de Muestras" class="btn btn-primary" OnClick="botonReporte_Click" />
                                                        <br />
                                                        <br />
                                                        <br />
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
                                                        <br />
                                                        <br />



                                                        <table id="tablaMuestras" class="table table-bordered table-hover" runat="server">
                                                            <thead>
                                                                <tr>
                                                                    <th>N°</th>
                                                                    <th>Nombre Variable</th>
                                                                    <th>Valor</th>
                                                                    <th>Descripcion</th>
                                                                </tr>
                                                            </thead>
                                                        </table>

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
