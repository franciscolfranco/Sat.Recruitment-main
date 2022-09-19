namespace Sat.Recruitment.Api.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.Models;
    using Sat.Recruitment.Api.Models.ViewModels;
    using Sat.Recruitment.Api.Services;

    [ApiController]
    [Route("user")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result>> CreateUserAsync(UserCreateModel model)
        {
            //Validations
            UserCreateModel.Validator validator = new UserCreateModel.Validator();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            Result<User> result = await _service.CreateUser(model);

            if (result?.IsSuccess != true)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
