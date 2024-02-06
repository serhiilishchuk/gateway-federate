namespace Gateway.Infrastructure.GraphQL
{
    internal class GraphQLOptions
    {
        public const string Section = "GraphQL";

        public string? ServiceName { get; set; }
        public bool RichOutput { get; set; } = false;
        public uint RequestTimeoutSec { get; set; } = 60;
        public string? RedisEndpoint { get; set; }
        public List<SchemaService> Services { get; set; } = [];

        public TimeSpan RequestTimeout => TimeSpan.FromSeconds(RequestTimeoutSec);
    }

    internal class SchemaService
    {
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
