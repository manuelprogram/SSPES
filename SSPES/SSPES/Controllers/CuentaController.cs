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
        
        public CuentaController() {
            useres = new CuentaModel();
        }

        public CuentaController(string a, string b, char c, int d) {
            useres = new CuentaModel(a, b, c, d);
        }

        public bool Insertar(CuentaModel obj) {
            return obj.insertarNuevaCuenta(obj);
        }

        public bool cuentaExiste(CuentaModel obj) {
            return obj.ValidarCuentaExistente(obj);
        }

        public DataTable consultarMenu(string idCuenta) {
            return useres.consultarMenu(idCuenta);
        }

        public string GetPkcuenta(string obj) {
            return useres.GetFk_cuenta(obj);
        }
        
        public string GetNombresUsuario(int pkcuenta) {
            PersonaModel p = new PersonaModel();
            return p.ConsultarNombresUsuario(useres.cosultarPKPersona(pkcuenta));
        }

        public DataTable consultarUsuariosDisponiblesProyecto(string pk_pro) {
            return useres.consultarUsuariosDisponiblesProyecto(pk_pro);
        }
    }
}
