using GESCA.Data;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESCA.Controllers
{
    public class TemaController
    {
        public List<Tema> MostrarTema()
        {
            TemaRepository TemaRepository = new TemaRepository();
            var list = new List<Tema>();
            list = TemaRepository.MostrarTema();
            return list;
        }

        public Tema BuscarTemaPorId(int id)
        {
            Tema Tema = new Tema();
            TemaRepository TemaRepository = new TemaRepository();
            return Tema = TemaRepository.BuscarTemaPorId((int)id);
        }

        public int InsertarTema(Tema c)
        {
            int id;
            TemaRepository TemaRepository = new TemaRepository();
            return id = TemaRepository.InsertarTema(c);
        }

        public void ActualizarTema(Tema c)
        {
            TemaRepository TemaRepository = new TemaRepository();
            TemaRepository.ActualizarTema(c);
        }

        public void EliminarTemaPorId(int id)
        {
            TemaRepository TemaRepository = new TemaRepository();
            TemaRepository.EliminarTemaPorId(id);
        }
    }
}
