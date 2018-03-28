using System;
using System.Linq;

namespace ExampleWebApplication
{
    public class LotteryTicket
    {
        public Guid UniqueId { get; set; }
        public DateTime PrintDateTime { get; set; }
        public int[] Numbers { get; set; }

        public LotteryTicket(int[] num)
        {
            UniqueId = Guid.NewGuid();
            PrintDateTime = DateTime.Now;
            Numbers = num;
        }

        public bool IsWinner(int[] winnerNumbers)
        {
            var loops = 4;
            var count = 0;

            for (var i = 0; i < loops; i++)
            {
                if (winnerNumbers.Contains(Numbers[i]))
                {
                    count++;
                    if (count >= 3)
                        return true;

                    loops++;
                }
            }

            return false;
        }
    }
}