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

        private DataTable dtProyectos, dtVariables, dtIntegrantes;
        public string msj = "";
        private Dictionary<string, int> mapa = new Dictionary<string, int>();//Para variables, nombre e indice en el dtVariables
        private List<KeyValuePair<string, bool>> listDis = new List<KeyValuePair<string, bool>>();//disponibles
        private List<KeyValuePair<string, bool>> listAsig = new List<KeyValuePair<string, bool>>();//a asignar
        //private List<bool> asignados = new List<bool>();//si ese integrante ya esta 

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["ENTRADA"].ToString().Equals("F")) {
                Response.Redirect("../../Login.aspx");
            }
            if (!Session["ROL"].ToString().Equals("director")) {
                Response.Redirect("../Home/Principal.aspx");
            }
            if (!IsPostBack) {
                cargarProyectos();
            }
            mapa.Clear();
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
            listaVariablesAsignadas.Items.Clear();
            proyecto.Items.Clear();

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

            VariableController obj = new VariableController(nombreVariable.Value.ToString(), tDato.Value,
                descripcionNuevaVariable.Value.ToString());
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
            listaVariablesAsignadas.Items.Clear();
            listaVariablesDisponibles.Enabled = true;
            listaVariablesAsignadas.Enabled = true;
            mapa.Clear();
            VariableController obj = new VariableController();
            dtVariables = obj.consultarEstadoVariablesProyecto(pk_pro);
            string str, str2;
            int con = 0;
            foreach (DataRow dr in dtVariables.Rows) {
                str = dr["EXISTE"].ToString();
                str2 = dr["NOMBRE_VARIABLE"].ToString();
                if (str.Equals("Si")) listaVariablesAsignadas.Items.Add(str2);
                else listaVariablesDisponibles.Items.Add(str2);
                mapa.Add(str2, con++);
            }
            Session["mapa"] = mapa;
            Session["dtVariables"] = dtVariables;

            MuestraController mc = new MuestraController();
            if (!mc.getNumeroMuestras(Session["pk_pro"].ToString()).Equals("0")) {
                listaVariablesDisponibles.Enabled = false;
                listaVariablesAsignadas.Enabled = false;
            }
        }

        //evento de cambiar variables
        protected void boton1_Click(object sender, EventArgs e) {
            while (listaVariablesDisponibles.GetSelectedIndices().Length > 0) {
                listaVariablesAsignadas.Items.Add(listaVariablesDisponibles.SelectedItem);
                listaVariablesDisponibles.Items.Remove(listaVariablesDisponibles.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }

        protected void noAsignar_Click(object sender, EventArgs e) {
            while (listaVariablesAsignadas.GetSelectedIndices().Length > 0) {
                listaVariablesDisponibles.Items.Add(listaVariablesAsignadas.SelectedItem);
                listaVariablesAsignadas.Items.Remove(listaVariablesAsignadas.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarVariables();", true);
        }

        protected void asignarVariable_Click(object sender, EventArgs e) {
            try {
                if (listaVariablesAsignadas.Enabled == false) {
                    Response.Write("<script> alert('Error, Hay muestras registradas'); </script>");
                    return;
                }
                VariableController obj = new VariableController();
                dtVariables = (DataTable)Session["dtVariables"];
                int con = 0, activos = 0;
                mapa = (Dictionary<string, int>)Session["mapa"];
                msj = "Se cambian ";
                DataRow dr;

                for (int i = 0; i < listaVariablesAsignadas.Items.Count; i++) {
                    dr = dtVariables.Rows[mapa[listaVariablesAsignadas.Items[i].ToString()]];
                    if (!dr["EXISTE"].ToString().Equals("Si")) {
                        activos++;
                        if (!obj.asignarVariable(Session["pk_pro"].ToString(), dr["idVARIABLE"].ToString())) con++;
                        else dtVariables.Rows[mapa[listaVariablesAsignadas.Items[i].ToString()]]["EXISTE"] = "Si";
                    }
                }

                for (int i = 0; i < listaVariablesDisponibles.Items.Count; i++) {
                    dr = dtVariables.Rows[mapa[listaVariablesDisponibles.Items[i].ToString()]];
                    if (dr["EXISTE"].ToString().Equals("Si")) {
                        activos++;
                        if (!obj.eliminarVariable(Session["pk_pro"].ToString(), dr["idVARIABLE"].ToString())) con++;
                        else dtVariables.Rows[mapa[listaVariablesDisponibles.Items[i].ToString()]]["EXISTE"] = "No";
                    }
                }

                if (activos == 0) {
                    msj = "Sin cambios";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                    return;
                }
                if (con == 0) {
                    msj += " " + activos;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                } else {
                    msj = "Error al actualizar alguno(s)";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                }

            } catch (Exception) {
                Response.Write("<script> alert('Error inesperado'); </script>");
            }
            cargarVariables(Session["pk_pro"].ToString());
        }

        //Asignacion integrantes

        protected void moverUser1_Click(object sender, EventArgs e) {
            listDis = (List<KeyValuePair<string, bool>>)Session["listDis"];
            listAsig = (List<KeyValuePair<string, bool>>)Session["listAsig"];
            while (ListUsuariosDisponibles.GetSelectedIndices().Length > 0) {
                listAsig.Add(listDis[ListUsuariosDisponibles.SelectedIndex]);
                listDis.RemoveAt(ListUsuariosDisponibles.SelectedIndex);
                ListUsuariosAsignados.Items.Add(ListUsuariosDisponibles.SelectedItem);
                ListUsuariosDisponibles.Items.Remove(ListUsuariosDisponibles.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarUsuarios();", true);
        }

        protected void moverUser2_Click(object sender, EventArgs e) {
            listDis = (List<KeyValuePair<string, bool>>)Session["listDis"];
            listAsig = (List<KeyValuePair<string, bool>>)Session["listAsig"];
            while (ListUsuariosAsignados.GetSelectedIndices().Length > 0) {
                listDis.Add(listAsig[ListUsuariosAsignados.SelectedIndex]);
                listAsig.RemoveAt(ListUsuariosAsignados.SelectedIndex);
                ListUsuariosDisponibles.Items.Add(ListUsuariosAsignados.SelectedItem);
                ListUsuariosAsignados.Items.Remove(ListUsuariosAsignados.SelectedItem);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "panelAsignarUsuarios();", true);
            Session["listDis"] = listDis;
            Session["listAsig"] = listAsig;
        }

        public void llenarUsuarios(string pk_pro) {
            ListUsuariosDisponibles.Items.Clear();
            ListUsuariosAsignados.Items.Clear();
            listDis.Clear();
            listAsig = new List<KeyValuePair<string, bool>>();
            CuentaController cc = new CuentaController();
            dtIntegrantes = cc.consultarUsuariosProyecto(pk_pro);
            Session["dtIntegrantes"] = dtIntegrantes;
            string str;
            foreach (DataRow dr in dtIntegrantes.Rows) {
                str = dr["NOMBRE_1"].ToString() + "  " + dr["APELLIDO_1"].ToString();
                if (dr["EXISTE"].ToString().Equals("Si")) {
                    ListUsuariosAsignados.Items.Add(str);
                    listAsig.Add(new KeyValuePair<string, bool>(dr["PK_CUENTA"].ToString(), true));
                } else {
                    ListUsuariosDisponibles.Items.Add(str);
                    listDis.Add(new KeyValuePair<string, bool>(dr["PK_CUENTA"].ToString(), false));
                }
            }
            Session["listDis"] = listDis;
            Session["listAsig"] = listAsig;
        }

        protected void AsignarUsuraios_Click(object sender, EventArgs e) {
            listAsig = (List<KeyValuePair<string, bool>>)Session["listAsig"];
            listDis = (List<KeyValuePair<string, bool>>)Session["listDis"];
            ProyectoController pc = new ProyectoController();
            int con = 0, activos = 0;

            for (int i = 0; i < listAsig.Count; i++) {
                if (!listAsig[i].Value) {
                    activos++;
                    if (!pc.agregarIntegrante(listAsig[i].Key, Session["pk_pro"].ToString())) con++;
                }
            }

            for (int i = 0; i < listDis.Count; i++) {
                if (listDis[i].Value) {
                    activos++;
                    if (!pc.eliminarIntegrante(listDis[i].Key, Session["pk_pro"].ToString())) con++;
                }
            }

            if (activos == 0) {
                msj = "Sin cambios " + listDis.Count;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }
            if (con == 0) {
                msj = "Exitoso";
            } else {
                msj = "Error al cambiar alguno(s)\nrevise que no tengas muestras registradas";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
            llenarUsuarios(Session["pk_pro"].ToString());
        }

        //Crear nuevo proyecto

        public bool validarLetrasYNumeros(String h) {
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^. ^: ^,]");
            return !reg.IsMatch(h);
        }

        public bool validarNumeros(string h) {
            if (h.Length == 0 || h.Length > 4) return false;
            for (int i = 0; i < h.Length; i++)
                if (h[i] < '0' || h[i] > '9') return false;

            return true;
        }

        protected void registrarProyecto_Click(object sender, EventArgs e) {
            if (!validarLetrasYNumeros(nombreProyectoNuevo.Value.ToString()) || nombreProyectoNuevo.Value.Length < 3) {
                msj = "Nombre de proyecto no valido";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                return;
            }

            if (!validarNumeros(canMuestras.Value)) {
                msj = "Error cantidad de muestras";
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
                    descripcionProyecto.Value.ToString(), d, dfin, archivo.PostedFile, Session["PK_CUENTA"].ToString(),
                    Int32.Parse(canMuestras.Value));
            } else {
                p = new ProyectoController(nombreProyectoNuevo.Value.ToString(),
                    descripcionProyecto.Value.ToString(), d, dfin, null, Session["PK_CUENTA"].ToString(),
                    Int32.Parse(canMuestras.Value));
            }

            if (p.insertarProyecto()) {
                msj = "Exitoso";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                Response.Redirect("AdministrarProyecto.aspx");
            } else {
                msj = "Error al crear proyecto";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
            }
        }
    }
}
