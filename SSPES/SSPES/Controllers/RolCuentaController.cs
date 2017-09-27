using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSPES.Controllers {
    public class RolCuentaController {
       public RolCuentaModel RC = new RolCuentaModel();
       public void InsertarRolCuenta() {
            RC.InsertarRolCuenta(RC);
        }
    }
}