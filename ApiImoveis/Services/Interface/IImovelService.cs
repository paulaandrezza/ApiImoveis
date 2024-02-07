using ApiImoveis.Models;

namespace ApiImoveis.Services.Interface
{
    public interface IImovelService
    {
        Imovel GetImovelById(int id);
        IEnumerable<Imovel> GetAllImoveis();
        int AddImovel(Imovel imovel);
        int UpdateImovel(int id, Imovel imovel);
        void DeleteImovel(int id);
    }
}
