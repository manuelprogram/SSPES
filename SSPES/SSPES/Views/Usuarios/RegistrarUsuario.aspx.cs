using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSPES.Views.Usuarios {
    public partial class RegistrarUsuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //profesion.Items.Add();
        }

        protected bool validarNombre(string h, bool requerido) {
            h = h.ToUpper();
            resultado.InnerText = "llego la cadena " + h;
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
                if (l < 0 || h.Length != longitud) return false;
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

        protected void Registrar(object sender, EventArgs e) {
            try {
                if (validarNombre(nombre1.ToString(), true) && validarNombre(nombre2.ToString(), false) &&
                        validarNombre(apellido1.ToString(), true) && validarNombre(apellido2.ToString(), false)) {
                    if (validarNumero(nTelefono.ToString(), 10, false) ) {
                        if(validarNumero(nDocumento.ToString(), 12, true)) {
                            if (validarCorreo(correo.ToString())) {
                                if (Usuario.Size != 0) {
                                    if ((password.Equals(rpassword))) {
                                        resultado.InnerText = "correcto";
                                    }else {
                                        resultado.InnerText = "password no coinciden";
                                    }
                                }else {
                                    resultado.InnerText = "nombre de usuario ya registrado";
                                }
                            }else {
                                resultado.InnerText = "verifique correo electronico";
                            }
                        }else {
                            resultado.InnerText = "verifique numero de documento";
                        }
                    }else {
                        resultado.InnerText = "verifique numero de telefono";
                    }
                }else {
                    //resultado.InnerText = "Verifique los nombres!!!";
                }

            } catch (Exception) { }
        }
    }
}
