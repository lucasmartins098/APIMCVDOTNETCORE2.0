using System;

namespace crudmysql.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int ConfiguracaoPerfil_ID { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Telefone { get; set; }
    }
}