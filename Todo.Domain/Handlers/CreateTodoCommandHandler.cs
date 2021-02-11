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

        public CreateTodoCommandHandler(ITodoRepository todoRepository)
        {
            this._todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está errada!", command.Notifications);

            TodoItem todo = new TodoItem(command.Title, command.Date, command.User);
            this._todoRepository.Create(todo);
            return new GenericCommandResult(true, "Tarefa criada com sucesso!", todo);
        }
    }
}
