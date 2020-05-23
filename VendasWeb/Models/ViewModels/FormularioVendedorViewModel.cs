using System.Collections.Generic;

namespace VendasWeb.Models.ViewModels
{
    public class FormularioVendedorViewModel
    {
        public Vendedor Vendedor { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }
    }
}
