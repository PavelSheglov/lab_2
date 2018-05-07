using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_1
{
    class StructTester
    {
        static void Main(string[] args)
        {
            Employee fred;           
            fred.deptID = 40;
            fred.name = "Fred";
            fred.title = EmpType.Grunt;
            var mary = new Employee(EmpType.VP, "Mary", 10);
            Console.WriteLine("Сотрудники, созданные с помощью структуры");
            Console.WriteLine();
            Console.WriteLine("Первый сотрудник (через структурную переменную):\nИмя - {0}, номер подразделения - {1}, должность - {2}", fred.name, fred.deptID, fred.title.ToString());
            Console.WriteLine();
            Console.WriteLine("Второй сотрудник (через конструктор структурной переменной):\nИмя - {0}, номер подразделения - {1}, должность - {2}", mary.name, mary.deptID, mary.title.ToString());
            Console.WriteLine();
            Console.WriteLine("Сотрудники, созданные с помощью конструктора класса");
            Console.WriteLine();
            var e1 = new EmployeeClass("Joe", 80, 30000);
            Console.WriteLine("Первый сотрудник до увеличения зарплаты:");
            e1.DisplayStats();
            e1.GiveBonus(200);
            Console.WriteLine("Первый сотрудник после увеличения зарплаты:");
            e1.DisplayStats();
            EmployeeClass e2;
            e2 = new EmployeeClass("Beth", 81, 50000);
            Console.WriteLine();
            Console.WriteLine("Второй сотрудник до увеличения зарплаты:");
            e2.DisplayStats();
            e2.GiveBonus(1000);
            Console.WriteLine("Второй сотрудник после увеличения зарплаты:");
            e2.DisplayStats();
        }
    }

    enum EmpType : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VP = 9
    }

    struct Employee
    {
        public EmpType title;
        public string name;
        public short deptID;

        public Employee(EmpType et, string n, short d)
        {
            title = et; name = n; deptID = d;
        }
    }

    class EmployeeClass
    {
        private string fullName;
        private int empID;
        private float currPay;

        public EmployeeClass() { }

        public EmployeeClass(string fullName, int empID, float currPay)
        {
            this.fullName = fullName; this.empID = empID;
            this.currPay = currPay;
        }

        public void GiveBonus(float amount)
        { currPay += amount; }
        
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", fullName);
            Console.WriteLine("Pay: {0}", currPay);
            Console.WriteLine("ID: {0}", empID);
        }
    }
}
