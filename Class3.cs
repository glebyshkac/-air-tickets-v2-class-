using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCLass
{
    public class TicketSystem
    {
        public List<Flight> Flights;
        public Dictionary<string, Ticket> Tickets;
        public Queue<string> PassengerQueue;
        public Stack<string> OperatorLog;
        public Random Random;

        public TicketSystem()
        {
            Flights = new List<Flight>
            {
                new Flight("PS001", "Kyiv", "Lviv", DateTime.Parse("27.05.2025 09:00"), 150, 1200.00m),
                new Flight("PS002", "Kyiv", "Odesa", DateTime.Parse("27.05.2025 12:00"), 200, 1500.00m),
                new Flight("PS003", "Lviv", "Kharkiv", DateTime.Parse("27.05.2025 15:00"), 180, 1300.00m),
                new Flight("PS004", "Odesa", "Kyiv", DateTime.Parse("27.05.2025 18:00"), 220, 1600.00m)
            };
            Tickets = new Dictionary<string, Ticket>();
            PassengerQueue = new Queue<string>();
            OperatorLog = new Stack<string>();
            Random = new Random();
        }

        public void ViewFlights()
        {
            Console.WriteLine("\nAvailable flights:");
            foreach (var flight in Flights)
            {
                Console.WriteLine(flight);
            }
        }

        public void BuyTicket(string flightNumber, string passengerName, string seatNumber)
        {
            var flight = Flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (flight.TotalSeats <= 0)
            {
                Console.WriteLine("No seats available for this flight.");
                return;
            }

            var ticketId = Guid.NewGuid().ToString();
            var ticket = new Ticket
            {
                TicketId = ticketId,
                FlightNumber = flightNumber,
                PassengerName = passengerName,
                SeatNumber = seatNumber,
                PurchaseDate = DateTime.Now
            };

            Tickets[ticketId] = ticket;
            flight.TotalSeats--;
            PassengerQueue.Enqueue(passengerName);
            OperatorLog.Push($"Ticket purchased: {ticket}");
            Console.WriteLine($"Ticket purchased successfully: {ticket}");
        }

        public void CancelTicket()
        {
            Console.Write("\nEnter the ticket ID to cancel: ");
            string id = Console.ReadLine();

            if (Tickets.TryGetValue(id, out var ticket))
            {
                var flight = Flights.FirstOrDefault(f => f.FlightNumber == ticket.FlightNumber);
                if (flight != null)
                {
                    flight.TotalSeats++;
                }

                Tickets.Remove(id);
                OperatorLog.Push($"Ticket {id} cancelled by {ticket.PassengerName}");
                Console.WriteLine($"Ticket {id} cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Ticket not found.");
            }
        }

        public void ViewSoldTickets()
        {
            Console.WriteLine("\nSold Tickets:");
            foreach (var ticket in Tickets.Values)
            {
                Console.WriteLine(ticket);
            }
        }

        public void ServePassenger()
        {
            if (PassengerQueue.Count > 0)
            {
                var next = PassengerQueue.Dequeue();
                Console.WriteLine($"Next passenger served: {next}");
                OperatorLog.Push($"Served next passenger: {next}");
            }
            else
            {
                Console.WriteLine("No passengers in line.");
            }
        }

        public void ViewOperatorLog()
        {
            Console.WriteLine("\nOperator Log:");
            foreach (var entry in OperatorLog)
            {
                Console.WriteLine(entry);
            }
        }
    }
}