using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class tur_mensaje_aprobacion : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string mensaje_aprobacion { get; set; }
        public bool activo { get; set; }


        public tur_mensaje_aprobacion()
        {
            id = 0;
            nombre = string.Empty;
            mensaje_aprobacion = string.Empty;
            activo = false;
        }

        private static List<tur_mensaje_aprobacion> mapeo(SqlDataReader dr)
        {
            List<tur_mensaje_aprobacion> lst = new List<tur_mensaje_aprobacion>();
            tur_mensaje_aprobacion obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int nombre = dr.GetOrdinal("nombre");
                int mensaje_aprobacion = dr.GetOrdinal("mensaje_aprobacion");
                int activo = dr.GetOrdinal("activo");

                while (dr.Read())
                {
                    obj = new tur_mensaje_aprobacion();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(mensaje_aprobacion))
                    {
                        obj.mensaje_aprobacion = dr.GetString(mensaje_aprobacion);
                    }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<tur_mensaje_aprobacion> read()
        {
            try
            {
                List<tur_mensaje_aprobacion> lst = new List<tur_mensaje_aprobacion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM tur_mensaje_aprobacion";
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

        public static tur_mensaje_aprobacion getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM tur_mensaje_aprobacion WHERE id=@id");
                tur_mensaje_aprobacion obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<tur_mensaje_aprobacion> lst = mapeo(dr);
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

        public static int insert(tur_mensaje_aprobacion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO tur_mensaje_aprobacion(");
                sql.AppendLine("nombre, mensaje_aprobacion, true)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@nombre, @mensaje_aprobacion");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@mensaje_aprobacion", obj.mensaje_aprobacion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(tur_mensaje_aprobacion obj)
        {
            try
            {
                string sql =
                @"UPDATE tur_mensaje_aprobacion 
                    SET nombre=@nombre, 
                    mensaje_aprobacion=@mensaje_aprobacion
                WHERE
                id=@id";
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@mensaje_aprobacion", obj.mensaje_aprobacion);
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
        public static void activa_desactiva(int id, bool activo)
        {
            try
            {
                string sql =
                @"UPDATE tur_mensaje_aprobacion 
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
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE tur_mensaje_aprobacion ");
                sql.AppendLine("WHERE id=@id");


                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
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

