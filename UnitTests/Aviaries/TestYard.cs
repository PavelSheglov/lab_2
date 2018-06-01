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
            //Проверка параметров корректно созданного вольера
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
            //Проверка параметров корректно созданного вольера
            var aviary = new Yard(YardType.Plain, 1000, 3);
            Assert.AreNotEqual("", aviary.Number);
            Assert.AreEqual(AviaryStatus.Opened, aviary.Status);
            Assert.AreEqual(3, aviary.Capacity);
            Assert.AreEqual(3, aviary.FreePlaces);
            Assert.AreEqual(YardType.Plain, aviary.Kind);
            Assert.AreEqual(1000, aviary.Square);
            
            //Попытка создать вольер с недопустимыми значениями параметров
            try
            {
                var aviary2 = new Yard(YardType.Plain, -1, 0);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestCloseAviary()
        {
            var aviary = new Yard(YardType.Rock);
            
            //Успешное закрытие вольера
            Assert.AreEqual(true, aviary.Close());
            Assert.AreEqual(AviaryStatus.Closed, aviary.Status);
            
            //Попытка закрыть уже закрытый вольер
            Assert.AreEqual(false, aviary.Close());
            
            //Попытка закрыть непустой вольер
            aviary.Open();
            aviary.SettleAnimal(new Mammal(MammalDetachment.Perissodactyla, "семейство1", "род1", "вид1"));
            Assert.AreEqual(false, aviary.Close());
        }
        [TestMethod]
        public void TestOpenAviary()
        {
            var aviary = new Yard(YardType.Plain);
            
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
            var aviary = new Yard(YardType.Plain);
            
            //Успешная проверка на допустимость заселения животного в подходящий пустой вольер
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
            
            //Успешная проверка на допустимость заселения животного в подходящий непустой вольер
            aviary.SettleAnimal(animal1);
            var animal6 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.IsCorrectForSettlement(animal6));
            
            //Неуспешная проверка на допустимость заселения животного в неподходящий пустой вольер
            aviary.EvictAnimal(animal1);
            var animal7 = new Mammal(MammalDetachment.Chiroptera, "семейство7", "род7", "вид7");
            Assert.AreEqual(false, aviary.IsCorrectForSettlement(animal7));
            
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
            var aviary = new Yard(YardType.Forest, 100, 2);
            
            //Успешная попытка заселить животное в подходящий пустой вольер
            var animal1 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид1");
            Assert.AreEqual(true, aviary.SettleAnimal(animal1));
            
            //Успешная попытка заселить животное в подходящий непустой вольер
            var animal2 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
            Assert.AreEqual(true, aviary.SettleAnimal(animal2));
            
            //Неуспешная попытка заселить животное в неподходящий непустой вольер
            var animal3 = new Bird(BirdDetachment.Struthioniformes, "семейство3", "род3", "вид3");
            Assert.AreEqual(false, aviary.SettleAnimal(animal3));
            
            //Неуспешная попытка заселить животное в подходящий полностью заполненный вольер
            var animal4 = new Mammal(MammalDetachment.Artiodactyla, "семейство1", "род1", "вид2");
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
            var aviary = new Yard(YardType.Plain);

            //Успешный поиск существующего животного
            var animal1 = new Bird(BirdDetachment.Struthioniformes, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal1);
            Assert.AreEqual(animal1, aviary.FindAnimal(animal1.Id));
            
            //Неуспешный поиск несуществующего животного
            Assert.AreEqual(null, aviary.FindAnimal("any id"));
        }
        [TestMethod]
        public void TestEvictAnimal()
        {
            var aviary = new Yard(YardType.Rock);

            //Успешная попытка выселить существующее животное
            var animal1 = new Mammal(MammalDetachment.Carnivora, "семейство1", "род1", "вид1");
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
            var aviary = new Yard(YardType.Plain);

            //Количество обитателей непустого вольера
            var animal1 = new Bird(BirdDetachment.Struthioniformes, "семейство1", "род1", "вид1");
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
            var aviary = new Yard(YardType.Plain, 500, 10);
            var animal = new Bird(BirdDetachment.Struthioniformes, "семейство1", "род1", "вид1");
            aviary.SettleAnimal(animal);
            var str = "Номер:" + aviary.Number +
                      " Тип:Yard Статус:Opened" +
                      "\nВместимость:10 особей, свободно:9 мест" +
                      "\nПлощадь:500 кв.м." +
                      "\nРазновидность:Plain";
            Assert.AreEqual(str, aviary.ToString());
        }
    }
}
