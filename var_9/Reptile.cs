using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Reptile : Animal
    {
        private ReptileDetachment _detachment;

        public ReptileDetachment Detachment => _detachment;

        private Reptile() : base() { }
        public Reptile(ReptileDetachment detachment, string family, string genus, string species) : base(AnimalClass.Reptile, family, genus, species)
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
