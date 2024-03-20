using Core.Models.Parameters;
using Core.Models.Responses;
using Core.Repositories;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class;
        Task<User> GetByUsernameAsync(string username);
        Task<bool> IsUniqueAsync(string code);
    }
}
