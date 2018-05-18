using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public string Name { get; set; }
        public string Address { get; set; }

        private Zoo() {}
        public Zoo(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddAviary(Aviary aviary)
        {
            _aviaries.Add(aviary);
        }
        public Aviary FindAviary(string number)
        {
            return _aviaries.FirstOrDefault(aviary => aviary.Number == number);
        }
        public bool DeleteAviary(string number)
        {
            var aviary = FindAviary(number);
            if (aviary?.Status == AviaryStatus.Closed)
            {
                _aviaries.Remove(aviary);
                return true;
            }
            return false;
        }
        public bool SettleAnimal(Animal animal, Aviary aviary)
        {
            return  animal != null &&
                    aviary != null &&
                    aviary.SettleAnimal(animal);
        }
        public Animal FindAnimal(string id)
        {
            return _aviaries.Select(aviary => aviary.FindAnimal(id))
                            .FirstOrDefault(animal => animal != null);
        }
        public bool TransferAnimal(string animalId, Aviary sender, Aviary receiver)
        {
            if (sender.Status != AviaryStatus.Closed && 
                receiver.Status != AviaryStatus.Closed &&
                receiver.FreePlaces > 0)
            {
                var animal = sender.FindAnimal(animalId);
                if (animal != null && receiver.IsCorrectForSettlement(animal))
                {
                    sender.EvictAnimal(animal);
                    if(receiver.SettleAnimal(animal))
                    {
                        return true;
                    }
                    sender.SettleAnimal(animal);
                }
            }
            return false;
        }
        public void EvictAnimal(string id)
        {
            var targetAviary = _aviaries.FirstOrDefault(aviary => aviary.FindAnimal(id) != null);
            var animal = targetAviary?.FindAnimal(id);
            targetAviary?.EvictAnimal(animal);
        }
        public StringBuilder GetListOfAviaries()
        {
            var str = new StringBuilder(1000);
            foreach (var aviary in _aviaries)
                str.Append(aviary.ToString() + "\n");
            return str;
        }
        public StringBuilder GetDetailInformation()
        {
            var str = new StringBuilder(10000);
            str.Append("\n-----------ОБЩИЙ ОТЧЕТ ПО ЗООПАРКУ---------------\n");
            foreach (var aviary in _aviaries)
            {
                str.Append("\n------------------------------------------\n");
                str.Append(aviary.ToString());
                str.Append("\n------------------------------------------\n");
                str.Append(aviary.GetListOfInhabitants() + "\n");
            }
            return str;
        }
        public override string ToString()
        {
            var count = 0;
            var str = new StringBuilder(1000);
            foreach (var aviary in _aviaries)
                count += (aviary.Capacity - aviary.FreePlaces);
            str.Append("Название: " + Name + "\nАдрес: " + Address + "\nКоличество вольеров: " + _aviaries.Count.ToString());
            str.Append(" Общая популяция: " + count.ToString());
            return str.ToString();
        }
    }
}
