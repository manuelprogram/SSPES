using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSPES.Controllers;

namespace SSPES.Views.Usuarios {
    public partial class RegistrarUsuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ProfesionController p = new ProfesionController();
            List<string> lista = p.consultarProfesiones(p.modelo);
            profesion.Items.Clear();
            for (int i = 0; i < lista.Count; i++) {
                profesion.Items.Add(lista[i]);
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

        protected void Registrar(object sender, EventArgs e) {
            try {
                if (validarNombre(nombre1.Value.ToString(), true) && validarNombre(nombre2.Value.ToString(), false) &&
                            validarNombre(apellido1.Value.ToString(), true) && validarNombre(apellido2.Value.ToString(), false)) {
                    if (validarNumero(nTelefono.Value.ToString(), 10, false)) {
                        if (validarNumero(nDocumento.Value.ToString(), 12, true)) {
                            if (validarCorreo(correo.Value.ToString())) {
                                if (Usuario.Size != 0) {
                                    if ((password.Value.ToString().Equals(rpassword.Value.ToString()))) {

                                        PersonaController p = new PersonaController(nombre1.Value.ToString(), nombre2.Value.ToString(),
                                            apellido1.Value.ToString(), apellido2.Value.ToString(),
                                            tipoDocumento(), nDocumento.Value.ToString(), nTelefono.Value.ToString(),
                                            correo.Value.ToString(), (profesion.SelectedIndex + 1));

                                        resultado.InnerText = p.Insertar(p.p, Usuario.Value.ToString(), password.Value.ToString());

                                    } else {
                                        resultado.InnerText = "password no coinciden";
                                    }
                                } else {
                                    resultado.InnerText = "nombre de usuario ya registrado";
                                }
                            } else {
                                resultado.InnerText = "verifique correo electronico";
                            }
                        } else {
                            resultado.InnerText = "verifique numero de documento";
                        }
                    } else {
                        resultado.InnerText = "verifique numero de telefono";
                    }
                } else {
                    resultado.InnerText = "Verifique los nombres!!!";
                }

            } catch (Exception) {
                resultado.InnerText = "Ha ocurrido un error inesperado!!!";
            }
        }
    }
}
