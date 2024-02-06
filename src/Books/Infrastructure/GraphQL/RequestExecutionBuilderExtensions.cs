﻿using HotChocolate.Execution.Configuration;
using StackExchange.Redis;

namespace Books.Infrastructure.GraphQL;

internal static class RequestExecutionBuilderExtensions
{
    internal static IRequestExecutorBuilder GatewayPublishSchemaDefinition(this IRequestExecutorBuilder builder, GraphQLOptions options)
    {
        if (options.Federation.IsEnabled)
        {
            builder.PublishSchemaDefinition(c => c
                .SetName(options.ServiceName!)
                .PublishToRedis(options.Federation.GatewayName!, sp => sp.GetRequiredService<IConnectionMultiplexer>())
            );
        }

        return builder;
    }
}