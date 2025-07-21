using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCLass
{
   
        public class Flight
        {
            public string FlightNumber;
            public string Origin;
            public string Destination;
            public DateTime DepartureTime;
            public int TotalSeats;
            public decimal Price;

            public Flight(string flightNumber, string origin, string destination, DateTime departureTime, int totalSeats, decimal price)
            {
                FlightNumber = flightNumber;
                Origin = origin;
                Destination = destination;
                DepartureTime = departureTime;
                TotalSeats = totalSeats;
                Price = price;
            }

            public override string ToString()
            {
                return $"{FlightNumber} from {Origin} to {Destination} at {DepartureTime:dd.MM.yyyy HH:mm}, Seats: {TotalSeats}, Price: {Price}";
            }
        }
}

