using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Models
{
    public class Capacitacion
    {
        public int IdCapacitacion { get; set; }
        public DateTime? FechaInicial { get; set; }      
        public DateTime? FechaFinal { get; set; }      
        public int? DuracionHrs { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFinal { get; set; }
        public string Estado { get; set; }
        public string TipoActividad { get; set; }
        public int LugarCapacitacion_IdLugar { get; set; }    
        public int Tema_IdTema { get; set; }
        public string Lugar { get; set; }
        public string Tema { get; set; }
    }
}
