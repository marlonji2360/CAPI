using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class DetalleEstudianteController
    {
        public int InsertarDetalleEstudiantes(Estudiante c, DetalleEstudiante d)
        {
            DetalleEstudianteRepository detalleEstudianteRepository = new DetalleEstudianteRepository();
            return detalleEstudianteRepository.InsertarDetalleEstudiantes(c,d);
        }

        public void EliminarDetalleEstuditanes(int idCapacitacion)
        {
            DetalleEstudianteRepository detalleEstudianteRepository = new DetalleEstudianteRepository();
            detalleEstudianteRepository.EliminarDetalleEstuditanes(idCapacitacion);
        }
    }
}
