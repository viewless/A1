using System;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Department { get; set; }
        public string ReasonForCreation { get; set; }
        public DateTime CompletionDate { get; set; }
        public string ReasonForClosing { get; set; }

       
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
