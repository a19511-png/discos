namespace discos.Models
{
    public class Faixa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Letra { get; set; } = string.Empty;
        public int Duracao { get; set; }
    }
}

