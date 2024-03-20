using Application.Models.Users;
using Application.Parameters.Users;
using AutoMapper;
using Core.Models.Responses;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Users
{
    public class GetUsersQuery : IRequest<PagedResponse<IReadOnlyList<UserModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNum { get; set; }
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResponse<IReadOnlyList<UserModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(IMapper mapper,
            IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<UserModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<UserParameter>(request);
            return await _repository.GetModelPagedReponseAsync<UserParameter, UserModel>(validFilter);
        }
    }
}
