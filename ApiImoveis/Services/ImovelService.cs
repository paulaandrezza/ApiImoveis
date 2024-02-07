using ApiImoveis.Models;
using ApiImoveis.Services.Interface;

namespace ApiImoveis.Services
{
    public class ImovelService : IImovelService
    {
        private static readonly List<Imovel> _imoveis = new List<Imovel>()
        {
            new Imovel(1, new Proprietario {
                    Id = 1,
                    Nome = "João",
                    Sobrenome = "Silva",
                    Email = "joao.silva@example.com",
                    Telefone = "(00) 1234-5678",
                    DataNascimento = new DateTime(1985, 10, 15),
                    Endereco = new Endereco("37640000", "MG", "Extrema", "Centro", "Rua das Flores", "111")
                },
                Models.Enum.TipoImovel.Apartamento,
                new Endereco("37640000", "MG", "Extrema", "Centro", "Rua das Palmeiras", "123-A"),
                2, 2, 1, [Models.Enum.StatusDisponibilidade.DisponivelVenda]) { ValorImovel = 500000 }
        };
        private static int _nextId = 1;
        private static int _nextUserId = 1;
        public int AddImovel(Imovel imovel)
        {
            imovel.Id = ++_nextId;
            imovel.Proprietario.Id = ++_nextUserId;
            _imoveis.Add(imovel);
            return imovel.Id;
        }

        public void DeleteImovel(int id)
        {
            var imovelToRemove = _imoveis.FirstOrDefault(imovel => imovel.Id == id);
            _imoveis.Remove(imovelToRemove);
        }

        public IEnumerable<Imovel> GetAllImoveis()
        {
            return _imoveis;
        }

        public Imovel GetImovelById(int id)
        {
            return _imoveis.FirstOrDefault(imovel => imovel.Id == id);
        }

        public int UpdateImovel(int id, Imovel imovel)
        {
            if (imovel == null)
                throw new ArgumentNullException("imovel");

            var existingImovel = _imoveis.FirstOrDefault(imovel => imovel.Id == id);

            existingImovel.Tipo = imovel.Tipo;
            existingImovel.Endereco = imovel.Endereco;
            existingImovel.QtdQuartos = imovel.QtdQuartos;
            existingImovel.QtdBanheiros = imovel.QtdBanheiros;
            existingImovel.QtdVagasGaragem = imovel.QtdVagasGaragem;
            existingImovel.Status = imovel.Status;
            existingImovel.ValorImovel = imovel.ValorImovel;
            existingImovel.ValorAluguel = imovel.ValorAluguel;

            return existingImovel.Id;
        }
    }
}
