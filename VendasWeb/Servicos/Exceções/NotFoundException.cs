using System;

namespace VendasWeb.Servicos.Exceções
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
