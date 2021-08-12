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


           
            //Task2_2(context);

            TakeLastTicketCreated(context);

        }

        private static void TakeLastTicketCreated(TicketsContext context)
        {
            var lastTicket = context.Tickets
                .OrderByDescending(x => x.DateOfCreation)
                .Select(ticket => ticket.TicketNumber)
                .Take(1);

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

       
    }
}
