using System;
using System.Collections.Generic;
using VendasWeb.Models;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebContext _context;

        public ServicoDepartamento(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
