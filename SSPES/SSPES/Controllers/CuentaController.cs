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
        public CuentaModel useres = new CuentaModel();

        public bool Insertar(CuentaModel obj) {
            return obj.insertarNuevaCuenta(obj);
        }

        public bool cuentaExiste(CuentaModel obj) {
            return obj.ValidarCuentaExistente(obj);
        }

        public DataTable consultarMenu(string idCuenta) {
            return useres.consultarMenu(idCuenta);
        }
    }
}
