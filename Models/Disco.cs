using System.Collections.Generic;

namespace discos.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Letra { get; set; } = string.Empty;
        public Genero Genero { get; set; }
        public byte[] Imagem { get; set; } = null;

        public List<Faixa> Faixas { get; set; } = new List<Faixa>();
    }
}
