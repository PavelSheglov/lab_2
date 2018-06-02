using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Serializer.DTOClasses.Animals;

namespace var_9.Serializer.DTOClasses.Aviaries
{
    [Serializable]
    [XmlInclude(typeof(AquariumDTO))]
    [XmlInclude(typeof(CageDTO))]
    [XmlInclude(typeof(GlassAviaryDTO))]
    [XmlInclude(typeof(PoolDTO))]
    [XmlInclude(typeof(YardDTO))]
    public abstract class AviaryDTO
    {
        public AviaryStatus Status { get; set; }
        public byte Capacity {get;set;}
        public List<AnimalDTO> Inhabitants;
        
        public AviaryDTO()
        {
            Inhabitants = new List<AnimalDTO>();
        }
    }
}
