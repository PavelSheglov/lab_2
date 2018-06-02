using System;
using System.Collections.Generic;
using var_9.Serializer.DTOClasses.Aviaries;

namespace var_9.Serializer.DTOClasses
{
    [Serializable]
    public class ZooDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<AviaryDTO> Aviaries;

        public ZooDTO()
        {
            Aviaries = new List<AviaryDTO>();
        }
    }
}
