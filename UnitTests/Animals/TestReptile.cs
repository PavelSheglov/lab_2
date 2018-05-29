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

            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Reptile.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(ReptileDetachment.Crocodilia, animal.Detachment);
            Assert.AreEqual("Аллигаторовые", animal.Family);
            Assert.AreEqual("Черные каманы", animal.Genus);
            Assert.AreEqual("Черный кайман", animal.Species);
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Reptile(ReptileDetachment.Squamata, "Гадюковые", "Настоящие гадюки", "Обыкновенная гадюка");

            var result = animal.GetFullNotation();
            Assert.AreEqual("Reptile*Squamata*Гадюковые*Настоящие гадюки*Обыкновенная гадюка", result);
        }
    }
}
