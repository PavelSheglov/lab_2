namespace var_9
{
    public sealed class GlassAviary : Aviary
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
            _glassAviaryType = glassAviaryType;
            _volume = volume;
            this.Capacity = capacity;
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
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
        public override string ToString()
        {
            return base.ToString() + "\nОбъем:" + Volume + "куб.м." +
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
