using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class LugarLugarCapacitacionController
    {
        public List<LugarCapacitacion> MostrarLugarCapacitacion()
        {
            LugarCapacitacionRepository LugarCapacitacionRepository = new LugarCapacitacionRepository();
            var list = new List<LugarCapacitacion>();
            list = LugarCapacitacionRepository.MostrarLugarCapacitacion();
            return list;
        }

        public LugarCapacitacion BuscarLugarCapacitacionPorId(int id)
        {
            LugarCapacitacion LugarCapacitacion = new LugarCapacitacion();
            LugarCapacitacionRepository LugarCapacitacionRepository = new LugarCapacitacionRepository();
            return LugarCapacitacion = LugarCapacitacionRepository.BuscarLugarCapacitacionPorId((int)id);
        }

        public int InsertarLugarCapacitacion(LugarCapacitacion c)
        {
            int id;
            LugarCapacitacionRepository LugarCapacitacionRepository = new LugarCapacitacionRepository();
            return id = LugarCapacitacionRepository.InsertarLugarCapacitacion(c);
        }

        public void ActualizarLugarCapacitacion(LugarCapacitacion c)
        {
            LugarCapacitacionRepository LugarCapacitacionRepository = new LugarCapacitacionRepository();
            LugarCapacitacionRepository.ActualizarLugarCapacitacion(c);
        }

        public void EliminarLugarCapacitacionPorId(int id)
        {
            LugarCapacitacionRepository LugarCapacitacionRepository = new LugarCapacitacionRepository();
            LugarCapacitacionRepository.EliminarLugarCapacitacionPorId(id);
        }
    }
}
