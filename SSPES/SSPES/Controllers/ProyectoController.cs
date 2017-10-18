using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class ProyectoController {

        public ProyectoModel obj;

        public ProyectoController() {
            obj = new ProyectoModel();
        }

        public ProyectoController(string a, string b, DateTime c, HttpPostedFile d, string e) {
            obj = new ProyectoModel(a, b, c, d, e);
        }

        public DataTable consultarNombreProyectos() {
            return obj.consultarNombreProyectos();
        }

        public bool insertarProyecto() {
            return obj.registrarProyecto();
        }

        public DataTable descargarDocumento(int pk) {
            return obj.cargarDocumento(pk);
        }

        public DataTable consultarProyectos() {
            return obj.consultarProyectos();
        }
        
        public DataTable consultarProyectosDirector(string pk_dir) {
            return obj.consultarProyectosDirector(pk_dir);
        }

        public bool agregarIntegrante(string a, string b, string c) {
            return obj.agregarIntegrante(Int32.Parse(a), Int32.Parse(b), Int32.Parse(c));
        }
    }
}
