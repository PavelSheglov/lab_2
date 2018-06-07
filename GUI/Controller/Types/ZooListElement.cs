
using var_9.Zoopark.Classes;

namespace GUI.Controller.Types
{
    internal class ZooListElement
    {
        private Zoo _zoo;
        public Zoo Zoo => _zoo;

        public ZooListElement(Zoo zoo)
        {
            _zoo = zoo;
        }
        public override string ToString()
        {
            return _zoo.Name;
        }
    }
}
