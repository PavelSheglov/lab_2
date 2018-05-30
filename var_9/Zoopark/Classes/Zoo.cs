using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;

namespace var_9.Zoopark.Classes
{
    public sealed class Zoo
    {
        private List<Aviary> _aviaries;

        public string Name { get; set; }
        public string Address { get; set; }

        public Zoo():this("","") {}
        public Zoo(string name, string address)
        {
            Name = name;
            Address = address;
            _aviaries = new List<Aviary>();
        }

        public void AddAviary(Aviary aviary)
        {
            try
            {
                if (aviary == null)
                    throw new ArgumentException("Пустая ссылка на вольер!!!");
                _aviaries.Add(aviary);
            }
            catch(ArgumentException)
            {
                throw;
            }
        }
        public Aviary FindAviary(string number)
        {
            return _aviaries.FirstOrDefault(aviary => aviary.Number == number);
        }
        public bool CloseAviary(string number)
        {
            var aviary = FindAviary(number);
            return aviary != null && aviary.Close();
        }
        public bool OpenAviary(string number)
        {
            var aviary = FindAviary(number);
            return aviary != null && aviary.Open();
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
            try
            {
                if (animal == null || aviary == null)
                    throw new ArgumentException("Пустая ссылка на животное и/или вольер!!!");
                return FindAviary(aviary.Number) != null && aviary.SettleAnimal(animal);
            }
            catch(ArgumentException)
            {
                throw;
            }
        }
        public Animal FindAnimal(string id)
        {
            return _aviaries.Select(aviary => aviary.FindAnimal(id))
                            .FirstOrDefault(animal => animal != null);
        }
        public bool TransferAnimal(Animal animal, Aviary receiver)
        {
            try
            {
                if(animal == null || receiver == null)
                    throw new ArgumentException("Пустая ссылка на животное и/или вольер!!!");
                var sender = _aviaries.FirstOrDefault(aviary => aviary.GetListOfInhabitants().Contains(animal));
                if (sender != null &&
                    receiver.Status != AviaryStatus.Closed &&
                    receiver.FreePlaces > 0 &&
                    receiver.IsCorrectForSettlement(animal))
                {
                    sender.EvictAnimal(animal);
                    if (receiver.SettleAnimal(animal))
                    {
                        return true;
                    }
                    sender.SettleAnimal(animal);
                }
                return false;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }
        public bool EvictAnimal(Animal animal)
        {

            try
            {
                if (animal == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                var targetAviary = _aviaries.FirstOrDefault(aviary => aviary.GetListOfInhabitants().Contains(animal));
                if (targetAviary != null)
                {
                    targetAviary.EvictAnimal(animal);
                    return true;
                }
                return false;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public List<Aviary> GetListOfAviaries()
        {
            return _aviaries;
        }
        public List<Aviary> GetListOfAviaries(AviaryType type)
        {
            return _aviaries.FindAll(aviary=>aviary.GetType().Name.ToString()==type.ToString());
        }
        public List<Animal> GetListOfAnimals()
        {
            var animals=new List<Animal>();
            foreach (var aviary in _aviaries.FindAll(aviary => aviary.FreePlaces > 0))
                foreach (var animal in aviary.GetListOfInhabitants())
                    animals.Add(animal);
            return animals;
        }
        public List<Animal> GetListOfAnimals(AnimalClass animalClass)
        {
            var animals = new List<Animal>();
            foreach (var aviary in _aviaries.FindAll(aviary => aviary.FreePlaces > 0))
                foreach (var animal in aviary.GetListOfInhabitants()
                                             .FindAll(inhabitant=>inhabitant.GetType().Name.ToString()==animalClass.ToString()))
                    animals.Add(animal);
            return animals;
        }
        public override string ToString()
        {
            var count = 0;
            var str = new StringBuilder(1000);
            foreach (var aviary in _aviaries)
                count += (aviary.Capacity - aviary.FreePlaces);
            str.Append("Название: " + Name + "\nАдрес: " + Address);
            str.Append("\nКоличество вольеров: " + _aviaries.Count.ToString());
            str.Append(" Общая популяция: " + count.ToString());
            return str.ToString();
        }
    }
}
