using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class DetalleCapacitadorController
    {
        public int InsertarDetalleCapacitador(int idCapacitaciones, int idCapacitador)
        {
            int id;
            DetalleCapacitadorRepository detalleCapacitadorRepository = new DetalleCapacitadorRepository();
            return id=detalleCapacitadorRepository.InsertarDetalleCapacitador(idCapacitaciones, idCapacitador);
        }

        public void ActualizarDetalleCapacitador(DetalleCapacitador d)
        {
            DetalleCapacitadorRepository detalleCapacitadorRepository = new DetalleCapacitadorRepository();
            detalleCapacitadorRepository.ActualizarDetalleCapacitador(d);
        }

        public void EliminarPorCapacitacion(int Capacitaciones_IdCapacitaciones)
        {
            DetalleCapacitadorRepository detalleCapacitadorRepository = new DetalleCapacitadorRepository();
            detalleCapacitadorRepository.EliminarPorCapacitacion(Capacitaciones_IdCapacitaciones);
        }
    }
}
