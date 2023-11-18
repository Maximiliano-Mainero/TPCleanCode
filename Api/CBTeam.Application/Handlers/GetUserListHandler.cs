using AutoMapper;
using CBTeam.Application.Contract;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CBTeam.Application.Handlers
{
    public class GetUserListHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUserListHandler(
            IUserRepository userRepository, 
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserListResponse> Handle(
            GetUserListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserListResponse();

            var userList = _userRepository.GetList();                       
            response.UserList = userList
                .Select(MapTo)
                .ToList();

            return response;
        }

        private UserDto MapTo(User user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
