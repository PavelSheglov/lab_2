using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Animals
{
    [TestClass]
    public class TestReptile
    {
        [TestMethod]
        public void TestConstructor()
        {
            var animal = new Reptile(ReptileDetachment.Crocodilia, "Аллигаторовые", "Черные каманы", "Черный кайман");
            
            //Проверка параметров корректно созданного животного
            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Reptile.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(ReptileDetachment.Crocodilia, animal.Detachment);
            Assert.AreEqual("Аллигаторовые", animal.Family);
            Assert.AreEqual("Черные каманы", animal.Genus);
            Assert.AreEqual("Черный кайман", animal.Species);
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal2 = new Reptile(ReptileDetachment.Crocodilia, "", "", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal3 = new Reptile(ReptileDetachment.Crocodilia, " ", " ", " ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal4 = new Reptile(ReptileDetachment.Crocodilia, "dfd", " ", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Reptile(ReptileDetachment.Squamata, "Гадюковые", "Настоящие гадюки", "Обыкновенная гадюка");
            
            //Проверка корректности формирования полного наименования животного
            var result = animal.GetFullNotation();
            Assert.AreEqual("Reptile*Squamata*Гадюковые*Настоящие гадюки*Обыкновенная гадюка", result);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var animal = new Reptile(ReptileDetachment.Squamata, "Гадюковые", "Настоящие гадюки", "Обыкновенная гадюка");
            var str = "Id:" + animal.Id + "\n" +
                      "Класс:Reptile\n" +
                      "Отряд:Squamata\n" +
                      "Семейство:Гадюковые\n" +
                      "Род:Настоящие гадюки, Вид:Обыкновенная гадюка";
            Assert.AreEqual(str, animal.ToString());
        }
    }
}
