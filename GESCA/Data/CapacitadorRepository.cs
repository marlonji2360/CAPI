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
    public class CapacitadorRepository
    {
        public Capacitador BuscarCapacitadorPorIdDiploma(int id)
        {
            const string sql = @"
                                     select top 1 c.*
                                     from dbo.Capacitador c 
                                     inner join dbo.DetalleCapacitador d on c.IdCapacitador=d.Capacitador_IdCapacitador
                                     inner join dbo.Capacitaciones a on a.IdCapacitaciones=d.Capacitaciones_IdCapacitaciones
                                     where a.IdCapacitaciones = @id";
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IdCapacitaciones", SqlDbType.Int).Value = id;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Capacitador
                        {
                            IdCapacitador = Convert.ToInt32(rd["IdCapacitaciones"]),                           
                            NombreCompleto = rd["NombreCompleto"] == DBNull.Value ? null : rd["NombreCompleto"].ToString(),
                            NombreEmpresa = rd["NombreEmpresa"] == DBNull.Value ? null : rd["NombreEmpresa"].ToString()
                            
                        };
                    }
                }
            }
            return null;
        }
        public List<Capacitador> MostrarCapacitador()
        {
            var list = new List<Capacitador>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Capacitador
                        {
                            IdCapacitador = Convert.ToInt32(rd["IdCapacitador"]),                            
                            NombreCompleto = rd["NombreCompleto"] == DBNull.Value ? null : rd["NombreCompleto"].ToString(),
                            NombreEmpresa = rd["NombreEmpresa"] == DBNull.Value ? null : rd["NombreEmpresa"].ToString()
                           
                           
                        });
                    }
                }
            }
            return list;
        }

        public Capacitador BuscarCapacitadorPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_GetById", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCapacitador", SqlDbType.Int).Value = id;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Capacitador
                        {
                            IdCapacitador = Convert.ToInt32(rd["IdCapacitador"]),                            
                            NombreCompleto = rd["NombreCompleto"] == DBNull.Value ? null : rd["NombreCompleto"].ToString(),
                            NombreEmpresa = rd["NombreEmpresa"] == DBNull.Value ? null : rd["NombreEmpresa"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int InsertarCapacitador(Capacitador c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCompleto", (object)c.NombreCompleto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreEmpresa", (object)c.NombreEmpresa ?? DBNull.Value);
                
                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
        }

        public void ActualizarCapacitador(Capacitador c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_Update", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCapacitador", c.IdCapacitador);
                cmd.Parameters.AddWithValue("@NombreCompleto", (object)c.NombreCompleto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreEmpresa", (object)c.NombreEmpresa ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCapacitadorPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCapacitador", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
