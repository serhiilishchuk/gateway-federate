namespace Books.Infrastructure.GraphQL
{
    internal class GraphQLOptions
    {
        public const string Section = "GraphQL";

        public string? ServiceName { get; set; }
        public bool RichOutput { get; set; } = false;
        public uint RequestTimeoutSec { get; set; } = 60;
        public GraphQLFederation Federation { get; set; } = new();

        public TimeSpan RequestTimeout => TimeSpan.FromSeconds(RequestTimeoutSec);
    }

    internal class GraphQLFederation
    {
        public string? GatewayName { get; set; }
        public string? RedisEndpoint { get; set; }
        public bool IsEnabled { get; set; } = false;
    }
}
