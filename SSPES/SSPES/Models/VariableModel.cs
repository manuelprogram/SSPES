using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class VariableModel {

        private Conexion con = new Conexion();
        protected string nombre { get; set; }
        protected string tipoDato { get; set; }
        protected string descripcion { get; set; }

        public VariableModel(string a, string b, string c) {
            nombre = a;
            tipoDato = b;
            descripcion = c;
        }

        public VariableModel() {
        }

        public bool registrarVariable() {
            string[] ar = new string[1];
            ar[0] = "INSERT INTO variable (NOMBRE_VARIABLE, TIPO_DE_DATO, DESCRIPCION_VARIABLE, ESTADO) VALUES";
            ar[0] += "('" + nombre + "', '" + tipoDato + "', '" + descripcion + "', 'A');";
            return con.RealizarTransaccion(ar);
        }

        public List<string> consultarVariables() {
            List<string> lista = new List<string>();
            string sql = "SELECT NOMBRE_VARIABLE FROM variable;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            foreach (DataRow row in data.Rows) {
                lista.Add(row[0].ToString());
            }
            return lista;
        }
    }
}
