using System;

namespace VendasWeb.Servicos.Exceções
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
