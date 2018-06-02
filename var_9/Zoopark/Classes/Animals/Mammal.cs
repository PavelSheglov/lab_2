using System;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    public sealed class Mammal : Animal
    {
        private MammalDetachment _detachment;

        public MammalDetachment Detachment => _detachment;

        private Mammal() : base() { }
        public Mammal(MammalDetachment detachment, string family, string genus, string species) : base(detachment.ToString(), family, genus, species)
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
