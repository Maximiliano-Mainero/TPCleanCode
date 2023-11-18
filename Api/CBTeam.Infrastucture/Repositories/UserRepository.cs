using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using CBTeam.Infrastructure.Database;

namespace CBTeam.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<User> GetList()
        {
            var userList = _context
                .Set<User>()
                .ToList();

            return userList;
        }

        public List<User> GetListForName(string name)
        {
            var userList = _context
                .Set<User>()
                .Where(s => s.FirstName.Contains(name))
                .ToList();

            return userList;
        }
    }
}
