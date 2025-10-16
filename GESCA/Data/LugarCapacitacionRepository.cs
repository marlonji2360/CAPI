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
    public class LugarCapacitacionRepository
    {
        public List<LugarCapacitacion> MostrarLugarCapacitacion()
        {
            var list = new List<LugarCapacitacion>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new LugarCapacitacion
                        {
                            IdLugar = Convert.ToInt32(rd["IdLugar"]),
                            Lugar = rd["Lugar"] == DBNull.Value ? null : rd["Lugar"].ToString()                          

                        });
                    }
                }
            }
            return list;
        }

        public LugarCapacitacion BuscarLugarCapacitacionPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_GetById", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdLugar", SqlDbType.Int).Value = id;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new LugarCapacitacion
                        {
                            IdLugar = Convert.ToInt32(rd["IdLugar"]),
                            Lugar = rd["Lugar"] == DBNull.Value ? null : rd["Lugar"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int InsertarLugarCapacitacion(LugarCapacitacion c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Lugar", (object)c.Lugar ?? DBNull.Value);
                
                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
        }

        public void ActualizarLugarCapacitacion(LugarCapacitacion c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_Update", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLugar", c.IdLugar);
                cmd.Parameters.AddWithValue("@Lugar", (object)c.Lugar ?? DBNull.Value);                
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarLugarCapacitacionPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLugar", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
