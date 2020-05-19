﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List <Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Name = "Eletronics" });
            list.Add(new Departamento { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}