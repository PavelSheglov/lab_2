using System;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    //[Serializable]
    public sealed class GlassAviary : Aviary, IVerification
    {
        private GlassAviaryType _glassAviaryType;
        private double _volume;//в метрах кубических

        public GlassAviaryType Kind => _glassAviaryType;
        public double Volume => _volume;

        private GlassAviary() : base() { }
        public GlassAviary(GlassAviaryType glassAviaryType) : base()
        {
            _glassAviaryType = glassAviaryType;
            switch (glassAviaryType)
            {
                case GlassAviaryType.WithWater:
                    _volume = 12.00;
                    this.Capacity = 5;
                    break;
                case GlassAviaryType.WithoutWater:
                    _volume = 12.00;
                    this.Capacity = 5;
                    break;
            }
        }
        public GlassAviary(GlassAviaryType glassAviaryType, double volume, byte capacity) : base()
        {
            try
            {
                if (volume <= 0 || capacity == 0)
                    throw new ArgumentException("Недопустимые значения объема и/или емкости!!!");
                _glassAviaryType = glassAviaryType;
                _volume = volume;
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
                      (((Mammal)individual).Detachment == MammalDetachment.Rodentia ||
                       ((Mammal)individual).Detachment == MammalDetachment.Chiroptera)) ||
                     (individual is Reptile) || (individual is Amphibian)) &&
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
            return base.ToString() + "\nОбъем:" + Volume + " куб.м." +
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
