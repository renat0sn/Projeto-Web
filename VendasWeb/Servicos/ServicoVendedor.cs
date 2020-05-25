using System.Collections.Generic;
using VendasWeb.Data;
using VendasWeb.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Servicos.Exceções;
using System.Threading.Tasks;

namespace VendasWeb.Servicos
{
    public class ServicoVendedor
    {
        private readonly VendasWebContext _context;

        public ServicoVendedor(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> EncontrarTodosAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarPorIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            var v = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(v);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
