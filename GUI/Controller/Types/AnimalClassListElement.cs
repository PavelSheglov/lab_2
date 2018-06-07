using System;
using var_9.Zoopark.Enums.Animals;

namespace GUI.Controller.Types
{
    internal class AnimalClassListElement
    {
        private AnimalClass _class;
        public AnimalClass Class => _class;

        public AnimalClassListElement(AnimalClass animalClass)
        {
            _class = animalClass;
        }
        public override string ToString()
        {
            string stringClass = String.Empty;
            switch (_class)
            {
                case AnimalClass.Mammal:
                    stringClass = "Млекопитающие";
                    break;
                case AnimalClass.Bird:
                    stringClass = "Птицы";
                    break;
                case AnimalClass.Reptile:
                    stringClass = "Пресмыкающиеся";
                    break;
                case AnimalClass.Amphibian:
                    stringClass = "Земноводные";
                    break;
                case AnimalClass.Fish:
                    stringClass = "Рыбы";
                    break;
            }
            return stringClass;
        }
    }
}
