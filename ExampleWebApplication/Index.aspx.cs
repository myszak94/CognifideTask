using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace ExampleWebApplication
{
    public partial class Index : Page
    {
        public int[] WinnerNumbers { get; set; }
        private Random Random { get; } = new Random((int)DateTime.Now.Ticks);

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateWinnerNumbers();
            TicketSeller.Instance.GoToWork(WinnerNumbers);
            
            //Predefined Numbers
            var tickets = new List<LotteryTicket>
            {
                TicketSeller.Instance.SellPreDefinedTicket(new[] {1, 2, 3, 4, 5, 6}),
                TicketSeller.Instance.SellPreDefinedTicket(new[] {7, 2, 3, 12, 22, 6}),
                TicketSeller.Instance.SellPreDefinedTicket(new[] {5, 2, 3, 6, 22, 1})
            };

            //Random Tickets
            for (var i = 0; i < 10; i++)
            {
                tickets.Add(TicketSeller.Instance.SellRandomTicket(GetRandomNumbers()));
            }
            Tickets.DataSource = tickets;
            Tickets.DataBind();

            TicketSellerReport.Text = TicketSeller.Instance.GetDailyReport();
        }

        private void GenerateWinnerNumbers()
        {
            var r = new Random((int)DateTime.Now.Ticks);
            WinnerNumbers = GetRandomNumbers();

            var numbersLiteralText = string.Empty;

            foreach (var i in WinnerNumbers)
            {
                numbersLiteralText += $"{i}, ";
            }

            WinnerNumbersLiteral.Text = numbersLiteralText;
            //Ze względu na to, że Winner Numbers zawsze będzie składało się z 6 liczb zostawiamy konkatenacje
            //Dla większej ilości łączonych stringów użylibyśmy klasy StringBuilder
        }

        private int[] GetRandomNumbers()
        {
            var randomNumbers = new int[6];
            var j = 0;

            while (j < 6)
            {
                var num = Random.Next(1, 31);

                if (!randomNumbers.Contains(num))
                {
                    randomNumbers[j] = num;
                    j++;
                }
            }

            return randomNumbers;
        }
    }
}