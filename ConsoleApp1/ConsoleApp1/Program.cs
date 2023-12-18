using ConsoleApp1;
    


Random damage = new Random();

Player bob = new Player
{
    Id = 1, 
    Health = 100, 
    Name = "Bob",
    Damage = damage.Next(Player.minDamage , Player.maxDamage),
    FullHealth = 100,
};

void Regeneration()
{
    for (int i = 0; i < bob.FullHealth; i++)
    {
        ++bob.Health;
    }

    if (bob.Health > bob.FullHealth)
    {
        bob.Health = bob.FullHealth;
    }
}

void Fight()
{
    Console.WriteLine(
        $"Вы вошли на поле боя, ваш противник: {Spider._name}, у него {bob.Health} HP и {bob.Damage} урона");
    Console.WriteLine("Бой начинается");
    while (bob.Health > 0 && Spider.Health_Spider > 0)
    {
        Console.WriteLine("Паук атакует");
        bob.Health -= Spider.Damage_Spider;
        Console.WriteLine($"Вас атаковал {Spider._name}, у вас осталось {bob.Health} Hp");
        Spider.Health_Spider -= bob.Damage;
        Console.WriteLine($"Вы атаковали {Spider._name}, у вас осталось {Spider.Health_Spider} Hp");
    }

    if (bob.Health > 0 && Spider.Health_Spider <= 0)
    {
        Console.WriteLine($"Вы вышли из поля боя, ваш противник побежден");
        Regeneration();
        Spider.Health_Spider = Spider.fullHealthSpider;
    }
}

void Game()
{
    Console.WriteLine($"Добро пожалвоать в игру, ваш персонаж: вас зовут: {bob.Name}, у вас {bob.Health} hp, ваш урон: минимальный: {Player.minDamage}, максимальный: {Player.maxDamage}");
}

void NamePlayer()
{
    Console.Write("Введите ваше имя: ");
    string? name = Console.ReadLine();
    bob.Name = name;
}


NamePlayer();
Game();

string choice;
while (true)
{
    Console.Write("Вы вошли в пещеру, если вы хотите сразиться - нажмите y: ");
    Console.WriteLine(bob.Health);
    choice = Console.ReadLine();
    if (choice == "y")
    {
        Fight();
    }
    else if(choice == "n")
    {
        break;
    }
    
}