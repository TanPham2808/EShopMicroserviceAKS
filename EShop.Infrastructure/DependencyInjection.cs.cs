using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Core.RepositoryContracts;
using EShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        return services;
    }
}

