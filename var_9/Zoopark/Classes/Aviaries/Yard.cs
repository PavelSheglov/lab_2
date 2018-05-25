using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    public sealed class Yard : Aviary, IVerification
    {
        private YardType _yardType;
        private double _square; //квадратных метров

        public YardType Kind => _yardType;
        public double Square => _square;
        
        private Yard() : base() { }
        public Yard(YardType yardType) : base()
        {
            _yardType = yardType;
            switch (yardType)
            {
                case YardType.Plain:
                    _square = 2000.00;
                    this.Capacity = 10;
                    break;
                case YardType.Rock:
                    _square = 800.00;
                    this.Capacity = 5;
                    break;
                case YardType.Forest:
                    _square = 1000.00;
                    this.Capacity = 10;
                    break;
            }
        }
        public Yard(YardType yardType, double square, byte capacity) : base()
        {
            _yardType = yardType;
            _square = square;
            this.Capacity = capacity;
        }
                
        public override bool IsCorrectForSettlement(Animal individual)
        {
            if ((((individual is Mammal) &&
                 (((Mammal)individual).Detachment == MammalDetachment.Artiodactyla ||
                  ((Mammal)individual).Detachment == MammalDetachment.Perissodactyla ||
                  ((Mammal)individual).Detachment == MammalDetachment.Proboscidea ||
                  ((Mammal)individual).Detachment == MammalDetachment.Carnivora)) ||
                ((individual is Bird) &&
                  (((Bird)individual).Detachment == BirdDetachment.Struthioniformes))) && 
                base.IsCorrectForSettlement(individual))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + "\nПлощадь:" + Square + "кв.м." +
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
