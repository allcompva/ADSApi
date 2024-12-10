using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities;

public class Tur_videos_educativos : DALBase
{
    public int id { get; set; }
    public string titulo { get; set; }
    public string codigo_insercion { get; set; }
    public bool es_principal { get; set; }
    public bool activo { get; set; }
    public int orden { get; set; }

    public Tur_videos_educativos()
    {
        id = 0;
        titulo = string.Empty;
        codigo_insercion = string.Empty;
        es_principal = false;
        activo = false;
        orden = 0;
    }

    private static List<Tur_videos_educativos> mapeo(SqlDataReader dr)
    {
        List<Tur_videos_educativos> lst = new List<Tur_videos_educativos>();
        Tur_videos_educativos obj;
        if (dr.HasRows)
        {
            int id = dr.GetOrdinal("id");
            int titulo = dr.GetOrdinal("titulo");
            int codigo_insercion = dr.GetOrdinal("codigo_insercion");
            int es_principal = dr.GetOrdinal("es_principal");
            int activo = dr.GetOrdinal("activo");
            int orden = dr.GetOrdinal("orden");
            while (dr.Read())
            {
                obj = new Tur_videos_educativos();
                if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                if (!dr.IsDBNull(titulo)) { obj.titulo = dr.GetString(titulo); }
                if (!dr.IsDBNull(codigo_insercion)) { obj.codigo_insercion = dr.GetString(codigo_insercion); }
                if (!dr.IsDBNull(es_principal)) { obj.es_principal = dr.GetBoolean(es_principal); }
                if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                if (!dr.IsDBNull(orden)) { obj.orden = dr.GetInt32(orden); }
                lst.Add(obj);
            }
        }
        return lst;
    }

    public static List<Tur_videos_educativos> read()
    {
        try
        {
            List<Tur_videos_educativos> lst = new List<Tur_videos_educativos>();
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT *FROM Tur_videos_educativos";
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

    public static Tur_videos_educativos getByPk(
    int id)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT *FROM Tur_videos_educativos WHERE");
            sql.AppendLine("id = @id");
            Tur_videos_educativos obj = null;
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Tur_videos_educativos> lst = mapeo(dr);
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

    public static int insert(Tur_videos_educativos obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Tur_videos_educativos(");
            sql.AppendLine("titulo");
            sql.AppendLine(", codigo_insercion");
            sql.AppendLine(", es_principal");
            sql.AppendLine(", activo");
            sql.AppendLine(", orden");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine("@titulo");
            sql.AppendLine(", @codigo_insercion");
            sql.AppendLine(", @es_principal");
            sql.AppendLine(", @activo");
            sql.AppendLine(", @orden");
            sql.AppendLine(")");
            sql.AppendLine("SELECT SCOPE_IDENTITY()");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                cmd.Parameters.AddWithValue("@codigo_insercion", obj.codigo_insercion);
                cmd.Parameters.AddWithValue("@es_principal", obj.es_principal);
                cmd.Parameters.AddWithValue("@activo", obj.activo);
                cmd.Parameters.AddWithValue("@orden", obj.orden);
                cmd.Connection.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void update(Tur_videos_educativos obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE  Tur_videos_educativos SET");
            sql.AppendLine("titulo=@titulo");
            sql.AppendLine(", codigo_insercion=@codigo_insercion");
            sql.AppendLine(", es_principal=@es_principal");
            sql.AppendLine(", activo=@activo");
            sql.AppendLine(", orden=@orden");
            sql.AppendLine("WHERE");
            sql.AppendLine("id=@id");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                cmd.Parameters.AddWithValue("@codigo_insercion", obj.codigo_insercion);
                cmd.Parameters.AddWithValue("@es_principal", obj.es_principal);
                cmd.Parameters.AddWithValue("@activo", obj.activo);
                cmd.Parameters.AddWithValue("@orden", obj.orden);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void delete(Tur_videos_educativos obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE  Tur_videos_educativos ");
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

