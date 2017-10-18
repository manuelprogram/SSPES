using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Data;

namespace SSPES.Views.IntegrantesProyectos {
    public partial class RegistrarIntegranteProyecto : System.Web.UI.Page {

        public DataTable dtProyectos, dtintegrantes, dtroles;
        private ProyectoController pc = new ProyectoController();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        protected void cargarProyectos() {
            proyectos.Items.Clear();
            user.Items.Clear();
            rolProyecto.Items.Clear();
            dtProyectos = pc.consultarProyectosDirector(Session["PK_CUENTA"].ToString());
            Session["dtProyectos"] = dtProyectos;
            proyectos.Items.Add("");
            for (int i = 0; i < dtProyectos.Rows.Count; i++) {
                proyectos.Items.Add(dtProyectos.Rows[i]["NOMBRE"].ToString());
            }
            texto.Text = "Descripcion del proyecto.";
        }

        protected void proyectos_SelectedIndexChanged(object sender, EventArgs e) {
            user.Items.Clear();
            rolProyecto.Items.Clear();
            int index = proyectos.SelectedIndex;
            if (index == 0) {
                texto.Text = "";
                return;
            }
            dtProyectos = (DataTable) Session["dtProyectos"];
            try {
                texto.Text = dtProyectos.Rows[index - 1]["DESCRIPCION"].ToString();
                llenarUsuarios(Int32.Parse(dtProyectos.Rows[index - 1]["PK_PROYECTO"].ToString()));
            } catch (Exception) {
                texto.Text = "Error inesperado";
                user.Items.Clear();
                return;
            }
        }

        public void llenarUsuarios(int pk_pro) {
            user.Items.Clear();
            CuentaController cc = new CuentaController();
            dtintegrantes = cc.consultarUsuariosDisponiblesProyecto(pk_pro);
            Session["dtIntegrantes"] = dtintegrantes;
            foreach (DataRow dr in dtintegrantes.Rows) {
                user.Items.Add(dr["USUARIO"].ToString());
            }
        }

        protected void user_SelectedIndexChanged(object sender, EventArgs e) {
            int index = user.SelectedIndex;
            rolProyecto.Items.Clear();
            RolProyectoController rpc = new RolProyectoController();
            dtroles = rpc.consultarRoles();
            Session["dtRoles"] = dtroles;
            foreach (DataRow dr in dtroles.Rows) {
                rolProyecto.Items.Add(dr["NOMBRE_ROL_PROYECTO"].ToString());
            }
        }

        //boton de registrar
        protected void boton_Click(object sender, EventArgs e) {
            if (rolProyecto.Items.Count == 0 || rolProyecto.SelectedIndex < 0) return;
            RolProyectoController rpc = new RolProyectoController();
            dtroles = (DataTable) Session["dtRoles"];
            dtProyectos = (DataTable) Session["dtProyectos"];
            dtintegrantes = (DataTable) Session["dtIntegrantes"];

            ProyectoController pc = new ProyectoController();
            if(pc.agregarIntegrante(dtintegrantes.Rows[user.SelectedIndex]["PK_CUENTA"].ToString(),
                dtProyectos.Rows[proyectos.SelectedIndex - 1]["PK_PROYECTO"].ToString(),
                dtroles.Rows[rolProyecto.SelectedIndex]["PK_ROL_PROYECTO"].ToString())) {
                Response.Write("<script> alert('Exitoso'); </script>");
            } else {
                Response.Write("<script> alert('Error al registrar'); </script>");
            }
            rolProyecto.Items.Clear();
            llenarUsuarios(Int32.Parse(dtProyectos.Rows[proyectos.SelectedIndex - 1]["PK_PROYECTO"].ToString()));
        }
    }
}
