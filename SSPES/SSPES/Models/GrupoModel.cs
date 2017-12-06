using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;



namespace SSPES.Models {
    public class GrupoModel {

        string siglas;
        string nombre;
        string descripcion;
        string institucion;
        private Conexion con;

        public GrupoModel() {
            con = new Conexion();
        }

        public DataTable ConsultarGrupo() {
            string sql = "SELECT * FROM grupo;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool RealizarUpdate(string siglas, string nombre, string descripcion, string institucion) {
            string[] sql = new string[1];
            sql[0] = "UPDATE grupo SET SIGLAS='" + siglas + "', NOMBRE = '" + nombre + "', DESCRIPCION = '" + descripcion + "', INSTITUCION ='" + institucion + "' WHERE PK_GRUPO = 1;";
            return con.RealizarTransaccion(sql);
        }
    }
}