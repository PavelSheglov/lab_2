using System;
using var_9.Zoopark.Enums.Aviaries;


namespace var_9.Serializer.DTOClasses.Aviaries
{
    [Serializable]
    public class AquariumDTO :AviaryDTO
    {
        public AquariumType Kind { get; set; }
        public double Volume { get; set; }

        public AquariumDTO() : base() { }
    }
}
