using System;
using System.Data;
using SSPES.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Grupo {
    public partial class AdminGrupo : System.Web.UI.Page {
        private DataRow dr;
        private DataTable dt;
        GrupoController grupos = new GrupoController();
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!Session["ROL"].ToString().Equals("superadmin")) {
                Response.Redirect("../Home/Principal.aspx");
            }
            dt = grupos.ConsultarGrupo();
            dr = dt.Rows[0];
            if (nombre.Value.ToString()=="") {
                sigla.Value = dr["SIGLAS"].ToString();
                nombre.Value = dr["NOMBRE"].ToString();
                descripcion.Value = dr["DESCRIPCION"].ToString();
                institucion.Value = dr["institucion"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (grupos.ActualizarGrupo(sigla.Value,nombre.Value,descripcion.Value,institucion.Value)) {
                Response.Write("<script> alert('Actualización Exitosa'); </script>");
            } else {
                Response.Write("<script> alert('Error Actulización'); </script>");
            }
        }
    }
}