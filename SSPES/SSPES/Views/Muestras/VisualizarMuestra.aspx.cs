using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Muestras {
    public partial class VisualizarMuestra : System.Web.UI.Page {

        private DataTable dtProyectos, dtMuestras;

        protected void Page_Load(object sender, EventArgs e) {
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
            Session["dtMuestas"] = dtMuestras;
        }

        protected void ListaMuestras_SelectedIndexChanged(object sender, EventArgs e) {
            dtMuestras = (DataTable)Session["dtMuestas"];
            muestraSeleccionada.Text = ListaMuestras.SelectedItem.Text;
            descripcionMuestra.Text = dtMuestras.Rows[ListaMuestras.SelectedIndex]["OBSERVACIONES"].ToString();

            MuestraController mc = new MuestraController();
            rep.DataSource = mc.getValorVariablesMuestras(dtMuestras.Rows[ListaMuestras.SelectedIndex]["PK_MUESTRA"].ToString());
            rep.DataBind();
            rep.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }
    }
}
