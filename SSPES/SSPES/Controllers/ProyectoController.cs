using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;

namespace SSPES.Controllers {
    public class ProyectoController {

        ProyectoModel obj;

        public ProyectoController() {
            obj = new ProyectoModel();
        }

        public List<string> consultarProyectosActivos() {
            return obj.ConsultarProyectos();
        }
    }
}