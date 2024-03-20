namespace Cache.Services
{
    public interface ICachingService
    {
        Task SetAsync<T>(string key, T data, TimeSpan slidingExpiration, CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    }
}
