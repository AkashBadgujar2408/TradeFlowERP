using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradeFlowERP.Core.Shared.ServiceContracts;
using TradeFlowERP.Core.Shared.Services;

namespace TradeFlowERP.Core;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}