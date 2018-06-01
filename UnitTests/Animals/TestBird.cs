using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Animals
{
    [TestClass]
    public class TestBird
    {
        [TestMethod]
        public void TestConstructor()
        {
            var animal = new Bird(BirdDetachment.Falconiformes, "Соколиные", "Соколы", "Кречет");
            
            //Проверка параметров корректно созданного животного
            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Bird.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(BirdDetachment.Falconiformes, animal.Detachment);
            Assert.AreEqual("Соколиные", animal.Family);
            Assert.AreEqual("Соколы", animal.Genus);
            Assert.AreEqual("Кречет", animal.Species);
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal2 = new Bird(BirdDetachment.Anseriformes, "", "", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal3 = new Bird(BirdDetachment.Anseriformes, " ", " ", " ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal4 = new Bird(BirdDetachment.Anseriformes, "dfd", " ", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Bird(BirdDetachment.Anseriformes, "Утиные", "Лесные утки", "Мандаринка");
            
            //Проверка корректности формирования полного наименования животного
            var result = animal.GetFullNotation();
            Assert.AreEqual("Bird*Anseriformes*Утиные*Лесные утки*Мандаринка", result);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var animal = new Bird(BirdDetachment.Anseriformes, "Утиные", "Лесные утки", "Мандаринка");
            var str = "Id:" + animal.Id + "\n" +
                      "Класс:Bird\n" +
                      "Отряд:Anseriformes\n" +
                      "Семейство:Утиные\n" +
                      "Род:Лесные утки, Вид:Мандаринка";
            Assert.AreEqual(str, animal.ToString());
        }
    }
}
