using System;
using var_9.Serializer.DTOClasses.Animals;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOConverters.Animals
{
    public class AmphibianConverter:IAnimalConverter
    {
        public Animal ToAnimal(AnimalDTO animalDTO)
        {
            try
            {
                if (animalDTO == null || !(animalDTO is AmphibianDTO))
                    throw new ArgumentException("Пустой DTO объект (животное) или не подходящего типа!!!");
                var animal = new Amphibian((animalDTO as AmphibianDTO).Detachment, 
                                                  animalDTO.Family, animalDTO.Genus, 
                                                  animalDTO.Species);
                return animal;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }

        public AnimalDTO ToAnimalDTO(Animal animal)
        {
            try
            {
                if (animal == null || !(animal is Amphibian))
                    throw new ArgumentException("Пустой объект (животное) или не подходящего типа!!!");
                var animalDTO = new AmphibianDTO();
                animalDTO.Detachment = (animal as Amphibian).Detachment;
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
