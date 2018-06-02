using System;
using var_9.Zoopark.Enums.Animals;

namespace var_9.Serializer.DTOClasses.Animals
{
    [Serializable]
    public class AmphibianDTO :AnimalDTO
    {
        public AmphibianDetachment Detachment { get; set; }

        public AmphibianDTO() : base() { } 
    }
}
