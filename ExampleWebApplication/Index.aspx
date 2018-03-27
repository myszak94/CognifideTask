<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ExampleWebApplication.Index" %>

<%@ Import Namespace="ExampleWebApplication" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
            And the winner numbers are:
            <asp:Literal runat="server" ID="WinnerNumbersLiteral"></asp:Literal></h3>
        <table style="border-style: solid;">
            <tr id="head">
                <td>
                    Nr
                </td>
                <td>
                    Guid
                </td>
                <td>
                    Numbers
                </td>
                <td>
                    PrintDate
                </td>
                <td>
                    IsWinner
                </td>
            </tr>
            <asp:Repeater ID="Tickets" runat="server">
                <itemtemplate>
                    <tr>
                        <td>
                            <%#  Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%# ((LotteryTicket) Container.DataItem).UniqueId%>
                        </td>
                        <td>
                            <asp:Repeater ID="childRepeater" runat="server" DataSource="<%# ((LotteryTicket)Container.DataItem).Numbers %>">
                                <ItemTemplate>
                                    <%# ((int)Container.DataItem) %>,
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <%# ((LotteryTicket) Container.DataItem).PrintDateTime%>
                        </td>
                        <td>
                            <%# ((LotteryTicket) Container.DataItem).IsWinner(WinnerNumbers)%>
                        </td>
                    </tr>
                </itemtemplate>
            </asp:Repeater>
        </table>
        <h3>
            TicketSellerReport:</h3>
        <asp:Literal runat="server" ID="TicketSellerReport"></asp:Literal>
    </div>
    </form>
</body>
</html>
