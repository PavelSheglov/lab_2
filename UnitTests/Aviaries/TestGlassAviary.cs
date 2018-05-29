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
    public class TestGlassAviary
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(5, aviary.Capacity);
            Assert.AreEqual(5, aviary.FreePlaces);
            Assert.AreEqual(GlassAviaryType.WithWater, aviary.Kind);
            Assert.AreEqual(12, aviary.Volume);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater, 10, 3);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(3, aviary.Capacity);
            Assert.AreEqual(3, aviary.FreePlaces);
            Assert.AreEqual(GlassAviaryType.WithoutWater, aviary.Kind);
            Assert.AreEqual(10, aviary.Volume);
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater);

            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);

            Assert.AreEqual(false, aviary.Close());

            aviary.Open();
            aviary.SettleAnimal(new Reptile(ReptileDetachment.Squamata, "семейство1", "род1", "вид1"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);

            aviary.Close();
            Assert.AreEqual(true, aviary.Open());
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);

            aviary.Open();
            Assert.AreEqual(false, aviary.Open());
        }
        [TestMethod]
        public void TestIsCorrectForSettlement()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);
            var animal1 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид1");
            var animal2 = new Mammal(MammalDetachment.Chiroptera, "семейство2", "род2", "вид2");
            var animal3 = new Amphibian(AmphibianDetachment.Anura, "семейство3", "род3", "вид3");
            var animal4 = new Reptile(ReptileDetachment.Testudinata, "семейство4", "род4", "вид4");

            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal3));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal4));
            
            aviary.SettleAnimal(animal1);
            var animal5 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal5));

            aviary.EvictAnimal(animal1);

            var animal6 = new Fish(FishDetachment.Rajiformes, "семейство8", "род8", "вид8");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal6));

            aviary.SettleAnimal(animal1);
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal4));
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater, 10, 2);
            var animal1 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид1");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            var animal2 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));

            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
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
            var aviary = new GlassAviary(GlassAviaryType.WithWater);
            var animal1 = new Reptile(ReptileDetachment.Crocodilia, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));

            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater);
            var animal1 = new Amphibian(AmphibianDetachment.Urodela, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);
            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);
        }
        [TestMethod]
        public void TestGetListOfInhabitants()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);
            var animal1 = new Mammal(MammalDetachment.Chiroptera, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(1, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
        }
    }
}
