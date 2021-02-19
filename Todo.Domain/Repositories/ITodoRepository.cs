using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);

        void Update(TodoItem todo);

        TodoItem GetById(Guid id, Guid user);

        IEnumerable<TodoItem> GetAll(Guid user);

        IEnumerable<TodoItem> GetAllDone(Guid user);

        IEnumerable<TodoItem> GetAllUndone(Guid user);

        IEnumerable<TodoItem> GetAllByPeriod(Guid user, DateTime date, bool done);
    }
}
