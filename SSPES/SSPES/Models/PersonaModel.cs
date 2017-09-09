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
        public int Profesion { get; set; }

        Conexion con = new Conexion();

        public int ConsultarIdUsuario(PersonaModel obj) {
            string sql = "SELECT PK_PERSONA FROM PERSONA where(N_DOCUMENTO='" + obj.N_documento + "');";
            foreach(DataRow row in con.EjecutarConsulta(sql, CommandType.Text).Rows) {
                return Int32.Parse(row[0].ToString());
            }
            return -1;
        }

        public bool InsertarNuevaPersona(PersonaModel obj) {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            string sql = "INSERT INTO PERSONA (NOMBRE_1, NOMBRE_2, APELLIDO_1, APELLIDO_2, T_DOCUMENTO, N_DOCUMENTO,";
            sql = sql + " CELULAR, CORREO, REGISTRO, FK_PROFESION) VALUES";
            sql = sql + "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}');";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.Nombre_1, obj.Nombre_2, obj.Apellido_1, obj.Apellido_2, obj.T_documento
                    , obj.N_documento, obj.Telefono, obj.Correo, fecha,
                    (obj.Profesion + ""));
            return con.RealizarTransaccion(ar);
        }
    }
}
