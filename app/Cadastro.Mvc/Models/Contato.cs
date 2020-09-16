using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Mvc.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDoCadastro { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

    }
}
