using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Cuenta {
    public partial class Cuentas : System.Web.UI.Page {
        PersonaController persona = new PersonaController();
        GrupoController grupo = new GrupoController();
        private DataRow dr;
        private DataTable dt;
        DataRow datos;
        public string name;
        string pk_person;
        
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            dt = grupo.ConsultarGrupo();
            dr = dt.Rows[0];
            lsigla.Text = dr["SIGLAS"].ToString();
            lnombre.Text= dr["NOMBRE"].ToString();
            ldescripcion.Text = dr["DESCRIPCION"].ToString();
            linstitucion.Text = dr["institucion"].ToString();

            if (udnumero.Value.ToString()=="") {
                pk_person = Session["FK_PERSONA"].ToString();
                datos = persona.ConsultarUpdate(pk_person);
                string tipe = datos["tipo"].ToString();
                if (tipe.Equals("CC")) {
                    udtipodoc.SelectedIndex = 1;
                } else if (tipe.Equals("TI")) {
                    udtipodoc.SelectedIndex = 0;
                } else {
                    udtipodoc.SelectedIndex = 2;
                }
                udcelular.Value = datos["celular"].ToString();
                udemail.Value = datos["correo"].ToString();
                udnumero.Value = datos["numero"].ToString();
                name = Session["NombreUsuario"].ToString();
            }
        }

        public string select() {
            switch (udtipodoc.SelectedIndex) {
                case 0:
                    return "TI";
                case 1:
                    return "CC";
                default:
                    return "CE";

            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (persona.RealizarUpdate(select(), udnumero.Value, udcelular.Value, udemail.Value, Session["FK_PERSONA"].ToString())) {
                Response.Write("<script> alert('Actualizacion Exitosa'); </script>");
            } else {
                Response.Write("<script> alert('ERROR ACTULIZACIÓN'); </script>");
            }
        }
    }
}