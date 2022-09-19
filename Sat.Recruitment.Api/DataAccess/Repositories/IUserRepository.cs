namespace Sat.Recruitment.Api.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.Models;

    public interface IUserRepository
    {
        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Result<User>> Add(User user);

        /// <summary>
        /// Searches the database for users with same
        /// <see cref="User.Email"/>
        /// <see cref="User.Phone"/>
        /// <see cref="User.Name"/>
        /// <see cref="User.Address"/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsUserDuplicated(User user);
    }
}