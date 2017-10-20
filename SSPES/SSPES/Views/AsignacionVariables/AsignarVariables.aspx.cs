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

        public DataTable dtVariables, dtProyectos;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        public void cargarProyectos() {
            variable.Items.Clear();
            proyecto.Items.Clear();

            ProyectoController obj2 = new ProyectoController();
            dtProyectos = obj2.consultarProyectosDirector(Session["PK_CUENTA"].ToString());
            for (int i = 0; i < dtProyectos.Rows.Count; i++) {
                proyecto.Items.Add(dtProyectos.Rows[i]["NOMBRE"].ToString());
            }
            Session["datos_dtProyecto"] = dtProyectos;
        }

        protected void Button_Click(object sender, EventArgs e) {
            dtProyectos = (DataTable)Session["datos_dtProyecto"];//Proyecto seleccionado
            int pk_pro = Int32.Parse(dtProyectos.Rows[proyecto.SelectedIndex]["PK_PROYECTO"].ToString());
            Session["pk_pro"] = pk_pro.ToString();
            cargarVariables(pk_pro);
        }

        public void cargarVariables(int pk_pro) {
            variable.Items.Clear();
            VariableController obj = new VariableController();
            dtVariables = obj.consulatarNombreVariablesDisponibles(pk_pro.ToString());
            for (int i = 0; i < dtVariables.Rows.Count; i++) {
                variable.Items.Add(dtVariables.Rows[i]["NOMBRE_VARIABLE"].ToString());
            }
            Session["datos_dtVariables"] = dtVariables;
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            int pk_pro = -1;
            try {
                int index = variable.SelectedIndex;
                if (index < 0) {
                    Response.Write("<script> alert('Seleccione una variable'); </script>");
                    return;
                }
                dtProyectos = (DataTable)Session["datos_dtProyecto"];
                pk_pro = Int32.Parse(Session["pk_pro"].ToString());
                dtVariables = (DataTable)Session["datos_dtVariables"];
                int pk_var = Int32.Parse(dtVariables.Rows[index]["idVARIABLE"].ToString());

                VariableController obj = new VariableController();
                if (obj.asignarVariable(pk_pro, pk_var)) {
                    Response.Write("<script> alert('Exitoso'); </script>");
                } else {
                    Response.Write("<script> alert('Error al asignar'); </script>");
                }
            } catch (Exception) {
                Response.Write("<script> alert('Error inesperado'); </script>");
                pk_pro = -1;
            }
            if (pk_pro != -1) cargarVariables(pk_pro);
            else variable.Items.Clear();
        }
    }
}
