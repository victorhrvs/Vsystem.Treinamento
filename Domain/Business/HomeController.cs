using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Controllers
{
    public class HomeController : Controller
    {

        private readonly TreinamentoContext _context;

        public HomeController(TreinamentoContext context)
        {
            _context = context;
        }

        public  IActionResult Resultado(string pesquisa)
        {
            var resultado = _context.Alunos
                        .Include(x => x.EnderecoFkNavigation)
                        .Where(x => x.Nome == pesquisa || x.EnderecoFkNavigation.Address == pesquisa || x.EnderecoFkNavigation.Uf == pesquisa)
                        .ToList();


            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
