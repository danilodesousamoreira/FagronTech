using FagronTech.Application.Interfaces;
using FagronTech.Application.ViewModels;
using FagronTech.Infrastructure.Web;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace FagronTech.Api.Controllers
{
    public class ClienteController : ApiControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService) 
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ClienteViewModel>> ListarClientes()
        {
            return Ok(clienteService.BuscarClientes());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClienteViewModel> BuscarClientePorId(int id)
        {
            ClienteViewModel result = clienteService.BuscarClientePorId(id);

            if (result == default)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Inserir([FromBody] ClienteInsertViewModel aluno)
        {
            clienteService.Inserir(aluno);
            return Created("", "Inserido com Sucesso");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Atualizar(int id, [FromBody] ClienteUpdateViewModel aluno)
        {
            clienteService.Atualizar(id, aluno);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Deletar(int id)
        {
            clienteService.Deletar(id);
            return Ok();
        }
    }
}
