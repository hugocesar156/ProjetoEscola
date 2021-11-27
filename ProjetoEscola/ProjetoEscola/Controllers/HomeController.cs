using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
