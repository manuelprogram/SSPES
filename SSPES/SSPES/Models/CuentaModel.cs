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
        private Conexion con = new Conexion();

        public CuentaModel() {
        }

        public CuentaModel(string a, string b, char c, int d) {
            Usuario = a;
            Password = b;
            Estado = c;
            FK_PERSONA = d;
        }

        public bool ValidarCuentaExistente(CuentaModel obj) {
            string sql = "SELECT USUARIO FROM CUENTA where(USUARIO='" + obj.Usuario + "');";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows.Count > 0;
        }

        public DataTable ConsultarCuenta(CuentaModel obj) {
            string sql = "SELECT PK_CUENTA FROM CUENTA where(USUARIO='" + obj.Usuario + "' AND PASSWORD= '" + obj.Password + "' AND ESTADO= 'A');";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool insertarNuevaCuenta(CuentaModel obj) {//PASSWORD();
            string sql = "INSERT INTO CUENTA (USUARIO, PASSWORD, ESTADO, FK_PERSONA,FK_GRUPO) VALUES ('{0}','{1}', 'A', '{2}',1);";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.Usuario, obj.Password, obj.FK_PERSONA.ToString());
            return con.RealizarTransaccion(ar);
        }
        public string GetFk_cuenta(string obj) {//PASSWORD();
            string sql = "SELECT PK_CUENTA FROM CUENTA WHERE USUARIO='" + obj + "';";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows[0]["PK_CUENTA"].ToString();
        }

        public DataTable consultarMenu(string idCuenta) {
            string sql = @"SELECT  *
                        FROM rol_cuenta rous
                       INNER JOIN rol ro ON rous.FK_CUENTA = ";
            sql += idCuenta + @" AND rous.FK_ROL = ro.PK_ROL AND rous.ESTADO = 'A'
                        INNER JOIN menu_usuario meus ON meus.FK_ROL = ro.PK_ROL AND meus.ESTADO_MENU = 'A'
                        INNER JOIN sub_menu sume ON meus.FK_SUB_MENU = sume.PK_SUB_MENU
                        INNER JOIN menu opme ON sume.FK_MENU = opme.PK_MENU
                        ORDER BY opme.MENU_NOMBRE; ";

            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public int cosultarPKPersona(int pkCuenta) {
            string sql = "SELECT FK_PERSONA FROM CUENTA where(PK_CUENTA = '" + pkCuenta + "' AND ESTADO= 'A');";
            return Int32.Parse(con.EjecutarConsulta(sql, CommandType.Text).Rows[0]["FK_PERSONA"].ToString());
        }

        public string CantidadCuentas() {
            string sql = "select count(*) as numero from cuenta;";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows[0]["numero"].ToString();
        }

        public DataTable consultarUsuariosProyecto(string pk_pro) {
            string sql = @"SELECT PK_CUENTA, FK_PERSONA, NOMBRE_1, APELLIDO_1, 
                IF (EXISTS(SELECT * FROM integrante_proyecto WHERE cuenta.PK_CUENTA = integrante_proyecto.FK_CUENTA 
                AND integrante_proyecto.FK_PROYECTO = '" + pk_pro + @"'), 'Si', 'No') AS 'Existe'
                FROM cuenta, persona WHERE persona.PK_PERSONA = cuenta.FK_PERSONA ORDER BY NOMBRE_1;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}
