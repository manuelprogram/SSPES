using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.IO;
using System.Data;

namespace SSPES.Views.Proyectos {
    public partial class RegistrarProyecto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public bool validarLetrasYNumeros(String h) {
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^. ^:]");
            return !reg.IsMatch(h);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (!validarLetrasYNumeros(nombreProyecto.Value.ToString()) || nombreProyecto.Value.Length < 3) {
                Response.Write("<script> alert('Nombre de proyecto no valido'); </script>");
                return;
            }
            if (!validarLetrasYNumeros(descripcionProyecto.Value.ToString())) {
                Response.Write("<script> alert('Descripcion no valida'); </script>");
                return;
            }

            string[] fecha = fechaInicio.Value.ToString().Split(new Char[] { '-' }); //año mes dia
            string[] fecha2 = fechaFin.Value.ToString().Split(new Char[] { '-' }); //año mes dia
            DateTime d = new DateTime(Int32.Parse(fecha[0]), Int32.Parse(fecha[1]), Int32.Parse(fecha[2]));
            DateTime dfin = new DateTime(Int32.Parse(fecha2[0]), Int32.Parse(fecha2[1]), Int32.Parse(fecha2[2]));
            DateTime ant = new DateTime(DateTime.Now.Year - 15, DateTime.Now.Month, DateTime.Now.Day);
            DateTime sig = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
            if (d.CompareTo(sig) > 0 || d.CompareTo(ant) < 0 || d.CompareTo(dfin) > 0) {
                Response.Write("<script> alert('error en la fecha'); </script>");
                return;
            }

            ProyectoController p;
            if (archivo.HasFile) {
                p = new ProyectoController(nombreProyecto.Value.ToString(), 
                    descripcionProyecto.Value.ToString(), d, dfin, archivo.PostedFile, Session["PK_CUENTA"].ToString(), 10);
            }else {
                p = new ProyectoController(nombreProyecto.Value.ToString(),
                    descripcionProyecto.Value.ToString(), d, dfin, null, Session["PK_CUENTA"].ToString(), 10);
            }

            if (p.insertarProyecto()) {
                Response.Write("<script> alert('exitoso'); </script>");
                Response.Redirect("../Home/Principal.spx");
            }else {
                Response.Write("<script> alert('Error al crear proyecto'); </script>");
            }
        }
    }
}
