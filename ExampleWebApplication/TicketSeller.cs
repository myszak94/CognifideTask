using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebApplication
{
    public class TicketSeller
    {
        private static Double _allMoney = 0;
        private static Double _income = 0;
        private static Int32 _soldTicketsCount = 0;
        private static Int32 _winnerTicketsCount = 0;
        private static int[] winnerNumbers;

        public static void GoToWork(int[] numbers)
        {
            winnerNumbers = numbers;
            _winnerTicketsCount = 0;
        }

        public static LotteryTicket SellRandomTicket()
        {
            _income += 0.1;
            _allMoney += 0.9;
            var newTicket = new LotteryTicket();
            UpdateTicketsCount(newTicket);
            return newTicket;
        }

        private static void UpdateTicketsCount(LotteryTicket newTicket)
        {
            _soldTicketsCount++;
            if (newTicket.IsWinner(winnerNumbers)); _winnerTicketsCount++;
        }

        public static LotteryTicket SellPreDefinedTicket(Int32[] userNumbers)
        {
            _income += 0.2;
            _allMoney += 1.3;
            var newTicket = new LotteryTicket(userNumbers);
            UpdateTicketsCount(newTicket);
            return newTicket;
        }

        public static Double ShowIncome()
        {
            return _income;
        }

        public static Double ShowAllMoney()
        {
            return _allMoney;
        }

        public static Double GetSoldTicketsCount()
        {
            return _soldTicketsCount;
        }

        public static Double GetLuckyTicketsCount()
        {
            return _winnerTicketsCount;
        }

        public static string GetDailyReport()
        {
            return string.Format("Ticket seller sold today <B>{0,10}</B> tickets. " +
                                          "He collected <B>{1,10:C}</B>, his income for today is equal: <B>{2,10:C}</B>" +
                                          ". Lucky tickets count for today is: <B>{3,10}</B>", TicketSeller.GetSoldTicketsCount(), TicketSeller.ShowAllMoney(), TicketSeller.ShowIncome(), TicketSeller.GetLuckyTicketsCount());
        }
    }
}