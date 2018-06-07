using System;
using var_9.Zoopark.Enums.Aviaries;

namespace GUI.Controller.Types
{
    internal class AviaryTypeListElement
    {
        private AviaryType _type;
        public AviaryType Type => _type;

        public AviaryTypeListElement(AviaryType type)
        {
            _type = type;
        }
        public override string ToString()
        {
            string stringType=String.Empty;
            switch (_type)
            {
                case AviaryType.Cage:
                    stringType = "Клетка";
                    break;
                case AviaryType.Yard:
                    stringType = "Загон";
                    break;
                case AviaryType.Pool:
                    stringType = "Водоем";
                    break;
                case AviaryType.GlassAviary:
                    stringType = "Стеклянный вольер";
                    break;
                case AviaryType.Aquarium:
                    stringType = "Аквариум";
                    break;
            }
            return stringType;
        }
    }
}
