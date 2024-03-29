using System.Text.Json;
using Confluent.Kafka;
using Core.Models.Responses;
using EventBus.Services.Kafka;
using Microsoft.Extensions.Options;

namespace EventBus
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly ProducerConfig _producerConfig;

        public KafkaProducerService(IOptions<ProducerConfig> options)
        {
            _producerConfig = options.Value;
        }

        public void PublishMessage<TRequest>(string topic, TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : class
        {
            using var producer = new ProducerBuilder<string, string>(_producerConfig).Build();
            producer.Produce(topic,
                new Message<string, string> { Value = JsonSerializer.Serialize(request), Key = new Guid().ToString() });
        }

        public async Task<Response<TResponse>> GetResponseAsync<TRequest, TResponse>(string topic, TRequest request,
            CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
        {
            using var producer = new ProducerBuilder<string, string>(_producerConfig).Build();
            var rs = await producer.ProduceAsync(topic,
                new Message<string, string> { Value = JsonSerializer.Serialize(request), Key = new Guid().ToString() },
                cancellationToken);

            return new Response<TResponse>(JsonSerializer.Deserialize<TResponse>(rs.Value) ?? throw new InvalidOperationException());
        }
    }
}