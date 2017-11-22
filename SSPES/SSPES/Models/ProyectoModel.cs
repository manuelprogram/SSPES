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
        public int cantidad_muestras { get; set; }
        private string f, f2;

        public ProyectoModel(string a, string b, DateTime c, DateTime c2, HttpPostedFile d, string e, int f) {
            nombre = a;
            descripcion = b;
            fecha = c;
            fechaFin = c2;
            archivo = d;
            fkCuenta = e;
            cantidad_muestras = f;
        }

        public ProyectoModel() {
        }

        public DataTable consultarNombreProyectos() {
            string sql = "SELECT NOMBRE, PK_PROYECTO FROM proyecto WHERE ESTADO = 'A' ORDER BY NOMBRE;";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data;
        }
        public string CantidadProyectos(string pk_user) {
            string sql = "select count(*) as numero from proyecto where fk_cuenta_proyecto='" + pk_user + "';";
            return con.EjecutarConsulta(sql, CommandType.Text).Rows[0]["numero"].ToString();
        }

        public bool registrarProyecto() {
            string[] sql = new string[1];
            f = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            f2 = fechaFin.Year + "-" + fechaFin.Month + "-" + fechaFin.Day;

            if (archivo == null) {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, FECHA_FIN, ESTADO, FK_CUENTA_PROYECTO, CANTIDAD_MUESTRAS) VALUES(";
                sql[0] += "'" + nombre + "', '" + descripcion + "', '" + f + "', '" + f2 + "', 'A', '" + fkCuenta + "', '" + cantidad_muestras + "' );";
                return con.RealizarTransaccion(sql);
            } else {
                sql[0] = "INSERT INTO proyecto (NOMBRE, DESCRIPCION, FECHA_INICIO, FECHA_FIN, ESTADO, ARCHIVO, NOMBREARCHIVO, FK_CUENTA_PROYECTO, ";
                sql[0] += "CANTIDAD_MUESTRAS) VALUES( '" + nombre + "', '" + descripcion + "', '" + f + "', '" + f2 + "' , 'A', @doc, ";
                sql[0] += " '" + archivo.FileName + "', '" + fkCuenta + "', '" + cantidad_muestras + "');";
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

        public DataTable consultarProyectosDirector(string pk_dir) {//los proyectos de un director
            string sql = "SELECT PK_PROYECTO, NOMBRE, DESCRIPCION, FECHA_INICIO FROM proyecto WHERE ESTADO = 'A' ";
            sql += "AND FK_CUENTA_PROYECTO = '" + pk_dir + "' ORDER BY NOMBRE;";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultarProyectosPersona(string pk_dir) {//sus proyectos creados y a los que esta como integrante
            string sql = "SELECT PK_PROYECTO, NOMBRE, DESCRIPCION, FECHA_INICIO FROM proyecto WHERE ESTADO = 'A' ";
            sql += "AND(FK_CUENTA_PROYECTO = '" + pk_dir + "' OR EXISTS(SELECT * FROM integrante_proyecto ";
            sql += "WHERE integrante_proyecto.FK_PROYECTO = PK_PROYECTO AND integrante_proyecto.FK_CUENTA = '" + pk_dir + "')";
            sql += ") ORDER BY NOMBRE; ";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool agregarIntegrante(string pk_cuenta, string pk_pro) {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            string[] sql = new string[1];
            sql[0] = @"INSERT INTO integrante_proyecto (ESTADO, REGISTRO, FK_CUENTA, FK_PROYECTO) 
                    VALUES('A', '" + fecha + "', '" + pk_cuenta + "', '" + pk_pro + "');";
            return con.RealizarTransaccion(sql);
        }

        public bool eliminarIntegrante(string pk_cuenta, string pk_pro) {
            string[] sql = new string[1];
            sql[0] = @"DELETE FROM integrante_proyecto WHERE FK_CUENTA = '" + pk_cuenta + 
                @"' AND FK_PROYECTO = '" + pk_pro + "';";
            return con.RealizarTransaccion(sql);
        }

        public string getPkIntegranteProyecto(string pk_cuenta, string pk_pro) {
            string sql = "SELECT PK_INTEGRANTE_PROYECTO FROM integrante_proyecto WHERE FK_PROYECTO = ";
            sql += "'" + pk_pro + "' AND FK_CUENTA = '" + pk_cuenta + "';";

            try {
                return con.EjecutarConsulta(sql, CommandType.Text).Rows[0][0].ToString();
            } catch (Exception) {
                return null;
            }
         }

        public string getPk() {
            string sql = @"SELECT PK_PROYECTO FROM proyecto WHERE NOMBRE = '" + nombre + @"' AND ESTADO = 'A' 
                AND DESCRIPCION = '" + descripcion + @"' AND FK_CUENTA_PROYECTO = '" + fkCuenta + @"' AND 
                CANTIDAD_MUESTRAS = '" + cantidad_muestras + @"' AND FECHA_INICIO = '" + f + @"'
                AND FECHA_FIN = '" + f2 + @"' ORDER BY PK_PROYECTO; ";
            DataTable dt = con.EjecutarConsulta(sql, CommandType.Text);
            return dt.Rows[dt.Rows.Count - 1]["PK_PROYECTO"].ToString();
        }
    }
}
