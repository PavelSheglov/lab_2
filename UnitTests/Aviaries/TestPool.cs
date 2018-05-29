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
    public class TestPool
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var aviary = new Pool(PoolType.IndoorsPool);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(5, aviary.Capacity);
            Assert.AreEqual(5, aviary.FreePlaces);
            Assert.AreEqual(PoolType.IndoorsPool, aviary.Kind);
            Assert.AreEqual(15, aviary.Square);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var aviary = new Pool(PoolType.OpenAirPool, 10, 4);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(4, aviary.Capacity);
            Assert.AreEqual(4, aviary.FreePlaces);
            Assert.AreEqual(PoolType.OpenAirPool, aviary.Kind);
            Assert.AreEqual(10, aviary.Square);
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new Pool(PoolType.Pond);

            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);

            Assert.AreEqual(false, aviary.Close());

            aviary.Open();
            aviary.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "семейство1", "род1", "вид1"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new Pool(PoolType.Pond);

            aviary.Close();
            Assert.AreEqual(true, aviary.Open());
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);

            aviary.Open();
            Assert.AreEqual(false, aviary.Open());
        }
        [TestMethod]
        public void TestIsCorrectForSettlement()
        {
            var aviary = new Pool(PoolType.OpenAirPool);
            var animal1 = new Mammal(MammalDetachment.Pinnipedia, "семейство1", "род1", "вид1");
            var animal2 = new Mammal(MammalDetachment.Carnivora, "семейство2", "род2", "вид2");
            var animal3 = new Mammal(MammalDetachment.Perissodactyla, "семейство3", "род3", "вид3");
            var animal4 = new Mammal(MammalDetachment.Cetacea, "семейство4", "род4", "вид4");
            var animal5 = new Mammal(MammalDetachment.Rodentia, "семейство5", "род5", "вид5");
            var animal6 = new Bird(BirdDetachment.Anseriformes, "семейство6", "род6", "вид6");
            var animal7 = new Bird(BirdDetachment.Sphenisciformes, "семейство7", "род7", "вид7");

            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal3));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal4));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal5));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal6));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal7));

            aviary.SettleAnimal(animal1);
            var animal8 = new Mammal(MammalDetachment.Pinnipedia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal8));

            aviary.EvictAnimal(animal1);

            var animal9 = new Fish(FishDetachment.Rajiformes, "семейство9", "род9", "вид9");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal9));

            aviary.SettleAnimal(animal1);
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal4));
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var aviary = new Pool(PoolType.IndoorsPool, 10, 2);
            var animal1 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид1");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            var animal2 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));

            var animal3 = new Bird(BirdDetachment.Struthioniformes, "семейство3", "род3", "вид3");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));

            var animal4 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(false, aviary.SettleAnimal(animal4));

            var ids = new List<string>();
            foreach (var animal in aviary.GetListOfInhabitants())
                ids.Add(animal.Id);
            foreach (var id in ids)
                aviary.EvictAnimal(aviary.FindAnimal(id));
            aviary.Close();

            Assert.AreEqual(false, aviary.SettleAnimal(animal4));
        }
        [TestMethod]
        public void TestFindAnimal()
        {
            var aviary = new Pool(PoolType.Pond);
            var animal1 = new Bird(BirdDetachment.Anseriformes, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));

            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new Pool(PoolType.OpenAirPool);
            var animal1 = new Mammal(MammalDetachment.Carnivora, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);
            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);
        }
        [TestMethod]
        public void TestGetListOfInhabitants()
        {
            var aviary = new Pool(PoolType.IndoorsPool);
            var animal1 = new Mammal(MammalDetachment.Cetacea, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(1, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
        }
    }
}
