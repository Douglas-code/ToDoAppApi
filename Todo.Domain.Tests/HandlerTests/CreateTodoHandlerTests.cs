using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da Tarefa", "Bruce Wayne", DateTime.Now);
        private readonly CreateTodoCommandHandler _handler = new CreateTodoCommandHandler(new FakeTodoRepository());

        [TestMethod]
        public void DadoUmComandoInvalidoDeveInterromperExecucao()
        {
            
            GenericCommandResult result = (GenericCommandResult)this._handler.Handle(this._invalidCommand);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveCriarTarefa()
        {
            GenericCommandResult result = (GenericCommandResult)this._handler.Handle(this._validCommand);
            Assert.IsTrue(result.Success);
        }
    }
}