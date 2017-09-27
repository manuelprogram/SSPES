using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSPES.Controllers {
    public class RolController {

        public RolModel modelo = new RolModel();

        public List<string> consultarRoles(RolModel obj) {
            return obj.consultarRoles(obj);
        }
    }
}