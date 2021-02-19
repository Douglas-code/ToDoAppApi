using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(Guid user)
        {
            return x => x.User.Id == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(Guid user)
        {
            return x => x.User.Id == user && x.Done == true;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(Guid user)
        {
            return x => x.User.Id == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(Guid user, DateTime date, bool done)
        {
            return x => x.User.Id == user && x.Done == done & x.Date.Date == date.Date;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id, Guid user)
        {
            return x => x.Id == id && x.User.Id == user;
        }
    }
}
