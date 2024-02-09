using Gateway.Infrastructure.GraphQL;
using HotChocolate.AspNetCore.Voyager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLFederation(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello from Gateway!");
app
    .MapGraphQL()
    .AllowAnonymous();
app.UseVoyager("/graphql", "/ui");

app.Run();