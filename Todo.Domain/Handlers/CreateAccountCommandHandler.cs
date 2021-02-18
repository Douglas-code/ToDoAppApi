using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class CreateAccountCommandHandler : IHandler<CreateAccountCommand>
    {
        private readonly IUserRepository _repository;

        public CreateAccountCommandHandler(IUserRepository userRepository)
        {
            this._repository = userRepository;
        }

        public ICommandResult Handle(CreateAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Falha ao Criar Conta!", command.Notifications);

            User user = new User(command.Name, command.Email, command.Password);
            if(this._repository.CheckIfEmailHasAlreadyBeenRegistered(user))
                return new GenericCommandResult(false, "Falha ao Criar Conta!", "Email Já Está Sendo Utilizado");

            this._repository.Create(user);

            return new GenericCommandResult(true, "Conta Criada com Sucesso!", new { Name = user.Name, Email = user.Email });
        }
    }
}
