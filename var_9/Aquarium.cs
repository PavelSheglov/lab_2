using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Aquarium : Aviary
    {
        private AquariumType _aquariumType;
        private double _volume;//в метрах кубических

        public AquariumType AquariumKind => _aquariumType;
        public double Volume => _volume;

        private Aquarium() : base() { }
        public Aquarium(AquariumType aquariumType) : base(AviaryType.Aquarium)
        {
            _aquariumType = aquariumType;
            switch (aquariumType)
            {
                case AquariumType.Freshwater:
                    _volume = 2.00;
                    this.Capacity = 5;
                    break;
                case AquariumType.SeaWater:
                    _volume = 2.00;
                    this.Capacity = 5;
                    break;
            }
        }
        public Aquarium(AquariumType aquariumType, double volume, byte capacity) : base(AviaryType.Aquarium)
        {
            _aquariumType = aquariumType;
            _volume = volume;
            this.Capacity = capacity;
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            if (individual is Fish)
            {
                if (base.IsCorrectForSettlement(individual))
                    return true;
            }
            return false;
        }
    }
}
