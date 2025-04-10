using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Core.ServiceContracts;
using EShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}

