using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Animals
{
    [TestClass]
    public class TestFish
    {
        [TestMethod]
        public void TestConstructor()
        {
            var animal = new Fish(FishDetachment.Cypriniformes, "Карповые", "Карпы", "Сазан");
            
            //Проверка параметров корректно созданного животного
            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Fish.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(FishDetachment.Cypriniformes, animal.Detachment);
            Assert.AreEqual("Карповые", animal.Family);
            Assert.AreEqual("Карпы", animal.Genus);
            Assert.AreEqual("Сазан", animal.Species);
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal2 = new Fish(FishDetachment.Anguilliformes, "", "", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal3 = new Fish(FishDetachment.Anguilliformes, " ", " ", " ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal4 = new Fish(FishDetachment.Anguilliformes, "dfd", " ", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Fish(FishDetachment.Rajiformes, "Ромбовые скаты", "Дактилобаты", "Вооруженный дактилобат");
            
            //Проверка корректности формирования полного наименования животного
            var result = animal.GetFullNotation();
            Assert.AreEqual("Fish*Rajiformes*Ромбовые скаты*Дактилобаты*Вооруженный дактилобат", result);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var animal = new Fish(FishDetachment.Rajiformes, "Ромбовые скаты", "Дактилобаты", "Вооруженный дактилобат");
            var str = "Id:" + animal.Id + "\n" +
                      "Класс:Fish\n" +
                      "Отряд:Rajiformes\n" +
                      "Семейство:Ромбовые скаты\n" +
                      "Род:Дактилобаты, Вид:Вооруженный дактилобат";
            Assert.AreEqual(str, animal.ToString());
        }
    }
}
