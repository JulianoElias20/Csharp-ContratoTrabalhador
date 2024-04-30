using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhadorContratos.Entities.Enums;

namespace TrabalhadorContratos.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public Department Dept { get; set; }
        public WorkerLevel Level { get; set; }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker() { }

        public Worker(string name, double salary, Department dept, WorkerLevel level)
        {
            Name = name;
            Salary = salary;
            Dept = dept;
            Level = level;
        }



        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = 0;
            foreach (HourContract contract in Contracts)
            {

                
                

                if (year == contract.Date.Year && contract.Date.Month == month)
                {
                    sum= sum+(contract.TotalValue());
                }
            }
            return Salary+sum;
        }
        public override string ToString()
        {
            

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Name: " + Name);
            sb.Append("Departament: " +Dept.Name);

            return sb.ToString();
            
        }


    }
}
