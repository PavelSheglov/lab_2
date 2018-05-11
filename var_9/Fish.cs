using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Fish : Animal
    {
        private FishDetachment _detachment;

        public FishDetachment Detachment => _detachment;

        private Fish() : base() { }
        public Fish(FishDetachment detachment, string family, string genus, string species) : base(AnimalClass.Fish, family, genus, species)
        {
            _detachment = detachment;
        }

        public override string GetFullNotation()
        {
            var str = new StringBuilder(500);
            str.Append(base.GetFullNotation() + " " + Detachment.ToString());
            str.Append(" " + this.Family.ToString());
            str.Append(" " + this.Name);
            return str.ToString();
        }
    }
}


