
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Business
{
    public class HomeBusiness
    {

        private readonly TreinamentoContext _context;

        public List<Entities.Aluno> Alunos { get; set; }
        public HomeBusiness(TreinamentoContext context, string pesquisa)
        {
            _context = context;
            Alunos = _context.Alunos
                        .Where(x => x.Nome == pesquisa || x.EnderecoFkNavigation.Address == pesquisa || x.EnderecoFkNavigation.Uf == pesquisa)
                        .Include(x => x.EnderecoFkNavigation)
                        .ToList();
        }
    }
}
