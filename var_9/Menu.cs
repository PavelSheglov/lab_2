using System;
using var_9.Zoopark.Classes;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Enums.Animals;
using var_9.Serializer;

namespace var_9
{
    class Menu
    {
        private Zoo _zoo;

        public Menu()
        {
            _zoo = new Zoo();
            StartMenu();
        }

        private void StartMenu()
        {
            bool exit = false;
            while(!exit)
            {
                ShowMenu();
                switch(Console.ReadLine())
                {
                    case "1":
                        CreateZoo();
                        break;
                    case "2":
                        GenerateZoo();
                        break;
                    case "3":
                        ChangeZooName();
                        break;
                    case "4":
                        ChangeZooAddress();
                        break;
                    case "5":
                        ShowGeneralZooInformation();
                        break;
                    case "6":
                        ShowListOfAviaries();
                        break;
                    case "7":
                        ShowListOfAviariesByType();
                        break;
                    case "8":
                        ShowListOfAnimals();
                        break;
                    case "9":
                        ShowListOfAnimalsByClass();
                        break;
                    case "10":
                        ShowInhabitantsOfAviary();
                        break;
                    case "11":
                        AddAviary();
                        break;
                    case "12":
                        SettleAnimal();
                        break;
                    case "13":
                        CloseAviary();
                        break;
                    case "14":
                        OpenAviary();
                        break;
                    case "15":
                        DeleteAviary();
                        break;
                    case "16":
                        EvictAnimal();
                        break;
                    case "17":
                        TransferAnimal();
                        break;
                    case "18":
                        SerializeZoo();
                        break;
                    case "19":
                        DeserializeZoo();
                        break;
                    case "20":
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------МЕНЮ----------------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. Создать новый пустой зоопарк");
            Console.WriteLine("2. Сгенерировать примерный зоопарк");
            Console.WriteLine("3. Изменить название зоопарка");
            Console.WriteLine("4. Изменить адрес зоопарка");
            Console.WriteLine("5. Показать общие сведения о зоопарке");
            Console.WriteLine("6. Показать список всех вольеров");
            Console.WriteLine("7. Показать список вольеров заданного типа");
            Console.WriteLine("8. Показать список всех животных");
            Console.WriteLine("9. Показать список животных заданного класса");
            Console.WriteLine("10. Показать обитателей заданного вольера");
            Console.WriteLine("11. Добавить новый вольер");
            Console.WriteLine("12. Поселить новое животное в любой подходящий вольер");
            Console.WriteLine("13. Найти и закрыть вольер по номеру");
            Console.WriteLine("14. Найти и открыть вольер по номеру");
            Console.WriteLine("15. Найти и удалить вольер по номеру");
            Console.WriteLine("16. Найти и выселить животное по ID");
            Console.WriteLine("17. Переселить животное с заданным ID в другой вольер с заданным номером");
            Console.WriteLine("18. Сериализовать зоопарк");
            Console.WriteLine("19. Десериализовать зоопарк");
            Console.WriteLine("20. Выход");
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
        }

        private void CreateZoo()
        {
            Console.Clear();
            Console.WriteLine("Введите название зоопарка:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите адрес зоопарка:");
            var address = Console.ReadLine();
            _zoo = new Zoo(name, address);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Создан новый пустой зоопарк");
            Console.WriteLine("С названием:{0} и \nадресом:{1}", _zoo.Name, _zoo.Address);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void GenerateZoo()
        {
            _zoo = new Zoo("АО \"Наш новый зоопарк\"", "Россия, г.Н-ск, ул.Новая, 50");

            var aviary1 = new Yard(YardType.Plain);
            System.Threading.Thread.Sleep(20);
            var aviary2 = new Cage(CageType.WithTrees);
            System.Threading.Thread.Sleep(20);
            var aviary3 = new Cage(CageType.WithRocks, 300.00, 3);
            System.Threading.Thread.Sleep(20);
            var aviary4 = new Pool(PoolType.Pond, 400, 10);
            System.Threading.Thread.Sleep(20);
            var aviary5 = new Aquarium(AquariumType.SeaWater, 5, 10);
            System.Threading.Thread.Sleep(20);
            var aviary6 = new GlassAviary(GlassAviaryType.WithWater);
            System.Threading.Thread.Sleep(20);

            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Благородный олень"));
            System.Threading.Thread.Sleep(20);
            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Пятнистый олень"));
            System.Threading.Thread.Sleep(20);
            aviary1.SettleAnimal(new Mammal(MammalDetachment.Artiodactyla, "Оленьи", "Олени", "Пятнистый олень"));
            System.Threading.Thread.Sleep(20);
            aviary2.SettleAnimal(new Mammal(MammalDetachment.Primates, "Гоминиды", "Орангутаны", "Суматранский орангутан"));
            System.Threading.Thread.Sleep(20);
            aviary3.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "Кошачьи", "Пантеры", "Западноафриканский лев"));
            System.Threading.Thread.Sleep(20);
            aviary3.SettleAnimal(new Mammal(MammalDetachment.Carnivora, "Кошачьи", "Пантеры", "Западноафриканский лев"));
            System.Threading.Thread.Sleep(20);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Черный лебедь"));
            System.Threading.Thread.Sleep(20);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Лебедь-шипун"));
            System.Threading.Thread.Sleep(20);
            aviary4.SettleAnimal(new Bird(BirdDetachment.Anseriformes, "Утиные", "Лебеди", "Лебедь-трубач"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Лосось атлантический"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Кумжа"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон"));
            System.Threading.Thread.Sleep(20);
            aviary5.SettleAnimal(new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон"));

            _zoo.AddAviary(aviary1);
            _zoo.AddAviary(aviary2);
            _zoo.AddAviary(aviary3);
            _zoo.AddAviary(aviary4);
            _zoo.AddAviary(aviary5);
            _zoo.AddAviary(aviary6);

            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Сгенерирован зоопарк");
            Console.WriteLine("С названием:{0} и \nадресом:{1}", _zoo.Name, _zoo.Address);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void ChangeZooName()
        {
            Console.Clear();
            Console.WriteLine("Текущее название зоопарка: {0}", _zoo.Name);
            Console.WriteLine("Введите новое название зоопарка:");
            var name = Console.ReadLine();
            if (!String.IsNullOrEmpty(name))
                _zoo.Name = name;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Изменения сохранены");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ChangeZooAddress()
        {
            Console.Clear();
            Console.WriteLine("Текущий адрес зоопарка: {0}", _zoo.Address);
            Console.WriteLine("Введите новый адрес зоопарка:");
            var address = Console.ReadLine();
            if(!String.IsNullOrEmpty(address))
                _zoo.Address = address;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Изменения сохранены");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void ShowGeneralZooInformation()
        {
            Console.Clear();
            Console.WriteLine("-----------------ОБЩИЕ СВЕДЕНИЯ О ЗООПАРКЕ------------------");
            Console.WriteLine(_zoo.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ShowListOfAviaries()
        {
            Console.Clear();
            Console.WriteLine("-----------------СПИСОК ВОЛЬЕРОВ------------------");
            Console.WriteLine("------------------------------------------------");
            foreach (var aviary in _zoo.GetListOfAviaries())
            {
                Console.WriteLine(aviary.ToString());
                Console.WriteLine("------------------------------------------------");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ShowListOfAviariesByType()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип вольера");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Клетка) - (по умолчанию)", AviaryType.Cage.ToString());
            Console.WriteLine("2. {0} (Загон)", AviaryType.Yard.ToString());
            Console.WriteLine("3. {0} (Водоем)", AviaryType.Pool.ToString());
            Console.WriteLine("4. {0} (Аквариум)", AviaryType.Aquarium.ToString());
            Console.WriteLine("5. {0} (Стеклянный вольер)", AviaryType.GlassAviary.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            AviaryType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = AviaryType.Cage;
                    break;
                case "2":
                    type = AviaryType.Yard;
                    break;
                case "3":
                    type = AviaryType.Pool;
                    break;
                case "4":
                    type = AviaryType.Aquarium;
                    break;
                case "5":
                    type = AviaryType.GlassAviary;
                    break;
            }
            Console.Clear();
            Console.WriteLine("-----------------СПИСОК ВОЛЬЕРОВ ТИПА {0}------------------", type.ToString());
            Console.WriteLine("------------------------------------------------");
            foreach (var aviary in _zoo.GetListOfAviaries(type))
            {
                Console.WriteLine(aviary.ToString());
                Console.WriteLine("------------------------------------------------");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ShowListOfAnimals()
        {
            Console.Clear();
            Console.WriteLine("-----------------СПИСОК ЖИВОТНЫХ------------------");
            Console.WriteLine("------------------------------------------------");
            foreach (var animal in _zoo.GetListOfAnimals())
            {
                Console.WriteLine(animal.Id);
                Console.WriteLine(animal.GetFullNotation());
                Console.WriteLine("------------------------------------------------");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ShowListOfAnimalsByClass()
        {
            Console.Clear();
            Console.WriteLine("Выберите класс животного");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Млекопитающие) - (по умолчанию)", AnimalClass.Mammal.ToString());
            Console.WriteLine("2. {0} (Птицы)", AnimalClass.Bird.ToString());
            Console.WriteLine("3. {0} (Рептилии)", AnimalClass.Reptile.ToString());
            Console.WriteLine("4. {0} (Земноводные)", AnimalClass.Amphibian.ToString());
            Console.WriteLine("5. {0} (Рыбы)", AnimalClass.Fish.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            AnimalClass animalClass;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    animalClass = AnimalClass.Mammal;
                    break;
                case "2":
                    animalClass = AnimalClass.Bird;
                    break;
                case "3":
                    animalClass = AnimalClass.Reptile;
                    break;
                case "4":
                    animalClass = AnimalClass.Amphibian;
                    break;
                case "5":
                    animalClass = AnimalClass.Fish;
                    break;
            }
            Console.Clear();
            Console.WriteLine("-----------------СПИСОК ЖИВОТНЫХ КЛАССА {0}------------------", animalClass.ToString());
            Console.WriteLine("------------------------------------------------");
            foreach (var animal in _zoo.GetListOfAnimals(animalClass))
            {
                Console.WriteLine(animal.Id);
                Console.WriteLine(animal.GetFullNotation());
                Console.WriteLine("------------------------------------------------");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private void ShowInhabitantsOfAviary()
        {
            Console.Clear();
            Console.Write("Введите номер вольера:");
            var aviary = _zoo.FindAviary(Console.ReadLine());
            if (aviary == null)
                Console.WriteLine("Вольера с таким номером нет");
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------СПИСОК ЖИВОТНЫХ В ВОЛЬЕРЕ НОМЕР {0}------------------", aviary.Number);
                Console.WriteLine("------------------------------------------------");
                foreach (var animal in aviary.GetListOfInhabitants())
                {
                    Console.WriteLine(animal.Id);
                    Console.WriteLine(animal.GetFullNotation());
                    Console.WriteLine("------------------------------------------------");
                }
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void AddAviary()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип вольера");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Клетка) - (по умолчанию)", AviaryType.Cage.ToString());
            Console.WriteLine("2. {0} (Загон)", AviaryType.Yard.ToString());
            Console.WriteLine("3. {0} (Водоем)", AviaryType.Pool.ToString());
            Console.WriteLine("4. {0} (Аквариум)", AviaryType.Aquarium.ToString());
            Console.WriteLine("5. {0} (Стеклянный вольер)", AviaryType.GlassAviary.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            Aviary aviary;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    aviary = CreateCage();
                    break;
                case "2":
                    aviary = CreateYard();
                    break;
                case "3":
                    aviary = CreatePool();
                    break;
                case "4":
                    aviary = CreateAquarium();
                    break;
                case "5":
                    aviary = CreateGlassAviary();
                    break;
            }
            _zoo.AddAviary(aviary);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Добавлен новый вольер");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(aviary.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private Cage CreateCage()
        {
            Console.WriteLine("Выберите разновидность клетки");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (с деревьями) - (по умолчанию)", CageType.WithTrees.ToString());
            Console.WriteLine("2. {0} (c водой)", CageType.WithWater.ToString());
            Console.WriteLine("3. {0} (с камнями)", CageType.WithRocks.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            CageType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = CageType.WithTrees;
                    break;
                case "2":
                    type = CageType.WithWater;
                    break;
                case "3":
                    type = CageType.WithRocks;
                    break;
            }
            
            try
            {
                Console.Write("Введите площадь (кв.м):");
                double square = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите емкость (кол-во особей):");
                byte capacity = Convert.ToByte(Console.ReadLine());
                return new Cage(type, square, capacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будут использованы значения по умолчанию");
                return new Cage(type);
            }
        }
        private Yard CreateYard()
        {
            Console.WriteLine("Выберите разновидность загона");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (равнинный/степной) - (по умолчанию)", YardType.Plain.ToString());
            Console.WriteLine("2. {0} (каменистый/со скалами)", YardType.Rock.ToString());
            Console.WriteLine("3. {0} (лесной)", YardType.Forest.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            YardType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = YardType.Plain;
                    break;
                case "2":
                    type = YardType.Rock;
                    break;
                case "3":
                    type = YardType.Forest;
                    break;
            }
            try
            {
                Console.Write("Введите площадь (кв.м):");
                double square = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите емкость (кол-во особей):");
                byte capacity = Convert.ToByte(Console.ReadLine());
                return new Yard(type, square, capacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будут использованы значения по умолчанию");
                return new Yard(type);
            }
        }
        private Pool CreatePool()
        {
            Console.WriteLine("Выберите разновидность водоема");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (открытый бассейн) - (по умолчанию)", PoolType.OpenAirPool.ToString());
            Console.WriteLine("2. {0} (крытый бассейн)", PoolType.IndoorsPool.ToString());
            Console.WriteLine("3. {0} (пруд)", PoolType.Pond.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            PoolType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = PoolType.OpenAirPool;
                    break;
                case "2":
                    type = PoolType.IndoorsPool;
                    break;
                case "3":
                    type = PoolType.Pond;
                    break;
            }
            try
            {
                Console.Write("Введите площадь (кв.м):");
                double square = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите емкость (кол-во особей):");
                byte capacity = Convert.ToByte(Console.ReadLine());
                return new Pool(type, square, capacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будут использованы значения по умолчанию");
                return new Pool(type);
            }
        }
        private Aquarium CreateAquarium()
        {
            Console.WriteLine("Выберите разновидность аквариума");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (пресноводный) - (по умолчанию)", AquariumType.Freshwater.ToString());
            Console.WriteLine("2. {0} (с морской водой)", AquariumType.SeaWater.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            AquariumType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = AquariumType.Freshwater;
                    break;
                case "2":
                    type = AquariumType.SeaWater;
                    break;
            }
            try
            {
                Console.Write("Введите объем (куб.м):");
                double volume = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите емкость (кол-во особей):");
                byte capacity = Convert.ToByte(Console.ReadLine());
                return new Aquarium(type, volume, capacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будут использованы значения по умолчанию");
                return new Aquarium(type);
            }      
        }
        private GlassAviary CreateGlassAviary()
        {
            Console.WriteLine("Выберите разновидность стеклянного вольера");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (с водой) - (по умолчанию)", GlassAviaryType.WithWater.ToString());
            Console.WriteLine("2. {0} (без воды)", GlassAviaryType.WithoutWater.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            GlassAviaryType type;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    type = GlassAviaryType.WithWater;
                    break;
                case "2":
                    type = GlassAviaryType.WithoutWater;
                    break;
            }
            try
            {
                Console.Write("Введите объем (куб.м):");
                double volume = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите емкость (кол-во особей):");
                byte capacity = Convert.ToByte(Console.ReadLine());
                return new GlassAviary(type, volume, capacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будут использованы значения по умолчанию");
                return new GlassAviary(type);
            }        
        }

        private void SettleAnimal()
        {
            Console.Clear();
            Console.WriteLine("Выберите класс добавляемого животного");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Млекопитающие) - (по умолчанию)", AnimalClass.Mammal.ToString());
            Console.WriteLine("2. {0} (Птицы)", AnimalClass.Bird.ToString());
            Console.WriteLine("3. {0} (Рептилии)", AnimalClass.Reptile.ToString());
            Console.WriteLine("4. {0} (Земноводные)", AnimalClass.Amphibian.ToString());
            Console.WriteLine("5. {0} (Рыбы)", AnimalClass.Fish.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            Animal animal;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    animal = CreateMammal();
                    break;
                case "2":
                    animal = CreateBird();
                    break;
                case "3":
                    animal = CreateReptile();
                    break;
                case "4":
                    animal = CreateAmphibian();
                    break;
                case "5":
                    animal = CreateFish();
                    break;
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Создано новое животное");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(animal.ToString());
            Console.WriteLine("------------------------------------------------");
            Aviary targetAviary=null;
            foreach(var aviary in _zoo.GetListOfAviaries())
                if(_zoo.SettleAnimal(animal, aviary))
                {
                    targetAviary = aviary;
                    break;
                }
            if(targetAviary!=null)
            {
                Console.WriteLine("Новое животное помещено в вольер номер {0}", targetAviary.Number);
            }
            else
                Console.WriteLine("Подходящий свободный вольер не найден.");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        private Mammal CreateMammal()
        {
            Console.WriteLine("Выберите отряд млекопитающих");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Приматы) - (по умолчанию)", MammalDetachment.Primates.ToString());
            Console.WriteLine("2. {0} (Хищные)", MammalDetachment.Carnivora.ToString());
            Console.WriteLine("3. {0} (Парнокопытные)", MammalDetachment.Artiodactyla.ToString());
            Console.WriteLine("4. {0} (Непарнокопытные)", MammalDetachment.Perissodactyla.ToString());
            Console.WriteLine("5. {0} (Грызуны)", MammalDetachment.Rodentia.ToString());
            Console.WriteLine("6. {0} (Ластоногие)", MammalDetachment.Pinnipedia.ToString());
            Console.WriteLine("7. {0} (Рукокрылые)", MammalDetachment.Chiroptera.ToString());
            Console.WriteLine("8. {0} (Зайцеобразные)", MammalDetachment.Lagomorpha.ToString());
            Console.WriteLine("9. {0} (Китообразные)", MammalDetachment.Cetacea.ToString());
            Console.WriteLine("10. {0} (Хоботные)", MammalDetachment.Proboscidea.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            MammalDetachment detachment;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    detachment = MammalDetachment.Primates;
                    break;
                case "2":
                    detachment = MammalDetachment.Carnivora;
                    break;
                case "3":
                    detachment = MammalDetachment.Artiodactyla;
                    break;
                case "4":
                    detachment = MammalDetachment.Perissodactyla;
                    break;
                case "5":
                    detachment = MammalDetachment.Rodentia;
                    break;
                case "6":
                    detachment = MammalDetachment.Pinnipedia;
                    break;
                case "7":
                    detachment = MammalDetachment.Chiroptera;
                    break;
                case "8":
                    detachment = MammalDetachment.Lagomorpha;
                    break;
                case "9":
                    detachment = MammalDetachment.Cetacea;
                    break;
                case "10":
                    detachment = MammalDetachment.Proboscidea;
                    break;
            }
            try
            {
                 Console.Write("Введите название семейства:");
                 var family = Console.ReadLine();
                 Console.Write("Введите название рода:");
                 var genus = Console.ReadLine();
                 Console.Write("Введите название вида:");
                 var species = Console.ReadLine();
                 return new Mammal(detachment, family, genus, species);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будет создано животное по умолчанию");
                return new Mammal(MammalDetachment.Primates, "Гоминиды", "Шимпанзе", "Обыкновенный шимпанзе");
            }
        }     
        private Bird CreateBird()
        {
            Console.WriteLine("Выберите отряд птиц");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Воробьиные) - (по умолчанию)", BirdDetachment.Passeridae.ToString());
            Console.WriteLine("2. {0} (Ржанковые)", BirdDetachment.Charadriidae.ToString());
            Console.WriteLine("3. {0} (Гусеобразные)", BirdDetachment.Anseriformes.ToString());
            Console.WriteLine("4. {0} (Журавлеобразные)", BirdDetachment.Gruiformes.ToString());
            Console.WriteLine("5. {0} (Аистообразные)", BirdDetachment.Ciconiiformes.ToString());
            Console.WriteLine("6. {0} (Пингвиновые)", BirdDetachment.Sphenisciformes.ToString());
            Console.WriteLine("7. {0} (Страусообразные)", BirdDetachment.Struthioniformes.ToString());
            Console.WriteLine("8. {0} (Курообразные)", BirdDetachment.Galliformes.ToString());
            Console.WriteLine("9. {0} (Соколообразные)", BirdDetachment.Falconiformes.ToString());
            Console.WriteLine("10. {0} (Совообразные)", BirdDetachment.Strigiformes.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            BirdDetachment detachment;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    detachment = BirdDetachment.Passeridae;
                    break;
                case "2":
                    detachment = BirdDetachment.Charadriidae;
                    break;
                case "3":
                    detachment = BirdDetachment.Anseriformes;
                    break;
                case "4":
                    detachment = BirdDetachment.Gruiformes;
                    break;
                case "5":
                    detachment = BirdDetachment.Ciconiiformes;
                    break;
                case "6":
                    detachment = BirdDetachment.Sphenisciformes;
                    break;
                case "7":
                    detachment = BirdDetachment.Struthioniformes;
                    break;
                case "8":
                    detachment = BirdDetachment.Galliformes;
                    break;
                case "9":
                    detachment = BirdDetachment.Falconiformes;
                    break;
                case "10":
                    detachment = BirdDetachment.Strigiformes;
                    break;
            }
            try
            {
                Console.Write("Введите название семейства:");
                var family = Console.ReadLine();
                Console.Write("Введите название рода:");
                var genus = Console.ReadLine();
                Console.Write("Введите название вида:");
                var species = Console.ReadLine();
                return new Bird(detachment, family, genus, species);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будет создано животное по умолчанию");
                return new Bird(BirdDetachment.Passeridae, "Врановые", "Вороны", "Обыкновенный ворон");
            }
        }
        private Reptile CreateReptile()
        {
            Console.WriteLine("Выберите отряд рептилий");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Чешуйчатые) - (по умолчанию)", ReptileDetachment.Squamata.ToString());
            Console.WriteLine("2. {0} (Черепахи)", ReptileDetachment.Testudinata.ToString());
            Console.WriteLine("3. {0} (Крокодилы)", ReptileDetachment.Crocodilia.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            ReptileDetachment detachment;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    detachment = ReptileDetachment.Squamata;
                    break;
                case "2":
                    detachment = ReptileDetachment.Testudinata;
                    break;
                case "3":
                    detachment = ReptileDetachment.Crocodilia;
                    break;
            }
            try
            {
                Console.Write("Введите название семейства:");
                var family = Console.ReadLine();
                Console.Write("Введите название рода:");
                var genus = Console.ReadLine();
                Console.Write("Введите название вида:");
                var species = Console.ReadLine();
                return new Reptile(detachment, family, genus, species);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будет создано животное по умолчанию");
                return new Reptile(ReptileDetachment.Testudinata, "Сухопутные черепахи", "Американские сухопутные черепахи", "Слоновая черепаха");
            }
        }
        private Amphibian CreateAmphibian()
        {
            Console.WriteLine("Выберите отряд рептилий");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Хвостатые) - (по умолчанию)", AmphibianDetachment.Urodela.ToString());
            Console.WriteLine("2. {0} (Бесхвостые)", AmphibianDetachment.Anura.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            AmphibianDetachment detachment;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    detachment = AmphibianDetachment.Urodela;
                    break;
                case "2":
                    detachment = AmphibianDetachment.Anura;
                    break;
            }
            try
            {
                Console.Write("Введите название семейства:");
                var family = Console.ReadLine();
                Console.Write("Введите название рода:");
                var genus = Console.ReadLine();
                Console.Write("Введите название вида:");
                var species = Console.ReadLine();
                return new Amphibian(detachment, family, genus, species);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будет создано животное по умолчанию");
                return new Amphibian(AmphibianDetachment.Urodela, "Саламандровые", "Малые тритоны", "Обыкновенный тритон");
            }
        }
        private Fish CreateFish()
        {
            Console.WriteLine("Выберите отряд рептилий");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. {0} (Окунеобразные) - (по умолчанию)", FishDetachment.Perciformes.ToString());
            Console.WriteLine("2. {0} (Карпообразные)", FishDetachment.Cypriniformes.ToString());
            Console.WriteLine("3. {0} (Осетрообразные)", FishDetachment.Acipenseriformes.ToString());
            Console.WriteLine("4. {0} (Сельдеобразные)", FishDetachment.Clupeiformes.ToString());
            Console.WriteLine("5. {0} (Лососеобразные)", FishDetachment.Salmoniformes.ToString());
            Console.WriteLine("6. {0} (Камбалообразные)", FishDetachment.Pleuronectiformes.ToString());
            Console.WriteLine("7. {0} (Скатообразные)", FishDetachment.Rajiformes.ToString());
            Console.WriteLine("8. {0} (Акулы)", FishDetachment.Selachimorpha.ToString());
            Console.WriteLine("9. {0} (Угреобразные)", FishDetachment.Anguilliformes.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.Write("Ваш выбор:");
            FishDetachment detachment;
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    detachment = FishDetachment.Perciformes;
                    break;
                case "2":
                    detachment = FishDetachment.Cypriniformes;
                    break;
                case "3":
                    detachment = FishDetachment.Acipenseriformes;
                    break;
                case "4":
                    detachment = FishDetachment.Clupeiformes;
                    break;
                case "5":
                    detachment = FishDetachment.Salmoniformes;
                    break;
                case "6":
                    detachment = FishDetachment.Pleuronectiformes;
                    break;
                case "7":
                    detachment = FishDetachment.Rajiformes;
                    break;
                case "8":
                    detachment = FishDetachment.Selachimorpha;
                    break;
                case "9":
                    detachment = FishDetachment.Anguilliformes;
                    break;
            }
            try
            {
                Console.Write("Введите название семейства:");
                var family = Console.ReadLine();
                Console.Write("Введите название рода:");
                var genus = Console.ReadLine();
                Console.Write("Введите название вида:");
                var species = Console.ReadLine();
                return new Fish(detachment, family, genus, species);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Были введены неверные данные, поэтому будет создано животное по умолчанию");
                return new Fish(FishDetachment.Salmoniformes, "Лососёвые", "Лососи", "Атлантический лосось");
            }
        }

        private void CloseAviary()
        {
            Console.Clear();
            Console.Write("Введите номер вольера:");
            var number = Console.ReadLine();
            try
            {
                if (_zoo.CloseAviary(number))
                    Console.WriteLine("Вольер с номером {0} успешно закрыт", number);
                else
                    Console.WriteLine("Вольер с номером {0} не может быть закрыт (например, занят или уже закрыт)", number);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Вольер с номером {0} не существует", number);
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void OpenAviary()
        {
            Console.Clear();
            Console.Write("Введите номер вольера:");
            var number = Console.ReadLine();
            try
            {
                if (_zoo.OpenAviary(number))
                    Console.WriteLine("Вольер с номером {0} успешно открыт", number);
                else
                    Console.WriteLine("Вольер с номером {0} не может быть открыт (например, уже открыт)", number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Вольер с номером {0} не существует", number);
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void DeleteAviary()
        {
            Console.Clear();
            Console.Write("Введите номер вольера:");
            var number = Console.ReadLine();
            try
            {
                if (_zoo.DeleteAviary(number))
                    Console.WriteLine("Вольер с номером {0} успешно удален", number);
                else
                    Console.WriteLine("Вольер с номером {0} не может быть удален (например, занят или не закрыт)", number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Вольер с номером {0} не существует", number);
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
        
        private void EvictAnimal()
        {
            Console.Clear();
            Console.Write("Введите Id животного:");
            var id = Console.ReadLine();
            try
            {
                _zoo.EvictAnimal(_zoo.FindAnimal(id));
                Console.WriteLine("Животное с ID {0} успешно выселено", id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Животное с ID {0} не существует в зоопарке\nи не может быть выселено", id);
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void TransferAnimal()
        {
            Console.Clear();
            Console.Write("Введите Id животного:");
            var id = Console.ReadLine();
            Console.Write("Введите номер вольера, в который переселить животное:");
            var number = Console.ReadLine();
            try
            {
                if (_zoo.TransferAnimal(_zoo.FindAnimal(id), _zoo.FindAviary(number)))
                    Console.WriteLine("Животное с ID {0} успешно переселено\nв вольер с номером {1}", id, number);
                else
                    Console.WriteLine("Животное с ID {0} не может быть переселено\nв вольер с номером {1} (занят/не подходит)", id, number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Животное с ID {0} и/или вольер с номером {1} не существует в зоопарке", id, number);
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void SerializeZoo()
        {
            Console.Clear();
            var serializer = new ZooSerializer();
            try
            {
                serializer.SerializeZoo(_zoo);
                Console.WriteLine("Зоопарк успешно сериализован в файл {0}", serializer.FileName);  
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Зоопарк не был сериализован");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void DeserializeZoo()
        {
            Console.Clear();
            var serializer = new ZooSerializer();
            try
            {
                _zoo = serializer.DeserializeZoo();
                Console.WriteLine("Зоопарк успешно десериализован из файла {0}", serializer.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Зоопарк не был десериализован");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}
