using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class RolModel {
        public string pk_rol;
        public string nombre;

        private Conexion con = new Conexion();

        public List<string> consultarRoles(RolModel obj) {
            List<string> lista = new List<string>();
            string sql = "SELECT rol_nombre FROM ROL WHERE pk_rol<> 1;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            foreach (DataRow row in data.Rows) {
                lista.Add(row[0].ToString());
            }
            return lista;
        }

        public string ConsultarPk(string obj) {
            string sql = "SELECT pk_rol FROM rol where rol.ROL_NOMBRE='"+obj+"';";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["pk_rol"].ToString();
        }

        public bool InsertarRol(string cad) {
            string sql = "INSERT INTO rol (ROL_NOMBRE) VALUES ('{0}');";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, cad);
            return con.RealizarTransaccion(ar);
        }

        public List<string> ConsultarPermisos() {
            List<string> lista = new List<string>();
            string sql = @"SELECT menu_nombre, sub_menu_nombre FROM rol r 
                            inner join menu_usuario mu ON mu.FK_ROL = r.PK_ROL
                            inner join sub_menu sm ON mu.FK_SUB_MENU = sm.PK_SUB_MENU
                            inner join menu m ON sm.FK_MENU = m.PK_MENU;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            foreach (DataRow row in data.Rows) {
                lista.Add(row[0].ToString() + " - " + row[1].ToString());
            }
            return lista;
        }

    }
}