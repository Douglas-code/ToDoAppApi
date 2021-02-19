using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class MarkTodoAsDoneCommandHandler : IHandler<MarkTodoAsDoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public MarkTodoAsDoneCommandHandler(ITodoRepository todoRepository, IUserRepository userRepository)
        {
            this._todoRepository = todoRepository;
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua Tarefa está errada", command.Notifications);

            TodoItem todoItem = this._todoRepository.GetById(command.Id, command.UserId);
            todoItem.MarkAsDone();
            this._todoRepository.Update(todoItem);
            return new GenericCommandResult(true, "Tarefa Concluída com Sucesso", todoItem);
        }
    }
}
