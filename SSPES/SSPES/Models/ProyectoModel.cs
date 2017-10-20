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
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaFin { get; set; }
        public HttpPostedFile archivo { get; set; }
        public string fkCuenta { get; set; }

        public ProyectoModel(string a, string b, DateTime c, DateTime c2, HttpPostedFile d, string e) {
            nombre = a;
            descripcion = b;
            fecha = c;
            fechaFin = c2;
            archivo = d;
            fkCuenta = e;
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
            string f2 = fechaFin.Year + "-" + fechaFin.Month + "-" + fechaFin.Day;

            if (archivo == null) {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, FECHA_FIN, ESTADO, FK_CUENTA_PROYECTO) VALUES(";
                sql[0] += "'" + nombre + "', '" + descripcion + "', '" + f + "', '" + f2 + "', 'A', '" + fkCuenta + "');";
                return con.RealizarTransaccion(sql);
            } else {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, FECHA_FIN, ESTADO, ARCHIVO, NOMBREARCHIVO, FK_CUENTA_PROYECTO) ";
                sql[0] += " VALUES( '" + nombre + "', '" + descripcion + "', '" + f + "', '" + f2 + "' , 'A', @doc, ";
                sql[0] += " '" + archivo.FileName + "', '" + fkCuenta + "');";
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
            string sql = "SELECT PK_PROYECTO, NOMBRE, DESCRIPCION, FECHA_INICIO FROM proyecto WHERE ESTADO = 'A' ";
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
