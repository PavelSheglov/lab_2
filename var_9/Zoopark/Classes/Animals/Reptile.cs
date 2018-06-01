using System;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    [Serializable]
    public sealed class Reptile : Animal
    {
        private ReptileDetachment _detachment;

        public ReptileDetachment Detachment => _detachment;

        private Reptile() : base() { }
        public Reptile(ReptileDetachment detachment, string family, string genus, string species) : base(detachment.ToString(), family, genus, species)
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
