using Microsoft.EntityFrameworkCore;

namespace Cadastro.Mvc.Models
{
    public class CadastroDeContato : DbContext
    {
        public CadastroDeContato(DbContextOptions<CadastroDeContato> options)
            : base(options) { }
        public DbSet<Contato> Contato { get; set; }
    }
}
