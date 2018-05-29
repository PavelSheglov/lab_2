using System;
using System.Text;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Animals
{
    public abstract class Animal:INotation // интерфейс оставить только для базового класса
    {
        private string _family;
        private string _genus;
        private string _species;
        private string _id;
                
        public string Id => _id;
        public string Family => _family;
        public string Genus => _genus;
        public string Species => _species;

        protected Animal() { }
        protected Animal(string family, string genus, string species)
        {
            _family = family;
            _genus = genus;
            _species = species;
            _id = GenerateId();
        }

        private string GenerateId()
        {
            System.Threading.Thread.Sleep(10);
            var temp = new StringBuilder(1000);
            var rnd = new Random();

            temp.Append(this.GetType().Name.ToString() + String.Format("{0:00000}", rnd.Next(100, 20000)));
            temp.Append(String.Format("{0:000}", rnd.Next(0, 999)));
            return temp.ToString();
        }

        public virtual string GetFullNotation()//добавить строковое представление отряда или генерик, а из каждого отряда этот метод удалить
        {
            return this.GetType().Name.ToString();
        }

        public override string ToString() //здесь сделать полную информацию, а из классов отрядов удалить этот метод
        {
            return "Id:" + Id + "\n" +
                   "Класс:" + this.GetType().Name.ToString() + "\n";
        }
    }
}
