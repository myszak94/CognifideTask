using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleWebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        public Int32[] WinnerNumbers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateWinnerNumbers();
            TicketSeller.GoToWork(WinnerNumbers);

            List<LotteryTicket> tickets = new List<LotteryTicket>();

            //Predefined Numbers
            tickets.Add(TicketSeller.SellPreDefinedTicket(new Int32[] { 1, 2, 3, 4, 5, 6 }));
            tickets.Add(TicketSeller.SellPreDefinedTicket(new Int32[] { 6, 2, 3, 6, 2, 6 }));
            tickets.Add(TicketSeller.SellPreDefinedTicket(new Int32[] { 5, 2, 3, 6, 2, 1 }));

            //Random Tickets
            for (Int32 i = 0; i < 10; i++)
            {
                tickets.Add(TicketSeller.SellRandomTicket());
            }
            Tickets.DataSource = tickets;
            Tickets.DataBind();

            TicketSellerReport.Text = TicketSeller.GetDailyReport();
        }

        private void GenerateWinnerNumbers()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            WinnerNumbers = new int[6];
            for (Int16 i = 0; i < 6; i++)
            {
                WinnerNumbers[i] = r.Next(10);
            }
            foreach (Int16 winner in WinnerNumbers)
            {
                WinnerNumbersLiteral.Text += winner.ToString() + ", ";
            }
        }
    }
}