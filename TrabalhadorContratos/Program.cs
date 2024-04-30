using System;
using System.Security.Cryptography.X509Certificates;
using TrabalhadorContratos.Entities;
using TrabalhadorContratos.Entities.Enums;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string dept = Console.ReadLine();

         
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine());

            Department depart = new Department(dept);
            Worker worker = new Worker(name, salary, depart, level);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hour = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, value, hour);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));


            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine(worker);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month));



        }

       
    }

    
}
