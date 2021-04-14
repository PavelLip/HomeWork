using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }

        public Employee()
        {

        }
        public Employee(string fullName, string position, string email, string telephone, int salary, int age)
        {
            FullName = fullName;
            Position = position;
            Email = email;
            Telephone = telephone;
            Salary = salary;
            Age = age;
        }

        public static void WriteConsole(Employee[] persArray, int PersoneAge)
        {
            foreach (var Person in persArray)
            {
                if (Person.Age > PersoneAge)
                    Console.WriteLine(Person.FullName + " "+ Person.Position + " " + Person.Email + " " + Person.Telephone + " " + Person.Salary + " " + Person.Age);
            }
        }
    }
}
