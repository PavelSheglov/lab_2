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
            
            //Проверка параметров корректно созданного зоопарка
            Assert.AreEqual("", zoo.Name);
            Assert.AreEqual("", zoo.Address);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestFullVersionConstructor()
        {
            var zoo = new Zoo("name", "address");
            
            //Проверка параметров корректно созданного зоопарка
            Assert.AreEqual("name", zoo.Name);
            Assert.AreEqual("address", zoo.Address);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestEditZooName()
        {
            var zoo = new Zoo();
            
            //Значение поля до редактирования
            Assert.AreEqual("", zoo.Name);

            //Значение поля после редактирования
            zoo.Name = "name";
            Assert.AreEqual("name", zoo.Name);
        }
        [TestMethod]
        public void TestEditZooAddress()
        {
            var zoo = new Zoo();
            
            //Значение поля до редактирования
            Assert.AreEqual("", zoo.Address);

            //Значение поля после редактирования
            zoo.Address = "address";
            Assert.AreEqual("address", zoo.Address);
        }
        [TestMethod]
        public void TestAddAviary()
        {
            var zoo = new Zoo("name", "address");

            //Корректное добавление
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            Assert.AreEqual(1, zoo.GetListOfAviaries().Count);
            
            //Попытка добавить несуществующий вольер                  
            try
            {
                zoo.AddAviary(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestFindAviary()
        {
            var zoo = new Zoo("name", "address");
            
            //Поиск существующего вольера
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            Assert.AreEqual(aviary, zoo.FindAviary(aviary.Number));
            
            //Поиск несуществующего вольера
            Assert.AreEqual(null, zoo.FindAviary("any number"));
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var zoo = new Zoo("name", "address");
            
            //Корректное закрытие открытого вольера
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            Assert.AreEqual(true, zoo.CloseAviary(aviary.Number));
            Assert.AreEqual(AviaryStatus.Closed, zoo.FindAviary(aviary.Number).Status);

            //Попытка закрыть уже закрытый вольер
            Assert.AreEqual(false, zoo.CloseAviary(aviary.Number));

            //Попытка закрыть несуществующий вольер
            try
            {
                zoo.CloseAviary("any number");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var zoo = new Zoo("name", "address");
            
            //Корректное открытие закрытого вольера
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            zoo.CloseAviary(aviary.Number);
            Assert.AreEqual(true, zoo.OpenAviary(aviary.Number));
            Assert.AreEqual(AviaryStatus.Opened, zoo.FindAviary(aviary.Number).Status);

            //Попытка открыть уже открытый вольер
            Assert.AreEqual(false, zoo.OpenAviary(aviary.Number));

            //Попытка открыть несуществующий вольер
            try
            {
                zoo.OpenAviary("any number");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestDeleteAviary()
        {
            var zoo = new Zoo("name", "address");
            //Корректное удаление существующего пустого закрытого вольера
            var aviary = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary);
            zoo.CloseAviary(aviary.Number);
            Assert.AreEqual(true, zoo.DeleteAviary(aviary.Number));
            Assert.AreEqual(null, zoo.FindAviary(aviary.Number));

            //Попытка удалить незакрытый вольер
            System.Threading.Thread.Sleep(10);
            var aviary2 = new Cage(CageType.WithTrees);
            zoo.AddAviary(aviary2);
            Assert.AreEqual(false, zoo.DeleteAviary(aviary2.Number));
            
            //Попытка удалить не существующий вольер
            try
            {
                zoo.DeleteAviary("any number");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка удалить уже удаленный вольер
            try
            {
                zoo.DeleteAviary(aviary.Number);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var zoo = new Zoo("name", "address");
            
            //Корректное заселение существующего животного в существующий подходящий пустой вольер
            var aviary = new Cage(CageType.WithRocks, 10, 2);
            zoo.AddAviary(aviary);
            var animal = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            Assert.AreEqual(true, zoo.SettleAnimal(animal, zoo.FindAviary(aviary.Number)));
            
            //Корректное заселение существующего животного в существующий подходящий не до конца заполненный вольер
            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species2");
            Assert.AreEqual(true, zoo.SettleAnimal(animal2, zoo.FindAviary(aviary.Number)));
            
            //Попытка заселения существующего животного в существующий не подходящий вольер
            var animal3 = new Mammal(MammalDetachment.Carnivora, "family3", "genus3", "species3");
            Assert.AreEqual(false, zoo.SettleAnimal(animal3, zoo.FindAviary(aviary.Number)));
            
            //Попытка заселения существующего животного в существующий подходящий, но полностью заполненный вольер
            var animal4 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species2");
            Assert.AreEqual(false, zoo.SettleAnimal(animal4, zoo.FindAviary(aviary.Number)));
            
            //Попытка заселения не существующего животного в существующий вольер
            try
            {
                zoo.SettleAnimal(null, zoo.FindAviary(aviary.Number));
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка заселения существующего животного в несуществующий вольер
            try
            {
                zoo.SettleAnimal(animal, null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка поселить существующее животное в существующий, но отсутствующий в данном зоопарке вольер
            try
            {
                zoo.SettleAnimal(animal, new Cage(CageType.WithRocks, 10, 2));
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestFindAnimal()
        {
            var zoo = new Zoo("name", "address");
            
            //Успешный поиск имеющегося в зоопарке животного
            var aviary = new Cage(CageType.WithRocks);
            var animal = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary);
            zoo.SettleAnimal(animal, zoo.FindAviary(aviary.Number));
            Assert.AreEqual(animal, zoo.FindAnimal(animal.Id));
            
            //Неуспешный поиск отсутствующего в зоопарке животного
            Assert.AreEqual(null, zoo.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestTransferAnimal()
        {
            var zoo = new Zoo("name", "address");
            
            //Успешная попытка переместить животное в существующий подходящий вольер
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            var aviary2 = new Cage(CageType.WithTrees, 5, 1);
            zoo.AddAviary(aviary2);
            Assert.AreEqual(true, zoo.TransferAnimal(zoo.FindAnimal(animal1.Id), zoo.FindAviary(aviary2.Number)));
            
            //Неуспешная попытка переместить животное в существующий не подходящий вольер
            var aviary3 = new Pool(PoolType.IndoorsPool);
            zoo.AddAviary(aviary3);
            Assert.AreEqual(false, zoo.TransferAnimal(zoo.FindAnimal(animal1.Id), zoo.FindAviary(aviary3.Number)));
            
            //Попытка переместить отсутствующее в зоопарке животное(несуществующее) в имеющийся вольер
            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary1.Number));
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка переместить отсутствующее в зоопарке животное в имеющийся вольер
            try
            {
                zoo.TransferAnimal(animal2, zoo.FindAviary(aviary1.Number));
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка переместить имеющееся в зоопарке животное в отсутствующий (несуществующий) вольер
            zoo.SettleAnimal(animal2, aviary1);
            var aviary4 = new Pool(PoolType.IndoorsPool);
            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary4.Number));
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка переместить имеющееся в зоопарке животное в отсутствующий вольер
            try
            {
                zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), aviary4);
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка переместить имеющееся животное в имеющийся подходящий, но полностью заполненный вольер
            Assert.AreEqual(false, zoo.TransferAnimal(zoo.FindAnimal(animal2.Id), zoo.FindAviary(aviary2.Number)));
            
            //Попытка переместить имеющееся животное в имеющийся подходящий пустой, но закрытый вольер
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
            
            //Результат успешного выселения животного
            zoo.EvictAnimal(animal1);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
            
            //Попытка выселить несуществующее (пустое) животное
            try
            {
                zoo.EvictAnimal(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка выселить отсутствующее в зоопарке животное
            try
            {
                zoo.EvictAnimal(animal1);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullListOfAviaries()
        {
            var zoo = new Zoo("name", "address");
            
            //Количество вольеров в непустом зоопарке
            var aviary1 = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary1);
            Assert.AreEqual(1, zoo.GetListOfAviaries().Count);
            
            //Количество вольеров в пустом зоопарке
            zoo.CloseAviary(aviary1.Number);
            zoo.DeleteAviary(aviary1.Number);
            Assert.AreEqual(0, zoo.GetListOfAviaries().Count);
        }
        [TestMethod]
        public void TestGetListOfAviariesByType()
        {
            var zoo = new Zoo("name", "address");
            
            //Количество вольеров имеющегося в зоопарке типа вольеров
            var aviary1 = new Cage(CageType.WithRocks);
            zoo.AddAviary(aviary1);
            Assert.AreEqual(1, zoo.GetListOfAviaries(AviaryType.Cage).Count);
            
            //Количество вольеров отсутствующего в зоопарке типа вольеров
            Assert.AreEqual(0, zoo.GetListOfAviaries(AviaryType.Aquarium).Count);
        }
        [TestMethod]
        public void TestGetFullListOfAnimals()
        {
            var zoo = new Zoo("name", "address");
            
            //Количество животных в непустом зоопарке
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            Assert.AreEqual(1, zoo.GetListOfAnimals().Count);
            
            //Количество животных в пустом зоопарке
            zoo.EvictAnimal(animal1);
            Assert.AreEqual(0, zoo.GetListOfAnimals().Count);
        }
        [TestMethod]
        public void TestGetListOfAnimalsByClass()
        {
            var zoo = new Zoo("name", "address");
            
            //Количество животных имеющегося в зоопарке класса
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            Assert.AreEqual(1, zoo.GetListOfAnimals(AnimalClass.Mammal).Count);
            
            //Количество животных отсутствующего в зоопарке класса
            Assert.AreEqual(0, zoo.GetListOfAnimals(AnimalClass.Bird).Count);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var zoo = new Zoo("name", "address");
            var aviary1 = new Cage(CageType.WithRocks);
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "family1", "genus1", "species1");
            zoo.AddAviary(aviary1);
            zoo.SettleAnimal(animal1, aviary1);
            var str = "Название: name\nАдрес: address" +
                      "\nКоличество вольеров: 1 Общая популяция: 1";
            Assert.AreEqual(str, zoo.ToString());
        }
    }
}
