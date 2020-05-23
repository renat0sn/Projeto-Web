using System;
using System.Collections.Generic;
using VendasWeb.Models;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Data;

namespace VendasWeb.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebContext _context;

        public ServicoDepartamento(VendasWebContext context)
        {
            _context = context;
        }

        public IEnumerable<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
