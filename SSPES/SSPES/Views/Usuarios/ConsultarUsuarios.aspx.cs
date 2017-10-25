using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Usuarios {
    public partial class ConsultarUsuarios : System.Web.UI.Page {
        public DataTable dtConsulta=new DataTable();
        public DataRow drConsulta;
        
        PersonaController Persona = new PersonaController();
        protected void Page_Load(object sender, EventArgs e) {
            dtConsulta = Persona.ConsultarDatosPersonas();
            if (dtConsulta.Rows.Count > 0) {
                drConsulta = dtConsulta.Rows[0];
            }
        }

        protected void Nuevo_Click(object sender, EventArgs e) {
            Response.Redirect("../Usuarios/RegistrarUsuario.aspx");
        }
    }
}