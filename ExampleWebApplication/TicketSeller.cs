using System;

namespace ExampleWebApplication
{
    public class TicketSeller
    {
        private TicketSeller() {}

        public static TicketSeller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketSeller();
                }
                return _instance;
            }
        }

        private static TicketSeller _instance;
        private double _allMoney;
        private double _income;
        private int _soldTicketsCount;
        private int _winnerTicketsCount;
        private int[] _winnerNumbers;

        private const double RandomTicketPrice = 1.0d;
        private const double PreDefinedTicketPrice = 1.5d;
        private const double IncomePercentage = 0.1d;

        public void GoToWork(int[] numbers)
        {
            _winnerNumbers = numbers;
            _winnerTicketsCount = 0;
        }

        public LotteryTicket SellRandomTicket(int[] numbers)
        {
            _income += IncomePercentage * RandomTicketPrice;
            _allMoney += RandomTicketPrice;
            var newTicket = new LotteryTicket(numbers);
            UpdateTicketsCount(newTicket);
            return newTicket;
        }

        private void UpdateTicketsCount(LotteryTicket newTicket)
        {
            _soldTicketsCount++;
            if (newTicket.IsWinner(_winnerNumbers))
                _winnerTicketsCount++;
        }

        public LotteryTicket SellPreDefinedTicket(int[] userNumbers)
        {
            _income += IncomePercentage * PreDefinedTicketPrice;
            _allMoney += PreDefinedTicketPrice;
            var newTicket = new LotteryTicket(userNumbers);
            UpdateTicketsCount(newTicket);
            return newTicket;
        }

        public double ShowIncome()
        {
            return _income;
        }

        public double ShowAllMoney()
        {
            return _allMoney;
        }

        public double GetSoldTicketsCount()
        {
            return _soldTicketsCount;
        }

        public double GetLuckyTicketsCount()
        {
            return _winnerTicketsCount;
        }

        public string GetDailyReport()
        {
            return $@"Ticket seller sold today <B>{GetSoldTicketsCount(),10}</B> tickets.
                   He collected <B>{ShowAllMoney(),10:C}</B>, his income for today is equal: <B>{ShowIncome(),10:C}</B>
                   . Lucky tickets count for today is: <B>{GetLuckyTicketsCount(),10}</B>";
        }
    }
}