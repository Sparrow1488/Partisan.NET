// See https://aka.ms/new-console-template for more information


using PartisanNET.Core;
using PartisanNET.Core.Static;

Console.WriteLine("Hello, World!");

var equipments = new List<Equipment>
{
    new()
    {
        Title = "Рейдовый рюкзак Raptor 60+",
        Company = "Splav",
        Currency = Currencies.Rub,
        Price = 16_500,
        Description = new Text { Content = "Без описания", Format = TextFormats.Txt },
        Group = "Рюкзаки"
    }
};

var squad = new Squad { Title = "SuperSquad" };

var warriors = new List<Warrior>
{
    new() { Name = "Warrior-1" },
    new() { Name = "Warrior-2" }
};

squad.AddWarrior(warriors[0]);
squad.AddWarrior(warriors[1]);

var purpose = new Purpose
{
    Title = "Боевая задача - 1",
    Description = new Text { Content = "Описание", Format = TextFormats.Txt }
};

squad.AddPurpose(purpose);