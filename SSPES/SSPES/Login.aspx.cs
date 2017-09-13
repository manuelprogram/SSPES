using SSPES.Controllers;
using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES {
    public partial class Login : System.Web.UI.Page {

        CuentaController userc = new CuentaController();
        CuentaModel us = new CuentaModel();

        protected void Page_Load(object sender, EventArgs e) {
            //userc.consultarUsuarios();
        }

        protected void BIniciarSesion_Click(object sender, EventArgs e) {
            try {

                if (!String.IsNullOrEmpty(TUsuario.Text) && !String.IsNullOrEmpty(TContrasenia.Text)) {
                    us.Usuario = TUsuario.Text;
                    us.Password = TContrasenia.Text;

                    if (us.ConsultarCuenta(us)) {
                        Response.Redirect("Views/Home/Principal.aspx");
                    } else {
                        //LMensaje.Text = "Error en el Usuario"; Se debe agregar un label para mostrar esto
                    }
                } else {
                    //LMensaje.Text = "Digite la credenciales"; Se debe agregar un label para mostrar esto
                }

            } catch (Exception) { }
        }
    }
}
