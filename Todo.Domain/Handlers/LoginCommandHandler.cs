using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class LoginCommandHandler : Notifiable, ILoginHandler<LoginCommand>
    {
        private readonly IUserRepository _repository;

        public LoginCommandHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new LoginCommandResult(false, "Email ou senha incorretos!", null);

            User user = this._repository.GetUserByEmailAndPassword(command.Email, command.Password);
            if (user == null)
                return new LoginCommandResult(false, "Email ou senha incorretos!", null);

            return new LoginCommandResult(true, "Login efetuado com sucesso!", user);
        }
    }
}
