using System;
using var_9.Serializer.DTOClasses.Animals;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOConverters.Animals
{
    public class ReptileConverter : IAnimalConverter
    {
        public Animal ToAnimal(AnimalDTO animalDTO)
        {
            try
            {
                if (animalDTO == null || !(animalDTO is ReptileDTO))
                    throw new ArgumentException("Пустой DTO объект или не подходящего типа!!!");
                var animal = new Reptile((animalDTO as ReptileDTO).Detachment,
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
                if (animal == null || !(animal is Reptile))
                    throw new ArgumentException("Пустой объект или не подходящего типа!!!");
                var animalDTO = new ReptileDTO();
                animalDTO.Detachment = (animal as Reptile).Detachment;
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