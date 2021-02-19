using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public IEnumerable<TodoItem> GetAll(Guid user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllByPeriod(Guid user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(Guid user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(Guid user)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, Guid user)
        {
            return new TodoItem("Titulo Aqui", DateTime.Now, new User("barry allen", "barryallen@dc.com.br", "12321123W"));
        }

        public void Update(TodoItem todo)
        {
            
        }
    }
}
