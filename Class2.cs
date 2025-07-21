using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCLass
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
        public DateTime PurchaseDate { get; set; }

        public override string ToString()
        {
            return $"Ticket ID: {TicketId} | Flight: {FlightNumber} | Passenger: {PassengerName} | Seat: {SeatNumber} | Purchased: {PurchaseDate:dd.MM.yyyy HH:mm}";
        }
    }
}
