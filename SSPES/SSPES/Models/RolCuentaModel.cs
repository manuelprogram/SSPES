using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class RolCuentaModel {
        public string fk_cuenta;
        public string fk_rol;
        Conexion con = new Conexion();

        public bool InsertarRolCuenta(RolCuentaModel obj) {
            Console.WriteLine("cuenta: "+obj.fk_cuenta+" rol "+obj.fk_rol);
            string sql = "INSERT INTO rol_cuenta values ('"+obj.fk_cuenta+"','"+obj.fk_rol+"','A')";
            string[] ar = new string[1];
            ar[0] = sql;
            return con.RealizarTransaccion(ar);
        }
    }
}