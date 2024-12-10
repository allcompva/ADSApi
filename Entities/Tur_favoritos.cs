using ADSWebApi.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ADSWebApi.Entities
{
    public class Tur_favoritos: DALBase
    {
        public string mail {  get; set; }   
        public int id_publicacion { get; set; }    
        public Tur_favoritos()
        {
            id_publicacion = 0;
            mail = string.Empty;
        }
        public static int insert(int cate, string mail)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO favoritos(");
                sql.AppendLine("mail");
                sql.AppendLine(", id_publicacion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@mail");
                sql.AppendLine(", @id_publicacion");
                sql.AppendLine(")");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@id_publicacion", cate); ;
     
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int id_publicacion, string mail)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  favoritos ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_publicacion=@id_publicacion AND");
                sql.AppendLine("mail=@mail");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@id_publicacion", id_publicacion); 
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool getByPk(int id, string mail)
        {
            try
            {
                bool result = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM favoritos WHERE");
                sql.AppendLine("id_publicacion = @id AND mail=@mail");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@mail", mail);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
