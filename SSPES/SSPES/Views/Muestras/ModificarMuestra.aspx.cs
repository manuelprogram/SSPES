using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Muestras {
    public partial class ModificarMuestra : System.Web.UI.Page {

        private DataTable dtProyectos, dtMuestras, dtVariables;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!IsPostBack) {
                cargarProyectos();
            }
        }
        
        protected string dias(string h) {
            switch (h) {
                case "Sunday":
                    return "Domingo";
                case "Monday":
                    return "Lunes";
                case "Tuesday":
                    return "Martes";
                case "Wednesday":
                    return "Miercoles";
                case "Thursday":
                    return "Jueves";
                case "Friday":
                    return "Viernes";
                default:
                    return "Sabado";
            }
        }

        //cargar proyectos

        public void cargarProyectos() {
            proyecto.Items.Clear();
            ListaMuestras.Items.Clear();
            rep.Visible = false;
            descripcionMuestra.ReadOnly = true;
            muestraSeleccionada.Text = "";
            descripcionMuestra.Text = "";

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
            llenarMuestras();
        }

        //muestras

        protected void llenarMuestras() {
            ListaMuestras.Items.Clear();
            rep.Visible = false;
            descripcionMuestra.ReadOnly = true;
            muestraSeleccionada.Text = "";
            descripcionMuestra.Text = "";

            MuestraController mc = new MuestraController();
            dtMuestras = mc.getMuestrasProyecto(Session["pk_pro"].ToString());
            cantidad.InnerText = "Hay " + dtMuestras.Rows.Count + " muestra(s)";
            string[] s;
            string f, mostrar;

            for (int i = 1; i <= dtMuestras.Rows.Count; i++) {
                f = dtMuestras.Rows[i - 1]["FECHA"].ToString();
                s = f.Split('-', '/', ' ');
                DateTime d = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
                mostrar = dias(d.DayOfWeek.ToString()) + " " + s[0] + "-" + s[1] + "-" + s[2];
                ListaMuestras.Items.Add("Muestra " + i + " de " + mostrar);
            }
            Session["dtMuestras"] = dtMuestras;
        }

        protected void ListaMuestras_SelectedIndexChanged(object sender, EventArgs e) {
            dtMuestras = (DataTable)Session["dtMuestras"];
            muestraSeleccionada.Text = ListaMuestras.SelectedItem.Text;
            descripcionMuestra.Text = dtMuestras.Rows[ListaMuestras.SelectedIndex]["OBSERVACIONES"].ToString();
            descripcionMuestra.ReadOnly = false;

            MuestraController mc = new MuestraController();
            dtVariables = mc.getValorVariablesMuestras(dtMuestras.Rows[ListaMuestras.SelectedIndex]["PK_MUESTRA"].ToString());
            Session["dtVariables"] = dtVariables;
            rep.DataSource = dtVariables;
            rep.DataBind();
            rep.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }

        //Actualizar muestra

        public bool validar(string h, string tipo) {
            if (h.Length == 0 || h.Length > 50) return false;

            if (tipo.Equals("Numero entero")) {
                for (int i = 0; i < h.Length; i++) {
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

        protected void ActualizarMuestra_Click(object sender, EventArgs e) {
            dtVariables = (DataTable) Session["dtVariables"];
            dtMuestras = (DataTable)Session["dtMuestras"];

            if (rep.Items.Count == 0 || dtVariables == null) {
                Response.Write("<script> alert('Seleccione un proyecto!!!'); </script>");
                return;
            }

            List<string> variables = new List<string>();
            int indice = 0;
            foreach (RepeaterItem ri in rep.Items) {
                TextBox tb = (TextBox)ri.FindControl("text");
                if (tb == null || tb.Text.Length == 0 || !validar(tb.Text, dtVariables.Rows[indice++]["TIPO_DE_DATO"].ToString())) {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                    Response.Write("<script> alert('Verifique los datos'); </script>");
                    return;
                } else {
                    variables.Add(tb.Text);
                }
            }

            MuestraController mc = new MuestraController();
            if (!mc.ActualizarObservacionesMuestra(dtMuestras.Rows[ListaMuestras.SelectedIndex]["PK_MUESTRA"].ToString(), 
                    descripcionMuestra.Text)) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                Response.Write("<script> alert('Error al actualizar la muestra'); </script>");
                return;
            }

            int con = 0;
            for (int i = 0; i < variables.Count; i++) {
                if (!mc.ActualizarVariableMuestra(dtMuestras.Rows[ListaMuestras.SelectedIndex]["PK_MUESTRA"].ToString(),
                    dtVariables.Rows[i]["PK_VARIABLE_PROYECTO"].ToString(), variables[i]) ) con++;
            }

            if (con == variables.Count) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
                Response.Write("<script> alert('Error al actualizar TODAS las variables'); </script>");
            } else {
                if (con == 0) Response.Write("<script> alert('Exitoso'); </script>");
                else Response.Write("<script> alert('Error al actualizar algunas variables'); </script>");
            }
            Response.Redirect("ModificarMuestra.aspx");
        }
    }
}
