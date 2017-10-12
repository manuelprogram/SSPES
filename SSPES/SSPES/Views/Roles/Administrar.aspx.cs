using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Roles {
    public partial class Administrar : System.Web.UI.Page {
        public List<string> Permisos = new List<string>();
        protected void Page_Load(object sender, EventArgs e) {
            RolController Rol = new RolController();
            List<string> lista = Rol.consultarRoles(Rol.modelo);
            select_roles.Items.Clear();
            for (int i = 0; i < lista.Count; i++) {
                select_roles.Items.Add(lista[i]);
            }

        }

        protected void brt_Click(object sender, EventArgs e) {
            string aux;
            if (tx_rol.Text.Equals("") == false) {
                RolController r=new RolController();
                r.RegistrarRol(tx_rol.Text);
                aux = "Operacion Exitosa";
            } else {
                aux= "Error campos vacios";
            }
            Response.Write("<script> alert('"+aux+"'); </script>");

        }
    }
}