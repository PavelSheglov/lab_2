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
            
            //Проверка параметров корректно созданного животного
            Assert.AreNotEqual("", animal.Id);
            Assert.AreEqual(AnimalClass.Mammal.ToString(), animal.GetType().Name.ToString());
            Assert.AreEqual(MammalDetachment.Lagomorpha, animal.Detachment);
            Assert.AreEqual("Зайцевые", animal.Family);
            Assert.AreEqual("Зайцы", animal.Genus);
            Assert.AreEqual("Арктический беляк", animal.Species);
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal2 = new Mammal(MammalDetachment.Artiodactyla, "", "", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal3 = new Mammal(MammalDetachment.Artiodactyla, " ", " ", " ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
            
            //Попытка создать животное с некорректными параметрами
            try
            {
                var animal4 = new Mammal(MammalDetachment.Artiodactyla, "dfd", " ", "");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void TestGetFullNotation()
        {
            var animal = new Mammal(MammalDetachment.Chiroptera, "Крылановые", "Летучие лисицы", "Сейшельская летучая лисица");
            
            //Проверка корректности формирования полного наименования животного
            var result = animal.GetFullNotation();
            Assert.AreEqual("Mammal*Chiroptera*Крылановые*Летучие лисицы*Сейшельская летучая лисица", result);
        }
        [TestMethod]
        public void TestToString()
        {
            //Корректное формирование информационной строки
            var animal = new Mammal(MammalDetachment.Chiroptera, "Крылановые", "Летучие лисицы", "Сейшельская летучая лисица");
            var str = "Id:" + animal.Id + "\n" +
                      "Класс:Mammal\n" +
                      "Отряд:Chiroptera\n" +
                      "Семейство:Крылановые\n" +
                      "Род:Летучие лисицы, Вид:Сейшельская летучая лисица";
            Assert.AreEqual(str, animal.ToString());
        }
    }
}

