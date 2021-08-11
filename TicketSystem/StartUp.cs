using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSystem.Models;

namespace TicketSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new TicketsContext();


            TakeLastCreatedTicket(context);

            //Task2_2(context);

            LastTicket(context);

        }

        private static void LastTicket(TicketsContext context)
        {
            var lastTicket = context.Tickets.Select(ticket => ticket.TicketNumber).OrderByDescending(x => x).Take(1);

            StringBuilder sb = new StringBuilder();

            foreach (var ticket in lastTicket)
            {
                sb.Append(ticket);
            }

            Console.WriteLine(sb.ToString());
        }

        private static void Task2_2(TicketsContext context)
        {
            var query = context.Tickets
            .FromSqlRaw("SELECT " +
            "[TicketNumber]," +
            "[DateOfCreation]," +
            "[Department]," +
            "[ReasonForCreation]," +
            "[CompletionDate]," +
            "[ReasonForClosing]," +
            "[UserId]," +
            "u.[Name]," +
            "u.[Username]" +
            "FROM[TicketSystem].[dbo].[Tickets]" +
            "INNER JOIN Users u ON UserId = u.Id")
            .ToList();
        }

        private static void TakeLastCreatedTicket(TicketsContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitlePrice = context
                .Tickets
                .Where(x => x.TicketNumber > 40)
                .Select(x => new
                {
                    Number = x.TicketNumber
                }).ToList();

            foreach (var book in bookTitlePrice)
            {
                sb.AppendLine($"{book.Number}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
