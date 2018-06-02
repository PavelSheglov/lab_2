using System;
using var_9.Serializer.DTOClasses.Aviaries;
using var_9.Serializer.DTOInterfaces;
using var_9.Zoopark.Classes.Aviaries;

namespace var_9.Serializer.DTOConverters.Aviaries
{
    public class AviaryConverter:IAviaryConverter
    {
        public Aviary ToAviary(AviaryDTO aviaryDTO)
        {
            try
            {
                if (aviaryDTO == null)
                    throw new ArgumentException("Пустой DTO объект (вольер)!!!");
                Aviary aviary = null;
                IAviaryConverter converter;
                switch (aviaryDTO.GetType().Name.ToString())
                {
                    case "AquariumDTO":
                        converter = new AquariumConverter();
                        aviary = converter.ToAviary(aviaryDTO);
                        break;
                    case "CageDTO":
                        converter = new CageConverter();
                        aviary = converter.ToAviary(aviaryDTO);
                        break;
                    case "GlassAviaryDTO":
                        converter = new GlassAviaryConverter();
                        aviary = converter.ToAviary(aviaryDTO);
                        break;
                    case "PoolDTO":
                        converter = new PoolConverter();
                        aviary = converter.ToAviary(aviaryDTO);
                        break;
                    case "YardDTO":
                        converter = new YardConverter();
                        aviary = converter.ToAviary(aviaryDTO);
                        break;
                }
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
                if (aviary == null)
                    throw new ArgumentException("Пустой объект (вольер)!!!");
                AviaryDTO aviaryDTO = null;
                IAviaryConverter converter;
                switch (aviary.GetType().Name.ToString())
                {
                    case "Aquarium":
                        converter = new AquariumConverter();
                        aviaryDTO = converter.ToAviaryDTO(aviary);
                        break;
                    case "Cage":
                        converter = new CageConverter();
                        aviaryDTO = converter.ToAviaryDTO(aviary);
                        break;
                    case "GlassAviary":
                        converter = new GlassAviaryConverter();
                        aviaryDTO = converter.ToAviaryDTO(aviary);
                        break;
                    case "Pool":
                        converter = new PoolConverter();
                        aviaryDTO = converter.ToAviaryDTO(aviary);
                        break;
                    case "Yard":
                        converter = new YardConverter();
                        aviaryDTO = converter.ToAviaryDTO(aviary);
                        break;
                }
                return aviaryDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
