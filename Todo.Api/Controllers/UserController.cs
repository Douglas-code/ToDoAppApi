using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Todo.Api.Services;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;

namespace Todo.Api.Controllers
{
    [ApiController, Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpPost, Route("create-account")]
        public GenericCommandResult Create([FromBody] CreateAccountCommand command, [FromServices] IHandler<CreateAccountCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPost, Route("login")]
        public GenericCommandResult Login([FromBody] LoginCommand command, [FromServices] ILoginHandler<LoginCommand> handler)
        {
            var result = (LoginCommandResult)handler.Handle(command);
            if(result.User == null)
                return new GenericCommandResult(result.Success, result.Message, null);
 
            string secret = this._configuration.GetSection("Security")["Secret"];
            var token = TokenService.GenerateToken(result.User, secret);

            return new GenericCommandResult(result.Success, result.Message, new
            {
                user = new { email = result.User.Email, name = result.User.Name },
                token = token
            });
        }
    }
}
