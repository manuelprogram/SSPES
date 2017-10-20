using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Text.RegularExpressions;
using System.Data;

namespace SSPES.Views.Proyectos {
    public partial class AdministrarProyecto : System.Web.UI.Page {

        private DataTable dtProyectos, dtVariables, dtIntegrantes, dtroles;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        public void cargarProyectos() {
            radio.Items.Clear();
            proyectos.Items.Clear();
            rolProyectos.Items.Clear();

            ProyectoController obj2 = new ProyectoController();
            dtProyectos = obj2.consultarProyectosDirector(Session["PK_CUENTA"].ToString());
            for (int i = 0; i < dtProyectos.Rows.Count; i++) {
                proyectos.Items.Add(dtProyectos.Rows[i]["NOMBRE"].ToString());
            }
            Session["datos_dtProyecto"] = dtProyectos;
        }

        //ASignacion variables

        protected void Button_Click(object sender, EventArgs e) {
            dtProyectos = (DataTable)Session["datos_dtProyecto"];//Proyecto seleccionado
            if (dtProyectos == null) return;
            string pk_pro = dtProyectos.Rows[proyectos.SelectedIndex]["PK_PROYECTO"].ToString();
            Session["pk_pro"] = pk_pro;
            nombrePro.InnerText = "Proyecto seleccionado: " + proyectos.SelectedItem;
            cargarVariables(pk_pro);
            llenarUsuarios(pk_pro);
            llenarRoles();
        }

        public void cargarVariables(string pk_pro) {
            radio.Items.Clear();
            VariableController obj = new VariableController();
            dtVariables = obj.consulatarNombreVariablesDisponibles(pk_pro);
            for (int i = 0; i < dtVariables.Rows.Count; i++) {
                radio.Items.Add(dtVariables.Rows[i]["NOMBRE_VARIABLE"].ToString());
            }
            Session["datos_dtVariables"] = dtVariables;
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            int pk_pro;
            try {
                VariableController obj = new VariableController();
                int con = 0, activos = 0;
                for (int i = 0; i < radio.Items.Count; i++) {
                    if (radio.Items[i].Selected) {
                        activos++;
                        pk_pro = Int32.Parse(Session["pk_pro"].ToString());
                        dtProyectos = (DataTable)Session["datos_dtProyecto"];
                        dtVariables = (DataTable)Session["datos_dtVariables"];
                        int pk_var = Int32.Parse(dtVariables.Rows[i]["idVARIABLE"].ToString());

                        if (!obj.asignarVariable(pk_pro, pk_var)) {
                            con++;
                        }
                    }
                }
                if (activos == 0) {
                    Response.Write("<script> alert('Seleccione un proyecto'); </script>");
                    return;
                }
                if (con == 0) {
                    Response.Write("<script> alert('Exitoso'); </script>");
                } else {
                    Response.Write("<script> alert('Error al asignar al menos uno'); </script>");
                }
                cargarVariables(Session["pk_pro"].ToString());
            } catch (Exception) {
                Response.Write("<script> alert('Error inesperado'); </script>");
                radio.Items.Clear();
            }
        }

        //Asignacion integrantes

        public void llenarUsuarios(string pk_pro) {
            users.Items.Clear();
            CuentaController cc = new CuentaController();
            dtIntegrantes = cc.consultarUsuariosDisponiblesProyecto(pk_pro);
            Session["dtIntegrantes"] = dtIntegrantes;
            foreach (DataRow dr in dtIntegrantes.Rows) {
                users.Items.Add(dr["NOMBRE_1"].ToString() + "  " + dr["APELLIDO_1"].ToString());
            }
        }

        protected void llenarRoles() {
            rolProyectos.Items.Clear();
            RolProyectoController rpc = new RolProyectoController();
            dtroles = rpc.consultarRoles();
            Session["dtRoles"] = dtroles;
            foreach (DataRow dr in dtroles.Rows) {
                rolProyectos.Items.Add(dr["NOMBRE_ROL_PROYECTO"].ToString());
            }
        }

        //boton de registrar
        protected void boton_Click(object sender, EventArgs e) {
            if (rolProyectos.Items.Count == 0) {
                Response.Write("<script> alert('Seleccione un proyecto'); </script>");
                return;
            }
            RolProyectoController rpc = new RolProyectoController();
            dtroles = (DataTable)Session["dtRoles"];
            dtProyectos = (DataTable)Session["dtProyectos"];
            dtIntegrantes = (DataTable)Session["dtIntegrantes"];
            ProyectoController pc = new ProyectoController();
            int con = 0, activos = 0;

            for (int i = 0; i < users.Items.Count; i++) {
                if (users.Items[i].Selected) {
                    activos++;
                    if (!pc.agregarIntegrante(dtIntegrantes.Rows[i]["PK_CUENTA"].ToString(),
                        Session["pk_pro"].ToString(),
                        dtroles.Rows[rolProyectos.SelectedIndex]["PK_ROL_PROYECTO"].ToString())) con++;
                }
            }
            if (activos == 0) {
                Response.Write("<script> alert('Seleccione integrantes'); </script>");
                return;
            }
            if (con == 0) Response.Write("<script> alert('Exitoso'); </script>");
            else {
                Response.Write("<script> alert('Error al registrar al menos uno'); </script>");
            }
            llenarUsuarios(Session["pk_pro"].ToString());
        }
    }
}
