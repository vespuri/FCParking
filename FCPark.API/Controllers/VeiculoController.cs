using AutoMapper;
using FCPark.API.Resources;
using FCPark.API.Validators;
using FCPark.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FCPark.API.Controllers
{

    [Route("api/[controller]")]
    //[Authorize("Bearer")]

    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;


        public VeiculoController(IVeiculoService veiculoService, IMapper mapper)
        {
            this._mapper = mapper;
            this._veiculoService = veiculoService;
        }

        /// <summary>
        /// Listar os Veículos cadastrados
        /// </summary>
        /// <returns>Veículos</returns>
        /// <response code="200">Retorna os veículos cadastrados</response>
        /// 
        [HttpGet("retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<VeiculoResource>>> GetAllVeiculos()
        {
            var veiculos = await _veiculoService.GetAllVeiculos();
            var veiculoResources = _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoResource>>(veiculos);

            return Ok(veiculoResources);
        }
        /// <summary>
        /// Buscar um Veículo pelo ID
        /// </summary>
        /// <returns>Retorna uma entidade Veiculo pelo parametro ID</returns>
        /// <response code="200">Retorna o veículo de acordo com o ID.</response>
        [HttpGet("{id}/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<VeiculoResource>> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoById(id);
            var veiculoResource = _mapper.Map<Veiculo, VeiculoResource>(veiculo);

            return Ok(veiculoResource);
        }

        // POST api/Veiculo
        /// <summary>
        /// Criar um novo Veículo
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Veiculo
        ///     {
        ///        "Id": 0,
        ///        "Marca": "VOLKSWAGEN",
        ///        "Modelo": "GOL 1.0",
        ///        "Placa": "FUU7876",
        ///        "Cor" : "Vermelho",
        ///        "Tipo" : "Carro"
        ///     }
        ///
        /// </remarks>
        /// <param name="saveVeiculoResource"></param>
        /// <returns>Um novo veículo criado.</returns>
        /// <response code="201">Retorna o novo veículo criado.</response>
        /// <response code="400">Se o veículo não for criado.</response>   
        [HttpPost("")]
        public async Task<ActionResult<VeiculoResource>> CreateVeiculo([FromBody] SaveVeiculoResource saveVeiculoResource)
        {
            var validator = new SaveVeiculoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVeiculoResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var veiculoToCreate = _mapper.Map<SaveVeiculoResource, Veiculo>(saveVeiculoResource);

            var newVeiculo = await _veiculoService.CreateVeiculo(veiculoToCreate);

            var veiculo = await _veiculoService.GetVeiculoById(newVeiculo.Id);

            var veiculoResource = _mapper.Map<Veiculo, VeiculoResource>(veiculo);

            return Ok(veiculoResource);
        }

        // PUT api/Veiculo
        /// <summary>
        /// Atualizar um Veículo
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /Veiculo
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
        /// <returns>Um veículo atualizado.</returns>
        /// <response code="201">Retorna o veículo atualizado.</response>
        /// <response code="400">Se o veículo não for atualizado.</response>   
        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoResource>> UpdateVeiculo(int id, [FromBody] SaveVeiculoResource saveVeiculoResource)
        {
            var validator = new SaveVeiculoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveVeiculoResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var veiculoToBeUpdated = await _veiculoService.GetVeiculoById(id);

            if (veiculoToBeUpdated == null)
                return NotFound();

            var veiculo = _mapper.Map<SaveVeiculoResource, Veiculo>(saveVeiculoResource);

            await _veiculoService.UpdateVeiculo(veiculoToBeUpdated, veiculo);

            var updatedVeiculo = await _veiculoService.GetVeiculoById(id);

            var updatedVeiculoResource = _mapper.Map<Veiculo, VeiculoResource>(updatedVeiculo);

            return Ok(updatedVeiculoResource);
        }

        // DELETE api/Veiculo
        /// <summary>
        /// Excluir um Veículo
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE /Veiculo
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
        /// <returns>Um veículo excluído.</returns>
        /// <response code="400">Se o veículo não for excluído.</response>  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoById(id);

            await _veiculoService.DeleteVeiculo(veiculo);

            return NoContent();
        }
    }
}
