using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests
{
    [TestClass]
    public class TestZoo
    {
        [TestMethod]
        public void TestSimpleConstructor()
        {
            var zoo = new Zoo();

            Assert.AreEqual("", zoo.Name);
            Assert.AreEqual("", zoo.Address);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var zoo = new Zoo("name", "address");

            Assert.AreEqual("name", zoo.Name);
            Assert.AreEqual("address", zoo.Address);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestEditZooName()
        {
            var zoo = new Zoo();

            Assert.AreEqual("", zoo.Name);

            zoo.Name = "name";

            Assert.AreEqual("name", zoo.Name);
        }
        [TestMethod]
        public void TestEditZooAddress()
        {
            var zoo = new Zoo();

            Assert.AreEqual("", zoo.Address);

            zoo.Address = "address";

            Assert.AreEqual("address", zoo.Address);
        }
        [TestMethod]
        public void TestAddAviary()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);

            Assert.AreEqual(1, zoo.GetListOfAviaries().Count);
                        
            try
            {
                zoo.AddAviary(null);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestFindAviary()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);

            Assert.AreEqual(aviary, zoo.FindAviary(aviary.Number));
            Assert.AreEqual(null, zoo.FindAviary("any number"));
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);

            Assert.AreEqual(true, zoo.CloseAviary(aviary.Number));
            try
            {
                zoo.CloseAviary("any number");
                Assert.Fail();
            }
            catch (Exception) { }
            Assert.AreEqual(false, zoo.CloseAviary(aviary.Number));
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            zoo.CloseAviary(aviary.Number);

            Assert.AreEqual(true, zoo.OpenAviary(aviary.Number));
            try
            {
                zoo.OpenAviary("any number");
                Assert.Fail();
            }
            catch (Exception) { }
            Assert.AreEqual(false, zoo.OpenAviary(aviary.Number));
        }
        [TestMethod]
        public void TestDeleteAviary()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            var aviary2 = new Cage(CageType.WithTrees);
            zoo.AddAviary(aviary);
            zoo.AddAviary(aviary2);
            zoo.CloseAviary(aviary.Number);

            Assert.AreEqual(true, zoo.DeleteAviary(aviary.Number));
            try
            {
                zoo.DeleteAviary("any number");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                zoo.DeleteAviary(aviary.Number);
                Assert.Fail();
            }
            catch (Exception) { }
            Assert.AreEqual(false, zoo.DeleteAviary(aviary2.Number));
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks, 10, 2);
            zoo.AddAviary(aviary);
            var animal = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species2");
            var animal3 = new Mammal(MammalDetachment.Carnivora, "family3", "genus3", "species3");
            var animal4 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species2");

            Assert.AreEqual(true, zoo.SettleAnimal(animal, zoo.FindAviary(aviary.Number)));
            Assert.AreEqual(true, zoo.SettleAnimal(animal2, zoo.FindAviary(aviary.Number)));
            Assert.AreEqual(false, zoo.SettleAnimal(animal3, zoo.FindAviary(aviary.Number)));
            Assert.AreEqual(false, zoo.SettleAnimal(animal4, zoo.FindAviary(aviary.Number)));
            try
            {
                zoo.SettleAnimal(null, zoo.FindAviary(aviary.Number));
            }
            catch (Exception) { }
            try
            {
                zoo.SettleAnimal(animal, null);
            }
            catch (Exception) { }
            try
            {
                zoo.SettleAnimal(animal, new Cage(CageType.WithRocks, 10, 2));
            }
            catch (Exception) { }

        }
        [TestMethod]
        public void TestFindAnimal()
        {
            var zoo = new Zoo("name", "address");
            var aviary = new Cage(CageType.WithRocks);
            var animal = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary);
            zoo.SettleAnimal(animal, zoo.FindAviary(aviary.Number));

            Assert.AreEqual(animal, zoo.FindAnimal(animal.Id));
            Assert.AreEqual(null, zoo.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestTransferAnimal()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");

            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            System.Threading.Thread.Sleep(10);

            var aviary2 = new Cage(CageType.WithTrees, 5, 1);
            zoo.AddAviary(aviary2);
            System.Threading.Thread.Sleep(10);

            var aviary3 = new Pool(PoolType.IndoorsPool);
            zoo.AddAviary(aviary3);
            System.Threading.Thread.Sleep(10);

            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");


            Assert.AreEqual(true, zoo.TransferAnimal(zoo.FindAnimal(animal1.Id), zoo.FindAviary(aviary2.Number)));
            Assert.AreEqual(false, zoo.TransferAnimal(zoo.FindAnimal(animal1.Id), zoo.FindAviary(aviary3.Number)));

            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary1.Number));
                Assert.Fail();
            }
            catch (Exception) { }

            try
            {
                zoo.TransferAnimal(animal2, zoo.FindAviary(aviary1.Number));
                Assert.Fail();
            }
            catch (Exception) { }

            zoo.SettleAnimal(animal2, aviary1);
            var aviary4 = new Pool(PoolType.IndoorsPool);
            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary4.Number));
                Assert.Fail();
            }
            catch (Exception) { }

            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), aviary4);
                Assert.Fail();
            }
            catch (Exception) { }

            Assert.AreEqual(false, zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary2.Number)));
            zoo.EvictAnimal(animal1);
            zoo.CloseAviary(aviary2.Number);
            Assert.AreEqual(false, zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary2.Number)));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");

            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            zoo.EvictAnimal(animal1);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
            try
            {
                zoo.EvictAnimal(null);
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                zoo.EvictAnimal(animal1);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestGetFullListOfAviaries()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary1);
            
            Assert.AreEqual(1, zoo.GetListOfAviaries().Count);
            zoo.CloseAviary(aviary1.Number);
            zoo.DeleteAviary(aviary1.Number);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
        }
        [TestMethod]
        public void TestGetListOfAviariesByType()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary1);

            Assert.AreEqual(1, zoo.GetListOfAviaries(AviaryType.Cage).Count);
            Assert.AreEqual(0, zoo.GetListOfAviaries(AviaryType.Aquarium).Count);
        }
        [TestMethod]
        public void TestGetFullListOfAnimals()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);

            Assert.AreEqual(1, zoo.GetListOfAnimals().Count);
            zoo.EvictAnimal(animal1);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestGetListOfAnimalsByClass()
        {
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);

            Assert.AreEqual(1, zoo.GetListOfAnimals(AnimalClass.Mammal).Count);
            Assert.AreEqual(0, zoo.GetListOfAnimals(AnimalClass.Bird).Count);
        }
    }
}
