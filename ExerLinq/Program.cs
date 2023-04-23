using ExerLinq.Entities;
using System.Globalization;

namespace ExerLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double sl = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            var a = list.Where(p => p.Salary > sl).OrderBy(p => p.Email).Select(p => p.Email);
            foreach (string emp in a)
            {
                Console.WriteLine(emp);
            }

            var b = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + b.ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}