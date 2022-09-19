namespace Sat.Recruitment.Api.DataAccess.Settings
{
    using System.Linq;
    using Sat.Recruitment.Api.Models;

    /// <summary>
    /// Initializes DB if it does not exist
    /// </summary>
    public static class  RecruitmentDbInitializer
    {
        public static void Initialize(RecruitmentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(new User 
            {
                Name = "Juan",
                Email = "juan@marmol.com",
                Phone = "+5491154762312",
                Address = "Peru 2464",
                UserType = UserType.Normal,
                Money = 1234
            });

            context.Users.Add(new User
            {
                Name = "Franco",
                Email = "franco.perez@gmail.com",
                Phone = "+534645213542",
                Address = "Alvear y Colombres",
                UserType = UserType.Premium,
                Money = 112234
            });

            context.Users.Add(new User
            {
                Name = "Agustina",
                Email = "agustina@gmail.com",
                Phone = "+534645213542",
                Address = "Garay y Otra Calle",
                UserType = UserType.SuperUser,
                Money = 112234
            });

            context.SaveChanges();
        }
    }
}
