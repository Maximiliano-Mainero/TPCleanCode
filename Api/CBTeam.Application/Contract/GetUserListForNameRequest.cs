using MediatR;

namespace CBTeam.Application.Contract
{
    public class GetUserListForNameRequest : IRequest<GetUserListForNameResponse>
    {
        public String? name { get; set; }
    }
}
