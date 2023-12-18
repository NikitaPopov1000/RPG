using ConsoleApp1;
    


Random damage = new Random();
Items sword = new Items
{
    Id = 0,
    name = "Sword",
    price = 5,
};
Potions potion = new Potions
{
    Id = 100,
    name = "health potion",
    price = 10,
    count = 0,
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
void Heal()
{
    if (potion.count > 0)
    {
        {

        }
        potion.count -= 1;
        bob.Health += 50;
        Console.WriteLine($"Вы лечились, у вас осталось {bob.Health} Hp");
        if (bob.Health > bob.FullHealth)
        {
            bob.Health = bob.FullHealth;
        }
    } else if (potion.count <= 0)
    {
        Console.WriteLine("У вас нет зелья? выполните другое действие");
    }
    Console.WriteLine($"У вас осталось {potion.count} банок зелья");
}

void Fight()
{
    
    Console.WriteLine(
        $"Вы вошли на поле боя, ваш противник: {Spider._name}, у него {bob.Health} HP и {bob.Damage} урона");
    Console.WriteLine("Бой начинается");
    while (bob.Health > 0 && Spider.Health_Spider > 0)
    {
        string? heal;
        Console.WriteLine("Паук атакует");
        bob.Health -= Spider.Damage_Spider;
        Console.WriteLine($"Вас атаковал {Spider._name}, у вас осталось {bob.Health} Hp");
        Console.WriteLine("Ваш ход, что вы выберете? Введите a, чтобы ударить и h, чтобы вылечиться");
        heal = Console.ReadLine();
        if (heal == "a")
        {
            Spider.Health_Spider -= bob.Damage;
            Console.WriteLine($"Вы атаковали {Spider._name}, у противника осталось {Spider.Health_Spider} Hp");
        } else if (heal == "h")
        {
            Heal();
        }
        
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
    Console.WriteLine("Если хотите увидеть зелья - введите 3");
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
                    Player.MaxDamage += 2;
                    Player.MinDamage += 2;
                }
                else if (Player.Coins < sword.price)
                {
                    Console.WriteLine("У вас недостаточно средств");
                }
                
            }

            break;


        case "2":
            Console.WriteLine("Вы вышли из магазина");
            break;
        case "3":
            string? buy_poison;
            Console.WriteLine(" В наличие есть зелье лечения, оно лечит на 50 здоровья и стоит 10 монет, желаете купить? ");
            Console.WriteLine("Если хотите купить - введите 1");
            buy_poison = Console.ReadLine();
            if (buy_poison == "1")
            { 
                if (Player.Coins >= 10)
                {
                    Player.Coins -= 10;
                    potion.count += 1;
                    break;
                }
                else if (Player.Coins < potion.price)
                {
                    Console.WriteLine("У вас недостаточно средств");
                    break;
                }

                
            }

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
  
}

Exit:;