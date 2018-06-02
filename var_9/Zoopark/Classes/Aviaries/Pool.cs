using System;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    public sealed class Pool : Aviary, IVerification
    {
        private PoolType _poolType;
        private double _square; //квадратных метров

        public PoolType Kind => _poolType;
        public double Square => _square;

        private Pool() : base() { }
        public Pool(PoolType poolType) : base()
        {
            _poolType = poolType;
            switch (poolType)
            {
                case PoolType.OpenAirPool:
                    _square = 15.00;
                    this.Capacity = 10;
                    break;
                case PoolType.IndoorsPool:
                    _square = 15.00;
                    this.Capacity = 5;
                    break;
                case PoolType.Pond:
                    _square = 20.00;
                    this.Capacity = 10;
                    break;
            }
        }
        public Pool(PoolType poolType, double square, byte capacity) : base()
        {
            try
            {
                if (square <= 0 || capacity == 0)
                    throw new ArgumentException("Недопустимые значения площади и/или емкости!!!");
                _poolType = poolType;
                _square = square;
                this.Capacity = capacity;
            }
            catch (ArgumentException)
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
                if ((((individual is Mammal) &&
                       (((Mammal)individual).Detachment == MammalDetachment.Pinnipedia ||
                        ((Mammal)individual).Detachment == MammalDetachment.Carnivora ||
                        ((Mammal)individual).Detachment == MammalDetachment.Perissodactyla ||
                        ((Mammal)individual).Detachment == MammalDetachment.Cetacea ||
                        ((Mammal)individual).Detachment == MammalDetachment.Rodentia)) ||
                     ((individual is Bird) &&
                       (((Bird)individual).Detachment == BirdDetachment.Anseriformes ||
                        ((Bird)individual).Detachment == BirdDetachment.Sphenisciformes))) &&
                     base.IsCorrectForSettlement(individual))
                {
                    return true;
                }
                return false;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\nПлощадь:" + Square + " кв.м." +
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
