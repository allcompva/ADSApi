using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class Tur_notificaciones : DALBase
    {
        public int id { get; set; }
        public string resenia { get; set; }
        public string notificacion { get; set; }
        public int id_turista { get; set; }
        public bool leida { get; set; }
        public bool enviada { get; set; }

        public Tur_notificaciones()
        {
            id = 0;
            resenia = string.Empty;
            notificacion = string.Empty;
            id_turista = 0;
            leida = false;
            enviada = false;
        }

        private static List<Tur_notificaciones> mapeo(SqlDataReader dr)
        {
            List<Tur_notificaciones> lst = new List<Tur_notificaciones>();
            Tur_notificaciones obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int resenia = dr.GetOrdinal("resenia");
                int notificacion = dr.GetOrdinal("notificacion");
                int id_turista = dr.GetOrdinal("id_turista");
                int leida = dr.GetOrdinal("leida");
                int enviada = dr.GetOrdinal("enviada");
                while (dr.Read())
                {
                    obj = new Tur_notificaciones();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(resenia)) { obj.resenia = dr.GetString(resenia); }
                    if (!dr.IsDBNull(notificacion)) { obj.notificacion = dr.GetString(notificacion); }
                    if (!dr.IsDBNull(id_turista)) { obj.id_turista = dr.GetInt32(id_turista); }
                    if (!dr.IsDBNull(leida)) { obj.leida = dr.GetBoolean(leida); }
                    if (!dr.IsDBNull(enviada)) { obj.enviada = dr.GetBoolean(enviada); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tur_notificaciones> read()
        {
            try
            {
                List<Tur_notificaciones> lst = new List<Tur_notificaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Tur_notificaciones";
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
        public static List<Tur_notificaciones> readTurista(int id_turista)
        {
            try
            {
                List<Tur_notificaciones> lst = new List<Tur_notificaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT *FROM tur_notificaciones 
                          WHERE id_turista=@id_turista";
                    cmd.Parameters.AddWithValue("@id_turista", id_turista);
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

        public static Tur_notificaciones getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Tur_notificaciones WHERE id=@id");
                Tur_notificaciones obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_notificaciones> lst = mapeo(dr);
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

        public static int insert(Tur_notificaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_notificaciones(");
                sql.AppendLine("id");
                sql.AppendLine(", resenia");
                sql.AppendLine(", notificacion");
                sql.AppendLine(", id_turista");
                sql.AppendLine(", leida");
                sql.AppendLine(", enviada");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @resenia");
                sql.AppendLine(", @notificacion");
                sql.AppendLine(", @id_turista");
                sql.AppendLine(", @leida");
                sql.AppendLine(", @enviada");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@notificacion", obj.notificacion);
                    cmd.Parameters.AddWithValue("@id_turista", obj.id_turista);
                    cmd.Parameters.AddWithValue("@leida", obj.leida);
                    cmd.Parameters.AddWithValue("@enviada", obj.enviada);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tur_notificaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_notificaciones SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", resenia=@resenia");
                sql.AppendLine(", notificacion=@notificacion");
                sql.AppendLine(", id_turista=@id_turista");
                sql.AppendLine(", leida=@leida");
                sql.AppendLine(", enviada=@enviada");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@notificacion", obj.notificacion);
                    cmd.Parameters.AddWithValue("@id_turista", obj.id_turista);
                    cmd.Parameters.AddWithValue("@leida", obj.leida);
                    cmd.Parameters.AddWithValue("@enviada", obj.enviada);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Tur_notificaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tur_notificaciones ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

