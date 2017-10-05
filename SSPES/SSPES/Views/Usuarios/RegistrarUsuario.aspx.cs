using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;
using System.Text.RegularExpressions;

namespace SSPES.Views.Usuarios {
    public partial class RegistrarUsuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            RolController p = new RolController();
            List<string> lista = p.consultarRoles(p.modelo);
            rol.Items.Clear();
            for (int i = 0; i < lista.Count; i++) {
                rol.Items.Add(lista[i]);
            }
        }

        protected bool validarNombre(string h, bool requerido) {
            h = h.ToUpper();
            if (requerido) {
                if (h.Length < 3) return false;
            } else {
                if (h.Length > 0 && h.Length < 3) return false;
            }
            for (int i = 0; i < h.Length; i++) {
                if (h[i] < 'A' || h[i] > 'Z') {
                    return false;
                }
            }
            return true;
        }

        protected bool validarNumero(string h, int longitud, bool requerido) {
            if (!requerido && h.Length == 0) return true;
            try {
                long l = long.Parse(h);
                if (l < 0 || h.Length > longitud) return false;
            } catch {
                return false;
            }
            return true;
        }

        public bool validarCorreo(string valor) {
            valor = valor.Trim();
            var n = valor.IndexOf("@");

            return (!(valor.Contains(" ") || n == -1 || n != valor.LastIndexOf("@")
                || valor.Length - n < 3 || n == 0 || valor[n + 1] == '.'));
        }

        public string tipoDocumento() {
            switch (tDocumento.SelectedIndex) {
                case 0:
                    return "TI";
                case 1:
                    return "CC";
                default:
                    return "CE";
            }
        }

        public bool validarUsuarioPassword(String user, String pass) {
            Regex reg = new Regex("[^A-Z ^a-z ^0-9 ^.]");
            return (!reg.IsMatch(user) && !reg.IsMatch(pass));
        }

        protected void Registrar(object sender, EventArgs e) {

            try {
                if (!(validarNombre(nombre1.Value.ToString(), true) && validarNombre(nombre2.Value.ToString(), false) &&
                            validarNombre(apellido1.Value.ToString(), true) && validarNombre(apellido2.Value.ToString(), false))) {
                    Response.Write("<script> alert('Verifique los nombres y apellidos'); </script>");
                    return;
                }
                if (!validarNumero(nTelefono.Value.ToString(), 10, false)) {
                    Response.Write("<script> alert('verifique numero de telefono'); </script>");
                    return;
                }
                if (!validarNumero(nDocumento.Value.ToString(), 12, true)) {
                    Response.Write("<script> alert('verifique numero de documento'); </script>");
                    return;
                }
                if (!validarCorreo(correo.Value.ToString())) {
                    Response.Write("<script> alert('verifique correo electronico'); </script>");
                    return;
                }
                if (!validarUsuarioPassword(Usuario.Value.ToString(), password.Value.ToString())) {
                    Response.Write("<script> alert('Caracteres no valido en usuario y/o password'); </script>");
                    return;
                }
                if (password.Value.Length < 5) {

                    Response.Write("<script> alert('Usuario y Password debe ser de al menos 5 caracteres'); </script>");
                    return;
                }
                if (!(password.Value.ToString().Equals(rpassword.Value.ToString()))) {
                    Response.Write("<script> alert('password no coinciden'); </script>");
                    return;
                }
                PersonaController p = new PersonaController(nombre1.Value.ToString(), nombre2.Value.ToString(),
                                            apellido1.Value.ToString(), apellido2.Value.ToString(),
                                            tipoDocumento(), nDocumento.Value.ToString(), nTelefono.Value.ToString(),
                                            correo.Value.ToString(), (rol.SelectedIndex + 2));
                Response.Write("<script> alert('" + p.Insertar(p.p, Usuario.Value.ToString(), password.Value.ToString()) + "'); </script>");
            } catch (Exception) {
                Response.Write("<script> alert('Error inesperado!'); </script>");
            }
        }
    }
}
