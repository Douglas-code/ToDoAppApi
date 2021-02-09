using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand() { }

        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            this.Id = id;
            this.User = user;
        }

        public Guid Id { get; set; }

        public string User { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
                    .HasMinLen(this.User, 6, "User", "Usuário Inválido!")
            );
        }
    }
}
