using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSPES.Controllers {
    public class PersonaController : ApiController {

        public PersonaModel p = new PersonaModel();

        public PersonaController() {
        }

        public PersonaController(string a, string b, string c, string d, string e, string f, string g, 
                string h, int i) {
            p.Nombre_1 = a;
            p.Nombre_2 = b;
            p.Apellido_1 = c;
            p.Apellido_2 = d;
            p.T_documento = e;
            p.N_documento = f;
            p.Telefono = g;
            p.Correo = h;
            p.rol = i;
        }
        
        public string Insertar(PersonaModel obj, string user, string pass) {
            CuentaController c = new CuentaController();
            RolCuentaController rcc = new RolCuentaController();
            c.useres.Usuario = user;
            c.useres.Password = pass;
            if (c.cuentaExiste(c.useres)) return "usuario ya existe!!!";
            if (!obj.InsertarNuevaPersona(obj)) return "Error al resgistrar la persona, ¿identificacion correcta?";
            c.useres.FK_PERSONA = p.ConsultarIdUsuario(p);
            if (c.Insertar(c.useres)) {
                rcc.RC.fk_cuenta = c.GetPkcuenta(user);
                rcc.RC.fk_rol = p.rol.ToString();
                rcc.RC.InsertarRolCuenta(rcc.RC);

                return "INSERT INTO rol_cuenta values('"+rcc.RC.fk_cuenta+"', '"+rcc.RC.fk_rol+"', 'A')";
               // return "exitoso";

            }else {
                return "Error al crear cuenta";
            }
        }
    }
}