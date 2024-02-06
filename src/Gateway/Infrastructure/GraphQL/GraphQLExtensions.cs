﻿using StackExchange.Redis;

namespace Gateway.Infrastructure.GraphQL
{
    internal static class GraphQLExtensions
    {
        internal static IServiceCollection HostGraphQLFederation(this IServiceCollection services, IConfiguration configuration)
        {
            var graphQlOptions = new GraphQLOptions();
            configuration
                .GetSection(GraphQLOptions.Section)
                .Bind(graphQlOptions);

            foreach(var config in graphQlOptions.Services)
            {
                services.AddHttpClient(config.Name, c => c.BaseAddress = new Uri(config.Endpoint));
            }

            services
                .AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(graphQlOptions.RedisEndpoint!))
                .AddGraphQLServer()
                .ModifyRequestOptions(options => options.ExecutionTimeout = graphQlOptions.RequestTimeout)
                .InitializeOnStartup()
                .AddRemoteSchemasFromRedis(graphQlOptions.ServiceName!, sp => sp.GetRequiredService<ConnectionMultiplexer>());

            return services;
        }
    }
}