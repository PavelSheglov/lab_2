using System.Text;

namespace var_9
{
    public sealed class Reptile : Animal
    {
        private ReptileDetachment _detachment;

        public ReptileDetachment Detachment => _detachment;

        private Reptile() : base() { }
        public Reptile(ReptileDetachment detachment, string family, string genus, string species) : base(family, genus, species)
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
