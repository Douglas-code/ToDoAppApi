using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsUndoneCommand() { }

        public MarkTodoAsUndoneCommand(Guid id, Guid user)
        {
            this.Id = id;
            this.UserId = user;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
            );
        }
    }
}
