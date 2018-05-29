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

            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Fish.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(FishDetachment.Cypriniformes, animal.Detachment);
            Assert.AreEqual("Карповые", animal.Family);
            Assert.AreEqual("Карпы", animal.Genus);
            Assert.AreEqual("Сазан", animal.Species);
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Fish(FishDetachment.Rajiformes, "Ромбовые скаты", "Дактилобаты", "Вооруженный дактилобат");

            var result = animal.GetFullNotation();
            Assert.AreEqual("Fish*Rajiformes*Ромбовые скаты*Дактилобаты*Вооруженный дактилобат", result);
        }
    }
}
