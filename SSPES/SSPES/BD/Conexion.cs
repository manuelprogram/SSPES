﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SSPES.BD {
    public class Conexion {
        private static MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        private static bool Conectar() {
            try {
                conexion.Open();
                return true;
            } catch (Exception) {
                return false;
            }
        }
        private static void Desconectar() {
            conexion.Close();
        }

        public DataTable EjecutarConsulta(string sentencia, CommandType TipoComando) {
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = new MySqlCommand(sentencia, conexion);
            adaptador.SelectCommand.CommandType = TipoComando;

            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }
        public bool RealizarTransaccion(string[] cadena) {
            bool state = false;
            if (Conectar()) {
                MySqlTransaction Transa = conexion.BeginTransaction();
                MySqlCommand cmd = null;
                try {
                    for (int i = 0; i < cadena.Length; i++) {
                        if (cadena[i].Length > 0) {
                            cmd = new MySqlCommand(cadena[i], conexion);
                            cmd.Transaction = Transa;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Transa.Commit();
                    conexion.Close();
                    conexion.Dispose();
                    Transa.Dispose();
                    Desconectar();
                    state = true;
                } catch {
                    Transa.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                    Desconectar();
                    state = false;
                } finally {
                    // Recolectamos objetos para liberar su memoria.
                    if (cmd != null) {
                        cmd.Dispose();
                    }
                }
            }
            return state;
        }
    }
}