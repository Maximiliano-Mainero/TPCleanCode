using CBTeam.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Contract
{
    public class GetUserListForNameResponse
    {
        public List<UserDto>? UserList { get; set; }
    }
}
