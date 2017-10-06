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
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button2_Click(object sender, EventArgs e) {

            try {
                ProyectoController p = new ProyectoController();
                DataTable data = p.descargarDocumento(Int32.Parse(idProyecto.Value.ToString()));
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
            } catch (Exception) { return; }
        }
    }
}