using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class UsuarioModel {

        Conexion con = new Conexion();

        public DataTable consultarUsuarios() {
            return new DataTable();
        }
    }
}