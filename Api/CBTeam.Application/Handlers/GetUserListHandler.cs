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
        private readonly IValidator<GetUserListRequest> _validator;
        public GetUserListHandler(
            IUserRepository userRepository, 
            IValidator<GetUserListRequest> validator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<GetUserListResponse> Handle(
            GetUserListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserListResponse();
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception("La solicitud no es válida: " +result.Errors[0].ErrorMessage);
            }

            var userList = _userRepository.GetList(request.name);               
            if (userList.Count==0)
            {
                throw new Exception("No se encontraron resultados coincidentes");
            }
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
