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
        protected DateTime fecha { get; set; }
        protected byte[] archivo { get; set; }

        public ProyectoModel(string a, string b, DateTime c) {
            nombre = a;
            descripcion = b;
            fecha = c;
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
        
        public bool registrarProyecto() {
            string[] sql = new string[1];
            string f = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, ESTADO) VALUES(";
            sql[0] += "'" + nombre + "', '" + descripcion + "', '" + f + "', 'A');";
            return con.RealizarTransaccion(sql);
        }
    }
}