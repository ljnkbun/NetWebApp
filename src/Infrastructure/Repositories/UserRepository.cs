using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Extensions.Objects;
using Core.Models.Parameters;
using Core.Models.Responses;
using Core.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(WebAppContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _users = _dbContext.Set<User>();
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            var rs = await _users
                .FirstOrDefaultAsync(x => x.UserName == username);

            return rs;
        }


        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _users.Filter(parameter);
            query = query.Where(x => x.IsActive == true);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            return response;
        }

        public async Task<bool> IsUniqueAsync(string username)
        {
            return await _users.AllAsync(x => x.UserName != username);
        }
    }
}
