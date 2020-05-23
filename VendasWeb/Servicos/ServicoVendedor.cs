using System.Collections.Generic;
using VendasWeb.Data;
using VendasWeb.Models;
using System.Linq;

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
    }
}
