﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [Authorize]
    [ApiController, Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet, Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll(Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()));
        }

        [HttpGet, Route("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone(Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()));
        }

        [HttpGet, Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone(Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()));
        }

        [HttpGet, Route("done/today")]
        public IEnumerable<TodoItem> GetAllDoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()), DateTime.Now.Date, true);
        }

        [HttpGet, Route("undone/today")]
        public IEnumerable<TodoItem> GetAllUndoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()), DateTime.Now.Date, false);
        }

        [HttpPost, Route("")]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] IHandler<CreateTodoCommand> handler)
        {
            command.UserId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut, Route("")]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] IHandler<UpdateTodoCommand> handler)
        {
            command.UserId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut, Route("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] IHandler<MarkTodoAsDoneCommand> handler)
        {
            command.UserId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut, Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] IHandler<MarkTodoAsUndoneCommand> handler)
        {
            command.UserId = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
