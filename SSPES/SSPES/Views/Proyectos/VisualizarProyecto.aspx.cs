using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Proyectos {
    public partial class VisualizarProyecto : System.Web.UI.Page {

        public DataTable dt;
        public DataRow dr;
        public string flag;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!this.IsPostBack) {
                cargarProyectos();
            }
        }

        protected void cargarProyectos() {
            ProyectoController pc = new ProyectoController();
            dt = pc.consultarProyectosPersona(Session["PK_CUENTA"].ToString());
            rep.DataSource = dt;
            rep.DataBind();
        }

        protected void descargar(Object sender, CommandEventArgs e) {

            int pk_proyecto = Int32.Parse(e.CommandArgument.ToString());
            try {
                ProyectoController p = new ProyectoController();
                DataTable data = p.descargarDocumento(pk_proyecto);
                byte[] arr = (byte[])(data.Rows[0]["ARCHIVO"]); //System.UnauthorizedAccessException
                string nombre = data.Rows[0]["NOMBREARCHIVO"].ToString();

                FileStream h = new FileStream(nombre, FileMode.Create);
                h.Write(arr, 0, Convert.ToInt32(arr.Length));
                h.Close();

                System.Diagnostics.Process obj = new System.Diagnostics.Process();
                obj.StartInfo.FileName = nombre;

                var buffer = File.ReadAllBytes(nombre);
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Type", "application/msword");
                Response.AddHeader("Content-disposition", "attachment; filename=" + nombre);
                Response.BinaryWrite(buffer);
                Response.ContentType = "application/msword";
            } catch (Exception) {
                Response.Write("<script> alert('No hay documento'); </script>");
                return;
            }
        }
        public string ProcessMyDataItem(object myValue) {
            if (myValue.ToString().Equals("R")) {
                return "panel panel-danger";
            } else if (myValue.ToString().Equals("A")) {
                return "panel panel-warning";
            } else {
                return "panel panel-success";
            }

        }

    }
}
