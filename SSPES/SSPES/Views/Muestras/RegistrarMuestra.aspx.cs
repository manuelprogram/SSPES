using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Data;
using System.Text.RegularExpressions;

namespace SSPES.Views.Muestras {

    public partial class RegistrarMuestra : System.Web.UI.Page {

        private DataTable dtProyectos, dtVariables;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        //cargar proyectos

        public void cargarProyectos() {
            proyecto.Items.Clear();

            ProyectoController obj2 = new ProyectoController();
            dtProyectos = obj2.consultarProyectosPersona(Session["PK_CUENTA"].ToString());
            for (int i = 0; i < dtProyectos.Rows.Count; i++) {
                proyecto.Items.Add(dtProyectos.Rows[i]["NOMBRE"].ToString());
            }
            Session["dtProyectos"] = dtProyectos;
        }

        protected void Button_Click(object sender, EventArgs e) {
            dtProyectos = (DataTable)Session["dtProyectos"];//Proyecto seleccionado
            if (dtProyectos == null) return;
            int index = proyecto.SelectedIndex;
            if (index < 0 || index >= dtProyectos.Rows.Count) {
                return;
            }
            string pk_pro = dtProyectos.Rows[index]["PK_PROYECTO"].ToString();
            Session["pk_pro"] = pk_pro;
            nombreProyecto.Text = proyecto.SelectedItem.ToString();
            texto.Text = dtProyectos.Rows[index]["DESCRIPCION"].ToString();
            cargarVariables();
        }

        //cargar variables

        protected void cargarVariables() {
            MuestraController mc = new MuestraController();
            string h = mc.getNumeroMuestras(Session["pk_pro"].ToString());
            Session["numeroMuestras"] = h;
            hNumeroMuestra.InnerText = "Muestra numero: " + (Int32.Parse(h) + 1);

            VariableController vc = new VariableController();
            dtVariables = vc.consultarVariablesProyecto(Session["pk_pro"].ToString());
            rep.DataSource = dtVariables;
            rep.DataBind();
            Session["dtVariables"] = dtVariables;
        }

        public bool validarLetrasYNumeros(string h, string tipo) {
            if (h.Length == 0 || h.Length > 50) return false;

            if (tipo.Equals("Numero Entero")) {
                for(int i = 0; i < h.Length; i++) {
                    if (h[i] < '0' || h[i] > '9') return false;
                }
            }

            if (tipo.Equals("Numero decimal")) {
                bool punto = false;
                for (int i = 0; i < h.Length; i++) {
                    if (h[i] == '.') {
                        if (punto) return false;
                        else punto = true;
                        continue;
                    }
                    if (h[i] < '0' || h[i] > '9') return false;
                }
            }
            return true;
        }

        protected void registrarMuestras_Click(object sender, EventArgs e) {
            if(rep.Items.Count == 0) {
                Response.Write("<script> alert('Seleccione un proyecto!!!'); </script>");
                return;
            }

            dtVariables = (DataTable) Session["dtVariables"];
            ProyectoController pc = new ProyectoController();
            string pk_int_pro = pc.getPkIntegranteProyecto(Session["PK_CUENTA"].ToString(), Session["pk_pro"].ToString());
            if (pk_int_pro == null) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                Response.Write("<script> alert('Error de permisos'); </script>");
                return;
            }

            List<string> variables = new List<string>();
            int indice = 0;
            foreach (RepeaterItem ri in rep.Items) {
                TextBox tb = (TextBox)ri.FindControl("text");
                if (tb == null || tb.Text.Length == 0 || !validarLetrasYNumeros(tb.Text, dtVariables.Rows[indice++]["TIPO_DE_DATO"].ToString())) {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                    Response.Write("<script> alert('Verifique los datos'); </script>");
                    return;
                } else {
                    variables.Add(tb.Text);
                }
            }

            MuestraController mc = new MuestraController(observaciones.Text, DateTime.Today, 
                Session["pk_pro"].ToString(), pk_int_pro);
            int numeroMuestras = Int32.Parse(Session["numeroMuestras"].ToString());
            if (!mc.registrarMuestra(numeroMuestras + 1)) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                Response.Write("<script> alert('Error al registrar la muestra'); </script>");
                return;
            }

            string pkMuestra = mc.getPk(numeroMuestras + 1);
            int con = 0;
            for (int i = 0; i < variables.Count; i++) {
                if (!mc.resgitrarValorMuestra(variables[i], pkMuestra,
                    dtVariables.Rows[i]["PK_VARIABLE_PROYECTO"].ToString())) con++;
            }

            if (con == variables.Count) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                Response.Write("<script> alert('Error al registrar TODAS las variables'); </script>");
            } else {
                if (con == 0) Response.Write("<script> alert('Exitoso'); </script>");
                else Response.Write("<script> alert('Error al registrar algunas variables'); </script>");
            }
            Response.Write("<script> alert('Exitoso'); </script>");
        }
    }
}
