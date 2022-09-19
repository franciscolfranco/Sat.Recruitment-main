namespace Sat.Recruitment.Api.Services
{
    using System.Threading.Tasks;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.Models;
    using Sat.Recruitment.Api.Models.ViewModels;

    public interface IUserService
    {
        /// <summary>
        /// Creates User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<User>> CreateUser(UserCreateModel model);
    }
}
