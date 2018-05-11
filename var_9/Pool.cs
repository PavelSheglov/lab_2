using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Pool : Aviary
    {
        private PoolType _poolType;
        private double _square; //квадратных метров

        public PoolType PoolKind => _poolType;
        public double Square => _square;

        private Pool() : base() { }
        public Pool(PoolType poolType) : base(AviaryType.Pool)
        {
            _poolType = poolType;
            switch (poolType)
            {
                case PoolType.OpenAirPool:
                    _square = 15.00;
                    this.Capacity = 10;
                    break;
                case PoolType.IndoorsPool:
                    _square = 15.00;
                    this.Capacity = 5;
                    break;
                case PoolType.Pond:
                    _square = 20.00;
                    this.Capacity = 10;
                    break;
            }
        }
        public Pool(PoolType poolType, double square, byte capacity) : base(AviaryType.Pool)
        {
            _poolType = poolType;
            _square = square;
            this.Capacity = capacity;
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            if (((individual is Mammal) &&
                  (((Mammal)individual).Detachment == MammalDetachment.Pinnipedia ||
                   ((Mammal)individual).Detachment == MammalDetachment.Carnivora ||
                   ((Mammal)individual).Detachment == MammalDetachment.Perissodactyla ||
                   ((Mammal)individual).Detachment == MammalDetachment.Cetacea ||
                   ((Mammal)individual).Detachment == MammalDetachment.Rodentia)) ||
                ((individual is Bird) &&
                  (((Bird)individual).Detachment == BirdDetachment.Anseriformes ||
                   ((Bird)individual).Detachment == BirdDetachment.Sphenisciformes)))
            {
                if (base.IsCorrectForSettlement(individual))
                    return true;
            }
            return false;
        }
    }
}
