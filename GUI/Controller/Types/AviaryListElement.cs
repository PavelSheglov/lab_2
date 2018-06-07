
using var_9.Zoopark.Classes.Aviaries;

namespace GUI.Controller.Types
{
    internal class AviaryListElement
    {
        private Aviary _aviary;
        public Aviary Aviary =>_aviary;

        public AviaryListElement(Aviary aviary)
        {
            _aviary = aviary;
        }

        public override string ToString()
        {
            return _aviary.Number +"---"+ _aviary.Status;
        }
    }
}
