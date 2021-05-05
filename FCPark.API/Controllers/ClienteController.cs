using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FCPark.Core;
using FCPark.API.Resources;
using FCPark.API.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

namespace FCPark.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            this._mapper = mapper;
            this._clienteService = clienteService;
        }

        /// <summary>
        /// Listar os Clientes cadastrados
        /// </summary>
        /// <returns>Clientes</returns>
        /// <response code="200">Retorna os clientes cadastrados</response>
        /// 

        [HttpGet("retorno.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<ClienteResource>>> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientes();
            var clientesResources = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResource>>(clientes);

            return Ok(clientesResources);
        }

        /// <summary>
        /// Buscar um Cliente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma entidade Cliente pelo parametro ID</returns>
        /// <response code="200">Retorna o cliente de acordo com o ID.</response>
         
        [HttpGet("{id}/retorno.{format}"), FormatFilter]
        public async Task<ActionResult<ClienteResource>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            var clienteResource = _mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(clienteResource);
        }


        // POST api/Cliente
        /// <summary>
        /// Criar um novo Cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///      POST /Cliente
        ///      {
        ///        "id": 0,
        ///        "nome": "Jade",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///       
        ///      }
        ///
        /// </remarks>
        /// <param name="saveClienteResource"></param>
        /// <returns>Um novo cliente criado.</returns>
        /// <response code="201">Retorna o novo cliente criado.</response>
        /// <response code="400">Se o cliente não for criado.</response>  

        // POST api/Cliente
        /// <summary>
        /// Criar um novo Cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///      POST /Cliente
        ///      {
        ///        "id": 0,
        ///        "nome": "Jade",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///      }
        ///
        /// </remarks>
        /// <param name="saveClienteResource"></param>
        /// <returns>Um novo cliente criado.</returns>
        /// <response code="201">Retorna o novo cliente criado.</response>
        /// <response code="400">Se o cliente não for criado.</response>   

        [HttpPost("")]
        public async Task<ActionResult<ClienteResource>> CreateCliente([FromBody] SaveClienteResource saveClienteResource)
        {

            var validator = new SaveClienteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveClienteResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var clienteToCreate = _mapper.Map<SaveClienteResource, Cliente>(saveClienteResource);
            var newCliente = await _clienteService.CreateCliente(clienteToCreate);
            var cliente = await _clienteService.GetClienteById(newCliente.Id);
            var clienteResource = _mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(clienteResource);
        }

        // PUT api/Cliente
        /// <summary>
        /// Atualizar um Cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///      POST /Cliente
        ///      {
        ///        "id": 1,
        ///        "nome": "Jade",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///      }
        ///
        /// </remarks>
        /// <param name="saveClienteResource"></param>
        /// <param name="id"></param>
        /// <returns>Um cliente atualizado.</returns>
        /// <response code="201">Retorna o cliente atualizado.</response>
        /// <response code="400">Se o cliente não for atualizado.</response>   
        /// 
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteResource>> UpdateCliente(int id, [FromBody] SaveClienteResource saveClienteResource)
        {
            var validator = new SaveClienteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveClienteResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var clienteToBeUpdated = await _clienteService.GetClienteById(id);

            if (clienteToBeUpdated == null)
                return NotFound();

            var cliente = _mapper.Map<SaveClienteResource, Cliente>(saveClienteResource);

            await _clienteService.UpdateCliente(clienteToBeUpdated, cliente);

            var updatedCliente = await _clienteService.GetClienteById(id);

            var updatedClienteResource = _mapper.Map<Cliente, ClienteResource>(updatedCliente);

            return Ok(updatedClienteResource);
        }
        // DELETE api/Cliente
        /// <summary>
        /// Excluir um Cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE /Cliente
        ///     {
        ///        "id": 1,
        ///        "nome": "Jade",
        ///        "endereco": "Rua das Hortências",
        ///        "telefone": "1335675869",
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um cliente excluído.</returns>
        /// <response code="400">Se o cliente não for excluído.</response>  ]
        ///
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);

            await _clienteService.DeleteCliente(cliente);

            return NoContent();
        }
    }
}
 