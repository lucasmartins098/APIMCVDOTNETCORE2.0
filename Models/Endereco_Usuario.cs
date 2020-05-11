using System;

namespace crudmysql.Models
{
    public class Endereco_Usuario
    {
        public int Id { get; set; }
        public int Endereco_Id { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public int Usuario_Id { get; set; }
        public int Usuario_ConfiguracaoPerfil_Id { get; set; }
    }
}