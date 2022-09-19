using System;

namespace Sat.Recruitment.Api.Helpers
{
    public class MoneyHelper : IMoneyHelper
    {
        /// <inheritdoc />
        public decimal CalculateGif(UserType userType, decimal money)
        {
            // TODO: Create file with the constants
            switch (userType)
            {
                case UserType.Normal:
                    return money > 100 ?
                        money * Convert.ToDecimal(1.12) :
                        money * Convert.ToDecimal(1.08);
                case UserType.SuperUser:
                    return money > 100 ?
                        money * Convert.ToDecimal(1.20) :
                        money;
                case UserType.Premium:
                    return money > 100 ?
                        money * Convert.ToDecimal(2) :
                        money;
                default: 
                    return money;
            }
        }
    }
}
