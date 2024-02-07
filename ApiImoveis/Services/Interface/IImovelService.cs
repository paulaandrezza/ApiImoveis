using ApiImoveis.Models;

namespace ApiImoveis.Services.Interface
{
    public interface IImovelService
    {
        Imovel GetImovelById(int id);
        IEnumerable<Imovel> GetAllImoveis();
        int AddImovel(Imovel imovel);
        string UpdateImovel(int id, Imovel imovel);
        string DeleteImovel(int id);
    }
}
