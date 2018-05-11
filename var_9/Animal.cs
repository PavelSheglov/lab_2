using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public abstract class Animal
    {
        private AnimalClass _class;
        private string _family;
        private string _genus;
        private string _species;
        private string _aviaryNumber;
        private string _id;

        public AnimalClass Class => _class;
        public string AviaryNumber
        {
            get { return _aviaryNumber; }
            set { _aviaryNumber = value; }
        }
        public string Id => _id;
        public string Family => _family;
        public string Genus => _genus;
        public string Name => _species;

        protected Animal() { }
        protected Animal(AnimalClass animalClass, string family, string genus, string species)
        {
            _class = animalClass;
            _aviaryNumber = "";
            _family = family;
            _genus = genus;
            _species = species;
            _id = GenerateId();
        }

        private string GenerateId()
        {
            var temp = new StringBuilder(1000);
            temp.Append(Class.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString());
            temp.Append(DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
            temp.Append(DateTime.Now.Millisecond.ToString());
            return temp.ToString();
        }

        public virtual string GetFullNotation()
        {
            return Class.ToString();
        }

        public override string ToString()
        {
            return "Id: " + Id + " Вольер: " + AviaryNumber + " Класс: " + Class.ToString();
        }
    }
}
