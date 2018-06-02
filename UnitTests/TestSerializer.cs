using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Serializer;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestSerializer
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var serialaizer = new ZooSerializer();
            Assert.AreEqual(@"..\..\..\Serialization\Zoo.xml", serialaizer.FileName);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            //Корректное создание сериализатора с правильным путем к файлу загрузки/выгрузки
            var serialaizer = new ZooSerializer(@"..\..\..\Serialization\NewZoo.xml");
            Assert.AreEqual(@"..\..\..\Serialization\NewZoo.xml", serialaizer.FileName);
            
            //Попытка указать пустой путь к файлу для выгрузки/загрузки (будет использован путь по умолчанию)
            var serialaizer2 = new ZooSerializer("");
            Assert.AreEqual(@"..\..\..\Serialization\Zoo.xml", serialaizer2.FileName);
            
            //Попытка указать некорректный путь к файлу для выгрузки/загрузки (будет использован путь по умолчанию)
            var serialaizer3 = new ZooSerializer(" ");
            Assert.AreEqual(@"..\..\..\Serialization\Zoo.xml", serialaizer3.FileName);
        }
        [TestMethod]
        public void TestChangeFileName()
        {
            var serialaizer = new ZooSerializer();
            //Путь к файлу до изменения
            Assert.AreEqual(@"..\..\..\Serialization\Zoo.xml", serialaizer.FileName);
            //Путь к файлу после изменения
            serialaizer.FileName = @"..\..\..\Serialization\NewZoo.xml";
            Assert.AreEqual(@"..\..\..\Serialization\NewZoo.xml", serialaizer.FileName);
        }
        [TestMethod]
        public void TestSerializeZoo()
        {
            var serialaizer = new ZooSerializer();
            
            //Успешная попытка сериализации пустого зоопарка
            var zoo = new Zoo("name", "address");
            serialaizer.SerializeZoo(zoo);
            Assert.AreEqual(true, File.Exists(serialaizer.FileName));
            var zoo2 = serialaizer.DeserializeZoo();
            Assert.AreEqual(zoo.Name, zoo2.Name);
            Assert.AreEqual(zoo.Address, zoo2.Address);
            Assert.AreEqual(0, zoo2.GetListOfAviaries().Count);
            Assert.AreEqual(0, zoo2.GetListOfAnimals().Count);

            //Успешная попытка сериализации непустого зоопарка
            zoo.AddAviary(new Cage(CageType.WithRocks));
            zoo.AddAviary(new Pool(PoolType.IndoorsPool));
            zoo.AddAviary(new Yard(YardType.Plain));
            zoo.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "family1", "genus1", "species1"), zoo.GetListOfAviaries(AviaryType.Cage).First());
            zoo.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "family2", "genus2", "species2"), zoo.GetListOfAviaries(AviaryType.Pool).First());
            zoo.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "family3", "genus3", "species3"), zoo.GetListOfAviaries(AviaryType.Yard).First());
            serialaizer.SerializeZoo(zoo);
            zoo2 = serialaizer.DeserializeZoo();
            Assert.AreEqual(3, zoo2.GetListOfAviaries().Count);
            Assert.AreEqual(3, zoo2.GetListOfAnimals().Count);
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Cage).All(aviary => (aviary as Cage).Kind == CageType.WithRocks));
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Pool).All(aviary => (aviary as Pool).Kind == PoolType.IndoorsPool));
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Yard).All(aviary => (aviary as Yard).Kind == YardType.Plain));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Mammal).Any(animal => (animal as Mammal).Detachment == MammalDetachment.Carnivora));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Bird).Any(animal => (animal as Bird).Detachment == BirdDetachment.Anseriformes));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Mammal).Any(animal => (animal as Mammal).Detachment == MammalDetachment.Artiodactyla));

            //Неуспешная попытка сериализации несуществующего зоопарка
            try
            {
                serialaizer.SerializeZoo(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            //Неуспешная попытка сериализации зоопарка в файл с некорректным путем
            try
            {
                serialaizer.FileName = @"??";
                serialaizer.SerializeZoo(zoo);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestDeserializeZoo()
        {
            var serialaizer = new ZooSerializer();

            //Успешная попытка десериализации непустого зоопарка
            var zoo = new Zoo("name", "address");
            zoo.AddAviary(new Cage(CageType.WithRocks));
            zoo.AddAviary(new Pool(PoolType.IndoorsPool));
            zoo.AddAviary(new Yard(YardType.Plain));
            zoo.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "family1", "genus1", "species1"), zoo.GetListOfAviaries(AviaryType.Cage).First());
            zoo.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "family2", "genus2", "species2"), zoo.GetListOfAviaries(AviaryType.Pool).First());
            zoo.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "family3", "genus3", "species3"), zoo.GetListOfAviaries(AviaryType.Yard).First());
            serialaizer.SerializeZoo(zoo);
            var zoo2 = serialaizer.DeserializeZoo();
            Assert.AreEqual(zoo.Name, zoo2.Name);
            Assert.AreEqual(zoo.Address, zoo2.Address);
            Assert.AreEqual(3, zoo2.GetListOfAviaries().Count);
            Assert.AreEqual(3, zoo2.GetListOfAnimals().Count);
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Cage).All(aviary => (aviary as Cage).Kind == CageType.WithRocks));
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Pool).All(aviary => (aviary as Pool).Kind == PoolType.IndoorsPool));
            Assert.AreEqual(true, zoo2.GetListOfAviaries(AviaryType.Yard).All(aviary => (aviary as Yard).Kind == YardType.Plain));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Mammal).Any(animal => (animal as Mammal).Detachment == MammalDetachment.Carnivora));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Bird).Any(animal => (animal as Bird).Detachment == BirdDetachment.Anseriformes));
            Assert.AreEqual(true, zoo2.GetListOfAnimals(AnimalClass.Mammal).Any(animal => (animal as Mammal).Detachment == MammalDetachment.Artiodactyla));

            //Неуспешная попытка десериализации из несуществующего файла
            try
            {
                serialaizer.FileName = @"..\..\..\Serialization\NewZoo.xml";
                var zoo3=serialaizer.DeserializeZoo();
                Assert.Fail();
            }
            catch (FileNotFoundException) { }

            //Неуспешная попытка десериализации зоопарка из файла с некорректным путем
            try
            {
                serialaizer.FileName = @"??";
                var zoo4=serialaizer.DeserializeZoo();
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
    }
}
