using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Contract
{
    // OUTPUT, lo que retorna el handler
    public class GetUserListResponse
    {
        public List<UserDto>? UserList { get; set; }    
    }
}
