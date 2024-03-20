using Core.Exceptions;
using Core.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Users
{
    public class GetUserQuery : IRequest<Response<User>>
    {
        public int Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<User>>
    {
        private readonly IUserRepository _repository;
        public GetUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<User>> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Users Not Found (Id:{query.Id}).");
            return new Response<User>(entity);
        }
    }
}
