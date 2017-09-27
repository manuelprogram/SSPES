using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class ProyectoModel {

        private Conexion con = new Conexion();
        protected string nombre { get; set; }
        protected string descripcion { get; set; }

        public ProyectoModel(string a, string b) {
            nombre = a;
            descripcion = b;
        }

        public ProyectoModel() {
        }

        public List<string> ConsultarProyectos() {
            List<string> lista = new List<string>();
            string sql = "SELECT NOMBRE FROM proyecto WHERE ESTADO = 'A';";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            foreach (DataRow row in data.Rows) {
                lista.Add(row[0].ToString());
            }
            return lista;
        }
    }
}