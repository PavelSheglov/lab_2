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

            try
            {
                var animal2 = new Reptile(ReptileDetachment.Crocodilia, "", "", "");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal3 = new Reptile(ReptileDetachment.Crocodilia, " ", " ", " ");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal4 = new Reptile(ReptileDetachment.Crocodilia, "dfd", " ", "");
                Assert.Fail();
            }
            catch (Exception) { }
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
