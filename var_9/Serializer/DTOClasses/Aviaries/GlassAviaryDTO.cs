using System;
using var_9.Zoopark.Enums.Aviaries;


namespace var_9.Serializer.DTOClasses.Aviaries
{
    [Serializable]
    public class GlassAviaryDTO : AviaryDTO
    {
        public GlassAviaryType Kind { get; set; }
        public double Volume { get; set; }

        public GlassAviaryDTO() : base() { }
    }
}