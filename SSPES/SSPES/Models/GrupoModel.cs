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
    }
}