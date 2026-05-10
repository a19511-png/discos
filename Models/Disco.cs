using System.Collections.Generic;

namespace discos.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int IdGenero { get; set; }
        public List<Faixa> Faixa { get; set; }

        public Disco(int id, string nome, int ano, int idGenero)
        {
            Id = id;
            Nome = nome;
            Ano = ano;
            IdGenero = idGenero;
        }
    }
}
