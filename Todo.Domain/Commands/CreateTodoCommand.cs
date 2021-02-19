using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, Guid userId, DateTime date)
        {
            this.Title = title;
            this.UserId = userId;
            this.Date = date;
        }

        public string Title { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

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
