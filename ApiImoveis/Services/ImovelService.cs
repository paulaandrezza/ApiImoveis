using ApiImoveis.Models;
using ApiImoveis.Services.Interface;

namespace ApiImoveis.Services
{
    public class ImovelService : IImovelService
    {
        private static readonly List<Imovel> _imoveis = new List<Imovel>()
        {
            new Imovel(0, Models.Enum.TipoImovel.Apartamento, new Endereco("37640000", "MG", "Extrema", "Centro", "Rua das Palmeiras", "123-A"), 2, 2, 1, [Models.Enum.StatusDisponibilidade.DisponivelVenda]) { ValorImovel = 500000 }
        };
        private int _nextId = 1;
        public int AddImovel(Imovel imovel)
        {
            imovel.Id = _nextId++;
            _imoveis.Add(imovel);
            return imovel.Id;
        }

        public string DeleteImovel(int id)
        {
            var imovelToRemove = _imoveis.FirstOrDefault(imovel => imovel.Id == id);
            if (imovelToRemove != null)
            {
                _imoveis.Remove(imovelToRemove);
                return "Imóvel exclúido com sucesso.";
            }
            return "Imóvel não encontrado.";
        }

        public IEnumerable<Imovel> GetAllImoveis()
        {
            return _imoveis;
        }

        public Imovel GetImovelById(int id)
        {
            return _imoveis.FirstOrDefault(imovel => imovel.Id == id);
        }

        public string UpdateImovel(int id, Imovel imovel)
        {
            var existingImovel = _imoveis.FirstOrDefault(imovel => imovel.Id == id);
            if (existingImovel != null)
            {
                existingImovel.Tipo = imovel.Tipo;
                existingImovel.Endereco = imovel.Endereco;
                existingImovel.QtdQuartos = imovel.QtdQuartos;
                existingImovel.QtdBanheiros = imovel.QtdBanheiros;
                existingImovel.QtdVagasGaragem = imovel.QtdVagasGaragem;
                existingImovel.Status = imovel.Status;
                return "Imóvel atualizado com sucesso.";
            }
            return "Imóvel não encontrado.";
        }
    }
}
