using System;
using System.Collections.Generic;
using System.Text;

namespace SproutSolution.Core.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
