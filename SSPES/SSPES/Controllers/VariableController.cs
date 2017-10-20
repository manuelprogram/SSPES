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

        public bool asignarVariable(int pro, int var) {
            return obj.asignarVariable(pro, var);
        }

        public DataTable consultarVariables(string pk_pro) {
            return obj.consultarVariables(pk_pro);
        }
    }
}
