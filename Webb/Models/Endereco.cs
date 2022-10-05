using System;
using System.Collections.Generic;

#nullable disable

namespace Web.Models
{
    public partial class Endereco
    {
        public int IdEndereco { get; set; }
        public int? Matricula { get; set; }
        public string Logradouro { get; set; }
        public string Uf { get; set; }

        public virtual Aluno MatriculaNavigation { get; set; }
    }
}
