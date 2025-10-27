using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Models
{
    public class DetalleEstudiante
    {
        public int IdDetalleEstudiante { get; set; }
        public decimal Notas { get; set; }
        public string Grupo { get; set; }
        public int Estudiante_IdEstudiante { get; set; }
        public int Capacitaciones_IdCapacitaciones { get; set; }
    }
}
