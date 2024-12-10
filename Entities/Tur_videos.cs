using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class Tur_videos : DALBase
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string resenia { get; set; }
        public string codigo_insercion { get; set; }
        public bool es_principal { get; set; }

        public Tur_videos()
        {
            id = 0;
            titulo = string.Empty;
            resenia = string.Empty;
            codigo_insercion = string.Empty;
            es_principal = false;
        }

        private static List<Tur_videos> mapeo(SqlDataReader dr)
        {
            List<Tur_videos> lst = new List<Tur_videos>();
            Tur_videos obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int titulo = dr.GetOrdinal("titulo");
                int resenia = dr.GetOrdinal("resenia");
                int codigo_insercion = dr.GetOrdinal("codigo_insercion");
                int es_principal = dr.GetOrdinal("es_principal");
                while (dr.Read())
                {
                    obj = new Tur_videos();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(titulo)) { obj.titulo = dr.GetString(titulo); }
                    if (!dr.IsDBNull(resenia)) { obj.resenia = dr.GetString(resenia); }
                    if (!dr.IsDBNull(codigo_insercion)) { obj.codigo_insercion = dr.GetString(codigo_insercion); }
                    if (!dr.IsDBNull(es_principal)) { obj.es_principal = dr.GetBoolean(es_principal); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tur_videos> read()
        {
            try
            {
                List<Tur_videos> lst = new List<Tur_videos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Tur_videos";
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

        public static Tur_videos getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Tur_videos WHERE");
                sql.AppendLine("id = @id");
                Tur_videos obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_videos> lst = mapeo(dr);
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

        public static int insert(Tur_videos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_videos(");
                sql.AppendLine("titulo");
                sql.AppendLine(", resenia");
                sql.AppendLine(", codigo_insercion");
                sql.AppendLine(", es_principal");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@titulo");
                sql.AppendLine(", @resenia");
                sql.AppendLine(", @codigo_insercion");
                sql.AppendLine(", @es_principal");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@codigo_insercion", obj.codigo_insercion);
                    cmd.Parameters.AddWithValue("@es_principal", obj.es_principal);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tur_videos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_videos SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine(", resenia=@resenia");
                sql.AppendLine(", codigo_insercion=@codigo_insercion");
                sql.AppendLine(", es_principal=@es_principal");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@codigo_insercion", obj.codigo_insercion);
                    cmd.Parameters.AddWithValue("@es_principal", obj.es_principal);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Tur_videos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tur_videos ");
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

