using EShop.Core;
using EShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure, Core services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controller to the container.
builder.Services.AddControllers();

// Build the web application
var app = builder.Build();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
