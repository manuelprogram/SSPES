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

        public ProyectoController(string a, string b, DateTime c, DateTime c2, HttpPostedFile d, string e, int f) {
            obj = new ProyectoModel(a, b, c, c2, d, e, f);
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

        public DataTable consultarProyectosPersona(string pk_dir) {
            return obj.consultarProyectosPersona(pk_dir);
        }

        public bool agregarIntegrante(string pk_cuenta, string pk_proyecto) {
            return obj.agregarIntegrante(pk_cuenta, pk_proyecto);
        }

        public bool eliminarIntegrante(string pk_cuenta, string pk_proyecto) {
            return obj.eliminarIntegrante(pk_cuenta, pk_proyecto);
        }

        public string CantidadProyecto(string pk_user) {
            return obj.CantidadProyectos(pk_user);
        }
        
        public string getPkIntegranteProyecto(string pk_cuent, string pk_proyecto) {
            return obj.getPkIntegranteProyecto(pk_cuent, pk_proyecto);
        }

        public string getPkProyecto() {
            return obj.getPk();
        }
    }
}
