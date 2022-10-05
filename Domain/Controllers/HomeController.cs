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
            var alunos = _context.Alunos.Where(s => s.Nome == pesquisa)
                        .Include(s => s.EnderecoFkNavigation)
                        .ToList();

            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }



    }
}
