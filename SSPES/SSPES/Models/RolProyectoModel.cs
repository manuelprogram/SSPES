using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class RolProyectoModel {

        private string pk_proyecto { get; set; }
        private string nombre { get; set; }
        private string descripcion { get; set; }
        private Conexion con = new Conexion();

        public RolProyectoModel() {
        }

        public RolProyectoModel(string a, string b, string c) {
            pk_proyecto = a;
            nombre = b;
            descripcion = c;
        }

        public DataTable consultarRoles() {
            string sql = "SELECT * FROM rol_proyecto ;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}
