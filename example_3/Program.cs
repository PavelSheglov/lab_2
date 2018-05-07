using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_3
{
    class TestPersonChildren
    {
        static void Main(string[] args)
        {
            Person pers1 = new Person(), pers2 = new Person(), pers3=new Person();
            pers1.Fam = "Петров"; pers1.Age = 42;
            pers1.Salary = 10000; pers1[pers1.Count_children] = pers2;
            pers2.Fam = "Петров"; pers2.Age = 21; pers2.Salary = 1000;
            pers3.Fam = "Петрова"; pers3.Age = 15; pers1[pers1.Count_children] = pers3;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            Console.WriteLine("Сын={0}, возраст={1}, статус={2}", pers1[0].Fam, pers1[0].Age, pers1[0].Status);
            Console.WriteLine("Дочь={0}, возраст={1}, статус={2}", pers1[1].Fam, pers1[1].Age, pers1[1].Status);
        }
    }

    public class Person
    {
        const int Child_Max = 10;

        string fam = "", status = "", health = "";
        int age = 0, salary = 0;
        Person[] children = new Person[Child_Max];
        int count_children = 0;

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

        public int Count_children
        {
            get { return count_children; }
        }

        public Person this[int i]
        {   
            get
            {
                if (i >= 0 && i < count_children)
                    return children[i];
                else
                    return children[0];
            }
            set
            {
                if (i == count_children && i < Child_Max)
                {
                    children[i] = value; count_children++;
                }
            }
        }

    }
}
