using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class UpdateTodoCommandHandler : IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua Tarefa está errada", command.Notifications);

            TodoItem todoItem = this._todoRepository.GetById(command.Id, command.User);
            todoItem.UpdateTitle(command.Title);
            this._todoRepository.Update(todoItem);
            return new GenericCommandResult(true, "Tarefa Alterada com sucesso", todoItem);
        }
    }
}
