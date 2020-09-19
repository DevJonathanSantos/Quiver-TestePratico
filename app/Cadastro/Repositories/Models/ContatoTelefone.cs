﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Repositories.Models
{
    public class ContatoTelefone
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public int IdTelefone { get; set; }
        public List<string> Telefone { get; set; }
    }
}