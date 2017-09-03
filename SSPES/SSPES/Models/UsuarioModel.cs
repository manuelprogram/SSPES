using MySql.Data.MySqlClient;
using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class UsuarioModel {
        public string user { get; set; }

        public string password { get; set; }

        Conexion con = new Conexion();

        public bool ValidarUsuario(UsuarioModel obj) {
            string sql = "SELECT USER FROM LOGIN where(USER='" + obj.user + "');";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows.Count > 0;
        }

        public bool ConsultarUsuario(UsuarioModel obj) {
            string sql = "SELECT USER FROM LOGIN where(USER='" + obj.user + "' AND PASSWORD=PASSWORD('" + obj.password + "'));";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows.Count > 0;
        }

        public bool insertar(UsuarioModel obj) {
            string sql = "INSERT INTO LOGIN (USER,PASSWORD) VALUES ('{0}',PASSWORD('{1}'));";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.user, obj.password);
            return con.RealizarTransaccion(ar);
        }
    }
}