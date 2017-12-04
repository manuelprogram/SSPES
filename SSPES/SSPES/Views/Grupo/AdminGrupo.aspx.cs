using System;
using System.Data;
using SSPES.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Grupo {
    public partial class AdminGrupo : System.Web.UI.Page {
        private DataRow dr;
        private DataTable dt;
        GrupoController grupos = new GrupoController();
        protected void Page_Load(object sender, EventArgs e) {
            dt = grupos.ConsultarGrupo();
            dr = dt.Rows[0];
            sigla.Value = dr["SIGLAS"].ToString();
            descripcion.Value = dr["DESCRIPCION"].ToString();
            institucion.Value = dr["institucion"].ToString();
        }
    }
}