using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using SSPES.Controllers;
using SSPES.Views.Reportes;

namespace SSPES.Reportes {
    public partial class Reporte : System.Web.UI.Page {

        ProyectoController prco = new ProyectoController();
        VariableController vc = new VariableController();
        PersonaController pc = new PersonaController();
        MuestraController mc = new MuestraController();

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!IsPostBack) {
                string tipo = Request.Params["tipo"].ToString();
                this.generarReporte(tipo);
            }
        }
        
        public void generarReporte(string tipo) {
            switch (tipo) {
                case "1":
                    DataTable proyectos = prco.EstadoProyectos(Session["PK_CUENTA"].ToString());
                    ReporteProyectos reporte = new ReporteProyectos();
                    reporte.SetDataSource(proyectos);
                    CrystalReportViewer1.ReportSource = reporte;
                    CrystalReportViewer1.DataBind();
                    break;
                case "3":
                    DataTable personas = pc.ConsultarPersonas();
                    ReportePersonas reporte3 = new ReportePersonas();
                    reporte3.SetDataSource(personas);
                    CrystalReportViewer1.ReportSource = reporte3;
                    CrystalReportViewer1.DataBind();
                    break;
                case "5":
                    DataTable muestras = mc.ReporteMuestrasProyecto(Request.Params["idpro"].ToString());
                    ReporteMuestras prueba = new ReporteMuestras();
                    prueba.SetDataSource(muestras);
                    CrystalReportViewer1.ReportSource = prueba;
                    CrystalReportViewer1.DataBind();
                    break;
            }
        }
        
    }
}
