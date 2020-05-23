using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;
using VendasWeb.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }
        public IActionResult Index()
        {
            var list = _servicoVendedor.EncontrarTodos();
            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new FormularioVendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _servicoVendedor.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remover(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _servicoVendedor.BuscarPorId(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            _servicoVendedor.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}