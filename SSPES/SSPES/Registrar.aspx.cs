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

        CuentaModel obj = new CuentaModel(); 
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BRegistrar_Click(object sender, EventArgs e) {
            obj.Usuario = TUsuario.Text;
            obj.Password = TContrasenia.Text;
            if (obj.ValidarCuentaExistente(obj)) {
                LMensaje.Text = "Usuario Existente!";
            } else {
                LMensaje.Text = "Correcto!";
                obj.insertarNuevaCuenta(obj);
                Response.Redirect("Login.aspx");
            }
        }
    }
}