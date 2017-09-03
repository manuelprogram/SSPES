using SSPES.Controllers;
using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES {
    public partial class Registrarse : System.Web.UI.Page {

        UsuarioModel obj = new UsuarioModel(); 
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BRegistrar_Click(object sender, EventArgs e) {
            obj.user = TUsuario.Text;
            obj.password = TContrasenia.Text;
            if (obj.ConsultarUsuario(obj)) {
                LMensaje.Text = "Usuario Existente!";
            } else {
                LMensaje.Text = "Correcto!";
                obj.insertar(obj);
                Response.Redirect("Login.aspx");
            }
        }
    }
}