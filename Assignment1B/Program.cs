using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1B
{
    internal class Program
    {
        // Constants
        private const double HourlyRate = 1.5;
        private const double MaxCharge = 120.00;
        private const int DiscountHours = 7;
        private const double MembershipRate = 0.75;
        private const double DiscountedRate = 1.25;


        // Method to display welcome message
        static void Welcome()
        {

            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Welcome to the Car Parking Mall Calculator");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter the number of hours you have parked: ");

        }


        // Method to check if the user has a membership card
        static double GetRates(double hours, string answer)
        {
            double rate;
            if (answer.ToLower() == "y")
            {
                rate = MembershipRate;
            }
            else if (hours > DiscountHours)
            {
                rate = DiscountedRate;
            }
            else
            {
                rate = HourlyRate;
            }
            return rate;

        }


        // Method to check if the user input is valid
        static string CheckAnswer()
        {


            string answer;
            while (true)
            {
                answer = Console.ReadLine().ToLower();
                if (answer != "y" && answer != "n")
                {
                    Console.WriteLine("Invalid input. Please try again (y/n) ");
                }
                else
                {
                    return answer;
                }

            }

        }



        // Main method
        static void Main(string[] args)
        {

            // Loop to calculate parking charges
            while (true)
            {
                Welcome();

                double hours;
                bool success = double.TryParse(Console.ReadLine(), out hours);

                if (!success)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                Console.WriteLine("Do you have a membership card (y/n)? ");
                string answer = CheckAnswer();
                double rate = GetRates(hours, answer);


                double chargeableHours = Math.Ceiling(hours);
                double charges = rate * chargeableHours;

                // Check if the charges are more than the maximum charge
                if (charges > MaxCharge)
                {
                    charges = MaxCharge;
                }

                // Display the results
                Console.WriteLine("Membership Card: " + (answer == "y" ? "Yes" : "No"));
                Console.WriteLine("Hourly Rate: $" + rate);
                Console.WriteLine("Number of Hours Charged: " + chargeableHours);
                Console.WriteLine("Total Charge: $" + charges);
                Console.WriteLine("");


                Console.WriteLine("Do you want to calculate another parking charge (y/n)? ");
                if (CheckAnswer() != "y")
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("Thank you for using the Car Parking Mall Calculator!");


        }
    }
}
