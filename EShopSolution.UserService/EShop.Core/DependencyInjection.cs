using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Core.ServiceContracts;
using EShop.Core.Services;
using EShop.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();

        // Phương thức này sẽ tìm toàn bộ class validator (IValidator<T>) nằm trong assembly 
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}

