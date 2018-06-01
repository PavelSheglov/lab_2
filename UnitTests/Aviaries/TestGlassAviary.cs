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
            //Проверка параметров корректно созданного вольера
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
            //Проверка параметров корректно созданного вольера
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater, 10, 3);
            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(3, aviary.Capacity);
            Assert.AreEqual(3, aviary.FreePlaces);
            Assert.AreEqual(GlassAviaryType.WithoutWater, aviary.Kind);
            Assert.AreEqual(10, aviary.Volume);
            
            //Попытка создать вольер с недопустимыми значениями параметров
            try
            {
                var aviary2 = new GlassAviary(GlassAviaryType.WithoutWater, -1, 0);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater);
            
            //Успешное закрытие вольера
            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);
            
            //Попытка закрыть уже закрытый вольер
            Assert.AreEqual(false, aviary.Close());
            
            //Попытка закрыть непустой вольер
            aviary.Open();
            aviary.SettleAnimal(new Reptile(ReptileDetachment.Squamata, "семейство1", "род1", "вид1"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);
            
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
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);
            
            //Успешная проверка на допустимость заселения животного в подходящий пустой вольер
            var animal1 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид1");
            var animal2 = new Mammal(MammalDetachment.Chiroptera, "семейство2", "род2", "вид2");
            var animal3 = new Amphibian(AmphibianDetachment.Anura, "семейство3", "род3", "вид3");
            var animal4 = new Reptile(ReptileDetachment.Testudinata, "семейство4", "род4", "вид4");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal1));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal2));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal3));
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal4));
            
            //Успешная проверка на допустимость заселения животного в подходящий непустой вольер
            aviary.SettleAnimal(animal1);
            var animal5 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal5));
            
            //Неуспешная проверка на допустимость заселения животного в неподходящий пустой вольер
            aviary.EvictAnimal(animal1);
            var animal6 = new Fish(FishDetachment.Rajiformes, "семейство8", "род8", "вид8");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal6));
            
            //Неуспешная проверка на допустимость заселения животного в подходящий по типу вольер, но занятый несовместимым животным
            aviary.SettleAnimal(animal1);
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
            var aviary = new GlassAviary(GlassAviaryType.WithWater, 10, 2);
            
            //Успешная попытка заселить животное в подходящий пустой вольер
            var animal1 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид1");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            
            //Успешная попытка заселить животное в подходящий непустой вольер
            var animal2 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));
            
            //Неуспешная попытка заселить животное в неподходящий непустой вольер
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "Страусовые", "Страусы", "Страус");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));
            
            //Неуспешная попытка заселить животное в подходящий полностью заполненный вольер
            var animal4 = new Mammal(MammalDetachment.Rodentia, "семейство1", "род1", "вид2");
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
            var aviary = new GlassAviary(GlassAviaryType.WithWater);
            
            //Успешный поиск существующего животного
            var animal1 = new Reptile(ReptileDetachment.Crocodilia, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);
            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));
            
            //Неуспешный поиск несуществующего животного
            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new GlassAviary(GlassAviaryType.WithWater);

            //Успешная попытка выселить существующее животное
            var animal1 = new Amphibian(AmphibianDetachment.Urodela, "семейство1", "род1", "вид1");
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
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater);

            //Количество обитателей непустого вольера
            var animal1 = new Mammal(MammalDetachment.Chiroptera, "семейство1", "род1", "вид1");
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
            var aviary = new GlassAviary(GlassAviaryType.WithoutWater, 10, 5);
            var animal = new Mammal(MammalDetachment.Chiroptera, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal);
            var str = "Номер:" + aviary.Number +
                      " Тип:GlassAviary Статус:Opened" +
                      "\nВместимость:5 особей, свободно:4 мест" +
                      "\nОбъем:10 куб.м." +
                      "\nРазновидность:WithoutWater";
            Assert.AreEqual(str, aviary.ToString());
        }
    }
}
