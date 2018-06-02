using System;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    //[Serializable]
    public sealed class Fish : Animal
    {
        private FishDetachment _detachment;

        public FishDetachment Detachment => _detachment;

        private Fish() : base() { }
        public Fish(FishDetachment detachment, string family, string genus, string species) : base(detachment.ToString(), family, genus, species)
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


