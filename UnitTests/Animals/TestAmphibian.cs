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

            try
            {
                var animal2 = new Amphibian(AmphibianDetachment.Anura, "", "", "");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal3 = new Amphibian(AmphibianDetachment.Anura, " ", " ", " ");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal4 = new Amphibian(AmphibianDetachment.Anura, "dfd", " ", "");
                Assert.Fail();
            }
            catch (Exception) { }
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
