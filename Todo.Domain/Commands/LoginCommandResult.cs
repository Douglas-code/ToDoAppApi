using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class LoginCommandResult : ICommandResult
    {
        public LoginCommandResult() { }

        public LoginCommandResult(bool success, string message, User user)
        {
            this.Success = success;
            this.Message = message;
            this.User = user;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public User User { get; set; }
    }
}
