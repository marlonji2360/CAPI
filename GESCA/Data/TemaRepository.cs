using GESCA.Infrastructure;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Data
{
    public class TemaRepository
    {
        public List<Tema> MostrarTema()
        {
            var list = new List<Tema>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Tema
                        {
                            IdTema = Convert.ToInt32(rd["IdTema"]),
                            Nombre = rd["Tema"] == DBNull.Value ? null : rd["Tema"].ToString()

                        });
                    }
                }
            }
            return list;
        }

        public Tema BuscarTemaPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_GetById", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdTema", SqlDbType.Int).Value = id;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Tema
                        {
                            IdTema = Convert.ToInt32(rd["IdTema"]),
                            Nombre = rd["Tema"] == DBNull.Value ? null : rd["Tema"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int InsertarTema(Tema c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tema", (object)c.Nombre ?? DBNull.Value);

                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
        }

        public void ActualizarTema(Tema c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_Update", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTema", c.IdTema);
                cmd.Parameters.AddWithValue("@Tema", (object)c.Nombre ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarTemaPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTema", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
