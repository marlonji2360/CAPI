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
    public class CatalogosRepository
    {
        public List<LugarCapacitacion> Lugares()
        {
            var list = new List<LugarCapacitacion>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_LugarCapacitacion_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new LugarCapacitacion
                        {
                            IdLugar = Convert.ToInt32(rd["IdLugar"]),
                            Lugar = rd["Lugar"].ToString()
                        });
            }
            return list;
        }

        public List<Capacitador> Capacitadores()
        {
            var list = new List<Capacitador>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_Capacitador_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new Capacitador
                        {
                            IdCapacitador = Convert.ToInt32(rd["IdCapacitador"]),
                            NombreCompleto = rd["NombreCompleto"].ToString()
                        });
            }
            return list;
        }

        public List<Tema> Temas()
        {
            var list = new List<Tema>();
            using (var cn = Db.Create())
            using (var cmd = new SqlCommand("dbo.sp_TemasDesarrollados_List", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new Tema
                        {
                            IdTema = Convert.ToInt32(rd["IdTema"]),
                            Nombre = rd["Tema"].ToString()
                        });
            }
            return list;
        }
    }
}
