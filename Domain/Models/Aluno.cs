using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? EnderecoFk { get; set; }

        public virtual Endereco EnderecoFkNavigation { get; set; }

        
    }
}
