using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class PersonaModel {

        public string Nombre_1 { get; set; }
        public string Nombre_2 { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
        public string T_documento { get; set; }
        public string N_documento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string rol { get; set; }

        Conexion con = new Conexion();
        private string fk_muestra;

        public int ConsultarIdUsuario(PersonaModel obj) {
            string sql = "SELECT PK_PERSONA FROM PERSONA where(N_DOCUMENTO='" + obj.N_documento + "');";
            foreach (DataRow row in con.EjecutarConsulta(sql, CommandType.Text).Rows) {
                return Int32.Parse(row[0].ToString());
            }
            return -1;
        }

        public string ConsultarNombresUsuario(int pk) {
            string sql = "SELECT NOMBRE_1, APELLIDO_1 FROM PERSONA where(PK_PERSONA='" + pk + "');";
            DataTable dt = con.EjecutarConsulta(sql, CommandType.Text);
            string nombres = dt.Rows[0]["NOMBRE_1"].ToString() + " " + dt.Rows[0]["APELLIDO_1"];
            return nombres;
        }

        public DataTable ConsultarDatosPersonas() {
            string sql = "SELECT t.N_DOCUMENTO as Documento, t.NOMBRE_1 as Nombre,t.APELLIDO_1 as Apellido,t.CELULAR as Celular,t.CORREO as Correo FROM persona t order by t.NOMBRE_1;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataRow ConsultarUpdate(string fk) {
            string sql = "select t_documento tipo, n_documento numero, celular celular, correo from persona where pk_persona='" + fk + "';";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows[0];
        }

        public bool RealizarUpdate(string tipo, string numero, string celular, string correo, string pk) {
            string[] sql = new string[1];
            sql[0] = "UPDATE persona SET T_DOCUMENTO='" + tipo + "', N_DOCUMENTO = '" + numero +"', CELULAR = '" + celular + "', CORREO ='" + correo + "' WHERE PK_PERSONA = '" + pk + "';";
            return con.RealizarTransaccion(sql);
        }


        public bool InsertarNuevaPersona(PersonaModel obj) {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            string sql = "INSERT INTO PERSONA (NOMBRE_1, NOMBRE_2, APELLIDO_1, APELLIDO_2, T_DOCUMENTO, N_DOCUMENTO,";
            sql = sql + " CELULAR, CORREO, REGISTRO) VALUES";
            sql = sql + "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.Nombre_1, obj.Nombre_2, obj.Apellido_1, obj.Apellido_2, obj.T_documento
                    , obj.N_documento, obj.Telefono, obj.Correo, fecha);
            return con.RealizarTransaccion(ar);
        }
    }
}
