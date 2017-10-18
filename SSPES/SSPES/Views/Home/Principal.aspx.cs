using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Home {
    public partial class Principal : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Session["datos_dtVariables"] = null;
            Session["datos_dtProyecto"] = null;
            Session["dtProyectos"] = null;
            Session["dtIntegrantes"] = null;
            Session["dtRoles"] = null;
        }
    }
}