using AutoMapper;
using FCPark.API.Resources;
using FCPark.API.Validators;
using FCPark.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IMapper _mapper;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService, IMapper mapper)
        {
            this._mapper = mapper;
            this._estabelecimentoService = estabelecimentoService;
        }

        /// <summary>
        /// Listar os Estabelecimentos cadastrados
        /// </summary>
        /// <returns>Estabelecimentos</returns>
        /// <response code="200">Retorna os estabelecimentos cadastrados</response>
        /// 
        [HttpGet("retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<EstabelecimentoResource>>> GetAllEstabelecimentos()
        {
            var estabelecimentos = await _estabelecimentoService.GetAllEstabelecimentos();
            var estabelecimentoResources = _mapper.Map<IEnumerable<Estabelecimento>, IEnumerable<EstabelecimentoResource>>(estabelecimentos);

            return Ok(estabelecimentoResources);
        }

        /// <summary>
        /// Buscar um Estabelecimento pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma entidade Estabelecimento pelo parametro ID</returns>
        /// <response code="200">Retorna o estabelecimento de acordo com o ID.</response>
        [HttpGet("{id}/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<EstabelecimentoResource>> GetEstabelecimentoById(int id)
        {
            var estabelecimento = await _estabelecimentoService.GetEstabelecimentoById(id);
            var estabelecimentoResource = _mapper.Map<Estabelecimento, EstabelecimentoResource>(estabelecimento);

            return Ok(estabelecimentoResource);
        }



        // POST api/Estabelecimento
        /// <summary>
        /// Criar um novo Estabelecimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///      POST /Estabelecimento
        ///      {
        ///        "id": 0,
        ///        "nome": "FC PARK",
        ///        "cnpj": "01256987000185",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///        "qtdVagasMotos": 60,
        ///        "qtdVagasCarros": 70
        ///      }
        ///
        /// </remarks>
        /// <param name="saveEstabelecimentoResource"></param>
        /// <returns>Um novo estabelecimento criado.</returns>
        /// <response code="201">Retorna o novo estabelecimento criado.</response>
        /// <response code="400">Se o estabelecimento não for criado.</response>   
        [HttpPost("")]
        public async Task<ActionResult<EstabelecimentoResource>> CreateEstabelecimento([FromBody] SaveEstabelecimentoResource saveEstabelecimentoResource)
        {
            var validator = new SaveEstabelecimentoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveEstabelecimentoResource);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var estabelecimentoToCreate = _mapper.Map<SaveEstabelecimentoResource, Estabelecimento>(saveEstabelecimentoResource);

            var newEstabelecimento = await _estabelecimentoService.CreateEstabelecimento(estabelecimentoToCreate);

            var estabelecimento = await _estabelecimentoService.GetEstabelecimentoById(newEstabelecimento.Id);

            var estabelecimentoResource = _mapper.Map<Estabelecimento, EstabelecimentoResource>(estabelecimento);

            return Ok(estabelecimentoResource);
        }

        // PUT api/Estabelecimento
        /// <summary>
        /// Atualizar um Estabelecimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///      POST /Estabelecimento
        ///      {
        ///        "id": 1,
        ///        "nome": "FC PARK PARKING",
        ///        "cnpj": "01256987000185",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///        "qtdVagasMotos": 60,
        ///        "qtdVagasCarros": 70
        ///      }
        ///
        /// </remarks>
        /// <param name="saveEstabelecimentoResource"></param>
        /// <param name="id"></param>
        /// <returns>Um estabelecimento atualizado.</returns>
        /// <response code="201">Retorna o estabelecimento atualizado.</response>
        /// <response code="400">Se o estabelecimento não for atualizado.</response>   
        [HttpPut("{id}")]
        public async Task<ActionResult<EstabelecimentoResource>> UpdateEstabelecimento(int id, [FromBody] SaveEstabelecimentoResource saveEstabelecimentoResource)
        {
            var validator = new SaveEstabelecimentoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveEstabelecimentoResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var estabelecimentoToBeUpdated = await _estabelecimentoService.GetEstabelecimentoById(id);

            if (estabelecimentoToBeUpdated == null)
                return NotFound();

            var estabelecimento = _mapper.Map<SaveEstabelecimentoResource, Estabelecimento>(saveEstabelecimentoResource);

            await _estabelecimentoService.UpdateEstabelecimento(estabelecimentoToBeUpdated, estabelecimento);

            var updatedEstabelecimento = await _estabelecimentoService.GetEstabelecimentoById(id);

            var updatedEstabelecimentoResource = _mapper.Map<Estabelecimento, EstabelecimentoResource>(updatedEstabelecimento);

            return Ok(updatedEstabelecimentoResource);
        }

        // DELETE api/Estabelecimento
        /// <summary>
        /// Excluir um Estabelecimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE /Estabelecimento
        ///     {
        ///        "Id": 1,
        ///        "Marca": "VOLKSWAGEN",
        ///        "Modelo": "GOL 1.0",
        ///        "Placa": "FUU7876",
        ///        "Cor" : "Vermelho",
        ///        "Tipo" : "Carro"
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um estabelecimento excluído.</returns>
        /// <response code="400">Se o estabelecimento não for excluído.</response>  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstabelecimento(int id)
        {
            var estabelecimento = await _estabelecimentoService.GetEstabelecimentoById(id);

            await _estabelecimentoService.DeleteEstabelecimento(estabelecimento);

            return NoContent();
        }
    }
}
