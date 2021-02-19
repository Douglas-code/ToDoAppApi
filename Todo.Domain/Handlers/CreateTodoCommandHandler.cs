using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class CreateTodoCommandHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUserRepository _userRepository;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IUserRepository userRepository)
        {
            this._todoRepository = todoRepository;
            this._userRepository = userRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está errada!", command.Notifications);

            User user = this._userRepository.GetUserById(command.UserId);
            TodoItem todo = new TodoItem(command.Title, command.Date, user);
            this._todoRepository.Create(todo);
            return new GenericCommandResult(true, "Tarefa criada com sucesso!", todo);
        }
    }
}
