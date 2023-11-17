using CBTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetList(string userName);
    }
}
