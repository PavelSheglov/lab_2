﻿using System.Text;
using var_9.Zoopark.Interfaces;
using var_9.Zoopark.Enums.Animals;


namespace var_9.Zoopark.Classes.Animals
{
    public sealed class Fish : Animal, INotation
    {
        private FishDetachment _detachment;

        public FishDetachment Detachment => _detachment;

        private Fish() : base() { }
        public Fish(FishDetachment detachment, string family, string genus, string species) : base(family, genus, species)
        {
            _detachment = detachment;
        }

        public override string GetFullNotation()
        {
            var str = new StringBuilder(500);
            str.Append(base.GetFullNotation() + "*" + Detachment.ToString());
            str.Append("*" + this.Family.ToString());
            str.Append("*" + this.Genus.ToString());
            str.Append("*" + this.Species);
            return str.ToString();
        }

        public override string ToString()
        {
            return base.ToString() +
                   "Отряд:" + Detachment.ToString() + "\n" +
                   "Семейство:" + Family + "\n" +
                   "Род:" + Genus +
                   ", Вид:" + Species;
        }
    }
}


