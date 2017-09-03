using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES {
    public partial class Login : System.Web.UI.Page {

        UsuarioController userc = new UsuarioController();

        protected void Page_Load(object sender, EventArgs e) {
            userc.consultarUsuarios();
        }

        protected void BIniciarSesion_Click(object sender, EventArgs e) {
            try {

                if(!String.IsNullOrEmpty(TUsuario.Text) && !String.IsNullOrEmpty(TContrasenia.Text)) {
                    Response.Redirect("Views/Home/Principal.aspx");
                } else {
                    LMensaje.Text = "Digite la credenciales";
                }

            } catch (Exception) { }
        }
    }
}
