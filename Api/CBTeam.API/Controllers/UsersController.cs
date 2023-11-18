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
            var response = await _mediator.Send(request); 
            return Ok(response);

        }

        [HttpGet]
        [Route("forName")]
        public async Task<IActionResult> GetListForName([FromQuery] GetUserListForNameRequest request)
        {
            var response = await _mediator.Send(request); 
            return Ok(response);

        }
    }
}
