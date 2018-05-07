using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_2
{
    class TestPersonProps
    {
        static void Main(string[] args)
        {
            Person pers1 = new Person();
            pers1.Fam = "Петров"; pers1.Age = 21; pers1.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            pers1.Fam = "Иванов"; pers1.Age++;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
        }
    }

    public class Person
    {
        string fam = "", status = "", health = "";
        int age = 0, salary = 0;

        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return fam; }
        }

        public string Status
        {
            get { return status; }
        }

        public int Age
        {
            set
            {
                age = value;
                if (age < 7) status = "ребенок";
                else if (age < 17) status = "школьник";
                else if (age < 22) status = "студент";
                else status = "служащий";
            }
            get { return age; }
        }

        public int Salary
        {
            set { salary = value; }
        }
    }
}
