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

            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Bird.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(BirdDetachment.Falconiformes, animal.Detachment);
            Assert.AreEqual("Соколиные", animal.Family);
            Assert.AreEqual("Соколы", animal.Genus);
            Assert.AreEqual("Кречет", animal.Species);

            try
            {
                var animal2 = new Bird(BirdDetachment.Anseriformes, "", "", "");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal3 = new Bird(BirdDetachment.Anseriformes, " ", " ", " ");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal4 = new Bird(BirdDetachment.Anseriformes, "dfd", " ", "");
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Bird(BirdDetachment.Anseriformes, "Утиные", "Лесные утки", "Мандаринка");

            var result = animal.GetFullNotation();
            Assert.AreEqual("Bird*Anseriformes*Утиные*Лесные утки*Мандаринка", result);
        }
    }
}
