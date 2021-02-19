using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand() { }

        public MarkTodoAsDoneCommand(Guid id, Guid user)
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
