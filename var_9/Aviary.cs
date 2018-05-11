using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public abstract class Aviary : IVerification
    {
        private string _number;
        private AviaryType _type;
        private AviaryStatus _status;
        private byte _capacity;//макс.количество особей
        private List<Animal> _inhabitants;

        public string Number => _number;
        public AviaryType Type => _type;
        public AviaryStatus Status => _status;
        public byte Capacity
        {
            get { return _capacity; }
            protected set { _capacity = value; }
        }
        public byte FreePlaces => (byte)(_capacity - _inhabitants.Count);

        protected Aviary() { }
        protected Aviary(AviaryType type)
        {
            _number = "";
            _type = type;
            _status = AviaryStatus.Opened;
            _inhabitants = new List<Animal>();
            _number = SetNumber();
        }

        private string SetNumber()
        {
            var temp = new StringBuilder(1000);
            temp.Append(Type.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString());
            temp.Append(DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
            temp.Append(DateTime.Now.Millisecond.ToString());
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
            if (_inhabitants.Count > 0)
            {
                if (_inhabitants.All(i => (i.Family == individual.Family && i.Genus == individual.Genus)))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        public bool SettleAnimal(Animal individual)
        {
            if (IsCorrectForSettlement(individual) && FreePlaces > 0 && Status == AviaryStatus.Opened)
            {
                individual.AviaryNumber = Number;
                _inhabitants.Add(individual);
                return true;
            }
            return false;
        }
        public Animal FindAnimalById(string id)
        {
            return _inhabitants.Find(f => f.Id == id);
        }
        public Animal EvictAnimal(string id)
        {
            var evi = FindAnimalById(id);
            if (evi != null)
            {
                _inhabitants.Remove(evi);
                evi.AviaryNumber = "";
            }
            return evi;
        }
        public string GetListOfInhabitants()
        {
            var str = new StringBuilder(1000);
            foreach (var i in _inhabitants)
            {
                str.Append(i.ToString() + "\n");
                str.Append(i.GetFullNotation() + "\n");
            }
            return str.ToString();
        }
        public override string ToString()
        {
            var str = new StringBuilder(1000);
            str.Append("Номер: " + Number + " Тип: " + Type.ToString() + " Статус: " + Status.ToString());
            str.Append(" Вместимость: " + Capacity.ToString() + " особей, свободно: " + FreePlaces.ToString() + " мест");
            return str.ToString();
        }
    }
}
