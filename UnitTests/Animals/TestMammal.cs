using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;

namespace UnitTests.Animals
{
    [TestClass]
    public class TestMammal
    {
        [TestMethod]
        public void TestConstructor()
        {
            var animal = new Mammal(MammalDetachment.Lagomorpha, "Зайцевые", "Зайцы", "Арктический беляк");

            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Mammal.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(MammalDetachment.Lagomorpha, animal.Detachment);
            Assert.AreEqual("Зайцевые", animal.Family);
            Assert.AreEqual("Зайцы", animal.Genus);
            Assert.AreEqual("Арктический беляк", animal.Species);

            try
            {
                var animal2 = new Mammal(MammalDetachment.Artiodactyla, "", "", "");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal3 = new Mammal(MammalDetachment.Artiodactyla, " ", " ", " ");
                Assert.Fail();
            }
            catch (Exception) { }
            try
            {
                var animal4 = new Mammal(MammalDetachment.Artiodactyla, "dfd", " ", "");
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Mammal(MammalDetachment.Chiroptera, "Крылановые", "Летучие лисицы", "Сейшельская летучая лисица");

            var result = animal.GetFullNotation();
            Assert.AreEqual("Mammal*Chiroptera*Крылановые*Летучие лисицы*Сейшельская летучая лисица", result);
        }
    }
}

