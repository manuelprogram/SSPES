using MySql.Data.MySqlClient;
using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.Models//push de prueba
{
    public class CuentaModel {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public char Estado { get; set; }
        public int FK_PERSONA { get; set; }

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
            string sql = "INSERT INTO CUENTA (USUARIO, PASSWORD, ESTADO, FK_PERSONA) VALUES ('{0}','{1}', 'A', '{2}');";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.Usuario, obj.Password, obj.FK_PERSONA.ToString());
            return con.RealizarTransaccion(ar);
        }


        public DataTable consultarMenu(string idCuenta) {
            string sql = @"SELECT
                        *
                        FROM roles__usuarios rous
                        INNER JOIN rol ro ON rous.FK_CUENTA = ";
            sql += idCuenta + @" AND rous.FK_ROL = ro.PK_ROL AND rous.ESTADO = 'A'
                        INNER JOIN menu_usuario meus ON meus.FK_ROL = ro.PK_ROL AND meus.ESTADO_MENU = 'A'
                        INNER JOIN subopcion_menu sume ON meus.FK_SUBOPCION_MENU = sume.PK_SUBOPCION_MENU
                        INNER JOIN opcion_menu opme ON sume.FK_OPCION_MENU = opme.PK_OPCION_MENU
                        ORDER BY opme.NOMBRE_OPCION; ";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}
