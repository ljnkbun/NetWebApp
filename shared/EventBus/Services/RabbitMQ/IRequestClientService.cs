using MassTransit;

namespace EventBus.Services.RabbitMQ
{
    public interface IRequestClientService
    {
        Task<Response<TResponse>> GetResponseAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class;
    }
}
