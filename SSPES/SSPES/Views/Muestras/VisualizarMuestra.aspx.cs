using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SSPES.Views.Muestras {
    public partial class VisualizarMuestra : System.Web.UI.Page {

        private DataTable dtProyectos, dtMuestras;

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

        //llenar tabla

        private void llenarTabla(DataTable aux) {
            for (int i = 0; i < aux.Rows.Count; i++) {
                HtmlTableRow htr = new HtmlTableRow();
                DataRow dr = aux.Rows[i];

                HtmlTableCell c0 = new HtmlTableCell(), c1 = new HtmlTableCell(), c2 = new HtmlTableCell(),
                    c3 = new HtmlTableCell();
                c0.InnerText = (i + 1) + "";
                c1.InnerText = dr["NOMBRE_VARIABLE"].ToString();
                c2.InnerText = dr["VALOR_VARIABLE"].ToString();
                c3.InnerText = dr["DESCRIPCION_VARIABLE"].ToString();
                htr.Cells.Add(c0);
                htr.Cells.Add(c1);
                htr.Cells.Add(c2);
                htr.Cells.Add(c3);

                tablaMuestras.Rows.Add(htr);
            }
        }

        //cargar proyectos

        public void cargarProyectos() {
            proyecto.Items.Clear();
            ListaMuestras.Items.Clear();
            tablaMuestras.Rows.Clear();
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
            tablaMuestras.Rows.Clear();
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

        protected void botonReporte_Click(object sender, EventArgs e) {
            if (Session["pk_pro"] == null) {
                Response.Write("<script> alert('Seleccione un proyecto'); </script>");
                return;
            }

            Response.Redirect("../Reportes/Reporte.aspx?tipo=5&idpro=" + Session["pk_pro"].ToString());
        }

        protected void ListaMuestras_SelectedIndexChanged(object sender, EventArgs e) {
            dtMuestras = (DataTable)Session["dtMuestas"];
            muestraSeleccionada.Text = ListaMuestras.SelectedItem.Text;
            descripcionMuestra.Text = dtMuestras.Rows[ListaMuestras.SelectedIndex]["OBSERVACIONES"].ToString();

            MuestraController mc = new MuestraController();
            DataTable aux = mc.getValorVariablesMuestras(dtMuestras.Rows[ListaMuestras.SelectedIndex]["PK_MUESTRA"].ToString());
            llenarTabla(aux);
        }
    }
}
