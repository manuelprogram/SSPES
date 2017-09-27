using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Roles {
    public partial class ModificarRoles : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            RolController Rol = new RolController();
            List<string> lista = Rol.consultarRoles(Rol.modelo);
            select_roles.Items.Clear();
            select_roles.Items.Add("holitaa");
            select_roles.Items.Add("soy yo");
            for (int i = 0; i < lista.Count; i++) {
                select_roles.Items.Add(lista[i]);
            }
        }
    }
}