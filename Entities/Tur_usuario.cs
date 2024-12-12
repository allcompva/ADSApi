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
    public class Tur_usuario : DALBase
    {
        public Guid id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string provider { get; set; }
        public bool habilitado { get; set; }

        public Tur_usuario()
        {



        }

        private static Tur_usuario mapeo(SqlDataReader dr)
        {

            Tur_usuario obj = new Tur_usuario();

            if (dr.HasRows)
            {


                int id = dr.GetOrdinal("id");
                int email = dr.GetOrdinal("email");
                int password = dr.GetOrdinal("password");
                int provider = dr.GetOrdinal("provider");
                int habiliado = dr.GetOrdinal("habilitado");
                while (dr.Read())
                {
                    obj = new Tur_usuario();

                    if (!dr.IsDBNull(id)) { obj.id = dr.GetGuid(id); }
                    if (!dr.IsDBNull(email)) { obj.email = dr.GetString(email); }
                    if (!dr.IsDBNull(password)) { obj.password = dr.GetString(password); }
                    if (!dr.IsDBNull(provider))
                    {
                        obj.provider = dr.GetString(provider);
                    }
                    if (!dr.IsDBNull(habiliado)) { obj.habilitado = dr.GetBoolean(habiliado); }
                    break;
                }
            }
            return obj;
        }


        public static Tur_usuario getByEmail(string email)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Tur_usuarios WHERE email=@email");
                Tur_usuario obj = new Tur_usuario();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    obj = mapeo(dr);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int registro(string email, string password)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tur_usuarios(");
                sql.AppendLine("email");
                sql.AppendLine(", password");
                // sql.AppendLine(", provider");
                sql.AppendLine(", habilitado");

                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine(" @email");
                sql.AppendLine(", @password");
                // sql.AppendLine(", @provider");
                sql.AppendLine(", @habilitado");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    //TODO: cambiar provider cuando se implemente login con google
                    // cmd.Parameters.AddWithValue("@provider", null);
                    cmd.Parameters.AddWithValue("@habilitado", true);
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


    }
}

