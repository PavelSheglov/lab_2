using System;
using var_9.Zoopark.Enums.Animals;

namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    public class MammalDTO : AnimalDTO
    {
        public MammalDetachment Detachment { get; set; }

        public MammalDTO() : base() { }
    }
}
