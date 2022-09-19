namespace Sat.Recruitment.Api.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.Models;

    public class UserRepository : IUserRepository
    {
        private readonly RecruitmentContext _context;

        public UserRepository(RecruitmentContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Result<User>> Add(User user)
        {
            Result<User> result = new Result<User>();

            _context.Users.AddAsync(user);

            Task<int> response = _context.SaveChangesAsync();

            if (!response.IsCompletedSuccessfully)
            {
                return Task.FromResult(result.Failed("Unhandled error adding user"));
            }

            return Task.FromResult(result.Success(user));
        }

        /// <inheritdoc />
        public bool IsUserDuplicated(User user)
        {
            IQueryable<User> query = _context.Users
                .AsNoTracking()
                .Where(u =>
                    u.Email == user.Email ||
                    u.Phone == user.Phone ||
                    u.Name == user.Name ||
                    u.Address == user.Address);

            return query.Any();
        }
    }
}