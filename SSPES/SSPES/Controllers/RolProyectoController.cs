using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class RolProyectoController {

        public RolProyectoModel obj;

        public RolProyectoController() {
            obj = new RolProyectoModel();
        }

        public RolProyectoController(string a, string b, string c) {
            obj = new RolProyectoModel(a, b, c);
        }

        public DataTable consultarRoles() {
            return obj.consultarRoles();
        }
    }
}