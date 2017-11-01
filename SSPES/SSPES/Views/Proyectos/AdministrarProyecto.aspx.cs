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
        public string msj = "";
        private Dictionary<string, string> mapa, mapa2;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarProyectos();
            }
            mapa = new Dictionary<string, string>();
            mapa2 = new Dictionary<string, string>();
        }

        protected void visualizar_Click(object sender, EventArgs e) {//redireccionar a visualizar
            Response.Redirect("VisualizarProyecto.aspx");
        }
        
        protected void redireccionUsuarios_Click(object sender, EventArgs e) {//redireccionar a crear usuario
            Response.Redirect("../Usuarios/RegistrarUsuario.aspx");
        }

        //Seleccionar proyectos

        public void cargarProyectos() {
            listaVariablesDisponibles.Items.Clear();
            listaVariablesSeleccionadas.Items.Clear();
            listaVariablesActuales.Items.Clear();
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
                if (Session["pk_pro"] != null && proyecto.SelectedIndex >= 0) cargarVariables(Session["pk_pro"].ToString());
            } else {
                msj = "Error al registrar";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
            }
        }

        //asignacion de variables

        public void cargarVariables(string pk_pro) {
            listaVariablesDisponibles.Items.Clear();
            listaVariablesSeleccionadas.Items.Clear();
            listaVariablesActuales.Items.Clear();
            mapa.Clear();
            VariableController obj = new VariableController();
            dtVariables = obj.consultarEstadoVariablesProyecto(pk_pro);
            string str, str2;
            foreach (DataRow dr in dtVariables.Rows) {
                str = dr["EXISTE"].ToString();
                str2 = dr["NOMBRE_VARIABLE"].ToString();
                if (str.Equals("Si")) {
                    listaVariablesActuales.Items.Add(str2);
                } else {
                    listaVariablesDisponibles.Items.Add(str2);
                    mapa.Add(str2, dr["idVARIABLE"].ToString());
                }
            }
            Session["mapa"] = mapa;
            Session["datos_dtVariables"] = dtVariables;
        }

        //evento de cambiar variables
        protected void boton1_Click(object sender, EventArgs e) {
            while (listaVariablesDisponibles.GetSelectedIndices().Length > 0) {
                listaVariablesSeleccionadas.Items.Add(listaVariablesDisponibles.SelectedItem);
                listaVariablesDisponibles.Items.Remove(listaVariablesDisponibles.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }

        protected void noAsignar_Click(object sender, EventArgs e) {
            while (listaVariablesSeleccionadas.GetSelectedIndices().Length > 0) {
                listaVariablesDisponibles.Items.Add(listaVariablesSeleccionadas.SelectedItem);
                listaVariablesSeleccionadas.Items.Remove(listaVariablesSeleccionadas.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            try {
                VariableController obj = new VariableController();
                int con = 0, activos = 0;
                mapa = (Dictionary<string, string>)Session["mapa"];
                for (int i = 0; i < listaVariablesSeleccionadas.Items.Count; i++) {
                    activos++;
                    if (!obj.asignarVariable(Session["pk_pro"].ToString(), mapa[listaVariablesSeleccionadas.Items[i].ToString()])) {
                        con++;
                    }
                }
                if (activos == 0) {
                    msj = "Seleccione al menos una variable";
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
                cargarVariables(Session["pk_pro"].ToString());
            }
        }

        //Asignacion integrantes

        protected void moverUser1_Click(object sender, EventArgs e) {
            while (ListUsuariosDisponibles.GetSelectedIndices().Length > 0) {
                ListUsuariosSeleccionados.Items.Add(ListUsuariosDisponibles.SelectedItem);
                ListUsuariosDisponibles.Items.Remove(ListUsuariosDisponibles.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarUsuarios();", true);
        }

        protected void moverUser2_Click(object sender, EventArgs e) {
            while (ListUsuariosSeleccionados.GetSelectedIndices().Length > 0) {
                ListUsuariosDisponibles.Items.Add(ListUsuariosSeleccionados.SelectedItem);
                ListUsuariosSeleccionados.Items.Remove(ListUsuariosSeleccionados.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarUsuarios();", true);
        }

        public void llenarUsuarios(string pk_pro) {
            ListUsuariosAsignados.Items.Clear();
            ListUsuariosDisponibles.Items.Clear();
            ListUsuariosSeleccionados.Items.Clear();
            mapa2.Clear();
            CuentaController cc = new CuentaController();
            dtIntegrantes = cc.consultarUsuariosProyecto(pk_pro);
            Session["dtIntegrantes"] = dtIntegrantes;
            string str;
            foreach (DataRow dr in dtIntegrantes.Rows) {
                str = dr["NOMBRE_1"].ToString() + "  " + dr["APELLIDO_1"].ToString();
                if (dr["EXISTE"].ToString().Equals("Si")) {
                    ListUsuariosAsignados.Items.Add(str);
                } else {
                    ListUsuariosDisponibles.Items.Add(str);
                    mapa2.Add(str, dr["PK_CUENTA"].ToString());
                }
            }
            Session["mapa2"] = mapa2;
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

        protected void AsignarUsuraios_Click(object sender, EventArgs e) {
            if (rolProyectos.Items.Count == 0) {
                msj = "Seleccione un proyecto";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            dtroles = (DataTable)Session["dtRoles"];
            dtIntegrantes = (DataTable)Session["dtIntegrantes"];
            ProyectoController pc = new ProyectoController();
            mapa2 = (Dictionary<string, string>) Session["mapa2"];
            int con = 0, activos = 0;

            for (int i = 0; i < ListUsuariosSeleccionados.Items.Count; i++) {
                activos++;
                if (!pc.agregarIntegrante(mapa2[ListUsuariosSeleccionados.Items[i].ToString()],
                    Session["pk_pro"].ToString(),
                    dtroles.Rows[rolProyectos.SelectedIndex]["PK_ROL_PROYECTO"].ToString())) con++;
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
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^. ^: ^,]");
            return !reg.IsMatch(h);
        }

        protected void registrarProyecto_Click(object sender, EventArgs e) {
            if (!validarLetrasYNumeros(nombreProyectoNuevo.Value.ToString()) || nombreProyectoNuevo.Value.Length < 3) {
                msj = "Nombre de proyecto no valido";
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
