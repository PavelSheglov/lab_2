using System;
using var_9.Zoopark.Enums.Animals;

namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    public class ReptileDTO : AnimalDTO
    {
        public ReptileDetachment Detachment { get; set; }

        public ReptileDTO() : base() { }
    }
}