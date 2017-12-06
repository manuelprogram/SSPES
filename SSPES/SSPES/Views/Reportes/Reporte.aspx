<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="SSPES.Reportes.Reporte" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                                    <h1 class="page-header" style="color: #ffffff;" align="center">Reportes</h1>
                                </div>
                            </div>

                            <div class="panel-body">
                                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                                    Width="975" Height="1200" BestFitPage="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
