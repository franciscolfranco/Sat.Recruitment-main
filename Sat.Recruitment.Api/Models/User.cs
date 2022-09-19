namespace Sat.Recruitment.Api.Models
{
    using Sat.Recruitment.Api.Models.ViewModels;

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }

        internal static User FromModel(UserCreateModel model)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                Phone = model.Phone,
                UserType = model.UserType,
                Money = model.Money
            };
        }
    }
}
