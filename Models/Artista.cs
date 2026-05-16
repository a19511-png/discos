using System;
using System.Collections.Generic;

namespace discos.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Biografia { get; set; } = string.Empty;
        public byte[] Imagem { get; set; } = null;

        public List<Disco> Discos { get; set; } = new List<Disco>();
    }
}
