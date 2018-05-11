using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class GlassAviary : Aviary
    {
        private GlassAviaryType _glassAviaryType;
        private double _volume;//в метрах кубических

        public GlassAviaryType GlassAviaryKind => _glassAviaryType;
        public double Volume => _volume;

        private GlassAviary() : base() { }
        public GlassAviary(GlassAviaryType glassAviaryType) : base(AviaryType.GlassAviary)
        {
            _glassAviaryType = glassAviaryType;
            switch (glassAviaryType)
            {
                case GlassAviaryType.WithWater:
                    _volume = 12.00;
                    this.Capacity = 5;
                    break;
                case GlassAviaryType.WithoutWater:
                    _volume = 12.00;
                    this.Capacity = 5;
                    break;
            }
        }
        public GlassAviary(GlassAviaryType glassAviaryType, double volume, byte capacity) : base(AviaryType.GlassAviary)
        {
            _glassAviaryType = glassAviaryType;
            _volume = volume;
            this.Capacity = capacity;
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            if (((individual is Mammal) &&
                  (((Mammal)individual).Detachment == MammalDetachment.Rodentia ||
                   ((Mammal)individual).Detachment == MammalDetachment.Chiroptera)) ||
                (individual is Reptile) || (individual is Amphibian))
            {
                if (base.IsCorrectForSettlement(individual))
                    return true;
            }
            return false;
        }
    }
}
