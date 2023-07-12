﻿namespace Motorsport1.Web.Infrastructor.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Mototsport1.Services.Data;
    using Mototsport1.Services.Data.Interfaces;
    using System.Reflection;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type st in serviceTypes)
            {
                Type? interfaceType = st
                    .GetInterface($"I{st.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No service is provided for the service with name: {st.Name}");
                }

                services.AddScoped(interfaceType, st);
            }
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}