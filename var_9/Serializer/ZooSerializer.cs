using System;
using System.Xml.Serialization;
using System.IO;
using var_9.Zoopark.Classes;
using var_9.Serializer.DTOConverters;
using var_9.Serializer.DTOClasses;

namespace var_9.Serializer
{
    public class ZooSerializer
    {
        private XmlSerializer _serializer;
        private ZooConverter _converter;
        public string FileName { get; set; }

        public ZooSerializer()
        {
            FileName = @"..\..\..\Serialization\Zoo.xml";
            _serializer = new XmlSerializer(typeof(ZooDTO));
            _converter = new ZooConverter();
        }
        public ZooSerializer(string fileName):this()
        {
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrWhiteSpace(fileName))
                FileName = fileName;
        }

        public void SerializeZoo(Zoo zoo)
        {
            try
            {
                using (var stream = new StreamWriter(FileName))
                {
                    _serializer.Serialize(stream, _converter.ToZooDTO(zoo));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Zoo DeserializeZoo()
        {
            try
            {
                Zoo zoo;
                using (var stream = new StreamReader(FileName))
                {
                    zoo = _converter.ToZoo((ZooDTO)_serializer.Deserialize(stream));
                }
                return zoo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
