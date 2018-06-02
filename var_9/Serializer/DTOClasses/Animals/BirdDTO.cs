using System;
using var_9.Zoopark.Enums.Animals;
namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    public class BirdDTO :AnimalDTO
    {
        public BirdDetachment Detachment { get; set; }

        public BirdDTO() : base() { }
    }
}
