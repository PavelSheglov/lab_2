using System;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    //[Serializable]
    public sealed class Amphibian : Animal
    {
        private AmphibianDetachment _detachment;

        public AmphibianDetachment Detachment => _detachment;

        private Amphibian() : base() { }
        public Amphibian(AmphibianDetachment detachment, string family, string genus, string species) : base(detachment.ToString(), family, genus, species)
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
