using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class CapacitadorController
    {
        public Capacitador BuscarCapacitadorPorIdDiploma(int id)
        {
            Capacitador Capacitador = new Capacitador();
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            return Capacitador = CapacitadorRepository.BuscarCapacitadorPorIdDiploma((int)id);

        }
        public List<Capacitador> MostrarCapacitador()
        {
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            var list = new List<Capacitador>();
            list = CapacitadorRepository.MostrarCapacitador();
            return list;
        }

        public Capacitador BuscarCapacitadorPorId(int id)
        {
            Capacitador Capacitador = new Capacitador();
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            return Capacitador = CapacitadorRepository.BuscarCapacitadorPorId((int)id);
        }

        public int InsertarCapacitador(Capacitador c)
        {
            int id;
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            return id = CapacitadorRepository.InsertarCapacitador(c);
        }

        public void ActualizarCapacitador(Capacitador c)
        {
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            CapacitadorRepository.ActualizarCapacitador(c);
        }

        public void EliminarCapacitadorPorId(int id)
        {
            CapacitadorRepository CapacitadorRepository = new CapacitadorRepository();
            CapacitadorRepository.EliminarCapacitadorPorId(id);
        }
    }
}
