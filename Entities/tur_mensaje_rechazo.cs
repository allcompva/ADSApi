using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class tur_mensaje_rechazo : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string mensaje_rechazo { get; set; }
        public bool activo { get; set; }

        public tur_mensaje_rechazo()
        {
            id = 0;
            nombre = string.Empty;
            mensaje_rechazo = string.Empty;
            activo = false;
        }

        private static List<tur_mensaje_rechazo> mapeo(SqlDataReader dr)
        {
            List<tur_mensaje_rechazo> lst = new List<tur_mensaje_rechazo>();
            tur_mensaje_rechazo obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int nombre = dr.GetOrdinal("nombre");
                int mensaje_rechazo = dr.GetOrdinal("mensaje_rechazo");
                int activo = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new tur_mensaje_rechazo();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(mensaje_rechazo)) { obj.mensaje_rechazo = dr.GetString(mensaje_rechazo); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<tur_mensaje_rechazo> read()
        {
            try
            {
                List<tur_mensaje_rechazo> lst = new List<tur_mensaje_rechazo>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Tur_mensaje_rechazo";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static tur_mensaje_rechazo getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Tur_mensaje_rechazo WHERE");
                sql.AppendLine("id = @id");
                tur_mensaje_rechazo obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<tur_mensaje_rechazo> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(tur_mensaje_rechazo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_mensaje_rechazo(");
                sql.AppendLine("nombre");
                sql.AppendLine(", mensaje_rechazo");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @mensaje_rechazo");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@mensaje_rechazo", obj.mensaje_rechazo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(tur_mensaje_rechazo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  tur_mensaje_rechazo SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", mensaje_rechazo=@mensaje_rechazo");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@mensaje_rechazo", obj.mensaje_rechazo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void activa_desactiva(int id, bool activo)
        {
            try
            {
                string sql =
                @"UPDATE tur_mensaje_rechazo 
                    SET activo=@activo
                WHERE id=@id";
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@activo", activo);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(tur_mensaje_rechazo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  tur_mensaje_rechazo ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

