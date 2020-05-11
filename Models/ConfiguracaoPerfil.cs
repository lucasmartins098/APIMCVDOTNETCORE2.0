using System;

namespace crudmysql.Models
{
    public class ConfiguracaoPerfil
    {
        public int Id { get; set; }
        public byte[] imagemPerfil { get; set; }
        public byte TipoPerfil { get; set; }
    }
}