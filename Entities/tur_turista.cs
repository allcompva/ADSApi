using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities;

public class Tur_turista : DALBase
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string mail { get; set; }
    public string password { get; set; }
    public bool recibe_notificaciones { get; set; }
    public string metadata { get; set; }
    public bool primer_ingreso { get; set; }

    public Tur_turista()
    {
        id = 0;
        nombre = string.Empty;
        mail = string.Empty;
        password = string.Empty;
        recibe_notificaciones = true;
        metadata = string.Empty;
        primer_ingreso = true;
    }

    private static List<Tur_turista> mapeo(SqlDataReader dr)
    {
        List<Tur_turista> lst = new List<Tur_turista>();
        Tur_turista obj;
        if (dr.HasRows)
        {
            int id = dr.GetOrdinal("id");
            int nombre = dr.GetOrdinal("nombre");
            int mail = dr.GetOrdinal("mail");
            int password = dr.GetOrdinal("password");
            int recibe_notificaciones = dr.GetOrdinal("recibe_notificaciones");
            int metadata = dr.GetOrdinal("metadata");
            int primer_ingreso = dr.GetOrdinal("primer_ingreso");
            while (dr.Read())
            {
                obj = new Tur_turista();
                if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                if (!dr.IsDBNull(mail)) { obj.mail = dr.GetString(mail); }
                if (!dr.IsDBNull(password)) { obj.password = dr.GetString(password); }
                if (!dr.IsDBNull(recibe_notificaciones)) { 
                    obj.recibe_notificaciones = dr.GetBoolean(recibe_notificaciones); }
                if (!dr.IsDBNull(metadata)) { obj.metadata = dr.GetString(metadata); }
                if (!dr.IsDBNull(primer_ingreso)) { obj.primer_ingreso = 
                        dr.GetBoolean(primer_ingreso); }               
                lst.Add(obj);
            }
        }
        return lst;
    }

    public static List<Tur_turista> read()
    {
        try
        {
            List<Tur_turista> lst = new List<Tur_turista>();
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT *FROM Tur_turista";
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

    public static Tur_turista getByPk(string mail)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT *FROM Tur_turista WHERE");
            sql.AppendLine("mail = @mail");
            Tur_turista obj = null;
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Tur_turista> lst = mapeo(dr);
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

    public static int insert(Tur_turista obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Tur_turista(");
            sql.AppendLine("nombre");
            sql.AppendLine(", mail");
            sql.AppendLine(", recibe_notificaciones");
            sql.AppendLine(", primer_ingreso");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine("@nombre");
            sql.AppendLine(", @mail");
            sql.AppendLine(", 1");
            sql.AppendLine(", 1");
            sql.AppendLine(")");
            sql.AppendLine("SELECT SCOPE_IDENTITY()");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@mail", obj.mail);              
                cmd.Connection.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void setNotificaciones(string mail, bool noti)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE  Tur_turista SET");
            sql.AppendLine("recibe_notificaciones=@recibe_notificaciones");
            sql.AppendLine("WHERE");
            sql.AppendLine("mail=@mail");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@recibe_notificaciones", noti);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void delete(string mail)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE  Tur_turista ");
            sql.AppendLine("WHERE");
            sql.AppendLine("mail=@mail");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@mail", mail);
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

