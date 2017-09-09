using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSPES.Controllers {
    public class ProfesionController {

        public ProfesionModel modelo = new ProfesionModel();

        public List<string> consultarProfesiones(ProfesionModel obj) {
            return obj.consultarProfesiones(obj);
        }
    }
}