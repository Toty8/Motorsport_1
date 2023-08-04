namespace Motorsport1.Web.Infrastructor.Extensions
{
    using System.Reflection;
    using Microsoft.AspNetCore.Antiforgery.Internal;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.Extensions.DependencyInjection;

    using Motorsport1.Data.Models;
    using Mototsport1.Services.Data;
    using Mototsport1.Services.Data.Interfaces;
    using static Common.GeneralApplicationConstants;

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

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManger =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await userManger.FindByEmailAsync(email);

                await userManger.AddToRoleAsync(adminUser, AdminRoleName);
            })
                .GetAwaiter()
                .GetResult();

            CreatePublisher(app, email);

            return app;
        }

        public static IApplicationBuilder CreatePublisher(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManger =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync(PublisherRoleName))
                {
                    IdentityRole<Guid> role = new IdentityRole<Guid>(PublisherRoleName);

                    await roleManager.CreateAsync(role);
                }

                ApplicationUser publisherUser = await userManger.FindByEmailAsync(email);

                await userManger.AddToRoleAsync(publisherUser, PublisherRoleName);
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
