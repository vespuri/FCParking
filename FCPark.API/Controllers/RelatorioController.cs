using AutoMapper;
using FCPark.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FCPark.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IMovimentacaoVeiculoService _movimentacaoService;
        private readonly IMapper _mapper;

        public RelatorioController(IMovimentacaoVeiculoService movimentacaoService, IMapper mapper)
        {
            this._mapper = mapper;
            this._movimentacaoService = movimentacaoService;
        }
        /// <summary>
        /// Retorna o TOTAL de Entrada de Veículos por HORA
        /// </summary>
        /// <returns>Retorna uma lista de Report com as entradas de veículo do dia por HORA</returns>
        /// <response code="200">Retorna a lista com sucesso.</response>
        [HttpGet("totalEntrada/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<TotalsReport>>> GetVeiculoEntradaPorHora()
        {
            var movimentos = await _movimentacaoService.GetMovimentacaoEntradaDiaHora(DateTime.Now);

            return Ok(movimentos);
        }

        /// <summary>
        /// Retorna o TOTAL de Saída de Veículos por HORA
        /// </summary>
        /// <returns>Retorna uma lista de Report com as saídas de veículo do dia por HORA</returns>
        /// <response code="200">Retorna a lista com sucesso.</response>
        [HttpGet("totalSaida/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<TotalsReport>>> GetVeiculoSaidaPorHora()
        {
            var movimentos = await _movimentacaoService.GetMovimentacaoSaidaDiaHora(DateTime.Now);

            return Ok(movimentos);
        }

        /// <summary>
        /// Retorna o TOTAL de Entrada e Saída de Veículos do DIA
        /// </summary>
        /// <returns>Retorna uma lista de Report com os totais de entradas e saídas de veículo do dia</returns>
        /// <response code="200">Retorna a lista com sucesso.</response>
        [HttpGet("totalEntradaSaida/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<TotalsReport>>> GetEntradaSaidaDia()
        {
            var movimentos = await _movimentacaoService.GetTotalEntradaSaidaDia(DateTime.Now);

            return Ok(movimentos);
        }
    }
}
