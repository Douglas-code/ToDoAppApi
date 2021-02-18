using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateAccountCommand : Notifiable, ICommand
    {
        public CreateAccountCommand() { }

        public CreateAccountCommand(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public string Name { get; set; }

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
                    .HasMinLen(this.Name, 3, "Name", "Nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(this.Name, 160, "Name", "Nome deve conter no maximo 160 caracteres")
            );
        }
    }
}
