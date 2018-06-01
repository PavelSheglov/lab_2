using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using var_9.Zoopark.Classes;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9
{
    class ZooSerializer
    {
        private XmlSerializer _serializer;
        public string FileName { get; set; }

        public ZooSerializer()
        {
            FileName = @"..\..\..\Serialization\Zoo.xml";
            _serializer = new XmlSerializer(typeof(Zoo));
        }
        public ZooSerializer(string fileName):this()
        {
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrWhiteSpace(fileName))
                FileName = fileName;
        }

        public bool SerializeZoo(Zoo zoo)
        {
            var result = false;
            using (var stream = new StreamWriter(FileName))
            {
                _serializer.Serialize(stream, zoo);
                result = true;
            }
            return result;
        }

        public Zoo DeserializeZoo()
        {
            Zoo zoo = null;
            using (var stream = new StreamReader(FileName))
            {
                zoo = (Zoo)_serializer.Deserialize(stream);
            }
            return zoo;
        }
    }
}
