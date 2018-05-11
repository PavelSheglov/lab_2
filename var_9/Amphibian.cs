using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    public sealed class Amphibian : Animal
    {
        private AmphibianDetachment _detachment;

        public AmphibianDetachment Detachment => _detachment;

        private Amphibian() : base() { }
        public Amphibian(AmphibianDetachment detachment, string family, string genus, string species) : base(AnimalClass.Amphibian, family, genus, species)
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
