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
    public class ParticipantesDiplomaRepository
    {
        public List<ParticipanteDiploma> ListByCapacitacion(int idCapacitacion)
        {
            var list = new List<ParticipanteDiploma>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_DetalleEstudiantes_ByCapacitacion", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Capacitaciones_IdCapacitaciones", SqlDbType.Int).Value = idCapacitacion;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new ParticipanteDiploma
                        {
                            IdEstudiante = Convert.ToInt32(rd["IdEstudiante"]),
                            Identificacion = rd["Identificacion"]?.ToString(),
                            CodigoEmpleado = rd["CodigoEmpleado"]?.ToString(),
                            NombreCompleto = rd["NombreCompleto"]?.ToString(),
                            NombreEmpresa = rd["NombreEmpresa"]?.ToString(),
                            Ubicacion = rd["Ubicacion"]?.ToString(),
                            Gerencia = rd["Gerencia"]?.ToString(),
                            Puesto = rd["Puesto"]?.ToString(),
                            Grupo = rd["Grupo"]?.ToString(),
                            Nota = rd["Notas"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["Notas"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
