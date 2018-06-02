using System;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    public sealed class Bird : Animal
    {
        private BirdDetachment _detachment;

        public BirdDetachment Detachment => _detachment;

        private Bird() : base() { }
        public Bird(BirdDetachment detachment, string family, string genus, string species) : base(detachment.ToString(), family, genus, species)
        {
            try
            {
                _detachment = detachment;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }
    }
}
