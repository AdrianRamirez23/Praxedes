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
    class GrupoFamiliarADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
        internal List<GrupoFamiliarBack> ListarGrupoFamiliar(LoguinRequestBack log) 
        {
            try
            {
                List<GrupoFamiliarBack> Lista = new List<GrupoFamiliarBack>();
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec GrupoFamiliar_CRUD 1,'"+log.Username+"','','','','','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GrupoFamiliarBack Fam = new GrupoFamiliarBack();
                        Fam.Usuario = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                        Fam.Cedula = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                        Fam.Nombres = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                        Fam.Apellidos = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                        Fam.Genero = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                        Fam.Parentesco = rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                        Fam.Edad = rdr[6] == DBNull.Value ? 0 : rdr.GetInt32(6);
                        Fam.MenorEdad = rdr[7] == DBNull.Value ? "" : rdr.GetString(7);
                        Fam.FechaNacimiento = rdr[8] == DBNull.Value ? Convert.ToDateTime("yyyy-mm-dd") : rdr.GetDateTime(8);
                        Lista.Add(Fam);
                    }
                    return Lista;
                }
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }
        internal void CrearGrupoFamiliar(GrupoFamiliarBack fam)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec GrupoFamiliar_CRUD 2,'" + fam.Usuario + "','"+fam.Cedula+"','"+fam.Nombres+"','"+fam.Apellidos+"','"+fam.Genero+"','"+fam.Parentesco+"','"+fam.Edad+"','"+fam.FechaNacimiento+"'";
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
        internal void EditarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec GrupoFamiliar_CRUD 3,'" + fam.Usuario + "','" + fam.Cedula + "','" + fam.Nombres + "','" + fam.Apellidos + "','" + fam.Genero + "','" + fam.Parentesco + "','" + fam.Edad + "','" + fam.FechaNacimiento + "'";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        internal void EliminarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec GrupoFamiliar_CRUD 4,'" + fam.Usuario + "','" + fam.Cedula + "','','','','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
