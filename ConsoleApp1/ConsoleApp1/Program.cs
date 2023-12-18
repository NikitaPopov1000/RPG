using ConsoleApp1;
    


Random damage = new Random();
Shop sword = new Shop
{
    Id = 0,
    name = "Sword",
    price = 5,
};

Player bob = new Player
{
    Id = 1, 
    Health = 100, 
    Name = "Bob",
    Damage = damage.Next(Player.MinDamage , Player.MaxDamage),
    FullHealth = 100,
    
};

void Regeneration()
{
    for (var i = 0; i < bob.FullHealth; i++)
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
        Player.Coins += 5;
        Regeneration();
        Spider.Health_Spider = Spider.fullHealthSpider;
    }
}

void Game()
{
    Console.WriteLine($"Добро пожалвоать в игру, ваш персонаж: вас зовут: {bob.Name}, у вас {bob.Health} hp, ваш урон: минимальный: {Player.MinDamage}, максимальный: {Player.MaxDamage}");
}

void NamePlayer()
{
    Console.Write("Введите ваше имя: ");
    string? name = Console.ReadLine();
    bob.Name = name;
}


void Shop()
{
    Console.WriteLine("Добро пожаловать в магазин");
    string? choice;
    Console.WriteLine("Чтобы посмотреть предметы - нажмите 1");
    Console.WriteLine("Чтобы выйти из магазина - 2");
    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":

            Console.WriteLine($"{sword.name} - {sword.price} рублей, дает +2 к урону");
            Console.WriteLine("Если хотите купить прдемет - введите 1");
            int buy;
            buy = Convert.ToInt32((Console.ReadLine()));
            if (buy == 1)
            {
                if (Player.Coins >= sword.price)
                {
                    Player.Coins -= 5;
                    sword.price += 2;
                } 
                else if (Player.Coins < sword.price)
                {
                    Console.WriteLine("У вас недостаточно средств");
                } 
            }

            Player.MaxDamage += 2;
            Player.MinDamage += 2;
            break;

        case "2":
            Console.WriteLine("Вы вышли из магазина");
            break;
        default:
            Console.WriteLine("Вы ввели неверный ввод");
            break;
    }

   


}




NamePlayer();
Game();


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
            Fight();
            break;
        case "shop":
            Shop();
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
    Console.WriteLine();

}

Exit:;