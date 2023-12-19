using ConsoleApp1;
    
Random damage = new Random();

Items sword = new Items
{
    Id = 0,
    Name = "Sword",
    Price = 5,
};
Potions potion = new Potions
{
    Id = 100,
    Name = "health potion",
    Price = 10,
    Count = 0,
};

Player bob = new Player
{
    Id = 1, 
    Health = 100, 
    Name = "Bob",
    Damage = damage.Next(Player.MinDamage , Player.MaxDamage),
    FullHealth = 100,
    
};


StartGame.NamePlayer(bob);
StartGame.Game(bob);

while (true)
{
    string? choice;
    
    Console.Write("Вы вошли в пещеру, если вы хотите сразиться - нажмите fight,чтобы сразиться, shop чтобы зайти в магазин и stats, чтобы посмотреть ваши характеристики");
    Console.WriteLine("Чтобы выйти из пещера - нажмите exit");
    Console.WriteLine("Введите действие: ");
    choice = Console.ReadLine();
    switch (choice)
    {
        case "fight": 
            MehanicFight.Fight(bob, potion);
            break;
        case "shop":
            BuyItems.Shop(sword, potion);
            break;
        case "exit":
            goto Exit;
        default:
            Console.WriteLine("Вы ввели неверный ввод, попробуйте заново");
            break;
        case "stats":
            Console.WriteLine($"{bob.Name} - {bob.Health} HP, ваш минимальный урон: {Player.MinDamage}, максимальный урон: {Player.MaxDamage}");
            Console.WriteLine($"Ваше количество монет {Player.Coins}");
            break;
        
    }
    Console.WriteLine();
  
}

Exit:;