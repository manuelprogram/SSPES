using SSPES.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Home {
    public partial class PaginaMaestra : System.Web.UI.MasterPage {

        public DataTable dtMenu = new DataTable();
        public DataRow drMenu;

        CuentaController cuenta = new CuentaController();

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["PK_CUENTA"]==null) {
                Response.Redirect("../../Login.aspx");
            } else {
                if (!this.IsPostBack) {
                    Response.Write("<script> alert('"+Session["Id_Session"]+"'); </script>");
                    this.CargarMenu(Session["PK_CUENTA"].ToString());
                }
            }
        }

        public void CargarMenu(string idCuenta) {
            dtMenu = cuenta.consultarMenu(idCuenta);
            if(dtMenu.Rows.Count>0) {
                drMenu = dtMenu.Rows[0];
            }
        }
    }
}