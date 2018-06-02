using System;
using var_9.Zoopark.Enums.Animals;

namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    public class FishDTO : AnimalDTO
    {
        public FishDetachment Detachment { get; set; }

        public FishDTO() : base() { }
    }
}
