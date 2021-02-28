using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class LoginCommand : Notifiable, ICommand
    {
        public LoginCommand() { }

        public LoginCommand(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
                    .HasMinLen(this.Password, 8, "Password", "Senha deve conter 8 caracteres")
                    .HasMaxLen(this.Password, 8, "Password", "Senha deve conter 8 caracteres")
                    .IsEmail(this.Email, "Email", "Email inválido")
            );
        }
    }
}
