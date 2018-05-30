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
    public class TestAquarium
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var aviary = new Aquarium(AquariumType.Freshwater);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(5, aviary.Capacity);
            Assert.AreEqual(5, aviary.FreePlaces);
            Assert.AreEqual(AquariumType.Freshwater, aviary.Kind);
            Assert.AreEqual(2, aviary.Volume);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var aviary = new Aquarium(AquariumType.Freshwater, 10, 15);

            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(15, aviary.Capacity);
            Assert.AreEqual(15, aviary.FreePlaces);
            Assert.AreEqual(AquariumType.Freshwater, aviary.Kind);
            Assert.AreEqual(10, aviary.Volume);
            try
            {
                var aviary2 = new Aquarium(AquariumType.Freshwater, -1, 0);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);

            Assert.AreEqual(false, aviary.Close());

            aviary.Open();
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);

            aviary.Close();
            Assert.AreEqual(true, aviary.Open());
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);

            aviary.Open();
            Assert.AreEqual(false, aviary.Open());
        }
        [TestMethod]
        public void TestIsCorrectForSettlement()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            aviary.SettleAnimal(animal1);
            var animal2 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));

            aviary.EvictAnimal(animal1);
            
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal3));

            aviary.SettleAnimal(animal1);
            var animal4 = new Fish(FishDetachment.Rajiformes, "Ромбовые скаты", "Дактилобаты", "Вооруженный дактилобат");
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
            var aviary = new Aquarium(AquariumType.SeaWater);
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            var animal2 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));
            
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));

            
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));

            var animal4 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
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
            var aviary = new Aquarium(AquariumType.SeaWater);
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal1);

            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));

            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
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
            var aviary = new Aquarium(AquariumType.SeaWater);
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal1);
            
            Assert.AreEqual(1, aviary.GetListOfInhabitants().Count);

            aviary.EvictAnimal(animal1);

            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
        }
    }
}
