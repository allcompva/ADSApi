using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class Tur_visitas_x_turista : DALBase
    {
        public int id { get; set; }
        public string mail_turista { get; set; }
        public DateTime fecha { get; set; }
        public string dias_permanencia { get; set; }
        public string cant_acompaniantes { get; set; }
        public string motivo_visita { get; set; }
        public string tipo_transporte { get; set; }
        public bool primera_visita { get; set; }
        public bool vigente { get; set; }

        public Tur_visitas_x_turista()
        {
            id = 0;
            mail_turista = string.Empty;
            fecha = DateTime.Now;
            dias_permanencia = string.Empty;
            cant_acompaniantes = string.Empty;
            motivo_visita = string.Empty;
            tipo_transporte = string.Empty;
            primera_visita = false;
            vigente = false;
        }

        private static List<Tur_visitas_x_turista> mapeo(SqlDataReader dr)
        {
            List<Tur_visitas_x_turista> lst = new List<Tur_visitas_x_turista>();
            Tur_visitas_x_turista obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int mail_turista = dr.GetOrdinal("mail_turista");
                int fecha = dr.GetOrdinal("fecha");
                int dias_permanencia = dr.GetOrdinal("dias_permanencia");
                int cant_acompaniantes = dr.GetOrdinal("cant_acompaniantes");
                int motivo_visita = dr.GetOrdinal("motivo_visita");
                int tipo_transporte = dr.GetOrdinal("tipo_transporte");
                int primera_visita = dr.GetOrdinal("primera_visita");
                int vigente = dr.GetOrdinal("vigente");

                while (dr.Read())
                {
                    obj = new Tur_visitas_x_turista();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(mail_turista)) { obj.mail_turista = dr.GetString(mail_turista); }
                    if (!dr.IsDBNull(fecha)) { obj.fecha = dr.GetDateTime(fecha); }
                    if (!dr.IsDBNull(dias_permanencia)) { obj.dias_permanencia = dr.GetString(dias_permanencia); }
                    if (!dr.IsDBNull(cant_acompaniantes)) { obj.cant_acompaniantes = dr.GetString(cant_acompaniantes); }
                    if (!dr.IsDBNull(motivo_visita)) { obj.motivo_visita = dr.GetString(motivo_visita); }
                    if (!dr.IsDBNull(tipo_transporte)) { obj.tipo_transporte = dr.GetString(tipo_transporte); }
                    if (!dr.IsDBNull(primera_visita)) { obj.primera_visita = dr.GetBoolean(primera_visita); }
                    if (!dr.IsDBNull(vigente)) { obj.vigente = dr.GetBoolean(vigente); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tur_visitas_x_turista> read()
        {
            try
            {
                List<Tur_visitas_x_turista> lst = new List<Tur_visitas_x_turista>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Tur_visitas_x_turista";
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
        public static bool IsFormComplete(string mail)
        {
            try
            {
                bool formComplete = false;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT *FROM tur_visitas_x_turista 
                        WHERE mail_turista=@mail_turista AND vigente=1";
                    cmd.Parameters.AddWithValue("@mail_turista", mail);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_visitas_x_turista> lst = mapeo(dr);
                    if (lst.Count != 0)
                        formComplete = true;
                }
                return formComplete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Tur_visitas_x_turista getByPk(string mail)
        {
            try
            {

                Tur_visitas_x_turista obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT * FROM tur_visitas_x_turista 
                        WHERE mail_turista=@mail_turista";
                    cmd.Parameters.AddWithValue("@mail_turista", mail);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_visitas_x_turista> lst = mapeo(dr);
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

        public static void insert(Tur_visitas_x_turista obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_visitas_x_turista(");
                sql.AppendLine("mail_turista");
                sql.AppendLine(", fecha");
                sql.AppendLine(", dias_permanencia");
                sql.AppendLine(", cant_acompaniantes");
                sql.AppendLine(", motivo_visita");
                sql.AppendLine(", tipo_transporte");
                sql.AppendLine(", primera_visita");
                sql.AppendLine(", vigente");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@mail_turista");
                sql.AppendLine(", @fecha");
                sql.AppendLine(", @dias_permanencia");
                sql.AppendLine(", @cant_acompaniantes");
                sql.AppendLine(", @motivo_visita");
                sql.AppendLine(", @tipo_transporte");
                sql.AppendLine(", @primera_visita");
                sql.AppendLine(", 1");
                sql.AppendLine("); SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@mail_turista", obj.mail_turista);
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@dias_permanencia", obj.dias_permanencia);
                    cmd.Parameters.AddWithValue("@cant_acompaniantes", obj.cant_acompaniantes);
                    cmd.Parameters.AddWithValue("@motivo_visita", obj.motivo_visita);
                    cmd.Parameters.AddWithValue("@tipo_transporte", obj.tipo_transporte);
                    cmd.Parameters.AddWithValue("@primera_visita", obj.primera_visita);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tur_visitas_x_turista obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_visitas_x_turista SET");
                sql.AppendLine("dias_permanencia=@dias_permanencia");
                sql.AppendLine(", cant_acompaniantes=@cant_acompaniantes");
                sql.AppendLine(", motivo_visita=@motivo_visita");
                sql.AppendLine(", tipo_transporte=@tipo_transporte");
                sql.AppendLine(", primera_visita=@primera_visita");
                sql.AppendLine("WHERE mail_turista=@mail_turista");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@dias_permanencia", obj.dias_permanencia);
                    cmd.Parameters.AddWithValue("@cant_acompaniantes", obj.cant_acompaniantes);
                    cmd.Parameters.AddWithValue("@motivo_visita", obj.motivo_visita);
                    cmd.Parameters.AddWithValue("@tipo_transporte", obj.tipo_transporte);
                    cmd.Parameters.AddWithValue("@primera_visita", obj.primera_visita);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setVigenciaMasiva(bool vigencia)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_visitas_x_turista SET");
                sql.AppendLine("vigente=@vigencia");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@vigente", vigencia);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setVigencia(int idForm, string mail, bool vigencia)
        {
            try
            {
                Tur_turista objTurista = Tur_turista.getByPk(mail);

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Tur_visitas_x_turista SET");
                sql.AppendLine("vigente=@vigencia");
                sql.AppendLine("WHERE id=@id AND mail_turista=@mail_turista");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@vigente", vigencia);
                    cmd.Parameters.AddWithValue("@id", idForm);
                    cmd.Parameters.AddWithValue("@mail_turista", objTurista.mail);
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
                sql.AppendLine("DELETE  Tur_visitas_x_turista ");
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

