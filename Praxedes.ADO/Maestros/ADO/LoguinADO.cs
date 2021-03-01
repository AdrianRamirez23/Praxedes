using Praxedes.ADO.Maestros.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxedes.ADO.Maestros.ADO
{
    class LoguinADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
        internal bool ValidarUsuario(LoguinRequestBack log)
        {
            try
            {
                bool resp = false;
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec Usuarios_CRUD 1,'" + log.Username + "','" + log.Password + "','' ";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        resp = rdr[0] == DBNull.Value ? false : rdr.GetBoolean(0);
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        internal void RegistrarToken(LoguinRequestBack log, string Token)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec Usuarios_CRUD 2,'" + log.Username + "','" + log.Password + "','"+Token+"' ";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}
