using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class LoginCommandResult : ICommandResult
    {
        public LoginCommandResult() { }

        public LoginCommandResult(bool success, string message, string email, string password)
        {
            this.Success = success;
            this.Message = message;
            this.Email = email;
            this.Password = password;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
