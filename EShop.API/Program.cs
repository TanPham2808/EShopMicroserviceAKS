using System.Text.Json.Serialization;
using EShop.API.Middlewares;
using EShop.Core;
using EShop.Core.Mapper;
using EShop.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure, Core services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controller to the container.
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Chuyển từ string về enum
});

// Bổ sung Auto Mapper
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// Bổ sung FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// Build the web application
var app = builder.Build();

// Middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
