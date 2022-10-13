using DataAccess.EFCore.Repositories;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class EnderecoRepository : GenericRepository<Endereco>
    {
        protected new readonly TreinamentoContext _context;
        public EnderecoRepository(TreinamentoContext context) : base(context)
        {
            _context = context;
        }

    }
}
