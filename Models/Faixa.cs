namespace discos.Models
{
    public class Faixa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Duracao { get; set; }

        public Faixa(int id, string descricao, int duracao)
        {
            Id = id;
            Descricao = descricao;
            Duracao = duracao;
        }
    }
}

