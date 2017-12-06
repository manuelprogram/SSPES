using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Home {
    public partial class Principal : System.Web.UI.Page {
        CuentaController cuenta = new CuentaController();
        ProyectoController proyecto = new ProyectoController();
        public string numeroUser;
        public string numeroPro;
        public string numeroTer;


        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            Session["datos_dtVariables"] = null;
            Session["datos_dtProyecto"] = null;
            Session["dtProyectos"] = null;
            Session["dtIntegrantes"] = null;
            Session["dtRoles"] = null;
            numeroUser = cuenta.CantidadCuenta();
            numeroPro = proyecto.CantidadProyecto(Session["PK_CUENTA"].ToString());
            numeroTer = proyecto.getNumeroProyectoFinal(Session["PK_CUENTA"].ToString());
        }
    }
}
