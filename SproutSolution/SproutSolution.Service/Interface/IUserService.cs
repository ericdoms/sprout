using SproutSolution.Core.Model;
using System.Threading.Tasks;

namespace SproutSolution.Service.Interface
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
