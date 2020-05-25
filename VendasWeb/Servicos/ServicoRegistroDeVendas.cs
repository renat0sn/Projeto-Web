using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Data;
using VendasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Servicos
{
    public class ServicoRegistroDeVendas
    {
        private readonly VendasWebContext _context;

        public ServicoRegistroDeVendas(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVendas>> BuscarPorDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento,RegistroDeVendas>>> BuscarPorDataAgrupadoAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
