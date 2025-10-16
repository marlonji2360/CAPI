using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Models
{
    public class ParticipanteDiploma
    {
        public int IdEstudiante { get; set; }
        public string Identificacion { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreEmpresa { get; set; }
        public string Ubicacion { get; set; }
        public string Gerencia { get; set; }
        public string Puesto { get; set; }
        public string Grupo { get; set; }
        public int? Nota { get; set; }
    }
}
