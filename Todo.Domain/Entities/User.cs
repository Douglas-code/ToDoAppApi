﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todo.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        [JsonIgnore]
        public List<TodoItem> Todos { get; private set; }

        public void UpdatePassword(string password)
        {
            this.Password = password;
        }
    }
}
