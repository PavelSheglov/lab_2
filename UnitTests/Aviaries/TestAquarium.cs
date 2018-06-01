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
            //Проверка параметров корректно созданного вольера
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
            //Проверка параметров корректно созданного вольера
            var aviary = new Aquarium(AquariumType.Freshwater, 10, 15);
            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(15, aviary.Capacity);
            Assert.AreEqual(15, aviary.FreePlaces);
            Assert.AreEqual(AquariumType.Freshwater, aviary.Kind);
            Assert.AreEqual(10, aviary.Volume);
            
            //Попытка создать вольер с недопустимыми значениями параметров
            try
            {
                var aviary2 = new Aquarium(AquariumType.Freshwater, -1, 0);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешное закрытие вольера
            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);
            
            //Попытка закрыть уже закрытый вольер
            Assert.AreEqual(false, aviary.Close());
            
            //Попытка закрыть непустой вольер
            aviary.Open();
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешное открытие закрытого вольера
            aviary.Close();
            Assert.AreEqual(true, aviary.Open());
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            
            //Попытка открыть уже открытый вольер
            Assert.AreEqual(false, aviary.Open());
        }
        [TestMethod]
        public void TestIsCorrectForSettlement()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешная проверка на допустимость заселения животного в подходящий пустой вольер
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            
            //Успешная проверка на допустимость заселения животного в подходящий непустой вольер
            aviary.SettleAnimal(animal1);
            var animal2 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));
            
            //Неуспешная проверка на допустимость заселения животного в неподходящий пустой вольер
            aviary.EvictAnimal(animal1);
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal3));
            
            //Неуспешная проверка на допустимость заселения животного в подходящий по типу вольер, но занятый несовместимым животным
            aviary.SettleAnimal(animal1);
            var animal4 = new Fish(FishDetachment.Rajiformes, "Ромбовые скаты", "Дактилобаты", "Вооруженный дактилобат");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal4));
            
            //Неуспешная проверка на допустимость заселения несуществующего животного
            try
            {
                aviary.IsCorrectForSettlement(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestSettleAnimal()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешная попытка заселить животное в подходящий пустой вольер
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            
            //Успешная попытка заселить животное в подходящий непустой вольер
            var animal2 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));
            
            //Неуспешная попытка заселить животное в неподходящий непустой вольер
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));
            
            //Неуспешная попытка заселить животное в подходящий полностью заполненный вольер
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));
            aviary.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Черноморский лосось"));
            var animal4 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            Assert.AreEqual(false, aviary.SettleAnimal(animal4));
            
            //Неуспешная попытка заселить животное в подходящий закрытый вольер           
            var ids = new List<string>();
            foreach (var animal in aviary.GetListOfInhabitants())
                ids.Add(animal.Id);
            foreach (var id in ids)
                aviary.EvictAnimal(aviary.FindAnimal(id));
            aviary.Close();
            Assert.AreEqual(false, aviary.SettleAnimal(animal4));
            
            //Неуспешная попытка заселить несуществующее животное в пустой вольер          
            aviary.Open();
            try
            {
                aviary.SettleAnimal(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestFindAnimal()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешный поиск существующего животного
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal1);
            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));
            
            //Неуспешный поиск несуществующего животного
            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Успешная попытка выселить существующее животное
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal1);
            aviary.EvictAnimal(animal1);
            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
            
            //Неуспешная попытка выселить несуществующее животное
            try
            {
                aviary.EvictAnimal(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Неуспешная попытка выселить отсутствующее в вольере животное
            try
            {
                aviary.EvictAnimal(animal1);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetListOfInhabitants()
        {
            var aviary = new Aquarium(AquariumType.SeaWater);
            
            //Количество обитателей непустого вольера
            var animal1 = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal1);
            Assert.AreEqual(1, aviary.GetListOfInhabitants().Count);
            
            //Количество обитателей пустого вольера
            aviary.EvictAnimal(animal1);
            Assert.AreEqual(0, aviary.GetListOfInhabitants().Count);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var aviary = new Aquarium(AquariumType.SeaWater, 5, 10);
            var animal = new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            aviary.SettleAnimal(animal);
            var str = "Номер:" + aviary.Number +
                      " Тип:Aquarium Статус:Opened" +
                      "\nВместимость:10 особей, свободно:9 мест" +
                      "\nОбъем:5 куб.м." +
                      "\nРазновидность:SeaWater";
            Assert.AreEqual(str, aviary.ToString());
        }
    }
}
