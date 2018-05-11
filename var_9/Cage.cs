using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Cage : Aviary
    {
        private CageType _cageType;
        private double _square; //квадратных метров

        public CageType CageKind => _cageType;
        public double Square => _square;

        private Cage() : base() { }
        public Cage(CageType cageType) : base(AviaryType.Cage)
        {
            _cageType = cageType;
            switch (cageType)
            {
                case CageType.WithTrees:
                    _square = 15.00;
                    this.Capacity = 10;
                    break;
                case CageType.WithRocks:
                    _square = 15.00;
                    this.Capacity = 5;
                    break;
                case CageType.WithWater:
                    _square = 20.00;
                    this.Capacity = 10;
                    break;
            }
        }
        public Cage(CageType cageType, double square, byte capacity) : base(AviaryType.Cage)
        {
            _cageType = cageType;
            _square = square;
            this.Capacity = capacity;
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            if (((individual is Mammal) &&
                  (((Mammal)individual).Detachment == MammalDetachment.Artiodactyla ||
                   ((Mammal)individual).Detachment == MammalDetachment.Carnivora ||
                   ((Mammal)individual).Detachment == MammalDetachment.Primates ||
                   ((Mammal)individual).Detachment == MammalDetachment.Rodentia ||
                   ((Mammal)individual).Detachment == MammalDetachment.Lagomorpha)) ||
                ((individual is Bird) &&
                  (((Bird)individual).Detachment != BirdDetachment.Struthioniformes)))
            {
                if (base.IsCorrectForSettlement(individual))
                    return true;
            }
            return false;
        }
    }
}
