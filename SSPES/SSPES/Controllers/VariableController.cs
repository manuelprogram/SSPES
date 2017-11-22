using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class VariableController {

        protected VariableModel obj;
        
        public VariableController(string a, string b, string c) {
            obj = new VariableModel(a, b, c);
        }

        public VariableController() {
            obj = new VariableModel();
        }

        public bool Registrar() {
            return obj.registrarVariable();
        }

        public DataTable consulatarNombreVariablesDisponibles(String pk) {
            return obj.consultarVariablesDisponibles(pk);
        }

        public bool asignarVariable(string pro, string var) {
            return obj.asignarVariable(pro, var);
        }

        public bool eliminarVariable(string pro, string var) {
            return obj.eliminarAsignacion(pro, var);
        }

        public DataTable consultarEstadoVariablesProyecto(string pk_pro) {
            return obj.consultarEstadoVariablesProyecto(pk_pro);
        }

        public DataTable consultarVariablesProyecto(string pk_pro) {
            return obj.consultarVariablesProyecto(pk_pro);
        }
    }
}
