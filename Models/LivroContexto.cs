using Microsoft.EntityFrameworkCore;

namespace crudmysql.Models
{
    public class LivroContexto : DbContext
    {
        public LivroContexto(DbContextOptions<LivroContexto> options) : base(options)
        {
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Livro2> Livros2 { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ConfiguracaoPerfil> ConfiguracaoPerfil { get; set; }
        public DbSet<Coletor> Coletor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Endereco_Usuario> Endereco_Usuario { get; set; }
    }
}