using SSPES.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSPES.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioModel useres = new UsuarioModel();

        //public DataTable consultarUsuarios() {
        //    return useres.consultarUsuarios();
        //}

        public void Insertar(UsuarioModel obj) {
            obj.insertar(obj);
        }
    }
}
