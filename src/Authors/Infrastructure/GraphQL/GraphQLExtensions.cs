using StackExchange.Redis;

namespace Authors.Infrastructure.GraphQL
{
    internal static class GraphQLExtensions
    {
        internal static IServiceCollection AddServiceGraphQL(this IServiceCollection services, IConfiguration configuration)
        {
            var graphQlOptions = new GraphQLOptions();
            configuration
                .GetSection(GraphQLOptions.Section)
                .Bind(graphQlOptions);

            services
                .AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(graphQlOptions.Federation!.RedisEndpoint!));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .ModifyRequestOptions(options => options.ExecutionTimeout = graphQlOptions.RequestTimeout)
                .InitializeOnStartup()
                .GatewayPublishSchemaDefinition(graphQlOptions);

            return services;
        }
    }
}
