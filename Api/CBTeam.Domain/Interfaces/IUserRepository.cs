using CBTeam.Domain.Entities;

namespace CBTeam.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetList();

        List<User> GetListForName(string name);
    }
}
