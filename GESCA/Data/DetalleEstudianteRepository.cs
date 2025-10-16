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
    public class DetalleEstudianteRepository
    {
        public int InsertarDetalleEstudiantes(Estudiante c, DetalleEstudiante d)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleEstudiantes_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificacion", (object)c.Identificacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodigoEmpleado", (object)c.CodigoEmpleado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Convenio", (object)c.Convenio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreEmpresa", (object)c.NombreEmpresa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreCompleto", (object)c.NombreCompleto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ubicacion", (object)c.Ubicacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gerencia", (object)c.Ubicacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notas", (object)d.Notas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Grupo", (object)d.Grupo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Capacitaciones_IdCapacitaciones", (object)d.Capacitaciones_IdCapacitaciones ?? DBNull.Value);
                
                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
            }

        public void EliminarDetalleEstuditanes(int idCapacitacion)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleEstudiantes_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCapacitacion", idCapacitacion);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
