using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Animals
{
    [TestClass]
    public class TestAmphibian
    {
        [TestMethod]
        public void TestConstructor()
        {
            var animal = new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон");
            
            //Проверка параметров корректно созданного животного
            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Amphibian.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(AmphibianDetachment.Urodela, animal.Detachment);
            Assert.AreEqual("Саламандровые", animal.Family);
            Assert.AreEqual("Малые тритоны", animal.Genus);
            Assert.AreEqual("Обыкновенный тритон", animal.Species);
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal2 = new Amphibian(AmphibianDetachment.Anura, "", "", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal3 = new Amphibian(AmphibianDetachment.Anura, " ", " ", " ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal4 = new Amphibian(AmphibianDetachment.Anura, "dfd", " ", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Amphibian(AmphibianDetachment.Anura, "Жабы", "Жабы", "Обыкновенная жаба");
            
            //Проверка корректности формирования полного наименования животного
            var result = animal.GetFullNotation();
            Assert.AreEqual("Amphibian*Anura*Жабы*Жабы*Обыкновенная жаба", result);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var animal = new Amphibian(AmphibianDetachment.Anura, "Жабы", "Жабы", "Обыкновенная жаба");
            var str = "Id:" + animal.Id + "\n" +
                      "Класс:Amphibian\n" +
                      "Отряд:Anura\n" +
                      "Семейство:Жабы\n" +
                      "Род:Жабы, Вид:Обыкновенная жаба";
            Assert.AreEqual(str, animal.ToString());
        }
    }
}
