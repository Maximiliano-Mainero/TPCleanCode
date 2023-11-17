using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Contract
{
    // Input, los handler que entran al handler
    // Lo debo marcar como request y ademas que va a devolver --> : IRequest<GetUserListResponse>
    public class GetUserListRequest : IRequest<GetUserListResponse>
    {
        public String? name { get; set; }
    }
}
