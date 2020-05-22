using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;

        public VendedoresController(ServicoVendedor servicoVendedor)
        {
            _servicoVendedor = servicoVendedor;
        }
        public IActionResult Index()
        {
            var list = _servicoVendedor.EncontrarTodos();
            return View(list);
        }
    }
}