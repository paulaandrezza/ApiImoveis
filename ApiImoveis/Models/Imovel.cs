using ApiImoveis.Models.Enum;

namespace ApiImoveis.Models
{
    public class Imovel
    {
        public Imovel(int id, Proprietario proprietario, TipoImovel tipo, Endereco endereco, int qtdQuartos, int qtdBanheiros, int qtdVagasGaragem, StatusDisponibilidade[] status)
        {
            Id = id;
            Proprietario = proprietario;
            Tipo = tipo;
            Endereco = endereco;
            QtdQuartos = qtdQuartos;
            QtdBanheiros = qtdBanheiros;
            QtdVagasGaragem = qtdVagasGaragem;
            Status = status;
        }

        public int Id { get; set; }
        public Proprietario? Proprietario { get; set; }
        public TipoImovel Tipo { get; set; }
        public Endereco? Endereco { get; set; }
        public decimal? ValorImovel { get; set; }
        public decimal? ValorAluguel { get; set; }
        public int QtdQuartos { get; set; }
        public int QtdBanheiros { get; set; }
        public int QtdVagasGaragem { get; set; }
        public StatusDisponibilidade[]? Status { get; set; }
    }
}
