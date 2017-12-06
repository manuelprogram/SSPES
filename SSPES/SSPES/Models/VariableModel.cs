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
        
        public DataTable consultarVariablesDisponibles(string pk_pro) {
            string sql = "SELECT idVARIABLE, NOMBRE_VARIABLE ";
                sql += "FROM variable WHERE NOT EXISTS ( ";
                sql += "   SELECT * FROM variable_proyecto ";
                sql += "   WHERE variable.idVARIABLE = variable_proyecto.FK_VARIABLE ";
                sql += "   AND variable_proyecto.FK_PROYECTO = " + pk_pro;
                sql += ") ";
                sql += "ORDER BY NOMBRE_VARIABLE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool asignarVariable(string pkProyecto, string pkVariable) {
            string[] sql = new string[1];
            sql[0] = "INSERT INTO variable_proyecto (FK_PROYECTO, FK_VARIABLE)";
            sql[0] += "VALUES(" + pkProyecto + ", " + pkVariable + ");";
            return con.RealizarTransaccion(sql);
        }

        public DataTable consultarEstadoVariablesProyecto(string pk_pro) {
            string sql = @"SELECT idVARIABLE, NOMBRE_VARIABLE, 
                if(EXISTS(SELECT FK_PROYECTO FROM variable_proyecto 
                WHERE variable_proyecto.FK_PROYECTO='"+ pk_pro + @"' AND
                variable_proyecto.FK_VARIABLE = variable.idVARIABLE
                ), 'Si', 'No') as 'EXISTE' FROM variable ORDER BY NOMBRE_VARIABLE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultarVariablesProyecto(string pk_pro) {
            string sql = @"SELECT NOMBRE_VARIABLE, TIPO_DE_DATO, DESCRIPCION_VARIABLE, PK_VARIABLE_PROYECTO 
                FROM variable INNER JOIN variable_proyecto ON variable.idVARIABLE = 
                variable_proyecto.FK_VARIABLE AND variable_proyecto.FK_PROYECTO = '" + pk_pro + @"' ORDER 
                BY NOMBRE_VARIABLE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool eliminarAsignacion(string pkProyecto, string pkVariable) {
            string[] sql = new string[1];
                sql[0] = @"DELETE FROM variable_proyecto WHERE FK_PROYECTO = '" + pkProyecto + @"' 
                 AND FK_VARIABLE = '" + pkVariable + "' ;";
            return con.RealizarTransaccion(sql);
        }

        public DataTable consultarVariables() {
            string sql = @"SELECT NOMBRE_VARIABLE, TIPO_DE_DATO, DESCRIPCION_VARIABLE  FROM variable;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}
