using System;

namespace discos.Models
{
    public class Artista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Nacionalidade { get; set; }

        public DateTime? DataNascimento { get; set; }

        public Artista(int id, string nome, string nascionalidade, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Nacionalidade = nascionalidade;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
