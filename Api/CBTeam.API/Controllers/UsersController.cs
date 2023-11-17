using CBTeam.Application.Contract;
using CBTeam.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTeam.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList([FromQuery] GetUserListRequest request)
        {
            var response = await _mediator.Send(request); // Llamo al handler donde está toda la lógica de aplicación, el controlador no sabe de donde lo saca, está abstraido a todo eso
            //var userList = _userRepository.GetList();
            return Ok(response);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok();
        }
    }
}
