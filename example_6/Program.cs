using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_6
{
    class TestTwoInterfaces
    {
        static void Main(string[] args)
        {
            var clain = new Clain();

            Console.WriteLine("-----------------Склейка свойства №1 двух интерфейсов-------------");
            clain.Prop1("Это отработало склеенное свойство №1");

            Console.WriteLine("-------------Перегрузка свойства №2 двух интерфейсов--------------");
            Console.WriteLine("---Вариант для интерфейса №1---");
            clain.Prop2("перегрузка: ", 99);
            Console.WriteLine("---Вариант для интерфейса №2---");
            clain.Prop2(9999);

            Console.WriteLine("-----------Переименование свойства №3 двух интерфейсов------------");
            Console.WriteLine("---Вариант для интерфейса №1---");
            clain.Prop3FromInterface1();
            Console.WriteLine("---Вариант для интерфейса №2---");
            clain.Prop3FromInterface2();

            Console.WriteLine("--Работа со свойствами двух интерфейсов через интерфейсные объекты--");

            var ip1 = (IPropsVer1)clain;
            Console.WriteLine("Интерфейсный объект вызывает методы 1-го  интерфейса!");
            ip1.Prop1("интерфейс #1: свойство #1");
            ip1.Prop2("интерфейс #1: свойство #2, вариант ", 1);
            ip1.Prop3();

            var ip2 = (IPropsVer2)clain;
            Console.WriteLine("Интерфейсный объект вызывает методы 2-го интерфейса!");
            ip2.Prop1("интерфейс #2: свойство #1");
            Console.WriteLine("Интерфейс №2, свойство №2, вариант");
            ip2.Prop2(2);
            ip2.Prop3();
        }
    }
    
    public interface IPropsVer1
    {
        void Prop1(string s);
        void Prop2(string name, int val);
        void Prop3();
    }

    public interface IPropsVer2
    {
        void Prop1(string s);
        void Prop2(int val);
        void Prop3();
    }

    public class Clain : IPropsVer1, IPropsVer2
    {
        public void Prop1(string s) { Console.WriteLine(s); }
        
        public void Prop2(string s, int x) { Console.WriteLine(s + x); }
        public void Prop2(int x) { Console.WriteLine(x); }
        
        void IPropsVer1.Prop3()  { Console.WriteLine("Метод 3 интерфейса 1"); }
        void IPropsVer2.Prop3()  { Console.WriteLine("Метод 3 интерфейса 2"); }
        public void Prop3FromInterface1() { ((IPropsVer1)this).Prop3(); }
        public void Prop3FromInterface2() { ((IPropsVer2)this).Prop3(); }
    }
}
