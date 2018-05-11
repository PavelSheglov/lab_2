using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Zoo
    {
        private string _name;
        private string _address;
        private List<Aviary> _aviaries = new List<Aviary>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Zoo()
        {
            _name = "Новый Зоопарк";
            _address = "Индекс, Страна, Город, Улица, Номер";
        }
        public Zoo(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public void AddAviary(Aviary aviary)
        {
            if (aviary != null)
                _aviaries.Add(aviary);

        }
        public Aviary FindAviaryByNumber(string number)
        {
            return _aviaries.Find(f => f.Number == number);
        }
        public bool DeleteAviary(string number)
        {
            var del = FindAviaryByNumber(number);
            if (del != null && del.Status == AviaryStatus.Closed)
            {
                _aviaries.Remove(del);
                return true;
            }
            return false;
        }
        public bool SettleAnimal(Animal animal, Aviary aviary)
        {
            if (animal != null && aviary != null && aviary.SettleAnimal(animal))
                return true;
            return false;
        }
        public Animal FindAnimalbyId(string id)
        {
            Animal res = null;
            foreach (var i in _aviaries)
            {
                var temp = i.FindAnimalById(id);
                if (temp != null)
                {
                    res = temp;
                    break;
                }
            }
            return res;
        }
        public bool TransferAnimal(Animal animal, Aviary sender, Aviary receiver)
        {
            if (animal != null && sender != null && receiver != null &&
               sender.Status != AviaryStatus.Closed && receiver.Status != AviaryStatus.Closed)
            {
                if (sender.FindAnimalById(animal.Id) != null && receiver.IsCorrectForSettlement(animal) && receiver.FreePlaces > 0)
                {
                    receiver.SettleAnimal(sender.EvictAnimal(animal.Id));
                    return true;
                }
            }
            return false;
        }
        public Animal EvictAnimal(string id)
        {
            var temp = FindAnimalbyId(id);
            Animal res = null;
            Aviary aviary = null;
            if (temp != null)
                aviary = FindAviaryByNumber(temp.AviaryNumber);
            if (aviary != null)
                res = aviary.EvictAnimal(id);
            return res;
        }
        public string GetListOfAviaries()
        {
            var str = new StringBuilder(1000);
            foreach (var i in _aviaries)
                str.Append(i.ToString() + "\n");
            return str.ToString();
        }
        public string GetDetailInformation()
        {
            var str = new StringBuilder(10000);
            str.Append("\n-----------ОБЩИЙ ОТЧЕТ ПО ЗООПАРКУ---------------\n");
            foreach (var i in _aviaries)
            {
                str.Append("\n------------------------------------------\n");
                str.Append(i.ToString());
                str.Append("\n------------------------------------------\n");
                str.Append(i.GetListOfInhabitants() + "\n");
            }
            return str.ToString();
        }
        public override string ToString()
        {
            var count = 0;
            var str = new StringBuilder(1000);
            foreach (var i in _aviaries)
                count += (i.Capacity - i.FreePlaces);
            str.Append("Название: " + Name + "\nАдрес: " + Address + "\nКоличество вольеров: " + _aviaries.Count.ToString());
            str.Append(" Общая популяция: " + count.ToString());
            return str.ToString();
        }
    }
}
