using System;
using var_9.Serializer.DTOClasses.Animals;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOConverters.Animals
{
    public class FishConverter : IAnimalConverter
    {
        public Animal ToAnimal(AnimalDTO animalDTO)
        {
            try
            {
                if (animalDTO == null || !(animalDTO is FishDTO))
                    throw new ArgumentException("Пустой DTO объект или не подходящего типа!!!");
                var animal = new Fish((animalDTO as FishDTO).Detachment,
                                                  animalDTO.Family, animalDTO.Genus,
                                                  animalDTO.Species);
                return animal;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public AnimalDTO ToAnimalDTO(Animal animal)
        {
            try
            {
                if (animal == null || !(animal is Fish))
                    throw new ArgumentException("Пустой объект или не подходящего типа!!!");
                var animalDTO = new FishDTO();
                animalDTO.Detachment = (animal as Fish).Detachment;
                animalDTO.Family = animal.Family;
                animalDTO.Genus = animal.Genus;
                animalDTO.Species = animal.Species;
                return animalDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}

