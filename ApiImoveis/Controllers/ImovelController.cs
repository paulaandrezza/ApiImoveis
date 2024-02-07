using ApiImoveis.Models;
using ApiImoveis.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiImoveis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly ImovelService _imovelService = new ImovelService();

        [HttpGet(Name = "GetAllImoveis")]
        public IActionResult GetImoveis()
        {
            return Ok(_imovelService.GetAllImoveis());
        }


        [HttpGet("{id}", Name = "GetImovelById")]
        public IActionResult GetImovelById([FromRoute] int id)
        {
            var imovel = _imovelService.GetImovelById(id);
            if (imovel == null)
                return NotFound();

            return Ok(imovel);
        }

        [HttpPost(Name = "AddImovel")]
        public IActionResult AddImovel([FromBody] Imovel imovel)
        {
            int id = _imovelService.AddImovel(imovel);
            return CreatedAtRoute("GetImovelById", new { id }, imovel);
        }

        [HttpPatch("{id}", Name = "UpdateImovel")]
        public IActionResult UpdateImovel([FromRoute] int id, [FromBody] Imovel imovel)
        {
            var existingImovel = _imovelService.GetImovelById(id);
            if (existingImovel == null)
                return NotFound();

            _imovelService.UpdateImovel(id, imovel);
            return Ok(imovel);
        }

        [HttpDelete("{id}", Name = "DeleteImovel")]
        public IActionResult DeleteImovel([FromRoute] int id)
        {
            var existingImovel = _imovelService.GetImovelById(id);
            if (existingImovel == null)
                return NotFound();

            _imovelService.DeleteImovel(id);
            return Ok(new { message = "Imóvel excluído com sucesso." });
        }
    }
}
