namespace Sat.Recruitment.Api
{
    using Microsoft.Extensions.DependencyInjection;
    using Sat.Recruitment.Api.DataAccess.Repositories;
    using Sat.Recruitment.Api.Helpers;
    using Sat.Recruitment.Api.Services;

    public static class DependencyInjectionConfig
    {
        public static void AddTransientServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMoneyHelper, MoneyHelper>();
        }
    }
}
