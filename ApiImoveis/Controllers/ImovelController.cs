using ApiImoveis.Models;
using ApiImoveis.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiImoveis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly ImovelService _imovelService = new ImovelService();

        [HttpGet(Name = "imovel")]
        public IEnumerable<Imovel> GetImoveis()
        {
            return _imovelService.GetAllImoveis();
        }


        [HttpGet("{id}", Name = "GetImovelById")]
        public IActionResult GetImovelById(int id)
        {
            var imovel = _imovelService.GetImovelById(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return Ok(imovel);
        }
    }
}
