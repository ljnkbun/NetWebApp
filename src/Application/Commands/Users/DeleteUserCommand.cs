using Core.Exceptions;
using Core.Models.Responses;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
    {
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"User Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
