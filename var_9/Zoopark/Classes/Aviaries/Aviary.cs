using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    [Serializable]
    public abstract class Aviary : IVerification
    {
        private string _number;
        private AviaryStatus _status;
        private byte _capacity;
        private List<Animal> _inhabitants;

        public string Number => _number;
        public AviaryStatus Status => _status;
        public byte Capacity
        {
            get { return _capacity; }
            protected set { _capacity = value; }
        }
        public byte FreePlaces => (byte)(_capacity - _inhabitants.Count);
                                
        protected Aviary()
        {
            _status = AviaryStatus.Opened;
            _inhabitants = new List<Animal>();
            _number = SetNumber();
        }

        private string SetNumber()
        {
            System.Threading.Thread.Sleep(10);
            var temp = new StringBuilder(1000);
            var rnd = new Random();
            System.Threading.Thread.Sleep(10);
            temp.Append(this.GetType().Name.ToString() + String.Format("{0:0000}", rnd.Next(100, 2000)));
            temp.Append(String.Format("{0:00}", rnd.Next(0, 99)));
            return temp.ToString();
        }
        public bool Close()
        {
            if (_status == AviaryStatus.Opened && _inhabitants.Count == 0)
            {
                _status = AviaryStatus.Closed;
                return true;
            }
            return false;
        }
        public bool Open()
        {
            if (_status == AviaryStatus.Closed)
            {
                _status = AviaryStatus.Opened;
                return true;
            }
            return false;
        }
        public virtual bool IsCorrectForSettlement(Animal individual)
        {
            try
            {
                if (individual == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                if (_inhabitants.Count == 0 ||
                   (_inhabitants.All(inhabitant =>
                             (inhabitant.GetType().Name.ToString() == individual.GetType().Name.ToString() &&
                              inhabitant.DetachmentName == individual.DetachmentName &&
                              inhabitant.Family == individual.Family &&
                              inhabitant.Genus == individual.Genus))))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public bool SettleAnimal(Animal individual)
        {
            try
            {
                if (individual == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                if (IsCorrectForSettlement(individual) && FreePlaces > 0 && Status == AviaryStatus.Opened)
                {
                    _inhabitants.Add(individual);
                    return true;
                }
                return false;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public Animal FindAnimal(string id)
        {
            return _inhabitants.FirstOrDefault(animal => animal.Id == id);
        }
        public void EvictAnimal(Animal individual)
        {
            try
            {
                if (individual == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                if(FindAnimal(individual.Id)==null)
                    throw new ArgumentException("Животное отсутствует в вольере!!!");
                _inhabitants.Remove(individual);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public List<Animal> GetListOfInhabitants()
        {
            return _inhabitants;
        }
        public override string ToString()
        {
            var str = new StringBuilder(1000);
            str.Append("Номер:" + Number + " Тип:" + this.GetType().Name.ToString() + " Статус:" + Status.ToString());
            str.Append("\nВместимость:" + Capacity.ToString() + " особей, свободно:" + FreePlaces.ToString() + " мест");
            return str.ToString();
        }
    }
}
