using EMS.Business.Services;

namespace EMS.Web.ServiceCollection
{
    public static class DependencyServiceCollectionExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<AuthenticateUserService>();
            services.AddTransient<OrgDivisionService>();
            services.AddTransient<DepartmentService>();
        }

    }
}
