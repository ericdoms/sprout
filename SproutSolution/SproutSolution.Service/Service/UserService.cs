using SproutSolution.Core.Model;
using SproutSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Service.Service
{
    public class UserService : IUserService
    {
        //dummy account
        private List<User> _users = new List<User>
        {
            new User { Id = Guid.Parse("298597B6-881D-4A34-A3B2-2272BEA09AE7"), Username = "sprout", Password = "solution" }
        };
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            if (user == null)
                return null;

            return user;
        }
    }
}
