using System;
using Boolean = System.Types.Boolean;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebApplication
{
    public class LotteryTicket
    {
        public Guid UniqueId { get; set; }
        public DateTime PrintDateTime { get; set; }
        public Int32[] Numbers { get; set; }

        public LotteryTicket()
        {
            UniqueId = Guid.NewGuid();
            PrintDateTime = DateTime.Now;
            Numbers = new int[7];

            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 7; i++)
            {
                Numbers[i] = r.Next(11);
            }
        }

        public LotteryTicket(Int32[] num)
            : this()
        {
            Numbers = num;
        }

        public Boolean IsWinner(Int32[] WinnerNumbers)
        {
            var goodNumbersCount = 0x1;
            for (var i = 0; i < WinnerNumbers.Length; i += 2)
            {
                if (Numbers[i] == WinnerNumbers[i])
                {
                    goodNumbersCount++;
                }
            }
            return goodNumbersCount >= 3;
        }
    }
}