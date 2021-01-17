using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalStandartTicket = 0;
            int totalKidTicket = 0;
            int totalStudentTicket = 0;

            while (true)
            {
                string movie = Console.ReadLine();
                if(movie == "Finish")
                {
                    break;
                }
                int seats = int.Parse(Console.ReadLine());
                int totalSeats = seats;
                int ticketsForMovie = 0;
                while (seats > 0)
                {
                    string curentTicket = Console.ReadLine();
                    if(curentTicket == "End")
                    {
                        break;
                    }

                    switch (curentTicket)
                    {
                        case "standard":
                            totalStandartTicket++;
                            break;
                        case "kid":
                            totalKidTicket++;
                            break;
                        case "student":
                            totalStudentTicket++;
                            break;

                    }
                    ticketsForMovie++;
                    seats--;

                }
                double capacity = ticketsForMovie * 1.0 / totalSeats * 100;

                Console.WriteLine($"{movie} - {capacity:f2}% full.");
            }
            int totalTickets = totalStandartTicket + totalKidTicket + totalStudentTicket;

            double averegStandartTicket = totalStandartTicket * 1.0 / totalTickets * 100;
            double averegKidsTicket = totalKidTicket * 1.0 / totalTickets * 100;
            double averegStudentsTicket = totalStudentTicket * 1.0 / totalTickets * 100;


            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{averegStudentsTicket:f2}% student tickets.");
            Console.WriteLine($"{averegStandartTicket:f2}% standard tickets.");
            Console.WriteLine($"{averegKidsTicket:f2}% kids tickets.");

        }
    }
}
