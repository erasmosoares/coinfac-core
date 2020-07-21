using System;

namespace CoinFac.Service.Dtos
{
    public class RecordDto
    {
        public string Account { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }
    }
}
