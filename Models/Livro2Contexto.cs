using Microsoft.EntityFrameworkCore;

namespace crudmysql.Models
{
    public class Livro2Contexto : DbContext
    {
        public Livro2Contexto(DbContextOptions<Livro2Contexto> options) : base(options)
        {
        }
        public DbSet<Livro2> Livros { get; set; }
    }
}