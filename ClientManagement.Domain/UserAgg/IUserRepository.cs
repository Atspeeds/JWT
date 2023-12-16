using ClientManagement.Application.Contract.UserCo;

namespace ClientManagement.Domain.UserAgg
{
    public interface IUserRepository
    {
        bool CreateUser(CreateUser command);
        string LoginUser(string userName,string password);
    }
}
