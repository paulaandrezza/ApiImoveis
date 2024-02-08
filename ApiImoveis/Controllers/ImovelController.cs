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
            throw new Exception();
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

        [HttpPost("{proprietarioId}", Name = "AddImovelFromRegisteredOwner")]
        public IActionResult AddImovelFromRegisteredOwner([FromRoute] int proprietarioId, [FromBody] Imovel imovel)
        {
            Proprietario proprietario = _imovelService.GetProprietarioById(proprietarioId);
            if (proprietario == null)
                return NotFound(new { message = "Proprietário não encontrado." });
            int id = _imovelService.AddImovelFromRegisteredOwner(imovel, proprietario);
            return CreatedAtRoute("GetImovelById", new { id }, imovel);
        }


        [HttpPatch("{id}", Name = "UpdateImovel")]
        public IActionResult UpdateImovel([FromRoute] int id, [FromBody] Imovel imovel)
        {
            var existingImovel = _imovelService.GetImovelById(id);
            if (existingImovel == null)
                return NotFound();

            _imovelService.UpdateImovel(id, imovel);
            return Ok(new { message = "Imóvel atualizado com sucesso." });
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
