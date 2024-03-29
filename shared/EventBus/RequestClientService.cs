using EventBus.Services.RabbitMQ;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus
{
    public class RequestClientService : IRequestClientService
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestClientService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Response<TResponse>> GetResponseAsync<TRequest, TResponse>(TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            var requestClient = _serviceProvider.GetRequiredService<IRequestClient<TRequest>>();
            return await requestClient.GetResponse<TResponse>(request, cancellationToken);
        }
    }
}