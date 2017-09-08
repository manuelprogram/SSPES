using SSPES.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSPES.Models {
    public class PersonaModel {

        public string Nombre_1 { get; set; }
        public string Nombre_2 { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
        public string T_documento { get; set; }
        public string N_documento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        Conexion con = new Conexion();

        //public bool InsertarNuevaCuanta() {
            //string sql = "INSERT INTO PERSONA (NOMBRE_1, NOMBRE_2, APELLIDO_1, APELLIDO_2, T_DOCUMENTO, N_DOCUMENTO, CELULAR, CORREO, REGISTRO, ) VALUES ('{0}','{1}');";
            //string[] ar = new string[1];
            //ar[0] = string.Format(sql, obj.Usuario, obj.Password);
            //return con.RealizarTransaccion(ar);
        //}
    }
}