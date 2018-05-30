using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Aviaries
{
    [TestClass]
    public class TestYard
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var aviary = new Yard(YardType.Forest);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(10, aviary.Capacity);
            Assert.AreEqual(10, aviary.FreePlaces);
            Assert.AreEqual(YardType.Forest, aviary.Kind);
            Assert.AreEqual(1000, aviary.Square);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var aviary = new Yard(YardType.Plain, 1000, 3);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(3, aviary.Capacity);
            Assert.AreEqual(3, aviary.FreePlaces);
            Assert.AreEqual(YardType.Plain, aviary.Kind);
            Assert.AreEqual(1000, aviary.Square);
            try
            {
                var aviary2 = new Yard(YardType.Plain, -1, 0);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new Yard(YardType.Rock);

            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);

            Assert.AreEqual(false, aviary.Close());

            aviary.Open();
            aviary.SettleAnimal(new Mammal(MammalDetachment.Perissodactyla, "семейство1", "род1", "вид1"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new Yard(YardType.Plain);

            aviary.Close();
            Assert.AreEqual(true, aviary.Open());
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);

            aviary.Open();
            Assert.AreEqual(false, aviary.Open());
        }
        [TestMethod]
        public void TestIsCorrectForSettlement()
        {
            var aviary = new Yard(YardType.Plain);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид1");
            var animal2 = new Mammal(MammalDetachment.Carnivora, "семейство2", "род2", "вид2");
            var animal3 = new Mammal(MammalDetachment.Perissodactyla, "семейство3", "род3", "вид3");
            var animal4 = new Mammal(MammalDetachment.Proboscidea, "семейство4", "род4", "вид4");
            var animal5 = new Bird(BirdDetachment.Struthioniformes, "семейство5", "род5", "вид5");
            
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal3));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal4));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal5));
            
            aviary.SettleAnimal(animal1);
            var animal6 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal6));

            aviary.EvictAnimal(animal1);

            var animal7 = new Mammal(MammalDetachment.Chiroptera, "семейство7", "род7", "вид7");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal7));

            aviary.SettleAnimal(animal1);
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal4));
            try
            {
                aviary.IsCorrectForSettlement(null);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var aviary = new Yard(YardType.Forest, 100, 2);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид1");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));

            var animal3 = new Bird(BirdDetachment.Struthioniformes, "семейство3", "род3", "вид3");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));

            var animal4 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
            Assert.AreEqual(false, aviary.SettleAnimal(animal4));

            var ids = new List<string>();
            foreach (var animal in aviary.GetListOfInhabitants())
                ids.Add(animal.Id);
            foreach (var id in ids)
                aviary.EvictAnimal(aviary.FindAnimal(id));
            aviary.Close();

            Assert.AreEqual(false, aviary.SettleAnimal(animal4));
            try
            {
                aviary.SettleAnimal(null);
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestFindAnimal()
        {
            var aviary = new Yard(YardType.Plain);
            var animal1 = new Bird(BirdDetachment.Struthioniformes, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));

            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new Yard(YardType.Rock);
            var animal1 = new Mammal(MammalDetachment.Carnivora, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);
            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
            try
            {
                aviary.EvictAnimal(null);
            }
            catch (Exception) { }
            try
            {
                aviary.EvictAnimal(animal1);
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestGetListOfInhabitants()
        {
            var aviary = new Yard(YardType.Forest);
            var animal1 = new Bird(BirdDetachment.Struthioniformes, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(1, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
        }
    }
}
