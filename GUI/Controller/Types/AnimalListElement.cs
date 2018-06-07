
using var_9.Zoopark.Classes.Animals;

namespace GUI.Controller.Types
{
    internal class AnimalListElement
    {
        private Animal _animal;
        public Animal Animal => _animal;

        public AnimalListElement(Animal animal)
        {
            _animal = animal;
        }

        public override string ToString()
        {
            return _animal.Id + "---" + _animal.Species;
        }
    }
}
