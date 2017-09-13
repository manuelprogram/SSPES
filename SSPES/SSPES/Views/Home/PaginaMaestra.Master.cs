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
        public string aux="";

        CuentaController cuenta = new CuentaController();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.CargarMenu("3");
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