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

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ở đây chỉ cho phép frontend (chạy ở http://localhost:4200) gọi API.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:4200") // Thay đổi địa chỉ này thành địa chỉ frontend
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Build the web application
var app = builder.Build();

// Middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

// Use Swagger
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
