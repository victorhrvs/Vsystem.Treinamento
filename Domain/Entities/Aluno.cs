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

        public int Matricula { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        
        public int EnderecoFk { get; set; }

        public virtual Endereco EnderecoFkNavigation { get; set; }

        public static explicit operator bool(Aluno v)
        {
            throw new NotImplementedException();
        }
    }
}
