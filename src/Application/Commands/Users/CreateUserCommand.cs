using AutoMapper;
using Core.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Users
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNum { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public CreateUserCommandHandler(IMapper mapper,
            IUserRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
