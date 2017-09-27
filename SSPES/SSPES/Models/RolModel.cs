using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class RolModel {
        public string nombre;
        private Conexion con = new Conexion();

        public List<string> consultarRoles(RolModel obj) {
            List<string> lista = new List<string>();
            string sql = "SELECT ROL_NOMBRE FROM rol;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            foreach (DataRow row in data.Rows) {
                lista.Add(row[0].ToString());
            }
            return lista;
        }
    }
}