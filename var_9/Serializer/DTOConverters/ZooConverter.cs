using System;
using var_9.Serializer.DTOConverters.Aviaries;
using var_9.Serializer.DTOClasses;
using var_9.Zoopark.Classes;
using var_9.Serializer.DTOInterfaces;

namespace var_9.Serializer.DTOConverters
{
    public class ZooConverter:IZooConverter
    {
        public Zoo ToZoo(ZooDTO zooDTO)
        {
            try
            {
                if (zooDTO == null)
                    throw new ArgumentException("Пустой DTO объект (зоопарк)!!!");
                var zoo = new Zoo(zooDTO.Name, zooDTO.Address);
                var converter = new AviaryConverter();
                foreach (var aviary in zooDTO.Aviaries)
                    zoo.AddAviary(converter.ToAviary(aviary));
                return zoo;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public ZooDTO ToZooDTO(Zoo zoo)
        {
            try
            {
                if (zoo == null)
                    throw new ArgumentException("Пустой объект (зоопарк)!!!");
                var zooDTO = new ZooDTO();
                zooDTO.Name = zoo.Name;
                zooDTO.Address = zoo.Address;
                var converter = new AviaryConverter();
                foreach (var aviary in zoo.GetListOfAviaries())
                    zooDTO.Aviaries.Add(converter.ToAviaryDTO(aviary));
                return zooDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
