using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FCPark.API.Resources;
using FCPark.API.Validators;
using FCPark.Core;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCPark.API.Controllers
{
    [Route("api/[controller]")]
   // [Authorize("Bearer")]
    [ApiController]
    public class MovimentacaoVeiculoController : Controller
    {
        private readonly IMovimentacaoVeiculoService _movimentacaoVeiculoService;
        private readonly IVeiculoService _veiculoService;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public MovimentacaoVeiculoController(IMovimentacaoVeiculoService movimentacaoVeiculoService,
            IVeiculoService veiculoService, IClienteService clienteService, IMapper mapper)
             
        {
            this._mapper = mapper;
            this._movimentacaoVeiculoService = movimentacaoVeiculoService;
            this._veiculoService = veiculoService;
            this._clienteService = clienteService;
        }

        // GET api/Veiculo
        /// <summary>
        /// Retorna TODAS as movimentações registradas
        /// </summary>
        /// <returns>Uma nova passagem do veículo é criada.</returns>
        /// <response code="201">Retorna a lista de registros de veículo.</response>
        /// <response code="400">Se a lista não for retornada.</response>  
        [HttpGet("retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<MovimentacaoVeiculoResource>>> GetAllMovimentacao()
        {
            var mVeiculos = await _movimentacaoVeiculoService.GetAllMovimentacaoVeiculos();
            var mVeiculoResources = _mapper.Map<IEnumerable<MovimentacaoVeiculo>, IEnumerable<MovimentacaoVeiculoResource>>(mVeiculos);

            return Ok(mVeiculoResources);
        }

        // POST api/Veiculo
        /// <summary>
        /// Registra a ENTRADA do Veículo no Estabelecimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///       "id": 0,
        ///       "veiculoId": 1,
        ///       "estabelecimentoId": 1,
        ///       "clienteId": 1,
        ///       "dataEntrada": "2020-09-21T09:57:27",
        ///       "dataSaida": null
        ///     }
        ///
        /// </remarks>
        /// <returns>Uma nova passagem do veículo é criada.</returns>
        /// <response code="201">Retorna o novo registro de entrada do veículo.</response>
        /// <response code="400">Se a entrada não for criada.</response>  
        [HttpPost("")]
        public async Task<ActionResult<MovimentacaoVeiculoResource>> RegistrarEntradaVeiculo([FromBody] SaveMovimentacaoVeiculoResource saveMovimentacaoVeiculoResource)
        {
            var validator = new SaveMovimentacaoVeiculoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMovimentacaoVeiculoResource);

            var veiculo = await _veiculoService.GetVeiculoById(saveMovimentacaoVeiculoResource.VeiculoId);
            var movimentacaoExistente = await _movimentacaoVeiculoService.GetMovimentacaoPorPlaca(veiculo.Placa);
            
            if (movimentacaoExistente != null)
            {
                ValidationFailure failure = new ValidationFailure("dataSaida", String.Format("Saída Pendente para o Veículo de placa {0}", veiculo.Placa));
                validationResult.Errors.Add(failure);
            }

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var cliente = await _clienteService.GetClienteById(saveMovimentacaoVeiculoResource.ClienteId);
            var movimentacaoVeiculoCliente = await _movimentacaoVeiculoService.GetMovimentacaoPorCPF(cliente.CPF);

            if (movimentacaoExistente != null)
            {
                ValidationFailure failure = new ValidationFailure("dataSaida", String.Format("Saída Pendente para o CPF {0}", cliente.CPF));
                validationResult.Errors.Add(failure);
            }

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var movimentacaoToCreate = _mapper.Map<SaveMovimentacaoVeiculoResource, MovimentacaoVeiculo>(saveMovimentacaoVeiculoResource);

            var newMovimentacao = await _movimentacaoVeiculoService.CreateMovimentacao(movimentacaoToCreate);

            var movimentacao = await _movimentacaoVeiculoService.GetMovimentacaoById(newMovimentacao.Id);

            var movimentacaoVeiculoResource = _mapper.Map<MovimentacaoVeiculo, MovimentacaoVeiculoResource>(movimentacao);

            return Ok(movimentacaoVeiculoResource);
        }

        // POST api/Veiculo
        /// <summary>
        /// Atualiza a passagem do Veículo no Estabelecimento. Altera Data de Entrada e Saída do Veículo
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///       "id": 1,
        ///       "veiculoId": 1,
        ///       "estabelecimentoId": 1,
        ///       "clienteId": 1,
        ///       "dataEntrada": "2020-09-21T09:57:27",
        ///       "dataSaida": "2020-09-21T11:30:00"
        ///     }
        ///
        /// </remarks>
        /// <returns>Uma nova passagem do veículo é atualizada.</returns>
        /// <response code="201">Retorna o registro de entrada do veículo atualizado.</response>
        /// <response code="400">Se o registro não for atualizado.</response> 
        [HttpPut("{id}")]
        public async Task<ActionResult<MovimentacaoVeiculoResource>> RegistrarSaidaVeiculo(int id, [FromBody] SaveMovimentacaoVeiculoResource saveMovimentacaoVeiculoResource)
        {
            var validator = new SaveMovimentacaoVeiculoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMovimentacaoVeiculoResource);

            if(saveMovimentacaoVeiculoResource.DataSaida == null) {
                ValidationFailure failure = new ValidationFailure("dataSaida", "É necessário preencher a Data de Saída do Veículo");
                validationResult.Errors.Add(failure);
            }

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var movimentacaoToBeUpdated = await _movimentacaoVeiculoService.GetMovimentacaoById(id);

            if (movimentacaoToBeUpdated == null)
                return NotFound();
            var movimentacao = _mapper.Map<SaveMovimentacaoVeiculoResource, MovimentacaoVeiculo>(saveMovimentacaoVeiculoResource);

            await _movimentacaoVeiculoService.RegistrarSaidaVeiculo(movimentacaoToBeUpdated, movimentacao);

            var updatedMovimentacaoVeiculo = await _movimentacaoVeiculoService.GetMovimentacaoById(id);

            var updatedMovimentacaoVeiculoResource = _mapper.Map<MovimentacaoVeiculo, MovimentacaoVeiculoResource>(updatedMovimentacaoVeiculo);

            return Ok(updatedMovimentacaoVeiculoResource);
        }

    }
}
