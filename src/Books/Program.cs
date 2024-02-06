using Books.Infrastructure.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceGraphQL(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello from Books API!");
app.MapGraphQL();

app.Run();
