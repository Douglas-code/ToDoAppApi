using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);

        bool CheckIfEmailHasAlreadyBeenRegistered(User user);

        User GetUserById(Guid userId);

        User GetUserByEmailAndPassword(string email, string password);
    }
}
