using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;

namespace SSPES.Views.AsignacionVariables {
    public partial class AsignarVariables : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            variables.Items.Clear();
            proyectos.Items.Clear();

            VariableController obj = new VariableController();
            List<string> var = obj.consulatarNombreVariables();
            foreach (string s in var) {
                variables.Items.Add(s);
            }

            ProyectoController obj2 = new ProyectoController();
            List<string> var2 = obj2.consultarProyectosActivos();
            foreach (string s in var2) {
                proyectos.Items.Add(s);
            }
        }
    }
}
