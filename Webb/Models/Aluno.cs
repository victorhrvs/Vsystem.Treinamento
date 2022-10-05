using System;
using System.Collections.Generic;

#nullable disable

namespace Web.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
