using DocumentFormat.OpenXml.Wordprocessing;
using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class CapacitacionController
    {
        public DataTable BuscarPorFecha(DateTime fechaDel, DateTime fechaAl)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var dt = new DataTable("CapacitacionDetalle");
            return dt = capacitacionRepository.BuscarPorFecha(fechaDel, fechaAl);
        }
        public DataTable BuscarPorCampo(string campo, string valor)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var dt = new DataTable("CapacitacionDetalle");
            return dt = capacitacionRepository.BuscarPorCampo(campo, valor);
        }

        public DataTable BuscarPorFechaTxt(DateTime fechaDel, DateTime fechaAl)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var dt = new DataTable("CapacitacionDetalle");
            return dt = capacitacionRepository.BuscarPorFechaTxt(fechaDel, fechaAl);
        }
        public DataTable BuscarPorCampoTxt(string campo, string valor)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var dt = new DataTable("CapacitacionDetalle");
            return dt = capacitacionRepository.BuscarPorCampoTxt(campo, valor);
        }
        public DataTable BuscarPorId(int idCapacitaciones)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var dt = new DataTable("CapacitacionDetalle");
            return dt = capacitacionRepository.BuscarPorId(idCapacitaciones);
        }
        public List<Capacitacion> MostrarCapacitaciones()
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            var list = new List<Capacitacion>();
            list = capacitacionRepository.MostrarCapacitaciones();
            return list;
        }

        public Capacitacion BuscarCapacitacionPorId(int id)
        {
            Capacitacion capacitacion = new Capacitacion();
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            return capacitacion = capacitacionRepository.BuscarCapacitacionPorId((int)id);
        }

        public int InsertarCapacitacion(Capacitacion c)
        {
            int id;
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            return id=capacitacionRepository.InsertarCapacitacion(c);
        }

        public void ActualizarCapacitacion(Capacitacion c)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            capacitacionRepository.ActualizarCapacitacion(c);
        }

        public void EliminarCapacitacionPorId(int id)
        {
            CapacitacionRepository capacitacionRepository = new CapacitacionRepository();
            capacitacionRepository.EliminarCapacitacionPorId(id);
        }
    }
}
