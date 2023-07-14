using FastEndpoints;
using FastEndpointTutorial.Api.Database;
using FastEndpointTutorial.Api.Repositories;
using FastEndpointTutorial.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddSingleton<IDbConnectionFactory>(_ 
    => new SqliteConnectionFactory(config.GetConnectionString("CustomersDb")));

builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();

builder.Services.AddFastEndpoints();

var app = builder.Build();

//app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseDefaultExceptionHandler(); 
app.UseFastEndpoints();

app.UseAuthorization(); 

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();