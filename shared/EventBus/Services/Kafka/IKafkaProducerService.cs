using Core.Models.Responses;

namespace EventBus.Services.Kafka;

public interface IKafkaProducerService
{
    void PublishMessage<TRequest>(string topic, TRequest request, CancellationToken cancellationToken = default)
        where TRequest : class;

    Task<Response<TResponse>> GetResponseAsync<TRequest, TResponse>(string topic, TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : class
        where TResponse : class;
}