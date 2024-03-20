namespace NetWebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMassTransit(x =>
            //{
            //    #region AddRequestClient
            //    x.AddRequestClient<GetArticlessRequest>();
            //    #endregion

            //    #region AddConsumer
            //    x.AddConsumer<CreateArticleBarcodeRequestConsumer>();
            //    #endregion

            //    #region UsingRabbitMq

            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.PrefetchCount = 50;
            //        cfg.AutoDelete = true;
            //        cfg.Durable = true;

            //        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            //        {
            //            var host = new Uri(configuration["RabbitMQSettings:Uri"]);
            //            _ = bool.TryParse(configuration["RabbitMQSettings:SSL"], out bool ssl);
            //            cfg.Host(host, h =>
            //            {
            //                h.Username(configuration["RabbitMQSettings:Username"]);
            //                h.Password(configuration["RabbitMQSettings:Password"]);
            //                if (ssl)
            //                {
            //                    h.UseSsl(s =>
            //                    {
            //                        s.Protocol = SslProtocols.Tls12;
            //                    });
            //                }
            //            });
            //        }
            //        else
            //        {
            //            var host = Environment.GetEnvironmentVariable("RabbitMQ_Host");
            //            _ = ushort.TryParse(Environment.GetEnvironmentVariable("RabbitMQ_Port"), out ushort port);
            //            _ = bool.TryParse(Environment.GetEnvironmentVariable("RabbitMQ_SSL"), out bool ssl);
            //            var username = Environment.GetEnvironmentVariable("RabbitMQ_Username");
            //            var password = Environment.GetEnvironmentVariable("RabbitMQ_Password");
            //            cfg.Host(host, port, "/", h =>
            //            {
            //                h.Username(username);
            //                h.Password(password);
            //                if (ssl)
            //                {
            //                    h.UseSsl(s =>
            //                    {
            //                        s.Protocol = SslProtocols.Tls12;
            //                    });
            //                }
            //            });
            //        }


            //    });
            //    #endregion
            //});
            //services.AddEventBusService();
        }
    }
}
