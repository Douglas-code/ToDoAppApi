using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTest
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todoItem = new TodoItem("Titulo aqui", DateTime.Now, "Bruce Waine");

        [TestMethod]
        public void DadoUmNovoTodoOMesmoNaoPodeEstarConcluido()
        {
            Assert.IsFalse(this._todoItem.Done);
        }
    }
}
