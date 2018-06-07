using System.Collections.Generic;
using System.Linq;
using var_9.Zoopark.Classes;
using var_9.Zoopark.Classes.Aviaries;
using var_9.Zoopark.Classes.Animals;
using var_9.Zoopark.Enums.Aviaries;
using var_9.Zoopark.Enums.Animals;
using GUI.Controller.Types;

namespace GUI.Controller
{
    public class ZooController
    {
        private List<ZooListElement> _zooList;
        private List<AviaryListElement> _aviaryList;
        private List<AnimalListElement> _animalList;

        public ZooController()
        {
            _zooList = new List<ZooListElement>();
            _aviaryList = new List<AviaryListElement>();
            _animalList = new List<AnimalListElement>();
        }
        //--------Зоопарки 
        public void AddZoo(string name, string address)
        {
            _zooList.Add(new ZooListElement(new Zoo(name, address)));
        }

        public void DeleteZoo(object zoo)
        {
            if((zoo as ZooListElement).Zoo.GetListOfAviaries().Count==0)
                _zooList.Remove((ZooListElement)zoo);
        }

        public List<object> GetZooList()
        {
            return _zooList.ToList<object>();
        }

        public string GetZooInformation(object zoo)
        {
            return (zoo as ZooListElement).Zoo.ToString();
        }

        public string GetZooName(object zoo)
        {
            return (zoo as ZooListElement).Zoo.Name;
        }

        public string GetZooAddress(object zoo)
        {
            return (zoo as ZooListElement).Zoo.Address;
        }

        public void SetZooName(object zoo, string name)
        {
            (zoo as ZooListElement).Zoo.Name = name;
        }

        public void SetZooAddress(object zoo, string address)
        {
            (zoo as ZooListElement).Zoo.Address = address;
        }
        //---------Вольеры
        public void AddAviary(object zoo, object type, object kind, double size, byte capacity)
        {
            Aviary aviary = null;
            switch((type as AviaryTypeListElement).Type)
            {
                case AviaryType.Cage:
                    if(size>0 && capacity>0)
                        aviary = new Cage((CageType)kind, size, capacity);
                    else
                        aviary = new Cage((CageType)kind);
                    break;
                case AviaryType.Yard:
                    if (size > 0 && capacity > 0)
                        aviary = new Yard((YardType)kind, size, capacity);
                    else
                        aviary = new Yard((YardType)kind);
                    break;
                case AviaryType.Pool:
                    if (size > 0 && capacity > 0)
                        aviary = new Pool((PoolType)kind, size, capacity);
                    else
                        aviary = new Pool((PoolType)kind);
                    break;
                case AviaryType.GlassAviary:
                    if (size > 0 && capacity > 0)
                        aviary = new GlassAviary((GlassAviaryType)kind, size, capacity);
                    else
                        aviary = new GlassAviary((GlassAviaryType)kind);
                    break;
                case AviaryType.Aquarium:
                    if (size > 0 && capacity > 0)
                        aviary = new Aquarium((AquariumType)kind, size, capacity);
                    else
                        aviary = new Aquarium((AquariumType)kind);
                    break;
            }
            (zoo as ZooListElement).Zoo.AddAviary(aviary);
        }

        public void DeleteAviary(object zoo, object aviary)
        {
            (zoo as ZooListElement).Zoo.DeleteAviary((aviary as AviaryListElement).Aviary.Number);
        }

        public void OpenAviary(object aviary)
        {
            (aviary as AviaryListElement).Aviary.Open();
        }

        public void CloseAviary(object aviary)
        {
            (aviary as AviaryListElement).Aviary.Close();
        }

        public List<object> GetAviaryTypesList()
        {
            var aviaryTypesList = new List<AviaryTypeListElement>()
                                      { new AviaryTypeListElement(AviaryType.Cage),
                                        new AviaryTypeListElement(AviaryType.Yard),
                                        new AviaryTypeListElement(AviaryType.Pool),
                                        new AviaryTypeListElement(AviaryType.GlassAviary),
                                        new AviaryTypeListElement(AviaryType.Aquarium)
                                      };
            return aviaryTypesList.ToList<object>();
        }

        public List<object> GetAviaryKindsList(object type)
        {
            List<object> kindsList = new List<object>();
            switch ((type as AviaryTypeListElement).Type)
            {
                case AviaryType.Cage:
                    var cageList = new List<CageType> {   CageType.WithTrees,
                                                          CageType.WithWater,
                                                          CageType.WithRocks };
                    foreach (var cage in cageList)
                        kindsList.Add((object)cage);
                    break;
                case AviaryType.Yard:
                    var yardList = new List<YardType> {   YardType.Plain,
                                                          YardType.Rock,
                                                          YardType.Forest };
                    foreach (var yard in yardList)
                        kindsList.Add((object)yard);
                    break;
                case AviaryType.Pool:
                    var poolList = new List<PoolType> {   PoolType.OpenAirPool,
                                                          PoolType.IndoorsPool,
                                                          PoolType.Pond };
                    foreach (var pool in poolList)
                        kindsList.Add((object)pool);
                    break;
                case AviaryType.GlassAviary:
                    var glassAviaryList = new List<GlassAviaryType> {   GlassAviaryType.WithWater,
                                                                        GlassAviaryType.WithoutWater };
                    foreach (var glassAviary in glassAviaryList)
                        kindsList.Add((object)glassAviary);
                    break;
                case AviaryType.Aquarium:
                    var aquariumList = new List<AquariumType> {   AquariumType.Freshwater,
                                                                  AquariumType.SeaWater };
                    foreach (var aquariumAviary in aquariumList)
                        kindsList.Add((object)aquariumAviary);
                    break;
            }
            return kindsList;
        }

        public List<object> GetAviaryList(object zoo)
        {
            _aviaryList.Clear();
            foreach (var aviary in (zoo as ZooListElement).Zoo.GetListOfAviaries())
                _aviaryList.Add(new AviaryListElement(aviary));
            return _aviaryList.ToList<object>();
        }

        public string GetAviaryInformation(object aviary)
        {
            return (aviary as AviaryListElement).Aviary.ToString();
        }
        //---------Животные
        public List<object> GetAnimalClassesList()
        {
            var animalClassesList = new List<AnimalClassListElement>()
                                      { new AnimalClassListElement(AnimalClass.Mammal),
                                        new AnimalClassListElement(AnimalClass.Bird),
                                        new AnimalClassListElement(AnimalClass.Reptile),
                                        new AnimalClassListElement(AnimalClass.Amphibian),
                                        new AnimalClassListElement(AnimalClass.Fish)
                                      };
            return animalClassesList.ToList<object>();
        }

        public List<object> GetAnimalDetachmentsList(object animalClass)
        {
            List<object> detachmentsList = new List<object>();
            switch ((animalClass as AnimalClassListElement).Class)
            {
                case AnimalClass.Mammal:
                    var mammalList = new List<MammalDetachment> {   MammalDetachment.Primates,
                                                                    MammalDetachment.Carnivora,
                                                                    MammalDetachment.Artiodactyla,
                                                                    MammalDetachment.Perissodactyla,
                                                                    MammalDetachment.Rodentia,
                                                                    MammalDetachment.Pinnipedia,
                                                                    MammalDetachment.Chiroptera,
                                                                    MammalDetachment.Lagomorpha,
                                                                    MammalDetachment.Cetacea,
                                                                    MammalDetachment.Proboscidea
                                                                };
                    foreach (var mammal in mammalList)
                        detachmentsList.Add((object)mammal);
                    break;
                case AnimalClass.Bird:
                    var birdList = new List<BirdDetachment> {   BirdDetachment.Passeridae,
                                                                BirdDetachment.Charadriidae,
                                                                BirdDetachment.Anseriformes,
                                                                BirdDetachment.Gruiformes,
                                                                BirdDetachment.Ciconiiformes,
                                                                BirdDetachment.Sphenisciformes,
                                                                BirdDetachment.Struthioniformes,
                                                                BirdDetachment.Galliformes,
                                                                BirdDetachment.Falconiformes,
                                                                BirdDetachment.Strigiformes
                                                            };
                    foreach (var bird in birdList)
                        detachmentsList.Add((object)bird);
                    break;
                case AnimalClass.Reptile:
                    var reptileList = new List<ReptileDetachment> { ReptileDetachment.Squamata,
                                                                    ReptileDetachment.Testudinata,
                                                                    ReptileDetachment.Crocodilia
                                                                  };
                    foreach (var reptile in reptileList)
                        detachmentsList.Add((object)reptile);
                    break;
                case AnimalClass.Amphibian:
                    var amphibianList = new List<AmphibianDetachment> {  AmphibianDetachment.Urodela,
                                                                         AmphibianDetachment.Anura
                                                                      };
                    foreach (var amphibian in amphibianList)
                        detachmentsList.Add((object)amphibian);
                    break;
                case AnimalClass.Fish:
                    var fishList = new List<FishDetachment> {   FishDetachment.Perciformes,
                                                                FishDetachment.Cypriniformes,
                                                                FishDetachment.Acipenseriformes,
                                                                FishDetachment.Clupeiformes,
                                                                FishDetachment.Salmoniformes,
                                                                FishDetachment.Pleuronectiformes,
                                                                FishDetachment.Rajiformes,
                                                                FishDetachment.Selachimorpha,
                                                                FishDetachment.Anguilliformes
                                                            };
                    foreach (var fish in fishList)
                        detachmentsList.Add((object)fish);
                    break;
            }
            return detachmentsList;
        }

        public List<object> GetAnimalList(object zoo, object aviary)
        {
            _animalList.Clear();
            if(aviary==null)
                foreach (var animal in (zoo as ZooListElement).Zoo.GetListOfAnimals())
                    _animalList.Add(new AnimalListElement(animal));
            else
                foreach (var animal in (aviary as AviaryListElement).Aviary.GetListOfInhabitants())
                    _animalList.Add(new AnimalListElement(animal));
            return _animalList.ToList<object>();
        }

        public string GetAnimalInformation(object animal)
        {
            return (animal as AnimalListElement).Animal.ToString();
        }

        public void AddAnimal(object zoo, object aviary, object animalClass, object detachment, string family, string genus, string species)
        {
            Animal animal = null;
            switch ((animalClass as AnimalClassListElement).Class)
            {
                case AnimalClass.Mammal:
                    animal = new Mammal((MammalDetachment)detachment, family, genus, species);
                    break;
                case AnimalClass.Bird:
                    animal = new Bird((BirdDetachment)detachment, family, genus, species);
                    break;
                case AnimalClass.Reptile:
                    animal = new Reptile((ReptileDetachment)detachment, family, genus, species);
                    break;
                case AnimalClass.Amphibian:
                    animal = new Reptile((ReptileDetachment)detachment, family, genus, species);
                    break;
                case AnimalClass.Fish:
                    animal = new Fish((FishDetachment)detachment, family, genus, species);
                    break;
            }
            (zoo as ZooListElement).Zoo.SettleAnimal(animal, (aviary as AviaryListElement).Aviary);
        }

        public void DeleteAnimal(object zoo, object aviary, object animal)
        {
            if (aviary == null)
                (zoo as ZooListElement).Zoo.EvictAnimal((animal as AnimalListElement).Animal);
            else
                (aviary as AviaryListElement).Aviary.EvictAnimal((animal as AnimalListElement).Animal);
        }

        public void TransferAnimal(object zoo, object targetAviary, object animal)
        {
            if((targetAviary as AviaryListElement).Aviary.FindAnimal((animal as AnimalListElement).Animal.Id)==null)
                (zoo as ZooListElement).Zoo.TransferAnimal((animal as AnimalListElement).Animal, (targetAviary as AviaryListElement).Aviary);
        }
    }
}
