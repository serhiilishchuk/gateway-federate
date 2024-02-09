using HotChocolate.Execution.Configuration;
using StackExchange.Redis;

namespace Authors.Infrastructure.GraphQL;

internal static class RequestExecutionBuilderExtensions
{
    internal static IRequestExecutorBuilder GatewayPublishSchemaDefinition(this IRequestExecutorBuilder builder, GraphQLOptions options)
    {
        if (options.Federation.IsEnabled)
        {
            builder.PublishSchemaDefinition(descriptor => descriptor
                .SetName(options.ServiceName!)
                .PublishToRedis(options.Federation.GatewayName!, sp => sp.GetRequiredService<IConnectionMultiplexer>())
            );
        }

        return builder;
    }
}