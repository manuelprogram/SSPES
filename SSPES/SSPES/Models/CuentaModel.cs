using MySql.Data.MySqlClient;
using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models//push de prueba
{
    public class CuentaModel
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public char Estado { get; set;  }
        //public string k { get; set; }

        Conexion con = new Conexion();

        public bool ValidarCuentaExistente(CuentaModel obj) {
            string sql = "SELECT USUARIO FROM CUENTA where(USUARIO='" + obj.Usuario + "');";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows.Count > 0;
        }

        public bool ConsultarCuenta(CuentaModel obj) {
            string sql = "SELECT USUARIO FROM CUENTA where(USUARIO='" + obj.Usuario + "' AND PASSWORD= '" + obj.Password + "' AND ESTADO= 'A');";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows.Count > 0;
        }

        public bool insertarNuevaCuenta(CuentaModel obj) {//PASSWORD();
            string sql = "INSERT INTO CUENTA (USER, PASSWORD, ESTADO) VALUES ('{0}','{1}');";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.Usuario, obj.Password);
            return con.RealizarTransaccion(ar);
        }
    }
}
