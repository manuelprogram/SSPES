using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSPES.Controllers {
    public class CuentaController : ApiController {
        CuentaModel useres = new CuentaModel();

        //public DataTable consultarUsuarios() {
        //    return useres.consultarUsuarios();
        //}

        public void Insertar(CuentaModel obj) {
            obj.insertarNuevaCuenta(obj);
        }
    }
}
