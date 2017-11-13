using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSPES.BD;
using System.Data;

namespace SSPES.Models {

    public class MuestraModel {

        private string observaciones, fk_pro, fk_integrante_pro;
        private DateTime fecha;
        private Conexion con;

        public MuestraModel(string obs, DateTime f, string fk_proyecto, string fk_int_pro) {
            observaciones = obs;
            fecha = f;
            fk_pro = fk_proyecto;
            fk_integrante_pro = fk_int_pro;
            con = new Conexion();
        }

        public MuestraModel() {
            con = new Conexion();
        }

        public bool registrarMuestra(string numero) {
            string[] ar = new string[1];
            DateTime hoy = DateTime.Today;
            string f = hoy.Year + "-" + hoy.Month + "-" + hoy.Day;
            ar[0] = @"INSERT INTO muestra (OBSERVACIONES, FECHA, FK_PROYECTO, FK_INTEGRANTE_PROYECTO, NUMERO_MUESTRA) 
                VALUES ('" + observaciones + "', '" + f + "', '" + fk_pro + "', '" + fk_integrante_pro + "', '"
                + numero + "');";
            return con.RealizarTransaccion(ar);
        }

        public string getPk(string numMuestra) {
            string f = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            string sql = "SELECT PK_MUESTRA FROM muestra WHERE FK_PROYECTO = '" + fk_pro + "' AND FK_INTEGRANTE_PROYECTO = '";
            sql += fk_integrante_pro + "' AND FECHA = '" + f + "' AND NUMERO_MUESTRA = '" + numMuestra + "' ;";
            DataTable dt = con.EjecutarConsulta(sql, CommandType.Text);
            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0]["PK_MUESTRA"].ToString();
        }

        public string getNumeroMuestras() {
            string sql = "SELECT COUNT(*) FROM muestra WHERE muestra.FK_PROYECTO = '" + fk_pro + "' ;";
            DataTable dt = con.EjecutarConsulta(sql, CommandType.Text);
            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0]["COUNT(*)"].ToString();
        }

        public string getNumeroMuestras(string fkPro) {
            string sql = "SELECT COUNT(*) FROM muestra WHERE muestra.FK_PROYECTO = '" + fkPro + "' ;";
            DataTable dt = con.EjecutarConsulta(sql, CommandType.Text);
            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0]["COUNT(*)"].ToString();
        }

        public bool resgitrarValorMuestra(string a, string b, string c) {
            string[] ar = new string[1];
            ar[0] += "INSERT INTO muestra_variable (VALOR_VARIABLE, FK_MUESTRA, FK_VARIABLE_PROYECTO) ";
            ar[0] += "VALUES ('" + a + "', '" + b + "', '" + c + "');";
            return con.RealizarTransaccion(ar);
        }

        public DataTable getMuestrasProyecto(string pk_pro) {
            string sql = "SELECT PK_MUESTRA, OBSERVACIONES, NUMERO_MUESTRA, FECHA FROM muestra WHERE ";
            sql += "muestra.FK_PROYECTO = '" + pk_pro + "' ORDER BY NUMERO_MUESTRA;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable getValorVariablesMuestra(string pk_muestra) {
            string sql = @"SELECT PK_MUESTRA_VARIABLE, VALOR_VARIABLE, PK_VARIABLE_PROYECTO, NOMBRE_VARIABLE, TIPO_DE_DATO, 
                DESCRIPCION_VARIABLE FROM muestra_variable, variable_proyecto, variable WHERE 
                variable_proyecto.PK_VARIABLE_PROYECTO = muestra_variable.FK_VARIABLE_PROYECTO AND 
                muestra_variable.FK_MUESTRA = '" + pk_muestra + @"' AND variable.idVARIABLE = 
                variable_proyecto.FK_VARIABLE ORDER BY NOMBRE_VARIABLE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool ActualizarVariableMuestra(string fk_muestra, string fk_var_pro, string valor) {
            string[] sql = new string[1];
            sql[0] = @"UPDATE muestra_variable SET VALOR_VARIABLE='" + valor + @"' WHERE
                FK_MUESTRA = '" + fk_muestra + "' AND FK_VARIABLE_PROYECTO = '" + fk_var_pro + "';";
            return con.RealizarTransaccion(sql);
        }

        public bool ActualizarObservacionesMuestra(string pk_muestra, string obs) {
            //UPDATE muestra set OBSERVACIONES = 'se cambio' WHERE PK_MUESTRA = '20';
            string[] sql = new string[1];
            sql[0] = "UPDATE muestra set OBSERVACIONES = '" + obs + "' WHERE PK_MUESTRA = '" + pk_muestra + "';";
            return con.RealizarTransaccion(sql);
        }
    }
}
