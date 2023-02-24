using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Num = 1, Name = "Bb", Summa = 100, City = "A" },
                new Employee() { Num = 2, Name = "Aa", Summa = 200, City = "B" },
                new Employee() { Num = 3, Name = "Ee", Summa = 60, City = "A" },
                new Employee() { Num = 4, Name = "Dd", Summa = 40, City = "B" }
            };

            Console.WriteLine("City");
            string city = Console.ReadLine();
            List<Employee> employees2 = employees.Where(x => x.City == city).ToList();
            Print(employees2);
            Console.ReadKey();

            Console.WriteLine("Summa");
            int summa = Convert.ToInt32(Console.ReadLine());
            List<Employee> employees3 = employees.Where(x => x.Summa >= summa).ToList();
            Print(employees3);
            Console.ReadKey();

            List<Employee> employees4 = employees.OrderBy(x => x.Name).ToList();
            Print(employees4);
            Console.ReadKey();


            IEnumerable<IGrouping<string, Employee>> employees5 = employees.GroupBy(x => x.City).ToList();
            foreach (IGrouping<string, Employee> gr in employees5)
            {
                Console.WriteLine(gr.Key);
                foreach (Employee e in gr)
                {
                    Console.WriteLine($"{e.Num} {e.Name} {e.Summa} {e.City}");
                }
            }

            Employee employee6 = employees.OrderByDescending(x => x.Summa).FirstOrDefault();
            Console.WriteLine($"{employee6.Num} {employee6.Name} {employee6.Summa} {employee6.City}");

            Employee employee7 = employees.OrderBy(x => x.Summa).FirstOrDefault();
            Console.WriteLine($"{employee7.Num} {employee7.Name} {employee7.Summa} {employee7.City}");

            Console.WriteLine(employees.Any(x => x.Summa > 200));
            Console.ReadKey();

        }
        static void Print(List<Employee> employees)
            {
                foreach(Employee e in employees)
                {
                    Console.WriteLine($"{e.Num} {e.Name} {e.Summa} {e.City}");
                }
                Console.WriteLine();
            }
    }
}
