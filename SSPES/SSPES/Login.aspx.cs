using SSPES.Controllers;
using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES {
    public partial class Login : System.Web.UI.Page {

        CuentaController userc = new CuentaController();
        CuentaModel us = new CuentaModel();
        DataRow dato;
        DataTable aux;
        //private int script;

        protected void Page_Load(object sender, EventArgs e) {
            Session.Clear();
        }

        protected void BIniciarSesion_Click(object sender, EventArgs e) {
            try {

                if (!String.IsNullOrEmpty(TUsuario.Text) && !String.IsNullOrEmpty(TContrasenia.Text)) {
                    us.Usuario = TUsuario.Text;
                    us.Password = TContrasenia.Text;
                    aux = us.ConsultarCuenta(us);
                    if (aux.Rows.Count > 0) {
                        dato = aux.Rows[0];
                        Session["PK_CUENTA"] = dato["PK_CUENTA"].ToString();
                        Session["Id_Session"] =Session.SessionID.ToString();

                       
                        Response.Redirect("Views/Home/Principal.aspx");
                    } else {
                        Response.Write("<script> alert('VERIFIQUE USUARIO O CONTRASEÑA'); </script>");
                    }
                } else {
                    Response.Write("<script> alert('CAMPOS NO PUEDEN SER VACIOS'); </script>");
                }

            } catch (Exception) { Response.Write("<script> alert(':('); </script>"); }
        }
    }
}
