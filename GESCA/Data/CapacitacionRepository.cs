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
    public class CapacitacionRepository
    {
        public DataTable BuscarPorFecha(DateTime fechaDel, DateTime fechaAl)
        {
            if (fechaDel.Date > fechaAl.Date)
                throw new ArgumentException("La fecha inicial no puede ser mayor que la final.");

            var dt = new DataTable("CapacitacionDetalle");

            const string sql = @"
                                    SELECT
                                        a.idCapacitaciones as Identificacion,
                                        CONVERT(varchar(8), a.FechaInicial, 112) AS [FECHA DE CAPACITACION],   -- yyyymmdd
                                        UPPER(b.Lugar)                           AS [LUGAR],
                                        UPPER(
                                            STUFF((
                                                SELECT DISTINCT ', ' + cap2.NombreCompleto
                                                FROM dbo.DetalleCapacitador dc2
                                                JOIN dbo.Capacitador cap2 ON cap2.IdCapacitador = dc2.Capacitador_IdCapacitador
                                                WHERE dc2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                                FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
                                        )                                         AS [CAPACITADOR],
                                        UPPER(c.Tema)                             AS [TEMA],
                                        UPPER(a.TipoActividad)                    AS [TIPO DE ACTIVIDAD],
                                        a.DuracionHrs                             AS [DURACION EN HORAS],

                                        -- <<< SOLO UN REGISTRO PARA ""CAPACITADO"" >>> (aquí uso Gerencia; cambia por el campo que quieras)
                                        UPPER((
                                            SELECT TOP 1 ISNULL(est2.Gerencia, '')
                                            FROM dbo.DetalleEstudiantes de2
                                            JOIN dbo.Estudiante est2 ON est2.IdEstudiante = de2.Estudiante_IdEstudiante
                                            WHERE de2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                            ORDER BY est2.Gerencia  -- o por est2.IdEstudiante si prefieres
                                        ))                                      AS [CAPACITADO],

                                        -- <<< CONCATENADO SIN REPETIR PARA ""PUESTO DE TRABAJO"" >>>
                                        UPPER(
                                            STUFF((
                                                SELECT DISTINCT ', ' + REPLACE(ISNULL(est3.Puesto,''), '*', '')
                                                FROM dbo.DetalleEstudiantes de3
                                                JOIN dbo.Estudiante est3 ON est3.IdEstudiante = de3.Estudiante_IdEstudiante
                                                WHERE de3.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                                FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
                                        )                                         AS [PUESTO DE TRABAJO],

                                        COUNT(DISTINCT de.idDetalleEstudiante)    AS total_capacitados

                                    FROM dbo.Capacitaciones a
                                    INNER JOIN dbo.TemasDesarrollados c  ON c.IdTema = a.TemasDesarrollados_IdTema
                                    INNER JOIN dbo.LugarCapacitacion b   ON b.IdLugar = a.LugarCapacitacion_IdLugar
                                    INNER JOIN dbo.DetalleEstudiantes de ON de.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                    WHERE a.FechaInicial between @Del AND @Al  -- opcional
                                    GROUP BY
                                        a.IdCapacitaciones, a.FechaInicial, b.Lugar, c.Tema, a.TipoActividad, a.DuracionHrs
                                    ORDER BY a.FechaInicial DESC, a.IdCapacitaciones;";

            using (var cn = Db.Create())
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.CommandType = CommandType.Text;
                da.SelectCommand.Parameters.Add("@Del", SqlDbType.Date).Value = fechaDel.Date;
                da.SelectCommand.Parameters.Add("@Al", SqlDbType.Date).Value = fechaAl.Date;

                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarPorFechaTxt(DateTime fechaDel, DateTime fechaAl)
        {
            if (fechaDel.Date > fechaAl.Date)
                throw new ArgumentException("La fecha inicial no puede ser mayor que la final.");

            var dt = new DataTable("CapacitacionDetalle");

            const string sql = @" SELECT
                                        CONVERT(varchar(8), a.FechaInicial, 112) +'&&'+  -- yyyymmdd
                                        UPPER(b.Lugar)                            +'&&'+
                                        UPPER(
                                            STUFF((
                                                SELECT DISTINCT ', ' + cap2.NombreCompleto
                                                FROM dbo.DetalleCapacitador dc2
                                                JOIN dbo.Capacitador cap2 ON cap2.IdCapacitador = dc2.Capacitador_IdCapacitador
                                                WHERE dc2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                                FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
                                        )                                          +'&&'+
                                        UPPER(c.Tema)                              +'&&'+
                                        UPPER(a.TipoActividad)                     +'&&'+
                                        CONVERT(VARCHAR,a.DuracionHrs )                             +'&&'+

                                        -- <<< SOLO UN REGISTRO PARA ""CAPACITADO"" >>> (aquí uso Gerencia; cambia por el campo que quieras)
                                        UPPER((
                                            SELECT TOP 1 ISNULL(est2.Gerencia, '')
                                            FROM dbo.DetalleEstudiantes de2
                                            JOIN dbo.Estudiante est2 ON est2.IdEstudiante = de2.Estudiante_IdEstudiante
                                            WHERE de2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                            ORDER BY est2.Gerencia  -- o por est2.IdEstudiante si prefieres
                                        ))                                       +'&&'+

                                        -- <<< CONCATENADO SIN REPETIR PARA ""PUESTO DE TRABAJO"" >>>
                                        UPPER(
                                            STUFF((
                                                SELECT DISTINCT ', ' + REPLACE(ISNULL(est3.Puesto,''), '*', '')
                                                FROM dbo.DetalleEstudiantes de3
                                                JOIN dbo.Estudiante est3 ON est3.IdEstudiante = de3.Estudiante_IdEstudiante
                                                WHERE de3.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                                FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
                                        )                                          +'&&'+

                                        CONVERT(VARCHAR,COUNT(DISTINCT de.idDetalleEstudiante))     +'&&' + +'&&'

                                    FROM dbo.Capacitaciones a
                                    INNER JOIN dbo.TemasDesarrollados c  ON c.IdTema = a.TemasDesarrollados_IdTema
                                    INNER JOIN dbo.LugarCapacitacion b   ON b.IdLugar = a.LugarCapacitacion_IdLugar
                                    INNER JOIN dbo.DetalleEstudiantes de ON de.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
                                    WHERE a.FechaInicial between @Del AND @Al  -- opcional
                                    GROUP BY
                                        a.IdCapacitaciones, a.FechaInicial, b.Lugar, c.Tema, a.TipoActividad, a.DuracionHrs
                                    ORDER BY a.FechaInicial DESC, a.IdCapacitaciones;";

            using (var cn = Db.Create())
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.CommandType = CommandType.Text;
                da.SelectCommand.Parameters.Add("@Del", SqlDbType.Date).Value = fechaDel.Date;
                da.SelectCommand.Parameters.Add("@Al", SqlDbType.Date).Value = fechaAl.Date;

                da.Fill(dt);
            }
            return dt;
        }
        public DataTable BuscarPorCampo(string campo, string valor)
        {
            var dt = new DataTable("CapacitacionDetalle");

            using (var cn = Db.Create())
            {

                string sql = @"
                                SELECT *
FROM (
SELECT
    a.IdCapacitaciones as Identificacion,
    CONVERT(varchar(8), a.FechaInicial, 112) AS [FECHA DE CAPACITACION],   -- yyyymmdd
    UPPER(b.Lugar)                           AS [LUGAR],
    UPPER(
        STUFF((
            SELECT DISTINCT ', ' + cap2.NombreCompleto
            FROM dbo.DetalleCapacitador dc2
            JOIN dbo.Capacitador cap2 ON cap2.IdCapacitador = dc2.Capacitador_IdCapacitador
            WHERE dc2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
            FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
    )                                         AS [CAPACITADOR],
    UPPER(c.Tema)                             AS [TEMA],
    UPPER(a.TipoActividad)                    AS [TIPO DE ACTIVIDAD],
    a.DuracionHrs                             AS [DURACION EN HORAS],

    -- <<< SOLO UN REGISTRO PARA ""CAPACITADO"" >>> (aquí uso Gerencia; cambia por el campo que quieras)
    UPPER((
        SELECT TOP 1 ISNULL(est2.Gerencia, '')
        FROM dbo.DetalleEstudiantes de2
        JOIN dbo.Estudiante est2 ON est2.IdEstudiante = de2.Estudiante_IdEstudiante
        WHERE de2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
        ORDER BY est2.Gerencia  -- o por est2.IdEstudiante si prefieres
    ))                                      AS [CAPACITADO],

    -- <<< CONCATENADO SIN REPETIR PARA ""PUESTO DE TRABAJO"" >>>
    UPPER(
        STUFF((
            SELECT DISTINCT ', ' + REPLACE(ISNULL(est3.Puesto,''), '*', '')
            FROM dbo.DetalleEstudiantes de3
            JOIN dbo.Estudiante est3 ON est3.IdEstudiante = de3.Estudiante_IdEstudiante
            WHERE de3.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
            FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
    )                                         AS [PUESTO DE TRABAJO],

    COUNT(DISTINCT de.idDetalleEstudiante)    AS NUMERO_PARTICIPANTES

FROM dbo.Capacitaciones a
INNER JOIN dbo.TemasDesarrollados c  ON c.IdTema = a.TemasDesarrollados_IdTema
INNER JOIN dbo.LugarCapacitacion b   ON b.IdLugar = a.LugarCapacitacion_IdLugar
INNER JOIN dbo.DetalleEstudiantes de ON de.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
-- WHERE a.IdCapacitaciones = @IdCapacitaciones  -- opcional
GROUP BY
    a.IdCapacitaciones, a.FechaInicial, b.Lugar, c.Tema, a.TipoActividad, a.DuracionHrs
) X
WHERE X." + campo+ " LIKE '%"+valor+"%'";
        
                                

                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;



                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable BuscarPorCampoTxt(string campo, string valor)
        {
            var dt = new DataTable("CapacitacionDetalle");

            using (var cn = Db.Create())
            {

                string sql = @"
                               SELECT [FECHA DE CAPACITACION] + '&&' +
[LUGAR] + '&&' +
[CAPACITADOR] + '&&' +
[TEMA] + '&&' +
[TIPO DE ACTIVIDAD] + '&&' +
convert(varchar,[DURACION EN HORAS]) + '&&' +
[CAPACITADO] + '&&' +
[PUESTO DE TRABAJO] + '&&' +
convert(varchar,NUMERO_PARTICIPANTES) + '&&' +
+ '&&' 
FROM (
SELECT
a.idCapacitaciones AS identificacion,
CONVERT(varchar(8), a.FechaInicial, 112) AS [FECHA DE CAPACITACION],   -- yyyymmdd
UPPER(b.Lugar)                           AS [LUGAR],
UPPER(
    STUFF((
        SELECT DISTINCT ', ' + cap2.NombreCompleto
        FROM dbo.DetalleCapacitador dc2
        JOIN dbo.Capacitador cap2 ON cap2.IdCapacitador = dc2.Capacitador_IdCapacitador
        WHERE dc2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
        FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
)                                         AS [CAPACITADOR],
UPPER(c.Tema)                             AS [TEMA],
UPPER(a.TipoActividad)                    AS [TIPO DE ACTIVIDAD],
a.DuracionHrs                             AS [DURACION EN HORAS],

-- <<< SOLO UN REGISTRO PARA ""CAPACITADO"" >>> (aquí uso Gerencia; cambia por el campo que quieras)
UPPER((
    SELECT TOP 1 ISNULL(est2.Gerencia, '')
    FROM dbo.DetalleEstudiantes de2
    JOIN dbo.Estudiante est2 ON est2.IdEstudiante = de2.Estudiante_IdEstudiante
    WHERE de2.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
    ORDER BY est2.Gerencia  -- o por est2.IdEstudiante si prefieres
))                                      AS [CAPACITADO],

-- <<< CONCATENADO SIN REPETIR PARA ""PUESTO DE TRABAJO"" >>>
UPPER(
    STUFF((
        SELECT DISTINCT ', ' + REPLACE(ISNULL(est3.Puesto,''), '*', '')
        FROM dbo.DetalleEstudiantes de3
        JOIN dbo.Estudiante est3 ON est3.IdEstudiante = de3.Estudiante_IdEstudiante
        WHERE de3.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
        FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')
)                                         AS [PUESTO DE TRABAJO],

COUNT(DISTINCT de.idDetalleEstudiante)    AS NUMERO_PARTICIPANTES

FROM dbo.Capacitaciones a
INNER JOIN dbo.TemasDesarrollados c  ON c.IdTema = a.TemasDesarrollados_IdTema
INNER JOIN dbo.LugarCapacitacion b   ON b.IdLugar = a.LugarCapacitacion_IdLugar
INNER JOIN dbo.DetalleEstudiantes de ON de.Capacitaciones_IdCapacitaciones = a.IdCapacitaciones
GROUP BY
a.IdCapacitaciones, a.FechaInicial, b.Lugar, c.Tema, a.TipoActividad, a.DuracionHrs
)    X
                                            WHERE X." + campo + " LIKE '%" + valor + "%'";

                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;



                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable BuscarPorId(int idCapacitaciones)
        {
            var dt = new DataTable("CapacitacionDetalle");
            using (var cn = Db.Create())
            using (var da = new SqlDataAdapter("dbo.sp_Capacitaciones_List_Id", cn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IdCapacitaciones", SqlDbType.Int).Value = idCapacitaciones;

                // ¡Listo! Llenamos el DataTable con el resultset del SP
                da.Fill(dt);
            }
            return dt;
        }
        public List<Capacitacion> MostrarCapacitaciones()
        {
            var list = new List<Capacitacion>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitaciones_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Capacitacion
                        {
                            IdCapacitacion = Convert.ToInt32(rd["IdCapacitacion"]),
                            FechaInicial = rd["FechaInicial"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rd["FechaInicial"]),
                            FechaFinal = rd["FechaFinal"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rd["FechaFinal"]),
                            DuracionHrs = rd["DuracionHrs"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["DuracionHrs"]),
                            HoraInicio = rd["HoraInicio"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)rd["HoraInicio"],
                            HoraFinal = rd["HoraFinal"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)rd["HoraFinal"],
                            Estado = rd["Estado"] == DBNull.Value ? null : rd["Estado"].ToString(),
                            TipoActividad = rd["TipoActividad"] == DBNull.Value ? null : rd["TipoActividad"].ToString(),
                            LugarCapacitacion_IdLugar = Convert.ToInt32(rd["LugarCapacitacion_IdLugar"]),                            
                            Tema_IdTema = Convert.ToInt32(rd["Tema_IdTema"])
                        });
                    }
                }
            }
            return list;
        }

        public Capacitacion BuscarCapacitacionPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitaciones_GetById", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCapacitaciones", SqlDbType.Int).Value = id;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Capacitacion
                        {
                            IdCapacitacion = Convert.ToInt32(rd["IdCapacitaciones"]),
                            FechaInicial = rd["FechaInicial"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rd["FechaInicial"]),
                            FechaFinal = rd["FechaFinal"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rd["FechaFinal"]),
                            DuracionHrs = rd["DuracionHrs"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["DuracionHrs"]),
                            HoraInicio = rd["HoraInicio"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)rd["HoraInicio"],
                            HoraFinal = rd["HoraFinal"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)rd["HoraFinal"],
                            Estado = rd["Estado"] == DBNull.Value ? null : rd["Estado"].ToString(),
                            TipoActividad = rd["TipoActividad"] == DBNull.Value ? null : rd["TipoActividad"].ToString(),
                            LugarCapacitacion_IdLugar = Convert.ToInt32(rd["LugarCapacitacion_IdLugar"]),                            
                            Tema_IdTema = Convert.ToInt32(rd["TemasDesarrollados_IdTema"]),
                            Tema = rd["Tema"] == DBNull.Value ? null : rd["Tema"].ToString(),
                            Lugar = rd["Lugar"] == DBNull.Value ? null : rd["Lugar"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int InsertarCapacitacion(Capacitacion c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitaciones_Insert", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicial", (object)c.FechaInicial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFinal", (object)c.FechaFinal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DuracionHrs", (object)c.DuracionHrs ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoraInicio", (object)c.HoraInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoraFinal", (object)c.HoraFinal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", (object)c.Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoActividad", (object)c.TipoActividad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LugarCapacitacion_IdLugar", c.LugarCapacitacion_IdLugar);                
                cmd.Parameters.AddWithValue("@TemasDesarrollados_IdTema", c.Tema_IdTema);
                var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pOut);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)pOut.Value;
            }
        }

        public void ActualizarCapacitacion(Capacitacion c)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitaciones_Update", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCapacitaciones", c.IdCapacitacion);
                cmd.Parameters.AddWithValue("@FechaInicial", (object)c.FechaInicial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFinal", (object)c.FechaFinal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DuracionHrs", (object)c.DuracionHrs ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoraInicio", (object)c.HoraInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoraFinal", (object)c.HoraFinal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", (object)c.Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoActividad", (object)c.TipoActividad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LugarCapacitacion_IdLugar", c.LugarCapacitacion_IdLugar);
                cmd.Parameters.AddWithValue("@TemasDesarrollados_IdTema", c.Tema_IdTema);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCapacitacionPorId(int id)
        {
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitaciones_Delete", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCapacitacion", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
