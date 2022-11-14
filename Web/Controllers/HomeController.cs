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
            Business.HomeBusiness resultado = new Business.HomeBusiness(_context, pesquisa);



            if (resultado.Alunos == null)
            {
                return NotFound();
            }

            return View(resultado.Alunos);
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
