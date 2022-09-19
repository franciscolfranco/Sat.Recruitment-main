namespace Sat.Recruitment.Api.Services
{
    using System.Threading.Tasks;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.DataAccess.Repositories;
    using Sat.Recruitment.Api.Helpers;
    using Sat.Recruitment.Api.Models;
    using Sat.Recruitment.Api.Models.ViewModels;

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMoneyHelper _moneyHelper;

        public UserService(IUserRepository repository, IMoneyHelper moneyHelper)
        {
            _repository = repository;
            _moneyHelper = moneyHelper;
        }

        /// <inheritdoc />
        public Task<Result<User>> CreateUser(UserCreateModel model)
        {
            Result<User> result = new Result<User>();

            if (model == null)
            {
                return Task.FromResult(result.BadRequest("Model can not be null"));
            }

            User user = User.FromModel(model);

            if (IsUserDuplicated(user))
            {
                return Task.FromResult(result.BadRequest($"User: {model.Email} already exists."));
            }

            model.Money = _moneyHelper.CalculateGif(model.UserType, model.Money);

            return _repository.Add(user);
        }

        private bool IsUserDuplicated(User user)
        {
            return _repository.IsUserDuplicated(user);
        }
    }
}
