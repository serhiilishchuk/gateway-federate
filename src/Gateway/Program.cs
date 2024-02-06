using Gateway.Infrastructure.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.HostGraphQLFederation(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello from Gateway!");
app.MapGraphQL();

app.Run();