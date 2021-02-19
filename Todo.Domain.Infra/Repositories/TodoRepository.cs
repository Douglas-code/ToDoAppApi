using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(TodoItem todo)
        {
            this._context.Todos.Add(todo);
            this._context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(Guid user)
        {
            return this._context.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllByPeriod(Guid user, DateTime date, bool done)
        {
            return this._context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(Guid user)
        {
            return this._context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(Guid user)
        {
            return this._context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, Guid user)
        {
            return this._context.Todos.FirstOrDefault(TodoQueries.GetById(id, user));
        }

        public void Update(TodoItem todo)
        {
            this._context.Entry(todo).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
