using Core.Exceptions;
using Core.Models.Responses;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Users
{
    public class UpdateUserCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"User Not Found.");

            entity.Name = command.Name;
            entity.UserName = command.UserName;
            entity.Password = command.Password;
            entity.Email = command.Email;
            entity.PhoneNum = command.PhoneNum;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
