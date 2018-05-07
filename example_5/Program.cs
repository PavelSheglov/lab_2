using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Derived("son", 50, 200);
            
            Console.WriteLine("-----метод родителя (использует переопределенный стандартный метод потомка)-----");
            d.NonVirtMethod();
            Console.WriteLine("-----метод родителя (использует переопределенный стандартный метод потомка)-----");
            d.Work();
            Console.WriteLine("-----------добавленный метод потомка--------");
            d.DerivedMethod();
            Console.WriteLine("-----------скрывающий метод потомка--------");
            d.Analysis();
            Console.WriteLine("-----------перегруженный метод потомка--------");
            d.Analysis(8);
            Console.WriteLine("-----------переопределенный стандартный метод потомка--------");
            Console.WriteLine(d.ToString());
            Console.WriteLine("-----------переопределенный родительский метод потомка--------");
            d.VirtMethod();
        }
    }

    public class Found
    {
        protected string name;
        protected int credit;

        public Found() { }

        public Found(string name, int sum)
        {
            this.name = name; credit = sum;
        }

        public virtual void VirtMethod()
        {
            Console.WriteLine("Отец: " + this.ToString());
        }

        public override string ToString()
        {
            return (String.Format("поля: name = {0}, credit = {1}", name, credit));
        }

        public void NonVirtMethod()
        {
            Console.WriteLine("Мать: " + this.ToString());
        }

        public void Analysis()
        {
            Console.WriteLine("Простой анализ");
        }

        public void Work()
        {
            VirtMethod();
            NonVirtMethod();
            Analysis();
        }
    }

    public class Derived : Found
    {
        protected int debet;

        public Derived() { }

        public Derived(string name, int cred, int deb) : base(name, cred)
        {
            debet = deb;
        }

        public void DerivedMethod()
        {	
            Console.WriteLine("Это метод класса Derived");
        }

        new public void Analysis()
        {   
            base.Analysis();
            Console.WriteLine("Сложный анализ");
        }

        public void Analysis(int level)
        {   
            base.Analysis();
            Console.WriteLine("Анализ глубины {0}", level);
        }

        public override String ToString()
        {   
            return String.Format("поля: name = {0}, credit = {1}, debet ={2}", name, credit, debet);
        }

        public override void VirtMethod()
        {
            Console.WriteLine("Сын: " + this.ToString());
        }
    }
}
