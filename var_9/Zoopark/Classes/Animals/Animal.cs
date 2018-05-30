using System;
using System.Text;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Animals
{
    public abstract class Animal:INotation
    {
        private string _family;
        private string _genus;
        private string _species;
        private string _id;
        private string _detachment;
                        
        public string Id => _id;
        public string DetachmentName => _detachment;
        public string Family => _family;
        public string Genus => _genus;
        public string Species => _species;

        protected Animal() { }
        protected Animal(string detachment, string family, string genus, string species)
        {
            if (string.IsNullOrEmpty(detachment) || string.IsNullOrWhiteSpace(detachment) ||
                string.IsNullOrEmpty(family) || string.IsNullOrWhiteSpace(family) ||
                string.IsNullOrEmpty(genus) || string.IsNullOrWhiteSpace(genus) ||
                string.IsNullOrEmpty(species) || string.IsNullOrWhiteSpace(species))
                            throw new ArgumentException("Пустые параметры животного!!!");
            _detachment = detachment;
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

        public string GetFullNotation()
        {
            var str = new StringBuilder(500);
            str.Append(this.GetType().Name.ToString());
            str.Append("*" + DetachmentName);
            str.Append("*" + this.Family.ToString());
            str.Append("*" + this.Genus.ToString());
            str.Append("*" + this.Species);
            return str.ToString();
        }

        public override string ToString()
        {
            return "Id:" + Id + "\n" +
                   "Класс:" + this.GetType().Name.ToString() + "\n"+
                   "Отряд:" + DetachmentName + "\n" +
                   "Семейство:" + Family + "\n" +
                   "Род:" + Genus +
                   ", Вид:" + Species;
        }
    }
}
