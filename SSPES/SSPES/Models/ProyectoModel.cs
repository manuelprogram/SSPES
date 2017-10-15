using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Models {
    public class ProyectoModel {

        private Conexion con = new Conexion();
        protected string nombre { get; set; }
        protected string descripcion { get; set; }
        protected DateTime fecha { get; set; }
        protected HttpPostedFile archivo { get; set; }

        public ProyectoModel(string a, string b, DateTime c, HttpPostedFile d) {
            nombre = a;
            descripcion = b;
            fecha = c;
            archivo = d;
        }

        public ProyectoModel() {
        }

        public DataTable consultarNombreProyectos() {
            string sql = "SELECT NOMBRE, PK_PROYECTO FROM proyecto WHERE ESTADO = 'A' ORDER BY NOMBRE;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data;
        }

        public bool registrarProyecto() {
            string[] sql = new string[1];
            string f = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;

            if (archivo == null) {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, ESTADO) VALUES(";
                sql[0] += "'" + nombre + "', '" + descripcion + "', '" + f + "', 'A');";
                return con.RealizarTransaccion(sql);
            } else {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, ESTADO, ARCHIVO, NOMBREARCHIVO) VALUES(";
                sql[0] += "'" + nombre + "', '" + descripcion + "', '" + f + "', 'A', @doc, '" + archivo.FileName + "');";
                return con.GuardarArchivo(sql[0], archivo);
            }
        }

        public DataTable cargarDocumento(int pk) {
            string sql = "SELECT ARCHIVO, NOMBREARCHIVO FROM proyecto WHERE PK_PROYECTO = '" + pk + "' AND ESTADO = 'A';";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultarProyectos() {
            string sql = "SELECT PK_PROYECTO, NOMBRE, DESCRIPCION, FECHA_INICIO FROM proyecto WHERE ESTADO = 'A';";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultarProyectosDirector(string pk_dir) {
            string sql = "SELECT PK_PROYECTO, NOMBRE, DESCRIPCION FROM proyecto WHERE ESTADO = 'A' ";
            sql += "AND FK_CUENTA_PROYECTO = '" + pk_dir + "' ORDER BY NOMBRE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool agregarIntegrante(int pk_cuenta, int pk_pro, int pk_rolpro) {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            string[] sql = new string[1];
            sql[0] = @"INSERT INTO integrante_proyecto (ESTADO, REGISTRO, FK_CUENTA, FK_PROYECTO, FK_ROL_PROYECTO) 
                    VALUES('A', '" + fecha + "', '" + pk_cuenta + "', '" + pk_pro + "', '" + pk_rolpro + "') ;";
            return con.RealizarTransaccion(sql);
        }
    }
}
