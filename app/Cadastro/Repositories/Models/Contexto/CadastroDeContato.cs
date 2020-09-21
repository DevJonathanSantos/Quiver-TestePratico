using Microsoft.EntityFrameworkCore;

namespace Cadastro.Repositories.Models.Contexto
{
    public class CadastroDeContato : DbContext
    {
        public CadastroDeContato(DbContextOptions<CadastroDeContato> options)
            : base(options) { }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
    }
}
