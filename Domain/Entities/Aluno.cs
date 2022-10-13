using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Aluno 
    {
        [StringLength(100)]
        public int Matricula { get; private set; }
        [StringLength(100)]
        public string Nome { get; private set; }
        [StringLength(100)]
        public string Email { get; private set; }
        public int? EnderecoFk { get; private set; }

        public virtual Endereco EnderecoFkNavigation { get; set; }
    }
}
