using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers.Contracts;

namespace Todo.Domain.Api.Controllers
{
    [ApiController, Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost, Route("create-account")]
        public GenericCommandResult Create([FromBody] CreateAccountCommand command, [FromServices] IHandler<CreateAccountCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPost, Route("login")]
        public GenericCommandResult Login([FromBody] LoginCommand command, [FromServices] ILoginHandler<LoginCommand> handler)
        {
            var result = (LoginCommandResult)handler.Handle(command);
            return new GenericCommandResult(result.Success, result.Message, new { email = result.Email });
        }
    }
}
