using AutoMapper;
using CBTeam.Application.Contract;
using CBTeam.Application.Handlers;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;


namespace CBTeam.Test
{
    public class GetUserListHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IValidator<GetUserListRequest>> _validator;

        private GetUserListHandler handler;

        public GetUserListHandlerTests()
        {
            var userDto = new UserDto()
            {
                Firstname = "xxx"
            };

            var userList = new List<User>
            {
                new User
                {
                    FirstName="maxi",
                },
                new User
                {
                    FirstName="user2"
                }
            };

            var userDtoList = new List<UserDto>
            {
                new UserDto
                {
                     Firstname="userDto1",
                },
                new UserDto
                {
                    Firstname="userDto2"
                }
            };

            var result = new ValidationResult();
            _validator = new Mock<IValidator<GetUserListRequest>>();
            _validator.Setup(validator => validator.Validate(It.IsAny<GetUserListRequest>()))
                      .Returns(result);

            _userRepository
                .Setup(repository => repository.GetList(userDto.Firstname))
                .Returns(userList);

            _mapper = new Mock<IMapper>();
            _mapper
                .Setup(m => m.Map<List<UserDto>>(It.IsAny<List<User>>()))
                .Returns(userDtoList);

            _userRepository = new Mock<IUserRepository>();
            handler = new GetUserListHandler(_userRepository.Object, _validator.Object, _mapper.Object);
        }

        [Fact]
        public async void CuandoObtengoRequestValido_RetornoResponseValido()
        {
            await handler.Handle(new GetUserListRequest(), CancellationToken.None); 
        }
    }
}