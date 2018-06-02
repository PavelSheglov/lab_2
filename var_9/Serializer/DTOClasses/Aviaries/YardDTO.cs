using System;
using var_9.Zoopark.Enums.Aviaries;


namespace var_9.Serializer.DTOClasses.Aviaries
{
    [Serializable]
    public class YardDTO : AviaryDTO
    {
        public YardType Kind { get; set; }
        public double Square { get; set; }

        public YardDTO() : base() { }
    }
}
