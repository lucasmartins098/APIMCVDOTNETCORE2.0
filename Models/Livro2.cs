using System;

namespace crudmysql.Models
{
    public class Livro2
    {
        public int Id { get; set; }
        public string NomeDolivro2 { get; set; }
        public string AutorDolivro2 { get; set; }
        public decimal PrecoDolivro2 { get; set; }
        //public Livro livro { get; set; }
        public int? idLivro { get; set; }
        public DateTime? LancamentoDolivro2 { get; set; } = DateTime.UtcNow;
    }
}