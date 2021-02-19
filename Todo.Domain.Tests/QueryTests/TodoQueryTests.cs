using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        //    public TodoQueryTests()
        //    {
        //        this._items = new List<TodoItem>();
        //        this._items.Add(new TodoItem("Tarefa 1", DateTime.Now, "Barry Allen"));
        //        this._items.Add(new TodoItem("Tarefa 2", DateTime.Now, "Barry Allen"));
        //        this._items.Add(new TodoItem("Tarefa 3", DateTime.Now, "Barry andre"));
        //        this._items.Add(new TodoItem("Tarefa 4", DateTime.Now, "jose antonio"));
        //        this._items.Add(new TodoItem("Tarefa 5", DateTime.Now, "Maria Allen"));
        //    }

        //    [TestMethod]
        //    public void DadaAConsultaDeveRetornarTarefasApenasDoUsuarioBarryAllen()
        //    {
        //        var result = this._items.AsQueryable().Where(TodoQueries.GetAll(new Guid())).ToList();
        //        Assert.AreEqual(result.Count, 2);
        //    }
    }
}
