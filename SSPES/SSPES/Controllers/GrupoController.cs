using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.Models;
using System.Data;

namespace SSPES.Controllers {
    public class GrupoController {
        GrupoModel model;
        public GrupoController() {
            model = new GrupoModel();
           
        }

        public DataTable ConsultarGrupo() {
            return model.ConsultarGrupo();
        }

        public bool ActualizarGrupo(string siglas, string nombre, string descripcion, string institucion) {
            return model.RealizarUpdate(siglas,nombre,descripcion,institucion);
        }
    }
}