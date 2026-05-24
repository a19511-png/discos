using System;
using System.Collections.Generic;
using System.Drawing;

namespace discos.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Biografia { get; set; } = string.Empty;
        public Image Imagem { get; set; } = null;

        public List<Disco> Discos { get; set; } = new List<Disco>();

        public int? Idade()
        {
            if (DataNascimento != null)
            {
                DateTime dataHoje = DateTime.Today;

                int idade = dataHoje.Year - DataNascimento.Value.Year;

                if (DataNascimento > dataHoje.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
            else
            {
                return null;
            }
        }
    }
}
