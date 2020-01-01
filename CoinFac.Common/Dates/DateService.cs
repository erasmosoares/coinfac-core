using System;

namespace CoinFac.Common.Dates
{
    public class DateService : IDateService
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}
