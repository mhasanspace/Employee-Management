using EMS.Domain;
using EMS.Domain.IRepository;
using EMS.Persistence;
using EMS.Persistence.Repository;

namespace EMS.Web.ServiceCollection
{
    public static class EntityServiceCollectionExtensions
    {
        public static void AddEntityFrameworkService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepositoryBase<>), typeof(Repository<>));

            services.AddTransient<IAuthenticateUserRepository, AuthenticateUserRepository>();

            services.AddTransient<IOrgDivisionRepository, OrgDivisionRepository>();
        }

    }
}
