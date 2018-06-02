using var_9.Serializer.DTOClasses.Animals;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOInterfaces
{
    public interface IAnimalConverter
    {
        Animal ToAnimal(AnimalDTO animalDTO);
        AnimalDTO ToAnimalDTO(Animal animal);
    }
}
