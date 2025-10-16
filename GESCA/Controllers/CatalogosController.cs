using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class CatalogosController
    {
        public List<LugarCapacitacion> Lugares()
        {
            var list = new List<LugarCapacitacion>();
            CatalogosRepository catalogosRepository = new CatalogosRepository();
            return list = catalogosRepository.Lugares();
            
        }

        public List<Capacitador> Capacitadores()
        {
            var list = new List<Capacitador>();
            CatalogosRepository catalogosRepository = new CatalogosRepository();
            return list = catalogosRepository.Capacitadores();
        }

        public List<Tema> Temas()
        {
            var list = new List<Tema>();
            CatalogosRepository catalogosRepository = new CatalogosRepository();
            return list = catalogosRepository.Temas();

        }
    }
}
