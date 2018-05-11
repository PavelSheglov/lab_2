using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo1 = GenerateZoo();

        }

        static Zoo GenerateZoo()
        {
            var zoo = new Zoo();

            var aviary1 = new Yard(YardType.Plain);
            var aviary2 = new Cage(CageType.WithTrees);
            var aviary3 = new Cage(CageType.WithRocks, 300.00, 3);
            var aviary4 = new Pool(PoolType.Pond, 400, 10);
            var aviary5 = new Aquarium(AquariumType.SeaWater, 5, 10);
            var aviary6 = new GlassAviary(GlassAviaryType.WithWater);

            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Благородный олень"));
            System.Threading.Thread.Sleep(5);
            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Пятнистый олень"));
            System.Threading.Thread.Sleep(5);
            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Пятнистый олень"));
            System.Threading.Thread.Sleep(5);
            aviary2.SettleAnimal(new Mammal(MammalDetachment.Primates, "Гоминиды", "Орангутаны", "Суматранский орангутан"));
            System.Threading.Thread.Sleep(5);
            aviary3.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "Кошачьи", "Пантеры", "Западноафриканский лев"));
            System.Threading.Thread.Sleep(5);
            aviary3.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "Кошачьи", "Пантеры", "Западноафриканский лев"));
            System.Threading.Thread.Sleep(5);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Черный лебедь"));
            System.Threading.Thread.Sleep(5);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Лебедь-шипун"));
            System.Threading.Thread.Sleep(5);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Лебедь-трубач"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососевые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососевые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососевые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососевые", "Лососи", "Кумжа"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон"));
            System.Threading.Thread.Sleep(5);
            aviary5.SettleAnimal(new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон"));

            zoo.AddAviary(aviary1);
            System.Threading.Thread.Sleep(5);
            zoo.AddAviary(aviary2);
            System.Threading.Thread.Sleep(5);
            zoo.AddAviary(aviary3);
            System.Threading.Thread.Sleep(5);
            zoo.AddAviary(aviary4);
            System.Threading.Thread.Sleep(5);
            zoo.AddAviary(aviary5);
            System.Threading.Thread.Sleep(5);
            zoo.AddAviary(aviary6);


            return zoo;
        }
    }
}
