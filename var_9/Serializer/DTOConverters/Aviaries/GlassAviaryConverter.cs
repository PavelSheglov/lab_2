using System;
using var_9.Serializer.DTOConverters.Animals;
using var_9.Serializer.DTOClasses.Aviaries;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Aviaries;

namespace var_9.Serializer.DTOConverters.Aviaries
{
    public class GlassAviaryConverter : IAviaryConverter
    {
        public Aviary ToAviary(AviaryDTO aviaryDTO)
        {
            try
            {
                if (aviaryDTO == null || !(aviaryDTO is GlassAviaryDTO))
                    throw new ArgumentException("Пустой DTO объект (вольер) или не подходящего типа!!!");
                var aviary = new GlassAviary((aviaryDTO as GlassAviaryDTO).Kind,
                                             (aviaryDTO as GlassAviaryDTO).Volume,
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
                if (aviary == null || !(aviary is GlassAviary))
                    throw new ArgumentException("Пустой объект (вольер) или не подходящего типа!!!");
                var aviaryDTO = new GlassAviaryDTO();
                aviaryDTO.Kind = (aviary as GlassAviary).Kind;
                aviaryDTO.Status = aviary.Status;
                aviaryDTO.Volume = (aviary as GlassAviary).Volume;
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

