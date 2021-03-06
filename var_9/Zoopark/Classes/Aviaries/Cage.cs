﻿using System;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Interfaces;

namespace var_9.Zoopark.Classes.Aviaries
{
    public sealed class Cage : Aviary, IVerification
    {
        private CageType _cageType;
        private double _square; //квадратных метров

        public CageType Kind => _cageType;
        public double Square => _square;

        private Cage() : base() { }
        public Cage(CageType cageType) : base()
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
        public Cage(CageType cageType, double square, byte capacity) : base()
        {
            try
            {
                if (square <= 0 || capacity == 0)
                    throw new ArgumentException("Недопустимые значения площади и/или емкости!!!");
                _cageType = cageType;
                _square = square;
                this.Capacity = capacity;
            }
            catch(ArgumentException)
            {
                throw;
            }
        }

        public override bool IsCorrectForSettlement(Animal individual)
        {
            try
            {
                if (individual == null)
                    throw new ArgumentException("Пустая ссылка на животное!!!");
                if ((((individual is Mammal) &&
                       (((Mammal)individual).Detachment == MammalDetachment.Artiodactyla ||
                        ((Mammal)individual).Detachment == MammalDetachment.Carnivora ||
                        ((Mammal)individual).Detachment == MammalDetachment.Primates ||
                        ((Mammal)individual).Detachment == MammalDetachment.Rodentia ||
                        ((Mammal)individual).Detachment == MammalDetachment.Lagomorpha)) ||
                     ((individual is Bird) &&
                       (((Bird)individual).Detachment != BirdDetachment.Struthioniformes))) &&
                     base.IsCorrectForSettlement(individual))
                {
                    return true;
                }
                return false;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\nПлощадь:" + Square + " кв.м." +
                                     "\nРазновидность:" + Kind.ToString();
        }
    }
}
