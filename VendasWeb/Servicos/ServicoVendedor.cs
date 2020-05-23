using System.Collections.Generic;
using VendasWeb.Data;
using VendasWeb.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Servicos
{
    public class ServicoVendedor
    {
        private readonly VendasWebContext _context;

        public ServicoVendedor(VendasWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> EncontrarTodos()
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor BuscarPorId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(v => v.Id == id);
        }

        public void Remover(int id)
        {
            var v = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(v);
            _context.SaveChanges();
        }
    }
}
