using FagronTech.Application.Interfaces;
using FagronTech.Application.ViewModels;

using Lider.Buzz.Web;

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
        public ActionResult<ClienteViewModel> Get(int id)
        {
            ClienteViewModel result = clienteService.BuscarClientePorId(id);

            if (result == default)
                return NotFound();

            return Ok(result);
        }
    }
}
