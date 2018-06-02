using System;
using var_9.Serializer.DTOClasses.Animals;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Animals;

namespace var_9.Serializer.DTOConverters.Animals
{
    public class AnimalConverter : IAnimalConverter
    {
        public Animal ToAnimal(AnimalDTO animalDTO)
        {
            try
            {
                if (animalDTO == null)
                    throw new ArgumentException("Пустой DTO объект (животное)!!!");

                Animal animal=null;
                IAnimalConverter converter;
                switch(animalDTO.GetType().Name.ToString())
                {
                    case "AmphibianDTO":
                        converter = new AmphibianConverter();
                        animal = converter.ToAnimal(animalDTO);
                        break;
                    case "BirdDTO":
                        converter = new BirdConverter();
                        animal = converter.ToAnimal(animalDTO);
                        break;
                    case "FishDTO":
                        converter = new FishConverter();
                        animal = converter.ToAnimal(animalDTO);
                        break;
                    case "MammalDTO":
                        converter = new MammalConverter();
                        animal = converter.ToAnimal(animalDTO);
                        break;
                    case "ReptileDTO":
                        converter = new ReptileConverter();
                        animal = converter.ToAnimal(animalDTO);
                        break;
                }
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
                if (animal == null)
                    throw new ArgumentException("Пустой объект (животное)!!!");
                AnimalDTO animalDTO=null;
                IAnimalConverter converter;
                switch (animal.GetType().Name.ToString())
                {
                    case "Amphibian":
                        converter = new AmphibianConverter();
                        animalDTO = converter.ToAnimalDTO(animal);
                        break;
                    case "Bird":
                        converter = new BirdConverter();
                        animalDTO = converter.ToAnimalDTO(animal);
                        break;
                    case "Fish":
                        converter = new FishConverter();
                        animalDTO = converter.ToAnimalDTO(animal);
                        break;
                    case "Mammal":
                        converter = new MammalConverter();
                        animalDTO = converter.ToAnimalDTO(animal);
                        break;
                    case "Reptile":
                        converter = new ReptileConverter();
                        animalDTO = converter.ToAnimalDTO(animal);
                        break;
                }
                return animalDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
