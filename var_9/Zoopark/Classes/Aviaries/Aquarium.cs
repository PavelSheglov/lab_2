using System;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    //[Serializable]
    public sealed class Aquarium : Aviary, IVerification
    {
        private AquariumType _aquariumType;
        private double _volume;//в метрах кубических

        public AquariumType Kind => _aquariumType;
        public double Volume => _volume;

        private Aquarium() : base() { }
        public Aquarium(AquariumType aquariumType) : base()
        {
            _aquariumType = aquariumType;
            switch (aquariumType)
            {
                case AquariumType.Freshwater:
                    _volume = 2.00;
                    this.Capacity = 5;
                    break;
                case AquariumType.SeaWater:
                    _volume = 2.00;
                    this.Capacity = 5;
                    break;
            }
        }
        public Aquarium(AquariumType aquariumType, double volume, byte capacity) : base()
        {
            try
            {
                if (volume <= 0 || capacity == 0)
                    throw new ArgumentException("Недопустимые значения объема и/или емкости!!!");
                _aquariumType = aquariumType;
                _volume = volume;
                this.Capacity = capacity;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            try
            {
                if (individual == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                if (individual is Fish && base.IsCorrectForSettlement(individual))
                {
                    return true;
                }
                return false;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\nОбъем:" + Volume + " куб.м." + 
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
