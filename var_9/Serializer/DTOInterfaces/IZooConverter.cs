using var_9.Serializer.DTOClasses;
using var_9.Zoopark.Classes;

namespace var_9.Serializer.DTOInterfaces
{
    public interface IZooConverter
    {
        Zoo ToZoo(ZooDTO zooDTO);
        ZooDTO ToZooDTO(Zoo zoo);
    }
}
