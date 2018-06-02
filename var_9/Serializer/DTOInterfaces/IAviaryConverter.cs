using var_9.Serializer.DTOClasses.Aviaries;
using var_9.Zoopark.Classes.Aviaries;

namespace var_9.Serializer.DTOInterfaces
{
    public interface IAviaryConverter
    {
        Aviary ToAviary(AviaryDTO aviaryDTO);
        AviaryDTO ToAviaryDTO(Aviary aviary);
    }
}
