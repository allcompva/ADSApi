using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities

{
    public class Tur_publicaciones : DALBase
    {
        public int id { get; set; }
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string resenia { get; set; }
        public string ubicacion { get; set; }
        public string georeferencia { get; set; }
        public string whatsapp { get; set; }
        public string descripcion { get; set; }
        public bool publicada { get; set; }
        public string img { get; set; }
        public string id_comercio { get; set; }
        public string fotos { get; set; }
        public int is_favorite { get; set; }

        public Tur_publicaciones()
        {
            id = 0;
            id_categoria = 0;
            nombre = string.Empty;
            resenia = string.Empty;
            ubicacion = string.Empty;
            georeferencia = string.Empty;
            whatsapp = string.Empty;
            descripcion = string.Empty;
            publicada = false;
            img = string.Empty;
            id_comercio = string.Empty;
            fotos = string.Empty;
            is_favorite = 0;
        }

        private static List<Tur_publicaciones> mapeo(SqlDataReader dr)
        {
            List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
            Tur_publicaciones obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_categoria = dr.GetOrdinal("id_categoria");
                int nombre = dr.GetOrdinal("nombre");
                int resenia = dr.GetOrdinal("resenia");
                int ubicacion = dr.GetOrdinal("ubicacion");
                int georeferencia = dr.GetOrdinal("georeferencia");
                int whatsapp = dr.GetOrdinal("whatsapp");
                int descripcion = dr.GetOrdinal("descripcion");
                int publicada = dr.GetOrdinal("publicada");
                int img = dr.GetOrdinal("img");
                int id_comercio = dr.GetOrdinal("id_comercio");
                int fotos = dr.GetOrdinal("fotos");
                int is_favorite = dr.GetOrdinal("is_favorite");
                while (dr.Read())
                {
                    obj = new Tur_publicaciones();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_categoria)) { obj.id_categoria = dr.GetInt32(id_categoria); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(resenia)) { obj.resenia = dr.GetString(resenia); }
                    if (!dr.IsDBNull(ubicacion)) { obj.ubicacion = dr.GetString(ubicacion); }
                    if (!dr.IsDBNull(georeferencia)) { obj.georeferencia = dr.GetString(georeferencia); }
                    if (!dr.IsDBNull(whatsapp)) { obj.whatsapp = dr.GetString(whatsapp); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(publicada)) { obj.publicada = dr.GetBoolean(publicada); }
                    if (!dr.IsDBNull(img)) { obj.img = dr.GetString(img); }
                    if (!dr.IsDBNull(id_comercio)) { obj.id_comercio = dr.GetString(id_comercio); }
                    if (!dr.IsDBNull(fotos)) { obj.fotos = dr.GetString(fotos); }
                    if (!dr.IsDBNull(is_favorite)) { obj.is_favorite = dr.GetInt32(is_favorite); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tur_publicaciones> read()
        {
            try
            {
                List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Tur_publicaciones";
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
        public static List<Tur_publicaciones> GetByCategoria(int idCate)
        {
            try
            {
                List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM Tur_publicaciones
                                        WHERE id_categoria=@id_categoria";

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
        public static List<Tur_publicaciones> GetByCategoriaMail(int idCate, string mail)
        {
            try
            {
                List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
                            p.*,
                            CASE 
                                WHEN f.id_publicacion IS NOT NULL THEN 1
                                ELSE 0
                            END AS is_favorite
                        FROM 
                            tur_publicaciones p
                        LEFT JOIN 
                            favoritos f ON p.id = f.id_publicacion AND f.mail=@mail

                        WHERE 
                         p.id_categoria = @cat";

                    cmd.Parameters.AddWithValue("@cat", idCate);
                    cmd.Parameters.AddWithValue("@mail", mail);

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
        public static List<Tur_publicaciones> GetByMail(string mail)
        {
            try
            {
                List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
                            p.*,
                            CASE 
                                WHEN f.id_publicacion IS NOT NULL THEN 1
                                ELSE 0
                            END AS is_favorite
                        FROM 
                            tur_publicaciones p
                        INNER JOIN 
                            favoritos f ON p.id = f.id_publicacion AND f.mail=@mail";

                    cmd.Parameters.AddWithValue("@mail", mail);

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
        public static List<Tur_publicaciones> GetByComercio(string cuit)
        {
            try
            {
                List<Tur_publicaciones> lst = new List<Tur_publicaciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
                            p.*,
                            CASE 
                                WHEN f.id_publicacion IS NOT NULL THEN 1
                                ELSE 0
                            END AS is_favorite
                        FROM 
                            tur_publicaciones p
                        LEFT JOIN 
                            favoritos f ON p.id = f.id_publicacion AND f.mail=@mail
                        WHERE id_comercio=@id_comercio";

                    cmd.Parameters.AddWithValue("@id_comercio", cuit);
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
        public static Tur_publicaciones getByPk(string cuit)
        {
            try
            {
                Entities.Tur_publicaciones obj = null;
                using (SqlConnection con = GetConnection())
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
                            p.*,
                            CASE 
                                WHEN f.id_publicacion IS NOT NULL THEN 1
                                ELSE 0
                            END AS is_favorite
                        FROM 
                            tur_publicaciones p
                        LEFT JOIN 
                            favoritos f ON p.id = f.id_publicacion AND f.mail=@mail
                        WHERE id = @cuit";

                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_publicaciones> lst = mapeo(dr);
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

        public static Tur_publicaciones getByDetails(string cuit, string mail)
        {
            try
            {
                Tur_publicaciones obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
                            p.*,
                            CASE 
                                WHEN f.id_publicacion IS NOT NULL THEN 1
                                ELSE 0
                            END AS is_favorite
                        FROM 
                            tur_publicaciones p
                        LEFT JOIN 
                            favoritos f ON p.id = f.id_publicacion AND f.mail=@mail
                        WHERE id_comercio = @cuit";
                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Parameters.AddWithValue("@mail", mail);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tur_publicaciones> lst = mapeo(dr);
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

        public static int insert(Tur_publicaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_publicaciones(");
                sql.AppendLine("id_categoria");
                sql.AppendLine(", nombre");
                sql.AppendLine(", resenia");
                sql.AppendLine(", ubicacion");
                sql.AppendLine(", georeferencia");
                sql.AppendLine(", whatsapp");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", publicada");
                sql.AppendLine(", fotos");
                sql.AppendLine(", id_comercio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_categoria");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @resenia");
                sql.AppendLine(", @ubicacion");
                sql.AppendLine(", @georeferencia");
                sql.AppendLine(", @whatsapp");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @publicada");
                sql.AppendLine(", @fotos");
                sql.AppendLine(", @id_comercio");

                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_categoria", obj.id_categoria);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
                    cmd.Parameters.AddWithValue("@georeferencia", obj.georeferencia);
                    cmd.Parameters.AddWithValue("@whatsapp", obj.whatsapp);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@publicada", obj.publicada);
                    cmd.Parameters.AddWithValue("@fotos", obj.fotos);
                    cmd.Parameters.AddWithValue("@id_comercio", obj.id_comercio);

                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tur_publicaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tur_publicaciones SET");
                sql.AppendLine("id_categoria=@id_categoria");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", resenia=@resenia");
                sql.AppendLine(", en_favoritos=@en_favoritos");
                sql.AppendLine(", ubicacion=@ubicacion");
                sql.AppendLine(", georeferencia=@georeferencia");
                sql.AppendLine(", whatsapp=@whatsapp");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine(", publicada=@publicada");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_categoria", obj.id_categoria);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
                    cmd.Parameters.AddWithValue("@georeferencia", obj.georeferencia);
                    cmd.Parameters.AddWithValue("@whatsapp", obj.whatsapp);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@publicada", obj.publicada);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Tur_publicaciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tur_publicaciones ");
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
        public static void deleteComercio(string cuit)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE Tur_publicaciones ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_comercio=@cuit");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cuit", cuit);
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

