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
    public class DetalleCapacitadorRepository
    {
        public int InsertarDetalleCapacitador(int idCapacitaciones, int idCapacitador)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleCapacitador_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Capacitador_IdCapacitador", SqlDbType.Int).Value = idCapacitador;
                cmd.Parameters.Add("@Capacitaciones_IdCapacitaciones", SqlDbType.Int).Value = idCapacitaciones;

                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);

                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
        }

        public void ActualizarDetalleCapacitador(DetalleCapacitador d)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleCapacitador_Update", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdDetallCapacitador", SqlDbType.Int).Value = d.IdDetallCapacitador;
                cmd.Parameters.Add("@Capacitador_IdCapacitador", SqlDbType.Int).Value = d.Capacitador_IdCapacitador;
                cmd.Parameters.Add("@Capacitaciones_IdCapacitaciones", SqlDbType.Int).Value = d.Capacitaciones_IdCapacitaciones;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPorCapacitacion(int Capacitaciones_IdCapacitaciones)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleCapacitador_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Capacitaciones_IdCapacitaciones", SqlDbType.Int).Value = Capacitaciones_IdCapacitaciones;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
