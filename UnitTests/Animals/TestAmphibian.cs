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

            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Amphibian.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(AmphibianDetachment.Urodela, animal.Detachment);
            Assert.AreEqual("Саламандровые", animal.Family);
            Assert.AreEqual("Малые тритоны", animal.Genus);
            Assert.AreEqual("Обыкновенный тритон", animal.Species);
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Amphibian(AmphibianDetachment.Anura, "Жабы", "Жабы", "Обыкновенная жаба");

            var result = animal.GetFullNotation();
            Assert.AreEqual("Amphibian*Anura*Жабы*Жабы*Обыкновенная жаба", result);
        }
    }
}
