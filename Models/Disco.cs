using System.Collections.Generic;
using System.Drawing;

namespace discos.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Letra { get; set; } = string.Empty;
        public Genero Genero { get; set; }
        public Image Imagem { get; set; } = null;

        public List<Faixa> Faixas { get; set; } = new List<Faixa>();

        public int DuracaoTotal()
        {
            int duracaoTotal = 0;
            foreach (var faixa in Faixas)
            {
                duracaoTotal += faixa.Duracao;
            }
            return duracaoTotal;
        }
    }
}
