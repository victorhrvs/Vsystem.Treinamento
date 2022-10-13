using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Endereco
    {
        public Endereco()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int EnderecoId { get; set; }
        public string Uf { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
