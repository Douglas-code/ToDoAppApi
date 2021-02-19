using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, Guid user)
        {
            this.Id = id;
            this.Title = title;
            this.UserId = user;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid UserId { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
                    .HasMinLen(this.Title, 3, "Title", "Por favor, descreva melhor essa tarefa!")
            );
        }
    }
}
