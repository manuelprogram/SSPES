using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Text.RegularExpressions;
using System.Data;

namespace SSPES.Views.Proyectos {
    public partial class AdministrarProyecto : System.Web.UI.Page {

        private DataTable dtProyectos, dtVariables, dtIntegrantes, dtroles;
        public string msj;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
        }

        protected void visualizar_Click(object sender, EventArgs e) {//redireccionar a visualizar
            Response.Redirect("VisualizarProyecto.aspx");
        }

        //Seleccionar proyectos

        public void cargarProyectos() {
            radio.Items.Clear();
            proyecto.Items.Clear();
            rolProyectos.Items.Clear();

            ProyectoController obj2 = new ProyectoController();
            dtProyectos = obj2.consultarProyectosDirector(Session["PK_CUENTA"].ToString());
            for (int i = 0; i < dtProyectos.Rows.Count; i++) {
                proyecto.Items.Add(dtProyectos.Rows[i]["NOMBRE"].ToString());
            }
            Session["datos_dtProyecto"] = dtProyectos;
        }

        protected void Button_Click(object sender, EventArgs e) {
            dtProyectos = (DataTable)Session["datos_dtProyecto"];//Proyecto seleccionado
            if (dtProyectos == null) return;
            int index = proyecto.SelectedIndex;
            if (index < 0 || index >= dtProyectos.Rows.Count) {
                return;
            }
            string pk_pro = dtProyectos.Rows[index]["PK_PROYECTO"].ToString();
            Session["pk_pro"] = pk_pro;
            nombreProyecto.Text = proyecto.SelectedItem.ToString();
            texto.Text = dtProyectos.Rows[index]["DESCRIPCION"].ToString();
            cargarVariables(pk_pro);
            llenarUsuarios(pk_pro);
            llenarRoles();
        }

        //modal creacion de variables

        protected void llamarModalVariable_Click(object sender, EventArgs e) {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CrearVariableModal();", true);
        }

        private bool validar(string h) {
            if (h.Length < 3 || h.Length > 50 || !validarLetrasYNumeros(h)) {
                return false;
            }
            return true;
        }

        protected void CrearVariable_Click(object sender, EventArgs e) {
            if (!validar(nombreVariable.Value.ToString()) || !validar(descripcionNuevaVariable.Value.ToString())) {
                msj = "Valide los campos";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            VariableController obj = new VariableController(nombreVariable.Value.ToString(),
                descripcionNuevaVariable.Value.ToString(), tDato.Value);
            if (obj.Registrar()) {
                msj = "Exitoso";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                if (Session["pk_pro"] != null) cargarVariables(Session["pk_pro"].ToString());
            } else {
                msj = "Error al registrar";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
            }
        }

        //asignacion de variables

        public void cargarVariables(string pk_pro) {
            radio.Items.Clear();
            VariableController obj = new VariableController();
            dtVariables = obj.consulatarNombreVariablesDisponibles(pk_pro);
            for (int i = 0; i < dtVariables.Rows.Count; i++) {
                radio.Items.Add(dtVariables.Rows[i]["NOMBRE_VARIABLE"].ToString());
            }
            Session["datos_dtVariables"] = dtVariables;
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            int pk_pro;
            try {
                VariableController obj = new VariableController();
                int con = 0, activos = 0;
                for (int i = 0; i < radio.Items.Count; i++) {
                    if (radio.Items[i].Selected) {
                        activos++;
                        pk_pro = Int32.Parse(Session["pk_pro"].ToString());
                        dtProyectos = (DataTable)Session["datos_dtProyecto"];
                        dtVariables = (DataTable)Session["datos_dtVariables"];
                        int pk_var = Int32.Parse(dtVariables.Rows[i]["idVARIABLE"].ToString());

                        if (!obj.asignarVariable(pk_pro, pk_var)) {
                            con++;
                        }
                    }
                }
                if (activos == 0) {
                    msj = "Seleccione al menos una variables";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                    return;
                }
                if (con == 0) {
                    msj = "Exitoso";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                } else {
                    msj = "Error al asignar alguno(s)";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                }
                cargarVariables(Session["pk_pro"].ToString());
            } catch (Exception) {
                Response.Write("<script> alert('Error inesperado'); </script>");
                radio.Items.Clear();
            }
        }

        //Asignacion integrantes

        public void llenarUsuarios(string pk_pro) {
            users.Items.Clear();
            CuentaController cc = new CuentaController();
            dtIntegrantes = cc.consultarUsuariosDisponiblesProyecto(pk_pro);
            Session["dtIntegrantes"] = dtIntegrantes;
            foreach (DataRow dr in dtIntegrantes.Rows) {
                users.Items.Add(dr["NOMBRE_1"].ToString() + "  " + dr["APELLIDO_1"].ToString());
            }
        }

        protected void llenarRoles() {
            rolProyectos.Items.Clear();
            RolProyectoController rpc = new RolProyectoController();
            dtroles = rpc.consultarRoles();
            Session["dtRoles"] = dtroles;
            foreach (DataRow dr in dtroles.Rows) {
                rolProyectos.Items.Add(dr["NOMBRE_ROL_PROYECTO"].ToString());
            }
        }

        protected void boton_Click(object sender, EventArgs e) {
            if (rolProyectos.Items.Count == 0) {
                msj = "Seleccione un proyecto";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            RolProyectoController rpc = new RolProyectoController();
            dtroles = (DataTable)Session["dtRoles"];
            dtProyectos = (DataTable)Session["dtProyectos"];
            dtIntegrantes = (DataTable)Session["dtIntegrantes"];
            ProyectoController pc = new ProyectoController();
            int con = 0, activos = 0;

            for (int i = 0; i < users.Items.Count; i++) {
                if (users.Items[i].Selected) {
                    activos++;
                    if (!pc.agregarIntegrante(dtIntegrantes.Rows[i]["PK_CUENTA"].ToString(),
                        Session["pk_pro"].ToString(),
                        dtroles.Rows[rolProyectos.SelectedIndex]["PK_ROL_PROYECTO"].ToString())) con++;
                }
            }
            if (activos == 0) {
                msj = "Error, seleccione integrantes";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }
            if (con == 0) {
                msj = "Exitoso";
            } else {
                msj = "Error al registrar alguno(s)";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
            llenarUsuarios(Session["pk_pro"].ToString());
        }

        //Crear nuevo proyecto

        public bool validarLetrasYNumeros(String h) {
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^. ^:]");
            return !reg.IsMatch(h);
        }

        protected void registrarProyecto_Click(object sender, EventArgs e) {
            if (!validarLetrasYNumeros(nombreProyectoNuevo.Value.ToString()) || nombreProyectoNuevo.Value.Length < 3) {
                msj = "Nombre de proyecto no valido";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }
            if (!validarLetrasYNumeros(descripcionProyecto.Value.ToString())) {
                msj = "Descricpcion no valida";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            string[] fecha = fechaInicio.Value.ToString().Split(new Char[] { '-' }); //año mes dia
            string[] fecha2 = fechaFin.Value.ToString().Split(new Char[] { '-' }); //año mes dia
            DateTime d, dfin;
            try {
                d = new DateTime(Int32.Parse(fecha[0]), Int32.Parse(fecha[1]), Int32.Parse(fecha[2]));
                dfin = new DateTime(Int32.Parse(fecha2[0]), Int32.Parse(fecha2[1]), Int32.Parse(fecha2[2]));
                DateTime ant = new DateTime(DateTime.Now.Year - 15, DateTime.Now.Month, DateTime.Now.Day);
                DateTime sig = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
                if (d.CompareTo(sig) > 0 || d.CompareTo(ant) < 0 || d.CompareTo(dfin) > 0) {
                    msj = "Error en las fechas";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                    return;
                }
            } catch (Exception) {
                msj = "Error en las fechas";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            ProyectoController p;
            if (archivo.HasFile) {
                p = new ProyectoController(nombreProyectoNuevo.Value.ToString(),
                    descripcionProyecto.Value.ToString(), d, dfin, archivo.PostedFile, Session["PK_CUENTA"].ToString());
            } else {
                p = new ProyectoController(nombreProyectoNuevo.Value.ToString(),
                    descripcionProyecto.Value.ToString(), d, dfin, null, Session["PK_CUENTA"].ToString());
            }

            if (p.insertarProyecto()) {
                msj = "Exitoso";
            } else {
                msj = "Error al crear proyecto";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
        }
    }
}
