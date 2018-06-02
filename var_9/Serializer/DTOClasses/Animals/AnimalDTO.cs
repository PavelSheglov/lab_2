using System;
using System.Xml.Serialization;
using var_9.Zoopark.Enums.Animals;

namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    [XmlInclude(typeof(AmphibianDTO))]
    [XmlInclude(typeof(BirdDTO))]
    [XmlInclude(typeof(FishDTO))]
    [XmlInclude(typeof(MammalDTO))]
    [XmlInclude(typeof(ReptileDTO))]
    public abstract class AnimalDTO
    {
        public string Family { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }

        public AnimalDTO() { }
    }
}
