using AutoMapper;
using CBTeam.Application.Contract;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using FluentValidation;
using MediatR;


namespace CBTeam.Application.Handlers
{
    public class GetUserListForNameHandler : IRequestHandler<GetUserListForNameRequest, GetUserListForNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<GetUserListForNameRequest> _validator;
        public GetUserListForNameHandler(
            IUserRepository userRepository,
            IValidator<GetUserListForNameRequest> validator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<GetUserListForNameResponse> Handle(
            GetUserListForNameRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserListForNameResponse();
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception("La solicitud no es válida: " + result.Errors[0].ErrorMessage);
            }

            var userList = _userRepository.GetListForName(request.name);
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
