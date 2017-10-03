using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using SSPES.Models;

namespace SSPES.Views.Variables {
    public partial class CrearVariable : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        private bool validar(string h) {
            if (h.Length < 3 || h.Length > 50) {
                return false;
            }
            return true;
        }

        protected void Registrar(object sender, EventArgs e) {
            if (!validar(nombreVariable.Value.ToString()) || !validar(descripcion.Value.ToString())) {
                resultado.InnerText = "Valide los campos";
                return;
            }

            VariableController obj = new VariableController(nombreVariable.Value.ToString(),
                descripcion.Value.ToString(), tDato.Value);
            if (obj.Registrar()) {
                resultado.InnerText = "Registro exitoso";
            }else {
                resultado.InnerText = "Error al registrar";
            }
        }
    }
}
