using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADSWebApi.Entities
{
public class Tur_movimientos_comercio : DALBase
{
public int id { get; set; }
public DateTime fecha { get; set; }
public int evento { get; set; }
public int cuit_comercio { get; set; }
public int id_usuario_interno { get; set; }

public Tur_movimientos_comercio()
{
id = 0;
fecha = DateTime.Now;
evento = 0;
cuit_comercio = 0;
id_usuario_interno = 0;
}

private static List<Tur_movimientos_comercio> mapeo(SqlDataReader dr)
{
List<Tur_movimientos_comercio> lst = new List<Tur_movimientos_comercio>();
Tur_movimientos_comercio obj;
if (dr.HasRows)
{
int id = dr.GetOrdinal("id");
int fecha = dr.GetOrdinal("fecha");
int evento = dr.GetOrdinal("evento");
int cuit_comercio = dr.GetOrdinal("cuit_comercio");
int id_usuario_interno = dr.GetOrdinal("id_usuario_interno");
while (dr.Read())
{
obj = new Tur_movimientos_comercio();
if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
if (!dr.IsDBNull(fecha)) { obj.fecha = dr.GetDateTime(fecha); }
if (!dr.IsDBNull(evento)) { obj.evento = dr.GetInt32(evento); }
if (!dr.IsDBNull(cuit_comercio)) { obj.cuit_comercio = dr.GetInt32(cuit_comercio); }
if (!dr.IsDBNull(id_usuario_interno)) { obj.id_usuario_interno = dr.GetInt32(id_usuario_interno); }
lst.Add(obj);
}
}
return lst;
}

public static List<Tur_movimientos_comercio> read()
{
try
{
List<Tur_movimientos_comercio> lst = new List<Tur_movimientos_comercio>();
using (SqlConnection con = GetConnection())
{
SqlCommand cmd = con.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = "SELECT *FROM Tur_movimientos_comercio";
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

public static Tur_movimientos_comercio getByPk(
int id)
{
try
{
StringBuilder sql = new StringBuilder();
sql.AppendLine("SELECT *FROM Tur_movimientos_comercio WHERE");
sql.AppendLine("id = @id");
Tur_movimientos_comercio obj = null;
using (SqlConnection con = GetConnection())
{
SqlCommand cmd = con.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = sql.ToString();
cmd.Parameters.AddWithValue("@id", id);
cmd.Connection.Open();
SqlDataReader dr = cmd.ExecuteReader();
List<Tur_movimientos_comercio> lst = mapeo(dr);
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

public static int insert(Tur_movimientos_comercio obj)
{
try
{
StringBuilder sql = new StringBuilder();
sql.AppendLine("INSERT INTO Tur_movimientos_comercio(");
sql.AppendLine("fecha");
sql.AppendLine(", evento");
sql.AppendLine(", cuit_comercio");
sql.AppendLine(", id_usuario_interno");
sql.AppendLine(")");
sql.AppendLine("VALUES");
sql.AppendLine("(");
sql.AppendLine("@fecha");
sql.AppendLine(", @evento");
sql.AppendLine(", @cuit_comercio");
sql.AppendLine(", @id_usuario_interno");
sql.AppendLine(")");
sql.AppendLine("SELECT SCOPE_IDENTITY()");
using (SqlConnection con = GetConnection())
{
SqlCommand cmd = con.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = sql.ToString();
cmd.Parameters.AddWithValue("@fecha", obj.fecha);
cmd.Parameters.AddWithValue("@evento", obj.evento);
cmd.Parameters.AddWithValue("@cuit_comercio", obj.cuit_comercio);
cmd.Parameters.AddWithValue("@id_usuario_interno", obj.id_usuario_interno);
cmd.Connection.Open();
return Convert.ToInt32(cmd.ExecuteScalar());
}
}
catch (Exception ex)
{
throw ex;
}
}

public static void update(Tur_movimientos_comercio obj)
{
try
{
StringBuilder sql = new StringBuilder();
sql.AppendLine("UPDATE  Tur_movimientos_comercio SET");
sql.AppendLine("fecha=@fecha");
sql.AppendLine(", evento=@evento");
sql.AppendLine(", cuit_comercio=@cuit_comercio");
sql.AppendLine(", id_usuario_interno=@id_usuario_interno");
sql.AppendLine("WHERE");
sql.AppendLine("id=@id");
using (SqlConnection con = GetConnection())
{
SqlCommand cmd = con.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = sql.ToString();
cmd.Parameters.AddWithValue("@fecha", obj.fecha);
cmd.Parameters.AddWithValue("@evento", obj.evento);
cmd.Parameters.AddWithValue("@cuit_comercio", obj.cuit_comercio);
cmd.Parameters.AddWithValue("@id_usuario_interno", obj.id_usuario_interno);
cmd.Connection.Open();
cmd.ExecuteNonQuery();
}
}
catch (Exception ex)
{
throw ex;
}
}

public static void delete(Tur_movimientos_comercio obj)
{
try
{
StringBuilder sql = new StringBuilder();
sql.AppendLine("DELETE  Tur_movimientos_comercio ");
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

