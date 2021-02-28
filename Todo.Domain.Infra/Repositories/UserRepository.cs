using System;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CheckIfEmailHasAlreadyBeenRegistered(User user)
        {
            return this._context.Users.Any(x => x.Email == user.Email);
        }

        public void Create(User user)
        { 
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this._context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public User GetUserById(Guid userId)
        {
            return this._context.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
