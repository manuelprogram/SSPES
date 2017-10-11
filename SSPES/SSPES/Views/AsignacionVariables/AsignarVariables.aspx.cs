using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Data;

namespace SSPES.Views.AsignacionVariables {
    public partial class AsignarVariables : System.Web.UI.Page {

        public DataTable dt1, dt2;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        public void cargarProyectos() {
            variables.Items.Clear();
            proyectos.Items.Clear();

            ProyectoController obj2 = new ProyectoController();
            dt2 = obj2.consultarNombreProyectos();
            for (int i = 0; i < dt2.Rows.Count; i++) {
                proyectos.Items.Add(dt2.Rows[i]["NOMBRE"].ToString());
            }
            Session["datos_dt2"] = dt2;
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            string h = "";
            int index = variables.SelectedIndex;
            dt2 = (DataTable)Session["datos_dt2"];
            int pk_pro = Int32.Parse(dt2.Rows[proyectos.SelectedIndex]["PK_PROYECTO"].ToString());
            dt1 = (DataTable)Session["datos_dt1"];
            int pk_var = Int32.Parse(dt1.Rows[index]["idVARIABLE"].ToString());
            VariableController obj = new VariableController();
            if (obj.asignarVariable(pk_pro, pk_var)) {
                h += "exitoso";
            } else {
                h += "no exitoso";
            }
            cargarVariables(pk_pro);
        }

        protected void boton_Click(object sender, EventArgs e) {
            dt2 = (DataTable) Session["datos_dt2"];
            int pk_pro = Int32.Parse(dt2.Rows[proyectos.SelectedIndex]["PK_PROYECTO"].ToString());
            cargarVariables(pk_pro);
        }

        public void cargarVariables(int pk_pro) {
            variables.Items.Clear();
            VariableController obj = new VariableController();
            dt1 = obj.consulatarNombreVariablesDisponibles(pk_pro);
            for (int i = 0; i < dt1.Rows.Count; i++) {
                variables.Items.Add(dt1.Rows[i]["NOMBRE_VARIABLE"].ToString());
            }
            Session["datos_dt1"] = dt1;
        }
    }
}
