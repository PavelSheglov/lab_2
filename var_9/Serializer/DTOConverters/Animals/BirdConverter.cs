using System;
using var_9.Serializer.DTOClasses.Animals;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOConverters.Animals
{
    public class BirdConverter : IAnimalConverter
    {
        public Animal ToAnimal(AnimalDTO animalDTO)
        {
            try
            {
                if (animalDTO == null || !(animalDTO is BirdDTO))
                    throw new ArgumentException("Пустой DTO объект или не подходящего типа!!!");
                var animal = new Bird((animalDTO as BirdDTO).Detachment,
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
                if (animal == null || !(animal is Bird))
                    throw new ArgumentException("Пустой объект или не подходящего типа!!!");
                var animalDTO = new BirdDTO();
                animalDTO.Detachment = (animal as Bird).Detachment;
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

