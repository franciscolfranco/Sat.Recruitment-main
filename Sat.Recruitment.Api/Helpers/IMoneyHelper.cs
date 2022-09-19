namespace Sat.Recruitment.Api.Helpers
{
    public interface IMoneyHelper
    {
        /// <summary>
        /// Adds gif based on the <see cref="UserType"/>
        /// and the amount of money
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public decimal CalculateGif(UserType userType, decimal money);
    }
}
