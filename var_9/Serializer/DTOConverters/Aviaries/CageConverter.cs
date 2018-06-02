using System;
using var_9.Serializer.DTOConverters.Animals;
using var_9.Serializer.DTOClasses.Aviaries;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Aviaries;

namespace var_9.Serializer.DTOConverters.Aviaries
{
    public class CageConverter : IAviaryConverter
    {
        public Aviary ToAviary(AviaryDTO aviaryDTO)
        {
            try
            {
                if (aviaryDTO == null || !(aviaryDTO is CageDTO))
                    throw new ArgumentException("Пустой DTO объект (вольер) или не подходящего типа!!!");
                var aviary = new Cage((aviaryDTO as CageDTO).Kind,
                                          (aviaryDTO as CageDTO).Square,
                                          aviaryDTO.Capacity);
                var converter = new AnimalConverter();
                foreach (var inhabitant in aviaryDTO.Inhabitants)
                    aviary.SettleAnimal(converter.ToAnimal(inhabitant));
                return aviary;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public AviaryDTO ToAviaryDTO(Aviary aviary)
        {
            try
            {
                if (aviary == null || !(aviary is Cage))
                    throw new ArgumentException("Пустой объект (вольер) или не подходящего типа!!!");
                var aviaryDTO = new CageDTO();
                aviaryDTO.Kind = (aviary as Cage).Kind;
                aviaryDTO.Status = aviary.Status;
                aviaryDTO.Square = (aviary as Cage).Square;
                aviaryDTO.Capacity = aviary.Capacity;
                var converter = new AnimalConverter();
                foreach (var inhabitant in aviary.GetListOfInhabitants())
                    aviaryDTO.Inhabitants.Add(converter.ToAnimalDTO(inhabitant));
                return aviaryDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
