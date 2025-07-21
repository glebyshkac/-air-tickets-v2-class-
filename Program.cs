using AviaCLass;

class Program
{
    static void Main()
    {
        var system = new TicketSystem();

        while (true)
        {
            Console.WriteLine("\nMenu:\n1 - View flights\n2 - Buy ticket\n3 - Cancel ticket\n4 - View sold tickets\n5 - Serve next passenger\n6 - View operator log\n7 - Exit");
            Console.Write("Choose option: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) continue;
            if (choice == 7) break;

            switch (choice)
            {
                case 1:
                    system.ViewFlights();
                    break;
                case 2:
                    Console.Write("Enter flight number: ");
                    var flightNum = Console.ReadLine();
                    Console.Write("Enter your name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter seat number: ");
                    var seat = Console.ReadLine();
                    system.BuyTicket(flightNum, name, seat);
                    break;
                case 3:
                    system.CancelTicket();
                    break;
                case 4:
                    system.ViewSoldTickets();
                    break;
                case 5:
                    system.ServePassenger();
                    break;
                case 6:
                    system.ViewOperatorLog();
                    break;
            }
        }
    }
}
