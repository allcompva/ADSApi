using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
    public class Tur_comercio : DALBase
    {
        public string cuit { get; set; }
        public string razon_social { get; set; }
        public string nro_comercio_e_industria { get; set; }
        public string nombre_fantacia { get; set; }
        public string direccion { get; set; }
        public string codigo_insercion_maps { get; set; }
        public string whatsapp { get; set; }
        public string cuit_responsable { get; set; }
        public string mail { get; set; }
        public string cel { get; set; }
        public string estado { get; set; }
        public string descripcion {  get; set; }
        public int id_categoria { get; set; }
        public string images { get; set; }
        public string responsablenombre { get; set; }
        public Tur_comercio()
        {
            cuit = string.Empty;
            razon_social = string.Empty;
            nro_comercio_e_industria = string.Empty;
            nombre_fantacia = string.Empty;
            direccion = string.Empty;
            codigo_insercion_maps = string.Empty;
            whatsapp = string.Empty;
            cuit_responsable = string.Empty;
            mail = string.Empty;
            cel = string.Empty;
            estado = string.Empty;
            descripcion = string.Empty;
            id_categoria = 0;
            images = string.Empty;
            responsablenombre = string.Empty;   
        }

        private static List<Tur_comercio> mapeo(SqlDataReader dr)
        {
            List<Tur_comercio> lst = new List<Tur_comercio>();
            Tur_comercio obj;
            if (dr.HasRows)
            {
                int cuit = dr.GetOrdinal("cuit");
                int razon_social = dr.GetOrdinal("razon_social");
                int nro_comercio_e_industria = dr.GetOrdinal("nro_comercio_e_industria");
                int nombre_fantacia = dr.GetOrdinal("nombre_fantacia");
                int direccion = dr.GetOrdinal("direccion");
                int codigo_insercion_maps = dr.GetOrdinal("codigo_insercion_maps");
                int whatsapp = dr.GetOrdinal("whatsapp");
                int cuit_responsable = dr.GetOrdinal("cuit_responsable");
                int mail = dr.GetOrdinal("mail");
                int cel = dr.GetOrdinal("cel");
                int estado = dr.GetOrdinal("estado");
                int descripcion = dr.GetOrdinal("descripcion");
                int id_categoria = dr.GetOrdinal("id_categoria");
                int fotos = dr.GetOrdinal("fotos");
                int responsablenombre = dr.GetOrdinal("responsablenombre");
                while (dr.Read())
                {
                    obj = new Tur_comercio();
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(razon_social)) { obj.razon_social = dr.GetString(razon_social); }
                    if (!dr.IsDBNull(nro_comercio_e_industria)) { obj.nro_comercio_e_industria = dr.GetString(nro_comercio_e_industria); }
                    if (!dr.IsDBNull(nombre_fantacia)) { obj.nombre_fantacia = dr.GetString(nombre_fantacia); }
                    if (!dr.IsDBNull(direccion)) { obj.direccion = dr.GetString(direccion); }
                    if (!dr.IsDBNull(codigo_insercion_maps)) { obj.codigo_insercion_maps = dr.GetString(codigo_insercion_maps); }
                    if (!dr.IsDBNull(whatsapp)) { obj.whatsapp = dr.GetString(whatsapp); }
                    if (!dr.IsDBNull(cuit_responsable)) { obj.cuit_responsable = dr.GetString(cuit_responsable); }
                    if (!dr.IsDBNull(mail)) { obj.mail = dr.GetString(mail); }
                    if (!dr.IsDBNull(cel)) { obj.cel = dr.GetString(cel); }
                    if (!dr.IsDBNull(estado)) { obj.estado = dr.GetString(estado); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(id_categoria)) { obj.id_categoria = dr.GetInt32(id_categoria); }
                    if (!dr.IsDBNull(fotos)) { obj.images = dr.GetString(fotos); }
                    if (!dr.IsDBNull(responsablenombre)) { obj.responsablenombre = dr.GetString(responsablenombre); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tur_comercio> read(int idCate)
        {
            try
            {
                List<Tur_comercio> lst = new List<Tur_comercio>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM Tur_comercio 
                                        WHERE id_categoria=@id_categoria
                                        AND ESTADO='Aprobado'";
                    cmd.Parameters.AddWithValue("@id_categoria", idCate);
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
        public static List<Tur_comercio> readAll(int idCate)
        {
            try
            {
                string sql = "SELECT *FROM Tur_comercio";
                if(idCate != 0)
                    sql += " WHERE id_categoria=@id_categoria";
                List<Tur_comercio> lst = new List<Tur_comercio>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    if (idCate != 0)
                        cmd.Parameters.AddWithValue("@id_categoria", idCate);
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
        public static List<Tur_comercio> readSolicitudes()
        {
            try
            {
                List<Tur_comercio> lst = null;

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Tur_comercio getByPk(string cuit)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Tur_comercio WHERE cuit=@cuit");
                Tur_comercio obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_comercio> lst = mapeo(dr);
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

        public static int insert(Tur_comercio obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_comercio(");
                sql.AppendLine("cuit");
                sql.AppendLine(", razon_social");
                sql.AppendLine(", nro_comercio_e_industria");
                sql.AppendLine(", nombre_fantacia");
                sql.AppendLine(", direccion");
                sql.AppendLine(", codigo_insercion_maps");
                sql.AppendLine(", whatsapp");
                sql.AppendLine(", cuit_responsable");
                sql.AppendLine(", mail");
                sql.AppendLine(", cel");
                sql.AppendLine(", estado");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", id_categoria");
                sql.AppendLine(", fotos");
                sql.AppendLine(", responsablenombre");
                sql.AppendLine(", fecha_registro");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cuit");
                sql.AppendLine(", @razon_social");
                sql.AppendLine(", @nro_comercio_e_industria");
                sql.AppendLine(", @nombre_fantacia");
                sql.AppendLine(", @direccion");
                sql.AppendLine(", @codigo_insercion_maps");
                sql.AppendLine(", @whatsapp");
                sql.AppendLine(", @cuit_responsable");
                sql.AppendLine(", @mail");
                sql.AppendLine(", @cel");
                sql.AppendLine(", @estado");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @id_categoria");
                sql.AppendLine(", @fotos");
                sql.AppendLine(", @responsablenombre");
                sql.AppendLine(", GETDATE()");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@razon_social", obj.razon_social);
                    cmd.Parameters.AddWithValue("@nro_comercio_e_industria", obj.nro_comercio_e_industria);
                    cmd.Parameters.AddWithValue("@nombre_fantacia", obj.nombre_fantacia);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@codigo_insercion_maps", obj.codigo_insercion_maps);
                    cmd.Parameters.AddWithValue("@whatsapp", obj.whatsapp);
                    cmd.Parameters.AddWithValue("@cuit_responsable", obj.cuit_responsable);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@cel", obj.cel);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", obj.id_categoria);
                    cmd.Parameters.AddWithValue("@fotos", obj.images);
                    cmd.Parameters.AddWithValue("@responsablenombre", obj.responsablenombre);

                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tur_comercio obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_comercio SET");
                sql.AppendLine("razon_social=@razon_social");
                sql.AppendLine(", nro_comercio_e_industria=@nro_comercio_e_industria");
                sql.AppendLine(", nombre_fantacia=@nombre_fantacia");
                sql.AppendLine(", direccion=@direccion");
                sql.AppendLine(", codigo_insercion_maps=@codigo_insercion_maps");
                sql.AppendLine(", whatsapp=@whatsapp");
                sql.AppendLine(", cuit_responsable=@cuit_responsable");
                sql.AppendLine(", mail=@mail");
                sql.AppendLine(", cel=@cel");
                sql.AppendLine(", estado=@estado");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine(", id_categoria=@id_categoria");
                sql.AppendLine(", responsablenombre=@responsablenombre");
                sql.AppendLine(", fotos=@fotos");
                sql.AppendLine("WHERE");
                sql.AppendLine("cuit=@cuit");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@razon_social", obj.razon_social);
                    cmd.Parameters.AddWithValue("@nro_comercio_e_industria", obj.nro_comercio_e_industria);
                    cmd.Parameters.AddWithValue("@nombre_fantacia", obj.nombre_fantacia);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@codigo_insercion_maps", obj.codigo_insercion_maps);
                    cmd.Parameters.AddWithValue("@whatsapp", obj.whatsapp);
                    cmd.Parameters.AddWithValue("@cuit_responsable", obj.cuit_responsable);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@cel", obj.cel);
                    cmd.Parameters.AddWithValue("@estado", "Pendiente");
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", obj.id_categoria);
                    cmd.Parameters.AddWithValue("@responsablenombre", obj.responsablenombre);
                    cmd.Parameters.AddWithValue("@fotos", obj.images);



                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CambioEstado(string cuit, string estado)
        {
            try
            {
                string sql = 
                    @"UPDATE Tur_comercio SET estado=@estado
                      WHERE cuit=@cuit";
                
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(string cuit)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tur_comercio ");
                sql.AppendLine("WHERE cuit=@cuit");
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

