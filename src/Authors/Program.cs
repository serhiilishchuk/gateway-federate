using Authors.Infrastructure.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceGraphQL(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello from Authors API!");
app.MapGraphQL();

app.Run();