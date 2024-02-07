using Gateway.Infrastructure.GraphQL;
using HotChocolate.AspNetCore.Voyager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.HostGraphQLFederation(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello from Gateway!");
app.MapGraphQL();
//app.UseVoyager("/graphql", "/ghui");

app.Run();