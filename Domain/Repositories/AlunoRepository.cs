using DataAccess.EFCore.Repositories;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>
    {


        /**
        public Task Add(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Aluno entity)
        {
            throw new NotImplementedException();
        }

        **/
        protected new readonly TreinamentoContext _context;
        

        public AlunoRepository(TreinamentoContext context) : base(context)
        {
            _context = context;
        }

        

        public new IEnumerable<Aluno> GetAll()
        {
            return _context.Set<Aluno>().Include(a => a.EnderecoFkNavigation).ToList();
        }


    }
}
