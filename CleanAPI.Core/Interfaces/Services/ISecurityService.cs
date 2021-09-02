using CleanAPI.Core.Entities;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Services
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
