using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Proyectos {
    public partial class ModificarProyecto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public bool validarLetrasYNumeros(String h) {
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^. ^:]");
            return !reg.IsMatch(h);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (!validarLetrasYNumeros(nombreProyecto.Value.ToString()) || 
                !validarLetrasYNumeros(descripcionProyecto.Value.ToString())) {
                Response.Write("<script> alert('Informacion no valida'); </script>");
                return;
            }
           
        }
    }
}