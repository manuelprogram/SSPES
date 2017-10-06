using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class ProyectoController {

        ProyectoModel obj;

        public ProyectoController() {
            obj = new ProyectoModel();
        }

        public ProyectoController(string a, string b, DateTime c, HttpPostedFile d) {
            obj = new ProyectoModel(a, b, c, d);
        }

        public List<string> consultarProyectosActivos() {
            return obj.ConsultarProyectos();
        }

        public bool insertarProyecto() {
            return obj.registrarProyecto();
        }

        public DataTable descargarDocumento(int pk) {
            return obj.cargarDocumento(pk);
        }
    }
}