using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class MuestraController {

        private MuestraModel obj;

        public MuestraController() {
            obj = new MuestraModel();
        }

        public MuestraController(string observaciones, DateTime fecha, string fk_proyecto, string fk_int_pro) {
            obj = new MuestraModel(observaciones, fecha, fk_proyecto, fk_int_pro);
        }

        public bool registrarMuestra() {
            return obj.registrarMuestra();
        }

        public string getPk() {
            return obj.getPk();
        }

        public bool resgitrarValorMuestra(string valor, string fk_muestra, string fk_var_pro) {
            return obj.resgitrarValorMuestra(valor, fk_muestra, fk_var_pro);
        }

        public DataTable getMuestrasProyecto(string pk_pro) {
            return obj.getMuestrasProyecto(pk_pro);
        }

        public DataTable getValorVariablesMuestras(string pk_muestra) {
            return obj.getValorVariablesMuestra(pk_muestra);
        }
    }
}
